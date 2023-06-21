using Microsoft.EntityFrameworkCore.Migrations;

namespace mo3askerpro2.Migrations
{
    public partial class admin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[AspNetUsers]([Id],[Gender],[City],[UserName],[NormalizedUserName] ,[Email] ,[NormalizedEmail] ,[EmailConfirmed] ,[PasswordHash],[SecurityStamp],[ConcurrencyStamp],[PhoneNumber],[PhoneNumberConfirmed],[TwoFactorEnabled],[LockoutEnd] ,[LockoutEnabled],[AccessFailedCount]) VALUES (N'9ae5b06d-9209-428a-8c24-e968e58e52e0',NULL,NULL,N'Admin@gmail.com', N'ADMIN@GMAIL.COM',N'Admin@gmail.com',N'ADMIN@GMAIL.COM',0,N'AQAAAAEAACcQAAAAEMLYnPkabyfqJvA+v+3p3D+D6KXQDuOTvC0uBYbDWzhatRul8w1gAya2omm3dpMzLQ==',N'QYJ7XEYV3VHAUDTHRBHNO2GGV6KEXDB3',N'6f23553c-8331-4de7-89a2-8cbb18d3fc68',N'0792904743',0,0,NULL,1,0)");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetUsers] WHERE Id='9ae5b06d-9209-428a-8c24-e968e58e52e0'");
        }
    }
}
