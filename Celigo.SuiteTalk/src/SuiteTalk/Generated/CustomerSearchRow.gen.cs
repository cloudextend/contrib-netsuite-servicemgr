// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class CustomerSearchRow: ISearchRow, ISearchRow<CustomerSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public CustomerSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public CustomerSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new CustomerSearchRowBasic();
            return this.basic;
        }

        ISearchRow<CustomerSearchRowBasic> 
            ISearchRow<CustomerSearchRowBasic>.CreateBasic(Action<CustomerSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public CustomerSearchRow CreateBasic(Action<CustomerSearchRowBasic> initializer)
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

        ISearchRow<CustomerSearchRowBasic> 
            ISearchRow<CustomerSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public CustomerSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.billingAccountJoin;
      //      yield return this.billingScheduleJoin;
      //      yield return this.callJoin;
      //      yield return this.campaignResponseJoin;
      //      yield return this.caseJoin;
      //      yield return this.contactJoin;
      //      yield return this.contactPrimaryJoin;
      //      yield return this.eventJoin;
      //      yield return this.fileJoin;
      //      yield return this.hostedPageJoin;
      //      yield return this.jobJoin;
      //      yield return this.leadSourceJoin;
      //      yield return this.messagesJoin;
      //      yield return this.messagesFromJoin;
      //      yield return this.messagesToJoin;
      //      yield return this.mseSubsidiaryJoin;
      //      yield return this.opportunityJoin;
      //      yield return this.originatingLeadJoin;
      //      yield return this.parentCustomerJoin;
      //      yield return this.partnerJoin;
      //      yield return this.pricingJoin;
      //      yield return this.purchasedItemJoin;
      //      yield return this.resourceAllocationJoin;
      //      yield return this.salesRepJoin;
      //      yield return this.subCustomerJoin;
      //      yield return this.taskJoin;
      //      yield return this.timeJoin;
      //      yield return this.topLevelParentJoin;
      //      yield return this.transactionJoin;
      //      yield return this.upsellItemJoin;
      //      yield return this.userJoin;
      //      yield return this.userNotesJoin;
      //      yield return this.webSiteCategoryJoin;
      //      yield return this.webSiteItemJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(CustomerSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new CustomerSearchRowBasic();
                    break;


                case "billingAccountJoin":
                    result = target.billingAccountJoin;
                    creator = () => target.billingAccountJoin = new BillingAccountSearchRowBasic();
                    break;
        
                case "billingScheduleJoin":
                    result = target.billingScheduleJoin;
                    creator = () => target.billingScheduleJoin = new BillingScheduleSearchRowBasic();
                    break;
        
                case "callJoin":
                    result = target.callJoin;
                    creator = () => target.callJoin = new PhoneCallSearchRowBasic();
                    break;
        
                case "campaignResponseJoin":
                    result = target.campaignResponseJoin;
                    creator = () => target.campaignResponseJoin = new CampaignSearchRowBasic();
                    break;
        
                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchRowBasic();
                    break;
        
                case "contactJoin":
                    result = target.contactJoin;
                    creator = () => target.contactJoin = new ContactSearchRowBasic();
                    break;
        
                case "contactPrimaryJoin":
                    result = target.contactPrimaryJoin;
                    creator = () => target.contactPrimaryJoin = new ContactSearchRowBasic();
                    break;
        
                case "eventJoin":
                    result = target.eventJoin;
                    creator = () => target.eventJoin = new CalendarEventSearchRowBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "hostedPageJoin":
                    result = target.hostedPageJoin;
                    creator = () => target.hostedPageJoin = new FileSearchRowBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchRowBasic();
                    break;
        
                case "leadSourceJoin":
                    result = target.leadSourceJoin;
                    creator = () => target.leadSourceJoin = new CampaignSearchRowBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchRowBasic();
                    break;
        
                case "messagesFromJoin":
                    result = target.messagesFromJoin;
                    creator = () => target.messagesFromJoin = new MessageSearchRowBasic();
                    break;
        
                case "messagesToJoin":
                    result = target.messagesToJoin;
                    creator = () => target.messagesToJoin = new MessageSearchRowBasic();
                    break;
        
                case "mseSubsidiaryJoin":
                    result = target.mseSubsidiaryJoin;
                    creator = () => target.mseSubsidiaryJoin = new MseSubsidiarySearchRowBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchRowBasic();
                    break;
        
                case "originatingLeadJoin":
                    result = target.originatingLeadJoin;
                    creator = () => target.originatingLeadJoin = new OriginatingLeadSearchRowBasic();
                    break;
        
                case "parentCustomerJoin":
                    result = target.parentCustomerJoin;
                    creator = () => target.parentCustomerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchRowBasic();
                    break;
        
                case "pricingJoin":
                    result = target.pricingJoin;
                    creator = () => target.pricingJoin = new PricingSearchRowBasic();
                    break;
        
                case "purchasedItemJoin":
                    result = target.purchasedItemJoin;
                    creator = () => target.purchasedItemJoin = new ItemSearchRowBasic();
                    break;
        
                case "resourceAllocationJoin":
                    result = target.resourceAllocationJoin;
                    creator = () => target.resourceAllocationJoin = new ResourceAllocationSearchRowBasic();
                    break;
        
                case "salesRepJoin":
                    result = target.salesRepJoin;
                    creator = () => target.salesRepJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "subCustomerJoin":
                    result = target.subCustomerJoin;
                    creator = () => target.subCustomerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchRowBasic();
                    break;
        
                case "timeJoin":
                    result = target.timeJoin;
                    creator = () => target.timeJoin = new TimeBillSearchRowBasic();
                    break;
        
                case "topLevelParentJoin":
                    result = target.topLevelParentJoin;
                    creator = () => target.topLevelParentJoin = new CustomerSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "upsellItemJoin":
                    result = target.upsellItemJoin;
                    creator = () => target.upsellItemJoin = new ItemSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchRowBasic();
                    break;
        
                case "webSiteCategoryJoin":
                    result = target.webSiteCategoryJoin;
                    creator = () => target.webSiteCategoryJoin = new SiteCategorySearchRowBasic();
                    break;
        
                case "webSiteItemJoin":
                    result = target.webSiteItemJoin;
                    creator = () => target.webSiteItemJoin = new ItemSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("CustomerSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}