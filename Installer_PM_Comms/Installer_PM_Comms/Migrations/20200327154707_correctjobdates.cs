using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Installer_PM_Comms.Migrations
{
    public partial class correctjobdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4101379f-39e5-4026-96c0-0a100dec7254");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4c6bb9ac-0f27-4282-a1f2-b1f76cc7b72f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b25a8bc9-47b1-425c-a314-82f43d86bb9c");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7a757fcf-b510-4a14-8149-bc3088f60ba3", "6f2414cd-847f-42af-8f98-6867117a9efb", "Admin", "ADMIN" },
                    { "7654973d-cf9d-47e3-bd0b-fa8a9dfd864e", "d97c21e1-9f95-4daf-884c-f0e44dbc44f4", "Project Manager", "PROJECT MANAGER" },
                    { "60aa33a4-f842-46d4-8e43-24225d6db6a7", "9e3ee102-9687-435b-bc15-0d0b56527b0b", "Installer", "INSTALLER" }
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstallDate",
                value: new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstallDate",
                value: new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstallDate",
                value: new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstallDate",
                value: new DateTime(2020, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "60aa33a4-f842-46d4-8e43-24225d6db6a7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7654973d-cf9d-47e3-bd0b-fa8a9dfd864e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a757fcf-b510-4a14-8149-bc3088f60ba3");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4101379f-39e5-4026-96c0-0a100dec7254", "9957e2a8-a7a7-4994-8311-77802efd3af4", "Admin", "ADMIN" },
                    { "4c6bb9ac-0f27-4282-a1f2-b1f76cc7b72f", "6b596fc1-bf2a-41da-9755-8780168599e5", "Project Manager", "PROJECT MANAGER" },
                    { "b25a8bc9-47b1-425c-a314-82f43d86bb9c", "128012a1-e884-422f-8438-4c65c405ec6d", "Installer", "INSTALLER" }
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "InstallDate",
                value: new DateTime(2020, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "InstallDate",
                value: new DateTime(2020, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3,
                column: "InstallDate",
                value: new DateTime(2020, 4, 27, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4,
                column: "InstallDate",
                value: new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
