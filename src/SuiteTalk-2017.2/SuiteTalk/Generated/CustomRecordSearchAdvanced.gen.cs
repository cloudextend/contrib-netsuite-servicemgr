// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CustomRecordSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CustomRecordSearch, CustomRecordSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CustomRecordSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CustomRecordSearch CreateCriteria()
        {
            this.criteria = new CustomRecordSearch();
            return this.criteria;
        }

        ISearchAdvanced<CustomRecordSearch, CustomRecordSearchRow> 
            ISearchAdvanced<CustomRecordSearch, CustomRecordSearchRow>.CreateCriteria(Action<CustomRecordSearch> initializer) => this.CreateCriteria(initializer);

        public CustomRecordSearchAdvanced CreateCriteria(Action<CustomRecordSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CustomRecordSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CustomRecordSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CustomRecordSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CustomRecordSearch, CustomRecordSearchRow> 
            ISearchAdvanced<CustomRecordSearch, CustomRecordSearchRow>.CreateColumns(Action<CustomRecordSearchRow> initializer) => this.CreateColumns(initializer);

        public CustomRecordSearchAdvanced CreateColumns(Action<CustomRecordSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}