// Generator { Name = "SearchRecordGenerator", Template = "ISearchColumnField" }

using System;

namespace SuiteTalk
{

      partial class SearchColumnDateField : ISearchColumnField<DateTime>, IValueTypeSearchColumnField<DateTime>
      {
            public object GetSearchValue() => this.searchValue;
      }

      partial class SearchColumnSelectField : ISearchColumnField<RecordRef>
      {
            public object GetSearchValue() => this.searchValue;
      }

      partial class SearchColumnEnumSelectField : ISearchColumnField<string>
      {
            public object GetSearchValue() => this.searchValue;
      }

      partial class SearchColumnDoubleField : ISearchColumnField<double>, IValueTypeSearchColumnField<double>
      {
            public object GetSearchValue() => this.searchValue;
      }

      partial class SearchColumnTextNumberField : ISearchColumnField<string>
      {
            public object GetSearchValue() => this.searchValue;
      }

      partial class SearchColumnLongField : ISearchColumnField<long>, IValueTypeSearchColumnField<long>
      {
            public object GetSearchValue() => this.searchValue;
      }

      partial class SearchColumnStringField : ISearchColumnField<string>
      {
            public object GetSearchValue() => this.searchValue;
      }

      partial class SearchColumnBooleanField : ISearchColumnField<bool>, IValueTypeSearchColumnField<bool>
      {
            public object GetSearchValue() => this.searchValue;
      }
}