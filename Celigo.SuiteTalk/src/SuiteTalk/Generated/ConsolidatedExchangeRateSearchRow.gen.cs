
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class ConsolidatedExchangeRateSearchRow: ISearchRow, ISearchRow<ConsolidatedExchangeRateSearchRowBasic>
    {
        public ConsolidatedExchangeRateSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public ConsolidatedExchangeRateSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ConsolidatedExchangeRateSearchRowBasic();
            return this.basic;
        }

        ISearchRow<ConsolidatedExchangeRateSearchRowBasic> 
            ISearchRow<ConsolidatedExchangeRateSearchRowBasic>.CreateBasic(Action<ConsolidatedExchangeRateSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ConsolidatedExchangeRateSearchRow CreateBasic(Action<ConsolidatedExchangeRateSearchRowBasic> initializer)
        {
            var rowBasic = this.CreateBasic();
            initializer(rowBasic);
            return this;
        }

        SearchRowBasic ISearchRow.CreateBasic() => this.CreateBasic();

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        ISearchRow<ConsolidatedExchangeRateSearchRowBasic> 
            ISearchRow<ConsolidatedExchangeRateSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ConsolidatedExchangeRateSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.fromSubsidiaryJoin;
      //      yield return this.periodJoin;
      //      yield return this.toSubsidiaryJoin;
      //      yield return this.userJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(ConsolidatedExchangeRateSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ConsolidatedExchangeRateSearchRowBasic();
                    break;


                case "fromSubsidiaryJoin":
                    result = target.fromSubsidiaryJoin;
                    creator = () => target.fromSubsidiaryJoin = new SubsidiarySearchRowBasic();
                    break;
        
                case "periodJoin":
                    result = target.periodJoin;
                    creator = () => target.periodJoin = new AccountingPeriodSearchRowBasic();
                    break;
        
                case "toSubsidiaryJoin":
                    result = target.toSubsidiaryJoin;
                    creator = () => target.toSubsidiaryJoin = new SubsidiarySearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ConsolidatedExchangeRateSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}