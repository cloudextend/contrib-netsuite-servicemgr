// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class HcmJobSearchAdvanced: ISearchAdvanced, ISearchAdvanced<HcmJobSearch, HcmJobSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public HcmJobSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public HcmJobSearch CreateCriteria()
        {
            this.criteria = new HcmJobSearch();
            return this.criteria;
        }

        ISearchAdvanced<HcmJobSearch, HcmJobSearchRow> 
            ISearchAdvanced<HcmJobSearch, HcmJobSearchRow>.CreateCriteria(Action<HcmJobSearch> initializer) => this.CreateCriteria(initializer);

        public HcmJobSearchAdvanced CreateCriteria(Action<HcmJobSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public HcmJobSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public HcmJobSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new HcmJobSearchRow();
            return this.columns;
        }

        ISearchAdvanced<HcmJobSearch, HcmJobSearchRow> 
            ISearchAdvanced<HcmJobSearch, HcmJobSearchRow>.CreateColumns(Action<HcmJobSearchRow> initializer) => this.CreateColumns(initializer);

        public HcmJobSearchAdvanced CreateColumns(Action<HcmJobSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}