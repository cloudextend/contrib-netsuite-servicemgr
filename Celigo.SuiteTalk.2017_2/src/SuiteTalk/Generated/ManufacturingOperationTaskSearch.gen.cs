// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class ManufacturingOperationTaskSearch: ISearch, ISearch<ManufacturingOperationTaskSearchBasic>
    {
        public ManufacturingOperationTaskSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public ManufacturingOperationTaskSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ManufacturingOperationTaskSearchBasic();
            return this.basic;
        }

        ISearch<ManufacturingOperationTaskSearchBasic> 
            ISearch<ManufacturingOperationTaskSearchBasic>.CreateBasic(Action<ManufacturingOperationTaskSearchBasic> initializer) => this.CreateBasic(initializer);

        public ManufacturingOperationTaskSearch CreateBasic(Action<ManufacturingOperationTaskSearchBasic> initializer)
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

        ISearch<ManufacturingOperationTaskSearchBasic> 
            ISearch<ManufacturingOperationTaskSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ManufacturingOperationTaskSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(ManufacturingOperationTaskSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ManufacturingOperationTaskSearchBasic();
                    break;

                case "predecessorJoin":
                    result = target.predecessorJoin;
                    creator = () => target.predecessorJoin = new ManufacturingOperationTaskSearchBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchBasic();
                    break;
        
                case "workOrderJoin":
                    result = target.workOrderJoin;
                    creator = () => target.workOrderJoin = new TransactionSearchBasic();
                    break;
                        default:
                    throw new ArgumentException("ManufacturingOperationTaskSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}