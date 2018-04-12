// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class PartnerSearch: ISearch, ISearch<PartnerSearchBasic>
    {
        public PartnerSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public PartnerSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PartnerSearchBasic();
            return this.basic;
        }

        ISearch<PartnerSearchBasic> 
            ISearch<PartnerSearchBasic>.CreateBasic(Action<PartnerSearchBasic> initializer) => this.CreateBasic(initializer);

        public PartnerSearch CreateBasic(Action<PartnerSearchBasic> initializer)
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

        ISearch<PartnerSearchBasic> 
            ISearch<PartnerSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PartnerSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(PartnerSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PartnerSearchBasic();
                    break;

                case "campaignResponseJoin":
                    result = target.campaignResponseJoin;
                    creator = () => target.campaignResponseJoin = new CampaignSearchBasic();
                    break;
        
                case "contactJoin":
                    result = target.contactJoin;
                    creator = () => target.contactJoin = new ContactSearchBasic();
                    break;
        
                case "contactPrimaryJoin":
                    result = target.contactPrimaryJoin;
                    creator = () => target.contactPrimaryJoin = new ContactSearchBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchBasic();
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
                        default:
                    throw new ArgumentException("PartnerSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}