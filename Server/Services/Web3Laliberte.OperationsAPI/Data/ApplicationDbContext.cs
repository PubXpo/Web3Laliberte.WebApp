using System;
using Microsoft.EntityFrameworkCore;
using Web3Laliberte.OperationsAPI.Model;
using Web3Laliberte.OperationsAPI.Model.Orders;
using Web3Laliberte.OperationsAPI.Models;

namespace Web3Laliberte.OperationsAPI.Data;


public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options) 
{
    
    // Add ContactLog DbSet
    public DbSet<ContactLog> ContactLogs { get; init; }
    
    // Add Order DbSet
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<Gift> Gifts { get; set; }
    
    // Add FAQ DbSet
    public DbSet<FAQ> FAQs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ContactLog Table Configuration
        modelBuilder.Entity<ContactLog>(entity =>
        {
            entity.ToTable("Web3Laliberte.ContactLogs");

            entity.HasKey(p => p.Id);
            entity.Property(p => p.Id).IsRequired();
            entity.Property(p => p.Name).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Subject).IsRequired().HasMaxLength(50);
            entity.Property(p => p.Message).IsRequired();
            entity.Property(p => p.CreatedAt).IsRequired();
            
            // Seed data
            entity.HasData(
                new ContactLog
                {
                    Id = Guid.NewGuid(),
                    Name = "Alice Johnson",
                    Email = "alice.johnson@example.com",
                    Subject = "Inquiry about services",
                    Message = "I would like to know more about your services.",
                    CreatedAt = DateTime.UtcNow
                },
                new ContactLog
                {
                    Id = Guid.NewGuid(),
                    Name = "Bob Smith",
                    Email = "bob.smith@example.com",
                    Subject = "Support request",
                    Message = "I need help with my account.",
                    CreatedAt = DateTime.UtcNow
                },
                new ContactLog
                {
                    Id = Guid.NewGuid(),
                    Name = "Charlie Brown",
                    Email = "charlie.brown@example.com",
                    Subject = "Feedback",
                    Message = "Great service! Keep it up.",
                    CreatedAt = DateTime.UtcNow
                });

        });
        
        // Order Tables Configuration
        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.ToTable("Web3Laliberte.Orders.Transactions");
            entity.HasKey(t => t.TransactionId);
            entity.Property(t => t.Amount).IsRequired();
            entity.Property(t => t.Date).IsRequired();
            entity.Property(t => t.PaymentMethod).IsRequired().HasMaxLength(50);
            entity.Property(t => t.Status).HasMaxLength(20).IsRequired();

            // User and billing details
            entity.Property(t => t.Title).HasMaxLength(10);
            entity.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(t => t.Surname).IsRequired().HasMaxLength(50);
            entity.Property(t => t.Email).IsRequired().HasMaxLength(100);
            entity.Property(t => t.Postcode).IsRequired().HasMaxLength(20);
            entity.Property(t => t.AddressLine1).IsRequired().HasMaxLength(100);
            entity.Property(t => t.AddressLine2).HasMaxLength(100);
            entity.Property(t => t.City).IsRequired().HasMaxLength(50);
            entity.Property(t => t.EmailUpdates).HasMaxLength(5);

            entity.HasOne(t => t.Band)
                .WithMany()
                .HasForeignKey(t => t.BandId);
            
            
            // Seed data
            entity.HasData(
                new Transaction
                {
                    TransactionId = Guid.NewGuid(),
                    BandId = 1,
                    Amount = 50,
                    Date = DateTime.UtcNow,
                    PaymentMethod = "Credit Card",
                    Status = "Completed",
                    Title = "Mr",
                    FirstName = "John",
                    Surname = "Doe",
                    Email = "john.doe@example.com",
                    Postcode = "12345",
                    AddressLine1 = "123 Main St",
                    AddressLine2 = "Apt 4B",
                    City = "Anytown",
                    EmailUpdates = "yes"
                },
                new Transaction
                {
                    TransactionId = Guid.NewGuid(),
                    BandId = 2,
                    Amount = 75,
                    Date = DateTime.UtcNow,
                    PaymentMethod = "PayPal",
                    Status = "Pending",
                    Title = "Ms",
                    FirstName = "Jane",
                    Surname = "Smith",
                    Email = "jane.smith@example.com",
                    Postcode = "67890",
                    AddressLine1 = "456 Elm St",
                    AddressLine2 = "Suite 1A",
                    City = "Othertown",
                    EmailUpdates = "no"
                }
            );
        });

        //// Band Tables Configuration
        modelBuilder.Entity<Band>(entity =>
        {
            entity.ToTable("Web3Laliberte.Orders.Bands");
            entity.HasKey(b => b.BandId);
            entity.Property(b => b.Name).IsRequired().HasMaxLength(100);
            
            
            entity.HasMany(b => b.Gifts)
                .WithOne(g => g.Band)
                .HasForeignKey(g => g.BandId);
           
            // Seed data
            entity.HasData(
                new Band { BandId = 1, Name = "Band 1" },
                new Band { BandId = 2, Name = "Band 2" },
                new Band { BandId = 3, Name = "Band 3" }
            );
        });

        //// Gift Tables Configuration
        modelBuilder.Entity<Gift>(entity =>
        {
            entity.ToTable("Web3Laliberte.Orders.Gifts");
            entity.HasKey(g => g.GiftId);
            entity.Property(g => g.Name).IsRequired().HasMaxLength(100);
            entity.Property(g => g.Description).HasMaxLength(500);
            entity.Property(g => g.InventoryAmount).IsRequired(); 

            entity.HasOne(g => g.Band)
                .WithMany(b => b.Gifts)
                .HasForeignKey(g => g.BandId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Seed data
            entity.HasData(
                new Gift { GiftId = Guid.NewGuid(), BandId = 1, Name = "Pin", Description = "A beautiful pin", InventoryAmount = 100 },
                new Gift { GiftId = Guid.NewGuid(), BandId = 1, Name = "Welcome Magazine", Description = "Exclusive Welcome Magazine", InventoryAmount = 50 },
                new Gift { GiftId = Guid.NewGuid(), BandId = 2, Name = "Tote Bag", Description = "Limited-edition tote bag", InventoryAmount = 30 },
                new Gift { GiftId = Guid.NewGuid(), BandId = 3, Name = "Virtual Tour", Description = "Behind-the-scenes virtual tour", InventoryAmount = 10 },
                new Gift { GiftId = Guid.NewGuid(), BandId = 3, Name = "Thank-you Certificate", Description = "Thank-you certificate", InventoryAmount = 20 }
            );
        });
        
        // FAQ Table Configuration
        modelBuilder.Entity<FAQ>(entity =>
        {
            entity.ToTable("Web3Laliberte.FAQs");
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Question).IsRequired().HasMaxLength(500);
            entity.Property(f => f.Answer).IsRequired().HasMaxLength(2000);

            entity.HasData(
                new FAQ { Id = 1, Question = "What is Web3, and how does it differ from Web2?", Answer = "Web3 represents the next generation of the internet, built on decentralized blockchain technology. Unlike Web2, where data is controlled by a few large companies, Web3 gives users control over their own data and digital assets, promoting privacy and security." },
                new FAQ { Id = 2, Question = "How can blockchain help in social and economic empowerment?", Answer = "Blockchain can help by creating transparent and tamper-proof records, making financial services accessible to underserved communities, and enabling new economic models that directly benefit creators and participants." },
                new FAQ { Id = 3, Question = "What are NFTs, and how can they support charitable causes?", Answer = "NFTs (Non-Fungible Tokens) are unique digital assets verified on the blockchain. They can be used to raise funds for charitable causes by selling unique digital items or artworks, with proceeds going directly to the organization or cause." },
                new FAQ { Id = 4, Question = "How can Web3 Laliberte promote transparency and trust in charity work?", Answer = "Web3 Laliberte provides immutable records of transactions, ensuring transparency in how funds are used. This builds trust with donors, as they can verify where and how their contributions are spent." },
                new FAQ { Id = 5, Question = "What are DAOs, and how can they benefit nonprofit organizations?", Answer = "DAOs (Decentralized Autonomous Organizations) are groups organized on the blockchain with decision-making processes driven by community voting. Nonprofits can use DAOs to allow supporters to have a say in the organization’s initiatives, fostering transparency and community-driven impact." },
                new FAQ { Id = 6, Question = "How does decentralized identity protect personal information?", Answer = "Decentralized identity allows individuals to own and control their digital identities without relying on centralized entities, reducing risks of identity theft and personal data misuse. This can empower vulnerable populations with safe identity solutions." },
                new FAQ { Id = 7, Question = "What is a smart contract, and how can it be used in social impact projects?", Answer = "A smart contract is a self-executing contract with the terms written into code. In social impact, smart contracts can automate funding distributions or aid processes, ensuring funds are released only when specific conditions are met, reducing corruption and inefficiency." },
                new FAQ { Id = 8, Question = "How can Web3 support financial inclusion?", Answer = "Web3 can support financial inclusion by enabling peer-to-peer transactions and access to financial services without traditional banks. This is crucial for unbanked populations, offering access to savings, loans, and other economic tools through decentralized finance (DeFi)." },
                new FAQ { Id = 9, Question = "What is regenerative finance (ReFi), and why is it important?", Answer = "Regenerative finance, or ReFi, focuses on building financial systems that restore and sustain social and environmental health. ReFi projects aim to address climate change, promote economic equity, and empower communities through sustainable financial solutions." },
                new FAQ { Id = 10, Question = "How does blockchain improve transparency in supply chains for fair trade?", Answer = "Blockchain technology can record each step in a product’s journey from producer to consumer, providing transparency in supply chains. This is valuable for fair trade, as it allows consumers to verify ethical practices and ensure fair compensation for producers." }
            );
        });

    }
}
