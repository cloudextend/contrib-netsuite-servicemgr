
// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class TaxTypeSearchRow: ISearchRow, ISearchRow<TaxTypeSearchRowBasic>
    {
        public TaxTypeSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public TaxTypeSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new TaxTypeSearchRowBasic();
            return this.basic;
        }

        ISearchRow<TaxTypeSearchRowBasic> 
            ISearchRow<TaxTypeSearchRowBasic>.CreateBasic(Action<TaxTypeSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public TaxTypeSearchRow CreateBasic(Action<TaxTypeSearchRowBasic> initializer)
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

        ISearchRow<TaxTypeSearchRowBasic> 
            ISearchRow<TaxTypeSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public TaxTypeSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
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

        private static SearchRowBasic GetOrCreateJoin(TaxTypeSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new TaxTypeSearchRowBasic();
                    break;


                case "userJoin":
                    result = target.userJoin;
                    creator = () => target.userJoin = new EmployeeSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("TaxTypeSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}