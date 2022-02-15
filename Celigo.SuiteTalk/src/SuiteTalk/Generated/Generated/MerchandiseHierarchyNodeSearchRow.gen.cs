using System;

namespace SuiteTalk
{
    public partial class MerchandiseHierarchyNodeSearchRow: SearchRow<MerchandiseHierarchyNodeSearchRowBasic>
    {
        public MerchandiseHierarchyNodeSearchRowBasic GetBasic() => this.basic;

        public MerchandiseHierarchyNodeSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new MerchandiseHierarchyNodeSearchRowBasic();
            return this.basic;
        }

        public MerchandiseHierarchyNodeSearchRowBasic CreateBasic(Action<MerchandiseHierarchyNodeSearchRowBasic> initializer)
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

        private static SearchRowBasic GetOrCreateJoin(MerchandiseHierarchyNodeSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "parentNodeJoin":
                    result = target.parentNodeJoin;
                    creator = () => target.parentNodeJoin = new MerchandiseHierarchyNodeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("MerchandiseHierarchyNodeSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}