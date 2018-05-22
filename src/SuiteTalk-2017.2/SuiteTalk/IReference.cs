namespace SuiteTalk
{
    public interface IReference
    {
#pragma warning disable IDE1006 // Naming Styles
        string internalId { get; set; }
        string externalId { get; set; }
#pragma warning restore IDE1006 // Naming Styles

        string GetInternalId();
        string GetExternalId();
        void SetInternalId(string internalId);
        void SetExternalId(string externalId);
    }
}
