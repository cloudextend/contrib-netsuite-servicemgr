using System;

namespace SuiteTalk
{
    public partial class ManufacturingRoutingSearchRow: SearchRow, SupportsCustomSearchJoin
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ManufacturingRoutingSearchRowBasic();
            return this.basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(ManufacturingRoutingSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "locationJoin":
                    result = target.locationJoin;
                    creator = () => target.locationJoin = new LocationSearchRowBasic();
                    break;
        
                case "manufacturingCostTemplateJoin":
                    result = target.manufacturingCostTemplateJoin;
                    creator = () => target.manufacturingCostTemplateJoin = new ManufacturingCostTemplateSearchRowBasic();
                    break;
        
                case "manufacturingWorkCenterJoin":
                    result = target.manufacturingWorkCenterJoin;
                    creator = () => target.manufacturingWorkCenterJoin = new EntityGroupSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ManufacturingRoutingSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}