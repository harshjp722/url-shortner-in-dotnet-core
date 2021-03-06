USE [master]
GO
/****** Object:  Database [URLShortnerDotnetCore]    Script Date: 4/22/2018 12:28:41 AM ******/
CREATE DATABASE [URLShortnerDotnetCore] ON  PRIMARY 
( NAME = N'URLShortnerDotnetCore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\URLShortnerDotnetCore.mdf' , SIZE = 2048KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'URLShortnerDotnetCore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\URLShortnerDotnetCore_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [URLShortnerDotnetCore] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [URLShortnerDotnetCore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [URLShortnerDotnetCore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET ARITHABORT OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET RECOVERY FULL 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET  MULTI_USER 
GO
ALTER DATABASE [URLShortnerDotnetCore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [URLShortnerDotnetCore] SET DB_CHAINING OFF 
GO
USE [URLShortnerDotnetCore]
GO
/****** Object:  Table [dbo].[ShortURLLog]    Script Date: 4/22/2018 12:28:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShortURLLog](
	[ID] [bigint] IDENTITY(1000,1) NOT NULL,
	[Code] [nvarchar](20) NULL,
	[LongURL] [nvarchar](max) NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ShortURLLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [URLShortnerDotnetCore] SET  READ_WRITE 
GO
