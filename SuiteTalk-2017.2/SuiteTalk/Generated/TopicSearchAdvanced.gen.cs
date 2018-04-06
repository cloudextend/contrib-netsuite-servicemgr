// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class TopicSearchAdvanced: ISearchAdvanced, ISearchAdvanced<TopicSearch, TopicSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public TopicSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public TopicSearch CreateCriteria()
        {
            this.criteria = new TopicSearch();
            return this.criteria;
        }

        ISearchAdvanced<TopicSearch, TopicSearchRow> 
            ISearchAdvanced<TopicSearch, TopicSearchRow>.CreateCriteria(Action<TopicSearch> initializer) => this.CreateCriteria(initializer);

        public TopicSearchAdvanced CreateCriteria(Action<TopicSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public TopicSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public TopicSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new TopicSearchRow();
            return this.columns;
        }

        ISearchAdvanced<TopicSearch, TopicSearchRow> 
            ISearchAdvanced<TopicSearch, TopicSearchRow>.CreateColumns(Action<TopicSearchRow> initializer) => this.CreateColumns(initializer);

        public TopicSearchAdvanced CreateColumns(Action<TopicSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}