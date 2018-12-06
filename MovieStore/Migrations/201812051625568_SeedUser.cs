namespace MovieStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'e0914afe-9338-4985-96b7-73d8b3db9173', N'admin@moviestore.com', 0, N'ABIZKddDjD7d7Sb+ErVPsyX1h1m5evxlQtDV7hR6zZNp5XkILoqI2m+aG+tA6SnXvA==', N'3a2d3d9d-c91d-4d76-a976-abf36157dde6', NULL, 0, 0, NULL, 1, 0, N'admin@moviestore.com')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd0f2e3af-7525-4c61-8099-10fecd1addb4', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'e0914afe-9338-4985-96b7-73d8b3db9173', N'd0f2e3af-7525-4c61-8099-10fecd1addb4')

");
        }
        
        public override void Down()
        {
        }
    }
}
