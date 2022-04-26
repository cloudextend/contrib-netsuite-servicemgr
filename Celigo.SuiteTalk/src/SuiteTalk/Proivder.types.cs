namespace SuiteTalk
{
    // public interface IPassportProvider
    // {
    //     Passport GetPassport();
    // }

    public interface IPreferenceProvider
    {
        SearchPreferences GetSearchPreferences();
        Preferences GetPreferences();
    }

}
