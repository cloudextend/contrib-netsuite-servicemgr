// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class ContactSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<ContactSearchRowBasic>, SupportsCustomSearchJoin
    {
        public ContactSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public ContactSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ContactSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<ContactSearchRowBasic> 
            ISearchAdvancedRow<ContactSearchRowBasic>.CreateBasic(Action<ContactSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ContactSearchRow CreateBasic(Action<ContactSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return this;
        }

        SearchRowBasic ISearchAdvancedRow.CreateBasic() => this.CreateBasic();

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        ISearchAdvancedRow<ContactSearchRowBasic> 
            ISearchAdvancedRow<ContactSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ContactSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.callJoin;
      //      yield return this.campaignResponseJoin;
      //      yield return this.caseJoin;
      //      yield return this.customerJoin;
      //      yield return this.customerPrimaryJoin;
      //      yield return this.eventJoin;
      //      yield return this.fileJoin;
      //      yield return this.jobJoin;
      //      yield return this.jobPrimaryJoin;
      //      yield return this.messagesJoin;
      //      yield return this.messagesFromJoin;
      //      yield return this.messagesToJoin;
      //      yield return this.opportunityJoin;
      //      yield return this.parentCustomerJoin;
      //      yield return this.parentJobJoin;
      //      yield return this.parentPartnerJoin;
      //      yield return this.parentVendorJoin;
      //      yield return this.partnerJoin;
      //      yield return this.partnerPrimaryJoin;
      //      yield return this.purchasedItemJoin;
      //      yield return this.taskJoin;
      //      yield return this.transactionJoin;
      //      yield return this.upsellItemJoin;
      //      yield return this.userJoin;
      //      yield return this.userNotesJoin;
      //      yield return this.vendorJoin;
      //      yield return this.vendorPrimaryJoin;
        //}


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
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ContactSearchRowBasic();
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