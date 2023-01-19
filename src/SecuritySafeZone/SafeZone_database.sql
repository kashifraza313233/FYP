USE [master]
GO
/****** Object:  Database [SafeZone]    Script Date: 1/19/2023 10:18:06 PM ******/
CREATE DATABASE [SafeZone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SafeZone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\SafeZone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SafeZone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS01\MSSQL\DATA\SafeZone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SafeZone] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SafeZone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SafeZone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SafeZone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SafeZone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SafeZone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SafeZone] SET ARITHABORT OFF 
GO
ALTER DATABASE [SafeZone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SafeZone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SafeZone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SafeZone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SafeZone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SafeZone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SafeZone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SafeZone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SafeZone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SafeZone] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SafeZone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SafeZone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SafeZone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SafeZone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SafeZone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SafeZone] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SafeZone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SafeZone] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SafeZone] SET  MULTI_USER 
GO
ALTER DATABASE [SafeZone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SafeZone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SafeZone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SafeZone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SafeZone] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SafeZone] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SafeZone] SET QUERY_STORE = OFF
GO
USE [SafeZone]
GO
/****** Object:  Table [dbo].[AdminLogin]    Script Date: 1/19/2023 10:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdminLogin](
	[Aid] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
 CONSTRAINT [PK_AdminLogin] PRIMARY KEY CLUSTERED 
(
	[Aid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 1/19/2023 10:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [varchar](max) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Police]    Script Date: 1/19/2023 10:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Police](
	[Pid] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Designation] [varchar](50) NULL,
	[status] [int] NOT NULL,
	[CNIC] [varchar](50) NULL,
 CONSTRAINT [PK_Police] PRIMARY KEY CLUSTERED 
(
	[Pid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Report]    Script Date: 1/19/2023 10:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Report](
	[Rid] [int] IDENTITY(1,1) NOT NULL,
	[Uid] [int] NULL,
	[Type] [varchar](100) NULL,
	[Description] [varchar](500) NULL,
	[Time] [time](7) NULL,
	[Date] [date] NULL,
	[Lat] [varchar](100) NULL,
	[Lng] [varchar](100) NULL,
	[Status] [varchar](100) NULL,
	[Address] [varchar](500) NULL,
	[Pid] [int] NULL,
	[Boundary] [nvarchar](500) NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[Rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 1/19/2023 10:18:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Uid] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[CNIC] [varchar](100) NULL,
	[Email] [varchar](50) NULL,
	[ContactNo] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[status] [int] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_Police] FOREIGN KEY([Pid])
REFERENCES [dbo].[Police] ([Pid])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_Police]
GO
ALTER TABLE [dbo].[Report]  WITH CHECK ADD  CONSTRAINT [FK_Report_User] FOREIGN KEY([Uid])
REFERENCES [dbo].[User] ([Uid])
GO
ALTER TABLE [dbo].[Report] CHECK CONSTRAINT [FK_Report_User]
GO
USE [master]
GO
ALTER DATABASE [SafeZone] SET  READ_WRITE 
GO
