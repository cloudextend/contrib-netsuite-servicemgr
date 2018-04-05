using System;

namespace SuiteTalk
{
    public partial class PaycheckSearchRow: SearchRow<PaycheckSearchRowBasic>
    {
        public PaycheckSearchRowBasic GetBasic() => this.basic;

        public PaycheckSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PaycheckSearchRowBasic();
            return this.basic;
        }

        public PaycheckSearchRowBasic CreateBasic(Action<PaycheckSearchRowBasic> initializer)
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

        private static SearchRowBasic GetOrCreateJoin(PaycheckSearchRow target, string joinName, bool createIfNull = false)
        {

            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {

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