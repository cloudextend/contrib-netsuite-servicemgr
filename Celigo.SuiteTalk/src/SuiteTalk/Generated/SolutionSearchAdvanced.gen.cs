// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class SolutionSearchAdvanced: ISearchAdvanced, ISearchAdvanced<SolutionSearch, SolutionSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public SolutionSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public SolutionSearch CreateCriteria()
        {
            this.criteria = new SolutionSearch();
            return this.criteria;
        }

        ISearchAdvanced<SolutionSearch, SolutionSearchRow> 
            ISearchAdvanced<SolutionSearch, SolutionSearchRow>.CreateCriteria(Action<SolutionSearch> initializer) => this.CreateCriteria(initializer);

        public SolutionSearchAdvanced CreateCriteria(Action<SolutionSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public SolutionSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public SolutionSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new SolutionSearchRow();
            return this.columns;
        }

        ISearchAdvanced<SolutionSearch, SolutionSearchRow> 
            ISearchAdvanced<SolutionSearch, SolutionSearchRow>.CreateColumns(Action<SolutionSearchRow> initializer) => this.CreateColumns(initializer);

        public SolutionSearchAdvanced CreateColumns(Action<SolutionSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}