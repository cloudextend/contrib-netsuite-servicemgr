// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ExpenseCategorySearchAdvanced: ISearchAdvanced, ISearchAdvanced<ExpenseCategorySearch, ExpenseCategorySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ExpenseCategorySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ExpenseCategorySearch CreateCriteria()
        {
            this.criteria = new ExpenseCategorySearch();
            return this.criteria;
        }

        ISearchAdvanced<ExpenseCategorySearch, ExpenseCategorySearchRow> 
            ISearchAdvanced<ExpenseCategorySearch, ExpenseCategorySearchRow>.CreateCriteria(Action<ExpenseCategorySearch> initializer) => this.CreateCriteria(initializer);

        public ExpenseCategorySearchAdvanced CreateCriteria(Action<ExpenseCategorySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ExpenseCategorySearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ExpenseCategorySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ExpenseCategorySearchRow();
            return this.columns;
        }

        ISearchAdvanced<ExpenseCategorySearch, ExpenseCategorySearchRow> 
            ISearchAdvanced<ExpenseCategorySearch, ExpenseCategorySearchRow>.CreateColumns(Action<ExpenseCategorySearchRow> initializer) => this.CreateColumns(initializer);

        public ExpenseCategorySearchAdvanced CreateColumns(Action<ExpenseCategorySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}