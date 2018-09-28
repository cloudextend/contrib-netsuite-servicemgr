// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class JobTypeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<JobTypeSearch, JobTypeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public JobTypeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public JobTypeSearch CreateCriteria()
        {
            this.criteria = new JobTypeSearch();
            return this.criteria;
        }

        ISearchAdvanced<JobTypeSearch, JobTypeSearchRow> 
            ISearchAdvanced<JobTypeSearch, JobTypeSearchRow>.CreateCriteria(Action<JobTypeSearch> initializer) => this.CreateCriteria(initializer);

        public JobTypeSearchAdvanced CreateCriteria(Action<JobTypeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public JobTypeSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public JobTypeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new JobTypeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<JobTypeSearch, JobTypeSearchRow> 
            ISearchAdvanced<JobTypeSearch, JobTypeSearchRow>.CreateColumns(Action<JobTypeSearchRow> initializer) => this.CreateColumns(initializer);

        public JobTypeSearchAdvanced CreateColumns(Action<JobTypeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}