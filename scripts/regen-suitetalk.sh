#!/usr/bin/env bash
#
# Regenerate Celigo.SuiteTalk proxy classes from a NetSuite WSDL.
#
# Usage:  scripts/regen-suitetalk.sh 2025_2
#
# svcutil flattens every NetSuite XML namespace into the single C# namespace
# "SuiteTalk". Three NetSuite types collide on name under that flattening, and
# svcutil resolves each collision by suffixing "1" onto whichever of the pair
# it happens to emit second. That choice is NOT stable: repeated runs of the
# same WSDL with the same svcutil produce different assignments.
#
# A wrong assignment does not fail the build. feature-metadata stores the type
# name as the literal string "SiteCategory1" in its committed JSON, so a bad
# draw silently binds item uploads to the website-category record instead.
# This script therefore regenerates until the assignment matches CANONICAL
# below, and refuses to install anything else.

set -euo pipefail

readonly REPO_ROOT="$(cd "$(dirname "${BASH_SOURCE[0]}")/.." && pwd)"
readonly TARGET="${REPO_ROOT}/Celigo.SuiteTalk/src/Connected Services/SuiteTalk/Reference.cs"
readonly MAX_ATTEMPTS="${MAX_ATTEMPTS:-12}"

# C#-name -> NetSuite XML namespace family it must bind to. Derived from the
# 2024.1 stub that every downstream consumer already compiles against; keeping
# it identical is what makes the WSDL bump a non-event for them.
readonly CANONICAL_TYPES=(SiteCategory1 CustomerSalesTeam1 CurrencyRate1)
readonly CANONICAL_NS=(accounting relationships core)

log() { printf '%s\n' "$*" >&2; }
die() { log "ERROR: $*"; exit 1; }

usage() {
  log "usage: $(basename "$0") <wsdl_version>   e.g. $(basename "$0") 2025_2"
  exit 2
}

# Reads which XML namespace family a generated C# class is bound to.
binding_of() {
  local file="$1" type="$2"
  grep -B3 "^    public partial class ${type}\b" "$file" \
    | grep -o 'Namespace="urn:[a-z]*' | tail -1 | sed 's/.*urn://'
}

matches_canonical() {
  local file="$1" i actual
  for i in "${!CANONICAL_TYPES[@]}"; do
    actual="$(binding_of "$file" "${CANONICAL_TYPES[$i]}")"
    [ "$actual" = "${CANONICAL_NS[$i]}" ] || return 1
  done
}

report_bindings() {
  local file="$1" i actual flag
  for i in "${!CANONICAL_TYPES[@]}"; do
    actual="$(binding_of "$file" "${CANONICAL_TYPES[$i]}")"
    [ "$actual" = "${CANONICAL_NS[$i]}" ] && flag="ok" || flag="MISMATCH"
    log "    ${CANONICAL_TYPES[$i]} -> ${actual:-<absent>} (want ${CANONICAL_NS[$i]}) ${flag}"
  done
}

# Order= makes the serializer match elements by position. NetSuite returns them
# out of order, so inherited fields deserialize empty with no error raised.
# DefaultValueAttribute makes explicit false/zero values vanish from requests.
apply_post_processing() {
  local file="$1"
  perl -pi -e 's/\(Order=[0-9]+\)//g; s/,\s*Order=[0-9]+//g;' "$file"
  perl -pi -e 's{^(\s*)(\[System\.ComponentModel\.DefaultValueAttribute)}{$1//$2};' "$file"

  local leftover
  leftover="$(grep -c 'Order=' "$file" || true)"
  [ "$leftover" -eq 0 ] || die "post-processing left ${leftover} Order= attributes"
}

main() {
  [ $# -eq 1 ] || usage
  local version="$1"
  [[ "$version" =~ ^[0-9]{4}_[0-9]$ ]] || die "version must look like 2025_2, got '${version}'"

  local wsdl="https://webservices.netsuite.com/wsdl/v${version}_0/netsuite.wsdl"
  local attempt generated
  # Global so the EXIT trap can still see it once main() has returned.
  WORKDIR="$(mktemp -d)"
  trap 'rm -rf "${WORKDIR:-}"' EXIT

  for (( attempt = 1; attempt <= MAX_ATTEMPTS; attempt++ )); do
    log "attempt ${attempt}/${MAX_ATTEMPTS}: generating from ${wsdl}"
    rm -rf "${WORKDIR:?}/out" && mkdir -p "$WORKDIR/out"
    (
      cd "$WORKDIR/out"
      DOTNET_ROLL_FORWARD=Major dotnet svcutil "$wsdl" -n "*,SuiteTalk" >/dev/null 2>&1
    ) || die "svcutil failed"

    generated="$WORKDIR/out/ServiceReference/Reference.cs"
    [ -s "$generated" ] || die "svcutil produced no output"

    if matches_canonical "$generated"; then
      log "  collision bindings match canonical"
      apply_post_processing "$generated"
      cp "$generated" "$TARGET"
      log "installed -> ${TARGET}"
      report_bindings "$TARGET"
      return 0
    fi

    log "  collision bindings differ, discarding:"
    report_bindings "$generated"
  done

  die "no canonical generation after ${MAX_ATTEMPTS} attempts; raise MAX_ATTEMPTS or revisit CANONICAL_*"
}

main "$@"
