
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class AccountingTransactionSearchAdvanced: ISearchAdvanced, ISearchAdvanced<AccountingTransactionSearch, AccountingTransactionSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public AccountingTransactionSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public AccountingTransactionSearch CreateCriteria()
        {
            this.criteria = new AccountingTransactionSearch();
            return this.criteria;
        }

        ISearchAdvanced<AccountingTransactionSearch, AccountingTransactionSearchRow> 
            ISearchAdvanced<AccountingTransactionSearch, AccountingTransactionSearchRow>.CreateCriteria(Action<AccountingTransactionSearch> initializer) => this.CreateCriteria(initializer);

        public AccountingTransactionSearchAdvanced CreateCriteria(Action<AccountingTransactionSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public AccountingTransactionSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public AccountingTransactionSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new AccountingTransactionSearchRow();
            return this.columns;
        }

        ISearchAdvanced<AccountingTransactionSearch, AccountingTransactionSearchRow> 
            ISearchAdvanced<AccountingTransactionSearch, AccountingTransactionSearchRow>.CreateColumns(Action<AccountingTransactionSearchRow> initializer) => this.CreateColumns(initializer);

        public AccountingTransactionSearchAdvanced CreateColumns(Action<AccountingTransactionSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}