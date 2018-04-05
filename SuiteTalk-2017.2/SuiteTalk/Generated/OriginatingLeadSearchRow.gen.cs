using System;

namespace SuiteTalk
{
    public partial class OriginatingLeadSearchRow: SearchRow<OriginatingLeadSearchRowBasic>, SupportsCustomSearchJoin
    {
        public OriginatingLeadSearchRowBasic GetBasic() => this.basic;

        public OriginatingLeadSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new OriginatingLeadSearchRowBasic();
            return this.basic;
        }

        public OriginatingLeadSearchRowBasic CreateBasic(Action<OriginatingLeadSearchRowBasic> initializer)
        {
            var basic = this.CreateBasic();
            initializer(basic);
            return basic;
        }

        public SearchRowBasic GetJoin(string joinName) => GetOrCreateJoin(this, joinName);

        public J GetJoin<J>(string joinName) where J: SearchRowBasic => (J)this.GetJoin(joinName);

        public SearchRowBasic CreateJoin(string joinName) => GetOrCreateJoin(this, joinName, true);

        public J CreateJoin<J>(string joinName) where J: SearchRowBasic => (J)this.CreateJoin(joinName);

        public J CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return join;
        }


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(OriginatingLeadSearchRow target, string joinName, bool createIfNull = false)
        {
          throw new ArgumentException("OriginatingLeadSearchRow does not support Joins");
        }
    }
}