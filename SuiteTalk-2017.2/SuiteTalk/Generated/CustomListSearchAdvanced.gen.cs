// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CustomListSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CustomListSearch, CustomListSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CustomListSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CustomListSearch CreateCriteria()
        {
            this.criteria = new CustomListSearch();
            return this.criteria;
        }

        ISearchAdvanced<CustomListSearch, CustomListSearchRow> 
            ISearchAdvanced<CustomListSearch, CustomListSearchRow>.CreateCriteria(Action<CustomListSearch> initializer) => this.CreateCriteria(initializer);

        public CustomListSearchAdvanced CreateCriteria(Action<CustomListSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CustomListSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CustomListSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CustomListSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CustomListSearch, CustomListSearchRow> 
            ISearchAdvanced<CustomListSearch, CustomListSearchRow>.CreateColumns(Action<CustomListSearchRow> initializer) => this.CreateColumns(initializer);

        public CustomListSearchAdvanced CreateColumns(Action<CustomListSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}