using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace mo3askerpro2.Migrations
{
    public partial class bff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(

                table: "AspNetRoles",
                columns:new[] {"Id","Name","NormalizedName","concurrencyStamp"},
                values: new object[] {Guid.NewGuid().ToString(),"User","User".ToUpper(),Guid.NewGuid().ToString()},
                schema :"dbo"
                );

            migrationBuilder.InsertData(

               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "concurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() },
               schema: "dbo"
               );
            migrationBuilder.InsertData(

               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "concurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "SuperAdmin", "SuperAdmin".ToUpper(), Guid.NewGuid().ToString() },
               schema: "dbo"
               );
        }


        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[AspNetRoles]");

        }
    }
}
