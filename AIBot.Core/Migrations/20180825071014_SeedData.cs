using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AIBot.Core.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO Answer (AnswerName, Value)
                VALUES (N'did not apply to me at all', 0),
                    (N'applied to me to some degree, or some of the time', 1),
                    (N'applied to me to a considerable degree or a good part of time', 2)
                    ,(N'applied to me very much or most of the time',3);");

            migrationBuilder.Sql(@"INSERT INTO Question (QuestionName, [Order],IsQuestion)
                VALUES 
                     (N'Hi #name#! (Put the user name here) Thanks for registering to mindhealer. I’m so excited to talk to you.
                        You can consider me as your best friend and talk about yourself and how your life has been during the past week
                        ', 0,0)
                   ,(N'Well start with getting to know each other and talk about your daily life and how the past week is has been.
                        You can say anything to me without being judged
                        ', 1,0)
                   ,(N'By the way I like your name Hirusha  its (Unique, Uncommon, nice, sounds good…..)', 2,0)
                    ,(N'Oh Okay. I love it! (In situations like this, user could ask a question in return, chatbot should be able to identify it)', 0,0)
                    ,(N'So how are you doing these days? Anything special you’re working on or nothing at all?', 3,0)
                    ,(N'Statement should be depending on the positive ness or negative ness of user’s answer', 4,0)
                    ,(N'I can help you find a way to relax your mind if you let me!', 5,0)
                    ,(N'Champ! You remember any moments which you were unable to breathe effortlessly?', 6,1)
                    ,(N'Let’s see! Did you feel a dryness in your mouth during the past couple of days?', 7,1)
                    ,(N'I know you work hard. But didn’t you have any positive feelings flowing in your mind last week?', 8,1)
                    ,(N'Let’s see! Did you had any breathing difficulty recently? You have to be honest with you friend.',9,1)
                    ,(N'So did you find it difficult to take the initiative for the work you are supposed to do?',10,1)
                    ,(N'Let’s see! Did you had any breathing difficulty recently? You have to be honest with you friend?',11,1)
                    ,(N'Alright! Do you think that you overreact to any situation last week?',12,1)
                    ,(N'So tell me did your hands tremble?',13,1)
                    ,(N'What made you nervous last week? Nothing at all? It’s fine if you can’t remember?',14,1)
                    ,(N'Don’t worry! I’m here for you, I know you were worried about some situations last week? I’mcorrect right?',15,1)
                    ,(N'People often have expectations in their lives’, I mean everybody does. Tell me what do you want to do with your life?',16,1)
                    ,(N'So, #username# were upset for anything last week? You can tell me, maybe I can help you.',17,1)
                    ,(N'Do you find it difficult to relax when things don’t work your way?',18,1)
                    ,(N'So do you feel discouraged and sad too?',19,1)
                    ,(N'Did you find it difficult to handle situations in which things don’t happen the way you expect?',20,1)
                    ,(N'How close you were to get panicked last week? Or you wasn’t at all?',21,1)
                    ,(N'Enthusiasm! I love that word. Can you relate it to last week?',22,1)
                    ,(N'You worth million stars!',23,1)
                    ,(N'Do you get offended easily?',24,1)
                    ,(N'19)Lub dub lub dub! I hear you heartbeat. Did you feel it beating faster than usual for anyone or
                    anything?',25,1)
                    ,(N'You felt scared about anything? Or you are a brave soul like superman?',26,1)
                    ,(N'Let’s focus on something else. What type of music do you like?',27,1);");

            migrationBuilder.Sql("Insert into [User](Name,Email,[Password]) values ('Hirusha','hirusha@gmail.com',123);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
