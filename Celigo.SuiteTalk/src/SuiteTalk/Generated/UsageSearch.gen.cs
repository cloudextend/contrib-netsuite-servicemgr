
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class UsageSearch: ISearch, ISearch<UsageSearchBasic>
    {
        public UsageSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public UsageSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new UsageSearchBasic();
            return this.basic;
        }

        ISearch<UsageSearchBasic> 
            ISearch<UsageSearchBasic>.CreateBasic(Action<UsageSearchBasic> initializer) => this.CreateBasic(initializer);

        public UsageSearch CreateBasic(Action<UsageSearchBasic> initializer)
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

        ISearch<UsageSearchBasic> 
            ISearch<UsageSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public UsageSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(UsageSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new UsageSearchBasic();
                    break;

                case "chargeJoin":
                    result = target.chargeJoin;
                    creator = () => target.chargeJoin = new ChargeSearchBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
        
                case "subscriptionPlanJoin":
                    result = target.subscriptionPlanJoin;
                    creator = () => target.subscriptionPlanJoin = new ItemSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("UsageSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}