
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ChargeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ChargeSearch, ChargeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ChargeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ChargeSearch CreateCriteria()
        {
            this.criteria = new ChargeSearch();
            return this.criteria;
        }

        ISearchAdvanced<ChargeSearch, ChargeSearchRow> 
            ISearchAdvanced<ChargeSearch, ChargeSearchRow>.CreateCriteria(Action<ChargeSearch> initializer) => this.CreateCriteria(initializer);

        public ChargeSearchAdvanced CreateCriteria(Action<ChargeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ChargeSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ChargeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ChargeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ChargeSearch, ChargeSearchRow> 
            ISearchAdvanced<ChargeSearch, ChargeSearchRow>.CreateColumns(Action<ChargeSearchRow> initializer) => this.CreateColumns(initializer);

        public ChargeSearchAdvanced CreateColumns(Action<ChargeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}