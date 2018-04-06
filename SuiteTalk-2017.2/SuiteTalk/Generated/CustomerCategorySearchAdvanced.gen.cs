// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CustomerCategorySearchAdvanced: ISearchAdvanced, ISearchAdvanced<CustomerCategorySearch, CustomerCategorySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CustomerCategorySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CustomerCategorySearch CreateCriteria()
        {
            this.criteria = new CustomerCategorySearch();
            return this.criteria;
        }

        ISearchAdvanced<CustomerCategorySearch, CustomerCategorySearchRow> 
            ISearchAdvanced<CustomerCategorySearch, CustomerCategorySearchRow>.CreateCriteria(Action<CustomerCategorySearch> initializer) => this.CreateCriteria(initializer);

        public CustomerCategorySearchAdvanced CreateCriteria(Action<CustomerCategorySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CustomerCategorySearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CustomerCategorySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CustomerCategorySearchRow();
            return this.columns;
        }

        ISearchAdvanced<CustomerCategorySearch, CustomerCategorySearchRow> 
            ISearchAdvanced<CustomerCategorySearch, CustomerCategorySearchRow>.CreateColumns(Action<CustomerCategorySearchRow> initializer) => this.CreateColumns(initializer);

        public CustomerCategorySearchAdvanced CreateColumns(Action<CustomerCategorySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}