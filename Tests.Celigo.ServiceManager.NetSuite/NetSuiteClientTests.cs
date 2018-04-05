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
        public async void Applies_search_pereferences_to_Search_requests()
        {
            const int pageSize = 10;

            var searchColumns = new TransactionSearchRow();
            searchColumns.CreateBasic(b => {
                b.SetColumns(new[] {
                    nameof(b.tranId),
                    nameof(b.amount),
                    nameof(b.entity)
                });
            });

            var searchResult = await client.searchAsync(
                new TransactionSearchAdvanced {
                    columns = searchColumns,
                    criteria = new TransactionSearch {
                        basic = new TransactionSearchBasic {
                            dateCreated = new SearchDateField {
                                @operator = SearchDateFieldOperator.after,
                                operatorSpecified = true,
                                searchValue = new DateTime(2018, 01, 01),
                                searchValueSpecified = true
                            }
                        }
                    }
                }, new SearchPreferences {
                    pageSize = pageSize,
                    pageSizeSpecified = true
                }
            );
            searchResult.status.isSuccess.Should().BeTrue();
            searchResult.pageSize.Should().Be(pageSize);
            searchResult.searchRowList.Length.Should().BeGreaterThan(0);
        }
    }
}
