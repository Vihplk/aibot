using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AIBot.Core.Migrations
{
    public partial class AlterUserSessionAnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Group",
                table: "UserSessionAnswer");

            migrationBuilder.AddColumn<double>(
                name: "MatchingPercentage",
                table: "UserSessionAnswer",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MatchingPercentage",
                table: "UserSessionAnswer");

            migrationBuilder.AddColumn<int>(
                name: "Group",
                table: "UserSessionAnswer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
