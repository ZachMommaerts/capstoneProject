using Microsoft.EntityFrameworkCore.Migrations;

namespace Installer_PM_Comms.Migrations
{
    public partial class nearmvp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "054b3346-2aee-4c6b-883d-41be51f2f0ff");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85e32f80-2b1d-40e6-86fc-2be8d8e4a63f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a6533ebb-346e-4ed2-82e1-ff61982ef29a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c70e878c-8218-40e2-ba58-b62c7f9b1b11", "8f15a1f6-cadc-4e0c-8561-253de08e3eb1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b5efdd2c-d6fd-439f-b9ef-8e76996f8358", "6382aa9f-4c23-437b-aebc-fcbdee576018", "Project Manager", "PROJECT MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9ea7299a-7ace-4f3e-b10a-e2866c5afa04", "6e794406-6765-414a-9043-1f99a20a187b", "Installer", "INSTALLER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9ea7299a-7ace-4f3e-b10a-e2866c5afa04");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b5efdd2c-d6fd-439f-b9ef-8e76996f8358");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c70e878c-8218-40e2-ba58-b62c7f9b1b11");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "054b3346-2aee-4c6b-883d-41be51f2f0ff", "23b8a473-aeeb-4882-9846-f8b43d9a40cb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a6533ebb-346e-4ed2-82e1-ff61982ef29a", "90a0cbba-dd37-4a89-bf36-47dfeaf6dcd2", "Project Manager", "PROJECT MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "85e32f80-2b1d-40e6-86fc-2be8d8e4a63f", "bf067196-8e17-409e-9684-03e4a31b53d0", "Installer", "INSTALLER" });
        }
    }
}
