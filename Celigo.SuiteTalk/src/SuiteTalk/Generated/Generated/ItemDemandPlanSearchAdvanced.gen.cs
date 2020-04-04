// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ItemDemandPlanSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ItemDemandPlanSearch, ItemDemandPlanSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ItemDemandPlanSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ItemDemandPlanSearch CreateCriteria()
        {
            this.criteria = new ItemDemandPlanSearch();
            return this.criteria;
        }

        ISearchAdvanced<ItemDemandPlanSearch, ItemDemandPlanSearchRow> 
            ISearchAdvanced<ItemDemandPlanSearch, ItemDemandPlanSearchRow>.CreateCriteria(Action<ItemDemandPlanSearch> initializer) => this.CreateCriteria(initializer);

        public ItemDemandPlanSearchAdvanced CreateCriteria(Action<ItemDemandPlanSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ItemDemandPlanSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ItemDemandPlanSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ItemDemandPlanSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ItemDemandPlanSearch, ItemDemandPlanSearchRow> 
            ISearchAdvanced<ItemDemandPlanSearch, ItemDemandPlanSearchRow>.CreateColumns(Action<ItemDemandPlanSearchRow> initializer) => this.CreateColumns(initializer);

        public ItemDemandPlanSearchAdvanced CreateColumns(Action<ItemDemandPlanSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}