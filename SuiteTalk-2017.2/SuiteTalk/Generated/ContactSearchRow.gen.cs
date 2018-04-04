using System;

namespace SuiteTalk
{
    public partial class ContactSearchRow: SearchRow, SupportsCustomSearchJoin
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ContactSearchRowBasic();
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
        private static SearchRowBasic GetOrCreateJoin(ContactSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

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
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "customerPrimaryJoin":
                    result = target.customerPrimaryJoin;
                    creator = () => target.customerPrimaryJoin = new CustomerSearchRowBasic();
                    break;
        
                case "eventJoin":
                    result = target.eventJoin;
                    creator = () => target.eventJoin = new CalendarEventSearchRowBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchRowBasic();
                    break;
        
                case "jobPrimaryJoin":
                    result = target.jobPrimaryJoin;
                    creator = () => target.jobPrimaryJoin = new JobSearchRowBasic();
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
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchRowBasic();
                    break;
        
                case "parentCustomerJoin":
                    result = target.parentCustomerJoin;
                    creator = () => target.parentCustomerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "parentJobJoin":
                    result = target.parentJobJoin;
                    creator = () => target.parentJobJoin = new JobSearchRowBasic();
                    break;
        
                case "parentPartnerJoin":
                    result = target.parentPartnerJoin;
                    creator = () => target.parentPartnerJoin = new PartnerSearchRowBasic();
                    break;
        
                case "parentVendorJoin":
                    result = target.parentVendorJoin;
                    creator = () => target.parentVendorJoin = new VendorSearchRowBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchRowBasic();
                    break;
        
                case "partnerPrimaryJoin":
                    result = target.partnerPrimaryJoin;
                    creator = () => target.partnerPrimaryJoin = new PartnerSearchRowBasic();
                    break;
        
                case "purchasedItemJoin":
                    result = target.purchasedItemJoin;
                    creator = () => target.purchasedItemJoin = new ItemSearchRowBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchRowBasic();
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
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchRowBasic();
                    break;
        
                case "vendorPrimaryJoin":
                    result = target.vendorPrimaryJoin;
                    creator = () => target.vendorPrimaryJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ContactSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}