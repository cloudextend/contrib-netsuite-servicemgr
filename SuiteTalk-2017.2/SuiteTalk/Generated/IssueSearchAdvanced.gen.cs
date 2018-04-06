// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class IssueSearchAdvanced: ISearchAdvanced, ISearchAdvanced<IssueSearch, IssueSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public IssueSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public IssueSearch CreateCriteria()
        {
            this.criteria = new IssueSearch();
            return this.criteria;
        }

        ISearchAdvanced<IssueSearch, IssueSearchRow> 
            ISearchAdvanced<IssueSearch, IssueSearchRow>.CreateCriteria(Action<IssueSearch> initializer) => this.CreateCriteria(initializer);

        public IssueSearchAdvanced CreateCriteria(Action<IssueSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public IssueSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public IssueSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new IssueSearchRow();
            return this.columns;
        }

        ISearchAdvanced<IssueSearch, IssueSearchRow> 
            ISearchAdvanced<IssueSearch, IssueSearchRow>.CreateColumns(Action<IssueSearchRow> initializer) => this.CreateColumns(initializer);

        public IssueSearchAdvanced CreateColumns(Action<IssueSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}