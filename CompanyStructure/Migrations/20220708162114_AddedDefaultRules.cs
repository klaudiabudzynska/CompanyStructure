using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyStructure.Migrations
{
    public partial class AddedDefaultRules : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ToTable",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.CreateTable(
                name: "EmployeeRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRoles", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "88610897-f8fa-46d3-9768-56ea0076c8ad", "8c1f1fd3-65af-45c5-9fc6-a4e2e3c6000d", "User", "USER" },
                    { "fdd94f1b-b075-4ac2-adb6-ba3e30978ebe", "d9db9905-df6a-4ebb-a727-a72ded4e6794", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "EmployeeRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Meneger" },
                    { 2, "Team Leader" },
                    { 3, "Scrum Master" },
                    { 4, "Frontend Developer" },
                    { 5, "Backend Developer" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ToTable",
                table: "Employees",
                column: "RoleId",
                principalTable: "EmployeeRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ToTable",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeRoles");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "88610897-f8fa-46d3-9768-56ea0076c8ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdd94f1b-b075-4ac2-adb6-ba3e30978ebe");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ToTable",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id");
        }
    }
}
