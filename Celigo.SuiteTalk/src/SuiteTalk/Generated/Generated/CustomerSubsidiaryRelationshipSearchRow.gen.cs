using System;

namespace SuiteTalk
{
    public partial class CustomerSubsidiaryRelationshipSearchRow: SearchRow<CustomerSubsidiaryRelationshipSearchRowBasic>, SupportsCustomSearchJoin
    {
        public CustomerSubsidiaryRelationshipSearchRowBasic GetBasic() => this.basic;

        public CustomerSubsidiaryRelationshipSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new CustomerSubsidiaryRelationshipSearchRowBasic();
            return this.basic;
        }

        public CustomerSubsidiaryRelationshipSearchRowBasic CreateBasic(Action<CustomerSubsidiaryRelationshipSearchRowBasic> initializer)
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
        private static SearchRowBasic GetOrCreateJoin(CustomerSubsidiaryRelationshipSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("CustomerSubsidiaryRelationshipSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}