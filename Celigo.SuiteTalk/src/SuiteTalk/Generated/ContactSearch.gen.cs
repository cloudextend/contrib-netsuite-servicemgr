// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ContactSearch: ISearch, ISearch<ContactSearchBasic>
    {
        public ContactSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ContactSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ContactSearchBasic();
            return this.basic;
        }

        ISearch<ContactSearchBasic> 
            ISearch<ContactSearchBasic>.CreateBasic(Action<ContactSearchBasic> initializer) => this.CreateBasic(initializer);

        public ContactSearch CreateBasic(Action<ContactSearchBasic> initializer)
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

        ISearch<ContactSearchBasic> 
            ISearch<ContactSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ContactSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ContactSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ContactSearchBasic();
                    break;

                case "callJoin":
                    result = target.callJoin;
                    creator = () => target.callJoin = new PhoneCallSearchBasic();
                    break;
        
                case "campaignResponseJoin":
                    result = target.campaignResponseJoin;
                    creator = () => target.campaignResponseJoin = new CampaignSearchBasic();
                    break;
        
                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "customerPrimaryJoin":
                    result = target.customerPrimaryJoin;
                    creator = () => target.customerPrimaryJoin = new CustomerSearchBasic();
                    break;
        
                case "eventJoin":
                    result = target.eventJoin;
                    creator = () => target.eventJoin = new CalendarEventSearchBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchBasic();
                    break;
        
                case "jobPrimaryJoin":
                    result = target.jobPrimaryJoin;
                    creator = () => target.jobPrimaryJoin = new JobSearchBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchBasic();
                    break;
        
                case "messagesFromJoin":
                    result = target.messagesFromJoin;
                    creator = () => target.messagesFromJoin = new MessageSearchBasic();
                    break;
        
                case "messagesToJoin":
                    result = target.messagesToJoin;
                    creator = () => target.messagesToJoin = new MessageSearchBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchBasic();
                    break;
        
                case "parentCustomerJoin":
                    result = target.parentCustomerJoin;
                    creator = () => target.parentCustomerJoin = new CustomerSearchBasic();
                    break;
        
                case "parentJobJoin":
                    result = target.parentJobJoin;
                    creator = () => target.parentJobJoin = new JobSearchBasic();
                    break;
        
                case "parentPartnerJoin":
                    result = target.parentPartnerJoin;
                    creator = () => target.parentPartnerJoin = new PartnerSearchBasic();
                    break;
        
                case "parentVendorJoin":
                    result = target.parentVendorJoin;
                    creator = () => target.parentVendorJoin = new VendorSearchBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchBasic();
                    break;
        
                case "partnerPrimaryJoin":
                    result = target.partnerPrimaryJoin;
                    creator = () => target.partnerPrimaryJoin = new PartnerSearchBasic();
                    break;
        
                case "purchasedItemJoin":
                    result = target.purchasedItemJoin;
                    creator = () => target.purchasedItemJoin = new ItemSearchBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
        
                case "upsellItemJoin":
                    result = target.upsellItemJoin;
                    creator = () => target.upsellItemJoin = new ItemSearchBasic();
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
        
                case "vendorPrimaryJoin":
                    result = target.vendorPrimaryJoin;
                    creator = () => target.vendorPrimaryJoin = new VendorSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ContactSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}