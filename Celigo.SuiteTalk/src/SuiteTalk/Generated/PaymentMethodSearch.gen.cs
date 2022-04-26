
// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class PaymentMethodSearch: ISearch, ISearch<PaymentMethodSearchBasic>
    {
        public PaymentMethodSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public PaymentMethodSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PaymentMethodSearchBasic();
            return this.basic;
        }

        ISearch<PaymentMethodSearchBasic> 
            ISearch<PaymentMethodSearchBasic>.CreateBasic(Action<PaymentMethodSearchBasic> initializer) => this.CreateBasic(initializer);

        public PaymentMethodSearch CreateBasic(Action<PaymentMethodSearchBasic> initializer)
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

        ISearch<PaymentMethodSearchBasic> 
            ISearch<PaymentMethodSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PaymentMethodSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(PaymentMethodSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PaymentMethodSearchBasic();
                    break;

                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("PaymentMethodSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}