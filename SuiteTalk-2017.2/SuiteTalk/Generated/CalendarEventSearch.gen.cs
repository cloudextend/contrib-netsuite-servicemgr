// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class CalendarEventSearch: ISearch, ISearch<CalendarEventSearchBasic>
    {
        public CalendarEventSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public CalendarEventSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new CalendarEventSearchBasic();
            return this.basic;
        }

        ISearch<CalendarEventSearchBasic> 
            ISearch<CalendarEventSearchBasic>.CreateBasic(Action<CalendarEventSearchBasic> initializer) => this.CreateBasic(initializer);

        public CalendarEventSearch CreateBasic(Action<CalendarEventSearchBasic> initializer)
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

        ISearch<CalendarEventSearchBasic> 
            ISearch<CalendarEventSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public CalendarEventSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(CalendarEventSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new CalendarEventSearchBasic();
                    break;

                case "attendeeJoin":
                    result = target.attendeeJoin;
                    creator = () => target.attendeeJoin = new EntitySearchBasic();
                    break;
        
                case "attendeeContactJoin":
                    result = target.attendeeContactJoin;
                    creator = () => target.attendeeContactJoin = new ContactSearchBasic();
                    break;
        
                case "attendeeCustomerJoin":
                    result = target.attendeeCustomerJoin;
                    creator = () => target.attendeeCustomerJoin = new CustomerSearchBasic();
                    break;
        
                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchBasic();
                    break;
        
                case "originatingLeadJoin":
                    result = target.originatingLeadJoin;
                    creator = () => target.originatingLeadJoin = new OriginatingLeadSearchBasic();
                    break;
        
                case "timeJoin":
                    result = target.timeJoin;
                    creator = () => target.timeJoin = new TimeBillSearchBasic();
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
                    throw new ArgumentException("CalendarEventSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}