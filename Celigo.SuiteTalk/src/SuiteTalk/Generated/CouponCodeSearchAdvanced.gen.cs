// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CouponCodeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CouponCodeSearch, CouponCodeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CouponCodeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CouponCodeSearch CreateCriteria()
        {
            this.criteria = new CouponCodeSearch();
            return this.criteria;
        }

        ISearchAdvanced<CouponCodeSearch, CouponCodeSearchRow> 
            ISearchAdvanced<CouponCodeSearch, CouponCodeSearchRow>.CreateCriteria(Action<CouponCodeSearch> initializer) => this.CreateCriteria(initializer);

        public CouponCodeSearchAdvanced CreateCriteria(Action<CouponCodeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CouponCodeSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CouponCodeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CouponCodeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CouponCodeSearch, CouponCodeSearchRow> 
            ISearchAdvanced<CouponCodeSearch, CouponCodeSearchRow>.CreateColumns(Action<CouponCodeSearchRow> initializer) => this.CreateColumns(initializer);

        public CouponCodeSearchAdvanced CreateColumns(Action<CouponCodeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}