// Generator { Name = "SearchRowGenerator", Template = "ISearchRow" }

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class PriceLevelSearchRow: ISearchAdvancedRow, ISearchAdvancedRow<PriceLevelSearchRowBasic>
    {
        public PriceLevelSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchAdvancedRow.GetBasic() => this.basic;

        public PriceLevelSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new PriceLevelSearchRowBasic();
            return this.basic;
        }

        ISearchAdvancedRow<PriceLevelSearchRowBasic> 
            ISearchAdvancedRow<PriceLevelSearchRowBasic>.CreateBasic(Action<PriceLevelSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public PriceLevelSearchRow CreateBasic(Action<PriceLevelSearchRowBasic> initializer)
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

        ISearchAdvancedRow<PriceLevelSearchRowBasic> 
            ISearchAdvancedRow<PriceLevelSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public PriceLevelSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.userJoin;
        //}

        private static SearchRowBasic GetOrCreateJoin(PriceLevelSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new PriceLevelSearchRowBasic();
                    break;


                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("PriceLevelSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}