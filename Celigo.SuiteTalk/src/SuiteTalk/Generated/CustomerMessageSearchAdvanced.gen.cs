
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CustomerMessageSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CustomerMessageSearch, CustomerMessageSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CustomerMessageSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CustomerMessageSearch CreateCriteria()
        {
            this.criteria = new CustomerMessageSearch();
            return this.criteria;
        }

        ISearchAdvanced<CustomerMessageSearch, CustomerMessageSearchRow> 
            ISearchAdvanced<CustomerMessageSearch, CustomerMessageSearchRow>.CreateCriteria(Action<CustomerMessageSearch> initializer) => this.CreateCriteria(initializer);

        public CustomerMessageSearchAdvanced CreateCriteria(Action<CustomerMessageSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CustomerMessageSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CustomerMessageSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CustomerMessageSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CustomerMessageSearch, CustomerMessageSearchRow> 
            ISearchAdvanced<CustomerMessageSearch, CustomerMessageSearchRow>.CreateColumns(Action<CustomerMessageSearchRow> initializer) => this.CreateColumns(initializer);

        public CustomerMessageSearchAdvanced CreateColumns(Action<CustomerMessageSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}