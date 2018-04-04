namespace SuiteTalk
{
    public partial interface SearchRow
    {
        SearchRowBasic GetBasic();

        SearchRowBasic CreateBasic();

        SearchRowBasic GetJoin(string joinName);

        SearchRowBasic CreateJoin(string joinName);
    }

    partial interface SupportsCustomSearchJoin
    {
        CustomSearchRowBasic[] GetCustomSearchJoin();

        CustomSearchRowBasic[] CreateCustomSearchJoin();
    }

//    public static partial class SearchColumnFactory
//    {
//        public static SearchColumnStringField CreateStringColumn(string columnName, string searchValue = null)
//        {
//            return new SearchColumnStringField {
//                customLabel = columnName,
//                searchValue = searchValue
//            };
//        }
//    }
}
