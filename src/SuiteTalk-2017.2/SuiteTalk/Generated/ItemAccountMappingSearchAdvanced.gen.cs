// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ItemAccountMappingSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ItemAccountMappingSearch, ItemAccountMappingSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ItemAccountMappingSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ItemAccountMappingSearch CreateCriteria()
        {
            this.criteria = new ItemAccountMappingSearch();
            return this.criteria;
        }

        ISearchAdvanced<ItemAccountMappingSearch, ItemAccountMappingSearchRow> 
            ISearchAdvanced<ItemAccountMappingSearch, ItemAccountMappingSearchRow>.CreateCriteria(Action<ItemAccountMappingSearch> initializer) => this.CreateCriteria(initializer);

        public ItemAccountMappingSearchAdvanced CreateCriteria(Action<ItemAccountMappingSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ItemAccountMappingSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ItemAccountMappingSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ItemAccountMappingSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ItemAccountMappingSearch, ItemAccountMappingSearchRow> 
            ISearchAdvanced<ItemAccountMappingSearch, ItemAccountMappingSearchRow>.CreateColumns(Action<ItemAccountMappingSearchRow> initializer) => this.CreateColumns(initializer);

        public ItemAccountMappingSearchAdvanced CreateColumns(Action<ItemAccountMappingSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}