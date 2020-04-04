// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TaxGroupSearchAdvanced: ISearchAdvanced, ISearchAdvanced<TaxGroupSearch, TaxGroupSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TaxGroupSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TaxGroupSearch CreateCriteria()
        {
            this.criteria = new TaxGroupSearch();
            return this.criteria;
        }

        ISearchAdvanced<TaxGroupSearch, TaxGroupSearchRow> 
            ISearchAdvanced<TaxGroupSearch, TaxGroupSearchRow>.CreateCriteria(Action<TaxGroupSearch> initializer) => this.CreateCriteria(initializer);

        public TaxGroupSearchAdvanced CreateCriteria(Action<TaxGroupSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TaxGroupSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TaxGroupSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TaxGroupSearchRow();
            return this.columns;
        }

        ISearchAdvanced<TaxGroupSearch, TaxGroupSearchRow> 
            ISearchAdvanced<TaxGroupSearch, TaxGroupSearchRow>.CreateColumns(Action<TaxGroupSearchRow> initializer) => this.CreateColumns(initializer);

        public TaxGroupSearchAdvanced CreateColumns(Action<TaxGroupSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}