namespace SuiteTalk
{
    public partial interface INetSuiteClient
    {
    #pragma warning disable IDE1006 // Naming Styles

        System.Threading.Tasks.Task<SuiteTalk.loginResponse> loginAsync();
        System.Threading.Tasks.Task<SuiteTalk.ssoLoginResponse> ssoLoginAsync(SuiteTalk.SsoPassport ssoPassport);
        System.Threading.Tasks.Task<SuiteTalk.mapSsoResponse> mapSsoAsync(SuiteTalk.SsoCredentials ssoCredentials);
        System.Threading.Tasks.Task<SuiteTalk.changePasswordResponse> changePasswordAsync(SuiteTalk.ChangePassword changePassword);
        System.Threading.Tasks.Task<SuiteTalk.changeEmailResponse> changeEmailAsync(SuiteTalk.ChangeEmail changeEmail);
        System.Threading.Tasks.Task<SuiteTalk.logoutResponse> logoutAsync();
        System.Threading.Tasks.Task<SuiteTalk.addResponse> addAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.deleteResponse> deleteAsync(SuiteTalk.BaseRef baseRef,SuiteTalk.DeletionReason deletionReason);
        System.Threading.Tasks.Task<SuiteTalk.searchResponse> searchAsync(SuiteTalk.SearchPreferences searchPreferences,SuiteTalk.SearchRecord searchRecord);
        System.Threading.Tasks.Task<SuiteTalk.searchMoreResponse> searchMoreAsync(SuiteTalk.SearchPreferences searchPreferences,System.Int32 pageIndex);
        System.Threading.Tasks.Task<SuiteTalk.searchMoreWithIdResponse> searchMoreWithIdAsync(SuiteTalk.SearchPreferences searchPreferences,System.String searchId,System.Int32 pageIndex);
        System.Threading.Tasks.Task<SuiteTalk.searchNextResponse> searchNextAsync(SuiteTalk.SearchPreferences searchPreferences);
        System.Threading.Tasks.Task<SuiteTalk.updateResponse> updateAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.upsertResponse> upsertAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.addListResponse> addListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.deleteListResponse> deleteListAsync(SuiteTalk.BaseRef[] baseRef,SuiteTalk.DeletionReason deletionReason);
        System.Threading.Tasks.Task<SuiteTalk.updateListResponse> updateListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.upsertListResponse> upsertListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.getResponse> getAsync(SuiteTalk.BaseRef baseRef);
        System.Threading.Tasks.Task<SuiteTalk.getListResponse> getListAsync(SuiteTalk.BaseRef[] baseRef);
        System.Threading.Tasks.Task<SuiteTalk.getAllResponse> getAllAsync(SuiteTalk.GetAllRecord record);
        System.Threading.Tasks.Task<SuiteTalk.getSavedSearchResponse> getSavedSearchAsync(SuiteTalk.GetSavedSearchRecord record);
        System.Threading.Tasks.Task<SuiteTalk.getCustomizationIdResponse> getCustomizationIdAsync(SuiteTalk.CustomizationType customizationType,System.Boolean includeInactives);
        System.Threading.Tasks.Task<SuiteTalk.initializeResponse> initializeAsync(SuiteTalk.InitializeRecord initializeRecord);
        System.Threading.Tasks.Task<SuiteTalk.initializeListResponse> initializeListAsync(SuiteTalk.InitializeRecord[] initializeRecord);
        System.Threading.Tasks.Task<SuiteTalk.getSelectValueResponse> getSelectValueAsync(SuiteTalk.GetSelectValueFieldDescription fieldDescription,System.Int32 pageIndex);
        System.Threading.Tasks.Task<SuiteTalk.getItemAvailabilityResponse> getItemAvailabilityAsync(SuiteTalk.ItemAvailabilityFilter itemAvailabilityFilter);
        System.Threading.Tasks.Task<SuiteTalk.getBudgetExchangeRateResponse> getBudgetExchangeRateAsync(SuiteTalk.BudgetExchangeRateFilter budgetExchangeRateFilter);
        System.Threading.Tasks.Task<SuiteTalk.getCurrencyRateResponse> getCurrencyRateAsync(SuiteTalk.CurrencyRateFilter currencyRateFilter);
        System.Threading.Tasks.Task<SuiteTalk.getDataCenterUrlsResponse> getDataCenterUrlsAsync(System.String account);
        System.Threading.Tasks.Task<SuiteTalk.getPostingTransactionSummaryResponse> getPostingTransactionSummaryAsync(SuiteTalk.PostingTransactionSummaryField fields,SuiteTalk.PostingTransactionSummaryFilter filters,System.Int32 pageIndex,System.String operationId);
        System.Threading.Tasks.Task<SuiteTalk.getServerTimeResponse> getServerTimeAsync();
        System.Threading.Tasks.Task<SuiteTalk.attachResponse> attachAsync(SuiteTalk.AttachReference attachReference);
        System.Threading.Tasks.Task<SuiteTalk.detachResponse> detachAsync(SuiteTalk.DetachReference detachReference);
        System.Threading.Tasks.Task<SuiteTalk.updateInviteeStatusResponse> updateInviteeStatusAsync(SuiteTalk.UpdateInviteeStatusReference updateInviteeStatusReference);
        System.Threading.Tasks.Task<SuiteTalk.updateInviteeStatusListResponse> updateInviteeStatusListAsync(SuiteTalk.UpdateInviteeStatusReference[] updateInviteeStatusReference);
        System.Threading.Tasks.Task<SuiteTalk.asyncAddListResponse> asyncAddListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.asyncUpdateListResponse> asyncUpdateListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.asyncUpsertListResponse> asyncUpsertListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.asyncDeleteListResponse> asyncDeleteListAsync(SuiteTalk.BaseRef[] baseRef,SuiteTalk.DeletionReason deletionReason);
        System.Threading.Tasks.Task<SuiteTalk.asyncGetListResponse> asyncGetListAsync(SuiteTalk.BaseRef[] baseRef);
        System.Threading.Tasks.Task<SuiteTalk.asyncInitializeListResponse> asyncInitializeListAsync(SuiteTalk.InitializeRecord[] initializeRecord);
        System.Threading.Tasks.Task<SuiteTalk.asyncSearchResponse> asyncSearchAsync(SuiteTalk.SearchPreferences searchPreferences,SuiteTalk.SearchRecord searchRecord);
        System.Threading.Tasks.Task<SuiteTalk.getAsyncResultResponse> getAsyncResultAsync(System.String jobId,System.Int32 pageIndex);
        System.Threading.Tasks.Task<SuiteTalk.checkAsyncStatusResponse> checkAsyncStatusAsync(System.String jobId);
        System.Threading.Tasks.Task<SuiteTalk.getDeletedResponse> getDeletedAsync(SuiteTalk.GetDeletedFilter getDeletedFilter,System.Int32 pageIndex);
    #pragma warning restore IDE1006 // Naming Styles
    }

