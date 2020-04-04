// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ContactRoleSearchAdvanced: ISearchAdvanced, ISearchAdvanced<ContactRoleSearch, ContactRoleSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ContactRoleSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ContactRoleSearch CreateCriteria()
        {
            this.criteria = new ContactRoleSearch();
            return this.criteria;
        }

        ISearchAdvanced<ContactRoleSearch, ContactRoleSearchRow> 
            ISearchAdvanced<ContactRoleSearch, ContactRoleSearchRow>.CreateCriteria(Action<ContactRoleSearch> initializer) => this.CreateCriteria(initializer);

        public ContactRoleSearchAdvanced CreateCriteria(Action<ContactRoleSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ContactRoleSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ContactRoleSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ContactRoleSearchRow();
            return this.columns;
        }

        ISearchAdvanced<ContactRoleSearch, ContactRoleSearchRow> 
            ISearchAdvanced<ContactRoleSearch, ContactRoleSearchRow>.CreateColumns(Action<ContactRoleSearchRow> initializer) => this.CreateColumns(initializer);

        public ContactRoleSearchAdvanced CreateColumns(Action<ContactRoleSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}