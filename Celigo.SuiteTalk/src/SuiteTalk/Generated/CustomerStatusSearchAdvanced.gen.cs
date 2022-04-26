
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CustomerStatusSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CustomerStatusSearch, CustomerStatusSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CustomerStatusSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CustomerStatusSearch CreateCriteria()
        {
            this.criteria = new CustomerStatusSearch();
            return this.criteria;
        }

        ISearchAdvanced<CustomerStatusSearch, CustomerStatusSearchRow> 
            ISearchAdvanced<CustomerStatusSearch, CustomerStatusSearchRow>.CreateCriteria(Action<CustomerStatusSearch> initializer) => this.CreateCriteria(initializer);

        public CustomerStatusSearchAdvanced CreateCriteria(Action<CustomerStatusSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CustomerStatusSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CustomerStatusSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CustomerStatusSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CustomerStatusSearch, CustomerStatusSearchRow> 
            ISearchAdvanced<CustomerStatusSearch, CustomerStatusSearchRow>.CreateColumns(Action<CustomerStatusSearchRow> initializer) => this.CreateColumns(initializer);

        public CustomerStatusSearchAdvanced CreateColumns(Action<CustomerStatusSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}