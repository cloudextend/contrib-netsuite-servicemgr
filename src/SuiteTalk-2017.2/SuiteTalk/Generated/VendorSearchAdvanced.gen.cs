// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class VendorSearchAdvanced: ISearchAdvanced, ISearchAdvanced<VendorSearch, VendorSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public VendorSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public VendorSearch CreateCriteria()
        {
            this.criteria = new VendorSearch();
            return this.criteria;
        }

        ISearchAdvanced<VendorSearch, VendorSearchRow> 
            ISearchAdvanced<VendorSearch, VendorSearchRow>.CreateCriteria(Action<VendorSearch> initializer) => this.CreateCriteria(initializer);

        public VendorSearchAdvanced CreateCriteria(Action<VendorSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public VendorSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public VendorSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new VendorSearchRow();
            return this.columns;
        }

        ISearchAdvanced<VendorSearch, VendorSearchRow> 
            ISearchAdvanced<VendorSearch, VendorSearchRow>.CreateColumns(Action<VendorSearchRow> initializer) => this.CreateColumns(initializer);

        public VendorSearchAdvanced CreateColumns(Action<VendorSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}