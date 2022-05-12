
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ItemAccountMappingSearch: ISearch, ISearch<ItemAccountMappingSearchBasic>
    {
        public ItemAccountMappingSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ItemAccountMappingSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ItemAccountMappingSearchBasic();
            return this.basic;
        }

        ISearch<ItemAccountMappingSearchBasic> 
            ISearch<ItemAccountMappingSearchBasic>.CreateBasic(Action<ItemAccountMappingSearchBasic> initializer) => this.CreateBasic(initializer);

        public ItemAccountMappingSearch CreateBasic(Action<ItemAccountMappingSearchBasic> initializer)
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

        ISearch<ItemAccountMappingSearchBasic> 
            ISearch<ItemAccountMappingSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ItemAccountMappingSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ItemAccountMappingSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ItemAccountMappingSearchBasic();
                    break;

                case "classJoin":
                    result = target.classJoin;
                    creator = () => target.classJoin = new ClassificationSearchBasic();
                    break;
        
                case "departmentJoin":
                    result = target.departmentJoin;
                    creator = () => target.departmentJoin = new DepartmentSearchBasic();
                    break;
        
                case "destinationAccountJoin":
                    result = target.destinationAccountJoin;
                    creator = () => target.destinationAccountJoin = new AccountSearchBasic();
                    break;
        
                case "locationJoin":
                    result = target.locationJoin;
                    creator = () => target.locationJoin = new LocationSearchBasic();
                    break;
        
                case "sourceAccountJoin":
                    result = target.sourceAccountJoin;
                    creator = () => target.sourceAccountJoin = new AccountSearchBasic();
                    break;
        
                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ItemAccountMappingSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}