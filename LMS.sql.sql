CREATE DATABASE [LMS];
GO

USE [LMS]
GO
/****** Object:  Table [dbo].[BookDetails]    Script Date: 16/01/2023 16:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Author] [nvarchar](max) NOT NULL,
	[Category] [int] NOT NULL,
	[PubYear] [date] NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[BookId] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Borrowed]    Script Date: 16/01/2023 16:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Borrowed](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BookId] [int] NOT NULL,
	[MemberId] [int] NOT NULL,
	[BorrowedDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NULL,
	[FineAmount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 16/01/2023 16:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fine]    Script Date: 16/01/2023 16:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fine](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[FineDate] [datetime] NOT NULL,
	[FineAmount] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Librarian]    Script Date: 16/01/2023 16:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Librarian](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
	[Active] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberDetails]    Script Date: 16/01/2023 16:15:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[JoinedDate] [date] NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BookDetails] ON 

INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (5, N'Alan Dennis', 2, CAST(N'2021-02-01' AS Date), N'System Analysis and Design', N'TE0002')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (6, N'Michael Taillard', 3, CAST(N'2012-01-01' AS Date), N'Corporate Finance ', N'FN0001')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (7, N'Ramez Elmasri', 1, CAST(N'1989-01-01' AS Date), N'Fundamentals of DBMS', N'SC0001')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (8, N'Raef Meeuwisse', 2, CAST(N'2015-03-01' AS Date), N'Cyber Security for Begginers', N'TE0003')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (9, N'Simon Lehna Singh', 2, CAST(N'1999-02-01' AS Date), N'The Code Book', N'TE0004')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (10, N'Robert Kiyosaki', 3, CAST(N'1997-01-01' AS Date), N'Rich Dad Poor Dad', N'FN0002')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (11, N'Chelsea Fagan', 3, CAST(N'2018-10-01' AS Date), N'The Financial Diet', N'FN0003')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (12, N'Ryan Deiss', 4, CAST(N'2016-06-01' AS Date), N'Digital Marketing for Dummies', N'MK0001')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (13, N'David Meerman Scott', 4, CAST(N'2009-10-01' AS Date), N'The New Rules of Marketing and PR', N'MK0002')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (14, N'Oliver Blanchard', 4, CAST(N'2011-11-01' AS Date), N'Social Media ROI', N'FN0003')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (15, N'Bedford D. Jordan', 3, CAST(N'1991-04-01' AS Date), N'Fundamentals of Corporate Finance', N'FN0004')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (16, N'Boni Hamilton', 2, CAST(N'2015-06-01' AS Date), N'Integrating Technology in the Classroom', N'TN0004')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (17, N'J. Michael Spector', 2, CAST(N'2019-02-01' AS Date), N'Educational Technology: A Primer for the 21st Century', N'TE0005')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (18, N'Peter Frankopan', 5, CAST(N'2015-12-01' AS Date), N'The Silk Roads', N'HS0001')
INSERT [dbo].[BookDetails] ([Id], [Author], [Category], [PubYear], [Title], [BookId]) VALUES (19, N'Steeve', 2, CAST(N'2023-01-01' AS Date), N'Steeve''s RFID book', N'TE0006')
SET IDENTITY_INSERT [dbo].[BookDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Borrowed] ON 

INSERT [dbo].[Borrowed] ([Id], [BookId], [MemberId], [BorrowedDate], [ReturnDate], [FineAmount]) VALUES (13, 5, 1, CAST(N'2020-12-25T00:00:00.000' AS DateTime), CAST(N'2023-01-09T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Borrowed] ([Id], [BookId], [MemberId], [BorrowedDate], [ReturnDate], [FineAmount]) VALUES (14, 18, 1, CAST(N'2022-12-20T00:00:00.000' AS DateTime), CAST(N'2023-01-05T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Borrowed] ([Id], [BookId], [MemberId], [BorrowedDate], [ReturnDate], [FineAmount]) VALUES (15, 8, 1, CAST(N'2022-12-10T00:00:00.000' AS DateTime), CAST(N'2022-12-25T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Borrowed] ([Id], [BookId], [MemberId], [BorrowedDate], [ReturnDate], [FineAmount]) VALUES (16, 10, 4, CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-02-14T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Borrowed] ([Id], [BookId], [MemberId], [BorrowedDate], [ReturnDate], [FineAmount]) VALUES (17, 19, 5, CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-01-31T00:00:00.000' AS DateTime), NULL)
INSERT [dbo].[Borrowed] ([Id], [BookId], [MemberId], [BorrowedDate], [ReturnDate], [FineAmount]) VALUES (18, 19, 5, CAST(N'2023-01-11T00:00:00.000' AS DateTime), CAST(N'2023-01-31T00:00:00.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[Borrowed] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [CatName]) VALUES (1, N'Science')
INSERT [dbo].[Category] ([Id], [CatName]) VALUES (2, N'Technology')
INSERT [dbo].[Category] ([Id], [CatName]) VALUES (3, N'Finance')
INSERT [dbo].[Category] ([Id], [CatName]) VALUES (4, N'Marketing')
INSERT [dbo].[Category] ([Id], [CatName]) VALUES (5, N'History')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Fine] ON 

INSERT [dbo].[Fine] ([Id], [MemberId], [FineDate], [FineAmount]) VALUES (4, 1, CAST(N'2023-01-02T17:24:24.623' AS DateTime), 2)
INSERT [dbo].[Fine] ([Id], [MemberId], [FineDate], [FineAmount]) VALUES (5, 3, CAST(N'2023-01-11T05:26:49.920' AS DateTime), 2)
INSERT [dbo].[Fine] ([Id], [MemberId], [FineDate], [FineAmount]) VALUES (6, 1, CAST(N'2023-01-11T05:27:34.337' AS DateTime), 2)
SET IDENTITY_INSERT [dbo].[Fine] OFF
GO
SET IDENTITY_INSERT [dbo].[Librarian] ON 

INSERT [dbo].[Librarian] ([Id], [Name], [Username], [Password], [Active]) VALUES (1, N'Karthik', N'kg9073', N'ganesh', 1)
SET IDENTITY_INSERT [dbo].[Librarian] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberDetails] ON 

INSERT [dbo].[MemberDetails] ([Id], [MemberId], [FirstName], [LastName], [JoinedDate], [Username], [Password]) VALUES (1, 234879, N'Karthik', N'Ganesh', CAST(N'2020-10-20' AS Date), N'kg9073a', N'karthik')
INSERT [dbo].[MemberDetails] ([Id], [MemberId], [FirstName], [LastName], [JoinedDate], [Username], [Password]) VALUES (3, 234880, N'Harry', N'Brooks', CAST(N'2022-02-01' AS Date), N'ha026', N'password')
INSERT [dbo].[MemberDetails] ([Id], [MemberId], [FirstName], [LastName], [JoinedDate], [Username], [Password]) VALUES (4, 234567, N'Jared ', N'Diamond', NULL, N'ja2345', N'12345')
INSERT [dbo].[MemberDetails] ([Id], [MemberId], [FirstName], [LastName], [JoinedDate], [Username], [Password]) VALUES (5, 12345, N'Steeven', N'Deer', CAST(N'2023-01-11' AS Date), N'st123', N'password')
SET IDENTITY_INSERT [dbo].[MemberDetails] OFF
GO
ALTER TABLE [dbo].[BookDetails]  WITH CHECK ADD FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[BookDetails]  WITH CHECK ADD FOREIGN KEY([Category])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Borrowed]  WITH CHECK ADD FOREIGN KEY([BookId])
REFERENCES [dbo].[BookDetails] ([Id])
GO
ALTER TABLE [dbo].[Borrowed]  WITH CHECK ADD FOREIGN KEY([MemberId])
REFERENCES [dbo].[MemberDetails] ([Id])
GO
ALTER TABLE [dbo].[Fine]  WITH CHECK ADD FOREIGN KEY([MemberId])
REFERENCES [dbo].[MemberDetails] ([Id])
GO
