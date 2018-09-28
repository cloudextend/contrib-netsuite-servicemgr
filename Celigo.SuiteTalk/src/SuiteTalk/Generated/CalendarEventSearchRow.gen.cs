// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class CalendarEventSearchRow: ISearchRow, ISearchRow<CalendarEventSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public CalendarEventSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public CalendarEventSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new CalendarEventSearchRowBasic();
            return this.basic;
        }

        ISearchRow<CalendarEventSearchRowBasic> 
            ISearchRow<CalendarEventSearchRowBasic>.CreateBasic(Action<CalendarEventSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public CalendarEventSearchRow CreateBasic(Action<CalendarEventSearchRowBasic> initializer)
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

        ISearchRow<CalendarEventSearchRowBasic> 
            ISearchRow<CalendarEventSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public CalendarEventSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.attendeeJoin;
      //      yield return this.attendeeContactJoin;
      //      yield return this.attendeeCustomerJoin;
      //      yield return this.caseJoin;
      //      yield return this.fileJoin;
      //      yield return this.opportunityJoin;
      //      yield return this.originatingLeadJoin;
      //      yield return this.timeJoin;
      //      yield return this.transactionJoin;
      //      yield return this.userJoin;
      //      yield return this.userNotesJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(CalendarEventSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new CalendarEventSearchRowBasic();
                    break;


                case "attendeeJoin":
                    result = target.attendeeJoin;
                    creator = () => target.attendeeJoin = new EntitySearchRowBasic();
                    break;
        
                case "attendeeContactJoin":
                    result = target.attendeeContactJoin;
                    creator = () => target.attendeeContactJoin = new ContactSearchRowBasic();
                    break;
        
                case "attendeeCustomerJoin":
                    result = target.attendeeCustomerJoin;
                    creator = () => target.attendeeCustomerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchRowBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "opportunityJoin":
                    result = target.opportunityJoin;
                    creator = () => target.opportunityJoin = new OpportunitySearchRowBasic();
                    break;
        
                case "originatingLeadJoin":
                    result = target.originatingLeadJoin;
                    creator = () => target.originatingLeadJoin = new OriginatingLeadSearchRowBasic();
                    break;
        
                case "timeJoin":
                    result = target.timeJoin;
                    creator = () => target.timeJoin = new TimeBillSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("CalendarEventSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}