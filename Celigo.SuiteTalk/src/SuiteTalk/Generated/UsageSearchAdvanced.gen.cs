
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class UsageSearchAdvanced: ISearchAdvanced, ISearchAdvanced<UsageSearch, UsageSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public UsageSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public UsageSearch CreateCriteria()
        {
            this.criteria = new UsageSearch();
            return this.criteria;
        }

        ISearchAdvanced<UsageSearch, UsageSearchRow> 
            ISearchAdvanced<UsageSearch, UsageSearchRow>.CreateCriteria(Action<UsageSearch> initializer) => this.CreateCriteria(initializer);

        public UsageSearchAdvanced CreateCriteria(Action<UsageSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public UsageSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public UsageSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new UsageSearchRow();
            return this.columns;
        }

        ISearchAdvanced<UsageSearch, UsageSearchRow> 
            ISearchAdvanced<UsageSearch, UsageSearchRow>.CreateColumns(Action<UsageSearchRow> initializer) => this.CreateColumns(initializer);

        public UsageSearchAdvanced CreateColumns(Action<UsageSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}