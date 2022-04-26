
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class NoteTypeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<NoteTypeSearch, NoteTypeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public NoteTypeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public NoteTypeSearch CreateCriteria()
        {
            this.criteria = new NoteTypeSearch();
            return this.criteria;
        }

        ISearchAdvanced<NoteTypeSearch, NoteTypeSearchRow> 
            ISearchAdvanced<NoteTypeSearch, NoteTypeSearchRow>.CreateCriteria(Action<NoteTypeSearch> initializer) => this.CreateCriteria(initializer);

        public NoteTypeSearchAdvanced CreateCriteria(Action<NoteTypeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public NoteTypeSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public NoteTypeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new NoteTypeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<NoteTypeSearch, NoteTypeSearchRow> 
            ISearchAdvanced<NoteTypeSearch, NoteTypeSearchRow>.CreateColumns(Action<NoteTypeSearchRow> initializer) => this.CreateColumns(initializer);

        public NoteTypeSearchAdvanced CreateColumns(Action<NoteTypeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}