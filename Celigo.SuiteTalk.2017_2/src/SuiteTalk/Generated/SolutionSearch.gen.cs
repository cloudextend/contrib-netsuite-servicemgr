// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class SolutionSearch: ISearch, ISearch<SolutionSearchBasic>
    {
        public SolutionSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public SolutionSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new SolutionSearchBasic();
            return this.basic;
        }

        ISearch<SolutionSearchBasic> 
            ISearch<SolutionSearchBasic>.CreateBasic(Action<SolutionSearchBasic> initializer) => this.CreateBasic(initializer);

        public SolutionSearch CreateBasic(Action<SolutionSearchBasic> initializer)
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

        ISearch<SolutionSearchBasic> 
            ISearch<SolutionSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public SolutionSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(SolutionSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new SolutionSearchBasic();
                    break;

                case "caseJoin":
                    result = target.caseJoin;
                    creator = () => target.caseJoin = new SupportCaseSearchBasic();
                    break;
        
                case "relatedSolutionJoin":
                    result = target.relatedSolutionJoin;
                    creator = () => target.relatedSolutionJoin = new SolutionSearchBasic();
                    break;
        
                case "topicJoin":
                    result = target.topicJoin;
                    creator = () => target.topicJoin = new TopicSearchBasic();
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
                    throw new ArgumentException("SolutionSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}