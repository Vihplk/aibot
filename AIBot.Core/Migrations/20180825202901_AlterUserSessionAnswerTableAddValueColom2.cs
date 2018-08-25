using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AIBot.Core.Migrations
{
    public partial class AlterUserSessionAnswerTableAddValueColom2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchingPercentage",
                table: "UserSessionAnswer");

            migrationBuilder.AddColumn<string>(
                name: "MatchingPercentageSummery",
                table: "UserSessionAnswer",
                type: "VARCHAR(1000)",
                maxLength: 1000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchingPercentageSummery",
                table: "UserSessionAnswer");

            migrationBuilder.AddColumn<double>(
                name: "MatchingPercentage",
                table: "UserSessionAnswer",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
