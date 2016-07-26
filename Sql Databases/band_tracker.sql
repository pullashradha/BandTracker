CREATE DATABASE band_tracker;
GO
USE [band_tracker]
GO
/****** Object:  Table [dbo].[bands]    Script Date: 7/22/2016 2:06:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[music_genre] [varchar](255) NULL,
	[description] [varchar](500) NULL,
	[website] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[bands_venues]    Script Date: 7/22/2016 2:06:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[bands_venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[band_id] [int] NULL,
	[venue_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[venues]    Script Date: 7/22/2016 2:06:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[venues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[street_address] [varchar](255) NULL,
	[city_address] [varchar](255) NULL,
	[state_address] [varchar](255) NULL,
	[zipcode] [varchar](255) NULL,
	[phone_number] [varchar](255) NULL,
	[website] [varchar](255) NULL,
	[event_date] [datetime] NULL
) ON [PRIMARY]

GO
