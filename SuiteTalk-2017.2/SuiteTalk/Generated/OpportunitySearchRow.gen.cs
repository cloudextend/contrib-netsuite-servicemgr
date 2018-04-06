// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class OpportunitySearchRow: ISearchAdvancedRow, ISearchAdvancedRow<OpportunitySearchRowBasic>, SupportsCustomSearchJoin
    {
        public OpportunitySearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public OpportunitySearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new OpportunitySearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<OpportunitySearchRowBasic> 
            ISearchAdvancedRow<OpportunitySearchRowBasic>.CreateBasic(Action<OpportunitySearchRowBasic> initializer) => this.CreateBasic(initializer);

        public OpportunitySearchRow CreateBasic(Action<OpportunitySearchRowBasic> initializer)
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

        ISearchAdvancedRow<OpportunitySearchRowBasic> 
            ISearchAdvancedRow<OpportunitySearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public OpportunitySearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(OpportunitySearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new OpportunitySearchRowBasic();
                    break;

                case "actualJoin":
                    result = target.actualJoin;
                    creator = () => target.actualJoin = new TransactionSearchRowBasic();
                    break;
        
                case "callJoin":
                    result = target.callJoin;
                    creator = () => target.callJoin = new PhoneCallSearchRowBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "decisionMakerJoin":
                    result = target.decisionMakerJoin;
                    creator = () => target.decisionMakerJoin = new ContactSearchRowBasic();
                    break;
        
                case "estimateJoin":
                    result = target.estimateJoin;
                    creator = () => target.estimateJoin = new TransactionSearchRowBasic();
                    break;
        
                case "eventJoin":
                    result = target.eventJoin;
                    creator = () => target.eventJoin = new CalendarEventSearchRowBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "leadSourceJoin":
                    result = target.leadSourceJoin;
                    creator = () => target.leadSourceJoin = new CampaignSearchRowBasic();
                    break;
        
                case "messagesJoin":
                    result = target.messagesJoin;
                    creator = () => target.messagesJoin = new MessageSearchRowBasic();
                    break;
        
                case "orderJoin":
                    result = target.orderJoin;
                    creator = () => target.orderJoin = new TransactionSearchRowBasic();
                    break;
        
                case "originatingLeadJoin":
                    result = target.originatingLeadJoin;
                    creator = () => target.originatingLeadJoin = new OriginatingLeadSearchRowBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchRowBasic();
                    break;
        
                case "salesRepJoin":
                    result = target.salesRepJoin;
                    creator = () => target.salesRepJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchRowBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("OpportunitySearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}