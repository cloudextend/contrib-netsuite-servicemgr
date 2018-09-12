// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TaxTypeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<TaxTypeSearch, TaxTypeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TaxTypeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TaxTypeSearch CreateCriteria()
        {
            this.criteria = new TaxTypeSearch();
            return this.criteria;
        }

        ISearchAdvanced<TaxTypeSearch, TaxTypeSearchRow> 
            ISearchAdvanced<TaxTypeSearch, TaxTypeSearchRow>.CreateCriteria(Action<TaxTypeSearch> initializer) => this.CreateCriteria(initializer);

        public TaxTypeSearchAdvanced CreateCriteria(Action<TaxTypeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TaxTypeSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TaxTypeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TaxTypeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<TaxTypeSearch, TaxTypeSearchRow> 
            ISearchAdvanced<TaxTypeSearch, TaxTypeSearchRow>.CreateColumns(Action<TaxTypeSearchRow> initializer) => this.CreateColumns(initializer);

        public TaxTypeSearchAdvanced CreateColumns(Action<TaxTypeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}