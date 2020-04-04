// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class WinLossReasonSearchAdvanced: ISearchAdvanced, ISearchAdvanced<WinLossReasonSearch, WinLossReasonSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public WinLossReasonSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public WinLossReasonSearch CreateCriteria()
        {
            this.criteria = new WinLossReasonSearch();
            return this.criteria;
        }

        ISearchAdvanced<WinLossReasonSearch, WinLossReasonSearchRow> 
            ISearchAdvanced<WinLossReasonSearch, WinLossReasonSearchRow>.CreateCriteria(Action<WinLossReasonSearch> initializer) => this.CreateCriteria(initializer);

        public WinLossReasonSearchAdvanced CreateCriteria(Action<WinLossReasonSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public WinLossReasonSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public WinLossReasonSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new WinLossReasonSearchRow();
            return this.columns;
        }

        ISearchAdvanced<WinLossReasonSearch, WinLossReasonSearchRow> 
            ISearchAdvanced<WinLossReasonSearch, WinLossReasonSearchRow>.CreateColumns(Action<WinLossReasonSearchRow> initializer) => this.CreateColumns(initializer);

        public WinLossReasonSearchAdvanced CreateColumns(Action<WinLossReasonSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}