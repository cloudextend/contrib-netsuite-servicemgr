using System;
using System.Collections.Generic;
using System.Text;
using Celigo.ServiceManager.NetSuite.REST;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace _
{
    public class When_using_dependency_injection
    {
        [Fact]
        public void It_can_construct_a_RestletClient()
        {
            var settings = new Dictionary<string, string> {
                { RestClientOptions.ConfigurationSectionName + ":ConsumerKey", "CNSKEY"},
                { RestClientOptions.ConfigurationSectionName + ":ConsumerSecret", "CNSSEC" },
                { RestletConfig.ConfigurationSectionName + ":Script", "custscript1" },
                { RestletConfig.ConfigurationSectionName + ":Deploy", "custdeploy1" }
            };
                     
            var conf = new ConfigurationBuilder()
                .AddInMemoryCollection(settings)
                .Build();
 
            var svcCollection = new ServiceCollection()
                .AddNetSuiteRestClientSupport(conf)
                .Configure<RestletConfig>(conf.GetSection(RestletConfig.ConfigurationSectionName));
             
            svcCollection.AddHttpClient<IRestletClient, RestletClient>();
            var services = svcCollection.BuildServiceProvider();
         
            var client = services.GetService<IRestletClient>();
            client.Should().NotBeNull();
        }

        [Fact]
        public void It_can_construct_a_RestletClientFactory_with_multiple_restlets()
        {
            var clientFactory = CreateFactory();
            clientFactory.Should().NotBeNull();
        }

        [Fact]
        public void It_creates_a_factory_that_can_create_named_clients()
        {
            var clientFactory = CreateFactory();
            clientFactory.CreateClient("sample1").Should().NotBeNull();
            clientFactory.CreateClient("sample2").Should().NotBeNull();
            clientFactory.CreateClient("sample3").Should().NotBeNull();
        }

        private static IRestletClientFactory CreateFactory()
        {
            var settings = new Dictionary<string, string> {
                {RestClientOptions.ConfigurationSectionName + ":ConsumerKey", "CNSKEY"},
                {RestClientOptions.ConfigurationSectionName + ":ConsumerSecret", "CNSSEC"},

                {RestletConfig.ConfigurationSectionName + ":Restlets:0:Script", "custscript1"},
                {RestletConfig.ConfigurationSectionName + ":Restlets:0:Deploy", "custdeploy1"},
                {RestletConfig.ConfigurationSectionName + ":Restlets:0:RestletName", "sample1"},
                {RestletConfig.ConfigurationSectionName + ":Restlets:1:Script", "custscript2"},
                {RestletConfig.ConfigurationSectionName + ":Restlets:1:Deploy", "custdeploy2"},
                {RestletConfig.ConfigurationSectionName + ":Restlets:1:RestletName", "sample2"},
                {RestletConfig.ConfigurationSectionName + ":Restlets:2:Script", "custscript3"},
                {RestletConfig.ConfigurationSectionName + ":Restlets:2:Deploy", "custdeploy3"},
                {RestletConfig.ConfigurationSectionName + ":Restlets:2:RestletName", "sample3"},
            };

            var conf = new ConfigurationBuilder()
                .AddInMemoryCollection(settings)
                .Build();

            var svcCollection = new ServiceCollection().AddRestletClient(conf);

            svcCollection.AddHttpClient<IRestletClient, RestletClient>();
            var services = svcCollection.BuildServiceProvider();

            return services.GetService<IRestletClientFactory>();
        }
    }
}
