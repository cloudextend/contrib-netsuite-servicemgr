// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class OpportunitySearchAdvanced: ISearchAdvanced, ISearchAdvanced<OpportunitySearch, OpportunitySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public OpportunitySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public OpportunitySearch CreateCriteria()
        {
            this.criteria = new OpportunitySearch();
            return this.criteria;
        }

        ISearchAdvanced<OpportunitySearch, OpportunitySearchRow> 
            ISearchAdvanced<OpportunitySearch, OpportunitySearchRow>.CreateCriteria(Action<OpportunitySearch> initializer) => this.CreateCriteria(initializer);

        public OpportunitySearchAdvanced CreateCriteria(Action<OpportunitySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public OpportunitySearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public OpportunitySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new OpportunitySearchRow();
            return this.columns;
        }

        ISearchAdvanced<OpportunitySearch, OpportunitySearchRow> 
            ISearchAdvanced<OpportunitySearch, OpportunitySearchRow>.CreateColumns(Action<OpportunitySearchRow> initializer) => this.CreateColumns(initializer);

        public OpportunitySearchAdvanced CreateColumns(Action<OpportunitySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}