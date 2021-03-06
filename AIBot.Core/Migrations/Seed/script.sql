USE [AIBot]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/26/2018 4:06:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Answer]    Script Date: 8/26/2018 4:06:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Answer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AnswerName] [varchar](200) NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Question]    Script Date: 8/26/2018 4:06:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Question](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IsQuestion] [bit] NOT NULL,
	[Order] [int] NOT NULL,
	[QuestionName] [varchar](1000) NULL,
 CONSTRAINT [PK_Question] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/26/2018 4:06:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](20) NULL,
	[Name] [varchar](20) NULL,
	[Password] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserSession]    Script Date: 8/26/2018 4:06:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSession](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateTime] [datetime2](7) NOT NULL,
	[IsSessionComplete] [bit] NOT NULL,
	[Marks] [decimal](18, 2) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_UserSession] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserSessionAnswer]    Script Date: 8/26/2018 4:06:35 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserSessionAnswer](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MatchingAnswerId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[UserAnswer] [varchar](500) NULL,
	[UserSessionId] [int] NOT NULL,
	[Value] [int] NOT NULL DEFAULT ((0)),
	[MatchingPercentageSummery] [varchar](1000) NULL,
 CONSTRAINT [PK_UserSessionAnswer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180825070643_Init', N'2.0.0-rtm-26452')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180825070952_IncreaseQuestionSize', N'2.0.0-rtm-26452')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180825071014_SeedData', N'2.0.0-rtm-26452')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180825141349_AlterUserSessionAnswerTable', N'2.0.0-rtm-26452')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180825141643_AlterUserSessionAnswerTableAddValueColom', N'2.0.0-rtm-26452')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20180825202901_AlterUserSessionAnswerTableAddValueColom2', N'2.0.0-rtm-26452')
SET IDENTITY_INSERT [dbo].[Answer] ON 

INSERT [dbo].[Answer] ([Id], [AnswerName], [Value]) VALUES (1, N'did not apply to me at all', 0)
INSERT [dbo].[Answer] ([Id], [AnswerName], [Value]) VALUES (2, N'applied to me to some degree, or some of the time', 1)
INSERT [dbo].[Answer] ([Id], [AnswerName], [Value]) VALUES (3, N'applied to me to a considerable degree or a good part of time', 2)
INSERT [dbo].[Answer] ([Id], [AnswerName], [Value]) VALUES (4, N'applied to me very much or most of the time', 3)
INSERT [dbo].[Answer] ([Id], [AnswerName], [Value]) VALUES (5, N'cannot found', 4)
SET IDENTITY_INSERT [dbo].[Answer] OFF
SET IDENTITY_INSERT [dbo].[Question] ON 

INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (1, 0, 0, N'Hi #name# ! Thanks for registering to mindhealer. I’m so excited to talk to you.
                        You can consider me as your best friend and talk about yourself and how your life has been during the past week
                        ')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (2, 0, 1, N'Well start with getting to know each other and talk about your daily life and how the past week is has been.
                        You can say anything to me without being judged
                        ')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (3, 0, 2, N'By the way I like your name Hirusha ? its (Unique, Uncommon, nice, sounds good…..)')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (4, 0, 3, N'Oh Okay. I love it! (In situations like this, user could ask a question in return, chatbot should be able to identify it)')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (5, 0, 4, N'So how are you doing these days? Anything special you’re working on or nothing at all?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (6, 0, 5, N'Statement should be depending on the positive ness or negative ness of user’s answer')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (7, 0, 6, N'I can help you find a way to relax your mind if you let me!')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (8, 1, 7, N'Champ! You remember any moments which you were unable to breathe effortlessly?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (9, 1, 8, N'Let’s see! Did you feel a dryness in your mouth during the past couple of days?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (10, 1, 9, N'I know you work hard. But didn’t you have any positive feelings flowing in your mind last week?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (11, 1, 10, N'Let’s see! Did you had any breathing difficulty recently? You have to be honest with you friend.')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (12, 1, 11, N'So did you find it difficult to take the initiative for the work you are supposed to do?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (13, 1, 12, N'Let’s see! Did you had any breathing difficulty recently? You have to be honest with you friend?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (14, 1, 13, N'Alright! Do you think that you overreact to any situation last week?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (15, 1, 14, N'So tell me did your hands tremble?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (16, 1, 15, N'What made you nervous last week? Nothing at all? It’s fine if you can’t remember?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (17, 1, 16, N'Don’t worry! I’m here for you, I know you were worried about some situations last week? I’mcorrect right?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (18, 1, 17, N'People often have expectations in their lives’, I mean everybody does. Tell me what do you want to do with your life?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (19, 1, 18, N'So, #name# were upset for anything last week? You can tell me, maybe I can help you.')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (20, 1, 19, N'Do you find it difficult to relax when things don’t work your way?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (21, 1, 20, N'So do you feel discouraged and sad too?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (22, 1, 21, N'Did you find it difficult to handle situations in which things don’t happen the way you expect?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (23, 1, 22, N'How close you were to get panicked last week? Or you wasn’t at all?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (24, 1, 23, N'Enthusiasm! I love that word. Can you relate it to last week?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (25, 1, 24, N'You worth million stars!')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (26, 1, 25, N'Do you get offended easily?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (27, 1, 26, N'Lub dub lub dub! I hear you heartbeat. Did you feel it beating faster than usual for anyone or
                    anything?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (28, 1, 27, N'You felt scared about anything? Or you are a brave soul like superman?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (29, 1, 28, N'Let’s focus on something else. What type of music do you like?')
INSERT [dbo].[Question] ([Id], [IsQuestion], [Order], [QuestionName]) VALUES (31, 0, 29, N'The Conversation is Over. Thank you Your collaboration ')
SET IDENTITY_INSERT [dbo].[Question] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Id], [Email], [Name], [Password]) VALUES (1, N'hirusha@gmail.com', N'Hirusha', N'123')
SET IDENTITY_INSERT [dbo].[User] OFF
SET IDENTITY_INSERT [dbo].[UserSession] ON 

INSERT [dbo].[UserSession] ([Id], [DateTime], [IsSessionComplete], [Marks], [UserId]) VALUES (7, CAST(N'2018-08-25 21:32:47.6459901' AS DateTime2), 0, CAST(0.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[UserSession] ([Id], [DateTime], [IsSessionComplete], [Marks], [UserId]) VALUES (8, CAST(N'2018-08-25 22:30:56.5884800' AS DateTime2), 0, CAST(0.00 AS Decimal(18, 2)), 1)
SET IDENTITY_INSERT [dbo].[UserSession] OFF
SET IDENTITY_INSERT [dbo].[UserSessionAnswer] ON 

INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (10, 1, 8, N'Applied to me to a considerable degree or a good part of time', 7, 0, N'[{"answer":1,"similarity":0.021258941084752},{"answer":2,"similarity":0.021258941084752},{"answer":3,"similarity":0.021258941084752},{"answer":4,"similarity":0.021258941084752}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (11, 3, 9, N'Applied to me to a considerable degree or a good part of time', 7, 2, N'[{"answer":1,"similarity":0.04189315722754},{"answer":2,"similarity":0.69896021427956},{"answer":3,"similarity":1.0},{"answer":4,"similarity":0.5705622272872}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (12, 3, 10, N'Applied to me to a considerable degree or a good part of time', 7, 2, N'[{"answer":1,"similarity":0.04189315722754},{"answer":2,"similarity":0.69896021427956},{"answer":3,"similarity":1.0},{"answer":4,"similarity":0.5705622272872}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (13, 2, 11, N'Applied to me to some degree, or some of the time', 7, 1, N'[{"answer":1,"similarity":0.01068655099674},{"answer":2,"similarity":1.0},{"answer":3,"similarity":0.69896021427956},{"answer":4,"similarity":0.8}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (14, 4, 12, N'Applied to me very much or most of the time', 7, 3, N'[{"answer":1,"similarity":0.010278070286098},{"answer":2,"similarity":0.8},{"answer":3,"similarity":0.5705622272872},{"answer":4,"similarity":1.0}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (15, 1, 13, N'Did not apply to me at all', 7, 0, N'[{"answer":1,"similarity":1.0},{"answer":2,"similarity":0.01068655099674},{"answer":3,"similarity":0.04189315722754},{"answer":4,"similarity":0.010278070286098}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (16, 2, 14, N'Applied to me to some degree, or some of the time', 7, 1, N'[{"answer":1,"similarity":0.01068655099674},{"answer":2,"similarity":1.0},{"answer":3,"similarity":0.69896021427956},{"answer":4,"similarity":0.8}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (17, 3, 15, N'Applied to me to a considerable degree or a good part of time', 7, 2, N'[{"answer":1,"similarity":0.04189315722754},{"answer":2,"similarity":0.69896021427956},{"answer":3,"similarity":1.0},{"answer":4,"similarity":0.5705622272872}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (18, 4, 16, N'Applied to me very much or most of the time', 7, 3, N'[{"answer":1,"similarity":0.010278070286098},{"answer":2,"similarity":0.8},{"answer":3,"similarity":0.5705622272872},{"answer":4,"similarity":1.0}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (19, 1, 17, N'Did not apply to me at all', 7, 0, N'[{"answer":1,"similarity":1.0},{"answer":2,"similarity":0.01068655099674},{"answer":3,"similarity":0.04189315722754},{"answer":4,"similarity":0.010278070286098}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (20, 3, 18, N'Applied to me to a considerable degree or a good part of time', 7, 2, N'[{"answer":1,"similarity":0.04189315722754},{"answer":2,"similarity":0.69896021427956},{"answer":3,"similarity":1.0},{"answer":4,"similarity":0.5705622272872}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (21, 3, 19, N'Applied to me to a considerable degree or a good part of time', 7, 2, N'[{"answer":1,"similarity":0.04189315722754},{"answer":2,"similarity":0.69896021427956},{"answer":3,"similarity":1.0},{"answer":4,"similarity":0.5705622272872}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (22, 4, 20, N'Applied to me very much or most of the time', 7, 3, N'[{"answer":1,"similarity":0.010278070286098},{"answer":2,"similarity":0.8},{"answer":3,"similarity":0.5705622272872},{"answer":4,"similarity":1.0}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (23, 1, 21, N'Did not apply to me at all', 7, 0, N'[{"answer":1,"similarity":1.0},{"answer":2,"similarity":0.01068655099674},{"answer":3,"similarity":0.04189315722754},{"answer":4,"similarity":0.010278070286098}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (24, 2, 22, N'Applied to me to some degree, or some of the time', 7, 1, N'[{"answer":1,"similarity":0.01068655099674},{"answer":2,"similarity":1.0},{"answer":3,"similarity":0.69896021427956},{"answer":4,"similarity":0.8}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (25, 2, 23, N'Applied to me to some degree, or some of the time', 7, 1, N'[{"answer":1,"similarity":0.01068655099674},{"answer":2,"similarity":1.0},{"answer":3,"similarity":0.69896021427956},{"answer":4,"similarity":0.8}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (26, 4, 24, N'Applied to me very much or most of the time', 7, 3, N'[{"answer":1,"similarity":0.010278070286098},{"answer":2,"similarity":0.8},{"answer":3,"similarity":0.5705622272872},{"answer":4,"similarity":1.0}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (27, 3, 25, N'Applied to me to a considerable degree or a good part of time', 7, 2, N'[{"answer":1,"similarity":0.04189315722754},{"answer":2,"similarity":0.69896021427956},{"answer":3,"similarity":1.0},{"answer":4,"similarity":0.5705622272872}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (28, 2, 26, N'Applied to me to some degree, or some of the time', 7, 1, N'[{"answer":1,"similarity":0.01068655099674},{"answer":2,"similarity":1.0},{"answer":3,"similarity":0.69896021427956},{"answer":4,"similarity":0.8}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (29, 1, 27, N'Did not apply to me at all', 7, 0, N'[{"answer":1,"similarity":1.0},{"answer":2,"similarity":0.01068655099674},{"answer":3,"similarity":0.04189315722754},{"answer":4,"similarity":0.010278070286098}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (30, 4, 28, N'Applied to me very much or most of the time', 7, 3, N'[{"answer":1,"similarity":0.010278070286098},{"answer":2,"similarity":0.8},{"answer":3,"similarity":0.5705622272872},{"answer":4,"similarity":1.0}]')
INSERT [dbo].[UserSessionAnswer] ([Id], [MatchingAnswerId], [QuestionId], [UserAnswer], [UserSessionId], [Value], [MatchingPercentageSummery]) VALUES (31, 3, 29, N'Applied to me to a considerable degree or a good part of time', 7, 2, N'[{"answer":1,"similarity":0.04189315722754},{"answer":2,"similarity":0.69896021427956},{"answer":3,"similarity":1.0},{"answer":4,"similarity":0.5705622272872}]')
SET IDENTITY_INSERT [dbo].[UserSessionAnswer] OFF
ALTER TABLE [dbo].[UserSession]  WITH CHECK ADD  CONSTRAINT [FK_UserSession_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserSession] CHECK CONSTRAINT [FK_UserSession_User_UserId]
GO
ALTER TABLE [dbo].[UserSessionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserSessionAnswer_Answer_MatchingAnswerId] FOREIGN KEY([MatchingAnswerId])
REFERENCES [dbo].[Answer] ([Id])
GO
ALTER TABLE [dbo].[UserSessionAnswer] CHECK CONSTRAINT [FK_UserSessionAnswer_Answer_MatchingAnswerId]
GO
ALTER TABLE [dbo].[UserSessionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserSessionAnswer_Question_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Question] ([Id])
GO
ALTER TABLE [dbo].[UserSessionAnswer] CHECK CONSTRAINT [FK_UserSessionAnswer_Question_QuestionId]
GO
ALTER TABLE [dbo].[UserSessionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_UserSessionAnswer_UserSession_UserSessionId] FOREIGN KEY([UserSessionId])
REFERENCES [dbo].[UserSession] ([Id])
GO
ALTER TABLE [dbo].[UserSessionAnswer] CHECK CONSTRAINT [FK_UserSessionAnswer_UserSession_UserSessionId]
GO
