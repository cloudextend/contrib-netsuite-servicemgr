
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class LocationSearch: ISearch, ISearch<LocationSearchBasic>
    {
        public LocationSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public LocationSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new LocationSearchBasic();
            return this.basic;
        }

        ISearch<LocationSearchBasic> 
            ISearch<LocationSearchBasic>.CreateBasic(Action<LocationSearchBasic> initializer) => this.CreateBasic(initializer);

        public LocationSearch CreateBasic(Action<LocationSearchBasic> initializer)
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

        ISearch<LocationSearchBasic> 
            ISearch<LocationSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public LocationSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(LocationSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new LocationSearchBasic();
                    break;

                case "addressJoin":
                    result = target.addressJoin;
                    creator = () => target.addressJoin = new AddressSearchBasic();
                    break;
        
                case "returnAddressJoin":
                    result = target.returnAddressJoin;
                    creator = () => target.returnAddressJoin = new AddressSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("LocationSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}