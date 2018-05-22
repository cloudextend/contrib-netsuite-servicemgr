namespace SuiteTalk
{
    public interface IPassportProvider
    {
        Passport GetPassport();
    }

    public interface ITokenPassportProvider
    {
        TokenPassport GetTokenPassport();
    }

    public interface IPreferenceProvider
    {
        SearchPreferences GetSearchPreferences();
        Preferences GetPreferences();
    }

}
