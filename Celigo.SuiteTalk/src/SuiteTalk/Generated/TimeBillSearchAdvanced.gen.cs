
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TimeBillSearchAdvanced: ISearchAdvanced, ISearchAdvanced<TimeBillSearch, TimeBillSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TimeBillSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TimeBillSearch CreateCriteria()
        {
            this.criteria = new TimeBillSearch();
            return this.criteria;
        }

        ISearchAdvanced<TimeBillSearch, TimeBillSearchRow> 
            ISearchAdvanced<TimeBillSearch, TimeBillSearchRow>.CreateCriteria(Action<TimeBillSearch> initializer) => this.CreateCriteria(initializer);

        public TimeBillSearchAdvanced CreateCriteria(Action<TimeBillSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TimeBillSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TimeBillSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TimeBillSearchRow();
            return this.columns;
        }

        ISearchAdvanced<TimeBillSearch, TimeBillSearchRow> 
            ISearchAdvanced<TimeBillSearch, TimeBillSearchRow>.CreateColumns(Action<TimeBillSearchRow> initializer) => this.CreateColumns(initializer);

        public TimeBillSearchAdvanced CreateColumns(Action<TimeBillSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}