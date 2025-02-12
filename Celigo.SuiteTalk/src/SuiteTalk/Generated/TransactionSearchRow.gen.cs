// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class TransactionSearchRow: ISearchRow, ISearchRow<TransactionSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public TransactionSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public TransactionSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new TransactionSearchRowBasic();
            return this.basic;
        }

        ISearchRow<TransactionSearchRowBasic> 
            ISearchRow<TransactionSearchRowBasic>.CreateBasic(Action<TransactionSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public TransactionSearchRow CreateBasic(Action<TransactionSearchRowBasic> initializer)
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

        ISearchRow<TransactionSearchRowBasic> 
            ISearchRow<TransactionSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public TransactionSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.accountJoin;
      //      yield return this.accountingPeriodJoin;
      //      yield return this.accountingTransactionJoin;
      //      yield return this.advanceToApplyAccountJoin;
      //      yield return this.appliedToTransactionJoin;
      //      yield return this.applyingTransactionJoin;
      //      yield return this.assemblyJoin;
      //      yield return this.billingAddressJoin;
      //      yield return this.billingTransactionJoin;
      //      yield return this.binNumberJoin;
      //      yield return this.bomJoin;
      //      yield return this.bomRevisionJoin;
      //      yield return this.callJoin;
      //      yield return this.caseJoin;
      //      yield return this.classJoin;
      //      yield return this.cogsPurchaseJoin;
      //      yield return this.cogsSaleJoin;
      //      yield return this.contactPrimaryJoin;
      //      yield return this.createdFromJoin;
      //      yield return this.customerJoin;
      //      yield return this.customerMainJoin;
      //      yield return this.departmentJoin;
      //      yield return this.depositTransactionJoin;
      //      yield return this.employeeJoin;
      //      yield return this.eventJoin;
      //      yield return this.expenseCategoryJoin;
      //      yield return this.fileJoin;
      //      yield return this.fromLocationJoin;
      //      yield return this.fulfillingTransactionJoin;
      //      yield return this.headerBillingAccountJoin;
      //      yield return this.installmentJoin;
      //      yield return this.inventoryDetailJoin;
      //      yield return this.itemJoin;
      //      yield return this.itemNumberJoin;
      //      yield return this.jobJoin;
      //      yield return this.jobMainJoin;
      //      yield return this.leadSourceJoin;
      //      yield return this.lineBillingAccountJoin;
      //      yield return this.lineFileJoin;
      //      yield return this.locationJoin;
      //      yield return this.manufacturingOperationTaskJoin;
      //      yield return this.messagesJoin;
      //      yield return this.nextApproverJoin;
      //      yield return this.opportunityJoin;
      //      yield return this.outsourcingVendorJoin;
      //      yield return this.paidTransactionJoin;
      //      yield return this.partnerJoin;
      //      yield return this.payingTransactionJoin;
      //      yield return this.paymentInstrumentJoin;
      //      yield return this.paymentOptionJoin;
      //      yield return this.payrollItemJoin;
      //      yield return this.projectTaskJoin;
      //      yield return this.purchaseOrderJoin;
      //      yield return this.requestorJoin;
      //      yield return this.revCommittingTransactionJoin;
      //      yield return this.revisionJoin;
      //      yield return this.revRecScheduleJoin;
      //      yield return this.rgPostingTransactionJoin;
      //      yield return this.salesOrderJoin;
      //      yield return this.salesRepJoin;
      //      yield return this.shippingAddressJoin;
      //      yield return this.subsidiaryJoin;
      //      yield return this.taskJoin;
      //      yield return this.taxCodeJoin;
      //      yield return this.taxDetailJoin;
      //      yield return this.taxItemJoin;
      //      yield return this.timeJoin;
      //      yield return this.toLocationJoin;
      //      yield return this.userJoin;
      //      yield return this.userNotesJoin;
      //      yield return this.vendorJoin;
      //      yield return this.vendorLineJoin;
        //}


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
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new TransactionSearchRowBasic();
                    break;


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
        
                case "assemblyJoin":
                    result = target.assemblyJoin;
                    creator = () => target.assemblyJoin = new ItemSearchRowBasic();
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
        
                case "bomJoin":
                    result = target.bomJoin;
                    creator = () => target.bomJoin = new BomSearchRowBasic();
                    break;
        
                case "bomRevisionJoin":
                    result = target.bomRevisionJoin;
                    creator = () => target.bomRevisionJoin = new BomRevisionSearchRowBasic();
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
        
                case "installmentJoin":
                    result = target.installmentJoin;
                    creator = () => target.installmentJoin = new InstallmentSearchRowBasic();
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
        
                case "lineFileJoin":
                    result = target.lineFileJoin;
                    creator = () => target.lineFileJoin = new FileSearchRowBasic();
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
        
                case "outsourcingVendorJoin":
                    result = target.outsourcingVendorJoin;
                    creator = () => target.outsourcingVendorJoin = new VendorSearchRowBasic();
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
        
                case "paymentInstrumentJoin":
                    result = target.paymentInstrumentJoin;
                    creator = () => target.paymentInstrumentJoin = new PaymentInstrumentSearchRowBasic();
                    break;
        
                case "paymentOptionJoin":
                    result = target.paymentOptionJoin;
                    creator = () => target.paymentOptionJoin = new PaymentOptionSearchRowBasic();
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