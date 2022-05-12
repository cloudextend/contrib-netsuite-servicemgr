
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class RevRecScheduleSearchRow: ISearchRow, ISearchRow<RevRecScheduleSearchRowBasic>
    {
        public RevRecScheduleSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public RevRecScheduleSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new RevRecScheduleSearchRowBasic();
            return this.basic;
        }

        ISearchRow<RevRecScheduleSearchRowBasic> 
            ISearchRow<RevRecScheduleSearchRowBasic>.CreateBasic(Action<RevRecScheduleSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public RevRecScheduleSearchRow CreateBasic(Action<RevRecScheduleSearchRowBasic> initializer)
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

        ISearchRow<RevRecScheduleSearchRowBasic> 
            ISearchRow<RevRecScheduleSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public RevRecScheduleSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.appliedToTransactionJoin;
      //      yield return this.customerJoin;
      //      yield return this.itemJoin;
      //      yield return this.transactionJoin;
      //      yield return this.userJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(RevRecScheduleSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new RevRecScheduleSearchRowBasic();
                    break;


                case "appliedToTransactionJoin":
                    result = target.appliedToTransactionJoin;
                    creator = () => target.appliedToTransactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("RevRecScheduleSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}