using System;

namespace SuiteTalk
{
    public partial class TimeSheetSearchRow: SearchRow<TimeSheetSearchRowBasic>, SupportsCustomSearchJoin
    {
        public TimeSheetSearchRowBasic GetBasic() => this.basic;

        public TimeSheetSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new TimeSheetSearchRowBasic();
            return this.basic;
        }

        public TimeSheetSearchRowBasic CreateBasic(Action<TimeSheetSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        public J CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return join;
        }


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(TimeSheetSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "timeBillJoin":
                    result = target.timeBillJoin;
                    creator = () => target.timeBillJoin = new TimeBillSearchRowBasic();
                    break;
        
                case "timeEntryJoin":
                    result = target.timeEntryJoin;
                    creator = () => target.timeEntryJoin = new TimeEntrySearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("TimeSheetSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}