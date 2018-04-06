// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ProjectTaskSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ProjectTaskSearch, ProjectTaskSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ProjectTaskSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ProjectTaskSearch CreateCriteria()
        {
            this.criteria = new ProjectTaskSearch();
            return this.criteria;
        }

        ISearchAdvanced<ProjectTaskSearch, ProjectTaskSearchRow> 
            ISearchAdvanced<ProjectTaskSearch, ProjectTaskSearchRow>.CreateCriteria(Action<ProjectTaskSearch> initializer) => this.CreateCriteria(initializer);

        public ProjectTaskSearchAdvanced CreateCriteria(Action<ProjectTaskSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ProjectTaskSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ProjectTaskSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ProjectTaskSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ProjectTaskSearch, ProjectTaskSearchRow> 
            ISearchAdvanced<ProjectTaskSearch, ProjectTaskSearchRow>.CreateColumns(Action<ProjectTaskSearchRow> initializer) => this.CreateColumns(initializer);

        public ProjectTaskSearchAdvanced CreateColumns(Action<ProjectTaskSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}