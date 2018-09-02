namespace MyGigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seeduser : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'3d3fa76d-6a97-4caa-b431-0c87a82fc282', N'admin@domain.com', 0, N'AJMYfPIUI2n8fgOm1gFQgogC5pjA2KVw87xh3vC/QdpOmDgEhk06Qcj6Z6zd1VEz2g==', N'4f4e9178-fd8e-4057-a498-046c1bdf1da4', NULL, 0, 0, NULL, 1, 0, N'admin@domain.com')
INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'dbc69fe5-1fec-4788-b2b8-4e7be16d8c10', N'user1@domain.com', 0, N'AM/bjz9ebU6xhIGNXImVCGJ0B3DH0wQcqTjB/yp5pbAsEzbeQj6Wzo4R3WjBwYPS8A==', N'16051367-f359-427a-8cec-57d6a64595fe', NULL, 0, 0, NULL, 1, 0, N'user1@domain.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'90fb264b-69fd-463a-a7c1-9025885b4011', N'Admin')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'3d3fa76d-6a97-4caa-b431-0c87a82fc282', N'90fb264b-69fd-463a-a7c1-9025885b4011')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
