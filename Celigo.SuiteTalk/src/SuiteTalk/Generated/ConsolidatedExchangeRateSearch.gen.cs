
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ConsolidatedExchangeRateSearch: ISearch, ISearch<ConsolidatedExchangeRateSearchBasic>
    {
        public ConsolidatedExchangeRateSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ConsolidatedExchangeRateSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ConsolidatedExchangeRateSearchBasic();
            return this.basic;
        }

        ISearch<ConsolidatedExchangeRateSearchBasic> 
            ISearch<ConsolidatedExchangeRateSearchBasic>.CreateBasic(Action<ConsolidatedExchangeRateSearchBasic> initializer) => this.CreateBasic(initializer);

        public ConsolidatedExchangeRateSearch CreateBasic(Action<ConsolidatedExchangeRateSearchBasic> initializer)
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

        ISearch<ConsolidatedExchangeRateSearchBasic> 
            ISearch<ConsolidatedExchangeRateSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ConsolidatedExchangeRateSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ConsolidatedExchangeRateSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ConsolidatedExchangeRateSearchBasic();
                    break;

                case "fromSubsidiaryJoin":
                    result = target.fromSubsidiaryJoin;
                    creator = () => target.fromSubsidiaryJoin = new SubsidiarySearchBasic();
                    break;
        
                case "periodJoin":
                    result = target.periodJoin;
                    creator = () => target.periodJoin = new AccountingPeriodSearchBasic();
                    break;
        
                case "toSubsidiaryJoin":
                    result = target.toSubsidiaryJoin;
                    creator = () => target.toSubsidiaryJoin = new SubsidiarySearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ConsolidatedExchangeRateSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}