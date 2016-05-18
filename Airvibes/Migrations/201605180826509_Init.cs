namespace Airvibes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Songs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Artist = c.Int(nullable: false),
                        Id_Record = c.Int(nullable: false),
                        Title = c.String(),
                        Duration = c.Int(nullable: false),
                        TimesPlayed = c.Int(nullable: false),
                        Rating = c.Int(),
                        LowQFile = c.Binary(),
                        HiQFile = c.Binary(),
                        Records_Id = c.Int(),
                        Artists_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Records", t => t.Records_Id)
                .ForeignKey("dbo.Artists", t => t.Artists_Id)
                .Index(t => t.Records_Id)
                .Index(t => t.Artists_Id);
            
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Photo = c.Int(),
                        Name = c.String(),
                        Bio = c.String(),
                        Photos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Photos", t => t.Photos_Id)
                .Index(t => t.Photos_Id);
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_Artist = c.Int(nullable: false),
                        Id_Cover = c.Int(),
                        Title = c.String(),
                        ReleaseDate = c.DateTime(),
                        Genre = c.String(),
                        Rating = c.Double(),
                        Artists_Id = c.Int(),
                        Covers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artists_Id)
                .ForeignKey("dbo.Covers", t => t.Covers_Id)
                .Index(t => t.Artists_Id)
                .Index(t => t.Covers_Id);
            
            CreateTable(
                "dbo.Covers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_User = c.Int(nullable: false),
                        Id_Record = c.Int(nullable: false),
                        Body = c.String(),
                        PostedAt = c.DateTime(nullable: false),
                        Records_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Records", t => t.Records_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Records_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SComments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Id_User = c.Int(nullable: false),
                        Id_Song = c.Int(nullable: false),
                        Body = c.String(),
                        PostedAt = c.DateTime(nullable: false),
                        Songs_Id = c.Int(),
                        Users_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Songs", t => t.Songs_Id)
                .ForeignKey("dbo.Users", t => t.Users_Id)
                .Index(t => t.Songs_Id)
                .Index(t => t.Users_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Nom = c.String(),
                        Prénom = c.String(),
                        DateNaissance = c.DateTime(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Songs", "Artists_Id", "dbo.Artists");
            DropForeignKey("dbo.Songs", "Records_Id", "dbo.Records");
            DropForeignKey("dbo.SComments", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.SComments", "Songs_Id", "dbo.Songs");
            DropForeignKey("dbo.RComments", "Users_Id", "dbo.Users");
            DropForeignKey("dbo.RComments", "Records_Id", "dbo.Records");
            DropForeignKey("dbo.Records", "Covers_Id", "dbo.Covers");
            DropForeignKey("dbo.Records", "Artists_Id", "dbo.Artists");
            DropForeignKey("dbo.Artists", "Photos_Id", "dbo.Photos");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.SComments", new[] { "Users_Id" });
            DropIndex("dbo.SComments", new[] { "Songs_Id" });
            DropIndex("dbo.RComments", new[] { "Users_Id" });
            DropIndex("dbo.RComments", new[] { "Records_Id" });
            DropIndex("dbo.Records", new[] { "Covers_Id" });
            DropIndex("dbo.Records", new[] { "Artists_Id" });
            DropIndex("dbo.Artists", new[] { "Photos_Id" });
            DropIndex("dbo.Songs", new[] { "Artists_Id" });
            DropIndex("dbo.Songs", new[] { "Records_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.SComments");
            DropTable("dbo.Users");
            DropTable("dbo.RComments");
            DropTable("dbo.Covers");
            DropTable("dbo.Records");
            DropTable("dbo.Photos");
            DropTable("dbo.Artists");
            DropTable("dbo.Songs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
