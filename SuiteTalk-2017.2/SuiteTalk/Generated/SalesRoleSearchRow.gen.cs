// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class SalesRoleSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<SalesRoleSearchRowBasic>
    {
        public SalesRoleSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public SalesRoleSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new SalesRoleSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<SalesRoleSearchRowBasic> 
            ISearchAdvancedRow<SalesRoleSearchRowBasic>.CreateBasic(Action<SalesRoleSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public SalesRoleSearchRow CreateBasic(Action<SalesRoleSearchRowBasic> initializer)
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

        ISearchAdvancedRow<SalesRoleSearchRowBasic> 
            ISearchAdvancedRow<SalesRoleSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public SalesRoleSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRowBasic GetOrCreateJoin(SalesRoleSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new SalesRoleSearchRowBasic();
                    break;

                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("SalesRoleSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}