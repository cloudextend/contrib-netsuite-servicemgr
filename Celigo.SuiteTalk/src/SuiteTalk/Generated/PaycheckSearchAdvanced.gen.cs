// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PaycheckSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PaycheckSearch, PaycheckSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PaycheckSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PaycheckSearch CreateCriteria()
        {
            this.criteria = new PaycheckSearch();
            return this.criteria;
        }

        ISearchAdvanced<PaycheckSearch, PaycheckSearchRow> 
            ISearchAdvanced<PaycheckSearch, PaycheckSearchRow>.CreateCriteria(Action<PaycheckSearch> initializer) => this.CreateCriteria(initializer);

        public PaycheckSearchAdvanced CreateCriteria(Action<PaycheckSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PaycheckSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PaycheckSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PaycheckSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PaycheckSearch, PaycheckSearchRow> 
            ISearchAdvanced<PaycheckSearch, PaycheckSearchRow>.CreateColumns(Action<PaycheckSearchRow> initializer) => this.CreateColumns(initializer);

        public PaycheckSearchAdvanced CreateColumns(Action<PaycheckSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}