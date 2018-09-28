// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class BomSearch: ISearch, ISearch<BomSearchBasic>
    {
        public BomSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public BomSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BomSearchBasic();
            return this.basic;
        }

        ISearch<BomSearchBasic> 
            ISearch<BomSearchBasic>.CreateBasic(Action<BomSearchBasic> initializer) => this.CreateBasic(initializer);

        public BomSearch CreateBasic(Action<BomSearchBasic> initializer)
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

        ISearch<BomSearchBasic> 
            ISearch<BomSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public BomSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(BomSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new BomSearchBasic();
                    break;

                case "revisionJoin":
                    result = target.revisionJoin;
                    creator = () => target.revisionJoin = new BomRevisionSearchBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
        
                case "assemblyItemJoin":
                    result = target.assemblyItemJoin;
                    creator = () => target.assemblyItemJoin = new AssemblyItemBomSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("BomSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}