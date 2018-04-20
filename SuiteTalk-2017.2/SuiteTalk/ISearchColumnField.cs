namespace SuiteTalk
{
    public partial interface ISearchColumnField
    {
        object GetSearchValue();
    }

    public partial interface ISearchColumnField<T>: ISearchColumnField
    {
#pragma warning disable IDE1006 // Naming Styles
        string customLabel { get; set; }

        T searchValue { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public partial interface IValueTypeSearchColumnField: ISearchColumnField
    {
#pragma warning disable IDE1006 // Naming Styles
        bool searchValueSpecified { get; set; }
#pragma warning restore IDE1006 // Naming Styles
    }

    public partial interface IValueTypeSearchColumnField<T> : ISearchColumnField<T>, IValueTypeSearchColumnField
    {
    }
}
