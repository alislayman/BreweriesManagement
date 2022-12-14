USE [master]
GO
/****** Object:  Database [BreweryManagement]    Script Date: 8/14/2022 7:58:41 PM ******/
CREATE DATABASE [BreweryManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BreweryManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BreweryManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BreweryManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\BreweryManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BreweryManagement] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BreweryManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BreweryManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BreweryManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BreweryManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BreweryManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BreweryManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [BreweryManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BreweryManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BreweryManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BreweryManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BreweryManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BreweryManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BreweryManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BreweryManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BreweryManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BreweryManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BreweryManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BreweryManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BreweryManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BreweryManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BreweryManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BreweryManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BreweryManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BreweryManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BreweryManagement] SET  MULTI_USER 
GO
ALTER DATABASE [BreweryManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BreweryManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BreweryManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BreweryManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BreweryManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BreweryManagement] SET QUERY_STORE = OFF
GO
USE [BreweryManagement]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [BreweryManagement]
GO
/****** Object:  Table [dbo].[Beer]  
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Beer](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[BreweryID] [uniqueidentifier] NOT NULL,
	[AlcoholContent] [decimal](18, 2) NOT NULL,
	[RetailPrice] [decimal](20, 2) NULL,
	[WholesalePrice] [decimal](20, 2) NOT NULL,
	[IsDeleted] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brewery]   
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brewery](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Wholesaler]    
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Wholesaler](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WholesalerBeerQuote]  
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WholesalerBeerQuote](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BeerID] [uniqueidentifier] NOT NULL,
	[WholesalerID] [uniqueidentifier] NOT NULL,
	[DiscountPercentage] [decimal](18, 2) NOT NULL,
	[MinimumNumberOfBeers] [int] NOT NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[WholesalerBeerQuote] ON 

INSERT [dbo].[WholesalerBeerQuote] ([ID], [BeerID], [WholesalerID], [DiscountPercentage], [MinimumNumberOfBeers]) VALUES (1, N'6c9626e4-5ff0-4425-bdab-d390fd9e7353', N'481b8ced-3fa6-4bc1-beee-2077e4f27fab', CAST(5.00 AS Decimal(18, 2)), 10)
INSERT [dbo].[WholesalerBeerQuote] ([ID], [BeerID], [WholesalerID], [DiscountPercentage], [MinimumNumberOfBeers]) VALUES (3, N'fc3e35c3-a0f4-47b2-adf5-6b72499c921a', N'a2fa5b28-77be-47e9-92d9-851d28b8831d', CAST(10.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[WholesalerBeerQuote] ([ID], [BeerID], [WholesalerID], [DiscountPercentage], [MinimumNumberOfBeers]) VALUES (4, N'6c9626e4-5ff0-4425-bdab-d390fd9e7353', N'481b8ced-3fa6-4bc1-beee-2077e4f27fab', CAST(10.00 AS Decimal(18, 2)), 20)
SET IDENTITY_INSERT [dbo].[WholesalerBeerQuote] OFF

/****** Object:  Table [dbo].[WholesalerStock]   
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WholesalerStock](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BeerID] [uniqueidentifier] NOT NULL,
	[WholesalerID] [uniqueidentifier] NOT NULL,
	[NumberOfBeers] [int] NOT NULL
) ON [PRIMARY]
GO
INSERT [dbo].[Beer] ([ID], [Name], [BreweryID], [AlcoholContent], [RetailPrice], [WholesalePrice], [IsDeleted]) VALUES (N'6c9626e4-5ff0-4425-bdab-d390fd9e7353', N'Saison Dupont - Organic Belgian Beer', N'77f2b686-aabf-4ed1-b9e4-506d5e9bda88', CAST(5.50 AS Decimal(18, 2)), CAST(2.35 AS Decimal(20, 2)), CAST(2.20 AS Decimal(20, 2)), 0)
INSERT [dbo].[Beer] ([ID], [Name], [BreweryID], [AlcoholContent], [RetailPrice], [WholesalePrice], [IsDeleted]) VALUES (N'812a4bd9-366f-487e-a6e1-9cd2c9a82f9d', N'Organic Moinette - Belgian Beer', N'77f2b686-aabf-4ed1-b9e4-506d5e9bda88', CAST(7.50 AS Decimal(18, 2)), CAST(2.60 AS Decimal(20, 2)), CAST(2.45 AS Decimal(20, 2)), 0)
INSERT [dbo].[Beer] ([ID], [Name], [BreweryID], [AlcoholContent], [RetailPrice], [WholesalePrice], [IsDeleted]) VALUES (N'0a6d73d8-4802-4d42-b365-d2e626b2509d', N'Lindemans Faro Lambic - Red Belgian Beer', N'10bf3cfc-afd1-437c-bc33-7527c5593938', CAST(4.50 AS Decimal(18, 2)), CAST(1.60 AS Decimal(20, 2)), CAST(1.50 AS Decimal(20, 2)), 0)
INSERT [dbo].[Beer] ([ID], [Name], [BreweryID], [AlcoholContent], [RetailPrice], [WholesalePrice], [IsDeleted]) VALUES (N'fc3e35c3-a0f4-47b2-adf5-6b72499c921a', N'Lindemans Pécheresse - Peach Beer', N'10bf3cfc-afd1-437c-bc33-7527c5593938', CAST(2.50 AS Decimal(18, 2)), CAST(2.00 AS Decimal(20, 2)), CAST(1.90 AS Decimal(20, 2)), 0)
INSERT [dbo].[Beer] ([ID], [Name], [BreweryID], [AlcoholContent], [RetailPrice], [WholesalePrice], [IsDeleted]) VALUES (N'933eac73-bd99-47e3-b6c6-8095b4778b00', N'Strawberries Lindemans Framboise', N'10bf3cfc-afd1-437c-bc33-7527c5593938', CAST(2.50 AS Decimal(18, 2)), CAST(2.00 AS Decimal(20, 2)), CAST(1.80 AS Decimal(20, 2)), 0)
INSERT [dbo].[Beer] ([ID], [Name], [BreweryID], [AlcoholContent], [RetailPrice], [WholesalePrice], [IsDeleted]) VALUES (N'f3ad8206-a1aa-41e0-9e65-03d11e160b1d', N'Corsendonk Pater Dubbel Ale', N'1b4f49c2-9ca8-4e87-bebb-d83d200680c7', CAST(6.50 AS Decimal(18, 2)), CAST(3.25 AS Decimal(20, 2)), CAST(3.10 AS Decimal(20, 2)), 0)
INSERT [dbo].[Beer] ([ID], [Name], [BreweryID], [AlcoholContent], [RetailPrice], [WholesalePrice], [IsDeleted]) VALUES (N'3b556575-fb25-4ea2-ad33-ad41e6c0e69c', N'Corsendonk white beer', N'1b4f49c2-9ca8-4e87-bebb-d83d200680c7', CAST(4.80 AS Decimal(18, 2)), CAST(1.80 AS Decimal(20, 2)), CAST(1.50 AS Decimal(20, 2)), 0)
INSERT [dbo].[Beer] ([ID], [Name], [BreweryID], [AlcoholContent], [RetailPrice], [WholesalePrice], [IsDeleted]) VALUES (N'25527540-745c-4622-96ce-96ed205137cb', N'Gulden Draak - Dark Belgian Beer', N'1b4f49c2-9ca8-4e87-bebb-d83d200680c7', CAST(10.50 AS Decimal(18, 2)), CAST(2.45 AS Decimal(20, 2)), CAST(2.10 AS Decimal(20, 2)), 0)
INSERT [dbo].[Brewery] ([ID], [Name]) VALUES (N'77f2b686-aabf-4ed1-b9e4-506d5e9bda88', N'Brasserie Dupont')
INSERT [dbo].[Brewery] ([ID], [Name]) VALUES (N'10bf3cfc-afd1-437c-bc33-7527c5593938', N'Brasserie Lindemans')
INSERT [dbo].[Brewery] ([ID], [Name]) VALUES (N'1b4f49c2-9ca8-4e87-bebb-d83d200680c7', N'Van Steenberge')
INSERT [dbo].[Wholesaler] ([ID], [Name]) VALUES (N'481b8ced-3fa6-4bc1-beee-2077e4f27fab', N'Belgibeer')
INSERT [dbo].[Wholesaler] ([ID], [Name]) VALUES (N'a2fa5b28-77be-47e9-92d9-851d28b8831d', N'Carlsberg Importers')
INSERT [dbo].[Wholesaler] ([ID], [Name]) VALUES (N'3f9ff53e-ba16-449d-b999-cc34d15a7bbc', N'Drinks Center Fontana')
/****** Object:  Index [IX_WholesalerStock_BeerID]    Script Date: 8/14/2022 7:58:41 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_WholesalerStock_BeerID] ON [dbo].[WholesalerStock]
(
	[BeerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [BreweryManagement] SET  READ_WRITE 
GO
