// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class InventoryNumberSearchAdvanced: ISearchAdvanced, ISearchAdvanced<InventoryNumberSearch, InventoryNumberSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public InventoryNumberSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public InventoryNumberSearch CreateCriteria()
        {
            this.criteria = new InventoryNumberSearch();
            return this.criteria;
        }

        ISearchAdvanced<InventoryNumberSearch, InventoryNumberSearchRow> 
            ISearchAdvanced<InventoryNumberSearch, InventoryNumberSearchRow>.CreateCriteria(Action<InventoryNumberSearch> initializer) => this.CreateCriteria(initializer);

        public InventoryNumberSearchAdvanced CreateCriteria(Action<InventoryNumberSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public InventoryNumberSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public InventoryNumberSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new InventoryNumberSearchRow();
            return this.columns;
        }

        ISearchAdvanced<InventoryNumberSearch, InventoryNumberSearchRow> 
            ISearchAdvanced<InventoryNumberSearch, InventoryNumberSearchRow>.CreateColumns(Action<InventoryNumberSearchRow> initializer) => this.CreateColumns(initializer);

        public InventoryNumberSearchAdvanced CreateColumns(Action<InventoryNumberSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}