
// Generator { Name: SearchAdvancedGenerator, Template: ISearchAdvanced }

using System;

namespace SuiteTalk
{
    public partial class InboundShipmentSearchAdvanced: ISearchAdvanced, ISearchAdvanced<InboundShipmentSearch, InboundShipmentSearchRow>
    {
        SearchRecord ISearchAdvanced.GetCriteria() => this.GetCriteria();

        public InboundShipmentSearch GetCriteria() => this.criteria;

        SearchRecord ISearchAdvanced.CreateCriteria() => this.CreateCriteria();

        public InboundShipmentSearch CreateCriteria()
        {
            this.criteria = new InboundShipmentSearch();
            return this.criteria;
        }

        ISearchAdvanced<InboundShipmentSearch, InboundShipmentSearchRow> 
            ISearchAdvanced<InboundShipmentSearch, InboundShipmentSearchRow>.CreateCriteria(Action<InboundShipmentSearch> initializer) => this.CreateCriteria(initializer);

        public InboundShipmentSearchAdvanced CreateCriteria(Action<InboundShipmentSearch> initializer)
        {
            var criteria = this.CreateCriteria();
            initializer?.Invoke(criteria);
            return this;
        }

        ISearchRow ISearchAdvanced.GetColumns() { return this.columns; }
    
        public InboundShipmentSearchRow GetColumns() => this.columns;

        ISearchRow ISearchAdvanced.CreateColumns() => this.CreateColumns();

        public InboundShipmentSearchRow CreateColumns()
        {
            if (this.columns == null) this.columns = new InboundShipmentSearchRow();
            return this.columns;
        }

        ISearchAdvanced<InboundShipmentSearch, InboundShipmentSearchRow> 
            ISearchAdvanced<InboundShipmentSearch, InboundShipmentSearchRow>.CreateColumns(Action<InboundShipmentSearchRow> initializer) => this.CreateColumns(initializer);

        public InboundShipmentSearchAdvanced CreateColumns(Action<InboundShipmentSearchRow> initializer) 
        {
            var columns = this.CreateColumns();
            initializer?.Invoke(columns);
            return this;
        }
    }
}