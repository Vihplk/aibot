﻿// <auto-generated />
using AIBot.Core.Infrastructure;
using AIBot.Core.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AIBot.Core.Migrations
{
    [DbContext(typeof(AIBotDbContext))]
    [Migration("20180908071408_QuestionType")]
    partial class QuestionType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AIBot.Core.Domain.Master.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AnswerName")
                        .HasColumnType("VARCHAR(200)")
                        .HasMaxLength(200);

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("AIBot.Core.Domain.Master.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsQuestion");

                    b.Property<int>("Order");

                    b.Property<string>("QuestionName")
                        .HasColumnType("VARCHAR(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("StressType");

                    b.HasKey("Id");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("AIBot.Core.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .HasColumnType("VARCHAR(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .HasColumnType("VARCHAR(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("AIBot.Core.Domain.UserSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateTime");

                    b.Property<bool>("IsSessionComplete");

                    b.Property<decimal>("Marks");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserSession");
                });

            modelBuilder.Entity("AIBot.Core.Domain.UserSessionAnswer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MatchingAnswerId");

                    b.Property<string>("MatchingPercentageSummery")
                        .HasColumnType("VARCHAR(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("QuestionId");

                    b.Property<string>("UserAnswer")
                        .HasColumnType("VARCHAR(500)")
                        .HasMaxLength(500);

                    b.Property<int>("UserSessionId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("MatchingAnswerId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserSessionId", "QuestionId")
                        .IsUnique();

                    b.ToTable("UserSessionAnswer");
                });

            modelBuilder.Entity("AIBot.Core.Domain.UserSession", b =>
                {
                    b.HasOne("AIBot.Core.Domain.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AIBot.Core.Domain.UserSessionAnswer", b =>
                {
                    b.HasOne("AIBot.Core.Domain.Master.Answer", "Answer")
                        .WithMany()
                        .HasForeignKey("MatchingAnswerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AIBot.Core.Domain.Master.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AIBot.Core.Domain.UserSession", "UserSession")
                        .WithMany()
                        .HasForeignKey("UserSessionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
