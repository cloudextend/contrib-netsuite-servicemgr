// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class BomRevisionSearch: ISearch, ISearch<BomRevisionSearchBasic>
    {
        public BomRevisionSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public BomRevisionSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BomRevisionSearchBasic();
            return this.basic;
        }

        ISearch<BomRevisionSearchBasic> 
            ISearch<BomRevisionSearchBasic>.CreateBasic(Action<BomRevisionSearchBasic> initializer) => this.CreateBasic(initializer);

        public BomRevisionSearch CreateBasic(Action<BomRevisionSearchBasic> initializer)
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

        ISearch<BomRevisionSearchBasic> 
            ISearch<BomRevisionSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public BomRevisionSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(BomRevisionSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new BomRevisionSearchBasic();
                    break;

                case "billOfMaterialsJoin":
                    result = target.billOfMaterialsJoin;
                    creator = () => target.billOfMaterialsJoin = new BomSearchBasic();
                    break;
        
                case "componentJoin":
                    result = target.componentJoin;
                    creator = () => target.componentJoin = new BomRevisionComponentSearchBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("BomRevisionSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}