namespace SuiteTalk
{
    #pragma warning disable IDE1006 // Naming Styles

    public partial interface INetSuiteClient
    {
        System.Threading.Tasks.Task<SuiteTalk.SessionResponse> loginAsync();
        System.Threading.Tasks.Task<SuiteTalk.SessionResponse> ssoLoginAsync(SuiteTalk.SsoPassport ssoPassport);
        System.Threading.Tasks.Task<SuiteTalk.SessionResponse> mapSsoAsync(SuiteTalk.SsoCredentials ssoCredentials);
        System.Threading.Tasks.Task<SuiteTalk.SessionResponse> changePasswordAsync(SuiteTalk.ChangePassword changePassword);
        System.Threading.Tasks.Task<SuiteTalk.SessionResponse> changeEmailAsync(SuiteTalk.ChangeEmail changeEmail);
        System.Threading.Tasks.Task<SuiteTalk.SessionResponse> logoutAsync();
        System.Threading.Tasks.Task<SuiteTalk.WriteResponse> addAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponse> deleteAsync(SuiteTalk.BaseRef baseRef,SuiteTalk.DeletionReason deletionReason);
        System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchAsync(SuiteTalk.SearchRecord searchRecord);
        System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchMoreAsync(System.Int32 pageIndex);
        System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchMoreWithIdAsync(System.String searchId,System.Int32 pageIndex);
        System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchNextAsync();
        System.Threading.Tasks.Task<SuiteTalk.WriteResponse> updateAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponse> upsertAsync(SuiteTalk.Record record);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> addListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> deleteListAsync(SuiteTalk.BaseRef[] baseRef,SuiteTalk.DeletionReason deletionReason);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> updateListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> upsertListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.ReadResponse> getAsync(SuiteTalk.BaseRef baseRef);
        System.Threading.Tasks.Task<SuiteTalk.ReadResponseList> getListAsync(SuiteTalk.BaseRef[] baseRef);
        System.Threading.Tasks.Task<SuiteTalk.GetAllResult> getAllAsync(SuiteTalk.GetAllRecord record);
        System.Threading.Tasks.Task<SuiteTalk.GetSavedSearchResult> getSavedSearchAsync(SuiteTalk.GetSavedSearchRecord record);
        System.Threading.Tasks.Task<SuiteTalk.GetCustomizationIdResult> getCustomizationIdAsync(SuiteTalk.CustomizationType customizationType,System.Boolean includeInactives);
        System.Threading.Tasks.Task<SuiteTalk.ReadResponse> initializeAsync(SuiteTalk.InitializeRecord initializeRecord);
        System.Threading.Tasks.Task<SuiteTalk.ReadResponseList> initializeListAsync(SuiteTalk.InitializeRecord[] initializeRecord);
        System.Threading.Tasks.Task<SuiteTalk.GetSelectValueResult> getSelectValueAsync(SuiteTalk.GetSelectValueFieldDescription fieldDescription,System.Int32 pageIndex);
        System.Threading.Tasks.Task<SuiteTalk.GetItemAvailabilityResult> getItemAvailabilityAsync(SuiteTalk.ItemAvailabilityFilter itemAvailabilityFilter);
        System.Threading.Tasks.Task<SuiteTalk.GetBudgetExchangeRateResult> getBudgetExchangeRateAsync(SuiteTalk.BudgetExchangeRateFilter budgetExchangeRateFilter);
        System.Threading.Tasks.Task<SuiteTalk.GetCurrencyRateResult> getCurrencyRateAsync(SuiteTalk.CurrencyRateFilter currencyRateFilter);
        System.Threading.Tasks.Task<SuiteTalk.GetDataCenterUrlsResult> getDataCenterUrlsAsync(System.String account);
        System.Threading.Tasks.Task<SuiteTalk.GetPostingTransactionSummaryResult> getPostingTransactionSummaryAsync(SuiteTalk.PostingTransactionSummaryField fields,SuiteTalk.PostingTransactionSummaryFilter filters,System.Int32 pageIndex,System.String operationId);
        System.Threading.Tasks.Task<SuiteTalk.GetServerTimeResult> getServerTimeAsync();
        System.Threading.Tasks.Task<SuiteTalk.WriteResponse> attachAsync(SuiteTalk.AttachReference attachReference);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponse> detachAsync(SuiteTalk.DetachReference detachReference);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponse> updateInviteeStatusAsync(SuiteTalk.UpdateInviteeStatusReference updateInviteeStatusReference);
        System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> updateInviteeStatusListAsync(SuiteTalk.UpdateInviteeStatusReference[] updateInviteeStatusReference);
        System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncAddListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncUpdateListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncUpsertListAsync(SuiteTalk.Record[] record);
        System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncDeleteListAsync(SuiteTalk.BaseRef[] baseRef,SuiteTalk.DeletionReason deletionReason);
        System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncGetListAsync(SuiteTalk.BaseRef[] baseRef);
        System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncInitializeListAsync(SuiteTalk.InitializeRecord[] initializeRecord);
        System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncSearchAsync(SuiteTalk.SearchRecord searchRecord);
        System.Threading.Tasks.Task<SuiteTalk.AsyncResult> getAsyncResultAsync(System.String jobId,System.Int32 pageIndex);
        System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> checkAsyncStatusAsync(System.String jobId);
        System.Threading.Tasks.Task<SuiteTalk.GetDeletedResult> getDeletedAsync(SuiteTalk.GetDeletedFilter getDeletedFilter,System.Int32 pageIndex);
    }

