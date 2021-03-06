USE [master]
GO
/****** Object:  Database [stock]    Script Date: 05/09/2017 00:21:49 ******/
CREATE DATABASE [stock] ON  PRIMARY 
( NAME = N'stock', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\stock.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'stock_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\stock_1.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [stock] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [stock].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [stock] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [stock] SET ANSI_NULLS OFF
GO
ALTER DATABASE [stock] SET ANSI_PADDING OFF
GO
ALTER DATABASE [stock] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [stock] SET ARITHABORT OFF
GO
ALTER DATABASE [stock] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [stock] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [stock] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [stock] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [stock] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [stock] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [stock] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [stock] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [stock] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [stock] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [stock] SET  DISABLE_BROKER
GO
ALTER DATABASE [stock] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [stock] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [stock] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [stock] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [stock] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [stock] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [stock] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [stock] SET  READ_WRITE
GO
ALTER DATABASE [stock] SET RECOVERY SIMPLE
GO
ALTER DATABASE [stock] SET  MULTI_USER
GO
ALTER DATABASE [stock] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [stock] SET DB_CHAINING OFF
GO
USE [stock]
GO
/****** Object:  Table [dbo].[csi]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[csi](
	[date] [date] NULL,
	[open] [float] NULL,
	[highest] [float] NULL,
	[lowest] [float] NULL,
	[closeure] [float] NULL,
	[volume] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[asset]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[asset](
	[asset] [decimal](18, 0) NULL,
	[real] [decimal](18, 0) NULL,
	[date] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[areacolumn]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[areacolumn](
	[name] [nvarchar](50) NULL,
	[area] [nvarchar](50) NULL,
	[value] [nvarchar](50) NULL,
	[datetime] [datetime] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[area]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[area](
	[area] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usi]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usi](
	[date] [date] NULL,
	[open] [float] NULL,
	[highest] [float] NULL,
	[lowest] [float] NULL,
	[closeure] [float] NULL,
	[volume] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stockremarks]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stockremarks](
	[no] [int] NULL,
	[remarks] [nvarchar](1000) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[stock]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stock](
	[stockno] [nvarchar](50) NULL,
	[buy] [float] NULL,
	[expectedsold] [float] NULL,
	[sold] [float] NULL,
	[owned] [int] NULL,
	[bdate] [date] NULL,
	[sdate] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rsimon]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rsimon](
	[stockno] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rsihistory]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rsihistory](
	[date] [date] NULL,
	[stockno] [int] NULL,
	[rsi] [float] NULL,
	[open] [float] NULL,
	[close] [float] NULL,
	[highest] [float] NULL,
	[lowest] [float] NULL,
	[volume] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rsi]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rsi](
	[stockno] [int] NOT NULL,
	[name] [nvarchar](50) NULL,
	[rsi] [float] NULL,
	[date] [datetime] NULL,
	[ignore] [bit] NULL,
	[volume] [float] NULL,
	[PE] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[ii] [nvarchar](50) NULL,
	[rid] [int] IDENTITY(1,1) NOT NULL,
	[infl] [float] NULL,
	[sph] [int] NULL,
 CONSTRAINT [PK_rsi_stockno] PRIMARY KEY CLUSTERED 
(
	[stockno] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[remarks]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[remarks](
	[date] [datetime] NULL,
	[remarks] [ntext] NULL,
	[removestamp] [nvarchar](20) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pptlearning]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pptlearning](
	[weight] [float] NULL,
	[pptName] [nvarchar](50) NULL,
	[th] [float] NULL,
	[stockno] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[patternhsi]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[patternhsi](
	[start] [float] NULL,
	[highest] [float] NULL,
	[lowest] [float] NULL,
	[closure] [float] NULL,
	[volume] [float] NULL,
	[date] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pattern]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pattern](
	[hsi] [float] NULL,
	[csi] [float] NULL,
	[hsip] [float] NULL,
	[csip] [float] NULL,
	[date] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[indexlist]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[indexlist](
	[url] [nvarchar](500) NULL,
	[indexname] [nvarchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[hsi]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hsi](
	[date] [date] NULL,
	[open] [float] NULL,
	[highest] [float] NULL,
	[lowest] [float] NULL,
	[closeure] [float] NULL,
	[volume] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gsi]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gsi](
	[date] [date] NULL,
	[open] [float] NULL,
	[highest] [float] NULL,
	[lowest] [float] NULL,
	[closeure] [float] NULL,
	[volume] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[focushistory]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[focushistory](
	[date] [date] NULL,
	[category] [nvarchar](50) NULL,
	[value] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[focus]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[focus](
	[stockno] [nvarchar](50) NULL,
	[category] [nvarchar](50) NULL,
	[remarks] [nvarchar](200) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[esi]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[esi](
	[date] [date] NULL,
	[open] [float] NULL,
	[highest] [float] NULL,
	[lowest] [float] NULL,
	[closeure] [float] NULL,
	[volume] [float] NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CustomStoredProcedure]    Script Date: 05/09/2017 00:21:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		sam
-- Create date: 2016/3/8
-- Description:	test
-- =============================================
CREATE PROCEDURE [dbo].[CustomStoredProcedure]
	-- Add the parameters for the stored procedure here
	@stockno nvarchar(50) = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT stockno
	FROM rsi where stockno=@stockno;
END
GO
