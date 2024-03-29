USE [ConGa]
GO
/****** Object:  Table [dbo].[DatMuaSo]    Script Date: 1/16/2024 10:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DatMuaSo](
	[DatMuaSoID] [int] IDENTITY(1,1) NOT NULL,
	[ThoiGianDat] [datetime] NOT NULL,
	[SlotMoSoID] [int] NOT NULL,
	[SoDuocDat] [int] NOT NULL,
	[UserID] [bigint] NOT NULL,
	[CreateUser] [varchar](36) NULL,
	[CreateDate] [datetime] NULL,
	[EditUser] [varchar](36) NULL,
	[EditDate] [datetime] NULL,
 CONSTRAINT [PK__DatMuaSo__F130C9230DAF0CB0] PRIMARY KEY CLUSTERED 
(
	[DatMuaSoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 1/16/2024 10:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[UserID] [bigint] IDENTITY(1,1) NOT NULL,
	[DienThoai] [varchar](36) NULL,
	[NgaySinh] [datetime] NULL,
	[HoTen] [nvarchar](255) NULL,
	[CreateUser] [varchar](36) NULL,
	[CreateDate] [datetime] NULL,
	[EditUser] [varchar](36) NULL,
	[EditDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuaySo]    Script Date: 1/16/2024 10:51:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuaySo](
	[QuaySoID] [bigint] NOT NULL,
	[ThoiGianQuaySo] [datetime] NOT NULL,
	[KetQua] [int] NOT NULL,
	[CreateUser] [varchar](36) NULL,
	[CreateDate] [datetime] NULL,
	[EditUser] [varchar](36) NULL,
	[EditDate] [datetime] NULL,
 CONSTRAINT [PK__QuaySo__9A8BF1CE117F9D94] PRIMARY KEY CLUSTERED 
(
	[QuaySoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
