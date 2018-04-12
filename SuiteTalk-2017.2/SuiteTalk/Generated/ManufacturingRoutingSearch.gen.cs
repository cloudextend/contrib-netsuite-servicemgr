// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ManufacturingRoutingSearch: ISearch, ISearch<ManufacturingRoutingSearchBasic>
    {
        public ManufacturingRoutingSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ManufacturingRoutingSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ManufacturingRoutingSearchBasic();
            return this.basic;
        }

        ISearch<ManufacturingRoutingSearchBasic> 
            ISearch<ManufacturingRoutingSearchBasic>.CreateBasic(Action<ManufacturingRoutingSearchBasic> initializer) => this.CreateBasic(initializer);

        public ManufacturingRoutingSearch CreateBasic(Action<ManufacturingRoutingSearchBasic> initializer)
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

        ISearch<ManufacturingRoutingSearchBasic> 
            ISearch<ManufacturingRoutingSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ManufacturingRoutingSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ManufacturingRoutingSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ManufacturingRoutingSearchBasic();
                    break;

                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
        
                case "locationJoin":
                    result = target.locationJoin;
                    creator = () => target.locationJoin = new LocationSearchBasic();
                    break;
        
                case "manufacturingCostTemplateJoin":
                    result = target.manufacturingCostTemplateJoin;
                    creator = () => target.manufacturingCostTemplateJoin = new ManufacturingCostTemplateSearchBasic();
                    break;
        
                case "manufacturingWorkCenterJoin":
                    result = target.manufacturingWorkCenterJoin;
                    creator = () => target.manufacturingWorkCenterJoin = new EntityGroupSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ManufacturingRoutingSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}