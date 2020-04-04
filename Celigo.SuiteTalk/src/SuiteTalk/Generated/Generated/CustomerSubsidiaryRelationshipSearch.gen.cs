// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class CustomerSubsidiaryRelationshipSearch: ISearch, ISearch<CustomerSubsidiaryRelationshipSearchBasic>
    {
        public CustomerSubsidiaryRelationshipSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public CustomerSubsidiaryRelationshipSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new CustomerSubsidiaryRelationshipSearchBasic();
            return this.basic;
        }

        ISearch<CustomerSubsidiaryRelationshipSearchBasic> 
            ISearch<CustomerSubsidiaryRelationshipSearchBasic>.CreateBasic(Action<CustomerSubsidiaryRelationshipSearchBasic> initializer) => this.CreateBasic(initializer);

        public CustomerSubsidiaryRelationshipSearch CreateBasic(Action<CustomerSubsidiaryRelationshipSearchBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return this;
        }

        SearchRecordBasic ISearch.CreateBasic() => this.CreateBasic();

        public SearchRecordBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRecordBasic => (J)this.GetJoin(joinName);

        public SearchRecordBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRecordBasic => (J)this.CreateJoin(joinName);

        ISearch<CustomerSubsidiaryRelationshipSearchBasic> 
            ISearch<CustomerSubsidiaryRelationshipSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public CustomerSubsidiaryRelationshipSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(CustomerSubsidiaryRelationshipSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new CustomerSubsidiaryRelationshipSearchBasic();
                    break;

                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchBasic();
                    break;
                        default:
                    throw new ArgumentException("CustomerSubsidiaryRelationshipSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}