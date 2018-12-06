namespace MovieStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCommonUser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense]) VALUES (N'9d8c0242-9295-402d-a990-ac1bc922e4b1', N'common@teste.com', 0, N'ADRifP8ye2bcDHVNXAC2U6PbrosZ1Y790hAVIfVSKw7h9dZpf1Vx+YAEpG3kT/7I8g==', N'839b28e7-906f-4570-b17c-3264167c47b3', N'12313', 0, 0, NULL, 1, 0, N'common@teste.com', N'1234')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd0f2e3af-7525-4c61-8099-10fecd1addb5', N'ReadOnlyUser')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9d8c0242-9295-402d-a990-ac1bc922e4b1', N'd0f2e3af-7525-4c61-8099-10fecd1addb5')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
