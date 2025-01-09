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
    [Migration("20250109145046_UpdateFAQSeedData")]
    partial class UpdateFAQSeedData
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
                            Id = new Guid("d4c96e80-ceca-4860-9f1a-f54a42c5c265"),
                            CreatedAt = new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(871),
                            Email = "alice.johnson@example.com",
                            Message = "I would like to know more about your services.",
                            Name = "Alice Johnson",
                            Subject = "Inquiry about services"
                        },
                        new
                        {
                            Id = new Guid("5c5749cf-e92c-41bd-86ff-59c8b1697c39"),
                            CreatedAt = new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(883),
                            Email = "bob.smith@example.com",
                            Message = "I need help with my account.",
                            Name = "Bob Smith",
                            Subject = "Support request"
                        },
                        new
                        {
                            Id = new Guid("9b8fb213-9ae2-4cd2-bd16-6d33d992dc80"),
                            CreatedAt = new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(893),
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
                            GiftId = new Guid("635d0b6b-c7c1-4421-ac7f-105b9f33c726"),
                            BandId = 1,
                            Description = "A beautiful pin",
                            InventoryAmount = 100,
                            Name = "Pin"
                        },
                        new
                        {
                            GiftId = new Guid("66a7218c-876c-4209-b907-96689d883908"),
                            BandId = 1,
                            Description = "Exclusive Welcome Magazine",
                            InventoryAmount = 50,
                            Name = "Welcome Magazine"
                        },
                        new
                        {
                            GiftId = new Guid("feed712b-0248-43a4-9f9e-ca51403ee8a3"),
                            BandId = 2,
                            Description = "Limited-edition tote bag",
                            InventoryAmount = 30,
                            Name = "Tote Bag"
                        },
                        new
                        {
                            GiftId = new Guid("86696995-b968-4b11-a561-1a656a456044"),
                            BandId = 3,
                            Description = "Behind-the-scenes virtual tour",
                            InventoryAmount = 10,
                            Name = "Virtual Tour"
                        },
                        new
                        {
                            GiftId = new Guid("19125802-0f64-4fd3-ada3-a3effab472a3"),
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
                            TransactionId = new Guid("545f1282-22d1-48f4-971e-f18c248876c3"),
                            AddressLine1 = "123 Main St",
                            AddressLine2 = "Apt 4B",
                            Amount = 50m,
                            BandId = 1,
                            City = "Anytown",
                            Date = new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(3580),
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
                            TransactionId = new Guid("9d750843-ddcf-4acd-9b68-8df710f29e67"),
                            AddressLine1 = "456 Elm St",
                            AddressLine2 = "Suite 1A",
                            Amount = 75m,
                            BandId = 2,
                            City = "Othertown",
                            Date = new DateTime(2025, 1, 9, 14, 50, 45, 667, DateTimeKind.Utc).AddTicks(3593),
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
                            Answer = "Web3 Laliberté is a decentralised initiative focused on advancing privacy, security, and freedom in the digital sphere. By utilising Web3 technologies, we provide tools, educational resources, and advocacy to enable users to reclaim control over their data and online experiences.",
                            Question = "What is Web3 Laliberté, and how does it empower users?"
                        },
                        new
                        {
                            Id = 2,
                            Answer = "Your generous donations will contribute to the development of privacy-focused technologies, advocacy for digital rights, and educational programmes designed to equip communities with safe digital practices.",
                            Question = "What specific projects will my donation support?"
                        },
                        new
                        {
                            Id = 3,
                            Answer = "We are committed to complying with relevant regulations to ensure the legality and sustainability of our operations. Simultaneously, we advocate for regulatory reforms that uphold digital rights and decentralisation principles, striving to balance compliance with our core mission.",
                            Question = "How does Web3 Laliberté address regulatory compliance while promoting decentralisation?"
                        },
                        new
                        {
                            Id = 4,
                            Answer = "Decentralised technologies remove the reliance on intermediaries, reducing the risk of data misuse and empowering users with greater autonomy. This approach fosters a fairer and more user-focused digital ecosystem.",
                            Question = "How do decentralised technologies benefit users compared to traditional platforms?"
                        },
                        new
                        {
                            Id = 5,
                            Answer = "We prioritise your privacy by implementing robust security measures and decentralised identity solutions. These ensure your personal information remains secure and confidential throughout the donation process.",
                            Question = "What measures are in place to protect my personal information when donating?"
                        },
                        new
                        {
                            Id = 6,
                            Answer = "As a registered non-profit organisation, donations to Web3 Laliberté may be tax-deductible. We recommend consulting a tax professional to understand the specific benefits relevant to your circumstances.",
                            Question = "Are there any tax benefits associated with donating to Web3 Laliberté?"
                        },
                        new
                        {
                            Id = 7,
                            Answer = "We provide regular updates via our website and newsletters, detailing project progress and achieved outcomes. This ensures you remain informed about the positive impact your support is making.",
                            Question = "How can I stay informed about the impact of my donation?"
                        },
                        new
                        {
                            Id = 8,
                            Answer = "Our donation platform employs advanced security protocols, including encryption and decentralised technologies, to protect your contributions and personal information from potential threats, ensuring a secure donation experience.",
                            Question = "What steps are taken to ensure the security of the donation platform?"
                        },
                        new
                        {
                            Id = 9,
                            Answer = "We offer a wide range of resources, such as workshops, articles, and tutorials, aimed at educating users on Web3 technologies, safe digital practices, and the advantages of decentralisation.",
                            Question = "What educational resources does Web3 Laliberté offer to help me understand and engage with Web3 technologies?"
                        },
                        new
                        {
                            Id = 10,
                            Answer = "Beyond financial contributions, you can participate in community events, volunteer for initiatives, and advocate for digital rights by spreading awareness of our mission within your network.",
                            Question = "How can I get involved beyond donating to support Web3 Laliberté's mission?"
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
