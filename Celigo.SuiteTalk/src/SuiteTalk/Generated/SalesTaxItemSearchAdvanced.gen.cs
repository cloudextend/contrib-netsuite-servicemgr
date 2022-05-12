
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class SalesTaxItemSearchAdvanced: ISearchAdvanced, ISearchAdvanced<SalesTaxItemSearch, SalesTaxItemSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public SalesTaxItemSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public SalesTaxItemSearch CreateCriteria()
        {
            this.criteria = new SalesTaxItemSearch();
            return this.criteria;
        }

        ISearchAdvanced<SalesTaxItemSearch, SalesTaxItemSearchRow> 
            ISearchAdvanced<SalesTaxItemSearch, SalesTaxItemSearchRow>.CreateCriteria(Action<SalesTaxItemSearch> initializer) => this.CreateCriteria(initializer);

        public SalesTaxItemSearchAdvanced CreateCriteria(Action<SalesTaxItemSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public SalesTaxItemSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public SalesTaxItemSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new SalesTaxItemSearchRow();
            return this.columns;
        }

        ISearchAdvanced<SalesTaxItemSearch, SalesTaxItemSearchRow> 
            ISearchAdvanced<SalesTaxItemSearch, SalesTaxItemSearchRow>.CreateColumns(Action<SalesTaxItemSearchRow> initializer) => this.CreateColumns(initializer);

        public SalesTaxItemSearchAdvanced CreateColumns(Action<SalesTaxItemSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}