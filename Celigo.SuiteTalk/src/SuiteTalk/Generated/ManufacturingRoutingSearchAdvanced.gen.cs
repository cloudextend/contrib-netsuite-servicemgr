
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ManufacturingRoutingSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ManufacturingRoutingSearch, ManufacturingRoutingSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ManufacturingRoutingSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ManufacturingRoutingSearch CreateCriteria()
        {
            this.criteria = new ManufacturingRoutingSearch();
            return this.criteria;
        }

        ISearchAdvanced<ManufacturingRoutingSearch, ManufacturingRoutingSearchRow> 
            ISearchAdvanced<ManufacturingRoutingSearch, ManufacturingRoutingSearchRow>.CreateCriteria(Action<ManufacturingRoutingSearch> initializer) => this.CreateCriteria(initializer);

        public ManufacturingRoutingSearchAdvanced CreateCriteria(Action<ManufacturingRoutingSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ManufacturingRoutingSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ManufacturingRoutingSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ManufacturingRoutingSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ManufacturingRoutingSearch, ManufacturingRoutingSearchRow> 
            ISearchAdvanced<ManufacturingRoutingSearch, ManufacturingRoutingSearchRow>.CreateColumns(Action<ManufacturingRoutingSearchRow> initializer) => this.CreateColumns(initializer);

        public ManufacturingRoutingSearchAdvanced CreateColumns(Action<ManufacturingRoutingSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}