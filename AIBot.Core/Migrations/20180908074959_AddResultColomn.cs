using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AIBot.Core.Migrations
{
    public partial class AddResultColomn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Marks",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "SessionResult",
                table: "UserSession");

            migrationBuilder.AddColumn<decimal>(
                name: "AnxietyMarks",
                table: "UserSession",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "DepressionMarks",
                table: "UserSession",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "StressMarks",
                table: "UserSession",
                type: "decimal(18, 2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnxietyMarks",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "DepressionMarks",
                table: "UserSession");

            migrationBuilder.DropColumn(
                name: "StressMarks",
                table: "UserSession");

            migrationBuilder.AddColumn<decimal>(
                name: "Marks",
                table: "UserSession",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "SessionResult",
                table: "UserSession",
                maxLength: 10,
                nullable: true);
        }
    }
}
