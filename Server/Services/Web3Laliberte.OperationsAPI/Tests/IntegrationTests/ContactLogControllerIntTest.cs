using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Web3Laliberte.OperationsAPI.Tests.IntegrationTests
{
    public class ContactLogControllerIntTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private const string ApiUrl = "http://localhost:4000";

        public ContactLogControllerIntTest()
        {
            var clientHandler = new HttpClientHandler();
            _client = new HttpClient(clientHandler) { BaseAddress = new Uri(ApiUrl) };
            _client.Timeout = TimeSpan.FromSeconds(30);
        }

        // Test cases for GET: api/v1/contactlog

        [Fact]
        public async Task Get_ShouldReturnAllContactLogs()
        {
            // Act
            var response = await _client.GetAsync("api/v1/contactlog");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        // Test cases for GET: api/v1/contactlog/{id}

        [Fact]
        public async Task Get_ShouldReturnNotFoundForInvalidId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var response = await _client.GetAsync($"api/v1/contactlog/{id}");

            // Assert
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }

        // Test cases for POST: api/v1/contactlog

        [Fact]
        public async Task Post_ShouldCreateContactLog()
        {
            // Arrange
            var requestBody = new StringContent(
                """
                {
                    "name": "John Doe",
                    "email": "john.doe@example.com",
                    "subject": "Initial Contact",
                    "message": "This is a test message.",
                    "createdAt": "2024-10-01T00:00:00Z"
                }
                """,
                Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/v1/contactlog", requestBody);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Post_ShouldReturnBadRequestForInvalidData()
        {
            // Arrange
            var requestBody = new StringContent(
                """
                {
                    "name": "",
                    "email": "invalid-email",
                    "subject": "",
                    "message": "",
                    "createdAt": "invalid-date"
                }
                """,
                Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/v1/contactlog", requestBody);

            // Assert
            Assert.Throws<HttpRequestException>(() => response.EnsureSuccessStatusCode());
        }
        

        // Test cases for DELETE: api/v1/contactlog/{id}
        
        [Fact]
        public async Task Delete_ShouldRemoveContactLog()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var response = await _client.DeleteAsync($"api/v1/contactlog/{id}");

            // Assert
            response.EnsureSuccessStatusCode();
        }
    }
}