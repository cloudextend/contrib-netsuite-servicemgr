namespace SuiteTalk
{
    public partial interface INetSuiteClient
    {
    #pragma warning disable IDE1006 // Naming Styles

        System.Threading.Tasks.Task<SuiteTalk.loginResponse> loginAsync();
        System.Threading.Tasks.Task<SuiteTalk.ssoLoginResponse> ssoLoginAsync();
        System.Threading.Tasks.Task<SuiteTalk.mapSsoResponse> mapSsoAsync();
        System.Threading.Tasks.Task<SuiteTalk.changePasswordResponse> changePasswordAsync();
        System.Threading.Tasks.Task<SuiteTalk.changeEmailResponse> changeEmailAsync();
        System.Threading.Tasks.Task<SuiteTalk.logoutResponse> logoutAsync();
        System.Threading.Tasks.Task<SuiteTalk.addResponse> addAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.deleteResponse> deleteAsync(SuiteTalk.DeletionReason deletionReason,SuiteTalk.BaseRef baseRef);
        System.Threading.Tasks.Task<SuiteTalk.searchResponse> searchAsync(SuiteTalk.SearchRecord searchRecord,SuiteTalk.SearchPreferences searchPreferences);
        System.Threading.Tasks.Task<SuiteTalk.searchMoreResponse> searchMoreAsync();
        System.Threading.Tasks.Task<SuiteTalk.searchMoreWithIdResponse> searchMoreWithIdAsync();
        System.Threading.Tasks.Task<SuiteTalk.searchNextResponse> searchNextAsync();
        System.Threading.Tasks.Task<SuiteTalk.updateResponse> updateAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.upsertResponse> upsertAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.addListResponse> addListAsync();
        System.Threading.Tasks.Task<SuiteTalk.deleteListResponse> deleteListAsync();
        System.Threading.Tasks.Task<SuiteTalk.updateListResponse> updateListAsync();
        System.Threading.Tasks.Task<SuiteTalk.upsertListResponse> upsertListAsync();
        System.Threading.Tasks.Task<SuiteTalk.getResponse> getAsync(SuiteTalk.BaseRef baseRef);
        System.Threading.Tasks.Task<SuiteTalk.getListResponse> getListAsync();
        System.Threading.Tasks.Task<SuiteTalk.getAllResponse> getAllAsync();
        System.Threading.Tasks.Task<SuiteTalk.getSavedSearchResponse> getSavedSearchAsync();
        System.Threading.Tasks.Task<SuiteTalk.getCustomizationIdResponse> getCustomizationIdAsync();
        System.Threading.Tasks.Task<SuiteTalk.initializeResponse> initializeAsync(SuiteTalk.InitializeRecord initializeRecord);
        System.Threading.Tasks.Task<SuiteTalk.initializeListResponse> initializeListAsync();
        System.Threading.Tasks.Task<SuiteTalk.getSelectValueResponse> getSelectValueAsync();
        System.Threading.Tasks.Task<SuiteTalk.getItemAvailabilityResponse> getItemAvailabilityAsync();
        System.Threading.Tasks.Task<SuiteTalk.getBudgetExchangeRateResponse> getBudgetExchangeRateAsync();
        System.Threading.Tasks.Task<SuiteTalk.getCurrencyRateResponse> getCurrencyRateAsync();
        System.Threading.Tasks.Task<SuiteTalk.getDataCenterUrlsResponse> getDataCenterUrlsAsync();
        System.Threading.Tasks.Task<SuiteTalk.getPostingTransactionSummaryResponse> getPostingTransactionSummaryAsync();
        System.Threading.Tasks.Task<SuiteTalk.getServerTimeResponse> getServerTimeAsync();
        System.Threading.Tasks.Task<SuiteTalk.attachResponse> attachAsync(SuiteTalk.AttachReference attachReference);
        System.Threading.Tasks.Task<SuiteTalk.detachResponse> detachAsync(SuiteTalk.DetachReference detachReference);
        System.Threading.Tasks.Task<SuiteTalk.updateInviteeStatusResponse> updateInviteeStatusAsync();
        System.Threading.Tasks.Task<SuiteTalk.updateInviteeStatusListResponse> updateInviteeStatusListAsync();
        System.Threading.Tasks.Task<SuiteTalk.asyncAddListResponse> asyncAddListAsync();
        System.Threading.Tasks.Task<SuiteTalk.asyncUpdateListResponse> asyncUpdateListAsync();
        System.Threading.Tasks.Task<SuiteTalk.asyncUpsertListResponse> asyncUpsertListAsync();
        System.Threading.Tasks.Task<SuiteTalk.asyncDeleteListResponse> asyncDeleteListAsync();
        System.Threading.Tasks.Task<SuiteTalk.asyncGetListResponse> asyncGetListAsync();
        System.Threading.Tasks.Task<SuiteTalk.asyncInitializeListResponse> asyncInitializeListAsync();
        System.Threading.Tasks.Task<SuiteTalk.asyncSearchResponse> asyncSearchAsync();
        System.Threading.Tasks.Task<SuiteTalk.getAsyncResultResponse> getAsyncResultAsync();
        System.Threading.Tasks.Task<SuiteTalk.checkAsyncStatusResponse> checkAsyncStatusAsync();
        System.Threading.Tasks.Task<SuiteTalk.getDeletedResponse> getDeletedAsync();
    #pragma warning restore IDE1006 // Naming Styles
    }

    public partial class NetSuitePortTypeClient: INetSuiteClient
    {
      public System.Threading.Tasks.Task<SuiteTalk.loginResponse> loginAsync()
      {
          var request = new loginRequest();
          request.passport = this.passport;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          return ((NetSuitePortType)this).loginAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.logoutResponse> logoutAsync()
      {
          var request = new logoutRequest();
          request.applicationInfo = this.applicationInfo;
          return ((NetSuitePortType)this).logoutAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.addResponse> addAsync(SuiteTalk.Record record)
      {
          var request = new addRequest();
          request.preferences = this.preferences;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.record = record;
          return ((NetSuitePortType)this).addAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.deleteResponse> deleteAsync(SuiteTalk.DeletionReason deletionReason,SuiteTalk.BaseRef baseRef)
      {
          var request = new deleteRequest();
          request.preferences = this.preferences;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.deletionReason = deletionReason;
          request.baseRef = baseRef;
          return ((NetSuitePortType)this).deleteAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.searchResponse> searchAsync(SuiteTalk.SearchRecord searchRecord,SuiteTalk.SearchPreferences searchPreferences)
      {
          var request = new searchRequest();
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.searchRecord = searchRecord;
          request.searchPreferences = searchPreferences;
          return ((NetSuitePortType)this).searchAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.updateResponse> updateAsync(SuiteTalk.Record record)
      {
          var request = new updateRequest();
          request.preferences = this.preferences;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.record = record;
          return ((NetSuitePortType)this).updateAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.upsertResponse> upsertAsync(SuiteTalk.Record record)
      {
          var request = new upsertRequest();
          request.preferences = this.preferences;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.record = record;
          return ((NetSuitePortType)this).upsertAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getResponse> getAsync(SuiteTalk.BaseRef baseRef)
      {
          var request = new getRequest();
          request.preferences = this.preferences;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.baseRef = baseRef;
          return ((NetSuitePortType)this).getAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.initializeResponse> initializeAsync(SuiteTalk.InitializeRecord initializeRecord)
      {
          var request = new initializeRequest();
          request.preferences = this.preferences;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.initializeRecord = initializeRecord;
          return ((NetSuitePortType)this).initializeAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.attachResponse> attachAsync(SuiteTalk.AttachReference attachReference)
      {
          var request = new attachRequest();
          request.preferences = this.preferences;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.attachReference = attachReference;
          return ((NetSuitePortType)this).attachAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.detachResponse> detachAsync(SuiteTalk.DetachReference detachReference)
      {
          var request = new detachRequest();
          request.preferences = this.preferences;
          request.partnerInfo = this.partnerInfo;
          request.applicationInfo = this.applicationInfo;
          request.tokenPassport = this.tokenPassport;
          request.passport = this.passport;
          request.detachReference = detachReference;
          return ((NetSuitePortType)this).detachAsync(request);
      }

    }
}
