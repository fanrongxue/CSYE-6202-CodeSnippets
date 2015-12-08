USE [CarDB]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 11/19/2015 8:48:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Inventory](
	[CarID] [int] NOT NULL,
	[Make] [varchar](50) NULL,
	[Color] [varchar](50) NULL,
	[PetName] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


