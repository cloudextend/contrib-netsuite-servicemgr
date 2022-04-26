
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class GiftCertificateSearch: ISearch, ISearch<GiftCertificateSearchBasic>
    {
        public GiftCertificateSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public GiftCertificateSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new GiftCertificateSearchBasic();
            return this.basic;
        }

        ISearch<GiftCertificateSearchBasic> 
            ISearch<GiftCertificateSearchBasic>.CreateBasic(Action<GiftCertificateSearchBasic> initializer) => this.CreateBasic(initializer);

        public GiftCertificateSearch CreateBasic(Action<GiftCertificateSearchBasic> initializer)
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

        ISearch<GiftCertificateSearchBasic> 
            ISearch<GiftCertificateSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public GiftCertificateSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(GiftCertificateSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new GiftCertificateSearchBasic();
                    break;

                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("GiftCertificateSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}