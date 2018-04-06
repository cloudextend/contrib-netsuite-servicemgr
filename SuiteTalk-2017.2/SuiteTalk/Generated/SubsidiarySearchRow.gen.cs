using System;

namespace SuiteTalk
{
    public partial class SubsidiarySearchRow: IAdvancedSearchRow, IAdvancedSearchRow<SubsidiarySearchRowBasic>, SupportsCustomSearchJoin
    {
        public SubsidiarySearchRowBasic GetBasic() => this.basic;

        SearchRowBasic IAdvancedSearchRow.GetBasic() => this.basic;

        public SubsidiarySearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new SubsidiarySearchRowBasic();
            return this.basic;
        }

        public SubsidiarySearchRowBasic CreateBasic(Action<SubsidiarySearchRowBasic> initializer)
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


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(SubsidiarySearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "addressJoin":
                    result = target.addressJoin;
                    creator = () => target.addressJoin = new AddressSearchRowBasic();
                    break;
        
                case "defaultAdvanceToApplyAccountJoin":
                    result = target.defaultAdvanceToApplyAccountJoin;
                    creator = () => target.defaultAdvanceToApplyAccountJoin = new AccountSearchRowBasic();
                    break;
        
                case "returnAddressJoin":
                    result = target.returnAddressJoin;
                    creator = () => target.returnAddressJoin = new AddressSearchRowBasic();
                    break;
        
                case "shippingAddressJoin":
                    result = target.shippingAddressJoin;
                    creator = () => target.shippingAddressJoin = new AddressSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("SubsidiarySearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}