// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ItemSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ItemSearch, ItemSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ItemSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ItemSearch CreateCriteria()
        {
            this.criteria = new ItemSearch();
            return this.criteria;
        }

        ISearchAdvanced<ItemSearch, ItemSearchRow> 
            ISearchAdvanced<ItemSearch, ItemSearchRow>.CreateCriteria(Action<ItemSearch> initializer) => this.CreateCriteria(initializer);

        public ItemSearchAdvanced CreateCriteria(Action<ItemSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ItemSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ItemSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ItemSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ItemSearch, ItemSearchRow> 
            ISearchAdvanced<ItemSearch, ItemSearchRow>.CreateColumns(Action<ItemSearchRow> initializer) => this.CreateColumns(initializer);

        public ItemSearchAdvanced CreateColumns(Action<ItemSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}