// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class EmployeeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<EmployeeSearch, EmployeeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public EmployeeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public EmployeeSearch CreateCriteria()
        {
            this.criteria = new EmployeeSearch();
            return this.criteria;
        }

        ISearchAdvanced<EmployeeSearch, EmployeeSearchRow> 
            ISearchAdvanced<EmployeeSearch, EmployeeSearchRow>.CreateCriteria(Action<EmployeeSearch> initializer) => this.CreateCriteria(initializer);

        public EmployeeSearchAdvanced CreateCriteria(Action<EmployeeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public EmployeeSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public EmployeeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new EmployeeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<EmployeeSearch, EmployeeSearchRow> 
            ISearchAdvanced<EmployeeSearch, EmployeeSearchRow>.CreateColumns(Action<EmployeeSearchRow> initializer) => this.CreateColumns(initializer);

        public EmployeeSearchAdvanced CreateColumns(Action<EmployeeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}