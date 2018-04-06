using System;

namespace SuiteTalk
{
    public partial class TopicSearchRow: IAdvancedSearchRow, IAdvancedSearchRow<TopicSearchRowBasic>
    {
        public TopicSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic IAdvancedSearchRow.GetBasic() => this.basic;

        public TopicSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new TopicSearchRowBasic();
            return this.basic;
        }

        public TopicSearchRowBasic CreateBasic(Action<TopicSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return basic;
        }

        SearchRowBasic IAdvancedSearchRow.CreateBasic() => this.CreateBasic();

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

        private static SearchRowBasic GetOrCreateJoin(TopicSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "solutionJoin":
                    result = target.solutionJoin;
                    creator = () => target.solutionJoin = new SolutionSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("TopicSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}