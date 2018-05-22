// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class AccountingTransactionSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<AccountingTransactionSearchRowBasic>
    {
        public AccountingTransactionSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public AccountingTransactionSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new AccountingTransactionSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<AccountingTransactionSearchRowBasic> 
            ISearchAdvancedRow<AccountingTransactionSearchRowBasic>.CreateBasic(Action<AccountingTransactionSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public AccountingTransactionSearchRow CreateBasic(Action<AccountingTransactionSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return this;
        }

        SearchRowBasic ISearchAdvancedRow.CreateBasic() => this.CreateBasic();

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        ISearchAdvancedRow<AccountingTransactionSearchRowBasic> 
            ISearchAdvancedRow<AccountingTransactionSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public AccountingTransactionSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.accountJoin;
      //      yield return this.revRecScheduleJoin;
      //      yield return this.transactionJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(AccountingTransactionSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new AccountingTransactionSearchRowBasic();
                    break;


                case "accountJoin":
                    result = target.accountJoin;
                    creator = () => target.accountJoin = new AccountSearchRowBasic();
                    break;
        
                case "revRecScheduleJoin":
                    result = target.revRecScheduleJoin;
                    creator = () => target.revRecScheduleJoin = new RevRecScheduleSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("AccountingTransactionSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}