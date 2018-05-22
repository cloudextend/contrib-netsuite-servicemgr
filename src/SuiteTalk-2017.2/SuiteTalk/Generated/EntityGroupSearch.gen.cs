// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class EntityGroupSearch: ISearch, ISearch<EntityGroupSearchBasic>
    {
        public EntityGroupSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public EntityGroupSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new EntityGroupSearchBasic();
            return this.basic;
        }

        ISearch<EntityGroupSearchBasic> 
            ISearch<EntityGroupSearchBasic>.CreateBasic(Action<EntityGroupSearchBasic> initializer) => this.CreateBasic(initializer);

        public EntityGroupSearch CreateBasic(Action<EntityGroupSearchBasic> initializer)
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

        ISearch<EntityGroupSearchBasic> 
            ISearch<EntityGroupSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public EntityGroupSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(EntityGroupSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new EntityGroupSearchBasic();
                    break;

                case "groupMemberJoin":
                    result = target.groupMemberJoin;
                    creator = () => target.groupMemberJoin = new EntitySearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("EntityGroupSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}