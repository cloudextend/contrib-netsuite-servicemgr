// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class BillingAccountSearchAdvanced: ISearchAdvanced, ISearchAdvanced<BillingAccountSearch, BillingAccountSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public BillingAccountSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public BillingAccountSearch CreateCriteria()
        {
            this.criteria = new BillingAccountSearch();
            return this.criteria;
        }

        ISearchAdvanced<BillingAccountSearch, BillingAccountSearchRow> 
            ISearchAdvanced<BillingAccountSearch, BillingAccountSearchRow>.CreateCriteria(Action<BillingAccountSearch> initializer) => this.CreateCriteria(initializer);

        public BillingAccountSearchAdvanced CreateCriteria(Action<BillingAccountSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public BillingAccountSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public BillingAccountSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new BillingAccountSearchRow();
            return this.columns;
        }

        ISearchAdvanced<BillingAccountSearch, BillingAccountSearchRow> 
            ISearchAdvanced<BillingAccountSearch, BillingAccountSearchRow>.CreateColumns(Action<BillingAccountSearchRow> initializer) => this.CreateColumns(initializer);

        public BillingAccountSearchAdvanced CreateColumns(Action<BillingAccountSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}