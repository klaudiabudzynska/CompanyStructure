using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyStructure.Migrations
{
    public partial class SupervisorColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0083c8d7-241c-4d0b-a094-447b8551a407");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e634304-33f9-4d87-bab4-ed70843eb7f9");

            migrationBuilder.AddColumn<int>(
                name: "SupervisorId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "4a244725-fe9e-45c5-948e-ee616d01a836", "8c483834-3a55-4aa8-8a71-1bdbc134811b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "abc436f4-9939-4197-94e1-d691fc23b244", "2099c0d3-e8d7-420c-b371-08d76c7d4138", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a244725-fe9e-45c5-948e-ee616d01a836");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "abc436f4-9939-4197-94e1-d691fc23b244");

            migrationBuilder.DropColumn(
                name: "SupervisorId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0083c8d7-241c-4d0b-a094-447b8551a407", "c9facc67-f9a9-4b83-8407-e9a6e0b5c8bb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7e634304-33f9-4d87-bab4-ed70843eb7f9", "df3f8c5f-539b-4170-bdfd-d6e295231d6a", "User", "USER" });
        }
    }
}
