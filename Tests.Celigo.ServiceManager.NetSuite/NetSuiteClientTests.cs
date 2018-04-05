using Celigo.ServiceManager.NetSuite;
using FluentAssertions;
using SuiteTalk;
using System;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite
{
    using Meta;

    public class NetSuiteClientTests
    {
        private readonly INetSuiteClient client;

        public NetSuiteClientTests()
        {
            var config = new TestConfiguration();
            var factory = new ClientFactory(config.ApplicationId);
            client = factory.CreateClient(config.PassportProvider);
        }

        [Fact]
        public async void Can_execute_a_parameterless_SuiteTalk_method()
        {
            
            var serverTimeResult = await client.getServerTimeAsync();
            serverTimeResult.status.isSuccess.Should().BeTrue();
            serverTimeResult.serverTime.Year.Should().Be(DateTime.Now.Year);
        }

        [Fact]
        public async void Can_execute_a_parameterized_SuiteTalk_method()
        {
            var customizationResult = await client.getCustomizationIdAsync(new CustomizationType {
                getCustomizationType = GetCustomizationType.customRecordType,
                getCustomizationTypeSpecified = true
            }, false);
            customizationResult.status.isSuccess.Should().BeTrue();
        }

        [Fact]
        public async void Can_execute_a_method_that_returns_a_paged_result()
        {
            var searchColumns = new TransactionSearchRow();
            searchColumns.CreateBasic(b => {
                b.SetColumns(new[] {
                    nameof(b.tranId),
                    nameof(b.amount),
                    nameof(b.entity)
                });
            });

            var searchResult = await client.searchAsync(
                null,
                new TransactionSearchAdvanced { columns = searchColumns }
            );
            searchResult.status.isSuccess.Should().BeTrue();
            searchResult.searchRowList.Length.Should().BeGreaterThan(0);
        }
    }
}
