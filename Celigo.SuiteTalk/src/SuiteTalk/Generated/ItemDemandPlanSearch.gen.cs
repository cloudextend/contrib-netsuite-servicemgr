
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ItemDemandPlanSearch: ISearch, ISearch<ItemDemandPlanSearchBasic>
    {
        public ItemDemandPlanSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ItemDemandPlanSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ItemDemandPlanSearchBasic();
            return this.basic;
        }

        ISearch<ItemDemandPlanSearchBasic> 
            ISearch<ItemDemandPlanSearchBasic>.CreateBasic(Action<ItemDemandPlanSearchBasic> initializer) => this.CreateBasic(initializer);

        public ItemDemandPlanSearch CreateBasic(Action<ItemDemandPlanSearchBasic> initializer)
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

        ISearch<ItemDemandPlanSearchBasic> 
            ISearch<ItemDemandPlanSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ItemDemandPlanSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ItemDemandPlanSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ItemDemandPlanSearchBasic();
                    break;

                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
        
                case "lastAlternateSourceItemJoin":
                    result = target.lastAlternateSourceItemJoin;
                    creator = () => target.lastAlternateSourceItemJoin = new ItemSearchBasic();
                    break;
        
                case "locationJoin":
                    result = target.locationJoin;
                    creator = () => target.locationJoin = new LocationSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ItemDemandPlanSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}