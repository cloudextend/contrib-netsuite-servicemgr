using System;

namespace SuiteTalk
{
    public partial class BillingAccountSearchRow: SearchRow, SupportsCustomSearchJoin
    {
        public SearchRowBasic GetBasic() => this.basic;

        public SearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new BillingAccountSearchRowBasic();
            return this.basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(BillingAccountSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("BillingAccountSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}