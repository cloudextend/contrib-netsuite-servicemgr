
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class RevRecTemplateSearchAdvanced: ISearchAdvanced, ISearchAdvanced<RevRecTemplateSearch, RevRecTemplateSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public RevRecTemplateSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public RevRecTemplateSearch CreateCriteria()
        {
            this.criteria = new RevRecTemplateSearch();
            return this.criteria;
        }

        ISearchAdvanced<RevRecTemplateSearch, RevRecTemplateSearchRow> 
            ISearchAdvanced<RevRecTemplateSearch, RevRecTemplateSearchRow>.CreateCriteria(Action<RevRecTemplateSearch> initializer) => this.CreateCriteria(initializer);

        public RevRecTemplateSearchAdvanced CreateCriteria(Action<RevRecTemplateSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public RevRecTemplateSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public RevRecTemplateSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new RevRecTemplateSearchRow();
            return this.columns;
        }

        ISearchAdvanced<RevRecTemplateSearch, RevRecTemplateSearchRow> 
            ISearchAdvanced<RevRecTemplateSearch, RevRecTemplateSearchRow>.CreateColumns(Action<RevRecTemplateSearchRow> initializer) => this.CreateColumns(initializer);

        public RevRecTemplateSearchAdvanced CreateColumns(Action<RevRecTemplateSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}