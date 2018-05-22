using System;

namespace SuiteTalk
{
    partial class NetSuitePortTypeClient: IPassportProvider, IPreferenceProvider
    {
        Passport IPassportProvider.GetPassport() => this.passport;
        
        SearchPreferences IPreferenceProvider.GetSearchPreferences() => this.searchPreferences;

        Preferences IPreferenceProvider.GetPreferences() => this.preferences;
    }
}