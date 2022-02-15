using System;

namespace SuiteTalk
{
    public partial class ManufacturingCostTemplateSearchRow: SearchRow<ManufacturingCostTemplateSearchRowBasic>, SupportsCustomSearchJoin
    {
        public ManufacturingCostTemplateSearchRowBasic GetBasic() => this.basic;

        public ManufacturingCostTemplateSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ManufacturingCostTemplateSearchRowBasic();
            return this.basic;
        }

        public ManufacturingCostTemplateSearchRowBasic CreateBasic(Action<ManufacturingCostTemplateSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return basic;
        }

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
        private static SearchRowBasic GetOrCreateJoin(ManufacturingCostTemplateSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ManufacturingCostTemplateSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}