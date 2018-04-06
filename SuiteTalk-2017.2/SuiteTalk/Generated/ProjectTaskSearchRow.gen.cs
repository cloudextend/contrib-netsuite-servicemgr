// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class ProjectTaskSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<ProjectTaskSearchRowBasic>, SupportsCustomSearchJoin
    {
        public ProjectTaskSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public ProjectTaskSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ProjectTaskSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<ProjectTaskSearchRowBasic> 
            ISearchAdvancedRow<ProjectTaskSearchRowBasic>.CreateBasic(Action<ProjectTaskSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ProjectTaskSearchRow CreateBasic(Action<ProjectTaskSearchRowBasic> initializer)
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

        ISearchAdvancedRow<ProjectTaskSearchRowBasic> 
            ISearchAdvancedRow<ProjectTaskSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ProjectTaskSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
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
        private static SearchRowBasic GetOrCreateJoin(ProjectTaskSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ProjectTaskSearchRowBasic();
                    break;

                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchRowBasic();
                    break;
        
                case "predecessorJoin":
                    result = target.predecessorJoin;
                    creator = () => target.predecessorJoin = new ProjectTaskSearchRowBasic();
                    break;
        
                case "projectTaskAssignmentJoin":
                    result = target.projectTaskAssignmentJoin;
                    creator = () => target.projectTaskAssignmentJoin = new ProjectTaskAssignmentSearchRowBasic();
                    break;
        
                case "resourceAllocationJoin":
                    result = target.resourceAllocationJoin;
                    creator = () => target.resourceAllocationJoin = new ResourceAllocationSearchRowBasic();
                    break;
        
                case "successorJoin":
                    result = target.successorJoin;
                    creator = () => target.successorJoin = new ProjectTaskSearchRowBasic();
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
                    throw new ArgumentException("ProjectTaskSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}