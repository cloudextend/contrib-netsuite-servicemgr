// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CurrencyRateSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CurrencyRateSearch, CurrencyRateSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CurrencyRateSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CurrencyRateSearch CreateCriteria()
        {
            this.criteria = new CurrencyRateSearch();
            return this.criteria;
        }

        ISearchAdvanced<CurrencyRateSearch, CurrencyRateSearchRow> 
            ISearchAdvanced<CurrencyRateSearch, CurrencyRateSearchRow>.CreateCriteria(Action<CurrencyRateSearch> initializer) => this.CreateCriteria(initializer);

        public CurrencyRateSearchAdvanced CreateCriteria(Action<CurrencyRateSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CurrencyRateSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CurrencyRateSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CurrencyRateSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CurrencyRateSearch, CurrencyRateSearchRow> 
            ISearchAdvanced<CurrencyRateSearch, CurrencyRateSearchRow>.CreateColumns(Action<CurrencyRateSearchRow> initializer) => this.CreateColumns(initializer);

        public CurrencyRateSearchAdvanced CreateColumns(Action<CurrencyRateSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}