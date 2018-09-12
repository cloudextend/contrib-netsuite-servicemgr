// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class JobSearchAdvanced: ISearchAdvanced, ISearchAdvanced<JobSearch, JobSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public JobSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public JobSearch CreateCriteria()
        {
            this.criteria = new JobSearch();
            return this.criteria;
        }

        ISearchAdvanced<JobSearch, JobSearchRow> 
            ISearchAdvanced<JobSearch, JobSearchRow>.CreateCriteria(Action<JobSearch> initializer) => this.CreateCriteria(initializer);

        public JobSearchAdvanced CreateCriteria(Action<JobSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public JobSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public JobSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new JobSearchRow();
            return this.columns;
        }

        ISearchAdvanced<JobSearch, JobSearchRow> 
            ISearchAdvanced<JobSearch, JobSearchRow>.CreateColumns(Action<JobSearchRow> initializer) => this.CreateColumns(initializer);

        public JobSearchAdvanced CreateColumns(Action<JobSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}