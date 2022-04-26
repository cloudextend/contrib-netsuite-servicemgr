
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ItemRevisionSearch: ISearch, ISearch<ItemRevisionSearchBasic>
    {
        public ItemRevisionSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ItemRevisionSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ItemRevisionSearchBasic();
            return this.basic;
        }

        ISearch<ItemRevisionSearchBasic> 
            ISearch<ItemRevisionSearchBasic>.CreateBasic(Action<ItemRevisionSearchBasic> initializer) => this.CreateBasic(initializer);

        public ItemRevisionSearch CreateBasic(Action<ItemRevisionSearchBasic> initializer)
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

        ISearch<ItemRevisionSearchBasic> 
            ISearch<ItemRevisionSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ItemRevisionSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ItemRevisionSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ItemRevisionSearchBasic();
                    break;

                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ItemRevisionSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}