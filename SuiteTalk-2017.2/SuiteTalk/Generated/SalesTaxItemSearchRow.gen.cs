using System;

namespace SuiteTalk
{
    public partial class SalesTaxItemSearchRow: IAdvancedSearchRow, IAdvancedSearchRow<SalesTaxItemSearchRowBasic>, SupportsCustomSearchJoin
    {
        public SalesTaxItemSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic IAdvancedSearchRow.GetBasic() => this.basic;

        public SalesTaxItemSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new SalesTaxItemSearchRowBasic();
            return this.basic;
        }

        public SalesTaxItemSearchRowBasic CreateBasic(Action<SalesTaxItemSearchRowBasic> initializer)
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


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(SalesTaxItemSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "taxTypeJoin":
                    result = target.taxTypeJoin;
                    creator = () => target.taxTypeJoin = new TaxTypeSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("SalesTaxItemSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}