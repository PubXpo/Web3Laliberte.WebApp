using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web3Laliberte.OperationsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Web3Laliberte.ContactLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Web3Laliberte.ContactLogs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Web3Laliberte.FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Answer = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Web3Laliberte.FAQs", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Web3Laliberte.Orders.Bands",
                columns: table => new
                {
                    BandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Web3Laliberte.Orders.Bands", x => x.BandId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Web3Laliberte.Orders.Gifts",
                columns: table => new
                {
                    GiftId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BandId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InventoryAmount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Web3Laliberte.Orders.Gifts", x => x.GiftId);
                    table.ForeignKey(
                        name: "FK_Web3Laliberte.Orders.Gifts_Web3Laliberte.Orders.Bands_BandId",
                        column: x => x.BandId,
                        principalTable: "Web3Laliberte.Orders.Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Web3Laliberte.Orders.Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    BandId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Title = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Postcode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailUpdates = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Web3Laliberte.Orders.Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Web3Laliberte.Orders.Transactions_Web3Laliberte.Orders.Bands~",
                        column: x => x.BandId,
                        principalTable: "Web3Laliberte.Orders.Bands",
                        principalColumn: "BandId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                table: "Web3Laliberte.FAQs",
                columns: new[] { "Id", "Answer", "Question" },
                values: new object[,]
                {
                    { 1, "Web3 represents the next generation of the internet, built on decentralized blockchain technology. Unlike Web2, where data is controlled by a few large companies, Web3 gives users control over their own data and digital assets, promoting privacy and security.", "What is Web3, and how does it differ from Web2?" },
                    { 2, "Blockchain can help by creating transparent and tamper-proof records, making financial services accessible to underserved communities, and enabling new economic models that directly benefit creators and participants.", "How can blockchain help in social and economic empowerment?" },
                    { 3, "NFTs (Non-Fungible Tokens) are unique digital assets verified on the blockchain. They can be used to raise funds for charitable causes by selling unique digital items or artworks, with proceeds going directly to the organization or cause.", "What are NFTs, and how can they support charitable causes?" },
                    { 4, "Web3 technologies like blockchain provide immutable records of transactions, ensuring transparency in how funds are used. This builds trust with donors, as they can verify where and how their contributions are spent.", "How can Web3 technologies promote transparency and trust in charity work?" },
                    { 5, "DAOs (Decentralized Autonomous Organizations) are groups organized on the blockchain with decision-making processes driven by community voting. Nonprofits can use DAOs to allow supporters to have a say in the organization’s initiatives, fostering transparency and community-driven impact.", "What are DAOs, and how can they benefit nonprofit organizations?" },
                    { 6, "Decentralized identity allows individuals to own and control their digital identities without relying on centralized entities, reducing risks of identity theft and personal data misuse. This can empower vulnerable populations with safe identity solutions.", "How does decentralized identity protect personal information?" },
                    { 7, "A smart contract is a self-executing contract with the terms written into code. In social impact, smart contracts can automate funding distributions or aid processes, ensuring funds are released only when specific conditions are met, reducing corruption and inefficiency.", "What is a smart contract, and how can it be used in social impact projects?" },
                    { 8, "Web3 can support financial inclusion by enabling peer-to-peer transactions and access to financial services without traditional banks. This is crucial for unbanked populations, offering access to savings, loans, and other economic tools through decentralized finance (DeFi).", "How can Web3 support financial inclusion?" },
                    { 9, "Regenerative finance, or ReFi, focuses on building financial systems that restore and sustain social and environmental health. ReFi projects aim to address climate change, promote economic equity, and empower communities through sustainable financial solutions.", "What is regenerative finance (ReFi), and why is it important?" },
                    { 10, "Blockchain technology can record each step in a product’s journey from producer to consumer, providing transparency in supply chains. This is valuable for fair trade, as it allows consumers to verify ethical practices and ensure fair compensation for producers.", "How does blockchain improve transparency in supply chains for fair trade?" }
                });

            migrationBuilder.InsertData(
                table: "Web3Laliberte.Orders.Bands",
                columns: new[] { "BandId", "Name" },
                values: new object[,]
                {
                    { 1, "Band 1" },
                    { 2, "Band 2" },
                    { 3, "Band 3" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Web3Laliberte.Orders.Gifts_BandId",
                table: "Web3Laliberte.Orders.Gifts",
                column: "BandId");

            migrationBuilder.CreateIndex(
                name: "IX_Web3Laliberte.Orders.Transactions_BandId",
                table: "Web3Laliberte.Orders.Transactions",
                column: "BandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Web3Laliberte.ContactLogs");

            migrationBuilder.DropTable(
                name: "Web3Laliberte.FAQs");

            migrationBuilder.DropTable(
                name: "Web3Laliberte.Orders.Gifts");

            migrationBuilder.DropTable(
                name: "Web3Laliberte.Orders.Transactions");

            migrationBuilder.DropTable(
                name: "Web3Laliberte.Orders.Bands");
        }
    }
}
