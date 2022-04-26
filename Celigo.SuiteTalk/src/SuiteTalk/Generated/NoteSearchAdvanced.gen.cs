
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class NoteSearchAdvanced: ISearchAdvanced, ISearchAdvanced<NoteSearch, NoteSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public NoteSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public NoteSearch CreateCriteria()
        {
            this.criteria = new NoteSearch();
            return this.criteria;
        }

        ISearchAdvanced<NoteSearch, NoteSearchRow> 
            ISearchAdvanced<NoteSearch, NoteSearchRow>.CreateCriteria(Action<NoteSearch> initializer) => this.CreateCriteria(initializer);

        public NoteSearchAdvanced CreateCriteria(Action<NoteSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public NoteSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public NoteSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new NoteSearchRow();
            return this.columns;
        }

        ISearchAdvanced<NoteSearch, NoteSearchRow> 
            ISearchAdvanced<NoteSearch, NoteSearchRow>.CreateColumns(Action<NoteSearchRow> initializer) => this.CreateColumns(initializer);

        public NoteSearchAdvanced CreateColumns(Action<NoteSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}