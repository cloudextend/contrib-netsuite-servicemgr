using Celigo.ServiceManager.NetSuite;
using FluentAssertions;
using SuiteTalk;
using System;
using System.Text;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite
{
    using Meta;
    using System.Linq;
    using Task = System.Threading.Tasks.Task;

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
        public async Task Can_execute_a_parameterless_SuiteTalk_method()
        {
            var serverTimeResult = await client.getServerTimeAsync();
            serverTimeResult.status.isSuccess.Should().BeTrue();
            serverTimeResult.serverTime.Year.Should().Be(DateTime.Now.Year);
        }

        [Fact]
        public async Task Can_execute_a_parameterized_SuiteTalk_method()
        {
            var customizationResult = await client.getCustomizationIdAsync(new CustomizationType {
                getCustomizationType = GetCustomizationType.customRecordType,
                getCustomizationTypeSpecified = true
            }, false);
            customizationResult.status.isSuccess.Should().BeTrue();
        }

        [Fact]
        public async Task Applies_search_pereferences_to_Search_requests()
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

        [Fact]
        public async Task Deserializes_base_class_properties_when_fetching()
        {
            // This test fails due to a NS WSDL issue as explained in https://github.com/dotnet/wcf/issues/3073
            // In order to fix this, remove all occurences of Order=[0-9]+

            var customizationList = await client.getCustomizationIdAsync(new CustomizationType {
                getCustomizationType = GetCustomizationType.transactionBodyCustomField,
                getCustomizationTypeSpecified = true,
            }, false);

            customizationList.status.isSuccess.Should().BeTrue();
            customizationList.customizationRefList.Should().NotBeNull();
            customizationList.customizationRefList.Length.Should().BeGreaterThan(0,
                "Test is inconclusive on this account without Transaction Body Custom Fields");

            var customFields = await client.getListAsync(customizationList.customizationRefList);
            customFields.status.isSuccess.Should().BeTrue();
            customFields.readResponse.Should().NotBeNull();
            customFields.readResponse.Length.Should().BeGreaterThan(0);
            customFields.readResponse.All(r => r.record is TransactionBodyCustomField field && field.fieldTypeSpecified)
                .Should().BeTrue();
        }

        [Fact]
        public async Task Can_upload_files()
        {
            var result = await client.addAsync(
                new File {
                    name = "TestUrl.url",
                    url = "https://google.com"
                }
            );
        }
    }
}
