// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CostCategorySearchAdvanced: ISearchAdvanced, ISearchAdvanced<CostCategorySearch, CostCategorySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CostCategorySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CostCategorySearch CreateCriteria()
        {
            this.criteria = new CostCategorySearch();
            return this.criteria;
        }

        ISearchAdvanced<CostCategorySearch, CostCategorySearchRow> 
            ISearchAdvanced<CostCategorySearch, CostCategorySearchRow>.CreateCriteria(Action<CostCategorySearch> initializer) => this.CreateCriteria(initializer);

        public CostCategorySearchAdvanced CreateCriteria(Action<CostCategorySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CostCategorySearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CostCategorySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CostCategorySearchRow();
            return this.columns;
        }

        ISearchAdvanced<CostCategorySearch, CostCategorySearchRow> 
            ISearchAdvanced<CostCategorySearch, CostCategorySearchRow>.CreateColumns(Action<CostCategorySearchRow> initializer) => this.CreateColumns(initializer);

        public CostCategorySearchAdvanced CreateColumns(Action<CostCategorySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}