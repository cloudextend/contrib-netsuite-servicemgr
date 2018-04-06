// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class NoteSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<NoteSearchRowBasic>, SupportsCustomSearchJoin
    {
        public NoteSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public NoteSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new NoteSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<NoteSearchRowBasic> 
            ISearchAdvancedRow<NoteSearchRowBasic>.CreateBasic(Action<NoteSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public NoteSearchRow CreateBasic(Action<NoteSearchRowBasic> initializer)
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

        ISearchAdvancedRow<NoteSearchRowBasic> 
            ISearchAdvancedRow<NoteSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public NoteSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
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
        private static SearchRowBasic GetOrCreateJoin(NoteSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new NoteSearchRowBasic();
                    break;

                case "authorJoin":
                    result = target.authorJoin;
                    creator = () => target.authorJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "callJoin":
                    result = target.callJoin;
                    creator = () => target.callJoin = new PhoneCallSearchRowBasic();
                    break;
        
                case "campaignJoin":
                    result = target.campaignJoin;
                    creator = () => target.campaignJoin = new CampaignSearchRowBasic();
                    break;
        
                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchRowBasic();
                    break;
        
                case "contactJoin":
                    result = target.contactJoin;
                    creator = () => target.contactJoin = new ContactSearchRowBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "entityJoin":
                    result = target.entityJoin;
                    creator = () => target.entityJoin = new EntitySearchRowBasic();
                    break;
        
                case "eventJoin":
                    result = target.eventJoin;
                    creator = () => target.eventJoin = new CalendarEventSearchRowBasic();
                    break;
        
                case "issueJoin":
                    result = target.issueJoin;
                    creator = () => target.issueJoin = new IssueSearchRowBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchRowBasic();
                    break;
        
                case "originatingLeadJoin":
                    result = target.originatingLeadJoin;
                    creator = () => target.originatingLeadJoin = new OriginatingLeadSearchRowBasic();
                    break;
        
                case "partnerJoin":
                    result = target.partnerJoin;
                    creator = () => target.partnerJoin = new PartnerSearchRowBasic();
                    break;
        
                case "solutionJoin":
                    result = target.solutionJoin;
                    creator = () => target.solutionJoin = new SolutionSearchRowBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("NoteSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}