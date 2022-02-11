// Generator: ProviderGenerator, Template: Providers
using System;

namespace SuiteTalk
{
    partial class NetSuitePortTypeClient
    {
        SearchPreferences IPreferenceProvider.GetSearchPreferences() => this.searchPreferences;

        Preferences IPreferenceProvider.GetPreferences() => this.preferences;
    }
} 