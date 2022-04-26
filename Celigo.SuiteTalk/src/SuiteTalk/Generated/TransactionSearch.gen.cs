
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class TransactionSearch: ISearch, ISearch<TransactionSearchBasic>
    {
        public TransactionSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public TransactionSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new TransactionSearchBasic();
            return this.basic;
        }

        ISearch<TransactionSearchBasic> 
            ISearch<TransactionSearchBasic>.CreateBasic(Action<TransactionSearchBasic> initializer) => this.CreateBasic(initializer);

        public TransactionSearch CreateBasic(Action<TransactionSearchBasic> initializer)
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

        ISearch<TransactionSearchBasic> 
            ISearch<TransactionSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public TransactionSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(TransactionSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new TransactionSearchBasic();
                    break;

                case "accountJoin":
                    result = target.accountJoin;
                    creator = () => target.accountJoin = new AccountSearchBasic();
                    break;
        
                case "accountingPeriodJoin":
                    result = target.accountingPeriodJoin;
                    creator = () => target.accountingPeriodJoin = new AccountingPeriodSearchBasic();
                    break;
        
                case "accountingTransactionJoin":
                    result = target.accountingTransactionJoin;
                    creator = () => target.accountingTransactionJoin = new AccountingTransactionSearchBasic();
                    break;
        
                case "advanceToApplyAccountJoin":
                    result = target.advanceToApplyAccountJoin;
                    creator = () => target.advanceToApplyAccountJoin = new AccountSearchBasic();
                    break;
        
                case "appliedToTransactionJoin":
                    result = target.appliedToTransactionJoin;
                    creator = () => target.appliedToTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "applyingTransactionJoin":
                    result = target.applyingTransactionJoin;
                    creator = () => target.applyingTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "assemblyJoin":
                    result = target.assemblyJoin;
                    creator = () => target.assemblyJoin = new ItemSearchBasic();
                    break;
        
                case "billingAddressJoin":
                    result = target.billingAddressJoin;
                    creator = () => target.billingAddressJoin = new AddressSearchBasic();
                    break;
        
                case "billingTransactionJoin":
                    result = target.billingTransactionJoin;
                    creator = () => target.billingTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "binNumberJoin":
                    result = target.binNumberJoin;
                    creator = () => target.binNumberJoin = new BinSearchBasic();
                    break;
        
                case "bomJoin":
                    result = target.bomJoin;
                    creator = () => target.bomJoin = new BomSearchBasic();
                    break;
        
                case "bomRevisionJoin":
                    result = target.bomRevisionJoin;
                    creator = () => target.bomRevisionJoin = new BomRevisionSearchBasic();
                    break;
        
                case "callJoin":
                    result = target.callJoin;
                    creator = () => target.callJoin = new PhoneCallSearchBasic();
                    break;
        
                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchBasic();
                    break;
        
                case "classJoin":
                    result = target.classJoin;
                    creator = () => target.classJoin = new ClassificationSearchBasic();
                    break;
        
                case "cogsPurchaseJoin":
                    result = target.cogsPurchaseJoin;
                    creator = () => target.cogsPurchaseJoin = new TransactionSearchBasic();
                    break;
        
                case "cogsSaleJoin":
                    result = target.cogsSaleJoin;
                    creator = () => target.cogsSaleJoin = new TransactionSearchBasic();
                    break;
        
                case "contactPrimaryJoin":
                    result = target.contactPrimaryJoin;
                    creator = () => target.contactPrimaryJoin = new ContactSearchBasic();
                    break;
        
                case "createdFromJoin":
                    result = target.createdFromJoin;
                    creator = () => target.createdFromJoin = new TransactionSearchBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "customerMainJoin":
                    result = target.customerMainJoin;
                    creator = () => target.customerMainJoin = new CustomerSearchBasic();
                    break;
        
                case "departmentJoin":
                    result = target.departmentJoin;
                    creator = () => target.departmentJoin = new DepartmentSearchBasic();
                    break;
        
                case "depositTransactionJoin":
                    result = target.depositTransactionJoin;
                    creator = () => target.depositTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchBasic();
                    break;
        
                case "eventJoin":
                    result = target.eventJoin;
                    creator = () => target.eventJoin = new CalendarEventSearchBasic();
                    break;
        
                case "expenseCategoryJoin":
                    result = target.expenseCategoryJoin;
                    creator = () => target.expenseCategoryJoin = new ExpenseCategorySearchBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchBasic();
                    break;
        
                case "fromLocationJoin":
                    result = target.fromLocationJoin;
                    creator = () => target.fromLocationJoin = new LocationSearchBasic();
                    break;
        
                case "fulfillingTransactionJoin":
                    result = target.fulfillingTransactionJoin;
                    creator = () => target.fulfillingTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "headerBillingAccountJoin":
                    result = target.headerBillingAccountJoin;
                    creator = () => target.headerBillingAccountJoin = new BillingAccountSearchBasic();
                    break;
        
                case "installmentJoin":
                    result = target.installmentJoin;
                    creator = () => target.installmentJoin = new InstallmentSearchBasic();
                    break;
        
                case "inventoryDetailJoin":
                    result = target.inventoryDetailJoin;
                    creator = () => target.inventoryDetailJoin = new InventoryDetailSearchBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
        
                case "itemNumberJoin":
                    result = target.itemNumberJoin;
                    creator = () => target.itemNumberJoin = new InventoryNumberSearchBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchBasic();
                    break;
        
                case "jobMainJoin":
                    result = target.jobMainJoin;
                    creator = () => target.jobMainJoin = new JobSearchBasic();
                    break;
        
                case "leadSourceJoin":
                    result = target.leadSourceJoin;
                    creator = () => target.leadSourceJoin = new CampaignSearchBasic();
                    break;
        
                case "lineBillingAccountJoin":
                    result = target.lineBillingAccountJoin;
                    creator = () => target.lineBillingAccountJoin = new BillingAccountSearchBasic();
                    break;
        
                case "lineFileJoin":
                    result = target.lineFileJoin;
                    creator = () => target.lineFileJoin = new FileSearchBasic();
                    break;
        
                case "locationJoin":
                    result = target.locationJoin;
                    creator = () => target.locationJoin = new LocationSearchBasic();
                    break;
        
                case "manufacturingOperationTaskJoin":
                    result = target.manufacturingOperationTaskJoin;
                    creator = () => target.manufacturingOperationTaskJoin = new ManufacturingOperationTaskSearchBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchBasic();
                    break;
        
                case "nextApproverJoin":
                    result = target.nextApproverJoin;
                    creator = () => target.nextApproverJoin = new EntitySearchBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchBasic();
                    break;
        
                case "outsourcingVendorJoin":
                    result = target.outsourcingVendorJoin;
                    creator = () => target.outsourcingVendorJoin = new VendorSearchBasic();
                    break;
        
                case "paidTransactionJoin":
                    result = target.paidTransactionJoin;
                    creator = () => target.paidTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchBasic();
                    break;
        
                case "payingTransactionJoin":
                    result = target.payingTransactionJoin;
                    creator = () => target.payingTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "paymentInstrumentJoin":
                    result = target.paymentInstrumentJoin;
                    creator = () => target.paymentInstrumentJoin = new PaymentInstrumentSearchBasic();
                    break;
        
                case "paymentOptionJoin":
                    result = target.paymentOptionJoin;
                    creator = () => target.paymentOptionJoin = new PaymentOptionSearchBasic();
                    break;
        
                case "payrollItemJoin":
                    result = target.payrollItemJoin;
                    creator = () => target.payrollItemJoin = new PayrollItemSearchBasic();
                    break;
        
                case "projectTaskJoin":
                    result = target.projectTaskJoin;
                    creator = () => target.projectTaskJoin = new ProjectTaskSearchBasic();
                    break;
        
                case "purchaseOrderJoin":
                    result = target.purchaseOrderJoin;
                    creator = () => target.purchaseOrderJoin = new TransactionSearchBasic();
                    break;
        
                case "requestorJoin":
                    result = target.requestorJoin;
                    creator = () => target.requestorJoin = new EmployeeSearchBasic();
                    break;
        
                case "revCommittingTransactionJoin":
                    result = target.revCommittingTransactionJoin;
                    creator = () => target.revCommittingTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "revisionJoin":
                    result = target.revisionJoin;
                    creator = () => target.revisionJoin = new ItemRevisionSearchBasic();
                    break;
        
                case "revRecScheduleJoin":
                    result = target.revRecScheduleJoin;
                    creator = () => target.revRecScheduleJoin = new RevRecScheduleSearchBasic();
                    break;
        
                case "rgPostingTransactionJoin":
                    result = target.rgPostingTransactionJoin;
                    creator = () => target.rgPostingTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "salesOrderJoin":
                    result = target.salesOrderJoin;
                    creator = () => target.salesOrderJoin = new TransactionSearchBasic();
                    break;
        
                case "salesRepJoin":
                    result = target.salesRepJoin;
                    creator = () => target.salesRepJoin = new EmployeeSearchBasic();
                    break;
        
                case "shippingAddressJoin":
                    result = target.shippingAddressJoin;
                    creator = () => target.shippingAddressJoin = new AddressSearchBasic();
                    break;
        
                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchBasic();
                    break;
        
                case "taxCodeJoin":
                    result = target.taxCodeJoin;
                    creator = () => target.taxCodeJoin = new SalesTaxItemSearchBasic();
                    break;
        
                case "taxDetailJoin":
                    result = target.taxDetailJoin;
                    creator = () => target.taxDetailJoin = new TaxDetailSearchBasic();
                    break;
        
                case "taxItemJoin":
                    result = target.taxItemJoin;
                    creator = () => target.taxItemJoin = new SalesTaxItemSearchBasic();
                    break;
        
                case "timeJoin":
                    result = target.timeJoin;
                    creator = () => target.timeJoin = new TimeBillSearchBasic();
                    break;
        
                case "toLocationJoin":
                    result = target.toLocationJoin;
                    creator = () => target.toLocationJoin = new LocationSearchBasic();
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
        
                case "vendorLineJoin":
                    result = target.vendorLineJoin;
                    creator = () => target.vendorLineJoin = new VendorSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("TransactionSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}