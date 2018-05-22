using System;

namespace SuiteTalk
{
    public interface ISearch
    {
        SearchRecordBasic GetBasic();

        SearchRecordBasic CreateBasic();

        SearchRecordBasic GetJoin(string joinName);

        SearchRecordBasic CreateJoin(string joinName);
    }

    public interface ISearch<T> where T : SearchRecordBasic
    {
        T GetBasic();

        T CreateBasic();

        ISearch<T> CreateBasic(Action<T> initializer);

        J GetJoin<J>(string joinName) where J : SearchRecordBasic;

        J CreateJoin<J>(string joinName) where J : SearchRecordBasic;

        ISearch<T> CreateJoin<J>(string joinName, Action<J> initializer) where J : SearchRecordBasic;
    }
}
