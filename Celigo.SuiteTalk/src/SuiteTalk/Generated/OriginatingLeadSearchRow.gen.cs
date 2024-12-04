// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class OriginatingLeadSearchRow: ISearchRow, ISearchRow<OriginatingLeadSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public OriginatingLeadSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public OriginatingLeadSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new OriginatingLeadSearchRowBasic();
            return this.basic;
        }

        ISearchRow<OriginatingLeadSearchRowBasic> 
            ISearchRow<OriginatingLeadSearchRowBasic>.CreateBasic(Action<OriginatingLeadSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public OriginatingLeadSearchRow CreateBasic(Action<OriginatingLeadSearchRowBasic> initializer)
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

        ISearchRow<OriginatingLeadSearchRowBasic> 
            ISearchRow<OriginatingLeadSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public OriginatingLeadSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(OriginatingLeadSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new OriginatingLeadSearchRowBasic();
                    break;

                default:
                    throw new ArgumentException("OriginatingLeadSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}