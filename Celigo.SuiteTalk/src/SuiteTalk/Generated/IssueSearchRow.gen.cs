// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class IssueSearchRow: ISearchRow, ISearchRow<IssueSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public IssueSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public IssueSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new IssueSearchRowBasic();
            return this.basic;
        }

        ISearchRow<IssueSearchRowBasic> 
            ISearchRow<IssueSearchRowBasic>.CreateBasic(Action<IssueSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public IssueSearchRow CreateBasic(Action<IssueSearchRowBasic> initializer)
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

        ISearchRow<IssueSearchRowBasic> 
            ISearchRow<IssueSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public IssueSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.caseJoin;
      //      yield return this.employeeJoin;
      //      yield return this.fileJoin;
      //      yield return this.productTeamJoin;
      //      yield return this.userJoin;
      //      yield return this.userNotesJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(IssueSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new IssueSearchRowBasic();
                    break;


                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchRowBasic();
                    break;
        
                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "fileJoin":
                    result = target.fileJoin;
                    creator = () => target.fileJoin = new FileSearchRowBasic();
                    break;
        
                case "productTeamJoin":
                    result = target.productTeamJoin;
                    creator = () => target.productTeamJoin = new EntityGroupSearchRowBasic();
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
                    throw new ArgumentException("IssueSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}