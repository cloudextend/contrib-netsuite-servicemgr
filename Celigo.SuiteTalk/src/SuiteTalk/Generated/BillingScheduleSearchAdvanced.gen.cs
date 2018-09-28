// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class BillingScheduleSearchAdvanced: ISearchAdvanced, ISearchAdvanced<BillingScheduleSearch, BillingScheduleSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public BillingScheduleSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public BillingScheduleSearch CreateCriteria()
        {
            this.criteria = new BillingScheduleSearch();
            return this.criteria;
        }

        ISearchAdvanced<BillingScheduleSearch, BillingScheduleSearchRow> 
            ISearchAdvanced<BillingScheduleSearch, BillingScheduleSearchRow>.CreateCriteria(Action<BillingScheduleSearch> initializer) => this.CreateCriteria(initializer);

        public BillingScheduleSearchAdvanced CreateCriteria(Action<BillingScheduleSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public BillingScheduleSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public BillingScheduleSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new BillingScheduleSearchRow();
            return this.columns;
        }

        ISearchAdvanced<BillingScheduleSearch, BillingScheduleSearchRow> 
            ISearchAdvanced<BillingScheduleSearch, BillingScheduleSearchRow>.CreateColumns(Action<BillingScheduleSearchRow> initializer) => this.CreateColumns(initializer);

        public BillingScheduleSearchAdvanced CreateColumns(Action<BillingScheduleSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}