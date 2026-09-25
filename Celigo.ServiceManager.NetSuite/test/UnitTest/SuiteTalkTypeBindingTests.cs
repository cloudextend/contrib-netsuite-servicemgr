using System;
using System.Xml.Serialization;
using FluentAssertions;
using SuiteTalk;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite
{
    /// <summary>
    /// Guards the generated SuiteTalk proxy classes against a bad svcutil draw.
    ///
    /// svcutil flattens every NetSuite XML namespace into the single C# namespace
    /// "SuiteTalk". Three NetSuite types collide on name under that flattening, and
    /// svcutil resolves each collision by suffixing "1" onto whichever of the pair it
    /// emits second. That choice is not stable across runs, and a wrong draw does not
    /// break the build: feature-metadata stores the type name as the literal string
    /// "SiteCategory1" in committed JSON, so item uploads would silently bind to the
    /// website-category record instead. These tests fail the build in that case.
    ///
    /// Regenerate with scripts/regen-suitetalk.sh, which enforces the same mapping.
    /// </summary>
    public class SuiteTalkTypeBindingTests
    {
        private const string WsdlYear = "2025_2";
        private const string SuiteTalkVersion = "2025.2";

        [Theory]
        [InlineData(typeof(SiteCategory), "website", null)]
        [InlineData(typeof(SiteCategory1), "accounting", "SiteCategory")]
        [InlineData(typeof(CustomerSalesTeam), "common", null)]
        [InlineData(typeof(CustomerSalesTeam1), "relationships", "CustomerSalesTeam")]
        [InlineData(typeof(CurrencyRate), "accounting", null)]
        [InlineData(typeof(CurrencyRate1), "core", "CurrencyRate")]
        public void Collision_renamed_types_bind_to_their_expected_schema(
            Type type, string schemaFamily, string expectedXmlTypeName)
        {
            var attribute = (XmlTypeAttribute)Attribute.GetCustomAttribute(type, typeof(XmlTypeAttribute));

            attribute.Should().NotBeNull($"{type.Name} must carry an XmlTypeAttribute");
            attribute.Namespace.Should().StartWith($"urn:{schemaFamily}_{WsdlYear}",
                $"{type.Name} is bound to the wrong NetSuite schema - svcutil swapped the " +
                "collision suffix. Rerun scripts/regen-suitetalk.sh.");

            // The suffixed twin must still serialize under the unsuffixed XML name,
            // otherwise the C# rename would leak onto the wire.
            if (expectedXmlTypeName != null)
            {
                attribute.TypeName.Should().Be(expectedXmlTypeName);
            }
        }

        [Fact]
        public void Schema_urns_match_the_declared_suitetalk_version()
        {
            SuiteTalkSchemas.Messages.Should().Be(
                $"urn:messages_{WsdlYear}.platform.webservices.netsuite.com");
            SuiteTalkSchemas.Core.Should().Be(
                $"urn:core_{WsdlYear}.platform.webservices.netsuite.com");

            new NetSuitePortTypeClient().SuiteTalkVersion.Should().Be(SuiteTalkVersion);

            // Downstream generators stamp their output from this rather than from the
            // URNs. Leaving it behind ships metadata advertising the previous WSDL year.
            SuiteTalkSchemas.WsdlVersion.Should().Be(SuiteTalkVersion);
        }

        [Fact]
        public void Generated_stub_has_no_positional_element_ordering()
        {
            // Order= makes the serializer match elements by position. NetSuite returns
            // them out of order, so inherited fields deserialize empty with no error.
            var elements = Attribute.GetCustomAttributes(
                typeof(BomRevisionComponent).GetProperty(nameof(BomRevisionComponent.id)),
                typeof(XmlElementAttribute));

            foreach (XmlElementAttribute element in elements)
            {
                element.Order.Should().Be(-1,
                    "Order= must be stripped after svcutil; see Celigo.SuiteTalk/src/README.md");
            }
        }
    }
}
