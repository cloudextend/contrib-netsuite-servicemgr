using System;

namespace SuiteTalk
{
    public interface IPassportProvider
    {
        Passport GetPassport();
    }

    public interface IPreferenceProvider
    {
        SearchPreferences GetSearchPreferences();
        Preferences GetPreferences();
    }

    partial class NetSuitePortTypeClient: IPassportProvider, IPreferenceProvider
    {
        Passport IPassportProvider.GetPassport() => this.passport;
        
        SearchPreferences IPreferenceProvider.GetSearchPreferences() => this.searchPreferences;

        Preferences IPreferenceProvider.GetPreferences() => this.preferences;
    }
}