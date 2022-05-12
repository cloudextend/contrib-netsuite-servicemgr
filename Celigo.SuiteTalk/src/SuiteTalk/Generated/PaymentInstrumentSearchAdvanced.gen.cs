
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PaymentInstrumentSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PaymentInstrumentSearch, PaymentInstrumentSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PaymentInstrumentSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PaymentInstrumentSearch CreateCriteria()
        {
            this.criteria = new PaymentInstrumentSearch();
            return this.criteria;
        }

        ISearchAdvanced<PaymentInstrumentSearch, PaymentInstrumentSearchRow> 
            ISearchAdvanced<PaymentInstrumentSearch, PaymentInstrumentSearchRow>.CreateCriteria(Action<PaymentInstrumentSearch> initializer) => this.CreateCriteria(initializer);

        public PaymentInstrumentSearchAdvanced CreateCriteria(Action<PaymentInstrumentSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PaymentInstrumentSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PaymentInstrumentSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PaymentInstrumentSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PaymentInstrumentSearch, PaymentInstrumentSearchRow> 
            ISearchAdvanced<PaymentInstrumentSearch, PaymentInstrumentSearchRow>.CreateColumns(Action<PaymentInstrumentSearchRow> initializer) => this.CreateColumns(initializer);

        public PaymentInstrumentSearchAdvanced CreateColumns(Action<PaymentInstrumentSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}