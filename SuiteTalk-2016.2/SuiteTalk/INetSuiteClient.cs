using System.Threading.Tasks;

namespace SuiteTalk
{
    public interface INetSuiteClient
    {
#pragma warning disable IDE1006 // Naming Styles
        Task<loginResponse> loginAsync(Passport passport);
        Task<logoutResponse> logoutAsync();
        Task<addResponse> addAsync(Record record);
        Task<deleteResponse> deleteAsync(BaseRef baseRef, DeletionReason deletionReason);
        Task<searchResponse> searchAsync(SearchRecord searchRecord);
        Task<searchMoreResponse> searchMoreAsync(int pageIndex);
        Task<searchMoreWithIdResponse> searchMoreWithIdAsync(string searchId, int pageIndex);
        Task<searchNextResponse> searchNextAsync();
        Task<updateResponse> updateAsync(Record record);
        Task<upsertResponse> upsertAsync(Record record);
        Task<addListResponse> addListAsync(Record[] record);
        Task<deleteListResponse> deleteListAsync(BaseRef[] baseRef, DeletionReason deletionReason);
        Task<updateListResponse> updateListAsync(Record[] record);
        Task<upsertListResponse> upsertListAsync(Record[] record);
        Task<getResponse> getAsync(BaseRef baseRef);
        Task<getListResponse> getListAsync(BaseRef[] baseRef);
        Task<getAllResponse> getAllAsync(GetAllRecord record);
        Task<getSavedSearchResponse> getSavedSearchAsync(GetSavedSearchRecord record);
        Task<getCustomizationIdResponse> getCustomizationIdAsync(CustomizationType customizationType, bool includeInactives);
        Task<initializeResponse> initializeAsync(InitializeRecord initializeRecord);
        Task<initializeListResponse> initializeListAsync(InitializeRecord[] initializeRecord);
        Task<getSelectValueResponse> getSelectValueAsync(GetSelectValueFieldDescription fieldDescription, int pageIndex);
        Task<getItemAvailabilityResponse> getItemAvailabilityAsync(ItemAvailabilityFilter itemAvailabilityFilter);
        Task<getBudgetExchangeRateResponse> getBudgetExchangeRateAsync(BudgetExchangeRateFilter budgetExchangeRateFilter);
        Task<getConsolidatedExchangeRateResponse> getConsolidatedExchangeRateAsync(ConsolidatedExchangeRateFilter consolidatedExchangeRateFilter);
        Task<getCurrencyRateResponse> getCurrencyRateAsync(CurrencyRateFilter currencyRateFilter);
        Task<getDataCenterUrlsResponse> getDataCenterUrlsAsync(string account);
        Task<getPostingTransactionSummaryResponse> getPostingTransactionSummaryAsync(PostingTransactionSummaryField fields, PostingTransactionSummaryFilter filters, int pageIndex);
        Task<getServerTimeResponse> getServerTimeAsync();
        Task<attachResponse> attachAsync(AttachReference attachReference);
        Task<detachResponse> detachAsync(DetachReference detachReference);
        Task<updateInviteeStatusResponse> updateInviteeStatusAsync(UpdateInviteeStatusReference updateInviteeStatusReference);
        Task<updateInviteeStatusListResponse> updateInviteeStatusListAsync(UpdateInviteeStatusReference[] updateInviteeStatusReference);
        Task<asyncAddListResponse> asyncAddListAsync(Record[] record);
        Task<asyncUpdateListResponse> asyncUpdateListAsync(Record[] record);
        Task<asyncUpsertListResponse> asyncUpsertListAsync(Record[] record);
        Task<asyncDeleteListResponse> asyncDeleteListAsync(BaseRef[] baseRef, DeletionReason deletionReason);
        Task<asyncGetListResponse> asyncGetListAsync(BaseRef[] baseRef);
        Task<asyncInitializeListResponse> asyncInitializeListAsync(InitializeRecord[] initializeRecord);
        Task<asyncSearchResponse> asyncSearchAsync(SearchRecord searchRecord);
        Task<getAsyncResultResponse> getAsyncResultAsync(string jobId, int pageIndex);
        Task<checkAsyncStatusResponse> checkAsyncStatusAsync(string jobId);
        Task<getDeletedResponse> getDeletedAsync(GetDeletedFilter getDeletedFilter, int pageIndex);
#pragma warning restore IDE1006 // Naming Styles

    }

    public partial class NetSuitePortTypeClient : INetSuiteClient
    {
        public static System.ServiceModel.EndpointAddress GetDefaultEndpoint()
        {
            return GetDefaultEndpointAddress();
        }

        
    }
}
