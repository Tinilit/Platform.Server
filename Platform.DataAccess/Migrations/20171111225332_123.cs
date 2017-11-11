using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Platform.DataAccess.Migrations
{
    public partial class _123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserTests_AspNetUsers_UserId",
                table: "UserTests");

            migrationBuilder.DropIndex(
                name: "IX_UserTests_UserId",
                table: "UserTests");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserTests");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Tests",
                newName: "Data");

            migrationBuilder.RenameColumn(
                name: "PaidCount",
                table: "Tests",
                newName: "ProviderProfileId");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "UserTests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_UserProfileId",
                table: "UserTests",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Tests_ProviderProfileId",
                table: "Tests",
                column: "ProviderProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Profiles_ProviderProfileId",
                table: "Tests",
                column: "ProviderProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserTests_Profiles_UserProfileId",
                table: "UserTests",
                column: "UserProfileId",
                principalTable: "Profiles",
                principalColumn: "ProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Profiles_ProviderProfileId",
                table: "Tests");

            migrationBuilder.DropForeignKey(
                name: "FK_UserTests_Profiles_UserProfileId",
                table: "UserTests");

            migrationBuilder.DropIndex(
                name: "IX_UserTests_UserProfileId",
                table: "UserTests");

            migrationBuilder.DropIndex(
                name: "IX_Tests_ProviderProfileId",
                table: "Tests");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserTests");

            migrationBuilder.RenameColumn(
                name: "ProviderProfileId",
                table: "Tests",
                newName: "PaidCount");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Tests",
                newName: "ProviderId");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserTests",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserTests_UserId",
                table: "UserTests",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserTests_AspNetUsers_UserId",
                table: "UserTests",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
