// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class ItemAccountMappingSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<ItemAccountMappingSearchRowBasic>, SupportsCustomSearchJoin
    {
        public ItemAccountMappingSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public ItemAccountMappingSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ItemAccountMappingSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<ItemAccountMappingSearchRowBasic> 
            ISearchAdvancedRow<ItemAccountMappingSearchRowBasic>.CreateBasic(Action<ItemAccountMappingSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ItemAccountMappingSearchRow CreateBasic(Action<ItemAccountMappingSearchRowBasic> initializer)
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

        ISearchAdvancedRow<ItemAccountMappingSearchRowBasic> 
            ISearchAdvancedRow<ItemAccountMappingSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ItemAccountMappingSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.classJoin;
      //      yield return this.departmentJoin;
      //      yield return this.destinationAccountJoin;
      //      yield return this.locationJoin;
      //      yield return this.sourceAccountJoin;
      //      yield return this.subsidiaryJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(ItemAccountMappingSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ItemAccountMappingSearchRowBasic();
                    break;


                case "classJoin":
                    result = target.classJoin;
                    creator = () => target.classJoin = new ClassificationSearchRowBasic();
                    break;
        
                case "departmentJoin":
                    result = target.departmentJoin;
                    creator = () => target.departmentJoin = new DepartmentSearchRowBasic();
                    break;
        
                case "destinationAccountJoin":
                    result = target.destinationAccountJoin;
                    creator = () => target.destinationAccountJoin = new AccountSearchRowBasic();
                    break;
        
                case "locationJoin":
                    result = target.locationJoin;
                    creator = () => target.locationJoin = new LocationSearchRowBasic();
                    break;
        
                case "sourceAccountJoin":
                    result = target.sourceAccountJoin;
                    creator = () => target.sourceAccountJoin = new AccountSearchRowBasic();
                    break;
        
                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ItemAccountMappingSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}