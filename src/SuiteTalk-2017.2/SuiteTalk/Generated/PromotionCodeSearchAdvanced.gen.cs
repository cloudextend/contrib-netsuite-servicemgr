// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PromotionCodeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PromotionCodeSearch, PromotionCodeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PromotionCodeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PromotionCodeSearch CreateCriteria()
        {
            this.criteria = new PromotionCodeSearch();
            return this.criteria;
        }

        ISearchAdvanced<PromotionCodeSearch, PromotionCodeSearchRow> 
            ISearchAdvanced<PromotionCodeSearch, PromotionCodeSearchRow>.CreateCriteria(Action<PromotionCodeSearch> initializer) => this.CreateCriteria(initializer);

        public PromotionCodeSearchAdvanced CreateCriteria(Action<PromotionCodeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PromotionCodeSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PromotionCodeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PromotionCodeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PromotionCodeSearch, PromotionCodeSearchRow> 
            ISearchAdvanced<PromotionCodeSearch, PromotionCodeSearchRow>.CreateColumns(Action<PromotionCodeSearchRow> initializer) => this.CreateColumns(initializer);

        public PromotionCodeSearchAdvanced CreateColumns(Action<PromotionCodeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}