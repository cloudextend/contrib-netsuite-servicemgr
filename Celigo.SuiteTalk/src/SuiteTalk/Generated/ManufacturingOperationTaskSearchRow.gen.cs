
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class ManufacturingOperationTaskSearchRow: ISearchRow, ISearchRow<ManufacturingOperationTaskSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public ManufacturingOperationTaskSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public ManufacturingOperationTaskSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ManufacturingOperationTaskSearchRowBasic();
            return this.basic;
        }

        ISearchRow<ManufacturingOperationTaskSearchRowBasic> 
            ISearchRow<ManufacturingOperationTaskSearchRowBasic>.CreateBasic(Action<ManufacturingOperationTaskSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ManufacturingOperationTaskSearchRow CreateBasic(Action<ManufacturingOperationTaskSearchRowBasic> initializer)
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

        ISearchRow<ManufacturingOperationTaskSearchRowBasic> 
            ISearchRow<ManufacturingOperationTaskSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ManufacturingOperationTaskSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.predecessorJoin;
      //      yield return this.userJoin;
      //      yield return this.workOrderJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(ManufacturingOperationTaskSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ManufacturingOperationTaskSearchRowBasic();
                    break;


                case "predecessorJoin":
                    result = target.predecessorJoin;
                    creator = () => target.predecessorJoin = new ManufacturingOperationTaskSearchRowBasic();
                    break;
        
                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
        
                case "workOrderJoin":
                    result = target.workOrderJoin;
                    creator = () => target.workOrderJoin = new TransactionSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ManufacturingOperationTaskSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}