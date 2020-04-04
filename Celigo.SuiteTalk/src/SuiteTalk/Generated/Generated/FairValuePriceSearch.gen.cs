// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class FairValuePriceSearch: ISearch, ISearch<FairValuePriceSearchBasic>
    {
        public FairValuePriceSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public FairValuePriceSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new FairValuePriceSearchBasic();
            return this.basic;
        }

        ISearch<FairValuePriceSearchBasic> 
            ISearch<FairValuePriceSearchBasic>.CreateBasic(Action<FairValuePriceSearchBasic> initializer) => this.CreateBasic(initializer);

        public FairValuePriceSearch CreateBasic(Action<FairValuePriceSearchBasic> initializer)
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

        ISearch<FairValuePriceSearchBasic> 
            ISearch<FairValuePriceSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public FairValuePriceSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(FairValuePriceSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new FairValuePriceSearchBasic();
                    break;

                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("FairValuePriceSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}