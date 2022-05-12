
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class SalesRoleSearchAdvanced: ISearchAdvanced, ISearchAdvanced<SalesRoleSearch, SalesRoleSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public SalesRoleSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public SalesRoleSearch CreateCriteria()
        {
            this.criteria = new SalesRoleSearch();
            return this.criteria;
        }

        ISearchAdvanced<SalesRoleSearch, SalesRoleSearchRow> 
            ISearchAdvanced<SalesRoleSearch, SalesRoleSearchRow>.CreateCriteria(Action<SalesRoleSearch> initializer) => this.CreateCriteria(initializer);

        public SalesRoleSearchAdvanced CreateCriteria(Action<SalesRoleSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public SalesRoleSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public SalesRoleSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new SalesRoleSearchRow();
            return this.columns;
        }

        ISearchAdvanced<SalesRoleSearch, SalesRoleSearchRow> 
            ISearchAdvanced<SalesRoleSearch, SalesRoleSearchRow>.CreateColumns(Action<SalesRoleSearchRow> initializer) => this.CreateColumns(initializer);

        public SalesRoleSearchAdvanced CreateColumns(Action<SalesRoleSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}