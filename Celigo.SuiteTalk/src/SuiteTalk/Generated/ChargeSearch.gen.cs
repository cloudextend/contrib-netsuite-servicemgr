
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ChargeSearch: ISearch, ISearch<ChargeSearchBasic>
    {
        public ChargeSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ChargeSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ChargeSearchBasic();
            return this.basic;
        }

        ISearch<ChargeSearchBasic> 
            ISearch<ChargeSearchBasic>.CreateBasic(Action<ChargeSearchBasic> initializer) => this.CreateBasic(initializer);

        public ChargeSearch CreateBasic(Action<ChargeSearchBasic> initializer)
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

        ISearch<ChargeSearchBasic> 
            ISearch<ChargeSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ChargeSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ChargeSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ChargeSearchBasic();
                    break;

                case "billingAccountJoin":
                    result = target.billingAccountJoin;
                    creator = () => target.billingAccountJoin = new BillingAccountSearchBasic();
                    break;
        
                case "billingScheduleJoin":
                    result = target.billingScheduleJoin;
                    creator = () => target.billingScheduleJoin = new BillingScheduleSearchBasic();
                    break;
        
                case "chargeEmployeeJoin":
                    result = target.chargeEmployeeJoin;
                    creator = () => target.chargeEmployeeJoin = new EmployeeSearchBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "invoiceJoin":
                    result = target.invoiceJoin;
                    creator = () => target.invoiceJoin = new TransactionSearchBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchBasic();
                    break;
        
                case "salesOrderJoin":
                    result = target.salesOrderJoin;
                    creator = () => target.salesOrderJoin = new TransactionSearchBasic();
                    break;
        
                case "timeJoin":
                    result = target.timeJoin;
                    creator = () => target.timeJoin = new TimeBillSearchBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchBasic();
                    break;
        
                case "usageJoin":
                    result = target.usageJoin;
                    creator = () => target.usageJoin = new UsageSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ChargeSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}