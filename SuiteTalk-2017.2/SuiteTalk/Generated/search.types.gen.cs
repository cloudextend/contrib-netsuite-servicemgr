using System;

namespace SuiteTalk
{
    public partial interface SearchRow
    {
        SearchRowBasic GetBasic();

        SearchRowBasic CreateBasic();
    }

    public partial interface SearchRow<T>
        where T: SearchRowBasic
    {
        T GetBasic();

        T CreateBasic();

        T CreateBasic(Action<T> initializer);

        SearchRowBasic GetJoin(string joinName);

        J GetJoin<J>(string joinName) where J: SearchRowBasic;

        SearchRowBasic CreateJoin(string joinName);

        J CreateJoin<J>(string joinName) where J: SearchRowBasic;

        J CreateJoin<J>(string joinName, Action<J> initializer) where J: SearchRowBasic;
    }

    partial interface SupportsCustomSearchJoin
    {
        CustomSearchRowBasic[] GetCustomSearchJoin();

        CustomSearchRowBasic[] CreateCustomSearchJoin();
    }

    partial class SearchRowBasic
    {
        public abstract void SetColumns(string[] columnNames);
    }
}
