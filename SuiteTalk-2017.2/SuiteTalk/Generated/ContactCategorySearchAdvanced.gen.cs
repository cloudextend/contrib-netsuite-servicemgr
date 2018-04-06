// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class ContactCategorySearchAdvanced: ISearchAdvanced, ISearchAdvanced<ContactCategorySearch, ContactCategorySearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public ContactCategorySearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public ContactCategorySearch CreateCriteria()
        {
            this.criteria = new ContactCategorySearch();
            return this.criteria;
        }

        ISearchAdvanced<ContactCategorySearch, ContactCategorySearchRow> 
            ISearchAdvanced<ContactCategorySearch, ContactCategorySearchRow>.CreateCriteria(Action<ContactCategorySearch> initializer) => this.CreateCriteria(initializer);

        public ContactCategorySearchAdvanced CreateCriteria(Action<ContactCategorySearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public ContactCategorySearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public ContactCategorySearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new ContactCategorySearchRow();
            return this.columns;
        }

        ISearchAdvanced<ContactCategorySearch, ContactCategorySearchRow> 
            ISearchAdvanced<ContactCategorySearch, ContactCategorySearchRow>.CreateColumns(Action<ContactCategorySearchRow> initializer) => this.CreateColumns(initializer);

        public ContactCategorySearchAdvanced CreateColumns(Action<ContactCategorySearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}