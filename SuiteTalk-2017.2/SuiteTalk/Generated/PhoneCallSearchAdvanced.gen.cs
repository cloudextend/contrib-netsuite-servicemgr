// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class PhoneCallSearchAdvanced: ISearchAdvanced, ISearchAdvanced<PhoneCallSearch, PhoneCallSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public PhoneCallSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public PhoneCallSearch CreateCriteria()
        {
            this.criteria = new PhoneCallSearch();
            return this.criteria;
        }

        ISearchAdvanced<PhoneCallSearch, PhoneCallSearchRow> 
            ISearchAdvanced<PhoneCallSearch, PhoneCallSearchRow>.CreateCriteria(Action<PhoneCallSearch> initializer) => this.CreateCriteria(initializer);

        public PhoneCallSearchAdvanced CreateCriteria(Action<PhoneCallSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public PhoneCallSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public PhoneCallSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new PhoneCallSearchRow();
            return this.columns;
        }

        ISearchAdvanced<PhoneCallSearch, PhoneCallSearchRow> 
            ISearchAdvanced<PhoneCallSearch, PhoneCallSearchRow>.CreateColumns(Action<PhoneCallSearchRow> initializer) => this.CreateColumns(initializer);

        public PhoneCallSearchAdvanced CreateColumns(Action<PhoneCallSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}