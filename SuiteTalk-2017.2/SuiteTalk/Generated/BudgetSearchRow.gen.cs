// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class BudgetSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<BudgetSearchRowBasic>, SupportsCustomSearchJoin
    {
        public BudgetSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public BudgetSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BudgetSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<BudgetSearchRowBasic> 
            ISearchAdvancedRow<BudgetSearchRowBasic>.CreateBasic(Action<BudgetSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public BudgetSearchRow CreateBasic(Action<BudgetSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return this;
        }

        SearchRowBasic ISearchAdvancedRow.CreateBasic() => this.CreateBasic();

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        ISearchAdvancedRow<BudgetSearchRowBasic> 
            ISearchAdvancedRow<BudgetSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public BudgetSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(BudgetSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new BudgetSearchRowBasic();
                    break;
                default:
                    throw new ArgumentException("BudgetSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}