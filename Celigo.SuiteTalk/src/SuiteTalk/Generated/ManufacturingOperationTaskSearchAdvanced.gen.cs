
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ManufacturingOperationTaskSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ManufacturingOperationTaskSearch, ManufacturingOperationTaskSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ManufacturingOperationTaskSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ManufacturingOperationTaskSearch CreateCriteria()
        {
            this.criteria = new ManufacturingOperationTaskSearch();
            return this.criteria;
        }

        ISearchAdvanced<ManufacturingOperationTaskSearch, ManufacturingOperationTaskSearchRow> 
            ISearchAdvanced<ManufacturingOperationTaskSearch, ManufacturingOperationTaskSearchRow>.CreateCriteria(Action<ManufacturingOperationTaskSearch> initializer) => this.CreateCriteria(initializer);

        public ManufacturingOperationTaskSearchAdvanced CreateCriteria(Action<ManufacturingOperationTaskSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ManufacturingOperationTaskSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ManufacturingOperationTaskSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ManufacturingOperationTaskSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ManufacturingOperationTaskSearch, ManufacturingOperationTaskSearchRow> 
            ISearchAdvanced<ManufacturingOperationTaskSearch, ManufacturingOperationTaskSearchRow>.CreateColumns(Action<ManufacturingOperationTaskSearchRow> initializer) => this.CreateColumns(initializer);

        public ManufacturingOperationTaskSearchAdvanced CreateColumns(Action<ManufacturingOperationTaskSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}