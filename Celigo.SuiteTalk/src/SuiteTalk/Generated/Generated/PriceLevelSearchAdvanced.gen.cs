// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PriceLevelSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PriceLevelSearch, PriceLevelSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PriceLevelSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PriceLevelSearch CreateCriteria()
        {
            this.criteria = new PriceLevelSearch();
            return this.criteria;
        }

        ISearchAdvanced<PriceLevelSearch, PriceLevelSearchRow> 
            ISearchAdvanced<PriceLevelSearch, PriceLevelSearchRow>.CreateCriteria(Action<PriceLevelSearch> initializer) => this.CreateCriteria(initializer);

        public PriceLevelSearchAdvanced CreateCriteria(Action<PriceLevelSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PriceLevelSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PriceLevelSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PriceLevelSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PriceLevelSearch, PriceLevelSearchRow> 
            ISearchAdvanced<PriceLevelSearch, PriceLevelSearchRow>.CreateColumns(Action<PriceLevelSearchRow> initializer) => this.CreateColumns(initializer);

        public PriceLevelSearchAdvanced CreateColumns(Action<PriceLevelSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}