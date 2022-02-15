using System;

namespace SuiteTalk
{
    public partial class UsageSearchRow: SearchRow<UsageSearchRowBasic>
    {
        public UsageSearchRowBasic GetBasic() => this.basic;

        public UsageSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new UsageSearchRowBasic();
            return this.basic;
        }

        public UsageSearchRowBasic CreateBasic(Action<UsageSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return basic;
        }

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

        private static SearchRowBasic GetOrCreateJoin(UsageSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "chargeJoin":
                    result = target.chargeJoin;
                    creator = () => target.chargeJoin = new ChargeSearchRowBasic();
                    break;
        
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