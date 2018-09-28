// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class JobStatusSearchAdvanced: ISearchAdvanced, ISearchAdvanced<JobStatusSearch, JobStatusSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public JobStatusSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public JobStatusSearch CreateCriteria()
        {
            this.criteria = new JobStatusSearch();
            return this.criteria;
        }

        ISearchAdvanced<JobStatusSearch, JobStatusSearchRow> 
            ISearchAdvanced<JobStatusSearch, JobStatusSearchRow>.CreateCriteria(Action<JobStatusSearch> initializer) => this.CreateCriteria(initializer);

        public JobStatusSearchAdvanced CreateCriteria(Action<JobStatusSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public JobStatusSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public JobStatusSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new JobStatusSearchRow();
            return this.columns;
        }

        ISearchAdvanced<JobStatusSearch, JobStatusSearchRow> 
            ISearchAdvanced<JobStatusSearch, JobStatusSearchRow>.CreateColumns(Action<JobStatusSearchRow> initializer) => this.CreateColumns(initializer);

        public JobStatusSearchAdvanced CreateColumns(Action<JobStatusSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}