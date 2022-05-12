
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TimeSheetSearchAdvanced: ISearchAdvanced, ISearchAdvanced<TimeSheetSearch, TimeSheetSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TimeSheetSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TimeSheetSearch CreateCriteria()
        {
            this.criteria = new TimeSheetSearch();
            return this.criteria;
        }

        ISearchAdvanced<TimeSheetSearch, TimeSheetSearchRow> 
            ISearchAdvanced<TimeSheetSearch, TimeSheetSearchRow>.CreateCriteria(Action<TimeSheetSearch> initializer) => this.CreateCriteria(initializer);

        public TimeSheetSearchAdvanced CreateCriteria(Action<TimeSheetSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TimeSheetSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TimeSheetSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TimeSheetSearchRow();
            return this.columns;
        }

        ISearchAdvanced<TimeSheetSearch, TimeSheetSearchRow> 
            ISearchAdvanced<TimeSheetSearch, TimeSheetSearchRow>.CreateColumns(Action<TimeSheetSearchRow> initializer) => this.CreateColumns(initializer);

        public TimeSheetSearchAdvanced CreateColumns(Action<TimeSheetSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}