using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web3Laliberte.OperationsAPI.Migrations
{
    /// <inheritdoc />
    public partial class prod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("022a5574-4343-4492-ba0a-aceaaec367ed"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("95fadfdb-062e-4796-bb1f-d5fc2a853077"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("980636d3-cb55-4f6c-915e-de15fe08af95"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("0c856372-7cc0-4151-9a9f-19b2b92ed6fb"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("160fe90b-a520-4bab-b829-274943861486"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("506c94bf-96b6-44b6-94d2-d774a845d2b7"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("a60e0dca-3ed9-48a0-8982-69515ecf5c11"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("ad2605c0-680b-4d6d-bc79-1df67b1a1106"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("075266b2-d5a1-417a-b760-598bda7b789e"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("3bc8555a-e10d-4aec-9122-ea0548cdeb88"));

            migrationBuilder.InsertData(
                table: "Web3Laliberte.ContactLogs",
                columns: new[] { "Id", "CreatedAt", "Email", "Message", "Name", "Subject" },
                values: new object[,]
                {
                    { new Guid("5cc361b9-afce-4490-b4a1-3139b224a758"), new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5368), "alice.johnson@example.com", "I would like to know more about your services.", "Alice Johnson", "Inquiry about services" },
                    { new Guid("70a12d8a-bbbe-47b9-baba-3a09bc25d8ec"), new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5390), "charlie.brown@example.com", "Great service! Keep it up.", "Charlie Brown", "Feedback" },
                    { new Guid("fc4a9e7c-94d3-4a4d-8097-eebbafa59cf4"), new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5379), "bob.smith@example.com", "I need help with my account.", "Bob Smith", "Support request" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Gifts",
                columns: new[] { "GiftId", "BandId", "Description", "InventoryAmount", "Name" },
                values: new object[,]
                {
                    { new Guid("032917f0-041f-43e8-829a-2fb21ea008cf"), 2, "Limited-edition tote bag", 30, "Tote Bag" },
                    { new Guid("27e2c16f-5c31-4171-926f-6bda55bf71e5"), 3, "Thank-you certificate", 20, "Thank-you Certificate" },
                    { new Guid("86b56e12-e0dc-4254-9786-ccfd1962e215"), 3, "Behind-the-scenes virtual tour", 10, "Virtual Tour" },
                    { new Guid("bc62b615-4db6-4208-927f-66f4bf1add76"), 1, "Exclusive Welcome Magazine", 50, "Welcome Magazine" },
                    { new Guid("eb7e829a-d1cf-4cf3-8392-215ca55008e5"), 1, "A beautiful pin", 100, "Pin" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Transactions",
                columns: new[] { "TransactionId", "AddressLine1", "AddressLine2", "Amount", "BandId", "City", "Date", "Email", "EmailUpdates", "FirstName", "PaymentMethod", "Postcode", "Status", "Surname", "Title" },
                values: new object[,]
                {
                    { new Guid("62afe848-acb6-4d4f-8d73-e75eee9f5626"), "456 Elm St", "Suite 1A", 75m, 2, "Othertown", new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(8154), "jane.smith@example.com", "no", "Jane", "PayPal", "67890", "Pending", "Smith", "Ms" },
                    { new Guid("807ca7ba-4ec3-4924-9a1e-75ca19522ab3"), "123 Main St", "Apt 4B", 50m, 1, "Anytown", new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(8139), "john.doe@example.com", "yes", "John", "Credit Card", "12345", "Completed", "Doe", "Mr" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("5cc361b9-afce-4490-b4a1-3139b224a758"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("70a12d8a-bbbe-47b9-baba-3a09bc25d8ec"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.ContactLogs",
                keyColumn: "Id",
                keyValue: new Guid("fc4a9e7c-94d3-4a4d-8097-eebbafa59cf4"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("032917f0-041f-43e8-829a-2fb21ea008cf"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("27e2c16f-5c31-4171-926f-6bda55bf71e5"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("86b56e12-e0dc-4254-9786-ccfd1962e215"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("bc62b615-4db6-4208-927f-66f4bf1add76"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Gifts",
                keyColumn: "GiftId",
                keyValue: new Guid("eb7e829a-d1cf-4cf3-8392-215ca55008e5"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("62afe848-acb6-4d4f-8d73-e75eee9f5626"));

            migrationBuilder.DeleteData(
                table: "Web3Laliberte.Orders.Transactions",
                keyColumn: "TransactionId",
                keyValue: new Guid("807ca7ba-4ec3-4924-9a1e-75ca19522ab3"));

            migrationBuilder.InsertData(
                table: "Web3Laliberte.ContactLogs",
                columns: new[] { "Id", "CreatedAt", "Email", "Message", "Name", "Subject" },
                values: new object[,]
                {
                    { new Guid("022a5574-4343-4492-ba0a-aceaaec367ed"), new DateTime(2024, 12, 29, 15, 57, 37, 940, DateTimeKind.Utc).AddTicks(9636), "bob.smith@example.com", "I need help with my account.", "Bob Smith", "Support request" },
                    { new Guid("95fadfdb-062e-4796-bb1f-d5fc2a853077"), new DateTime(2024, 12, 29, 15, 57, 37, 940, DateTimeKind.Utc).AddTicks(9622), "alice.johnson@example.com", "I would like to know more about your services.", "Alice Johnson", "Inquiry about services" },
                    { new Guid("980636d3-cb55-4f6c-915e-de15fe08af95"), new DateTime(2024, 12, 29, 15, 57, 37, 940, DateTimeKind.Utc).AddTicks(9649), "charlie.brown@example.com", "Great service! Keep it up.", "Charlie Brown", "Feedback" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Gifts",
                columns: new[] { "GiftId", "BandId", "Description", "InventoryAmount", "Name" },
                values: new object[,]
                {
                    { new Guid("0c856372-7cc0-4151-9a9f-19b2b92ed6fb"), 1, "Exclusive Welcome Magazine", 50, "Welcome Magazine" },
                    { new Guid("160fe90b-a520-4bab-b829-274943861486"), 1, "A beautiful pin", 100, "Pin" },
                    { new Guid("506c94bf-96b6-44b6-94d2-d774a845d2b7"), 3, "Thank-you certificate", 20, "Thank-you Certificate" },
                    { new Guid("a60e0dca-3ed9-48a0-8982-69515ecf5c11"), 2, "Limited-edition tote bag", 30, "Tote Bag" },
                    { new Guid("ad2605c0-680b-4d6d-bc79-1df67b1a1106"), 3, "Behind-the-scenes virtual tour", 10, "Virtual Tour" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Transactions",
                columns: new[] { "TransactionId", "AddressLine1", "AddressLine2", "Amount", "BandId", "City", "Date", "Email", "EmailUpdates", "FirstName", "PaymentMethod", "Postcode", "Status", "Surname", "Title" },
                values: new object[,]
                {
                    { new Guid("075266b2-d5a1-417a-b760-598bda7b789e"), "456 Elm St", "Suite 1A", 75m, 2, "Othertown", new DateTime(2024, 12, 29, 15, 57, 37, 941, DateTimeKind.Utc).AddTicks(3406), "jane.smith@example.com", "no", "Jane", "PayPal", "67890", "Pending", "Smith", "Ms" },
                    { new Guid("3bc8555a-e10d-4aec-9122-ea0548cdeb88"), "123 Main St", "Apt 4B", 50m, 1, "Anytown", new DateTime(2024, 12, 29, 15, 57, 37, 941, DateTimeKind.Utc).AddTicks(3390), "john.doe@example.com", "yes", "John", "Credit Card", "12345", "Completed", "Doe", "Mr" }
                });
        }
    }
}
