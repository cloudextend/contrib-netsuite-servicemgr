// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class FairValuePriceSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<FairValuePriceSearchRowBasic>, SupportsCustomSearchJoin
    {
        public FairValuePriceSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public FairValuePriceSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new FairValuePriceSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<FairValuePriceSearchRowBasic> 
            ISearchAdvancedRow<FairValuePriceSearchRowBasic>.CreateBasic(Action<FairValuePriceSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public FairValuePriceSearchRow CreateBasic(Action<FairValuePriceSearchRowBasic> initializer)
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

        ISearchAdvancedRow<FairValuePriceSearchRowBasic> 
            ISearchAdvancedRow<FairValuePriceSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public FairValuePriceSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
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
        private static SearchRowBasic GetOrCreateJoin(FairValuePriceSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new FairValuePriceSearchRowBasic();
                    break;
                default:
                    throw new ArgumentException("FairValuePriceSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}