// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PaymentMethodSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PaymentMethodSearch, PaymentMethodSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PaymentMethodSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PaymentMethodSearch CreateCriteria()
        {
            this.criteria = new PaymentMethodSearch();
            return this.criteria;
        }

        ISearchAdvanced<PaymentMethodSearch, PaymentMethodSearchRow> 
            ISearchAdvanced<PaymentMethodSearch, PaymentMethodSearchRow>.CreateCriteria(Action<PaymentMethodSearch> initializer) => this.CreateCriteria(initializer);

        public PaymentMethodSearchAdvanced CreateCriteria(Action<PaymentMethodSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PaymentMethodSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PaymentMethodSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PaymentMethodSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PaymentMethodSearch, PaymentMethodSearchRow> 
            ISearchAdvanced<PaymentMethodSearch, PaymentMethodSearchRow>.CreateColumns(Action<PaymentMethodSearchRow> initializer) => this.CreateColumns(initializer);

        public PaymentMethodSearchAdvanced CreateColumns(Action<PaymentMethodSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}