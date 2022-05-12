
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class MerchandiseHierarchyNodeSearchRow: ISearchRow, ISearchRow<MerchandiseHierarchyNodeSearchRowBasic>
    {
        public MerchandiseHierarchyNodeSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public MerchandiseHierarchyNodeSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new MerchandiseHierarchyNodeSearchRowBasic();
            return this.basic;
        }

        ISearchRow<MerchandiseHierarchyNodeSearchRowBasic> 
            ISearchRow<MerchandiseHierarchyNodeSearchRowBasic>.CreateBasic(Action<MerchandiseHierarchyNodeSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public MerchandiseHierarchyNodeSearchRow CreateBasic(Action<MerchandiseHierarchyNodeSearchRowBasic> initializer)
        {
            var rowBasic = this.CreateBasic();
            initializer(rowBasic);
            return this;
        }

        SearchRowBasic ISearchRow.CreateBasic() => this.CreateBasic();

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        ISearchRow<MerchandiseHierarchyNodeSearchRowBasic> 
            ISearchRow<MerchandiseHierarchyNodeSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public MerchandiseHierarchyNodeSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.parentNodeJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(MerchandiseHierarchyNodeSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new MerchandiseHierarchyNodeSearchRowBasic();
                    break;


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