// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TaskSearchAdvanced: ISearchAdvanced, ISearchAdvanced<TaskSearch, TaskSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TaskSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TaskSearch CreateCriteria()
        {
            this.criteria = new TaskSearch();
            return this.criteria;
        }

        ISearchAdvanced<TaskSearch, TaskSearchRow> 
            ISearchAdvanced<TaskSearch, TaskSearchRow>.CreateCriteria(Action<TaskSearch> initializer) => this.CreateCriteria(initializer);

        public TaskSearchAdvanced CreateCriteria(Action<TaskSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TaskSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TaskSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TaskSearchRow();
            return this.columns;
        }

        ISearchAdvanced<TaskSearch, TaskSearchRow> 
            ISearchAdvanced<TaskSearch, TaskSearchRow>.CreateColumns(Action<TaskSearchRow> initializer) => this.CreateColumns(initializer);

        public TaskSearchAdvanced CreateColumns(Action<TaskSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}