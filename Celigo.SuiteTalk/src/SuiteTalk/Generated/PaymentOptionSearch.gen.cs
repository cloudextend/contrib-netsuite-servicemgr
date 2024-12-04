// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class PaymentOptionSearch: ISearch, ISearch<PaymentOptionSearchBasic>
    {
        public PaymentOptionSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public PaymentOptionSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PaymentOptionSearchBasic();
            return this.basic;
        }

        ISearch<PaymentOptionSearchBasic> 
            ISearch<PaymentOptionSearchBasic>.CreateBasic(Action<PaymentOptionSearchBasic> initializer) => this.CreateBasic(initializer);

        public PaymentOptionSearch CreateBasic(Action<PaymentOptionSearchBasic> initializer)
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

        ISearch<PaymentOptionSearchBasic> 
            ISearch<PaymentOptionSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PaymentOptionSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(PaymentOptionSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PaymentOptionSearchBasic();
                    break;

                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("PaymentOptionSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}