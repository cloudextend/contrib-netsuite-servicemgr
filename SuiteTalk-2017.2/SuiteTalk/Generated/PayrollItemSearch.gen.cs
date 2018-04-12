// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class PayrollItemSearch: ISearch, ISearch<PayrollItemSearchBasic>
    {
        public PayrollItemSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public PayrollItemSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PayrollItemSearchBasic();
            return this.basic;
        }

        ISearch<PayrollItemSearchBasic> 
            ISearch<PayrollItemSearchBasic>.CreateBasic(Action<PayrollItemSearchBasic> initializer) => this.CreateBasic(initializer);

        public PayrollItemSearch CreateBasic(Action<PayrollItemSearchBasic> initializer)
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

        ISearch<PayrollItemSearchBasic> 
            ISearch<PayrollItemSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PayrollItemSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(PayrollItemSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PayrollItemSearchBasic();
                    break;
                default:
                    throw new ArgumentException("PayrollItemSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}