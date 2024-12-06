// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ItemSearch: ISearch, ISearch<ItemSearchBasic>
    {
        public ItemSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ItemSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ItemSearchBasic();
            return this.basic;
        }

        ISearch<ItemSearchBasic> 
            ISearch<ItemSearchBasic>.CreateBasic(Action<ItemSearchBasic> initializer) => this.CreateBasic(initializer);

        public ItemSearch CreateBasic(Action<ItemSearchBasic> initializer)
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

        ISearch<ItemSearchBasic> 
            ISearch<ItemSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ItemSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ItemSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ItemSearchBasic();
                    break;

                case "accountingBookRevRecScheduleJoin":
                    result = target.accountingBookRevRecScheduleJoin;
                    creator = () => target.accountingBookRevRecScheduleJoin = new RevRecTemplateSearchBasic();
                    break;
        
                case "assemblyItemBillOfMaterialsJoin":
                    result = target.assemblyItemBillOfMaterialsJoin;
                    creator = () => target.assemblyItemBillOfMaterialsJoin = new AssemblyItemBomSearchBasic();
                    break;
        
                case "binNumberJoin":
                    result = target.binNumberJoin;
                    creator = () => target.binNumberJoin = new BinSearchBasic();
                    break;
        
                case "binOnHandJoin":
                    result = target.binOnHandJoin;
                    creator = () => target.binOnHandJoin = new ItemBinNumberSearchBasic();
                    break;
        
                case "correlatedItemJoin":
                    result = target.correlatedItemJoin;
                    creator = () => target.correlatedItemJoin = new ItemSearchBasic();
                    break;
        
                case "effectiveRevisionJoin":
                    result = target.effectiveRevisionJoin;
                    creator = () => target.effectiveRevisionJoin = new ItemRevisionSearchBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchBasic();
                    break;
        
                case "hierarchyNodeJoin":
                    result = target.hierarchyNodeJoin;
                    creator = () => target.hierarchyNodeJoin = new MerchandiseHierarchyNodeSearchBasic();
                    break;
        
                case "inventoryDetailJoin":
                    result = target.inventoryDetailJoin;
                    creator = () => target.inventoryDetailJoin = new InventoryDetailSearchBasic();
                    break;
        
                case "inventoryLocationJoin":
                    result = target.inventoryLocationJoin;
                    creator = () => target.inventoryLocationJoin = new LocationSearchBasic();
                    break;
        
                case "inventoryNumberJoin":
                    result = target.inventoryNumberJoin;
                    creator = () => target.inventoryNumberJoin = new InventoryNumberSearchBasic();
                    break;
        
                case "inventoryNumberBinOnHandJoin":
                    result = target.inventoryNumberBinOnHandJoin;
                    creator = () => target.inventoryNumberBinOnHandJoin = new InventoryNumberBinSearchBasic();
                    break;
        
                case "memberItemJoin":
                    result = target.memberItemJoin;
                    creator = () => target.memberItemJoin = new ItemSearchBasic();
                    break;
        
                case "obsoleteRevisionJoin":
                    result = target.obsoleteRevisionJoin;
                    creator = () => target.obsoleteRevisionJoin = new ItemRevisionSearchBasic();
                    break;
        
                case "parentJoin":
                    result = target.parentJoin;
                    creator = () => target.parentJoin = new ItemSearchBasic();
                    break;
        
                case "preferredLocationJoin":
                    result = target.preferredLocationJoin;
                    creator = () => target.preferredLocationJoin = new LocationSearchBasic();
                    break;
        
                case "preferredVendorJoin":
                    result = target.preferredVendorJoin;
                    creator = () => target.preferredVendorJoin = new VendorSearchBasic();
                    break;
        
                case "pricingJoin":
                    result = target.pricingJoin;
                    creator = () => target.pricingJoin = new PricingSearchBasic();
                    break;
        
                case "shopperJoin":
                    result = target.shopperJoin;
                    creator = () => target.shopperJoin = new CustomerSearchBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ItemSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}