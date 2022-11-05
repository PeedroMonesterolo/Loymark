USE [master]
GO


CREATE DATABASE [loymark]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'loymark', FILENAME = N'C:\Users\Pedro\loymark.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'loymark_log', FILENAME = N'C:\Users\Pedro\loymark_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [loymark] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [loymark].[dbo].[sp_fulltext_database] @action = 'enable'
END
GO
ALTER DATABASE [loymark] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [loymark] SET ANSI_NULLS OFF
GO
ALTER DATABASE [loymark] SET ANSI_PADDING OFF
GO
ALTER DATABASE [loymark] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [loymark] SET ARITHABORT OFF
GO
ALTER DATABASE [loymark] SET AUTO_CLOSE ON
GO
ALTER DATABASE [loymark] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [loymark] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [loymark] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [loymark] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [loymark] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [loymark] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [loymark] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [loymark] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [loymark] SET  ENABLE_BROKER
GO
ALTER DATABASE [loymark] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [loymark] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [loymark] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [loymark] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [loymark] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [loymark] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [loymark] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [loymark] SET RECOVERY SIMPLE
GO
ALTER DATABASE [loymark] SET  MULTI_USER
GO
ALTER DATABASE [loymark] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [loymark] SET DB_CHAINING OFF
GO
ALTER DATABASE [loymark] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO
ALTER DATABASE [loymark] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO
ALTER DATABASE [loymark] SET DELAYED_DURABILITY = DISABLED
GO
ALTER DATABASE [loymark] SET QUERY_STORE = OFF
GO
USE [loymark]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [loymark]
GO
/****** Object:  Table [dbo].[Actividad]    Script Date: 05/11/2022 19:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actividad](
	[id_actividad] [int] IDENTITY(1,1) NOT NULL,
	[create_date] [datetime] NOT NULL,
	[id_usuario] [int] NOT NULL,
	[actividad] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id_actividad] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 05/11/2022 19:36:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NOT NULL,
	[apellido] [varchar](35) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[fecha_nacimiento] [date] NOT NULL,
	[telefono] [bigint] NULL,
	[cod_pais] [varchar](3) NOT NULL,
	[recibir_info] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (NULL) FOR [telefono]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((0)) FOR [recibir_info]
GO
ALTER TABLE [dbo].[Actividad]  WITH CHECK ADD  CONSTRAINT [FK_id_usuario] FOREIGN KEY([id_usuario])
REFERENCES [dbo].[Usuarios] ([id])
GO
ALTER TABLE [dbo].[Actividad] CHECK CONSTRAINT [FK_id_usuario]
GO
USE [master]
GO
ALTER DATABASE [loymark] SET  READ_WRITE
GO



-- INSERCCION EN TABLA Usuarios
INSERT INTO loymark.dbo.Usuarios (nombre, apellido, email, fecha_nacimiento, cod_pais, recibir_info, telefono)
	VALUES ('Pedro', 'Monesterolo', 'peedromonesterolo@gmail.com', '1995-11-05', 'ARG', 1, NULL),
	('Fernando', 'Fernandez', 'ffernandez@gmail.com', '2022-11-05', 'BRA', 0, 3533487689),
	('Esteban', 'Quito', 'equito@gmail.com', '1990-01-14', 'CHL', 1, 3533422862),
	('Matias', 'Juncal', 'mjuncal@gmail.com', '2001-03-01', 'ARG', 1, 3533476294),
	('Matias', 'Fernandez', 'mfernandez@gmail.com', '2005-02-22', 'ARG', 1, 3533476294),
	('Gaspar', 'Santillan', 'gsantillas@gmail.com', '2022-11-05', 'BRA', 1, 3533476294),
	('Agustin', 'Fortini', 'afortini@gmail.com', '1992-09-09', 'CHL', 1, NULL),
	('Nestor', 'Rivera', 'nrivera@gmail.com', '1990-04-12', 'BRA', 1, 3533476294),
	('Maximiliano', 'Mino', 'mmino@gmail.com', '1993-07-17', 'ARG', 1, NULL),
	('Matias', 'Narvaja', 'mnarvaja@gmail.com', '1997-08-18', 'BRA', 1, 3533365491),
	('Pedro', 'Rivera', 'privera@gmail.com', '2008-01-11', 'BRA', 1, NULL)

-- INSERCCION EN TABLA Actividad
INSERT INTO loymark.dbo.Actividad (create_date, id_usuario, actividad)
	VALUES (DATEADD(DAY, -11, GETDATE()), 1, 'Creación de Usuario'),
	(DATEADD(DAY, -10, GETDATE()), 2, 'Creación de Usuario'),
	(DATEADD(DAY, -9, GETDATE()), 3, 'Creación de Usuario'),
	(DATEADD(DAY, -8, GETDATE()), 4, 'Creación de Usuario'),
	(DATEADD(DAY, -7, GETDATE()), 5, 'Creación de Usuario'),
	(DATEADD(DAY, -6, GETDATE()), 6, 'Creación de Usuario'),
	(DATEADD(DAY, -5, GETDATE()), 7, 'Creación de Usuario'),
	(DATEADD(DAY, -4, GETDATE()), 8, 'Creación de Usuario'),
	(DATEADD(DAY, -3, GETDATE()), 9, 'Creación de Usuario'),
	(DATEADD(DAY, -2, GETDATE()), 10, 'Creación de Usuario'),
	(DATEADD(DAY, -1, GETDATE()), 11, 'Creación de Usuario'),
	(DATEADD(DAY, -7, GETDATE()), 4, 'Actualización de Usuario'),
	(DATEADD(DAY, -7, GETDATE()), 5, 'Actualización de Usuario'),
	(DATEADD(DAY, -1, GETDATE()), 2, 'Actualización de Usuario'),
	(DATEADD(DAY, -7, GETDATE()), 11, 'Actualización de Usuario'),
	(DATEADD(DAY, -3, GETDATE()), 5, 'Actualización de Usuario')
