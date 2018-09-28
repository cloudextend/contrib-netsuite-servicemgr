// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class GlobalAccountMappingSearchAdvanced: ISearchAdvanced, ISearchAdvanced<GlobalAccountMappingSearch, GlobalAccountMappingSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public GlobalAccountMappingSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public GlobalAccountMappingSearch CreateCriteria()
        {
            this.criteria = new GlobalAccountMappingSearch();
            return this.criteria;
        }

        ISearchAdvanced<GlobalAccountMappingSearch, GlobalAccountMappingSearchRow> 
            ISearchAdvanced<GlobalAccountMappingSearch, GlobalAccountMappingSearchRow>.CreateCriteria(Action<GlobalAccountMappingSearch> initializer) => this.CreateCriteria(initializer);

        public GlobalAccountMappingSearchAdvanced CreateCriteria(Action<GlobalAccountMappingSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public GlobalAccountMappingSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public GlobalAccountMappingSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new GlobalAccountMappingSearchRow();
            return this.columns;
        }

        ISearchAdvanced<GlobalAccountMappingSearch, GlobalAccountMappingSearchRow> 
            ISearchAdvanced<GlobalAccountMappingSearch, GlobalAccountMappingSearchRow>.CreateColumns(Action<GlobalAccountMappingSearchRow> initializer) => this.CreateColumns(initializer);

        public GlobalAccountMappingSearchAdvanced CreateColumns(Action<GlobalAccountMappingSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}