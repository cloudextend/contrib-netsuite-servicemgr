// Generator { Name = "SearchRecordGenerator", Template = "ISearch" }

using System;

namespace SuiteTalk
{
    public partial class OriginatingLeadSearch: ISearch, ISearch<OriginatingLeadSearchBasic>
    {
        public OriginatingLeadSearchBasic GetBasic() => this.basic;

        SearchRecordBasic ISearch.GetBasic() => this.basic;

        public OriginatingLeadSearchBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new OriginatingLeadSearchBasic();
            return this.basic;
        }

        ISearch<OriginatingLeadSearchBasic> 
            ISearch<OriginatingLeadSearchBasic>.CreateBasic(Action<OriginatingLeadSearchBasic> initializer) => this.CreateBasic(initializer);

        public OriginatingLeadSearch CreateBasic(Action<OriginatingLeadSearchBasic> initializer)
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

        ISearch<OriginatingLeadSearchBasic> 
            ISearch<OriginatingLeadSearchBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public OriginatingLeadSearch CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRecordBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        private static SearchRecordBasic GetOrCreateJoin(OriginatingLeadSearch target, string joinName, bool createIfNull = false)
        {
            SearchRecordBasic result;
            Func<SearchRecordBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new OriginatingLeadSearchBasic();
                    break;
                default:
                    throw new ArgumentException("OriginatingLeadSearch does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}