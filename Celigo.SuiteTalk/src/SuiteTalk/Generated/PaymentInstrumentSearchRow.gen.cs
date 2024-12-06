// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class PaymentInstrumentSearchRow: ISearchRow, ISearchRow<PaymentInstrumentSearchRowBasic>
    {
        public PaymentInstrumentSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public PaymentInstrumentSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PaymentInstrumentSearchRowBasic();
            return this.basic;
        }

        ISearchRow<PaymentInstrumentSearchRowBasic> 
            ISearchRow<PaymentInstrumentSearchRowBasic>.CreateBasic(Action<PaymentInstrumentSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public PaymentInstrumentSearchRow CreateBasic(Action<PaymentInstrumentSearchRowBasic> initializer)
        {
            var rowBasic = this.CreateBasic();
            initializer(rowBasic);
            return this;
        }

        SearchRowBasic ISearchRow.CreateBasic() => this.CreateBasic();

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        ISearchRow<PaymentInstrumentSearchRowBasic> 
            ISearchRow<PaymentInstrumentSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PaymentInstrumentSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.customerJoin;
      //      yield return this.transactionJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(PaymentInstrumentSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PaymentInstrumentSearchRowBasic();
                    break;


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