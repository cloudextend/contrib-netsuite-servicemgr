using System;

namespace SuiteTalk
{
    public partial class PaymentInstrumentSearchRow: SearchRow<PaymentInstrumentSearchRowBasic>
    {
        public PaymentInstrumentSearchRowBasic GetBasic() => this.basic;

        public PaymentInstrumentSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PaymentInstrumentSearchRowBasic();
            return this.basic;
        }

        public PaymentInstrumentSearchRowBasic CreateBasic(Action<PaymentInstrumentSearchRowBasic> initializer)
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

        private static SearchRowBasic GetOrCreateJoin(PaymentInstrumentSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("PaymentInstrumentSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
                }
    }
}