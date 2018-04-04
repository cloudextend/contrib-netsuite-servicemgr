using System;

namespace SuiteTalk
{
    public partial class BillingScheduleSearchRow: SearchRow
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BillingScheduleSearchRowBasic();
            return this.basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        private static SearchRowBasic GetOrCreateJoin(BillingScheduleSearchRow target, string joinName, bool createIfNull = false)
        {
          throw new ArgumentException("BillingScheduleSearchRow does not support Joins");
        }
    }
}