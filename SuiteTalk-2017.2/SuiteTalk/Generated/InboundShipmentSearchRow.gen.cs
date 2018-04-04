using System;

namespace SuiteTalk
{
    public partial class InboundShipmentSearchRow: SearchRow, SupportsCustomSearchJoin
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new InboundShipmentSearchRowBasic();
            return this.basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(InboundShipmentSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "itemReceiptJoin":
                    result = target.itemReceiptJoin;
                    creator = () => target.itemReceiptJoin = new TransactionSearchRowBasic();
                    break;
        
                case "purchaseOrderJoin":
                    result = target.purchaseOrderJoin;
                    creator = () => target.purchaseOrderJoin = new TransactionSearchRowBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("InboundShipmentSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}