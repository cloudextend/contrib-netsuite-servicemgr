using System;

namespace SuiteTalk
{
    public partial class OpportunitySearchRow: SearchRow, SupportsCustomSearchJoin
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new OpportunitySearchRowBasic();
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
        private static SearchRowBasic GetOrCreateJoin(OpportunitySearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

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