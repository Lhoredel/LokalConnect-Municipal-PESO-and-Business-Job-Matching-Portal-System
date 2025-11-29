namespace LokalConnect.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        BusinessId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Industry = c.String(maxLength: 100),
                        Description = c.String(),
                        Website = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                        IsVerified = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BusinessId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false),
                        CompanyName = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        JobType = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        Salary = c.Decimal(precision: 18, scale: 2),
                        PostedDate = c.DateTime(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        JobApplicationId = c.Int(nullable: false, identity: true),
                        JobId = c.Int(nullable: false),
                        JobSeekerId = c.Int(nullable: false),
                        ApplicationDate = c.DateTime(nullable: false),
                        CoverLetter = c.String(maxLength: 500),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.JobApplicationId)
                .ForeignKey("dbo.Jobs", t => t.JobId, cascadeDelete: true)
                .ForeignKey("dbo.JobSeekers", t => t.JobSeekerId, cascadeDelete: true)
                .Index(t => t.JobId)
                .Index(t => t.JobSeekerId);
            
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        JobSeekerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Skills = c.String(),
                        Education = c.String(),
                        Experience = c.String(),
                        ResumePath = c.String(),
                        RegistrationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.JobSeekerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobApplications", "JobSeekerId", "dbo.JobSeekers");
            DropForeignKey("dbo.JobApplications", "JobId", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "BusinessId", "dbo.Businesses");
            DropIndex("dbo.JobApplications", new[] { "JobSeekerId" });
            DropIndex("dbo.JobApplications", new[] { "JobId" });
            DropIndex("dbo.Jobs", new[] { "BusinessId" });
            DropTable("dbo.JobSeekers");
            DropTable("dbo.JobApplications");
            DropTable("dbo.Jobs");
            DropTable("dbo.Businesses");
        }
    }
}
