// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class GiftCertificateSearchAdvanced: ISearchAdvanced, ISearchAdvanced<GiftCertificateSearch, GiftCertificateSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public GiftCertificateSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public GiftCertificateSearch CreateCriteria()
        {
            this.criteria = new GiftCertificateSearch();
            return this.criteria;
        }

        ISearchAdvanced<GiftCertificateSearch, GiftCertificateSearchRow> 
            ISearchAdvanced<GiftCertificateSearch, GiftCertificateSearchRow>.CreateCriteria(Action<GiftCertificateSearch> initializer) => this.CreateCriteria(initializer);

        public GiftCertificateSearchAdvanced CreateCriteria(Action<GiftCertificateSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchAdvancedRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public GiftCertificateSearchRow GetColumns() => this.columns;

        ISearchAdvancedRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public GiftCertificateSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new GiftCertificateSearchRow();
            return this.columns;
        }

        ISearchAdvanced<GiftCertificateSearch, GiftCertificateSearchRow> 
            ISearchAdvanced<GiftCertificateSearch, GiftCertificateSearchRow>.CreateColumns(Action<GiftCertificateSearchRow> initializer) => this.CreateColumns(initializer);

        public GiftCertificateSearchAdvanced CreateColumns(Action<GiftCertificateSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}