
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ManufacturingCostTemplateSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ManufacturingCostTemplateSearch, ManufacturingCostTemplateSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ManufacturingCostTemplateSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ManufacturingCostTemplateSearch CreateCriteria()
        {
            this.criteria = new ManufacturingCostTemplateSearch();
            return this.criteria;
        }

        ISearchAdvanced<ManufacturingCostTemplateSearch, ManufacturingCostTemplateSearchRow> 
            ISearchAdvanced<ManufacturingCostTemplateSearch, ManufacturingCostTemplateSearchRow>.CreateCriteria(Action<ManufacturingCostTemplateSearch> initializer) => this.CreateCriteria(initializer);

        public ManufacturingCostTemplateSearchAdvanced CreateCriteria(Action<ManufacturingCostTemplateSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ManufacturingCostTemplateSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ManufacturingCostTemplateSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ManufacturingCostTemplateSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ManufacturingCostTemplateSearch, ManufacturingCostTemplateSearchRow> 
            ISearchAdvanced<ManufacturingCostTemplateSearch, ManufacturingCostTemplateSearchRow>.CreateColumns(Action<ManufacturingCostTemplateSearchRow> initializer) => this.CreateColumns(initializer);

        public ManufacturingCostTemplateSearchAdvanced CreateColumns(Action<ManufacturingCostTemplateSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}