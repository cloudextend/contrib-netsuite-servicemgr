// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class BillingAccountSearch: ISearch, ISearch<BillingAccountSearchBasic>
    {
        public BillingAccountSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public BillingAccountSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BillingAccountSearchBasic();
            return this.basic;
        }

        ISearch<BillingAccountSearchBasic> 
            ISearch<BillingAccountSearchBasic>.CreateBasic(Action<BillingAccountSearchBasic> initializer) => this.CreateBasic(initializer);

        public BillingAccountSearch CreateBasic(Action<BillingAccountSearchBasic> initializer)
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

        ISearch<BillingAccountSearchBasic> 
            ISearch<BillingAccountSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public BillingAccountSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(BillingAccountSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new BillingAccountSearchBasic();
                    break;

                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("BillingAccountSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}