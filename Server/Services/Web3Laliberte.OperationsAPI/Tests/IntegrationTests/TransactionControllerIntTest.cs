using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Web3Laliberte.OperationsAPI.Tests.IntegrationTests
{
    public class TransactionControllerIntTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        private const string ApiUrl = "http://localhost:4000";

        public TransactionControllerIntTest()
        {
            var clientHandler = new HttpClientHandler();
            _client = new HttpClient(clientHandler) { BaseAddress = new Uri(ApiUrl) };
            _client.Timeout = TimeSpan.FromSeconds(30);
        }

        // Test cases for GET: api/v1/transaction

        [Fact]
        public async Task Get_ShouldReturnAllTransactions()
        {
            // Act
            var response = await _client.GetAsync("api/v1/transaction");

            // Assert
            response.EnsureSuccessStatusCode();
        }

        // Test cases for GET: api/v1/transaction/{id}

        [Fact]
        public async Task Get_ShouldReturnNotFoundForInvalidId()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var response = await _client.GetAsync($"api/v1/transaction/{id}");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        // Test cases for POST: api/v1/transaction

        [Fact]
        public async Task Post_ShouldCreateTransaction()
        {
            // Arrange
            var requestBody = new StringContent(
                """
                {
                    "amount": 100.00,
                    "bandId": 1,
                    "paymentMethod": "Credit Card",
                    "title": "Mr.",
                    "firstName": "John",
                    "surname": "Doe",
                    "email": "john.doe@example.com",
                    "postcode": "12345",
                    "addressLine1": "123 Main St",
                    "addressLine2": "Apt 4",
                    "city": "Anytown",
                    "emailUpdates": "true"
                }
                """,
                Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("api/v1/transaction", requestBody);

            // Assert
            response.EnsureSuccessStatusCode();
        }
        

        // Test cases for PUT: api/v1/transaction/{id}

        [Fact]
        public async Task Put_ShouldUpdateTransaction()
        {
            // Arrange
            var id = "f1efbd9d-44fc-4fac-991e-9f7b60e6dc2a";
            var requestBody = new StringContent(
                """
                {
                    "transactionId": "f1efbd9d-44fc-4fac-991e-9f7b60e6dc2a",
                    "amount": 150.00,
                    "bandId": 1,
                    "paymentMethod": "Credit Card",
                    "title": "Mr.",
                    "firstName": "John",
                    "surname": "Doe",
                    "email": "john.doe@example.com",
                    "postcode": "12345",
                    "addressLine1": "123 Main St",
                    "addressLine2": "Apt 4",
                    "city": "Anytown",
                    "emailUpdates": "true"
                }
                """,
                Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync($"api/v1/transaction/{id}", requestBody);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Put_ShouldReturnNotFoundForInvalidId()
        {
            // Arrange
            var id = Guid.NewGuid();
            var requestBody = new StringContent(
                """
                {
                    "transactionId": "00000000-0000-0000-0000-000000000000",
                    "amount": 150.00,
                    "bandId": 1,
                    "paymentMethod": "PayPal",
                    "title": "Mr.",
                    "firstName": "John",
                    "surname": "Doe",
                    "email": "john.doe@example.com",
                    "postcode": "12345",
                    "addressLine1": "123 Main St",
                    "addressLine2": "Apt 4",
                    "city": "Anytown",
                    "emailUpdates": "true"
                }
                """,
                Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PutAsync($"api/v1/transaction/{id}", requestBody);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
        
    }
}