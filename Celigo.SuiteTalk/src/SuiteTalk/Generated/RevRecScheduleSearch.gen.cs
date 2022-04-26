
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class RevRecScheduleSearch: ISearch, ISearch<RevRecScheduleSearchBasic>
    {
        public RevRecScheduleSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public RevRecScheduleSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new RevRecScheduleSearchBasic();
            return this.basic;
        }

        ISearch<RevRecScheduleSearchBasic> 
            ISearch<RevRecScheduleSearchBasic>.CreateBasic(Action<RevRecScheduleSearchBasic> initializer) => this.CreateBasic(initializer);

        public RevRecScheduleSearch CreateBasic(Action<RevRecScheduleSearchBasic> initializer)
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

        ISearch<RevRecScheduleSearchBasic> 
            ISearch<RevRecScheduleSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public RevRecScheduleSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(RevRecScheduleSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new RevRecScheduleSearchBasic();
                    break;

                case "appliedToTransactionJoin":
                    result = target.appliedToTransactionJoin;
                    creator = () => target.appliedToTransactionJoin = new TransactionSearchBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("RevRecScheduleSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}