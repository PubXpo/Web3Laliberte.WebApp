﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web3Laliberte.OperationsAPI.Data;

#nullable disable

namespace Web3Laliberte.OperationsAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250103151319_prod")]
    partial class prod
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Web3Laliberte.OperationsAPI.Model.ContactLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Web3Laliberte.ContactLogs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5cc361b9-afce-4490-b4a1-3139b224a758"),
                            CreatedAt = new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5368),
                            Email = "alice.johnson@example.com",
                            Message = "I would like to know more about your services.",
                            Name = "Alice Johnson",
                            Subject = "Inquiry about services"
                        },
                        new
                        {
                            Id = new Guid("fc4a9e7c-94d3-4a4d-8097-eebbafa59cf4"),
                            CreatedAt = new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5379),
                            Email = "bob.smith@example.com",
                            Message = "I need help with my account.",
                            Name = "Bob Smith",
                            Subject = "Support request"
                        },
                        new
                        {
                            Id = new Guid("70a12d8a-bbbe-47b9-baba-3a09bc25d8ec"),
                            CreatedAt = new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(5390),
                            Email = "charlie.brown@example.com",
                            Message = "Great service! Keep it up.",
                            Name = "Charlie Brown",
                            Subject = "Feedback"
                        });
                });

            modelBuilder.Entity("Web3Laliberte.OperationsAPI.Model.Orders.Band", b =>
                {
                    b.Property<int>("BandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("BandId");

                    b.ToTable("Web3Laliberte.Orders.Bands", (string)null);

                    b.HasData(
                        new
                        {
                            BandId = 1,
                            Name = "Band 1"
                        },
                        new
                        {
                            BandId = 2,
                            Name = "Band 2"
                        },
                        new
                        {
                            BandId = 3,
                            Name = "Band 3"
                        });
                });

            modelBuilder.Entity("Web3Laliberte.OperationsAPI.Model.Orders.Gift", b =>
                {
                    b.Property<Guid>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("InventoryAmount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("GiftId");

                    b.HasIndex("BandId");

                    b.ToTable("Web3Laliberte.Orders.Gifts", (string)null);

                    b.HasData(
                        new
                        {
                            GiftId = new Guid("eb7e829a-d1cf-4cf3-8392-215ca55008e5"),
                            BandId = 1,
                            Description = "A beautiful pin",
                            InventoryAmount = 100,
                            Name = "Pin"
                        },
                        new
                        {
                            GiftId = new Guid("bc62b615-4db6-4208-927f-66f4bf1add76"),
                            BandId = 1,
                            Description = "Exclusive Welcome Magazine",
                            InventoryAmount = 50,
                            Name = "Welcome Magazine"
                        },
                        new
                        {
                            GiftId = new Guid("032917f0-041f-43e8-829a-2fb21ea008cf"),
                            BandId = 2,
                            Description = "Limited-edition tote bag",
                            InventoryAmount = 30,
                            Name = "Tote Bag"
                        },
                        new
                        {
                            GiftId = new Guid("86b56e12-e0dc-4254-9786-ccfd1962e215"),
                            BandId = 3,
                            Description = "Behind-the-scenes virtual tour",
                            InventoryAmount = 10,
                            Name = "Virtual Tour"
                        },
                        new
                        {
                            GiftId = new Guid("27e2c16f-5c31-4171-926f-6bda55bf71e5"),
                            BandId = 3,
                            Description = "Thank-you certificate",
                            InventoryAmount = 20,
                            Name = "Thank-you Certificate"
                        });
                });

            modelBuilder.Entity("Web3Laliberte.OperationsAPI.Model.Orders.Transaction", b =>
                {
                    b.Property<Guid>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("AddressLine2")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("BandId")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("EmailUpdates")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Postcode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("TransactionId");

                    b.HasIndex("BandId");

                    b.ToTable("Web3Laliberte.Orders.Transactions", (string)null);

                    b.HasData(
                        new
                        {
                            TransactionId = new Guid("807ca7ba-4ec3-4924-9a1e-75ca19522ab3"),
                            AddressLine1 = "123 Main St",
                            AddressLine2 = "Apt 4B",
                            Amount = 50m,
                            BandId = 1,
                            City = "Anytown",
                            Date = new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(8139),
                            Email = "john.doe@example.com",
                            EmailUpdates = "yes",
                            FirstName = "John",
                            PaymentMethod = "Credit Card",
                            Postcode = "12345",
                            Status = "Completed",
                            Surname = "Doe",
                            Title = "Mr"
                        },
                        new
                        {
                            TransactionId = new Guid("62afe848-acb6-4d4f-8d73-e75eee9f5626"),
                            AddressLine1 = "456 Elm St",
                            AddressLine2 = "Suite 1A",
                            Amount = 75m,
                            BandId = 2,
                            City = "Othertown",
                            Date = new DateTime(2025, 1, 3, 15, 13, 19, 220, DateTimeKind.Utc).AddTicks(8154),
                            Email = "jane.smith@example.com",
                            EmailUpdates = "no",
                            FirstName = "Jane",
                            PaymentMethod = "PayPal",
                            Postcode = "67890",
                            Status = "Pending",
                            Surname = "Smith",
                            Title = "Ms"
                        });
                });

            modelBuilder.Entity("Web3Laliberte.OperationsAPI.Models.FAQ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Question")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Web3Laliberte.FAQs", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Answer = "Web3 represents the next generation of the internet, built on decentralized blockchain technology. Unlike Web2, where data is controlled by a few large companies, Web3 gives users control over their own data and digital assets, promoting privacy and security.",
                            Question = "What is Web3, and how does it differ from Web2?"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "Blockchain can help by creating transparent and tamper-proof records, making financial services accessible to underserved communities, and enabling new economic models that directly benefit creators and participants.",
                            Question = "How can blockchain help in social and economic empowerment?"
                        },
                        new
                        {
                            Id = 3,
                            Answer = "NFTs (Non-Fungible Tokens) are unique digital assets verified on the blockchain. They can be used to raise funds for charitable causes by selling unique digital items or artworks, with proceeds going directly to the organization or cause.",
                            Question = "What are NFTs, and how can they support charitable causes?"
                        },
                        new
                        {
                            Id = 4,
                            Answer = "Web3 technologies like blockchain provide immutable records of transactions, ensuring transparency in how funds are used. This builds trust with donors, as they can verify where and how their contributions are spent.",
                            Question = "How can Web3 technologies promote transparency and trust in charity work?"
                        },
                        new
                        {
                            Id = 5,
                            Answer = "DAOs (Decentralized Autonomous Organizations) are groups organized on the blockchain with decision-making processes driven by community voting. Nonprofits can use DAOs to allow supporters to have a say in the organization’s initiatives, fostering transparency and community-driven impact.",
                            Question = "What are DAOs, and how can they benefit nonprofit organizations?"
                        },
                        new
                        {
                            Id = 6,
                            Answer = "Decentralized identity allows individuals to own and control their digital identities without relying on centralized entities, reducing risks of identity theft and personal data misuse. This can empower vulnerable populations with safe identity solutions.",
                            Question = "How does decentralized identity protect personal information?"
                        },
                        new
                        {
                            Id = 7,
                            Answer = "A smart contract is a self-executing contract with the terms written into code. In social impact, smart contracts can automate funding distributions or aid processes, ensuring funds are released only when specific conditions are met, reducing corruption and inefficiency.",
                            Question = "What is a smart contract, and how can it be used in social impact projects?"
                        },
                        new
                        {
                            Id = 8,
                            Answer = "Web3 can support financial inclusion by enabling peer-to-peer transactions and access to financial services without traditional banks. This is crucial for unbanked populations, offering access to savings, loans, and other economic tools through decentralized finance (DeFi).",
                            Question = "How can Web3 support financial inclusion?"
                        },
                        new
                        {
                            Id = 9,
                            Answer = "Regenerative finance, or ReFi, focuses on building financial systems that restore and sustain social and environmental health. ReFi projects aim to address climate change, promote economic equity, and empower communities through sustainable financial solutions.",
                            Question = "What is regenerative finance (ReFi), and why is it important?"
                        },
                        new
                        {
                            Id = 10,
                            Answer = "Blockchain technology can record each step in a product’s journey from producer to consumer, providing transparency in supply chains. This is valuable for fair trade, as it allows consumers to verify ethical practices and ensure fair compensation for producers.",
                            Question = "How does blockchain improve transparency in supply chains for fair trade?"
                        });
                });

            modelBuilder.Entity("Web3Laliberte.OperationsAPI.Model.Orders.Gift", b =>
                {
                    b.HasOne("Web3Laliberte.OperationsAPI.Model.Orders.Band", "Band")
                        .WithMany("Gifts")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");
                });

            modelBuilder.Entity("Web3Laliberte.OperationsAPI.Model.Orders.Transaction", b =>
                {
                    b.HasOne("Web3Laliberte.OperationsAPI.Model.Orders.Band", "Band")
                        .WithMany()
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");
                });

            modelBuilder.Entity("Web3Laliberte.OperationsAPI.Model.Orders.Band", b =>
                {
                    b.Navigation("Gifts");
                });
#pragma warning restore 612, 618
        }
    }
}
