
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class CampaignSearchAdvanced: ISearchAdvanced, ISearchAdvanced<CampaignSearch, CampaignSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public CampaignSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public CampaignSearch CreateCriteria()
        {
            this.criteria = new CampaignSearch();
            return this.criteria;
        }

        ISearchAdvanced<CampaignSearch, CampaignSearchRow> 
            ISearchAdvanced<CampaignSearch, CampaignSearchRow>.CreateCriteria(Action<CampaignSearch> initializer) => this.CreateCriteria(initializer);

        public CampaignSearchAdvanced CreateCriteria(Action<CampaignSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public CampaignSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public CampaignSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new CampaignSearchRow();
            return this.columns;
        }

        ISearchAdvanced<CampaignSearch, CampaignSearchRow> 
            ISearchAdvanced<CampaignSearch, CampaignSearchRow>.CreateColumns(Action<CampaignSearchRow> initializer) => this.CreateColumns(initializer);

        public CampaignSearchAdvanced CreateColumns(Action<CampaignSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}