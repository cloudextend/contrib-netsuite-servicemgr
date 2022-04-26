
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PaymentOptionSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PaymentOptionSearch, PaymentOptionSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PaymentOptionSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PaymentOptionSearch CreateCriteria()
        {
            this.criteria = new PaymentOptionSearch();
            return this.criteria;
        }

        ISearchAdvanced<PaymentOptionSearch, PaymentOptionSearchRow> 
            ISearchAdvanced<PaymentOptionSearch, PaymentOptionSearchRow>.CreateCriteria(Action<PaymentOptionSearch> initializer) => this.CreateCriteria(initializer);

        public PaymentOptionSearchAdvanced CreateCriteria(Action<PaymentOptionSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PaymentOptionSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PaymentOptionSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PaymentOptionSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PaymentOptionSearch, PaymentOptionSearchRow> 
            ISearchAdvanced<PaymentOptionSearch, PaymentOptionSearchRow>.CreateColumns(Action<PaymentOptionSearchRow> initializer) => this.CreateColumns(initializer);

        public PaymentOptionSearchAdvanced CreateColumns(Action<PaymentOptionSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}