using System;

namespace SuiteTalk
{
    public partial class TransactionSearchRow: IAdvancedSearchRow, IAdvancedSearchRow<TransactionSearchRowBasic>, SupportsCustomSearchJoin
    {
        public TransactionSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic IAdvancedSearchRow.GetBasic() => this.basic;

        public TransactionSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new TransactionSearchRowBasic();
            return this.basic;
        }

        public TransactionSearchRowBasic CreateBasic(Action<TransactionSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return basic;
        }

        SearchRowBasic IAdvancedSearchRow.CreateBasic() => this.CreateBasic();

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
        private static SearchRowBasic GetOrCreateJoin(TransactionSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "accountJoin":
                    result = target.accountJoin;
                    creator = () => target.accountJoin = new AccountSearchRowBasic();
                    break;
        
                case "accountingPeriodJoin":
                    result = target.accountingPeriodJoin;
                    creator = () => target.accountingPeriodJoin = new AccountingPeriodSearchRowBasic();
                    break;
        
                case "accountingTransactionJoin":
                    result = target.accountingTransactionJoin;
                    creator = () => target.accountingTransactionJoin = new AccountingTransactionSearchRowBasic();
                    break;
        
                case "advanceToApplyAccountJoin":
                    result = target.advanceToApplyAccountJoin;
                    creator = () => target.advanceToApplyAccountJoin = new AccountSearchRowBasic();
                    break;
        
                case "appliedToTransactionJoin":
                    result = target.appliedToTransactionJoin;
                    creator = () => target.appliedToTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "applyingTransactionJoin":
                    result = target.applyingTransactionJoin;
                    creator = () => target.applyingTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "billingAddressJoin":
                    result = target.billingAddressJoin;
                    creator = () => target.billingAddressJoin = new AddressSearchRowBasic();
                    break;
        
                case "billingTransactionJoin":
                    result = target.billingTransactionJoin;
                    creator = () => target.billingTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "binNumberJoin":
                    result = target.binNumberJoin;
                    creator = () => target.binNumberJoin = new BinSearchRowBasic();
                    break;
        
                case "callJoin":
                    result = target.callJoin;
                    creator = () => target.callJoin = new PhoneCallSearchRowBasic();
                    break;
        
                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchRowBasic();
                    break;
        
                case "classJoin":
                    result = target.classJoin;
                    creator = () => target.classJoin = new ClassificationSearchRowBasic();
                    break;
        
                case "cogsPurchaseJoin":
                    result = target.cogsPurchaseJoin;
                    creator = () => target.cogsPurchaseJoin = new TransactionSearchRowBasic();
                    break;
        
                case "cogsSaleJoin":
                    result = target.cogsSaleJoin;
                    creator = () => target.cogsSaleJoin = new TransactionSearchRowBasic();
                    break;
        
                case "contactPrimaryJoin":
                    result = target.contactPrimaryJoin;
                    creator = () => target.contactPrimaryJoin = new ContactSearchRowBasic();
                    break;
        
                case "createdFromJoin":
                    result = target.createdFromJoin;
                    creator = () => target.createdFromJoin = new TransactionSearchRowBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "customerMainJoin":
                    result = target.customerMainJoin;
                    creator = () => target.customerMainJoin = new CustomerSearchRowBasic();
                    break;
        
                case "departmentJoin":
                    result = target.departmentJoin;
                    creator = () => target.departmentJoin = new DepartmentSearchRowBasic();
                    break;
        
                case "depositTransactionJoin":
                    result = target.depositTransactionJoin;
                    creator = () => target.depositTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "eventJoin":
                    result = target.eventJoin;
                    creator = () => target.eventJoin = new CalendarEventSearchRowBasic();
                    break;
        
                case "expenseCategoryJoin":
                    result = target.expenseCategoryJoin;
                    creator = () => target.expenseCategoryJoin = new ExpenseCategorySearchRowBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "fromLocationJoin":
                    result = target.fromLocationJoin;
                    creator = () => target.fromLocationJoin = new LocationSearchRowBasic();
                    break;
        
                case "fulfillingTransactionJoin":
                    result = target.fulfillingTransactionJoin;
                    creator = () => target.fulfillingTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "headerBillingAccountJoin":
                    result = target.headerBillingAccountJoin;
                    creator = () => target.headerBillingAccountJoin = new BillingAccountSearchRowBasic();
                    break;
        
                case "inventoryDetailJoin":
                    result = target.inventoryDetailJoin;
                    creator = () => target.inventoryDetailJoin = new InventoryDetailSearchRowBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "itemNumberJoin":
                    result = target.itemNumberJoin;
                    creator = () => target.itemNumberJoin = new InventoryNumberSearchRowBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchRowBasic();
                    break;
        
                case "jobMainJoin":
                    result = target.jobMainJoin;
                    creator = () => target.jobMainJoin = new JobSearchRowBasic();
                    break;
        
                case "leadSourceJoin":
                    result = target.leadSourceJoin;
                    creator = () => target.leadSourceJoin = new CampaignSearchRowBasic();
                    break;
        
                case "lineBillingAccountJoin":
                    result = target.lineBillingAccountJoin;
                    creator = () => target.lineBillingAccountJoin = new BillingAccountSearchRowBasic();
                    break;
        
                case "locationJoin":
                    result = target.locationJoin;
                    creator = () => target.locationJoin = new LocationSearchRowBasic();
                    break;
        
                case "manufacturingOperationTaskJoin":
                    result = target.manufacturingOperationTaskJoin;
                    creator = () => target.manufacturingOperationTaskJoin = new ManufacturingOperationTaskSearchRowBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchRowBasic();
                    break;
        
                case "nextApproverJoin":
                    result = target.nextApproverJoin;
                    creator = () => target.nextApproverJoin = new EntitySearchRowBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchRowBasic();
                    break;
        
                case "paidTransactionJoin":
                    result = target.paidTransactionJoin;
                    creator = () => target.paidTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchRowBasic();
                    break;
        
                case "payingTransactionJoin":
                    result = target.payingTransactionJoin;
                    creator = () => target.payingTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "payrollItemJoin":
                    result = target.payrollItemJoin;
                    creator = () => target.payrollItemJoin = new PayrollItemSearchRowBasic();
                    break;
        
                case "projectTaskJoin":
                    result = target.projectTaskJoin;
                    creator = () => target.projectTaskJoin = new ProjectTaskSearchRowBasic();
                    break;
        
                case "purchaseOrderJoin":
                    result = target.purchaseOrderJoin;
                    creator = () => target.purchaseOrderJoin = new TransactionSearchRowBasic();
                    break;
        
                case "requestorJoin":
                    result = target.requestorJoin;
                    creator = () => target.requestorJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "revCommittingTransactionJoin":
                    result = target.revCommittingTransactionJoin;
                    creator = () => target.revCommittingTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "revisionJoin":
                    result = target.revisionJoin;
                    creator = () => target.revisionJoin = new ItemRevisionSearchRowBasic();
                    break;
        
                case "revRecScheduleJoin":
                    result = target.revRecScheduleJoin;
                    creator = () => target.revRecScheduleJoin = new RevRecScheduleSearchRowBasic();
                    break;
        
                case "rgPostingTransactionJoin":
                    result = target.rgPostingTransactionJoin;
                    creator = () => target.rgPostingTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "salesOrderJoin":
                    result = target.salesOrderJoin;
                    creator = () => target.salesOrderJoin = new TransactionSearchRowBasic();
                    break;
        
                case "salesRepJoin":
                    result = target.salesRepJoin;
                    creator = () => target.salesRepJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "shippingAddressJoin":
                    result = target.shippingAddressJoin;
                    creator = () => target.shippingAddressJoin = new AddressSearchRowBasic();
                    break;
        
                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchRowBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchRowBasic();
                    break;
        
                case "taxCodeJoin":
                    result = target.taxCodeJoin;
                    creator = () => target.taxCodeJoin = new SalesTaxItemSearchRowBasic();
                    break;
        
                case "taxDetailJoin":
                    result = target.taxDetailJoin;
                    creator = () => target.taxDetailJoin = new TaxDetailSearchRowBasic();
                    break;
        
                case "taxItemJoin":
                    result = target.taxItemJoin;
                    creator = () => target.taxItemJoin = new SalesTaxItemSearchRowBasic();
                    break;
        
                case "timeJoin":
                    result = target.timeJoin;
                    creator = () => target.timeJoin = new TimeBillSearchRowBasic();
                    break;
        
                case "toLocationJoin":
                    result = target.toLocationJoin;
                    creator = () => target.toLocationJoin = new LocationSearchRowBasic();
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
        
                case "vendorLineJoin":
                    result = target.vendorLineJoin;
                    creator = () => target.vendorLineJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("TransactionSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}