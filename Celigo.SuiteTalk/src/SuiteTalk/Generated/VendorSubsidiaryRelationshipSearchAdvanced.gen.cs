// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class VendorSubsidiaryRelationshipSearchAdvanced: ISearchAdvanced, ISearchAdvanced<VendorSubsidiaryRelationshipSearch, VendorSubsidiaryRelationshipSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public VendorSubsidiaryRelationshipSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public VendorSubsidiaryRelationshipSearch CreateCriteria()
        {
            this.criteria = new VendorSubsidiaryRelationshipSearch();
            return this.criteria;
        }

        ISearchAdvanced<VendorSubsidiaryRelationshipSearch, VendorSubsidiaryRelationshipSearchRow> 
            ISearchAdvanced<VendorSubsidiaryRelationshipSearch, VendorSubsidiaryRelationshipSearchRow>.CreateCriteria(Action<VendorSubsidiaryRelationshipSearch> initializer) => this.CreateCriteria(initializer);

        public VendorSubsidiaryRelationshipSearchAdvanced CreateCriteria(Action<VendorSubsidiaryRelationshipSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public VendorSubsidiaryRelationshipSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public VendorSubsidiaryRelationshipSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new VendorSubsidiaryRelationshipSearchRow();
            return this.columns;
        }

        ISearchAdvanced<VendorSubsidiaryRelationshipSearch, VendorSubsidiaryRelationshipSearchRow> 
            ISearchAdvanced<VendorSubsidiaryRelationshipSearch, VendorSubsidiaryRelationshipSearchRow>.CreateColumns(Action<VendorSubsidiaryRelationshipSearchRow> initializer) => this.CreateColumns(initializer);

        public VendorSubsidiaryRelationshipSearchAdvanced CreateColumns(Action<VendorSubsidiaryRelationshipSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}