    public partial class NetSuitePortTypeClient: INetSuiteClient
    {
      public async System.Threading.Tasks.Task<SuiteTalk.SessionResponse> loginAsync()
      {
          var request = new loginRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      passport = passport,
          };
          var response = await ((NetSuitePortType)this).loginAsync(request);
          return response.sessionResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SessionResponse> ssoLoginAsync(SuiteTalk.SsoPassport ssoPassport)
      {
          var request = new ssoLoginRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      ssoPassport = ssoPassport,
          };
          var response = await ((NetSuitePortType)this).ssoLoginAsync(request);
          return response.sessionResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SessionResponse> mapSsoAsync(SuiteTalk.SsoCredentials ssoCredentials)
      {
          var request = new mapSsoRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      ssoCredentials = ssoCredentials,
          };
          var response = await ((NetSuitePortType)this).mapSsoAsync(request);
          return response.sessionResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SessionResponse> changePasswordAsync(SuiteTalk.ChangePassword changePassword)
      {
          var request = new changePasswordRequest() {
                      passport = passport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      changePassword = changePassword,
          };
          var response = await ((NetSuitePortType)this).changePasswordAsync(request);
          return response.sessionResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SessionResponse> changeEmailAsync(SuiteTalk.ChangeEmail changeEmail)
      {
          var request = new changeEmailRequest() {
                      passport = passport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      changeEmail = changeEmail,
          };
          var response = await ((NetSuitePortType)this).changeEmailAsync(request);
          return response.sessionResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SessionResponse> logoutAsync()
      {
          var request = new logoutRequest() {
                      applicationInfo = applicationInfo,
          };
          var response = await ((NetSuitePortType)this).logoutAsync(request);
          return response.sessionResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponse> addAsync(SuiteTalk.Record record)
      {
          var request = new addRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).addAsync(request);
          return response.writeResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponse> deleteAsync(SuiteTalk.BaseRef baseRef,SuiteTalk.DeletionReason deletionReason)
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
          var response = await ((NetSuitePortType)this).deleteAsync(request);
          return response.writeResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchAsync(SuiteTalk.SearchRecord searchRecord)
      {
          var request = new searchRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      searchPreferences = searchPreferences,
                      searchRecord = searchRecord,
          };
          var response = await ((NetSuitePortType)this).searchAsync(request);
          return response.searchResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchMoreAsync(System.Int32 pageIndex)
      {
          var request = new searchMoreRequest() {
                      applicationInfo = applicationInfo,
                      searchPreferences = searchPreferences,
                      pageIndex = pageIndex,
          };
          var response = await ((NetSuitePortType)this).searchMoreAsync(request);
          return response.searchResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchMoreWithIdAsync(System.String searchId,System.Int32 pageIndex)
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
          var response = await ((NetSuitePortType)this).searchMoreWithIdAsync(request);
          return response.searchResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.SearchResult> searchNextAsync()
      {
          var request = new searchNextRequest() {
                      applicationInfo = applicationInfo,
                      searchPreferences = searchPreferences,
          };
          var response = await ((NetSuitePortType)this).searchNextAsync(request);
          return response.searchResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponse> updateAsync(SuiteTalk.Record record)
      {
          var request = new updateRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).updateAsync(request);
          return response.writeResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponse> upsertAsync(SuiteTalk.Record record)
      {
          var request = new upsertRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).upsertAsync(request);
          return response.writeResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> addListAsync(SuiteTalk.Record[] record)
      {
          var request = new addListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).addListAsync(request);
          return response.writeResponseList;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> deleteListAsync(SuiteTalk.BaseRef[] baseRef,SuiteTalk.DeletionReason deletionReason)
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
          var response = await ((NetSuitePortType)this).deleteListAsync(request);
          return response.writeResponseList;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> updateListAsync(SuiteTalk.Record[] record)
      {
          var request = new updateListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).updateListAsync(request);
          return response.writeResponseList;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> upsertListAsync(SuiteTalk.Record[] record)
      {
          var request = new upsertListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).upsertListAsync(request);
          return response.writeResponseList;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.ReadResponse> getAsync(SuiteTalk.BaseRef baseRef)
      {
          var request = new getRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
          };
          var response = await ((NetSuitePortType)this).getAsync(request);
          return response.readResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.ReadResponseList> getListAsync(SuiteTalk.BaseRef[] baseRef)
      {
          var request = new getListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
          };
          var response = await ((NetSuitePortType)this).getListAsync(request);
          return response.readResponseList;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetAllResult> getAllAsync(SuiteTalk.GetAllRecord record)
      {
          var request = new getAllRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).getAllAsync(request);
          return response.getAllResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetSavedSearchResult> getSavedSearchAsync(SuiteTalk.GetSavedSearchRecord record)
      {
          var request = new getSavedSearchRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).getSavedSearchAsync(request);
          return response.getSavedSearchResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetCustomizationIdResult> getCustomizationIdAsync(SuiteTalk.CustomizationType customizationType,System.Boolean includeInactives)
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
          var response = await ((NetSuitePortType)this).getCustomizationIdAsync(request);
          return response.getCustomizationIdResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.ReadResponse> initializeAsync(SuiteTalk.InitializeRecord initializeRecord)
      {
          var request = new initializeRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      initializeRecord = initializeRecord,
          };
          var response = await ((NetSuitePortType)this).initializeAsync(request);
          return response.readResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.ReadResponseList> initializeListAsync(SuiteTalk.InitializeRecord[] initializeRecord)
      {
          var request = new initializeListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      initializeRecord = initializeRecord,
          };
          var response = await ((NetSuitePortType)this).initializeListAsync(request);
          return response.readResponseList;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetSelectValueResult> getSelectValueAsync(SuiteTalk.GetSelectValueFieldDescription fieldDescription,System.Int32 pageIndex)
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
          var response = await ((NetSuitePortType)this).getSelectValueAsync(request);
          return response.getSelectValueResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetItemAvailabilityResult> getItemAvailabilityAsync(SuiteTalk.ItemAvailabilityFilter itemAvailabilityFilter)
      {
          var request = new getItemAvailabilityRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      itemAvailabilityFilter = itemAvailabilityFilter,
          };
          var response = await ((NetSuitePortType)this).getItemAvailabilityAsync(request);
          return response.getItemAvailabilityResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetBudgetExchangeRateResult> getBudgetExchangeRateAsync(SuiteTalk.BudgetExchangeRateFilter budgetExchangeRateFilter)
      {
          var request = new getBudgetExchangeRateRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      budgetExchangeRateFilter = budgetExchangeRateFilter,
          };
          var response = await ((NetSuitePortType)this).getBudgetExchangeRateAsync(request);
          return response.getBudgetExchangeRateResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetCurrencyRateResult> getCurrencyRateAsync(SuiteTalk.CurrencyRateFilter currencyRateFilter)
      {
          var request = new getCurrencyRateRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      currencyRateFilter = currencyRateFilter,
          };
          var response = await ((NetSuitePortType)this).getCurrencyRateAsync(request);
          return response.getCurrencyRateResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetDataCenterUrlsResult> getDataCenterUrlsAsync(System.String account)
      {
          var request = new getDataCenterUrlsRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      account = account,
          };
          var response = await ((NetSuitePortType)this).getDataCenterUrlsAsync(request);
          return response.getDataCenterUrlsResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetPostingTransactionSummaryResult> getPostingTransactionSummaryAsync(SuiteTalk.PostingTransactionSummaryField fields,SuiteTalk.PostingTransactionSummaryFilter filters,System.Int32 pageIndex,System.String operationId)
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
          var response = await ((NetSuitePortType)this).getPostingTransactionSummaryAsync(request);
          return response.getPostingTransactionSummaryResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetServerTimeResult> getServerTimeAsync()
      {
          var request = new getServerTimeRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
          };
          var response = await ((NetSuitePortType)this).getServerTimeAsync(request);
          return response.getServerTimeResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponse> attachAsync(SuiteTalk.AttachReference attachReference)
      {
          var request = new attachRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      attachReference = attachReference,
          };
          var response = await ((NetSuitePortType)this).attachAsync(request);
          return response.writeResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponse> detachAsync(SuiteTalk.DetachReference detachReference)
      {
          var request = new detachRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      detachReference = detachReference,
          };
          var response = await ((NetSuitePortType)this).detachAsync(request);
          return response.writeResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponse> updateInviteeStatusAsync(SuiteTalk.UpdateInviteeStatusReference updateInviteeStatusReference)
      {
          var request = new updateInviteeStatusRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      updateInviteeStatusReference = updateInviteeStatusReference,
          };
          var response = await ((NetSuitePortType)this).updateInviteeStatusAsync(request);
          return response.writeResponse;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.WriteResponseList> updateInviteeStatusListAsync(SuiteTalk.UpdateInviteeStatusReference[] updateInviteeStatusReference)
      {
          var request = new updateInviteeStatusListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      updateInviteeStatusReference = updateInviteeStatusReference,
          };
          var response = await ((NetSuitePortType)this).updateInviteeStatusListAsync(request);
          return response.writeResponseList;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncAddListAsync(SuiteTalk.Record[] record)
      {
          var request = new asyncAddListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).asyncAddListAsync(request);
          return response.asyncStatusResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncUpdateListAsync(SuiteTalk.Record[] record)
      {
          var request = new asyncUpdateListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).asyncUpdateListAsync(request);
          return response.asyncStatusResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncUpsertListAsync(SuiteTalk.Record[] record)
      {
          var request = new asyncUpsertListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      record = record,
          };
          var response = await ((NetSuitePortType)this).asyncUpsertListAsync(request);
          return response.asyncStatusResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncDeleteListAsync(SuiteTalk.BaseRef[] baseRef,SuiteTalk.DeletionReason deletionReason)
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
          var response = await ((NetSuitePortType)this).asyncDeleteListAsync(request);
          return response.asyncStatusResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncGetListAsync(SuiteTalk.BaseRef[] baseRef)
      {
          var request = new asyncGetListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      baseRef = baseRef,
          };
          var response = await ((NetSuitePortType)this).asyncGetListAsync(request);
          return response.asyncStatusResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncInitializeListAsync(SuiteTalk.InitializeRecord[] initializeRecord)
      {
          var request = new asyncInitializeListRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      initializeRecord = initializeRecord,
          };
          var response = await ((NetSuitePortType)this).asyncInitializeListAsync(request);
          return response.asyncStatusResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> asyncSearchAsync(SuiteTalk.SearchRecord searchRecord)
      {
          var request = new asyncSearchRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      searchPreferences = searchPreferences,
                      searchRecord = searchRecord,
          };
          var response = await ((NetSuitePortType)this).asyncSearchAsync(request);
          return response.asyncStatusResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncResult> getAsyncResultAsync(System.String jobId,System.Int32 pageIndex)
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
          var response = await ((NetSuitePortType)this).getAsyncResultAsync(request);
          return response.asyncResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.AsyncStatusResult> checkAsyncStatusAsync(System.String jobId)
      {
          var request = new checkAsyncStatusRequest() {
                      passport = passport,
                      tokenPassport = tokenPassport,
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      preferences = preferences,
                      jobId = jobId,
          };
          var response = await ((NetSuitePortType)this).checkAsyncStatusAsync(request);
          return response.asyncStatusResult;
      }

      public async System.Threading.Tasks.Task<SuiteTalk.GetDeletedResult> getDeletedAsync(SuiteTalk.GetDeletedFilter getDeletedFilter,System.Int32 pageIndex)
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
          var response = await ((NetSuitePortType)this).getDeletedAsync(request);
          return response.getDeletedResult;
      }

    }

    #pragma warning restore IDE1006 // Naming Styles
}
