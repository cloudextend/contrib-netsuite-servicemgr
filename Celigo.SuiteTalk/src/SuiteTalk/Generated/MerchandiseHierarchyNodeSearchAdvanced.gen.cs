
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class MerchandiseHierarchyNodeSearchAdvanced: ISearchAdvanced, ISearchAdvanced<MerchandiseHierarchyNodeSearch, MerchandiseHierarchyNodeSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public MerchandiseHierarchyNodeSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public MerchandiseHierarchyNodeSearch CreateCriteria()
        {
            this.criteria = new MerchandiseHierarchyNodeSearch();
            return this.criteria;
        }

        ISearchAdvanced<MerchandiseHierarchyNodeSearch, MerchandiseHierarchyNodeSearchRow> 
            ISearchAdvanced<MerchandiseHierarchyNodeSearch, MerchandiseHierarchyNodeSearchRow>.CreateCriteria(Action<MerchandiseHierarchyNodeSearch> initializer) => this.CreateCriteria(initializer);

        public MerchandiseHierarchyNodeSearchAdvanced CreateCriteria(Action<MerchandiseHierarchyNodeSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public MerchandiseHierarchyNodeSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public MerchandiseHierarchyNodeSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new MerchandiseHierarchyNodeSearchRow();
            return this.columns;
        }

        ISearchAdvanced<MerchandiseHierarchyNodeSearch, MerchandiseHierarchyNodeSearchRow> 
            ISearchAdvanced<MerchandiseHierarchyNodeSearch, MerchandiseHierarchyNodeSearchRow>.CreateColumns(Action<MerchandiseHierarchyNodeSearchRow> initializer) => this.CreateColumns(initializer);

        public MerchandiseHierarchyNodeSearchAdvanced CreateColumns(Action<MerchandiseHierarchyNodeSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}