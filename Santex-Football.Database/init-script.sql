
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Players]') AND type in (N'U'))
ALTER TABLE [dbo].[Players] DROP CONSTRAINT IF EXISTS [FK_Players_Teams_TeamId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Leagues]') AND type in (N'U'))
ALTER TABLE [dbo].[Leagues] DROP CONSTRAINT IF EXISTS [FK__Leagues__LeagueC__0C85DE4D]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImportedLeagues]') AND type in (N'U'))
ALTER TABLE [dbo].[ImportedLeagues] DROP CONSTRAINT IF EXISTS [FK__ImportedL__Leagu__07C12930]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 20/8/2018 20:35:24 ******/
DROP TABLE IF EXISTS [dbo].[Teams]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 20/8/2018 20:35:24 ******/
DROP TABLE IF EXISTS [dbo].[Players]
GO
/****** Object:  Table [dbo].[LeagueTeam]    Script Date: 20/8/2018 20:35:24 ******/
DROP TABLE IF EXISTS [dbo].[LeagueTeam]
GO
/****** Object:  Table [dbo].[Leagues]    Script Date: 20/8/2018 20:35:24 ******/
DROP TABLE IF EXISTS [dbo].[Leagues]
GO
/****** Object:  Table [dbo].[LeagueCodes]    Script Date: 20/8/2018 20:35:24 ******/
DROP TABLE IF EXISTS [dbo].[LeagueCodes]
GO
/****** Object:  Table [dbo].[ImportedLeagues]    Script Date: 20/8/2018 20:35:24 ******/
DROP TABLE IF EXISTS [dbo].[ImportedLeagues]
GO
/****** Object:  Table [dbo].[ImportedLeagues]    Script Date: 20/8/2018 20:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImportedLeagues]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ImportedLeagues](
	[LeagueCodeId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_ImportedLeagues] PRIMARY KEY CLUSTERED 
(
	[LeagueCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LeagueCodes]    Script Date: 20/8/2018 20:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeagueCodes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LeagueCodes](
	[LeagueCodeId] [nvarchar](450) NOT NULL,
	[Country] [nvarchar](max) NULL,
	[LeagueDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_LeagueCodes] PRIMARY KEY CLUSTERED 
(
	[LeagueCodeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Leagues]    Script Date: 20/8/2018 20:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Leagues]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Leagues](
	[LeagueId] [int] IDENTITY(1,1) NOT NULL,
	[Caption] [nvarchar](max) NULL,
	[LeagueCode] [nvarchar](450) NULL,
	[Year] [nvarchar](max) NULL,
 CONSTRAINT [PK_Leagues] PRIMARY KEY CLUSTERED 
(
	[LeagueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[LeagueTeam]    Script Date: 20/8/2018 20:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LeagueTeam]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[LeagueTeam](
	[TeamId] [int] NOT NULL,
	[LeagueId] [int] NOT NULL,
 CONSTRAINT [PK_LeagueTeam] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC,
	[LeagueId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Players]    Script Date: 20/8/2018 20:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Players]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Players](
	[PlayerId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Position] [nvarchar](max) NULL,
	[JerseyNumber] [int] NULL,
	[DateOfBirth] [nvarchar](max) NULL,
	[Nationality] [nvarchar](max) NULL,
	[ContractUntil] [nvarchar](max) NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 20/8/2018 20:35:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Teams](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Code] [nvarchar](max) NULL,
	[Shortname] [nvarchar](max) NULL,
	[LeagueId] [int] NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'BL1', N'Germany', N'1. Bundesliga')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'BL2', N'Germany', N'2. Bundesliga')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'BL3', N'Germany', N'3. Bundesliga')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'CDR', N'Spain', N'Copa del Rey')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'CL', N'Europe', N'Champions-League')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'DED', N'Netherlands', N'Eredivisie')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'DFB', N'Germany', N'Dfb-Cup')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'EC', N'Europe', N'European-Cup of Nations')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'EL', N'Europe', N'UEFA-Cup')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'EL1', N'England', N'League One')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'ELC', N'England', N'Championship')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'FAC', N'England', N'FA-Cup')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'FL1', N'France', N'Ligue 1')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'FL2', N'France', N'Ligue 2')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'GSL', N'Greece', N'Super League')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'PD', N'Spain', N'Primera Division')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'PL', N'England', N'Premiere League')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'PPL', N'Portugal', N'Primeira Liga')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'SA', N'Italy', N'Serie A')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'SB', N'Italy', N'Serie B')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'SD', N'Spain', N'Segunda Division')
INSERT [dbo].[LeagueCodes] ([LeagueCodeId], [Country], [LeagueDescription]) VALUES (N'WC', N'World', N'World-Cup')
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__ImportedL__Leagu__07C12930]') AND parent_object_id = OBJECT_ID(N'[dbo].[ImportedLeagues]'))
ALTER TABLE [dbo].[ImportedLeagues]  WITH CHECK ADD FOREIGN KEY([LeagueCodeId])
REFERENCES [dbo].[LeagueCodes] ([LeagueCodeId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__Leagues__LeagueC__0C85DE4D]') AND parent_object_id = OBJECT_ID(N'[dbo].[Leagues]'))
ALTER TABLE [dbo].[Leagues]  WITH CHECK ADD FOREIGN KEY([LeagueCode])
REFERENCES [dbo].[LeagueCodes] ([LeagueCodeId])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Players_Teams_TeamId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Players]'))
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Players_Teams_TeamId]') AND parent_object_id = OBJECT_ID(N'[dbo].[Players]'))
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Teams_TeamId]
GO
