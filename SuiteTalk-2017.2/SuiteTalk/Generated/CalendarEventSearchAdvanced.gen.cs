// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CalendarEventSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CalendarEventSearch, CalendarEventSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CalendarEventSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CalendarEventSearch CreateCriteria()
        {
            this.criteria = new CalendarEventSearch();
            return this.criteria;
        }

        ISearchAdvanced<CalendarEventSearch, CalendarEventSearchRow> 
            ISearchAdvanced<CalendarEventSearch, CalendarEventSearchRow>.CreateCriteria(Action<CalendarEventSearch> initializer) => this.CreateCriteria(initializer);

        public CalendarEventSearchAdvanced CreateCriteria(Action<CalendarEventSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CalendarEventSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CalendarEventSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CalendarEventSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CalendarEventSearch, CalendarEventSearchRow> 
            ISearchAdvanced<CalendarEventSearch, CalendarEventSearchRow>.CreateColumns(Action<CalendarEventSearchRow> initializer) => this.CreateColumns(initializer);

        public CalendarEventSearchAdvanced CreateColumns(Action<CalendarEventSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}