    public partial class NetSuitePortTypeClient: INetSuiteClient
    {
      public System.Threading.Tasks.Task<SuiteTalk.loginResponse> loginAsync()
      {
          var request = new loginRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      passport = passport,
          };
          return ((NetSuitePortType)this).loginAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.ssoLoginResponse> ssoLoginAsync(SuiteTalk.SsoPassport ssoPassport)
      {
          var request = new ssoLoginRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      ssoPassport = ssoPassport,
          };
          return ((NetSuitePortType)this).ssoLoginAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.mapSsoResponse> mapSsoAsync(SuiteTalk.SsoCredentials ssoCredentials)
      {
          var request = new mapSsoRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      ssoCredentials = ssoCredentials,
          };
          return ((NetSuitePortType)this).mapSsoAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.changePasswordResponse> changePasswordAsync(SuiteTalk.ChangePassword changePassword)
      {
          var request = new changePasswordRequest() {
                      passport = passport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      changePassword = changePassword,
          };
          return ((NetSuitePortType)this).changePasswordAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.changeEmailResponse> changeEmailAsync(SuiteTalk.ChangeEmail changeEmail)
      {
          var request = new changeEmailRequest() {
                      passport = passport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      changeEmail = changeEmail,
          };
          return ((NetSuitePortType)this).changeEmailAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.logoutResponse> logoutAsync()
      {
          var request = new logoutRequest() {
                      applicationInfo = applicationInfo,
          };
          return ((NetSuitePortType)this).logoutAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.addResponse> addAsync(SuiteTalk.Record record)
      {
          var request = new addRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).addAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.deleteResponse> deleteAsync(SuiteTalk.BaseRef baseRef,SuiteTalk.DeletionReason deletionReason)
      {
          var request = new deleteRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
                      deletionReason = deletionReason,
          };
          return ((NetSuitePortType)this).deleteAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.searchResponse> searchAsync(SuiteTalk.SearchPreferences searchPreferences,SuiteTalk.SearchRecord searchRecord)
      {
          var request = new searchRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      searchPreferences = searchPreferences,
                      searchRecord = searchRecord,
          };
          return ((NetSuitePortType)this).searchAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.searchMoreResponse> searchMoreAsync(SuiteTalk.SearchPreferences searchPreferences,System.Int32 pageIndex)
      {
          var request = new searchMoreRequest() {
                      applicationInfo = applicationInfo,
                      searchPreferences = searchPreferences,
                      pageIndex = pageIndex,
          };
          return ((NetSuitePortType)this).searchMoreAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.searchMoreWithIdResponse> searchMoreWithIdAsync(SuiteTalk.SearchPreferences searchPreferences,System.String searchId,System.Int32 pageIndex)
      {
          var request = new searchMoreWithIdRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      searchPreferences = searchPreferences,
                      searchId = searchId,
                      pageIndex = pageIndex,
          };
          return ((NetSuitePortType)this).searchMoreWithIdAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.searchNextResponse> searchNextAsync(SuiteTalk.SearchPreferences searchPreferences)
      {
          var request = new searchNextRequest() {
                      applicationInfo = applicationInfo,
                      searchPreferences = searchPreferences,
          };
          return ((NetSuitePortType)this).searchNextAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.updateResponse> updateAsync(SuiteTalk.Record record)
      {
          var request = new updateRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).updateAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.upsertResponse> upsertAsync(SuiteTalk.Record record)
      {
          var request = new upsertRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).upsertAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.addListResponse> addListAsync(SuiteTalk.Record[] record)
      {
          var request = new addListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).addListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.deleteListResponse> deleteListAsync(SuiteTalk.BaseRef[] baseRef,SuiteTalk.DeletionReason deletionReason)
      {
          var request = new deleteListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
                      deletionReason = deletionReason,
          };
          return ((NetSuitePortType)this).deleteListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.updateListResponse> updateListAsync(SuiteTalk.Record[] record)
      {
          var request = new updateListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).updateListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.upsertListResponse> upsertListAsync(SuiteTalk.Record[] record)
      {
          var request = new upsertListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).upsertListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getResponse> getAsync(SuiteTalk.BaseRef baseRef)
      {
          var request = new getRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
          };
          return ((NetSuitePortType)this).getAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getListResponse> getListAsync(SuiteTalk.BaseRef[] baseRef)
      {
          var request = new getListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
          };
          return ((NetSuitePortType)this).getListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getAllResponse> getAllAsync(SuiteTalk.GetAllRecord record)
      {
          var request = new getAllRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).getAllAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getSavedSearchResponse> getSavedSearchAsync(SuiteTalk.GetSavedSearchRecord record)
      {
          var request = new getSavedSearchRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).getSavedSearchAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getCustomizationIdResponse> getCustomizationIdAsync(SuiteTalk.CustomizationType customizationType,System.Boolean includeInactives)
      {
          var request = new getCustomizationIdRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      customizationType = customizationType,
                      includeInactives = includeInactives,
          };
          return ((NetSuitePortType)this).getCustomizationIdAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.initializeResponse> initializeAsync(SuiteTalk.InitializeRecord initializeRecord)
      {
          var request = new initializeRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      initializeRecord = initializeRecord,
          };
          return ((NetSuitePortType)this).initializeAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.initializeListResponse> initializeListAsync(SuiteTalk.InitializeRecord[] initializeRecord)
      {
          var request = new initializeListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      initializeRecord = initializeRecord,
          };
          return ((NetSuitePortType)this).initializeListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getSelectValueResponse> getSelectValueAsync(SuiteTalk.GetSelectValueFieldDescription fieldDescription,System.Int32 pageIndex)
      {
          var request = new getSelectValueRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      fieldDescription = fieldDescription,
                      pageIndex = pageIndex,
          };
          return ((NetSuitePortType)this).getSelectValueAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getItemAvailabilityResponse> getItemAvailabilityAsync(SuiteTalk.ItemAvailabilityFilter itemAvailabilityFilter)
      {
          var request = new getItemAvailabilityRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      itemAvailabilityFilter = itemAvailabilityFilter,
          };
          return ((NetSuitePortType)this).getItemAvailabilityAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getBudgetExchangeRateResponse> getBudgetExchangeRateAsync(SuiteTalk.BudgetExchangeRateFilter budgetExchangeRateFilter)
      {
          var request = new getBudgetExchangeRateRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      budgetExchangeRateFilter = budgetExchangeRateFilter,
          };
          return ((NetSuitePortType)this).getBudgetExchangeRateAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getCurrencyRateResponse> getCurrencyRateAsync(SuiteTalk.CurrencyRateFilter currencyRateFilter)
      {
          var request = new getCurrencyRateRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      currencyRateFilter = currencyRateFilter,
          };
          return ((NetSuitePortType)this).getCurrencyRateAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getDataCenterUrlsResponse> getDataCenterUrlsAsync(System.String account)
      {
          var request = new getDataCenterUrlsRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      account = account,
          };
          return ((NetSuitePortType)this).getDataCenterUrlsAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getPostingTransactionSummaryResponse> getPostingTransactionSummaryAsync(SuiteTalk.PostingTransactionSummaryField fields,SuiteTalk.PostingTransactionSummaryFilter filters,System.Int32 pageIndex,System.String operationId)
      {
          var request = new getPostingTransactionSummaryRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      fields = fields,
                      filters = filters,
                      pageIndex = pageIndex,
                      operationId = operationId,
          };
          return ((NetSuitePortType)this).getPostingTransactionSummaryAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getServerTimeResponse> getServerTimeAsync()
      {
          var request = new getServerTimeRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
          };
          return ((NetSuitePortType)this).getServerTimeAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.attachResponse> attachAsync(SuiteTalk.AttachReference attachReference)
      {
          var request = new attachRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      attachReference = attachReference,
          };
          return ((NetSuitePortType)this).attachAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.detachResponse> detachAsync(SuiteTalk.DetachReference detachReference)
      {
          var request = new detachRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      detachReference = detachReference,
          };
          return ((NetSuitePortType)this).detachAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.updateInviteeStatusResponse> updateInviteeStatusAsync(SuiteTalk.UpdateInviteeStatusReference updateInviteeStatusReference)
      {
          var request = new updateInviteeStatusRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      updateInviteeStatusReference = updateInviteeStatusReference,
          };
          return ((NetSuitePortType)this).updateInviteeStatusAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.updateInviteeStatusListResponse> updateInviteeStatusListAsync(SuiteTalk.UpdateInviteeStatusReference[] updateInviteeStatusReference)
      {
          var request = new updateInviteeStatusListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      updateInviteeStatusReference = updateInviteeStatusReference,
          };
          return ((NetSuitePortType)this).updateInviteeStatusListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.asyncAddListResponse> asyncAddListAsync(SuiteTalk.Record[] record)
      {
          var request = new asyncAddListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).asyncAddListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.asyncUpdateListResponse> asyncUpdateListAsync(SuiteTalk.Record[] record)
      {
          var request = new asyncUpdateListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).asyncUpdateListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.asyncUpsertListResponse> asyncUpsertListAsync(SuiteTalk.Record[] record)
      {
          var request = new asyncUpsertListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          return ((NetSuitePortType)this).asyncUpsertListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.asyncDeleteListResponse> asyncDeleteListAsync(SuiteTalk.BaseRef[] baseRef,SuiteTalk.DeletionReason deletionReason)
      {
          var request = new asyncDeleteListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
                      deletionReason = deletionReason,
          };
          return ((NetSuitePortType)this).asyncDeleteListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.asyncGetListResponse> asyncGetListAsync(SuiteTalk.BaseRef[] baseRef)
      {
          var request = new asyncGetListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
          };
          return ((NetSuitePortType)this).asyncGetListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.asyncInitializeListResponse> asyncInitializeListAsync(SuiteTalk.InitializeRecord[] initializeRecord)
      {
          var request = new asyncInitializeListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      initializeRecord = initializeRecord,
          };
          return ((NetSuitePortType)this).asyncInitializeListAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.asyncSearchResponse> asyncSearchAsync(SuiteTalk.SearchPreferences searchPreferences,SuiteTalk.SearchRecord searchRecord)
      {
          var request = new asyncSearchRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      searchPreferences = searchPreferences,
                      searchRecord = searchRecord,
          };
          return ((NetSuitePortType)this).asyncSearchAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getAsyncResultResponse> getAsyncResultAsync(System.String jobId,System.Int32 pageIndex)
      {
          var request = new getAsyncResultRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      jobId = jobId,
                      pageIndex = pageIndex,
          };
          return ((NetSuitePortType)this).getAsyncResultAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.checkAsyncStatusResponse> checkAsyncStatusAsync(System.String jobId)
      {
          var request = new checkAsyncStatusRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      jobId = jobId,
          };
          return ((NetSuitePortType)this).checkAsyncStatusAsync(request);
      }

      public System.Threading.Tasks.Task<SuiteTalk.getDeletedResponse> getDeletedAsync(SuiteTalk.GetDeletedFilter getDeletedFilter,System.Int32 pageIndex)
      {
          var request = new getDeletedRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      getDeletedFilter = getDeletedFilter,
                      pageIndex = pageIndex,
          };
          return ((NetSuitePortType)this).getDeletedAsync(request);
      }

    }
}
