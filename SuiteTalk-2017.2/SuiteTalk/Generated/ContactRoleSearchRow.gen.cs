using System;

namespace SuiteTalk
{
    public partial class ContactRoleSearchRow: SearchRow
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ContactRoleSearchRowBasic();
            return this.basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        private static SearchRowBasic GetOrCreateJoin(ContactRoleSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ContactRoleSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}