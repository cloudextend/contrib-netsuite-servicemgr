
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TimeEntrySearchAdvanced: ISearchAdvanced, ISearchAdvanced<TimeEntrySearch, TimeEntrySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TimeEntrySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TimeEntrySearch CreateCriteria()
        {
            this.criteria = new TimeEntrySearch();
            return this.criteria;
        }

        ISearchAdvanced<TimeEntrySearch, TimeEntrySearchRow> 
            ISearchAdvanced<TimeEntrySearch, TimeEntrySearchRow>.CreateCriteria(Action<TimeEntrySearch> initializer) => this.CreateCriteria(initializer);

        public TimeEntrySearchAdvanced CreateCriteria(Action<TimeEntrySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TimeEntrySearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TimeEntrySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TimeEntrySearchRow();
            return this.columns;
        }

        ISearchAdvanced<TimeEntrySearch, TimeEntrySearchRow> 
            ISearchAdvanced<TimeEntrySearch, TimeEntrySearchRow>.CreateColumns(Action<TimeEntrySearchRow> initializer) => this.CreateColumns(initializer);

        public TimeEntrySearchAdvanced CreateColumns(Action<TimeEntrySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}