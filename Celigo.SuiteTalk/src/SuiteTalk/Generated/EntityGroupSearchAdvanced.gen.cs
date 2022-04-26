
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class EntityGroupSearchAdvanced: ISearchAdvanced, ISearchAdvanced<EntityGroupSearch, EntityGroupSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public EntityGroupSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public EntityGroupSearch CreateCriteria()
        {
            this.criteria = new EntityGroupSearch();
            return this.criteria;
        }

        ISearchAdvanced<EntityGroupSearch, EntityGroupSearchRow> 
            ISearchAdvanced<EntityGroupSearch, EntityGroupSearchRow>.CreateCriteria(Action<EntityGroupSearch> initializer) => this.CreateCriteria(initializer);

        public EntityGroupSearchAdvanced CreateCriteria(Action<EntityGroupSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public EntityGroupSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public EntityGroupSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new EntityGroupSearchRow();
            return this.columns;
        }

        ISearchAdvanced<EntityGroupSearch, EntityGroupSearchRow> 
            ISearchAdvanced<EntityGroupSearch, EntityGroupSearchRow>.CreateColumns(Action<EntityGroupSearchRow> initializer) => this.CreateColumns(initializer);

        public EntityGroupSearchAdvanced CreateColumns(Action<EntityGroupSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}