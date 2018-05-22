// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class UsageSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<UsageSearchRowBasic>
    {
        public UsageSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public UsageSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new UsageSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<UsageSearchRowBasic> 
            ISearchAdvancedRow<UsageSearchRowBasic>.CreateBasic(Action<UsageSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public UsageSearchRow CreateBasic(Action<UsageSearchRowBasic> initializer)
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

        ISearchAdvancedRow<UsageSearchRowBasic> 
            ISearchAdvancedRow<UsageSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public UsageSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.customerJoin;
      //      yield return this.itemJoin;
      //      yield return this.subscriptionPlanJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(UsageSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new UsageSearchRowBasic();
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