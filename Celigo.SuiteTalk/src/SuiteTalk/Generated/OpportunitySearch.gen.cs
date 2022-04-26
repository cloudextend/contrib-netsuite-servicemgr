
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class OpportunitySearch: ISearch, ISearch<OpportunitySearchBasic>
    {
        public OpportunitySearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public OpportunitySearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new OpportunitySearchBasic();
            return this.basic;
        }

        ISearch<OpportunitySearchBasic> 
            ISearch<OpportunitySearchBasic>.CreateBasic(Action<OpportunitySearchBasic> initializer) => this.CreateBasic(initializer);

        public OpportunitySearch CreateBasic(Action<OpportunitySearchBasic> initializer)
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

        ISearch<OpportunitySearchBasic> 
            ISearch<OpportunitySearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public OpportunitySearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(OpportunitySearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new OpportunitySearchBasic();
                    break;

                case "actualJoin":
                    result = target.actualJoin;
                    creator = () => target.actualJoin = new TransactionSearchBasic();
                    break;
        
                case "callJoin":
                    result = target.callJoin;
                    creator = () => target.callJoin = new PhoneCallSearchBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "decisionMakerJoin":
                    result = target.decisionMakerJoin;
                    creator = () => target.decisionMakerJoin = new ContactSearchBasic();
                    break;
        
                case "estimateJoin":
                    result = target.estimateJoin;
                    creator = () => target.estimateJoin = new TransactionSearchBasic();
                    break;
        
                case "eventJoin":
                    result = target.eventJoin;
                    creator = () => target.eventJoin = new CalendarEventSearchBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
        
                case "leadSourceJoin":
                    result = target.leadSourceJoin;
                    creator = () => target.leadSourceJoin = new CampaignSearchBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchBasic();
                    break;
        
                case "orderJoin":
                    result = target.orderJoin;
                    creator = () => target.orderJoin = new TransactionSearchBasic();
                    break;
        
                case "originatingLeadJoin":
                    result = target.originatingLeadJoin;
                    creator = () => target.originatingLeadJoin = new OriginatingLeadSearchBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchBasic();
                    break;
        
                case "salesRepJoin":
                    result = target.salesRepJoin;
                    creator = () => target.salesRepJoin = new EmployeeSearchBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("OpportunitySearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}