// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PartnerCategorySearchAdvanced: ISearchAdvanced, ISearchAdvanced<PartnerCategorySearch, PartnerCategorySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PartnerCategorySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PartnerCategorySearch CreateCriteria()
        {
            this.criteria = new PartnerCategorySearch();
            return this.criteria;
        }

        ISearchAdvanced<PartnerCategorySearch, PartnerCategorySearchRow> 
            ISearchAdvanced<PartnerCategorySearch, PartnerCategorySearchRow>.CreateCriteria(Action<PartnerCategorySearch> initializer) => this.CreateCriteria(initializer);

        public PartnerCategorySearchAdvanced CreateCriteria(Action<PartnerCategorySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PartnerCategorySearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PartnerCategorySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PartnerCategorySearchRow();
            return this.columns;
        }

        ISearchAdvanced<PartnerCategorySearch, PartnerCategorySearchRow> 
            ISearchAdvanced<PartnerCategorySearch, PartnerCategorySearchRow>.CreateColumns(Action<PartnerCategorySearchRow> initializer) => this.CreateColumns(initializer);

        public PartnerCategorySearchAdvanced CreateColumns(Action<PartnerCategorySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}