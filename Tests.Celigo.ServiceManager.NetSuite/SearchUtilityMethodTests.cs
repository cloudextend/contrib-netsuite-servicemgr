using FluentAssertions;
using SuiteTalk;
using Xunit;

namespace Tests.Celigo.ServiceManager.NetSuite
{
    public class Search_utility_method_tests
    { 
        [Fact]
        public void Create_basic_of_a_SearchRow()
        {
            var searchRow = new CustomerSearchRow();
            var basic = searchRow.CreateBasic();

            basic.Should().BeOfType<CustomerSearchRowBasic>();
            searchRow.basic.Should().NotBeNull();
            searchRow.basic.Should().Be(basic);
        }

        [Fact]
        public void Get_basic_of_a_SearchRow()
        {
            var searchRow = new TransactionSearchRow();
            var basic = searchRow.GetBasic();
            basic.Should().BeNull();

            var createdBasic = searchRow.CreateBasic();
            basic = searchRow.GetBasic();
            basic.Should().NotBeNull();
            basic.Should().Be(createdBasic);
        }

        [Fact]
        public void Create_basic_of_an_IAdvancedSearchRow()
        {
            IAdvancedSearchRow row = new SupportCaseSearchRow();
            var basic = row.CreateBasic();
            basic.Should().BeOfType<SupportCaseSearchRowBasic>();
        }

        [Fact]
        public void Get_basic_of_an_IAdvancedSearchRow()
        {
            IAdvancedSearchRow row = new SupportCaseSearchRow();
            var basic = row.GetBasic();
            basic.Should().BeNull();

            basic = row.CreateBasic();
            basic.Should().BeOfType<SupportCaseSearchRowBasic>();
            basic.Should().Be(row.GetBasic());
        }

        [Fact]
        public void Create_a_join_on_a_SearchRow_by_name()
        {
            var searchRow = new AccountSearchRow();
            var userJoin = searchRow.CreateJoin("userJoin");

            userJoin.Should().NotBeNull();
            userJoin.Should().BeOfType<EmployeeSearchRowBasic>();

            searchRow.userJoin.Should().NotBeNull();
            searchRow.userJoin.Should().Be(userJoin);
        }

        [Fact]
        public void Get_a_join_on_a_SearchRow_by_name()
        {
            var searchRow = new BillingAccountSearchRow();
            var jobJoin = searchRow.GetJoin("jobJoin");

            jobJoin.Should().BeNull();

            var createdJoin = searchRow.CreateJoin("jobJoin");
            jobJoin = searchRow.GetJoin("jobJoin");
            
            jobJoin.Should().Be(createdJoin);
        }

        [Fact]
        public void Set_a_search_column_by_name_on_SearchRowBasic()
        {
            var basic = new EmployeeSearchRowBasic();
            basic.SetColumns(new[] {
                nameof(basic.email),
                nameof(basic.dateCreated),
                nameof(basic.country),
                nameof(basic.@class),
                nameof(basic.entityNumber)
            });

            basic.email.Should().NotBeNull();
            basic.email.Length.Should().Be(1);
            basic.email[0].customLabel.Should().Be("email");

            basic.dateCreated.Should().NotBeNull();
            basic.dateCreated.Length.Should().Be(1);
            basic.dateCreated[0].customLabel.Should().Be("dateCreated");

            basic.country.Should().NotBeNull();
            basic.country.Length.Should().Be(1);
            basic.country[0].customLabel.Should().Be("country");

            basic.@class.Should().NotBeNull();
            basic.@class.Length.Should().Be(1);
            basic.@class[0].customLabel.Should().Be("class");

            basic.entityNumber.Should().NotBeNull();
            basic.entityNumber.Length.Should().Be(1);
            basic.entityNumber[0].customLabel.Should().Be("entityNumber");
        }
    }
}
