// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class SalesTaxItemSearch: ISearch, ISearch<SalesTaxItemSearchBasic>
    {
        public SalesTaxItemSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public SalesTaxItemSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new SalesTaxItemSearchBasic();
            return this.basic;
        }

        ISearch<SalesTaxItemSearchBasic> 
            ISearch<SalesTaxItemSearchBasic>.CreateBasic(Action<SalesTaxItemSearchBasic> initializer) => this.CreateBasic(initializer);

        public SalesTaxItemSearch CreateBasic(Action<SalesTaxItemSearchBasic> initializer)
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

        ISearch<SalesTaxItemSearchBasic> 
            ISearch<SalesTaxItemSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public SalesTaxItemSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(SalesTaxItemSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new SalesTaxItemSearchBasic();
                    break;

                case "taxTypeJoin":
                    result = target.taxTypeJoin;
                    creator = () => target.taxTypeJoin = new TaxTypeSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("SalesTaxItemSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}