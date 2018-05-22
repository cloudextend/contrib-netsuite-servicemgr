// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class VendorCategorySearchAdvanced: ISearchAdvanced, ISearchAdvanced<VendorCategorySearch, VendorCategorySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public VendorCategorySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public VendorCategorySearch CreateCriteria()
        {
            this.criteria = new VendorCategorySearch();
            return this.criteria;
        }

        ISearchAdvanced<VendorCategorySearch, VendorCategorySearchRow> 
            ISearchAdvanced<VendorCategorySearch, VendorCategorySearchRow>.CreateCriteria(Action<VendorCategorySearch> initializer) => this.CreateCriteria(initializer);

        public VendorCategorySearchAdvanced CreateCriteria(Action<VendorCategorySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public VendorCategorySearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public VendorCategorySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new VendorCategorySearchRow();
            return this.columns;
        }

        ISearchAdvanced<VendorCategorySearch, VendorCategorySearchRow> 
            ISearchAdvanced<VendorCategorySearch, VendorCategorySearchRow>.CreateColumns(Action<VendorCategorySearchRow> initializer) => this.CreateColumns(initializer);

        public VendorCategorySearchAdvanced CreateColumns(Action<VendorCategorySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}