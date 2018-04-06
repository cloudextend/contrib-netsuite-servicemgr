// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CustomerSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CustomerSearch, CustomerSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CustomerSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CustomerSearch CreateCriteria()
        {
            this.criteria = new CustomerSearch();
            return this.criteria;
        }

        ISearchAdvanced<CustomerSearch, CustomerSearchRow> 
            ISearchAdvanced<CustomerSearch, CustomerSearchRow>.CreateCriteria(Action<CustomerSearch> initializer) => this.CreateCriteria(initializer);

        public CustomerSearchAdvanced CreateCriteria(Action<CustomerSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CustomerSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CustomerSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CustomerSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CustomerSearch, CustomerSearchRow> 
            ISearchAdvanced<CustomerSearch, CustomerSearchRow>.CreateColumns(Action<CustomerSearchRow> initializer) => this.CreateColumns(initializer);

        public CustomerSearchAdvanced CreateColumns(Action<CustomerSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}