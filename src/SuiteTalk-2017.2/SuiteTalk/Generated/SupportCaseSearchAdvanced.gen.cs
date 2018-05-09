// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class SupportCaseSearchAdvanced: ISearchAdvanced, ISearchAdvanced<SupportCaseSearch, SupportCaseSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public SupportCaseSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public SupportCaseSearch CreateCriteria()
        {
            this.criteria = new SupportCaseSearch();
            return this.criteria;
        }

        ISearchAdvanced<SupportCaseSearch, SupportCaseSearchRow> 
            ISearchAdvanced<SupportCaseSearch, SupportCaseSearchRow>.CreateCriteria(Action<SupportCaseSearch> initializer) => this.CreateCriteria(initializer);

        public SupportCaseSearchAdvanced CreateCriteria(Action<SupportCaseSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public SupportCaseSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public SupportCaseSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new SupportCaseSearchRow();
            return this.columns;
        }

        ISearchAdvanced<SupportCaseSearch, SupportCaseSearchRow> 
            ISearchAdvanced<SupportCaseSearch, SupportCaseSearchRow>.CreateColumns(Action<SupportCaseSearchRow> initializer) => this.CreateColumns(initializer);

        public SupportCaseSearchAdvanced CreateColumns(Action<SupportCaseSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}