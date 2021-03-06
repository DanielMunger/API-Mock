USE [4TELLAPITest]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/25/2017 1:58:20 PM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 8/25/2017 1:58:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 8/25/2017 1:58:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[ProductName] [nvarchar](max) NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170825020816_InitialMigration', N'1.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170825021055_Plurals', N'1.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170825021308_ProductList', N'1.0.1')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20170825034703_ProductModelChange', N'1.0.1')
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (1, N'Baseball')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (2, N'Running')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (3, N'Basketball')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (4, N'Fishing')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (5, N'Climbing')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (6, N'Kayaking')
INSERT [dbo].[Categories] ([CategoryId], [CategoryName]) VALUES (7, N'Camping')
SET IDENTITY_INSERT [dbo].[Categories] OFF
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (1, 1, N'Baseball Mitt')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (2, 1, N'Baseball Bat')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (3, 1, N'Baseball')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (4, 2, N'Running Shoes')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (5, 2, N'Running Short')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (6, 2, N'Sweatshirt')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (7, 3, N'Basketball')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (8, 3, N'Hoop')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (9, 3, N'Ball Pump')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (10, 4, N'Tackle Box')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (11, 4, N'Fishing Rod')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (12, 4, N'Fishing Vest')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (13, 5, N'Harness')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (14, 5, N'Climbing Rope')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (15, 5, N'ATC')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (16, 6, N'Kayak')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (17, 6, N'Paddle')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (18, 6, N'Spray Skirt')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (19, 7, N'Stove')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (20, 7, N'Tent')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (21, 7, N'Sleeping Bag')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (22, 7, N'Sleeping Pad')
INSERT [dbo].[Products] ([ProductId], [CategoryId], [ProductName]) VALUES (23, 7, N'Cooler')
SET IDENTITY_INSERT [dbo].[Products] OFF
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([CategoryId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Categories_CategoryId]
GO
