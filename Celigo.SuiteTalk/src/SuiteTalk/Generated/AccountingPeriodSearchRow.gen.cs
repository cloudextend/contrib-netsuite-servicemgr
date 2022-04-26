
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class AccountingPeriodSearchRow: ISearchRow, ISearchRow<AccountingPeriodSearchRowBasic>
    {
        public AccountingPeriodSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public AccountingPeriodSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new AccountingPeriodSearchRowBasic();
            return this.basic;
        }

        ISearchRow<AccountingPeriodSearchRowBasic> 
            ISearchRow<AccountingPeriodSearchRowBasic>.CreateBasic(Action<AccountingPeriodSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public AccountingPeriodSearchRow CreateBasic(Action<AccountingPeriodSearchRowBasic> initializer)
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

        ISearchRow<AccountingPeriodSearchRowBasic> 
            ISearchRow<AccountingPeriodSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public AccountingPeriodSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.userJoin;
      //      yield return this.userNotesJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(AccountingPeriodSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new AccountingPeriodSearchRowBasic();
                    break;


                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "userNotesJoin":
                    result = target.userNotesJoin;
                    creator = () => target.userNotesJoin = new NoteSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("AccountingPeriodSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}