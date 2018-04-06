// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class NexusSearchAdvanced: ISearchAdvanced, ISearchAdvanced<NexusSearch, NexusSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public NexusSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public NexusSearch CreateCriteria()
        {
            this.criteria = new NexusSearch();
            return this.criteria;
        }

        ISearchAdvanced<NexusSearch, NexusSearchRow> 
            ISearchAdvanced<NexusSearch, NexusSearchRow>.CreateCriteria(Action<NexusSearch> initializer) => this.CreateCriteria(initializer);

        public NexusSearchAdvanced CreateCriteria(Action<NexusSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public NexusSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public NexusSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new NexusSearchRow();
            return this.columns;
        }

        ISearchAdvanced<NexusSearch, NexusSearchRow> 
            ISearchAdvanced<NexusSearch, NexusSearchRow>.CreateColumns(Action<NexusSearchRow> initializer) => this.CreateColumns(initializer);

        public NexusSearchAdvanced CreateColumns(Action<NexusSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}