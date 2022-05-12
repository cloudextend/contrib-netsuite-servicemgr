
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ItemRevisionSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ItemRevisionSearch, ItemRevisionSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ItemRevisionSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ItemRevisionSearch CreateCriteria()
        {
            this.criteria = new ItemRevisionSearch();
            return this.criteria;
        }

        ISearchAdvanced<ItemRevisionSearch, ItemRevisionSearchRow> 
            ISearchAdvanced<ItemRevisionSearch, ItemRevisionSearchRow>.CreateCriteria(Action<ItemRevisionSearch> initializer) => this.CreateCriteria(initializer);

        public ItemRevisionSearchAdvanced CreateCriteria(Action<ItemRevisionSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ItemRevisionSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ItemRevisionSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ItemRevisionSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ItemRevisionSearch, ItemRevisionSearchRow> 
            ISearchAdvanced<ItemRevisionSearch, ItemRevisionSearchRow>.CreateColumns(Action<ItemRevisionSearchRow> initializer) => this.CreateColumns(initializer);

        public ItemRevisionSearchAdvanced CreateColumns(Action<ItemRevisionSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}