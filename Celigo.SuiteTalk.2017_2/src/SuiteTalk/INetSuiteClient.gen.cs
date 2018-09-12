namespace SuiteTalk
{
    #pragma warning disable IDE1006 // Naming Styles

    public partial interface INetSuiteClient
    {
        System.Threading.Tasks.Task<SessionResponse> loginAsync();
        System.Threading.Tasks.Task<SessionResponse> ssoLoginAsync(SsoPassport ssoPassport);
        System.Threading.Tasks.Task<SessionResponse> mapSsoAsync(SsoCredentials ssoCredentials);
        System.Threading.Tasks.Task<SessionResponse> changePasswordAsync(ChangePassword changePassword);
        System.Threading.Tasks.Task<SessionResponse> changeEmailAsync(ChangeEmail changeEmail);
        System.Threading.Tasks.Task<SessionResponse> logoutAsync();
        System.Threading.Tasks.Task<WriteResponse> addAsync(Record record);
        System.Threading.Tasks.Task<WriteResponse> deleteAsync(BaseRef baseRef,DeletionReason deletionReason);
        System.Threading.Tasks.Task<SearchResult> searchAsync(SearchRecord searchRecord);
        System.Threading.Tasks.Task<SearchResult> searchMoreAsync(int pageIndex);
        System.Threading.Tasks.Task<SearchResult> searchMoreWithIdAsync(string searchId,int pageIndex);
        System.Threading.Tasks.Task<SearchResult> searchNextAsync();
        System.Threading.Tasks.Task<WriteResponse> updateAsync(Record record);
        System.Threading.Tasks.Task<WriteResponse> upsertAsync(Record record);
        System.Threading.Tasks.Task<WriteResponseList> addListAsync(Record[] record);
        System.Threading.Tasks.Task<WriteResponseList> deleteListAsync(BaseRef[] baseRef,DeletionReason deletionReason);
        System.Threading.Tasks.Task<WriteResponseList> updateListAsync(Record[] record);
        System.Threading.Tasks.Task<WriteResponseList> upsertListAsync(Record[] record);
        System.Threading.Tasks.Task<ReadResponse> getAsync(BaseRef baseRef);
        System.Threading.Tasks.Task<ReadResponseList> getListAsync(BaseRef[] baseRef);
        System.Threading.Tasks.Task<GetAllResult> getAllAsync(GetAllRecord record);
        System.Threading.Tasks.Task<GetSavedSearchResult> getSavedSearchAsync(GetSavedSearchRecord record);
        System.Threading.Tasks.Task<GetCustomizationIdResult> getCustomizationIdAsync(CustomizationType customizationType,bool includeInactives);
        System.Threading.Tasks.Task<ReadResponse> initializeAsync(InitializeRecord initializeRecord);
        System.Threading.Tasks.Task<ReadResponseList> initializeListAsync(InitializeRecord[] initializeRecord);
        System.Threading.Tasks.Task<GetSelectValueResult> getSelectValueAsync(GetSelectValueFieldDescription fieldDescription,int pageIndex);
        System.Threading.Tasks.Task<GetItemAvailabilityResult> getItemAvailabilityAsync(ItemAvailabilityFilter itemAvailabilityFilter);
        System.Threading.Tasks.Task<GetBudgetExchangeRateResult> getBudgetExchangeRateAsync(BudgetExchangeRateFilter budgetExchangeRateFilter);
        System.Threading.Tasks.Task<GetCurrencyRateResult> getCurrencyRateAsync(CurrencyRateFilter currencyRateFilter);
        System.Threading.Tasks.Task<GetDataCenterUrlsResult> getDataCenterUrlsAsync(string account);
        System.Threading.Tasks.Task<GetPostingTransactionSummaryResult> getPostingTransactionSummaryAsync(PostingTransactionSummaryField fields,PostingTransactionSummaryFilter filters,int pageIndex,string operationId);
        System.Threading.Tasks.Task<GetServerTimeResult> getServerTimeAsync();
        System.Threading.Tasks.Task<WriteResponse> attachAsync(AttachReference attachReference);
        System.Threading.Tasks.Task<WriteResponse> detachAsync(DetachReference detachReference);
        System.Threading.Tasks.Task<WriteResponse> updateInviteeStatusAsync(UpdateInviteeStatusReference updateInviteeStatusReference);
        System.Threading.Tasks.Task<WriteResponseList> updateInviteeStatusListAsync(UpdateInviteeStatusReference[] updateInviteeStatusReference);
        System.Threading.Tasks.Task<AsyncStatusResult> asyncAddListAsync(Record[] record);
        System.Threading.Tasks.Task<AsyncStatusResult> asyncUpdateListAsync(Record[] record);
        System.Threading.Tasks.Task<AsyncStatusResult> asyncUpsertListAsync(Record[] record);
        System.Threading.Tasks.Task<AsyncStatusResult> asyncDeleteListAsync(BaseRef[] baseRef,DeletionReason deletionReason);
        System.Threading.Tasks.Task<AsyncStatusResult> asyncGetListAsync(BaseRef[] baseRef);
        System.Threading.Tasks.Task<AsyncStatusResult> asyncInitializeListAsync(InitializeRecord[] initializeRecord);
        System.Threading.Tasks.Task<AsyncStatusResult> asyncSearchAsync(SearchRecord searchRecord);
        System.Threading.Tasks.Task<AsyncResult> getAsyncResultAsync(string jobId,int pageIndex);
        System.Threading.Tasks.Task<AsyncStatusResult> checkAsyncStatusAsync(string jobId);
        System.Threading.Tasks.Task<GetDeletedResult> getDeletedAsync(GetDeletedFilter getDeletedFilter,int pageIndex);
    }

    public partial class NetSuitePortTypeClient: INetSuiteClient
    {
      public virtual async System.Threading.Tasks.Task<SessionResponse> loginAsync()
      {
          var request = new loginRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      passport = passport,
          };
          var response = await ((NetSuitePortType)this).loginAsync(request);
          return response.sessionResponse;
      }

      public virtual async System.Threading.Tasks.Task<SessionResponse> ssoLoginAsync(SsoPassport ssoPassport)
      {
          var request = new ssoLoginRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      ssoPassport = ssoPassport,
          };
          var response = await ((NetSuitePortType)this).ssoLoginAsync(request);
          return response.sessionResponse;
      }

      public virtual async System.Threading.Tasks.Task<SessionResponse> mapSsoAsync(SsoCredentials ssoCredentials)
      {
          var request = new mapSsoRequest() {
                      applicationInfo = applicationInfo,
                      partnerInfo = partnerInfo,
                      ssoCredentials = ssoCredentials,
          };
          var response = await ((NetSuitePortType)this).mapSsoAsync(request);
          return response.sessionResponse;
      }

      public virtual async System.Threading.Tasks.Task<SessionResponse> changePasswordAsync(ChangePassword changePassword)
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

      public virtual async System.Threading.Tasks.Task<SessionResponse> changeEmailAsync(ChangeEmail changeEmail)
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

      public virtual async System.Threading.Tasks.Task<SessionResponse> logoutAsync()
      {
          var request = new logoutRequest() {
                      applicationInfo = applicationInfo,
          };
          var response = await ((NetSuitePortType)this).logoutAsync(request);
          return response.sessionResponse;
      }

      public virtual async System.Threading.Tasks.Task<WriteResponse> addAsync(Record record)
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

      public virtual async System.Threading.Tasks.Task<WriteResponse> deleteAsync(BaseRef baseRef,DeletionReason deletionReason)
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

      public virtual async System.Threading.Tasks.Task<SearchResult> searchAsync(SearchRecord searchRecord)
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

      public virtual async System.Threading.Tasks.Task<SearchResult> searchMoreAsync(int pageIndex)
      {
          var request = new searchMoreRequest() {
                      applicationInfo = applicationInfo,
                      searchPreferences = searchPreferences,
                      pageIndex = pageIndex,
          };
          var response = await ((NetSuitePortType)this).searchMoreAsync(request);
          return response.searchResult;
      }

      public virtual async System.Threading.Tasks.Task<SearchResult> searchMoreWithIdAsync(string searchId,int pageIndex)
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

      public virtual async System.Threading.Tasks.Task<SearchResult> searchNextAsync()
      {
          var request = new searchNextRequest() {
                      applicationInfo = applicationInfo,
                      searchPreferences = searchPreferences,
          };
          var response = await ((NetSuitePortType)this).searchNextAsync(request);
          return response.searchResult;
      }

      public virtual async System.Threading.Tasks.Task<WriteResponse> updateAsync(Record record)
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

      public virtual async System.Threading.Tasks.Task<WriteResponse> upsertAsync(Record record)
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

      public virtual async System.Threading.Tasks.Task<WriteResponseList> addListAsync(Record[] record)
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

      public virtual async System.Threading.Tasks.Task<WriteResponseList> deleteListAsync(BaseRef[] baseRef,DeletionReason deletionReason)
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

      public virtual async System.Threading.Tasks.Task<WriteResponseList> updateListAsync(Record[] record)
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

      public virtual async System.Threading.Tasks.Task<WriteResponseList> upsertListAsync(Record[] record)
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

      public virtual async System.Threading.Tasks.Task<ReadResponse> getAsync(BaseRef baseRef)
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

      public virtual async System.Threading.Tasks.Task<ReadResponseList> getListAsync(BaseRef[] baseRef)
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

      public virtual async System.Threading.Tasks.Task<GetAllResult> getAllAsync(GetAllRecord record)
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

      public virtual async System.Threading.Tasks.Task<GetSavedSearchResult> getSavedSearchAsync(GetSavedSearchRecord record)
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

      public virtual async System.Threading.Tasks.Task<GetCustomizationIdResult> getCustomizationIdAsync(CustomizationType customizationType,bool includeInactives)
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

      public virtual async System.Threading.Tasks.Task<ReadResponse> initializeAsync(InitializeRecord initializeRecord)
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

      public virtual async System.Threading.Tasks.Task<ReadResponseList> initializeListAsync(InitializeRecord[] initializeRecord)
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

      public virtual async System.Threading.Tasks.Task<GetSelectValueResult> getSelectValueAsync(GetSelectValueFieldDescription fieldDescription,int pageIndex)
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

      public virtual async System.Threading.Tasks.Task<GetItemAvailabilityResult> getItemAvailabilityAsync(ItemAvailabilityFilter itemAvailabilityFilter)
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

      public virtual async System.Threading.Tasks.Task<GetBudgetExchangeRateResult> getBudgetExchangeRateAsync(BudgetExchangeRateFilter budgetExchangeRateFilter)
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

      public virtual async System.Threading.Tasks.Task<GetCurrencyRateResult> getCurrencyRateAsync(CurrencyRateFilter currencyRateFilter)
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

      public virtual async System.Threading.Tasks.Task<GetDataCenterUrlsResult> getDataCenterUrlsAsync(string account)
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

      public virtual async System.Threading.Tasks.Task<GetPostingTransactionSummaryResult> getPostingTransactionSummaryAsync(PostingTransactionSummaryField fields,PostingTransactionSummaryFilter filters,int pageIndex,string operationId)
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

      public virtual async System.Threading.Tasks.Task<GetServerTimeResult> getServerTimeAsync()
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

      public virtual async System.Threading.Tasks.Task<WriteResponse> attachAsync(AttachReference attachReference)
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

      public virtual async System.Threading.Tasks.Task<WriteResponse> detachAsync(DetachReference detachReference)
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

      public virtual async System.Threading.Tasks.Task<WriteResponse> updateInviteeStatusAsync(UpdateInviteeStatusReference updateInviteeStatusReference)
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

      public virtual async System.Threading.Tasks.Task<WriteResponseList> updateInviteeStatusListAsync(UpdateInviteeStatusReference[] updateInviteeStatusReference)
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

      public virtual async System.Threading.Tasks.Task<AsyncStatusResult> asyncAddListAsync(Record[] record)
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

      public virtual async System.Threading.Tasks.Task<AsyncStatusResult> asyncUpdateListAsync(Record[] record)
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

      public virtual async System.Threading.Tasks.Task<AsyncStatusResult> asyncUpsertListAsync(Record[] record)
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

      public virtual async System.Threading.Tasks.Task<AsyncStatusResult> asyncDeleteListAsync(BaseRef[] baseRef,DeletionReason deletionReason)
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

      public virtual async System.Threading.Tasks.Task<AsyncStatusResult> asyncGetListAsync(BaseRef[] baseRef)
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

      public virtual async System.Threading.Tasks.Task<AsyncStatusResult> asyncInitializeListAsync(InitializeRecord[] initializeRecord)
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

      public virtual async System.Threading.Tasks.Task<AsyncStatusResult> asyncSearchAsync(SearchRecord searchRecord)
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

      public virtual async System.Threading.Tasks.Task<AsyncResult> getAsyncResultAsync(string jobId,int pageIndex)
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

      public virtual async System.Threading.Tasks.Task<AsyncStatusResult> checkAsyncStatusAsync(string jobId)
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

      public virtual async System.Threading.Tasks.Task<GetDeletedResult> getDeletedAsync(GetDeletedFilter getDeletedFilter,int pageIndex)
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
