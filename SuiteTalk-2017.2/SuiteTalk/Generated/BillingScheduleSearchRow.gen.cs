using System;

namespace SuiteTalk
{
    public partial class BillingScheduleSearchRow: IAdvancedSearchRow, IAdvancedSearchRow<BillingScheduleSearchRowBasic>
    {
        public BillingScheduleSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic IAdvancedSearchRow.GetBasic() => this.basic;

        public BillingScheduleSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BillingScheduleSearchRowBasic();
            return this.basic;
        }

        public BillingScheduleSearchRowBasic CreateBasic(Action<BillingScheduleSearchRowBasic> initializer)
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

        private static SearchRowBasic GetOrCreateJoin(BillingScheduleSearchRow target, string joinName, bool createIfNull = false)
        {
          throw new ArgumentException("BillingScheduleSearchRow does not support Joins");
        }
    }
}