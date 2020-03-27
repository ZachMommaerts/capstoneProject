using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Installer_PM_Comms.Migrations
{
    public partial class nullableaddresses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Installers_Addresses_AddressId",
                table: "Installers");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Managers_Addresses_AddressId",
                table: "Project_Managers");

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

            migrationBuilder.DropColumn(
                name: "ClockInFive",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockInFour",
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
                name: "ClockOutThree",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ClockOutTwo",
                table: "Jobs");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Project_Managers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Installers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Clients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Latitude", "Longitude", "State", "StreetName", "ZipCode" },
                values: new object[] { 5, "milwaukee", null, null, "wi", "3880 w milwaukee rd", 53208 });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5853d9a4-8f3b-4804-9a65-bef04db11831", "34e3cc99-196d-43b0-af95-99ec9a0dca0e", "Admin", "ADMIN" },
                    { "10e04fa8-b8e5-40ab-ac6f-7d16a27534d9", "b0332fb6-6cee-4009-9bba-42259f994c8c", "Project Manager", "PROJECT MANAGER" },
                    { "e2436895-c907-4725-9725-65ed88e3ac48", "fd613b92-96c7-475c-84de-c05ef522ee6a", "Installer", "INSTALLER" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Installers_Addresses_AddressId",
                table: "Installers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Managers_Addresses_AddressId",
                table: "Project_Managers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Installers_Addresses_AddressId",
                table: "Installers");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_Managers_Addresses_AddressId",
                table: "Project_Managers");

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10e04fa8-b8e5-40ab-ac6f-7d16a27534d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5853d9a4-8f3b-4804-9a65-bef04db11831");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2436895-c907-4725-9725-65ed88e3ac48");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Project_Managers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInFive",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInFour",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInThree",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockInTwo",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutFive",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutFour",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutThree",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ClockOutTwo",
                table: "Jobs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Installers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Clients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_Addresses_AddressId",
                table: "Clients",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Installers_Addresses_AddressId",
                table: "Installers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Managers_Addresses_AddressId",
                table: "Project_Managers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
