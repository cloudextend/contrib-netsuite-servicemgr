using System;

namespace SuiteTalk
{
    public partial class ItemSearchRow: SearchRow<ItemSearchRowBasic>, SupportsCustomSearchJoin
    {
        public ItemSearchRowBasic GetBasic() => this.basic;

        public ItemSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ItemSearchRowBasic();
            return this.basic;
        }

        public ItemSearchRowBasic CreateBasic(Action<ItemSearchRowBasic> initializer)
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
        private static SearchRowBasic GetOrCreateJoin(ItemSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "accountingBookRevRecScheduleJoin":
                    result = target.accountingBookRevRecScheduleJoin;
                    creator = () => target.accountingBookRevRecScheduleJoin = new RevRecTemplateSearchRowBasic();
                    break;
        
                case "assemblyItemBillOfMaterialsJoin":
                    result = target.assemblyItemBillOfMaterialsJoin;
                    creator = () => target.assemblyItemBillOfMaterialsJoin = new AssemblyItemBomSearchRowBasic();
                    break;
        
                case "binNumberJoin":
                    result = target.binNumberJoin;
                    creator = () => target.binNumberJoin = new BinSearchRowBasic();
                    break;
        
                case "binOnHandJoin":
                    result = target.binOnHandJoin;
                    creator = () => target.binOnHandJoin = new ItemBinNumberSearchRowBasic();
                    break;
        
                case "correlatedItemJoin":
                    result = target.correlatedItemJoin;
                    creator = () => target.correlatedItemJoin = new ItemSearchRowBasic();
                    break;
        
                case "effectiveRevisionJoin":
                    result = target.effectiveRevisionJoin;
                    creator = () => target.effectiveRevisionJoin = new ItemRevisionSearchRowBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "hierarchyNodeJoin":
                    result = target.hierarchyNodeJoin;
                    creator = () => target.hierarchyNodeJoin = new MerchandiseHierarchyNodeSearchRowBasic();
                    break;
        
                case "inventoryDetailJoin":
                    result = target.inventoryDetailJoin;
                    creator = () => target.inventoryDetailJoin = new InventoryDetailSearchRowBasic();
                    break;
        
                case "inventoryLocationJoin":
                    result = target.inventoryLocationJoin;
                    creator = () => target.inventoryLocationJoin = new LocationSearchRowBasic();
                    break;
        
                case "inventoryNumberJoin":
                    result = target.inventoryNumberJoin;
                    creator = () => target.inventoryNumberJoin = new InventoryNumberSearchRowBasic();
                    break;
        
                case "inventoryNumberBinOnHandJoin":
                    result = target.inventoryNumberBinOnHandJoin;
                    creator = () => target.inventoryNumberBinOnHandJoin = new InventoryNumberBinSearchRowBasic();
                    break;
        
                case "memberItemJoin":
                    result = target.memberItemJoin;
                    creator = () => target.memberItemJoin = new ItemSearchRowBasic();
                    break;
        
                case "obsoleteRevisionJoin":
                    result = target.obsoleteRevisionJoin;
                    creator = () => target.obsoleteRevisionJoin = new ItemRevisionSearchRowBasic();
                    break;
        
                case "parentJoin":
                    result = target.parentJoin;
                    creator = () => target.parentJoin = new ItemSearchRowBasic();
                    break;
        
                case "preferredLocationJoin":
                    result = target.preferredLocationJoin;
                    creator = () => target.preferredLocationJoin = new LocationSearchRowBasic();
                    break;
        
                case "preferredVendorJoin":
                    result = target.preferredVendorJoin;
                    creator = () => target.preferredVendorJoin = new VendorSearchRowBasic();
                    break;
        
                case "pricingJoin":
                    result = target.pricingJoin;
                    creator = () => target.pricingJoin = new PricingSearchRowBasic();
                    break;
        
                case "shopperJoin":
                    result = target.shopperJoin;
                    creator = () => target.shopperJoin = new CustomerSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchRowBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ItemSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}