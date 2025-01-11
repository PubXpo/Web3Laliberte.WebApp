using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web3Laliberte.OperationsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFAQSeedData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("5c5749cf-e92c-41bd-86ff-59c8b1697c39"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("9b8fb213-9ae2-4cd2-bd16-6d33d992dc80"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("d4c96e80-ceca-4860-9f1a-f54a42c5c265"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("19125802-0f64-4fd3-ada3-a3effab472a3"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("635d0b6b-c7c1-4421-ac7f-105b9f33c726"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("66a7218c-876c-4209-b907-96689d883908"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("86696995-b968-4b11-a561-1a656a456044"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("feed712b-0248-43a4-9f9e-ca51403ee8a3"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("545f1282-22d1-48f4-971e-f18c248876c3"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("9d750843-ddcf-4acd-9b68-8df710f29e67"));

            migrationBuilder.InsertData(
                table: "Web3Laliberte.ContactLogs",
                columns: new[] { "Id", "CreatedAt", "Email", "Message", "Name", "Subject" },
                values: new object[,]
                {
                    { new Guid("98ddfcd0-e06c-424c-bf10-792f217819d3"), new DateTime(2025, 1, 11, 15, 36, 44, 226, DateTimeKind.Utc).AddTicks(474), "alice.johnson@example.com", "I would like to know more about your services.", "Alice Johnson", "Inquiry about services" },
                    { new Guid("e5ab157e-8d3c-4c73-be61-9fd54855c375"), new DateTime(2025, 1, 11, 15, 36, 44, 226, DateTimeKind.Utc).AddTicks(486), "bob.smith@example.com", "I need help with my account.", "Bob Smith", "Support request" },
                    { new Guid("fcbebee8-6891-49bc-9d79-24badfc78b10"), new DateTime(2025, 1, 11, 15, 36, 44, 226, DateTimeKind.Utc).AddTicks(497), "charlie.brown@example.com", "Great service! Keep it up.", "Charlie Brown", "Feedback" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Gifts",
                columns: new[] { "GiftId", "BandId", "Description", "InventoryAmount", "Name" },
                values: new object[,]
                {
                    { new Guid("3b143465-b509-4bbd-bd2c-f3b899742dfc"), 2, "Limited-edition tote bag", 30, "Tote Bag" },
                    { new Guid("94f377da-4fae-41db-b859-b5c52d00e0e4"), 1, "A beautiful pin", 100, "Pin" },
                    { new Guid("b204917a-57e4-4e63-b476-e9a892b21ca6"), 1, "Exclusive Welcome Magazine", 50, "Welcome Magazine" },
                    { new Guid("c5163852-5fda-4ba4-a3d4-b817b392793e"), 3, "Behind-the-scenes virtual tour", 10, "Virtual Tour" },
                    { new Guid("d71d7cd9-3a2a-473f-85b6-e93061f7022d"), 3, "Thank-you certificate", 20, "Thank-you Certificate" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Transactions",
                columns: new[] { "TransactionId", "AddressLine1", "AddressLine2", "Amount", "BandId", "City", "Date", "Email", "EmailUpdates", "FirstName", "PaymentMethod", "Postcode", "Status", "Surname", "Title" },
                values: new object[,]
                {
                    { new Guid("4f0741b9-b842-4727-88a3-cffbe77a02b9"), "456 Elm St", "Suite 1A", 75m, 2, "Othertown", new DateTime(2025, 1, 11, 15, 36, 44, 226, DateTimeKind.Utc).AddTicks(4127), "jane.smith@example.com", "no", "Jane", "PayPal", "67890", "Pending", "Smith", "Ms" },
                    { new Guid("6145dace-72a2-48e0-89df-9dc585b22378"), "123 Main St", "Apt 4B", 50m, 1, "Anytown", new DateTime(2025, 1, 11, 15, 36, 44, 226, DateTimeKind.Utc).AddTicks(4114), "john.doe@example.com", "yes", "John", "Credit Card", "12345", "Completed", "Doe", "Mr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("98ddfcd0-e06c-424c-bf10-792f217819d3"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("e5ab157e-8d3c-4c73-be61-9fd54855c375"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("fcbebee8-6891-49bc-9d79-24badfc78b10"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("3b143465-b509-4bbd-bd2c-f3b899742dfc"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("94f377da-4fae-41db-b859-b5c52d00e0e4"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("b204917a-57e4-4e63-b476-e9a892b21ca6"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("c5163852-5fda-4ba4-a3d4-b817b392793e"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("d71d7cd9-3a2a-473f-85b6-e93061f7022d"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("4f0741b9-b842-4727-88a3-cffbe77a02b9"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("6145dace-72a2-48e0-89df-9dc585b22378"));

            migrationBuilder.InsertData(
                table: "Web3Laliberte.ContactLogs",
                columns: new[] { "Id", "CreatedAt", "Email", "Message", "Name", "Subject" },
                values: new object[,]
                {
                    { new Guid("5c5749cf-e92c-41bd-86ff-59c8b1697c39"), new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(883), "bob.smith@example.com", "I need help with my account.", "Bob Smith", "Support request" },
                    { new Guid("9b8fb213-9ae2-4cd2-bd16-6d33d992dc80"), new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(893), "charlie.brown@example.com", "Great service! Keep it up.", "Charlie Brown", "Feedback" },
                    { new Guid("d4c96e80-ceca-4860-9f1a-f54a42c5c265"), new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(871), "alice.johnson@example.com", "I would like to know more about your services.", "Alice Johnson", "Inquiry about services" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Gifts",
                columns: new[] { "GiftId", "BandId", "Description", "InventoryAmount", "Name" },
                values: new object[,]
                {
                    { new Guid("19125802-0f64-4fd3-ada3-a3effab472a3"), 3, "Thank-you certificate", 20, "Thank-you Certificate" },
                    { new Guid("635d0b6b-c7c1-4421-ac7f-105b9f33c726"), 1, "A beautiful pin", 100, "Pin" },
                    { new Guid("66a7218c-876c-4209-b907-96689d883908"), 1, "Exclusive Welcome Magazine", 50, "Welcome Magazine" },
                    { new Guid("86696995-b968-4b11-a561-1a656a456044"), 3, "Behind-the-scenes virtual tour", 10, "Virtual Tour" },
                    { new Guid("feed712b-0248-43a4-9f9e-ca51403ee8a3"), 2, "Limited-edition tote bag", 30, "Tote Bag" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Transactions",
                columns: new[] { "TransactionId", "AddressLine1", "AddressLine2", "Amount", "BandId", "City", "Date", "Email", "EmailUpdates", "FirstName", "PaymentMethod", "Postcode", "Status", "Surname", "Title" },
                values: new object[,]
                {
                    { new Guid("545f1282-22d1-48f4-971e-f18c248876c3"), "123 Main St", "Apt 4B", 50m, 1, "Anytown", new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(3580), "john.doe@example.com", "yes", "John", "Credit Card", "12345", "Completed", "Doe", "Mr" },
                    { new Guid("9d750843-ddcf-4acd-9b68-8df710f29e67"), "456 Elm St", "Suite 1A", 75m, 2, "Othertown", new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(3593), "jane.smith@example.com", "no", "Jane", "PayPal", "67890", "Pending", "Smith", "Ms" }
                });
        }
    }
}
