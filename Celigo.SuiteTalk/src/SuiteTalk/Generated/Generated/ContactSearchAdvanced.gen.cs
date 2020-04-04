// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ContactSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ContactSearch, ContactSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ContactSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ContactSearch CreateCriteria()
        {
            this.criteria = new ContactSearch();
            return this.criteria;
        }

        ISearchAdvanced<ContactSearch, ContactSearchRow> 
            ISearchAdvanced<ContactSearch, ContactSearchRow>.CreateCriteria(Action<ContactSearch> initializer) => this.CreateCriteria(initializer);

        public ContactSearchAdvanced CreateCriteria(Action<ContactSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ContactSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ContactSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ContactSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ContactSearch, ContactSearchRow> 
            ISearchAdvanced<ContactSearch, ContactSearchRow>.CreateColumns(Action<ContactSearchRow> initializer) => this.CreateColumns(initializer);

        public ContactSearchAdvanced CreateColumns(Action<ContactSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}