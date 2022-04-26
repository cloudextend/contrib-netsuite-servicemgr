
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class MerchandiseHierarchyNodeSearch: ISearch, ISearch<MerchandiseHierarchyNodeSearchBasic>
    {
        public MerchandiseHierarchyNodeSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public MerchandiseHierarchyNodeSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new MerchandiseHierarchyNodeSearchBasic();
            return this.basic;
        }

        ISearch<MerchandiseHierarchyNodeSearchBasic> 
            ISearch<MerchandiseHierarchyNodeSearchBasic>.CreateBasic(Action<MerchandiseHierarchyNodeSearchBasic> initializer) => this.CreateBasic(initializer);

        public MerchandiseHierarchyNodeSearch CreateBasic(Action<MerchandiseHierarchyNodeSearchBasic> initializer)
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

        ISearch<MerchandiseHierarchyNodeSearchBasic> 
            ISearch<MerchandiseHierarchyNodeSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public MerchandiseHierarchyNodeSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(MerchandiseHierarchyNodeSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new MerchandiseHierarchyNodeSearchBasic();
                    break;

                case "parentNodeJoin":
                    result = target.parentNodeJoin;
                    creator = () => target.parentNodeJoin = new MerchandiseHierarchyNodeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("MerchandiseHierarchyNodeSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}