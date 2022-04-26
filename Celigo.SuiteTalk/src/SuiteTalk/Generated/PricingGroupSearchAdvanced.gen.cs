
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PricingGroupSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PricingGroupSearch, PricingGroupSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PricingGroupSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PricingGroupSearch CreateCriteria()
        {
            this.criteria = new PricingGroupSearch();
            return this.criteria;
        }

        ISearchAdvanced<PricingGroupSearch, PricingGroupSearchRow> 
            ISearchAdvanced<PricingGroupSearch, PricingGroupSearchRow>.CreateCriteria(Action<PricingGroupSearch> initializer) => this.CreateCriteria(initializer);

        public PricingGroupSearchAdvanced CreateCriteria(Action<PricingGroupSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PricingGroupSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PricingGroupSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PricingGroupSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PricingGroupSearch, PricingGroupSearchRow> 
            ISearchAdvanced<PricingGroupSearch, PricingGroupSearchRow>.CreateColumns(Action<PricingGroupSearchRow> initializer) => this.CreateColumns(initializer);

        public PricingGroupSearchAdvanced CreateColumns(Action<PricingGroupSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}