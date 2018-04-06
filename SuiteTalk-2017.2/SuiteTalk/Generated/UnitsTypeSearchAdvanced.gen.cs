// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class UnitsTypeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<UnitsTypeSearch, UnitsTypeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public UnitsTypeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public UnitsTypeSearch CreateCriteria()
        {
            this.criteria = new UnitsTypeSearch();
            return this.criteria;
        }

        ISearchAdvanced<UnitsTypeSearch, UnitsTypeSearchRow> 
            ISearchAdvanced<UnitsTypeSearch, UnitsTypeSearchRow>.CreateCriteria(Action<UnitsTypeSearch> initializer) => this.CreateCriteria(initializer);

        public UnitsTypeSearchAdvanced CreateCriteria(Action<UnitsTypeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public UnitsTypeSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public UnitsTypeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new UnitsTypeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<UnitsTypeSearch, UnitsTypeSearchRow> 
            ISearchAdvanced<UnitsTypeSearch, UnitsTypeSearchRow>.CreateColumns(Action<UnitsTypeSearchRow> initializer) => this.CreateColumns(initializer);

        public UnitsTypeSearchAdvanced CreateColumns(Action<UnitsTypeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}