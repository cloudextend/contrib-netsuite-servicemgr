// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class OtherNameCategorySearchAdvanced: ISearchAdvanced, ISearchAdvanced<OtherNameCategorySearch, OtherNameCategorySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public OtherNameCategorySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public OtherNameCategorySearch CreateCriteria()
        {
            this.criteria = new OtherNameCategorySearch();
            return this.criteria;
        }

        ISearchAdvanced<OtherNameCategorySearch, OtherNameCategorySearchRow> 
            ISearchAdvanced<OtherNameCategorySearch, OtherNameCategorySearchRow>.CreateCriteria(Action<OtherNameCategorySearch> initializer) => this.CreateCriteria(initializer);

        public OtherNameCategorySearchAdvanced CreateCriteria(Action<OtherNameCategorySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public OtherNameCategorySearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public OtherNameCategorySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new OtherNameCategorySearchRow();
            return this.columns;
        }

        ISearchAdvanced<OtherNameCategorySearch, OtherNameCategorySearchRow> 
            ISearchAdvanced<OtherNameCategorySearch, OtherNameCategorySearchRow>.CreateColumns(Action<OtherNameCategorySearchRow> initializer) => this.CreateColumns(initializer);

        public OtherNameCategorySearchAdvanced CreateColumns(Action<OtherNameCategorySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}