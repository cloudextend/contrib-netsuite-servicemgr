// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class RevRecScheduleSearchAdvanced: ISearchAdvanced, ISearchAdvanced<RevRecScheduleSearch, RevRecScheduleSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public RevRecScheduleSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public RevRecScheduleSearch CreateCriteria()
        {
            this.criteria = new RevRecScheduleSearch();
            return this.criteria;
        }

        ISearchAdvanced<RevRecScheduleSearch, RevRecScheduleSearchRow> 
            ISearchAdvanced<RevRecScheduleSearch, RevRecScheduleSearchRow>.CreateCriteria(Action<RevRecScheduleSearch> initializer) => this.CreateCriteria(initializer);

        public RevRecScheduleSearchAdvanced CreateCriteria(Action<RevRecScheduleSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public RevRecScheduleSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public RevRecScheduleSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new RevRecScheduleSearchRow();
            return this.columns;
        }

        ISearchAdvanced<RevRecScheduleSearch, RevRecScheduleSearchRow> 
            ISearchAdvanced<RevRecScheduleSearch, RevRecScheduleSearchRow>.CreateColumns(Action<RevRecScheduleSearchRow> initializer) => this.CreateColumns(initializer);

        public RevRecScheduleSearchAdvanced CreateColumns(Action<RevRecScheduleSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}