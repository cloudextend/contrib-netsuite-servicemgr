// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ItemSupplyPlanSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ItemSupplyPlanSearch, ItemSupplyPlanSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ItemSupplyPlanSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ItemSupplyPlanSearch CreateCriteria()
        {
            this.criteria = new ItemSupplyPlanSearch();
            return this.criteria;
        }

        ISearchAdvanced<ItemSupplyPlanSearch, ItemSupplyPlanSearchRow> 
            ISearchAdvanced<ItemSupplyPlanSearch, ItemSupplyPlanSearchRow>.CreateCriteria(Action<ItemSupplyPlanSearch> initializer) => this.CreateCriteria(initializer);

        public ItemSupplyPlanSearchAdvanced CreateCriteria(Action<ItemSupplyPlanSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ItemSupplyPlanSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ItemSupplyPlanSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ItemSupplyPlanSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ItemSupplyPlanSearch, ItemSupplyPlanSearchRow> 
            ISearchAdvanced<ItemSupplyPlanSearch, ItemSupplyPlanSearchRow>.CreateColumns(Action<ItemSupplyPlanSearchRow> initializer) => this.CreateColumns(initializer);

        public ItemSupplyPlanSearchAdvanced CreateColumns(Action<ItemSupplyPlanSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}