
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class BomSearchAdvanced: ISearchAdvanced, ISearchAdvanced<BomSearch, BomSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public BomSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public BomSearch CreateCriteria()
        {
            this.criteria = new BomSearch();
            return this.criteria;
        }

        ISearchAdvanced<BomSearch, BomSearchRow> 
            ISearchAdvanced<BomSearch, BomSearchRow>.CreateCriteria(Action<BomSearch> initializer) => this.CreateCriteria(initializer);

        public BomSearchAdvanced CreateCriteria(Action<BomSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public BomSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public BomSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new BomSearchRow();
            return this.columns;
        }

        ISearchAdvanced<BomSearch, BomSearchRow> 
            ISearchAdvanced<BomSearch, BomSearchRow>.CreateColumns(Action<BomSearchRow> initializer) => this.CreateColumns(initializer);

        public BomSearchAdvanced CreateColumns(Action<BomSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}