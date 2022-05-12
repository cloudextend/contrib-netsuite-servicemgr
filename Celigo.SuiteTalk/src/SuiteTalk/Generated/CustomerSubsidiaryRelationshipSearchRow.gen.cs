
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class CustomerSubsidiaryRelationshipSearchRow: ISearchRow, ISearchRow<CustomerSubsidiaryRelationshipSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public CustomerSubsidiaryRelationshipSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public CustomerSubsidiaryRelationshipSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new CustomerSubsidiaryRelationshipSearchRowBasic();
            return this.basic;
        }

        ISearchRow<CustomerSubsidiaryRelationshipSearchRowBasic> 
            ISearchRow<CustomerSubsidiaryRelationshipSearchRowBasic>.CreateBasic(Action<CustomerSubsidiaryRelationshipSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public CustomerSubsidiaryRelationshipSearchRow CreateBasic(Action<CustomerSubsidiaryRelationshipSearchRowBasic> initializer)
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

        ISearchRow<CustomerSubsidiaryRelationshipSearchRowBasic> 
            ISearchRow<CustomerSubsidiaryRelationshipSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public CustomerSubsidiaryRelationshipSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.customerJoin;
      //      yield return this.subsidiaryJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(CustomerSubsidiaryRelationshipSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new CustomerSubsidiaryRelationshipSearchRowBasic();
                    break;


                case "customerJoin":
                    result = target.customerJoin;
                    creator = () => target.customerJoin = new CustomerSearchRowBasic();
                    break;
        
                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("CustomerSubsidiaryRelationshipSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}