using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FullWeb.Data.Migrations
{
    public partial class BlogMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Volunteer",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "NeedsConsent",
                table: "Volunteer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProjectId",
                table: "Product",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Project_ProjectId",
                table: "Product",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Project_ProjectId",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProjectId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "NeedsConsent",
                table: "Volunteer");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Product");
        }
    }
}
