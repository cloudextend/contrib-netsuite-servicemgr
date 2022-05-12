
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class AccountingPeriodSearchAdvanced: ISearchAdvanced, ISearchAdvanced<AccountingPeriodSearch, AccountingPeriodSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public AccountingPeriodSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public AccountingPeriodSearch CreateCriteria()
        {
            this.criteria = new AccountingPeriodSearch();
            return this.criteria;
        }

        ISearchAdvanced<AccountingPeriodSearch, AccountingPeriodSearchRow> 
            ISearchAdvanced<AccountingPeriodSearch, AccountingPeriodSearchRow>.CreateCriteria(Action<AccountingPeriodSearch> initializer) => this.CreateCriteria(initializer);

        public AccountingPeriodSearchAdvanced CreateCriteria(Action<AccountingPeriodSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public AccountingPeriodSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public AccountingPeriodSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new AccountingPeriodSearchRow();
            return this.columns;
        }

        ISearchAdvanced<AccountingPeriodSearch, AccountingPeriodSearchRow> 
            ISearchAdvanced<AccountingPeriodSearch, AccountingPeriodSearchRow>.CreateColumns(Action<AccountingPeriodSearchRow> initializer) => this.CreateColumns(initializer);

        public AccountingPeriodSearchAdvanced CreateColumns(Action<AccountingPeriodSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}