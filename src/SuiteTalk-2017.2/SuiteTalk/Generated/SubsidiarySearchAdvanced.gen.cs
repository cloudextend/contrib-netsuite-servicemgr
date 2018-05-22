// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class SubsidiarySearchAdvanced: ISearchAdvanced, ISearchAdvanced<SubsidiarySearch, SubsidiarySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public SubsidiarySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public SubsidiarySearch CreateCriteria()
        {
            this.criteria = new SubsidiarySearch();
            return this.criteria;
        }

        ISearchAdvanced<SubsidiarySearch, SubsidiarySearchRow> 
            ISearchAdvanced<SubsidiarySearch, SubsidiarySearchRow>.CreateCriteria(Action<SubsidiarySearch> initializer) => this.CreateCriteria(initializer);

        public SubsidiarySearchAdvanced CreateCriteria(Action<SubsidiarySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public SubsidiarySearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public SubsidiarySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new SubsidiarySearchRow();
            return this.columns;
        }

        ISearchAdvanced<SubsidiarySearch, SubsidiarySearchRow> 
            ISearchAdvanced<SubsidiarySearch, SubsidiarySearchRow>.CreateColumns(Action<SubsidiarySearchRow> initializer) => this.CreateColumns(initializer);

        public SubsidiarySearchAdvanced CreateColumns(Action<SubsidiarySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}