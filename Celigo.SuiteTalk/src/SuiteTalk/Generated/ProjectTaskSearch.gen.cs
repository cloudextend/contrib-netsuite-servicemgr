
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ProjectTaskSearch: ISearch, ISearch<ProjectTaskSearchBasic>
    {
        public ProjectTaskSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ProjectTaskSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ProjectTaskSearchBasic();
            return this.basic;
        }

        ISearch<ProjectTaskSearchBasic> 
            ISearch<ProjectTaskSearchBasic>.CreateBasic(Action<ProjectTaskSearchBasic> initializer) => this.CreateBasic(initializer);

        public ProjectTaskSearch CreateBasic(Action<ProjectTaskSearchBasic> initializer)
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

        ISearch<ProjectTaskSearchBasic> 
            ISearch<ProjectTaskSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ProjectTaskSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ProjectTaskSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ProjectTaskSearchBasic();
                    break;

                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchBasic();
                    break;
        
                case "predecessorJoin":
                    result = target.predecessorJoin;
                    creator = () => target.predecessorJoin = new ProjectTaskSearchBasic();
                    break;
        
                case "projectTaskAssignmentJoin":
                    result = target.projectTaskAssignmentJoin;
                    creator = () => target.projectTaskAssignmentJoin = new ProjectTaskAssignmentSearchBasic();
                    break;
        
                case "resourceAllocationJoin":
                    result = target.resourceAllocationJoin;
                    creator = () => target.resourceAllocationJoin = new ResourceAllocationSearchBasic();
                    break;
        
                case "successorJoin":
                    result = target.successorJoin;
                    creator = () => target.successorJoin = new ProjectTaskSearchBasic();
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
                    throw new ArgumentException("ProjectTaskSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}