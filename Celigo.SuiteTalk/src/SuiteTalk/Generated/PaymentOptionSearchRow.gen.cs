
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class PaymentOptionSearchRow: ISearchRow, ISearchRow<PaymentOptionSearchRowBasic>
    {
        public PaymentOptionSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public PaymentOptionSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PaymentOptionSearchRowBasic();
            return this.basic;
        }

        ISearchRow<PaymentOptionSearchRowBasic> 
            ISearchRow<PaymentOptionSearchRowBasic>.CreateBasic(Action<PaymentOptionSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public PaymentOptionSearchRow CreateBasic(Action<PaymentOptionSearchRowBasic> initializer)
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

        ISearchRow<PaymentOptionSearchRowBasic> 
            ISearchRow<PaymentOptionSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PaymentOptionSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.transactionJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(PaymentOptionSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PaymentOptionSearchRowBasic();
                    break;


                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("PaymentOptionSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}