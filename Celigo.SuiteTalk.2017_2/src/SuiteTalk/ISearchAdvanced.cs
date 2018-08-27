using System;

namespace SuiteTalk
{
    public interface ISearchAdvanced
    {
        SearchRecord GetCriteria();

        SearchRecord CreateCriteria();

        ISearchAdvancedRow GetColumns();

        ISearchAdvancedRow CreateColumns();

#pragma warning disable IDE1006 // Naming Styles
        string savedSearchId { get; set; }

        string savedSearchScriptId { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public interface ISearchAdvanced<TCriteria, TColumns> 
        where TCriteria: SearchRecord
        where TColumns: ISearchAdvancedRow
    {
        TCriteria GetCriteria();

        TCriteria CreateCriteria();

        ISearchAdvanced<TCriteria, TColumns> CreateCriteria(Action<TCriteria> initializer);

        TColumns GetColumns();

        TColumns CreateColumns();

        ISearchAdvanced<TCriteria, TColumns> CreateColumns(Action<TColumns> initializer);
    }
}
