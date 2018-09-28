// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class ResourceAllocationSearchRow: ISearchRow, ISearchRow<ResourceAllocationSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public ResourceAllocationSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public ResourceAllocationSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ResourceAllocationSearchRowBasic();
            return this.basic;
        }

        ISearchRow<ResourceAllocationSearchRowBasic> 
            ISearchRow<ResourceAllocationSearchRowBasic>.CreateBasic(Action<ResourceAllocationSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ResourceAllocationSearchRow CreateBasic(Action<ResourceAllocationSearchRowBasic> initializer)
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

        ISearchRow<ResourceAllocationSearchRowBasic> 
            ISearchRow<ResourceAllocationSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ResourceAllocationSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.customerJoin;
      //      yield return this.employeeJoin;
      //      yield return this.jobJoin;
      //      yield return this.projectTaskJoin;
      //      yield return this.requestedByJoin;
      //      yield return this.resourceJoin;
      //      yield return this.userJoin;
      //      yield return this.vendorJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(ResourceAllocationSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ResourceAllocationSearchRowBasic();
                    break;


                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "employeeJoin":
                    result = target.employeeJoin;
                    creator = () => target.employeeJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "jobJoin":
                    result = target.jobJoin;
                    creator = () => target.jobJoin = new JobSearchRowBasic();
                    break;
        
                case "projectTaskJoin":
                    result = target.projectTaskJoin;
                    creator = () => target.projectTaskJoin = new ProjectTaskSearchRowBasic();
                    break;
        
                case "requestedByJoin":
                    result = target.requestedByJoin;
                    creator = () => target.requestedByJoin = new EntitySearchRowBasic();
                    break;
        
                case "resourceJoin":
                    result = target.resourceJoin;
                    creator = () => target.resourceJoin = new EntitySearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ResourceAllocationSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}