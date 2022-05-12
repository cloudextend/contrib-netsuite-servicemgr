
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TransactionSearchAdvanced: ISearchAdvanced, ISearchAdvanced<TransactionSearch, TransactionSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TransactionSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TransactionSearch CreateCriteria()
        {
            this.criteria = new TransactionSearch();
            return this.criteria;
        }

        ISearchAdvanced<TransactionSearch, TransactionSearchRow> 
            ISearchAdvanced<TransactionSearch, TransactionSearchRow>.CreateCriteria(Action<TransactionSearch> initializer) => this.CreateCriteria(initializer);

        public TransactionSearchAdvanced CreateCriteria(Action<TransactionSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TransactionSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TransactionSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TransactionSearchRow();
            return this.columns;
        }

        ISearchAdvanced<TransactionSearch, TransactionSearchRow> 
            ISearchAdvanced<TransactionSearch, TransactionSearchRow>.CreateColumns(Action<TransactionSearchRow> initializer) => this.CreateColumns(initializer);

        public TransactionSearchAdvanced CreateColumns(Action<TransactionSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}