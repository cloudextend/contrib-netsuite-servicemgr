// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PartnerSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PartnerSearch, PartnerSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PartnerSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PartnerSearch CreateCriteria()
        {
            this.criteria = new PartnerSearch();
            return this.criteria;
        }

        ISearchAdvanced<PartnerSearch, PartnerSearchRow> 
            ISearchAdvanced<PartnerSearch, PartnerSearchRow>.CreateCriteria(Action<PartnerSearch> initializer) => this.CreateCriteria(initializer);

        public PartnerSearchAdvanced CreateCriteria(Action<PartnerSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PartnerSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PartnerSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PartnerSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PartnerSearch, PartnerSearchRow> 
            ISearchAdvanced<PartnerSearch, PartnerSearchRow>.CreateColumns(Action<PartnerSearchRow> initializer) => this.CreateColumns(initializer);

        public PartnerSearchAdvanced CreateColumns(Action<PartnerSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}