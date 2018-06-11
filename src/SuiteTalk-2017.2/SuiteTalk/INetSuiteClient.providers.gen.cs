namespace SuiteTalk
{
    partial class NetSuitePortTypeClient
    {
        Passport IPassportProvider.GetPassport() => this.passport;

        TokenPassport ITokenPassportProvider.GetTokenPassport() => this.tokenPassport;
        
        SearchPreferences IPreferenceProvider.GetSearchPreferences() => this.searchPreferences;

        Preferences IPreferenceProvider.GetPreferences() => this.preferences;
    }
}