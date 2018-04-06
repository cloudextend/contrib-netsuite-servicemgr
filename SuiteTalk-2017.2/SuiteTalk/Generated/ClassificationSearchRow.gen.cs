// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;

namespace SuiteTalk
{
    public partial class ClassificationSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<ClassificationSearchRowBasic>, SupportsCustomSearchJoin
    {
        public ClassificationSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public ClassificationSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new ClassificationSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<ClassificationSearchRowBasic> 
            ISearchAdvancedRow<ClassificationSearchRowBasic>.CreateBasic(Action<ClassificationSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public ClassificationSearchRow CreateBasic(Action<ClassificationSearchRowBasic> initializer)
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

        ISearchAdvancedRow<ClassificationSearchRowBasic> 
            ISearchAdvancedRow<ClassificationSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public ClassificationSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(ClassificationSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new ClassificationSearchRowBasic();
                    break;

                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("ClassificationSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}