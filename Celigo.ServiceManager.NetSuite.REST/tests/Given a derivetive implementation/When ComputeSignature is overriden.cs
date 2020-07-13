using System;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using _.Utils;
using Celigo.ServiceManager.NetSuite.REST;
using FluentAssertions;
using FluentAssertions.Execution;
using Microsoft.Extensions.Options;
using Xunit;

namespace _.Given_a_derivetive_implementation
{
        
#if DEBUG
    public class When_ComputeSignature_is_overriden
    {
        private static readonly IOptions<RestClientOptions> _options = Options.Create(new RestClientOptions {
                                                                            ConsumerKey = "CNSKEY", 
                                                                            ConsumerSecret = "CNSSEC"
                                                                        });
        
        class Incorrect: RestClient
        {
            public Incorrect(): base(RestClientTestBase.CreateMockHttpClient(), _options) { }

            protected override string ComputeSignature(string baseString, string tokenSecret) => "new sig";
        }

        class Correct : RestClient
        {
            public override string SignatureAlgorithmName { get; } = "NEW-SIG";

            public Correct(): base(RestClientTestBase.CreateMockHttpClient(), _options) { }
            
            protected override string ComputeSignature(string baseString, string tokenSecret) => "new sig";
        }
        
        [Fact]
        public async Task It_will_fail_with_a_DebugAssert_if_Algorithm_name_property_is_not_also_overriden()
        {
            var incorrect = new Incorrect();
            try
            {
                await incorrect.Get("TSTDRV1234", new Uri("https://someserver.com"), "TKN", "SEC");
                Assert.False(true, "An assertion failure should have happened.");
            }
            catch (Exception e)
            {
                e.GetType().Name.Should().Contain("Assert");
            }
        }
        
        [Fact]
        public async Task It_will_not_fail_if_Algorithm_name_property_is_also_overriden()
        {
            var correct = new Correct();
            await correct.Get("TSTDRV1234", new Uri("https://someserver.com"), "TKN", "SEC");
            Assert.True(true);
        }
    }
#endif
}