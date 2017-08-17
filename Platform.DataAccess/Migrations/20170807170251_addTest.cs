using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Platform.DataAccess.Migrations
{
    public partial class addTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "selfHealth",
                table: "AspNetUsers",
                newName: "SelfHealth");

            migrationBuilder.RenameColumn(
                name: "selfEsteem",
                table: "AspNetUsers",
                newName: "SelfEsteem");

            migrationBuilder.RenameColumn(
                name: "medName",
                table: "AspNetUsers",
                newName: "MedName");

            migrationBuilder.RenameColumn(
                name: "maritalStatus",
                table: "AspNetUsers",
                newName: "MaritalStatus");

            migrationBuilder.RenameColumn(
                name: "lastName",
                table: "AspNetUsers",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "injuryCount",
                table: "AspNetUsers",
                newName: "InjuryCount");

            migrationBuilder.RenameColumn(
                name: "income",
                table: "AspNetUsers",
                newName: "Income");

            migrationBuilder.RenameColumn(
                name: "hand",
                table: "AspNetUsers",
                newName: "Hand");

            migrationBuilder.RenameColumn(
                name: "gender",
                table: "AspNetUsers",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "firstName",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "firstLanguage",
                table: "AspNetUsers",
                newName: "FirstLanguage");

            migrationBuilder.RenameColumn(
                name: "exercise",
                table: "AspNetUsers",
                newName: "Exercise");

            migrationBuilder.RenameColumn(
                name: "ethnisity",
                table: "AspNetUsers",
                newName: "Ethnisity");

            migrationBuilder.RenameColumn(
                name: "education",
                table: "AspNetUsers",
                newName: "Education");

            migrationBuilder.RenameColumn(
                name: "brainActivity",
                table: "AspNetUsers",
                newName: "BrainActivity");

            migrationBuilder.RenameColumn(
                name: "birthDate",
                table: "AspNetUsers",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "AspNetUsers",
                newName: "Address");

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FinishTime = table.Column<DateTime>(nullable: false),
                    ProviderId = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    TestType = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.RenameColumn(
                name: "SelfHealth",
                table: "AspNetUsers",
                newName: "selfHealth");

            migrationBuilder.RenameColumn(
                name: "SelfEsteem",
                table: "AspNetUsers",
                newName: "selfEsteem");

            migrationBuilder.RenameColumn(
                name: "MedName",
                table: "AspNetUsers",
                newName: "medName");

            migrationBuilder.RenameColumn(
                name: "MaritalStatus",
                table: "AspNetUsers",
                newName: "maritalStatus");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "AspNetUsers",
                newName: "lastName");

            migrationBuilder.RenameColumn(
                name: "InjuryCount",
                table: "AspNetUsers",
                newName: "injuryCount");

            migrationBuilder.RenameColumn(
                name: "Income",
                table: "AspNetUsers",
                newName: "income");

            migrationBuilder.RenameColumn(
                name: "Hand",
                table: "AspNetUsers",
                newName: "hand");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "AspNetUsers",
                newName: "gender");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "AspNetUsers",
                newName: "firstName");

            migrationBuilder.RenameColumn(
                name: "FirstLanguage",
                table: "AspNetUsers",
                newName: "firstLanguage");

            migrationBuilder.RenameColumn(
                name: "Exercise",
                table: "AspNetUsers",
                newName: "exercise");

            migrationBuilder.RenameColumn(
                name: "Ethnisity",
                table: "AspNetUsers",
                newName: "ethnisity");

            migrationBuilder.RenameColumn(
                name: "Education",
                table: "AspNetUsers",
                newName: "education");

            migrationBuilder.RenameColumn(
                name: "BrainActivity",
                table: "AspNetUsers",
                newName: "brainActivity");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "AspNetUsers",
                newName: "birthDate");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "AspNetUsers",
                newName: "address");
        }
    }
}
