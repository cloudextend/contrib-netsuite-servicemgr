// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ClassificationSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ClassificationSearch, ClassificationSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ClassificationSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ClassificationSearch CreateCriteria()
        {
            this.criteria = new ClassificationSearch();
            return this.criteria;
        }

        ISearchAdvanced<ClassificationSearch, ClassificationSearchRow> 
            ISearchAdvanced<ClassificationSearch, ClassificationSearchRow>.CreateCriteria(Action<ClassificationSearch> initializer) => this.CreateCriteria(initializer);

        public ClassificationSearchAdvanced CreateCriteria(Action<ClassificationSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ClassificationSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ClassificationSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ClassificationSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ClassificationSearch, ClassificationSearchRow> 
            ISearchAdvanced<ClassificationSearch, ClassificationSearchRow>.CreateColumns(Action<ClassificationSearchRow> initializer) => this.CreateColumns(initializer);

        public ClassificationSearchAdvanced CreateColumns(Action<ClassificationSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}