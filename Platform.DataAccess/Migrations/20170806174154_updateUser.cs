using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.DataAccess.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "Zipcode",
                table: "AspNetUsers",
                newName: "selfHealth");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "AspNetUsers",
                newName: "selfEsteem");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "AspNetUsers",
                newName: "medName");

            migrationBuilder.RenameColumn(
                name: "CreditCardIdentifier",
                table: "AspNetUsers",
                newName: "maritalStatus");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "AspNetUsers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "Address2",
                table: "AspNetUsers",
                newName: "firstLanguage");

            migrationBuilder.RenameColumn(
                name: "Address1",
                table: "AspNetUsers",
                newName: "exercise");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthDate",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "brainActivity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "education",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ethnisity",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "gender",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "hand",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "income",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "injuryCount",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "birthDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "brainActivity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "education",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ethnisity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "hand",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "income",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "injuryCount",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "selfHealth",
                table: "AspNetUsers",
                newName: "Zipcode");

            migrationBuilder.RenameColumn(
                name: "selfEsteem",
                table: "AspNetUsers",
                newName: "Town");

            migrationBuilder.RenameColumn(
                name: "medName",
                table: "AspNetUsers",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "maritalStatus",
                table: "AspNetUsers",
                newName: "CreditCardIdentifier");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "AspNetUsers",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "firstLanguage",
                table: "AspNetUsers",
                newName: "Address2");

            migrationBuilder.RenameColumn(
                name: "exercise",
                table: "AspNetUsers",
                newName: "Address1");
        }
    }
}
