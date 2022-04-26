
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class TimeSheetSearch: ISearch, ISearch<TimeSheetSearchBasic>
    {
        public TimeSheetSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public TimeSheetSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new TimeSheetSearchBasic();
            return this.basic;
        }

        ISearch<TimeSheetSearchBasic> 
            ISearch<TimeSheetSearchBasic>.CreateBasic(Action<TimeSheetSearchBasic> initializer) => this.CreateBasic(initializer);

        public TimeSheetSearch CreateBasic(Action<TimeSheetSearchBasic> initializer)
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

        ISearch<TimeSheetSearchBasic> 
            ISearch<TimeSheetSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public TimeSheetSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(TimeSheetSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new TimeSheetSearchBasic();
                    break;

                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchBasic();
                    break;
        
                case "timeBillJoin":
                    result = target.timeBillJoin;
                    creator = () => target.timeBillJoin = new TimeBillSearchBasic();
                    break;
        
                case "timeEntryJoin":
                    result = target.timeEntryJoin;
                    creator = () => target.timeEntryJoin = new TimeEntrySearchBasic();
                    break;
                        default:
                    throw new ArgumentException("TimeSheetSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}