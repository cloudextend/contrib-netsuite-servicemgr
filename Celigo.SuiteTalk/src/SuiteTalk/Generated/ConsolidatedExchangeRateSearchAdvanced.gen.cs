
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ConsolidatedExchangeRateSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ConsolidatedExchangeRateSearch, ConsolidatedExchangeRateSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ConsolidatedExchangeRateSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ConsolidatedExchangeRateSearch CreateCriteria()
        {
            this.criteria = new ConsolidatedExchangeRateSearch();
            return this.criteria;
        }

        ISearchAdvanced<ConsolidatedExchangeRateSearch, ConsolidatedExchangeRateSearchRow> 
            ISearchAdvanced<ConsolidatedExchangeRateSearch, ConsolidatedExchangeRateSearchRow>.CreateCriteria(Action<ConsolidatedExchangeRateSearch> initializer) => this.CreateCriteria(initializer);

        public ConsolidatedExchangeRateSearchAdvanced CreateCriteria(Action<ConsolidatedExchangeRateSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ConsolidatedExchangeRateSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ConsolidatedExchangeRateSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ConsolidatedExchangeRateSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ConsolidatedExchangeRateSearch, ConsolidatedExchangeRateSearchRow> 
            ISearchAdvanced<ConsolidatedExchangeRateSearch, ConsolidatedExchangeRateSearchRow>.CreateColumns(Action<ConsolidatedExchangeRateSearchRow> initializer) => this.CreateColumns(initializer);

        public ConsolidatedExchangeRateSearchAdvanced CreateColumns(Action<ConsolidatedExchangeRateSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}