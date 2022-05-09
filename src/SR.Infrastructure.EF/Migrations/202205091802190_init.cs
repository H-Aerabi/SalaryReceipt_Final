namespace SR.Infrastructure.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MonthID = c.Int(nullable: false),
                        AcountNumber = c.String(maxLength: 30),
                        RullNumber = c.String(maxLength: 50),
                        CollaborationType = c.String(maxLength: 100),
                        MonthPerformance = c.Int(nullable: false),
                        MonthMessage = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Postings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JournalId = c.Int(nullable: false),
                        Title = c.String(maxLength: 100),
                        CurrentAmount = c.Long(nullable: false),
                        IsTitle = c.Boolean(nullable: false),
                        DeferredAmount = c.Long(nullable: false),
                        DebtAmount = c.Long(nullable: false),
                        AmountType = c.Int(nullable: false),
                        PaymentType = c.Int(nullable: false),
                        Remaining = c.Long(nullable: false),
                        InstallmentNumber = c.String(maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Journals", t => t.JournalId, cascadeDelete: true)
                .Index(t => t.JournalId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrganizationId = c.Int(nullable: false),
                        Code = c.String(nullable: false, maxLength: 10),
                        FullName = c.String(maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 500),
                        Email = c.String(),
                        PhoneNumber = c.String(maxLength: 13),
                        IsRemoved = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ActiceCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 14),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(maxLength: 500),
                        PhoneNumber = c.String(maxLength: 13),
                        Website = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Code, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Journals", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.Postings", "JournalId", "dbo.Journals");
            DropIndex("dbo.Organizations", new[] { "Code" });
            DropIndex("dbo.Users", new[] { "OrganizationId" });
            DropIndex("dbo.Postings", new[] { "JournalId" });
            DropIndex("dbo.Journals", new[] { "UserId" });
            DropTable("dbo.Organizations");
            DropTable("dbo.Users");
            DropTable("dbo.Postings");
            DropTable("dbo.Journals");
        }
    }
}
