using System;

namespace SuiteTalk
{
    public interface ISearchAdvanced
    {
        SearchRecord GetCriteria();

        SearchRecord CreateCriteria();

        ISearchAdvancedRow GetColumns();

        ISearchAdvancedRow CreateColumns();
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
