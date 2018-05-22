// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class LocationSearchAdvanced: ISearchAdvanced, ISearchAdvanced<LocationSearch, LocationSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public LocationSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public LocationSearch CreateCriteria()
        {
            this.criteria = new LocationSearch();
            return this.criteria;
        }

        ISearchAdvanced<LocationSearch, LocationSearchRow> 
            ISearchAdvanced<LocationSearch, LocationSearchRow>.CreateCriteria(Action<LocationSearch> initializer) => this.CreateCriteria(initializer);

        public LocationSearchAdvanced CreateCriteria(Action<LocationSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public LocationSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public LocationSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new LocationSearchRow();
            return this.columns;
        }

        ISearchAdvanced<LocationSearch, LocationSearchRow> 
            ISearchAdvanced<LocationSearch, LocationSearchRow>.CreateColumns(Action<LocationSearchRow> initializer) => this.CreateColumns(initializer);

        public LocationSearchAdvanced CreateColumns(Action<LocationSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}