using System;

namespace SuiteTalk
{
    public partial class UsageSearchRow: SearchRow
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new UsageSearchRowBasic();
            return this.basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        private static SearchRowBasic GetOrCreateJoin(UsageSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "subscriptionPlanJoin":
                    result = target.subscriptionPlanJoin;
                    creator = () => target.subscriptionPlanJoin = new ItemSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("UsageSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}