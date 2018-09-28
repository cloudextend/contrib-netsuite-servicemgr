// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class SiteCategorySearchAdvanced: ISearchAdvanced, ISearchAdvanced<SiteCategorySearch, SiteCategorySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public SiteCategorySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public SiteCategorySearch CreateCriteria()
        {
            this.criteria = new SiteCategorySearch();
            return this.criteria;
        }

        ISearchAdvanced<SiteCategorySearch, SiteCategorySearchRow> 
            ISearchAdvanced<SiteCategorySearch, SiteCategorySearchRow>.CreateCriteria(Action<SiteCategorySearch> initializer) => this.CreateCriteria(initializer);

        public SiteCategorySearchAdvanced CreateCriteria(Action<SiteCategorySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public SiteCategorySearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public SiteCategorySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new SiteCategorySearchRow();
            return this.columns;
        }

        ISearchAdvanced<SiteCategorySearch, SiteCategorySearchRow> 
            ISearchAdvanced<SiteCategorySearch, SiteCategorySearchRow>.CreateColumns(Action<SiteCategorySearchRow> initializer) => this.CreateColumns(initializer);

        public SiteCategorySearchAdvanced CreateColumns(Action<SiteCategorySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}