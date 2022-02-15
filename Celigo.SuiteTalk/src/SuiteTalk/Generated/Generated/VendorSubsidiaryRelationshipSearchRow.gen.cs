using System;

namespace SuiteTalk
{
    public partial class VendorSubsidiaryRelationshipSearchRow: SearchRow<VendorSubsidiaryRelationshipSearchRowBasic>, SupportsCustomSearchJoin
    {
        public VendorSubsidiaryRelationshipSearchRowBasic GetBasic() => this.basic;

        public VendorSubsidiaryRelationshipSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new VendorSubsidiaryRelationshipSearchRowBasic();
            return this.basic;
        }

        public VendorSubsidiaryRelationshipSearchRowBasic CreateBasic(Action<VendorSubsidiaryRelationshipSearchRowBasic> initializer)
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


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(VendorSubsidiaryRelationshipSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchRowBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("VendorSubsidiaryRelationshipSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}