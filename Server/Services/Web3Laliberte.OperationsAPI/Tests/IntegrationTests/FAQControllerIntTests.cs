using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Web3Laliberte.OperationsAPI.Tests.IntegrationTests
{
    public class FAQControllerIntTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private const string ApiUrl = "http://localhost:4000";

        public FAQControllerIntTest()
        {
            var clientHandler = new HttpClientHandler();
            _client = new HttpClient(clientHandler) { BaseAddress = new Uri(ApiUrl) };
            _client.Timeout = TimeSpan.FromSeconds(30);
        }

        // Test cases for GET: api/v1/faq

        [Fact]
        public async Task Get_ShouldReturnAllFAQs()
        {
            // Act
            var response = await _client.GetAsync("api/v1/faq");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        // Test cases for GET: api/v1/faq/{id}

        [Fact]
        public async Task Get_ShouldReturnNotFoundForInvalidId()
        {
            // Arrange
            var id = 100001;

            // Act
            var response = await _client.GetAsync($"api/v1/faq/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // Test cases for POST: api/v1/faq

        [Fact]
        public async Task Post_ShouldCreateFAQ()
        {
            // Arrange
            var requestBody = new StringContent(
                """
                {
                    "question": "What is Web3 Laliberté?",
                    "answer": "Web3 Laliberté is a decentralised initiative focused on advancing privacy, security, and freedom in the digital sphere."
                }
                """,
                Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/v1/faq", requestBody);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        // Test cases for PUT: api/v1/faq/{id}

        [Fact]
        public async Task Put_ShouldUpdateFAQ()
        {
            // Arrange
            var id = 10;
            var requestBody = new StringContent(
                """
                {
                    "id": 10,
                    "question": "How can I get involved beyond donating to support Web3 Laliberté's mission?",
                    "answer": "Beyond financial contributions, you can participate in community events, volunteer for initiatives, and advocate for digital rights by spreading awareness of our mission within your network."
                }
                """,
                Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync($"api/v1/faq/{id}", requestBody);

            // Assert
            response.EnsureSuccessStatusCode();
        }

      
        // Test cases for DELETE: api/v1/faq/{id}

        [Fact]
        public async Task Delete_ShouldRemoveFAQ()
        {
            // Arrange
            var id = 20; // Assuming this ID exists in the database

            // Act
            var response = await _client.DeleteAsync($"api/v1/faq/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Delete_ShouldReturnNotFoundForInvalidId()
        {
            // Arrange
            var id = 100005;

            // Act
            var response = await _client.DeleteAsync($"api/v1/faq/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}