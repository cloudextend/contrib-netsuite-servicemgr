// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class ManufacturingRoutingSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<ManufacturingRoutingSearchRowBasic>, SupportsCustomSearchJoin
    {
        public ManufacturingRoutingSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public ManufacturingRoutingSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ManufacturingRoutingSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<ManufacturingRoutingSearchRowBasic> 
            ISearchAdvancedRow<ManufacturingRoutingSearchRowBasic>.CreateBasic(Action<ManufacturingRoutingSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ManufacturingRoutingSearchRow CreateBasic(Action<ManufacturingRoutingSearchRowBasic> initializer)
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

        ISearchAdvancedRow<ManufacturingRoutingSearchRowBasic> 
            ISearchAdvancedRow<ManufacturingRoutingSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ManufacturingRoutingSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
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
        private static SearchRowBasic GetOrCreateJoin(ManufacturingRoutingSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ManufacturingRoutingSearchRowBasic();
                    break;

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