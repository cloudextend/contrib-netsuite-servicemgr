// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class PaycheckSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<PaycheckSearchRowBasic>
    {
        public PaycheckSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public PaycheckSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PaycheckSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<PaycheckSearchRowBasic> 
            ISearchAdvancedRow<PaycheckSearchRowBasic>.CreateBasic(Action<PaycheckSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public PaycheckSearchRow CreateBasic(Action<PaycheckSearchRowBasic> initializer)
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

        ISearchAdvancedRow<PaycheckSearchRowBasic> 
            ISearchAdvancedRow<PaycheckSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PaycheckSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.employeeJoin;
      //      yield return this.payrollItemJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(PaycheckSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PaycheckSearchRowBasic();
                    break;


                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "payrollItemJoin":
                    result = target.payrollItemJoin;
                    creator = () => target.payrollItemJoin = new PayrollItemSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("PaycheckSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}