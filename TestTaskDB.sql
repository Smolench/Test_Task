USE [master]
GO
/****** Object:  Database [TestTaskDB]    Script Date: 03.05.2017 1:09:50 ******/
CREATE DATABASE [TestTaskDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestTaskDB', FILENAME = N'D:\MS MySQL server\MSSQL12.SMOLENCH\MSSQL\DATA\TestTaskDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TestTaskDB_log', FILENAME = N'D:\MS MySQL server\MSSQL12.SMOLENCH\MSSQL\DATA\TestTaskDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TestTaskDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestTaskDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestTaskDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestTaskDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestTaskDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestTaskDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestTaskDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestTaskDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestTaskDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestTaskDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestTaskDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestTaskDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestTaskDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestTaskDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestTaskDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestTaskDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestTaskDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestTaskDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestTaskDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestTaskDB] SET RECOVERY FULL 
GO
ALTER DATABASE [TestTaskDB] SET  MULTI_USER 
GO
ALTER DATABASE [TestTaskDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestTaskDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestTaskDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestTaskDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TestTaskDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'TestTaskDB', N'ON'
GO
USE [TestTaskDB]
GO
/****** Object:  Table [dbo].[Company]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NULL,
	[size] [int] NULL,
	[form] [varchar](50) NULL,
 CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Worker]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Worker](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [varchar](50) NULL,
	[second_name] [varchar](50) NULL,
	[middle_name] [varchar](50) NULL,
	[entry_date] [date] NULL,
	[position] [varchar](50) NULL,
	[company] [varchar](50) NULL,
 CONSTRAINT [PK_Worker] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[AddNewCompanyDetails]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[AddNewCompanyDetails] 
	@name varchar(50),
	@size int,
	@form varchar(50)
AS
BEGIN
	INSERT INTO [dbo].[Company] VALUES(@name,@size,@form) 
END

GO
/****** Object:  StoredProcedure [dbo].[AddNewWorkerDetails]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[AddNewWorkerDetails] 
	 @first_name varchar (50),  
     @second_name varchar (50),  
     @middle_name varchar (50),
	 @entry_date date,
	 @position varchar (50),
	 @company varchar (50)
AS
BEGIN
	INSERT INTO [dbo].[Worker] VALUES(@first_name,@second_name,@middle_name,@entry_date,@position,@company)   
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteCompanyById]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCompanyById] 
	@id int
AS
BEGIN
	DELETE FROM [dbo].[Company] WHERE id=@id
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteWorkerById]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteWorkerById] 
	@id int
AS
BEGIN
	DELETE FROM [dbo].[Worker] where id=@id  
END

GO
/****** Object:  StoredProcedure [dbo].[GetCompanies]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetCompanies] 
	
AS
BEGIN
	SELECT * FROM [dbo].[Company]
END

GO
/****** Object:  StoredProcedure [dbo].[GetWorkers]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[GetWorkers] 	
AS
BEGIN
	SELECT * FROM [dbo].[Worker]  
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateCompanyDetails]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCompanyDetails] 
	@id int,
	@name varchar(50),
	@size int,
	@form varchar(50)
AS
BEGIN
	UPDATE [dbo].[Company]
	SET name=@name,
	size=@size,
	form=@form
	WHERE id=@id
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateWorkerDetails]    Script Date: 03.05.2017 1:09:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		
-- Create date: 
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[UpdateWorkerDetails] 
	 @id int,
	 @first_name varchar (50),  
     @second_name varchar (50),  
     @middle_name varchar (50),
	 @entry_date date,
	 @position varchar (50),
	 @company varchar (50)
AS
BEGIN
	UPDATE [dbo].[Worker]   
    SET first_name=@first_name,  
    second_name=@second_name,  
    middle_name=@middle_name,
	entry_date=@entry_date,
	position=@position,
	company=@company  
   where id=@id  
END

GO
USE [master]
GO
ALTER DATABASE [TestTaskDB] SET  READ_WRITE 
GO
