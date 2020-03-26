using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Installer_PM_Comms.Migrations
{
    public partial class redo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "152c6848-41b5-4b46-b39d-e9653967626c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a10a5b9-62a8-4762-96fd-1aac0a8809af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "caf22f12-3193-4dcd-880d-205d48471315");

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInFive",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInFour",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInOne",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInThree",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInTwo",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutFive",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutFour",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutOne",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutThree",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutTwo",
                table: "Jobs",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InstallCompleted",
                table: "Jobs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Latitude", "Longitude", "State", "StreetName", "ZipCode" },
                values: new object[,]
                {
                    { 1, "oconomowoc", null, null, "wi", "329 e pleasant st", 53066 },
                    { 2, "milwaukee", null, null, "wi", "2100 n kilian pl", 53212 },
                    { 3, "west allis", null, null, "wi", "1427 s 75th st", 53214 },
                    { 4, "kenosha", null, null, "wi", "1105 57th st", 53140 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "054b3346-2aee-4c6b-883d-41be51f2f0ff", "23b8a473-aeeb-4882-9846-f8b43d9a40cb", "Admin", "ADMIN" },
                    { "a6533ebb-346e-4ed2-82e1-ff61982ef29a", "90a0cbba-dd37-4a89-bf36-47dfeaf6dcd2", "Project Manager", "PROJECT MANAGER" },
                    { "85e32f80-2b1d-40e6-86fc-2be8d8e4a63f", "bf067196-8e17-409e-9684-03e4a31b53d0", "Installer", "INSTALLER" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressId", "CompanyName", "ContactEmailAddress", "ContactName", "ContactPhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "Hungry Sumo", "jsmith@gmail.com", "jenny smith", "569-2341" },
                    { 2, 2, null, "rodh@gmail.com", "Rodney Herrington", "567-3391" },
                    { 3, 3, "the blue circle", "bluecircle@gmail.com", "Jeff Griswold", "490-5806" },
                    { 4, 4, "sports 'n drinks", "rachelstam@gmail.com", "rachel stamford", "490-6317" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Blueprints", "ClientId", "ClockInFive", "ClockInFour", "ClockInOne", "ClockInThree", "ClockInTwo", "ClockOutFive", "ClockOutFour", "ClockOutOne", "ClockOutThree", "ClockOutTwo", "Completed", "CompletionDate", "Description", "InstallCompleted", "InstallDate", "JobName", "JobNumber", "Notes", "Photos", "ProjectManagerId" },
                values: new object[,]
                {
                    { 1, null, 1, null, null, null, null, null, null, null, null, null, null, false, null, "new hand rail for downtown restaurant", false, new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Restaurant Rail", 247.0, null, null, null },
                    { 2, null, 2, null, null, null, null, null, null, null, null, null, null, false, null, "new residential fence in west allis", false, new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Residential Fence", 768.0, null, null, null },
                    { 3, null, 3, null, null, null, null, null, null, null, null, null, null, false, null, "remodel stair rail 12inches", false, new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Stair Rail Remodel", 134.0, null, null, null },
                    { 4, null, 4, null, null, null, null, null, null, null, null, null, null, false, null, "new bar rail interior", false, new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bar construction", 318.0, null, null, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "ClockInFive",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockInFour",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockInOne",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockInThree",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockInTwo",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockOutFive",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockOutFour",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockOutOne",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockOutThree",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockOutTwo",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "InstallCompleted",
                table: "Jobs");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a10a5b9-62a8-4762-96fd-1aac0a8809af", "2c7505c1-f9a5-4c3d-b1d6-63178db5070b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "152c6848-41b5-4b46-b39d-e9653967626c", "f50ea018-e780-480a-b07f-97fbb310cbe3", "Project Manager", "PROJECT MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "caf22f12-3193-4dcd-880d-205d48471315", "abd642d5-c5c4-40a0-867f-3b93318b6aa4", "Installer", "INSTALLER" });
        }
    }
}
