using System;

namespace SuiteTalk
{
    public interface ISearchAdvancedRow
    {
        SearchRowBasic GetBasic();

        SearchRowBasic CreateBasic();

        SearchRowBasic GetJoin(string joinName);

        SearchRowBasic CreateJoin(string joinName);
    }

    public interface ISearchAdvancedRow<T> where T : SearchRowBasic
    {
        T GetBasic();

        T CreateBasic();

        ISearchAdvancedRow<T> CreateBasic(Action<T> initializer);

        J GetJoin<J>(string joinName) where J : SearchRowBasic;

        J CreateJoin<J>(string joinName) where J : SearchRowBasic;

        ISearchAdvancedRow<T> CreateJoin<J>(string joinName, Action<J> initializer) where J : SearchRowBasic;
    }

    partial interface SupportsCustomSearchJoin
    {
        CustomSearchRowBasic[] GetCustomSearchJoin();

        CustomSearchRowBasic[] CreateCustomSearchJoin();
    }
}
