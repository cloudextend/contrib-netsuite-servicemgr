// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ResourceAllocationSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ResourceAllocationSearch, ResourceAllocationSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ResourceAllocationSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ResourceAllocationSearch CreateCriteria()
        {
            this.criteria = new ResourceAllocationSearch();
            return this.criteria;
        }

        ISearchAdvanced<ResourceAllocationSearch, ResourceAllocationSearchRow> 
            ISearchAdvanced<ResourceAllocationSearch, ResourceAllocationSearchRow>.CreateCriteria(Action<ResourceAllocationSearch> initializer) => this.CreateCriteria(initializer);

        public ResourceAllocationSearchAdvanced CreateCriteria(Action<ResourceAllocationSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ResourceAllocationSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ResourceAllocationSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ResourceAllocationSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ResourceAllocationSearch, ResourceAllocationSearchRow> 
            ISearchAdvanced<ResourceAllocationSearch, ResourceAllocationSearchRow>.CreateColumns(Action<ResourceAllocationSearchRow> initializer) => this.CreateColumns(initializer);

        public ResourceAllocationSearchAdvanced CreateColumns(Action<ResourceAllocationSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}