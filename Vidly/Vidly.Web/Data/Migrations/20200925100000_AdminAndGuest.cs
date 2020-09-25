using Microsoft.EntityFrameworkCore.Migrations;

namespace Vidly.Web.Data.Migrations
{
    public partial class AdminAndGuest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c0abdbb2-c8a8-4d6a-b730-a5e2553f8157', N'admin@mail.com', N'ADMIN@MAIL.COM', N'admin@mail.com', N'ADMIN@MAIL.COM', 0, N'AQAAAAEAACcQAAAAECXrtb4A4f9L+voqhabw4zTFbEaZ605QT7jL4n5TUSHrBrFBw3AlM/85/AJnK46a2A==', N'ZPCTEQML3PS7WL45ZCX53QPY7VTXZW5T', N'95d74cb4-93a6-4ed4-8d91-d63746b43c0c', NULL, 0, 0, NULL, 1, 0)
            INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c6a1fdbf-5ab3-4c49-baec-e1d2b17445e8', N'guest@mail.com', N'GUEST@MAIL.COM', N'guest@mail.com', N'GUEST@MAIL.COM', 0, N'AQAAAAEAACcQAAAAELtvoaaMDO+EdlvA15sNYhg53+CmrflhoqQsMFm2+KJ+Kzo5bN3c64qfuDfSYPuh7g==', N'WYRUXUCLKBQ4QW3DD7LW73GWNCUMXRPI', N'95e5b02d-1ecb-40f3-94ca-4b3bd24e8ed3', NULL, 0, 0, NULL, 1, 0)
            
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'42581d7d-7097-4af6-b51a-2b1bb6c423ca', N'CanManageMovies', N'CANMANAGEMOVIES', N'c26721ea-a13a-4f9f-881b-3cab645d4d28')
            
            INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c0abdbb2-c8a8-4d6a-b730-a5e2553f8157', N'42581d7d-7097-4af6-b51a-2b1bb6c423ca')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
