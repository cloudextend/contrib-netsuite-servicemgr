// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class FolderSearchAdvanced: ISearchAdvanced, ISearchAdvanced<FolderSearch, FolderSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public FolderSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public FolderSearch CreateCriteria()
        {
            this.criteria = new FolderSearch();
            return this.criteria;
        }

        ISearchAdvanced<FolderSearch, FolderSearchRow> 
            ISearchAdvanced<FolderSearch, FolderSearchRow>.CreateCriteria(Action<FolderSearch> initializer) => this.CreateCriteria(initializer);

        public FolderSearchAdvanced CreateCriteria(Action<FolderSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public FolderSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public FolderSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new FolderSearchRow();
            return this.columns;
        }

        ISearchAdvanced<FolderSearch, FolderSearchRow> 
            ISearchAdvanced<FolderSearch, FolderSearchRow>.CreateColumns(Action<FolderSearchRow> initializer) => this.CreateColumns(initializer);

        public FolderSearchAdvanced CreateColumns(Action<FolderSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}