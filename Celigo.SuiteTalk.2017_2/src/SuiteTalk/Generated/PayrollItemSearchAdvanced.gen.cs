// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PayrollItemSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PayrollItemSearch, PayrollItemSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PayrollItemSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PayrollItemSearch CreateCriteria()
        {
            this.criteria = new PayrollItemSearch();
            return this.criteria;
        }

        ISearchAdvanced<PayrollItemSearch, PayrollItemSearchRow> 
            ISearchAdvanced<PayrollItemSearch, PayrollItemSearchRow>.CreateCriteria(Action<PayrollItemSearch> initializer) => this.CreateCriteria(initializer);

        public PayrollItemSearchAdvanced CreateCriteria(Action<PayrollItemSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PayrollItemSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PayrollItemSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PayrollItemSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PayrollItemSearch, PayrollItemSearchRow> 
            ISearchAdvanced<PayrollItemSearch, PayrollItemSearchRow>.CreateColumns(Action<PayrollItemSearchRow> initializer) => this.CreateColumns(initializer);

        public PayrollItemSearchAdvanced CreateColumns(Action<PayrollItemSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}