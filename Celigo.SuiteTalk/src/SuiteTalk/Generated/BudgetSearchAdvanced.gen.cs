
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class BudgetSearchAdvanced: ISearchAdvanced, ISearchAdvanced<BudgetSearch, BudgetSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public BudgetSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public BudgetSearch CreateCriteria()
        {
            this.criteria = new BudgetSearch();
            return this.criteria;
        }

        ISearchAdvanced<BudgetSearch, BudgetSearchRow> 
            ISearchAdvanced<BudgetSearch, BudgetSearchRow>.CreateCriteria(Action<BudgetSearch> initializer) => this.CreateCriteria(initializer);

        public BudgetSearchAdvanced CreateCriteria(Action<BudgetSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public BudgetSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public BudgetSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new BudgetSearchRow();
            return this.columns;
        }

        ISearchAdvanced<BudgetSearch, BudgetSearchRow> 
            ISearchAdvanced<BudgetSearch, BudgetSearchRow>.CreateColumns(Action<BudgetSearchRow> initializer) => this.CreateColumns(initializer);

        public BudgetSearchAdvanced CreateColumns(Action<BudgetSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}