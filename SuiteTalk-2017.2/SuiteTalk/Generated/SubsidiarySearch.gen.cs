// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class SubsidiarySearch: ISearch, ISearch<SubsidiarySearchBasic>
    {
        public SubsidiarySearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public SubsidiarySearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new SubsidiarySearchBasic();
            return this.basic;
        }

        ISearch<SubsidiarySearchBasic> 
            ISearch<SubsidiarySearchBasic>.CreateBasic(Action<SubsidiarySearchBasic> initializer) => this.CreateBasic(initializer);

        public SubsidiarySearch CreateBasic(Action<SubsidiarySearchBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return this;
        }

        SearchRecordBasic ISearch.CreateBasic() => this.CreateBasic();

        public SearchRecordBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRecordBasic => (J)this.GetJoin(joinName);

        public SearchRecordBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRecordBasic => (J)this.CreateJoin(joinName);

        ISearch<SubsidiarySearchBasic> 
            ISearch<SubsidiarySearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public SubsidiarySearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(SubsidiarySearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new SubsidiarySearchBasic();
                    break;

                case "addressJoin":
                    result = target.addressJoin;
                    creator = () => target.addressJoin = new AddressSearchBasic();
                    break;
        
                case "defaultAdvanceToApplyAccountJoin":
                    result = target.defaultAdvanceToApplyAccountJoin;
                    creator = () => target.defaultAdvanceToApplyAccountJoin = new AccountSearchBasic();
                    break;
        
                case "returnAddressJoin":
                    result = target.returnAddressJoin;
                    creator = () => target.returnAddressJoin = new AddressSearchBasic();
                    break;
        
                case "shippingAddressJoin":
                    result = target.shippingAddressJoin;
                    creator = () => target.shippingAddressJoin = new AddressSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("SubsidiarySearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}