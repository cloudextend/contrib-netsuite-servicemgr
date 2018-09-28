// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class BomSearchRow: ISearchRow, ISearchRow<BomSearchRowBasic>
    {
        public BomSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public BomSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BomSearchRowBasic();
            return this.basic;
        }

        ISearchRow<BomSearchRowBasic> 
            ISearchRow<BomSearchRowBasic>.CreateBasic(Action<BomSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public BomSearchRow CreateBasic(Action<BomSearchRowBasic> initializer)
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

        ISearchRow<BomSearchRowBasic> 
            ISearchRow<BomSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public BomSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.revisionJoin;
      //      yield return this.transactionJoin;
      //      yield return this.assemblyItemJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(BomSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new BomSearchRowBasic();
                    break;


                case "revisionJoin":
                    result = target.revisionJoin;
                    creator = () => target.revisionJoin = new BomRevisionSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "assemblyItemJoin":
                    result = target.assemblyItemJoin;
                    creator = () => target.assemblyItemJoin = new AssemblyItemBomSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("BomSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}