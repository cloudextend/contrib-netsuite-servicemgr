// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class PaymentInstrumentSearch: ISearch, ISearch<PaymentInstrumentSearchBasic>
    {
        public PaymentInstrumentSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public PaymentInstrumentSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PaymentInstrumentSearchBasic();
            return this.basic;
        }

        ISearch<PaymentInstrumentSearchBasic> 
            ISearch<PaymentInstrumentSearchBasic>.CreateBasic(Action<PaymentInstrumentSearchBasic> initializer) => this.CreateBasic(initializer);

        public PaymentInstrumentSearch CreateBasic(Action<PaymentInstrumentSearchBasic> initializer)
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

        ISearch<PaymentInstrumentSearchBasic> 
            ISearch<PaymentInstrumentSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PaymentInstrumentSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(PaymentInstrumentSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PaymentInstrumentSearchBasic();
                    break;

                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("PaymentInstrumentSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}