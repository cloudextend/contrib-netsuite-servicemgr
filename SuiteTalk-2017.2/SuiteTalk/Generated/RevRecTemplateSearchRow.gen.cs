// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class RevRecTemplateSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<RevRecTemplateSearchRowBasic>
    {
        public RevRecTemplateSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public RevRecTemplateSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new RevRecTemplateSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<RevRecTemplateSearchRowBasic> 
            ISearchAdvancedRow<RevRecTemplateSearchRowBasic>.CreateBasic(Action<RevRecTemplateSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public RevRecTemplateSearchRow CreateBasic(Action<RevRecTemplateSearchRowBasic> initializer)
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

        ISearchAdvancedRow<RevRecTemplateSearchRowBasic> 
            ISearchAdvancedRow<RevRecTemplateSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public RevRecTemplateSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRowBasic GetOrCreateJoin(RevRecTemplateSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new RevRecTemplateSearchRowBasic();
                    break;

                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("RevRecTemplateSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}