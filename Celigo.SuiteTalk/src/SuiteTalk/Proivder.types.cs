namespace SuiteTalk
{
    public interface IPreferenceProvider
    {
        SearchPreferences GetSearchPreferences();
        Preferences GetPreferences();
    }

}
