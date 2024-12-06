// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class DepartmentSearchAdvanced: ISearchAdvanced, ISearchAdvanced<DepartmentSearch, DepartmentSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public DepartmentSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public DepartmentSearch CreateCriteria()
        {
            this.criteria = new DepartmentSearch();
            return this.criteria;
        }

        ISearchAdvanced<DepartmentSearch, DepartmentSearchRow> 
            ISearchAdvanced<DepartmentSearch, DepartmentSearchRow>.CreateCriteria(Action<DepartmentSearch> initializer) => this.CreateCriteria(initializer);

        public DepartmentSearchAdvanced CreateCriteria(Action<DepartmentSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public DepartmentSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public DepartmentSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new DepartmentSearchRow();
            return this.columns;
        }

        ISearchAdvanced<DepartmentSearch, DepartmentSearchRow> 
            ISearchAdvanced<DepartmentSearch, DepartmentSearchRow>.CreateColumns(Action<DepartmentSearchRow> initializer) => this.CreateColumns(initializer);

        public DepartmentSearchAdvanced CreateColumns(Action<DepartmentSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}