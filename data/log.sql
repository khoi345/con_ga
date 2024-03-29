USE [ConGa]
GO
/****** Object:  Table [dbo].[S777]    Script Date: 1/16/2024 10:52:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[S777](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Ver] [varchar](36) NULL,
	[Url] [nvarchar](250) NULL,
	[ThaoTac] [nvarchar](50) NULL,
	[Obj] [ntext] NULL,
	[ThongTin] [ntext] NULL,
	[CreateUser] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_S777] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
