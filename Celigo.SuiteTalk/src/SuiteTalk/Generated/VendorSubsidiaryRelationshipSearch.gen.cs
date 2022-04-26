
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class VendorSubsidiaryRelationshipSearch: ISearch, ISearch<VendorSubsidiaryRelationshipSearchBasic>
    {
        public VendorSubsidiaryRelationshipSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public VendorSubsidiaryRelationshipSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new VendorSubsidiaryRelationshipSearchBasic();
            return this.basic;
        }

        ISearch<VendorSubsidiaryRelationshipSearchBasic> 
            ISearch<VendorSubsidiaryRelationshipSearchBasic>.CreateBasic(Action<VendorSubsidiaryRelationshipSearchBasic> initializer) => this.CreateBasic(initializer);

        public VendorSubsidiaryRelationshipSearch CreateBasic(Action<VendorSubsidiaryRelationshipSearchBasic> initializer)
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

        ISearch<VendorSubsidiaryRelationshipSearchBasic> 
            ISearch<VendorSubsidiaryRelationshipSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public VendorSubsidiaryRelationshipSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(VendorSubsidiaryRelationshipSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new VendorSubsidiaryRelationshipSearchBasic();
                    break;

                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("VendorSubsidiaryRelationshipSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}