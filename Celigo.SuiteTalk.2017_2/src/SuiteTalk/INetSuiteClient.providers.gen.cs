namespace SuiteTalk
{
    partial class NetSuitePortTypeClient
    {
        Passport IPassportProvider.GetPassport() => this.passport;
        
        SearchPreferences IPreferenceProvider.GetSearchPreferences() => this.searchPreferences;

        Preferences IPreferenceProvider.GetPreferences() => this.preferences;
    }
}