using System;

namespace SuiteTalk
{
    public partial class ConsolidatedExchangeRateSearchRow: IAdvancedSearchRow, IAdvancedSearchRow<ConsolidatedExchangeRateSearchRowBasic>
    {
        public ConsolidatedExchangeRateSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic IAdvancedSearchRow.GetBasic() => this.basic;

        public ConsolidatedExchangeRateSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ConsolidatedExchangeRateSearchRowBasic();
            return this.basic;
        }

        public ConsolidatedExchangeRateSearchRowBasic CreateBasic(Action<ConsolidatedExchangeRateSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return basic;
        }

        SearchRowBasic IAdvancedSearchRow.CreateBasic() => this.CreateBasic();

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        public J CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return join;
        }

        private static SearchRowBasic GetOrCreateJoin(ConsolidatedExchangeRateSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

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