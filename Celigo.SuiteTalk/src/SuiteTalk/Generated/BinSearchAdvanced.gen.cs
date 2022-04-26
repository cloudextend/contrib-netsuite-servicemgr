
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class BinSearchAdvanced: ISearchAdvanced, ISearchAdvanced<BinSearch, BinSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public BinSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public BinSearch CreateCriteria()
        {
            this.criteria = new BinSearch();
            return this.criteria;
        }

        ISearchAdvanced<BinSearch, BinSearchRow> 
            ISearchAdvanced<BinSearch, BinSearchRow>.CreateCriteria(Action<BinSearch> initializer) => this.CreateCriteria(initializer);

        public BinSearchAdvanced CreateCriteria(Action<BinSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public BinSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public BinSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new BinSearchRow();
            return this.columns;
        }

        ISearchAdvanced<BinSearch, BinSearchRow> 
            ISearchAdvanced<BinSearch, BinSearchRow>.CreateColumns(Action<BinSearchRow> initializer) => this.CreateColumns(initializer);

        public BinSearchAdvanced CreateColumns(Action<BinSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}