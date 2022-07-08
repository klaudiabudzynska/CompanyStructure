using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyStructure.Migrations
{
    public partial class DeleteDeleting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88610897-f8fa-46d3-9768-56ea0076c8ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdd94f1b-b075-4ac2-adb6-ba3e30978ebe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0083c8d7-241c-4d0b-a094-447b8551a407", "c9facc67-f9a9-4b83-8407-e9a6e0b5c8bb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e634304-33f9-4d87-bab4-ed70843eb7f9", "df3f8c5f-539b-4170-bdfd-d6e295231d6a", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0083c8d7-241c-4d0b-a094-447b8551a407");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e634304-33f9-4d87-bab4-ed70843eb7f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "88610897-f8fa-46d3-9768-56ea0076c8ad", "8c1f1fd3-65af-45c5-9fc6-a4e2e3c6000d", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fdd94f1b-b075-4ac2-adb6-ba3e30978ebe", "d9db9905-df6a-4ebb-a727-a72ded4e6794", "Admin", "ADMIN" });
        }
    }
}
