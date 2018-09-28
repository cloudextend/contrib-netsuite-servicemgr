// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class BomRevisionSearchAdvanced: ISearchAdvanced, ISearchAdvanced<BomRevisionSearch, BomRevisionSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public BomRevisionSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public BomRevisionSearch CreateCriteria()
        {
            this.criteria = new BomRevisionSearch();
            return this.criteria;
        }

        ISearchAdvanced<BomRevisionSearch, BomRevisionSearchRow> 
            ISearchAdvanced<BomRevisionSearch, BomRevisionSearchRow>.CreateCriteria(Action<BomRevisionSearch> initializer) => this.CreateCriteria(initializer);

        public BomRevisionSearchAdvanced CreateCriteria(Action<BomRevisionSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public BomRevisionSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public BomRevisionSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new BomRevisionSearchRow();
            return this.columns;
        }

        ISearchAdvanced<BomRevisionSearch, BomRevisionSearchRow> 
            ISearchAdvanced<BomRevisionSearch, BomRevisionSearchRow>.CreateColumns(Action<BomRevisionSearchRow> initializer) => this.CreateColumns(initializer);

        public BomRevisionSearchAdvanced CreateColumns(Action<BomRevisionSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}