// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class MessageSearchAdvanced: ISearchAdvanced, ISearchAdvanced<MessageSearch, MessageSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public MessageSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public MessageSearch CreateCriteria()
        {
            this.criteria = new MessageSearch();
            return this.criteria;
        }

        ISearchAdvanced<MessageSearch, MessageSearchRow> 
            ISearchAdvanced<MessageSearch, MessageSearchRow>.CreateCriteria(Action<MessageSearch> initializer) => this.CreateCriteria(initializer);

        public MessageSearchAdvanced CreateCriteria(Action<MessageSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public MessageSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public MessageSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new MessageSearchRow();
            return this.columns;
        }

        ISearchAdvanced<MessageSearch, MessageSearchRow> 
            ISearchAdvanced<MessageSearch, MessageSearchRow>.CreateColumns(Action<MessageSearchRow> initializer) => this.CreateColumns(initializer);

        public MessageSearchAdvanced CreateColumns(Action<MessageSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}