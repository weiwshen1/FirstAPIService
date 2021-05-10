using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Example.Service.ComponentTest
{
    public class Tests
    {
        private ComponentTestConfig testConfig = new ComponentTestConfig();

        [OneTimeSetUp]
        public void InitialSetup()
        {
            testConfig = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", false,false)
                .AddEnvironmentVariables()
                .Build()
                .GetSection("ComponentTests")
                .Get<ComponentTestConfig>();
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public async Task ShouldReturnAListOfStaticValues()
        {
            var httpClient = new HttpClient {BaseAddress = new Uri(testConfig.ServiceUri)};

            var response = await httpClient.GetAsync("api/values");
            var responseJson = await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();

            Assert.That(responseJson, Is.EqualTo("[\"value1\",\"value2\",\"Wei001\"]"));
        }
    }
}