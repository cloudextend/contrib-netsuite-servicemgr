// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TermSearchAdvanced: ISearchAdvanced, ISearchAdvanced<TermSearch, TermSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TermSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TermSearch CreateCriteria()
        {
            this.criteria = new TermSearch();
            return this.criteria;
        }

        ISearchAdvanced<TermSearch, TermSearchRow> 
            ISearchAdvanced<TermSearch, TermSearchRow>.CreateCriteria(Action<TermSearch> initializer) => this.CreateCriteria(initializer);

        public TermSearchAdvanced CreateCriteria(Action<TermSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TermSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TermSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TermSearchRow();
            return this.columns;
        }

        ISearchAdvanced<TermSearch, TermSearchRow> 
            ISearchAdvanced<TermSearch, TermSearchRow>.CreateColumns(Action<TermSearchRow> initializer) => this.CreateColumns(initializer);

        public TermSearchAdvanced CreateColumns(Action<TermSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}