namespace RMovies.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
        INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2acb41c0-dc57-4abc-b95a-74bc8febd4f4', N'guest@Rmovies.com', 0, N'AAUrDaWQEE8IuEunknT6CGi1WfGtW7KQGxumstsGmu9SaOjer6Vvz/A//C5BfyKkdA==', N'22ea9175-5e86-4b1f-b12c-806c6f38f6aa', NULL, 0, 0, NULL, 1, 0, N'guest@Rmovies.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a62d9b0e-adb2-4752-81a0-ce8a9f4159ca', N'admin@Rmovies.com', 0, N'ALu0H9yTINdHVfgVNlbweUhjhCEKx8r3T5BIIdg8P3g+hWX/2Wm2odS5yg6n/PKslw==', N'e6c3acad-4ce7-4a13-a2fe-ee874b066f71', NULL, 0, 0, NULL, 1, 0, N'admin@Rmovies.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'64d4a58b-5e41-4537-9676-6d02021a8578', N'canManage')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'a62d9b0e-adb2-4752-81a0-ce8a9f4159ca', N'64d4a58b-5e41-4537-9676-6d02021a8578')
 
        
    
");
        }
        
        public override void Down()
        {
        }
    }
}
