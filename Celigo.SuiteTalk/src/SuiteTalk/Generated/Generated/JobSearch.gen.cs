// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class JobSearch: ISearch, ISearch<JobSearchBasic>
    {
        public JobSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public JobSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new JobSearchBasic();
            return this.basic;
        }

        ISearch<JobSearchBasic> 
            ISearch<JobSearchBasic>.CreateBasic(Action<JobSearchBasic> initializer) => this.CreateBasic(initializer);

        public JobSearch CreateBasic(Action<JobSearchBasic> initializer)
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

        ISearch<JobSearchBasic> 
            ISearch<JobSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public JobSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(JobSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new JobSearchBasic();
                    break;

                case "billingAccountJoin":
                    result = target.billingAccountJoin;
                    creator = () => target.billingAccountJoin = new BillingAccountSearchBasic();
                    break;
        
                case "billingScheduleJoin":
                    result = target.billingScheduleJoin;
                    creator = () => target.billingScheduleJoin = new BillingScheduleSearchBasic();
                    break;
        
                case "contactPrimaryJoin":
                    result = target.contactPrimaryJoin;
                    creator = () => target.contactPrimaryJoin = new ContactSearchBasic();
                    break;
        
                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchBasic();
                    break;
        
                case "projectTaskJoin":
                    result = target.projectTaskJoin;
                    creator = () => target.projectTaskJoin = new ProjectTaskSearchBasic();
                    break;
        
                case "resourceAllocationJoin":
                    result = target.resourceAllocationJoin;
                    creator = () => target.resourceAllocationJoin = new ResourceAllocationSearchBasic();
                    break;
        
                case "taskJoin":
                    result = target.taskJoin;
                    creator = () => target.taskJoin = new TaskSearchBasic();
                    break;
        
                case "timeJoin":
                    result = target.timeJoin;
                    creator = () => target.timeJoin = new TimeBillSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("JobSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}