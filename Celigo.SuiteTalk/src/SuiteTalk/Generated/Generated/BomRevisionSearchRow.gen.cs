using System;

namespace SuiteTalk
{
    public partial class BomRevisionSearchRow: SearchRow<BomRevisionSearchRowBasic>, SupportsCustomSearchJoin
    {
        public BomRevisionSearchRowBasic GetBasic() => this.basic;

        public BomRevisionSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BomRevisionSearchRowBasic();
            return this.basic;
        }

        public BomRevisionSearchRowBasic CreateBasic(Action<BomRevisionSearchRowBasic> initializer)
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


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(BomRevisionSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "billOfMaterialsJoin":
                    result = target.billOfMaterialsJoin;
                    creator = () => target.billOfMaterialsJoin = new BomSearchRowBasic();
                    break;
        
                case "componentJoin":
                    result = target.componentJoin;
                    creator = () => target.componentJoin = new BomRevisionComponentSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("BomRevisionSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}