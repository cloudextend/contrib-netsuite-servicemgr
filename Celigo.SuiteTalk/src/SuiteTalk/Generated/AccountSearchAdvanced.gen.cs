
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class AccountSearchAdvanced: ISearchAdvanced, ISearchAdvanced<AccountSearch, AccountSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public AccountSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public AccountSearch CreateCriteria()
        {
            this.criteria = new AccountSearch();
            return this.criteria;
        }

        ISearchAdvanced<AccountSearch, AccountSearchRow> 
            ISearchAdvanced<AccountSearch, AccountSearchRow>.CreateCriteria(Action<AccountSearch> initializer) => this.CreateCriteria(initializer);

        public AccountSearchAdvanced CreateCriteria(Action<AccountSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public AccountSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public AccountSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new AccountSearchRow();
            return this.columns;
        }

        ISearchAdvanced<AccountSearch, AccountSearchRow> 
            ISearchAdvanced<AccountSearch, AccountSearchRow>.CreateColumns(Action<AccountSearchRow> initializer) => this.CreateColumns(initializer);

        public AccountSearchAdvanced CreateColumns(Action<AccountSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}