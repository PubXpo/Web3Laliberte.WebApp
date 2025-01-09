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
                new FAQ { Id = 1, Question = "What is Web3 Laliberté, and how does it empower users?", Answer = "Web3 Laliberté is a decentralised initiative focused on advancing privacy, security, and freedom in the digital sphere. By utilising Web3 technologies, we provide tools, educational resources, and advocacy to enable users to reclaim control over their data and online experiences." },
                new FAQ { Id = 2, Question = "What specific projects will my donation support?", Answer = "Your generous donations will contribute to the development of privacy-focused technologies, advocacy for digital rights, and educational programmes designed to equip communities with safe digital practices." },
                new FAQ { Id = 3, Question = "How does Web3 Laliberté address regulatory compliance while promoting decentralisation?", Answer = "We are committed to complying with relevant regulations to ensure the legality and sustainability of our operations. Simultaneously, we advocate for regulatory reforms that uphold digital rights and decentralisation principles, striving to balance compliance with our core mission." },
                new FAQ { Id = 4, Question = "How do decentralised technologies benefit users compared to traditional platforms?", Answer = "Decentralised technologies remove the reliance on intermediaries, reducing the risk of data misuse and empowering users with greater autonomy. This approach fosters a fairer and more user-focused digital ecosystem." },
                new FAQ { Id = 5, Question = "What measures are in place to protect my personal information when donating?", Answer = "We prioritise your privacy by implementing robust security measures and decentralised identity solutions. These ensure your personal information remains secure and confidential throughout the donation process." },
                new FAQ { Id = 6, Question = "Are there any tax benefits associated with donating to Web3 Laliberté?", Answer = "As a registered non-profit organisation, donations to Web3 Laliberté may be tax-deductible. We recommend consulting a tax professional to understand the specific benefits relevant to your circumstances." },
                new FAQ { Id = 7, Question = "How can I stay informed about the impact of my donation?", Answer = "We provide regular updates via our website and newsletters, detailing project progress and achieved outcomes. This ensures you remain informed about the positive impact your support is making." },
                new FAQ { Id = 8, Question = "What steps are taken to ensure the security of the donation platform?", Answer = "Our donation platform employs advanced security protocols, including encryption and decentralised technologies, to protect your contributions and personal information from potential threats, ensuring a secure donation experience." },
                new FAQ { Id = 9, Question = "What educational resources does Web3 Laliberté offer to help me understand and engage with Web3 technologies?", Answer = "We offer a wide range of resources, such as workshops, articles, and tutorials, aimed at educating users on Web3 technologies, safe digital practices, and the advantages of decentralisation." },
                new FAQ { Id = 10, Question = "How can I get involved beyond donating to support Web3 Laliberté's mission?", Answer = "Beyond financial contributions, you can participate in community events, volunteer for initiatives, and advocate for digital rights by spreading awareness of our mission within your network." }
            );
        });

    }
}
