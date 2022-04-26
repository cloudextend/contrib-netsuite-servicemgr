
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CustomerSubsidiaryRelationshipSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CustomerSubsidiaryRelationshipSearch, CustomerSubsidiaryRelationshipSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CustomerSubsidiaryRelationshipSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CustomerSubsidiaryRelationshipSearch CreateCriteria()
        {
            this.criteria = new CustomerSubsidiaryRelationshipSearch();
            return this.criteria;
        }

        ISearchAdvanced<CustomerSubsidiaryRelationshipSearch, CustomerSubsidiaryRelationshipSearchRow> 
            ISearchAdvanced<CustomerSubsidiaryRelationshipSearch, CustomerSubsidiaryRelationshipSearchRow>.CreateCriteria(Action<CustomerSubsidiaryRelationshipSearch> initializer) => this.CreateCriteria(initializer);

        public CustomerSubsidiaryRelationshipSearchAdvanced CreateCriteria(Action<CustomerSubsidiaryRelationshipSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CustomerSubsidiaryRelationshipSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CustomerSubsidiaryRelationshipSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CustomerSubsidiaryRelationshipSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CustomerSubsidiaryRelationshipSearch, CustomerSubsidiaryRelationshipSearchRow> 
            ISearchAdvanced<CustomerSubsidiaryRelationshipSearch, CustomerSubsidiaryRelationshipSearchRow>.CreateColumns(Action<CustomerSubsidiaryRelationshipSearchRow> initializer) => this.CreateColumns(initializer);

        public CustomerSubsidiaryRelationshipSearchAdvanced CreateColumns(Action<CustomerSubsidiaryRelationshipSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}