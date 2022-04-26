using Celigo.ServiceManager.NetSuite;
using Polly;
using SuiteTalk;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;

namespace Tests.Celigo.ServiceManager.NetSuite.Retries
{
    class PollyNetSuiteClient: NetSuitePortTypeClient
    {
        private readonly IAsyncPolicy _retryPolicy;

        public List<Exception> UnsuccessfulStatuses { get; }

        public PollyNetSuiteClient()
        {
            this.UnsuccessfulStatuses = new List<Exception>();
            Random jitterer = new Random();
            _retryPolicy = Policy
                            .Handle<FaultException<ExceededRequestLimitFault>>()
                            .Or<FaultException<ExceededConcurrentRequestLimitFault>>()
                            .WaitAndRetryAsync(5,
                                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt))  // exponential back-off: 2, 4, 8 etc
                                                + TimeSpan.FromMilliseconds(jitterer.Next(0, 1000)), // plus some jitter: up to 1 second
                                onRetry: (response, timespan) => {
                                    this.UnsuccessfulStatuses.Add(response);
                                });
        }

        public override Task<SearchResult> searchAsync(SearchRecord searchRecord, SearchPreferences searchPreferences)
        {
            return _retryPolicy.ExecuteAsync(() => base.searchAsync(searchRecord, searchPreferences));
        }
    }
}
