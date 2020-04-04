// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class BillingScheduleSearch: ISearch, ISearch<BillingScheduleSearchBasic>
    {
        public BillingScheduleSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public BillingScheduleSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BillingScheduleSearchBasic();
            return this.basic;
        }

        ISearch<BillingScheduleSearchBasic> 
            ISearch<BillingScheduleSearchBasic>.CreateBasic(Action<BillingScheduleSearchBasic> initializer) => this.CreateBasic(initializer);

        public BillingScheduleSearch CreateBasic(Action<BillingScheduleSearchBasic> initializer)
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

        ISearch<BillingScheduleSearchBasic> 
            ISearch<BillingScheduleSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public BillingScheduleSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(BillingScheduleSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new BillingScheduleSearchBasic();
                    break;
                default:
                    throw new ArgumentException("BillingScheduleSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}