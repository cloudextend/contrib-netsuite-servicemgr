// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class FairValuePriceSearchAdvanced: ISearchAdvanced, ISearchAdvanced<FairValuePriceSearch, FairValuePriceSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public FairValuePriceSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public FairValuePriceSearch CreateCriteria()
        {
            this.criteria = new FairValuePriceSearch();
            return this.criteria;
        }

        ISearchAdvanced<FairValuePriceSearch, FairValuePriceSearchRow> 
            ISearchAdvanced<FairValuePriceSearch, FairValuePriceSearchRow>.CreateCriteria(Action<FairValuePriceSearch> initializer) => this.CreateCriteria(initializer);

        public FairValuePriceSearchAdvanced CreateCriteria(Action<FairValuePriceSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public FairValuePriceSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public FairValuePriceSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new FairValuePriceSearchRow();
            return this.columns;
        }

        ISearchAdvanced<FairValuePriceSearch, FairValuePriceSearchRow> 
            ISearchAdvanced<FairValuePriceSearch, FairValuePriceSearchRow>.CreateColumns(Action<FairValuePriceSearchRow> initializer) => this.CreateColumns(initializer);

        public FairValuePriceSearchAdvanced CreateColumns(Action<FairValuePriceSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}