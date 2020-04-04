// Generator: SearchStubGenerator
// Template: ISearchRow

using System;
using System.Collections.Generic;

namespace SuiteTalk
{
    public partial class VendorSubsidiaryRelationshipSearchRow: ISearchRow, ISearchRow<VendorSubsidiaryRelationshipSearchRowBasic>, ISupportsCustomSearchJoin
    {
        public VendorSubsidiaryRelationshipSearchRowBasic GetBasic() => this.basic;

        SearchRowBasic ISearchRow.GetBasic() => this.basic;

        public VendorSubsidiaryRelationshipSearchRowBasic CreateBasic()
        {
            if (this.basic == null) this.basic = new VendorSubsidiaryRelationshipSearchRowBasic();
            return this.basic;
        }

        ISearchRow<VendorSubsidiaryRelationshipSearchRowBasic> 
            ISearchRow<VendorSubsidiaryRelationshipSearchRowBasic>.CreateBasic(Action<VendorSubsidiaryRelationshipSearchRowBasic> initializer) => this.CreateBasic(initializer);

        public VendorSubsidiaryRelationshipSearchRow CreateBasic(Action<VendorSubsidiaryRelationshipSearchRowBasic> initializer)
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

        ISearchRow<VendorSubsidiaryRelationshipSearchRowBasic> 
            ISearchRow<VendorSubsidiaryRelationshipSearchRowBasic>.CreateJoin<J>(string joinName, Action<J> initializer) => this.CreateJoin(joinName, initializer);

        public VendorSubsidiaryRelationshipSearchRow CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic
        {
            J join =  this.CreateJoin<J>(joinName);
            initializer(join);
            return this;
        }

        // public IEnumerable<SearchRowBasic> GetJoins()
        // {
        //    yield return this.basic;
      //      yield return this.subsidiaryJoin;
      //      yield return this.vendorJoin;
        //}


          public CustomSearchRowBasic[] GetCustomSearchJoin() => this.customSearchJoin;
  
          public CustomSearchRowBasic[] CreateCustomSearchJoin()
          {
              if (this.customSearchJoin == null) this.customSearchJoin = new CustomSearchRowBasic[0];
              return this.customSearchJoin;
          }
        private static SearchRowBasic GetOrCreateJoin(VendorSubsidiaryRelationshipSearchRow target, string joinName, bool createIfNull = false)
        {
            SearchRowBasic result;
            Func<SearchRowBasic> creator;

            switch (joinName)
            {
                case "basic":
                    result = target.basic;
                    creator = () => target.basic = new VendorSubsidiaryRelationshipSearchRowBasic();
                    break;


                case "subsidiaryJoin":
                    result = target.subsidiaryJoin;
                    creator = () => target.subsidiaryJoin = new SubsidiarySearchRowBasic();
                    break;
        
                case "vendorJoin":
                    result = target.vendorJoin;
                    creator = () => target.vendorJoin = new VendorSearchRowBasic();
                    break;
                        default:
                    throw new ArgumentException("VendorSubsidiaryRelationshipSearchRow does not have a " + joinName);
            }

            if (createIfNull && result == null) result = creator();
            return result;
        }
    }
}