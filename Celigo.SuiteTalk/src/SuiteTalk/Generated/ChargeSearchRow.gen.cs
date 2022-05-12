
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class ChargeSearchRow: ISearchRow, ISearchRow<ChargeSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public ChargeSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public ChargeSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ChargeSearchRowBasic();
            return this.basic;
        }

        ISearchRow<ChargeSearchRowBasic> 
            ISearchRow<ChargeSearchRowBasic>.CreateBasic(Action<ChargeSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ChargeSearchRow CreateBasic(Action<ChargeSearchRowBasic> initializer)
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

        ISearchRow<ChargeSearchRowBasic> 
            ISearchRow<ChargeSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ChargeSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.billingAccountJoin;
      //      yield return this.billingScheduleJoin;
      //      yield return this.chargeEmployeeJoin;
      //      yield return this.customerJoin;
      //      yield return this.invoiceJoin;
      //      yield return this.itemJoin;
      //      yield return this.jobJoin;
      //      yield return this.salesOrderJoin;
      //      yield return this.timeJoin;
      //      yield return this.transactionJoin;
      //      yield return this.usageJoin;
      //      yield return this.userJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(ChargeSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ChargeSearchRowBasic();
                    break;


                case "billingAccountJoin":
                    result = target.billingAccountJoin;
                    creator = () => target.billingAccountJoin = new BillingAccountSearchRowBasic();
                    break;
        
                case "billingScheduleJoin":
                    result = target.billingScheduleJoin;
                    creator = () => target.billingScheduleJoin = new BillingScheduleSearchRowBasic();
                    break;
        
                case "chargeEmployeeJoin":
                    result = target.chargeEmployeeJoin;
                    creator = () => target.chargeEmployeeJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "invoiceJoin":
                    result = target.invoiceJoin;
                    creator = () => target.invoiceJoin = new TransactionSearchRowBasic();
                    break;
        
                case "itemJoin":
                    result = target.itemJoin;
                    creator = () => target.itemJoin = new ItemSearchRowBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchRowBasic();
                    break;
        
                case "salesOrderJoin":
                    result = target.salesOrderJoin;
                    creator = () => target.salesOrderJoin = new TransactionSearchRowBasic();
                    break;
        
                case "timeJoin":
                    result = target.timeJoin;
                    creator = () => target.timeJoin = new TimeBillSearchRowBasic();
                    break;
        
                case "transactionJoin":
                    result = target.transactionJoin;
                    creator = () => target.transactionJoin = new TransactionSearchRowBasic();
                    break;
        
                case "usageJoin":
                    result = target.usageJoin;
                    creator = () => target.usageJoin = new UsageSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ChargeSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}