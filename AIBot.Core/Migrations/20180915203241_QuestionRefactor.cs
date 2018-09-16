using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AIBot.Core.Migrations
{
    public partial class QuestionRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsQuestion",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "QuestionType",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionType",
                table: "Question");

            migrationBuilder.AddColumn<bool>(
                name: "IsQuestion",
                table: "Question",
                nullable: false,
                defaultValue: false);
        }
    }
}
