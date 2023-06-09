USE [master]
GO
/****** Object:  Database [HotelDb]    Script Date: 7/04/2023 10:45:33 p. m. ******/
CREATE DATABASE [HotelDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HotelDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HotelDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HotelDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\HotelDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [HotelDb] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HotelDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HotelDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HotelDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HotelDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HotelDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HotelDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [HotelDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HotelDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HotelDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HotelDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HotelDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HotelDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HotelDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HotelDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HotelDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HotelDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HotelDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HotelDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HotelDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HotelDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HotelDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HotelDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [HotelDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HotelDb] SET RECOVERY FULL 
GO
ALTER DATABASE [HotelDb] SET  MULTI_USER 
GO
ALTER DATABASE [HotelDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HotelDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HotelDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HotelDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HotelDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [HotelDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'HotelDb', N'ON'
GO
ALTER DATABASE [HotelDb] SET QUERY_STORE = ON
GO
ALTER DATABASE [HotelDb] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [HotelDb]
GO
/****** Object:  Table [dbo].[ContactoEmergencia]    Script Date: 7/04/2023 10:45:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactoEmergencia](
	[ContactoId] [uniqueidentifier] NOT NULL,
	[PasajeroId] [uniqueidentifier] NOT NULL,
	[ContactoNombre] [nvarchar](200) NOT NULL,
	[ContactoTelefono] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ContactoEmergencia] PRIMARY KEY CLUSTERED 
(
	[ContactoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Habitacion]    Script Date: 7/04/2023 10:45:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Habitacion](
	[HabitacionId] [uniqueidentifier] NOT NULL,
	[HotelId] [uniqueidentifier] NOT NULL,
	[HabitacionTipo] [nvarchar](200) NOT NULL,
	[HabitacionPrecio] [decimal](18, 2) NOT NULL,
	[HabitacionDisponibilidad] [int] NOT NULL,
 CONSTRAINT [PK_Habitacion] PRIMARY KEY CLUSTERED 
(
	[HabitacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hotel]    Script Date: 7/04/2023 10:45:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hotel](
	[HotelId] [uniqueidentifier] NOT NULL,
	[HotelNombre] [nvarchar](150) NOT NULL,
	[HotelCiudad] [nvarchar](150) NOT NULL,
	[HotelFechaCreacion] [datetime2](7) NOT NULL,
	[HotelFechaSalida] [datetime2](7) NOT NULL,
	[HotelNumPersonas] [int] NOT NULL,
	[HotelDisponibilidad] [int] NOT NULL,
 CONSTRAINT [PK_Hotel] PRIMARY KEY CLUSTERED 
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pasajero]    Script Date: 7/04/2023 10:45:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pasajero](
	[PasajeroId] [uniqueidentifier] NOT NULL,
	[PasajeroNombre] [nvarchar](150) NOT NULL,
	[PasajeroApellido] [nvarchar](150) NOT NULL,
	[PasajeroFechaNacimiento] [datetime2](7) NOT NULL,
	[PasajeroGenero] [nvarchar](max) NOT NULL,
	[PasajeroTipoDocumento] [nvarchar](max) NOT NULL,
	[PasajeroNumeroDocumento] [nvarchar](max) NOT NULL,
	[PasajeroEmail] [nvarchar](max) NOT NULL,
	[PasajeroTelefono] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Pasajero] PRIMARY KEY CLUSTERED 
(
	[PasajeroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reserva]    Script Date: 7/04/2023 10:45:34 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reserva](
	[ReservaId] [uniqueidentifier] NOT NULL,
	[PasajeroId] [uniqueidentifier] NOT NULL,
	[HabitacionId] [uniqueidentifier] NOT NULL,
	[ReservaFecha] [datetime2](7) NOT NULL,
	[ReservaPrecio] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Reserva] PRIMARY KEY CLUSTERED 
(
	[ReservaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ContactoEmergencia] ([ContactoId], [PasajeroId], [ContactoNombre], [ContactoTelefono]) VALUES (N'fe2de405-c38e-4c90-ac52-da0540dfb410', N'fe2de405-c38e-4c90-ac52-da0540dfb4ef', N'Javier', N'1114445')
GO
INSERT [dbo].[Habitacion] ([HabitacionId], [HotelId], [HabitacionTipo], [HabitacionPrecio], [HabitacionDisponibilidad]) VALUES (N'fe2de405-c38e-4c90-ac52-da0540dfb410', N'fe2de405-c38e-4c90-ac52-da0540dfb4ef', N'cama doble', CAST(10000.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Hotel] ([HotelId], [HotelNombre], [HotelCiudad], [HotelFechaCreacion], [HotelFechaSalida], [HotelNumPersonas], [HotelDisponibilidad]) VALUES (N'fe2de405-c38e-4c90-ac52-da0540dfb4ef', N'Hotel Cariongo', N'Pamplona', CAST(N'2023-04-07T22:25:53.4053681' AS DateTime2), CAST(N'2023-04-07T22:25:53.4053699' AS DateTime2), 4, 1)
GO
INSERT [dbo].[Pasajero] ([PasajeroId], [PasajeroNombre], [PasajeroApellido], [PasajeroFechaNacimiento], [PasajeroGenero], [PasajeroTipoDocumento], [PasajeroNumeroDocumento], [PasajeroEmail], [PasajeroTelefono]) VALUES (N'fe2de405-c38e-4c90-ac52-da0540dfb4ef', N'Andres', N'Gonzales', CAST(N'2023-04-07T22:25:53.4060287' AS DateTime2), N'Masculino', N'cc', N'1094270086', N'admin@gmail.com', N'3102311234')
GO
INSERT [dbo].[Reserva] ([ReservaId], [PasajeroId], [HabitacionId], [ReservaFecha], [ReservaPrecio]) VALUES (N'fe2de405-c38e-4c90-ac52-da0540dfb410', N'fe2de405-c38e-4c90-ac52-da0540dfb4ef', N'fe2de405-c38e-4c90-ac52-da0540dfb410', CAST(N'2023-04-07T22:25:53.4066451' AS DateTime2), CAST(12000.00 AS Decimal(18, 2)))
GO
/****** Object:  Index [IX_ContactoEmergencia_PasajeroId]    Script Date: 7/04/2023 10:45:34 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_ContactoEmergencia_PasajeroId] ON [dbo].[ContactoEmergencia]
(
	[PasajeroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Habitacion_HotelId]    Script Date: 7/04/2023 10:45:34 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Habitacion_HotelId] ON [dbo].[Habitacion]
(
	[HotelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reserva_HabitacionId]    Script Date: 7/04/2023 10:45:34 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Reserva_HabitacionId] ON [dbo].[Reserva]
(
	[HabitacionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reserva_PasajeroId]    Script Date: 7/04/2023 10:45:34 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Reserva_PasajeroId] ON [dbo].[Reserva]
(
	[PasajeroId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[ContactoEmergencia]  WITH CHECK ADD  CONSTRAINT [FK_ContactoEmergencia_Pasajero_PasajeroId] FOREIGN KEY([PasajeroId])
REFERENCES [dbo].[Pasajero] ([PasajeroId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ContactoEmergencia] CHECK CONSTRAINT [FK_ContactoEmergencia_Pasajero_PasajeroId]
GO
ALTER TABLE [dbo].[Habitacion]  WITH CHECK ADD  CONSTRAINT [FK_Habitacion_Hotel_HotelId] FOREIGN KEY([HotelId])
REFERENCES [dbo].[Hotel] ([HotelId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Habitacion] CHECK CONSTRAINT [FK_Habitacion_Hotel_HotelId]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Habitacion_HabitacionId] FOREIGN KEY([HabitacionId])
REFERENCES [dbo].[Habitacion] ([HabitacionId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Habitacion_HabitacionId]
GO
ALTER TABLE [dbo].[Reserva]  WITH CHECK ADD  CONSTRAINT [FK_Reserva_Pasajero_PasajeroId] FOREIGN KEY([PasajeroId])
REFERENCES [dbo].[Pasajero] ([PasajeroId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reserva] CHECK CONSTRAINT [FK_Reserva_Pasajero_PasajeroId]
GO
USE [master]
GO
ALTER DATABASE [HotelDb] SET  READ_WRITE 
GO
