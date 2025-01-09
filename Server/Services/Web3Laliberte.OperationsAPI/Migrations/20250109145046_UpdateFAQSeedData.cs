using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Web3Laliberte.OperationsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFAQSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { new Guid("5c5749cf-e92c-41bd-86ff-59c8b1697c39"), new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(883), "bob.smith@example.com", "I need help with my account.", "Bob Smith", "Support request" },
                    { new Guid("9b8fb213-9ae2-4cd2-bd16-6d33d992dc80"), new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(893), "charlie.brown@example.com", "Great service! Keep it up.", "Charlie Brown", "Feedback" },
                    { new Guid("d4c96e80-ceca-4860-9f1a-f54a42c5c265"), new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(871), "alice.johnson@example.com", "I would like to know more about your services.", "Alice Johnson", "Inquiry about services" }
                });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Web3 Laliberté is a decentralised initiative focused on advancing privacy, security, and freedom in the digital sphere. By utilising Web3 technologies, we provide tools, educational resources, and advocacy to enable users to reclaim control over their data and online experiences.", "What is Web3 Laliberté, and how does it empower users?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Your generous donations will contribute to the development of privacy-focused technologies, advocacy for digital rights, and educational programmes designed to equip communities with safe digital practices.", "What specific projects will my donation support?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "We are committed to complying with relevant regulations to ensure the legality and sustainability of our operations. Simultaneously, we advocate for regulatory reforms that uphold digital rights and decentralisation principles, striving to balance compliance with our core mission.", "How does Web3 Laliberté address regulatory compliance while promoting decentralisation?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Decentralised technologies remove the reliance on intermediaries, reducing the risk of data misuse and empowering users with greater autonomy. This approach fosters a fairer and more user-focused digital ecosystem.", "How do decentralised technologies benefit users compared to traditional platforms?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "We prioritise your privacy by implementing robust security measures and decentralised identity solutions. These ensure your personal information remains secure and confidential throughout the donation process.", "What measures are in place to protect my personal information when donating?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "As a registered non-profit organisation, donations to Web3 Laliberté may be tax-deductible. We recommend consulting a tax professional to understand the specific benefits relevant to your circumstances.", "Are there any tax benefits associated with donating to Web3 Laliberté?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "We provide regular updates via our website and newsletters, detailing project progress and achieved outcomes. This ensures you remain informed about the positive impact your support is making.", "How can I stay informed about the impact of my donation?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Our donation platform employs advanced security protocols, including encryption and decentralised technologies, to protect your contributions and personal information from potential threats, ensuring a secure donation experience.", "What steps are taken to ensure the security of the donation platform?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "We offer a wide range of resources, such as workshops, articles, and tutorials, aimed at educating users on Web3 technologies, safe digital practices, and the advantages of decentralisation.", "What educational resources does Web3 Laliberté offer to help me understand and engage with Web3 technologies?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Beyond financial contributions, you can participate in community events, volunteer for initiatives, and advocate for digital rights by spreading awareness of our mission within your network.", "How can I get involved beyond donating to support Web3 Laliberté's mission?" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { new Guid("5cc361b9-afce-4490-b4a1-3139b224a758"), new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5368), "alice.johnson@example.com", "I would like to know more about your services.", "Alice Johnson", "Inquiry about services" },
                    { new Guid("70a12d8a-bbbe-47b9-baba-3a09bc25d8ec"), new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5390), "charlie.brown@example.com", "Great service! Keep it up.", "Charlie Brown", "Feedback" },
                    { new Guid("fc4a9e7c-94d3-4a4d-8097-eebbafa59cf4"), new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5379), "bob.smith@example.com", "I need help with my account.", "Bob Smith", "Support request" }
                });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Web3 represents the next generation of the internet, built on decentralized blockchain technology. Unlike Web2, where data is controlled by a few large companies, Web3 gives users control over their own data and digital assets, promoting privacy and security.", "What is Web3, and how does it differ from Web2?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Blockchain can help by creating transparent and tamper-proof records, making financial services accessible to underserved communities, and enabling new economic models that directly benefit creators and participants.", "How can blockchain help in social and economic empowerment?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "NFTs (Non-Fungible Tokens) are unique digital assets verified on the blockchain. They can be used to raise funds for charitable causes by selling unique digital items or artworks, with proceeds going directly to the organization or cause.", "What are NFTs, and how can they support charitable causes?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Web3 technologies like blockchain provide immutable records of transactions, ensuring transparency in how funds are used. This builds trust with donors, as they can verify where and how their contributions are spent.", "How can Web3 technologies promote transparency and trust in charity work?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "DAOs (Decentralized Autonomous Organizations) are groups organized on the blockchain with decision-making processes driven by community voting. Nonprofits can use DAOs to allow supporters to have a say in the organization’s initiatives, fostering transparency and community-driven impact.", "What are DAOs, and how can they benefit nonprofit organizations?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Decentralized identity allows individuals to own and control their digital identities without relying on centralized entities, reducing risks of identity theft and personal data misuse. This can empower vulnerable populations with safe identity solutions.", "How does decentralized identity protect personal information?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "A smart contract is a self-executing contract with the terms written into code. In social impact, smart contracts can automate funding distributions or aid processes, ensuring funds are released only when specific conditions are met, reducing corruption and inefficiency.", "What is a smart contract, and how can it be used in social impact projects?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Web3 can support financial inclusion by enabling peer-to-peer transactions and access to financial services without traditional banks. This is crucial for unbanked populations, offering access to savings, loans, and other economic tools through decentralized finance (DeFi).", "How can Web3 support financial inclusion?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Regenerative finance, or ReFi, focuses on building financial systems that restore and sustain social and environmental health. ReFi projects aim to address climate change, promote economic equity, and empower communities through sustainable financial solutions.", "What is regenerative finance (ReFi), and why is it important?" });

            migrationBuilder.UpdateData(
                table: "Web3Laliberte.FAQs",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Answer", "Question" },
                values: new object[] { "Blockchain technology can record each step in a product’s journey from producer to consumer, providing transparency in supply chains. This is valuable for fair trade, as it allows consumers to verify ethical practices and ensure fair compensation for producers.", "How does blockchain improve transparency in supply chains for fair trade?" });

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
    }
}
