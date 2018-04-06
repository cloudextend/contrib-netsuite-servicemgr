// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class FileSearchAdvanced: ISearchAdvanced, ISearchAdvanced<FileSearch, FileSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public FileSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public FileSearch CreateCriteria()
        {
            this.criteria = new FileSearch();
            return this.criteria;
        }

        ISearchAdvanced<FileSearch, FileSearchRow> 
            ISearchAdvanced<FileSearch, FileSearchRow>.CreateCriteria(Action<FileSearch> initializer) => this.CreateCriteria(initializer);

        public FileSearchAdvanced CreateCriteria(Action<FileSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public FileSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public FileSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new FileSearchRow();
            return this.columns;
        }

        ISearchAdvanced<FileSearch, FileSearchRow> 
            ISearchAdvanced<FileSearch, FileSearchRow>.CreateColumns(Action<FileSearchRow> initializer) => this.CreateColumns(initializer);

        public FileSearchAdvanced CreateColumns(Action<FileSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}