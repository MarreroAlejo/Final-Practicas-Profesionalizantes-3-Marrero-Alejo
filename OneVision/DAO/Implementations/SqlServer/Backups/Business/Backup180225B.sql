USE [master]
GO
/****** Object:  Database [OneVisionBD]    Script Date: 18/2/2025 19:11:23 ******/
CREATE DATABASE [OneVisionBD]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OneVisionBD', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OneVisionBD.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OneVisionBD_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\OneVisionBD_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [OneVisionBD] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OneVisionBD].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OneVisionBD] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OneVisionBD] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OneVisionBD] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OneVisionBD] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OneVisionBD] SET ARITHABORT OFF 
GO
ALTER DATABASE [OneVisionBD] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [OneVisionBD] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OneVisionBD] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OneVisionBD] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OneVisionBD] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OneVisionBD] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OneVisionBD] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OneVisionBD] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OneVisionBD] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OneVisionBD] SET  DISABLE_BROKER 
GO
ALTER DATABASE [OneVisionBD] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OneVisionBD] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OneVisionBD] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OneVisionBD] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OneVisionBD] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OneVisionBD] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [OneVisionBD] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OneVisionBD] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OneVisionBD] SET  MULTI_USER 
GO
ALTER DATABASE [OneVisionBD] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OneVisionBD] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OneVisionBD] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OneVisionBD] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OneVisionBD] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OneVisionBD] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [OneVisionBD] SET QUERY_STORE = ON
GO
ALTER DATABASE [OneVisionBD] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [OneVisionBD]
GO
/****** Object:  UserDefinedTableType [dbo].[DetallePedido]    Script Date: 18/2/2025 19:11:23 ******/
CREATE TYPE [dbo].[DetallePedido] AS TABLE(
	[idProducto] [uniqueidentifier] NULL,
	[cantidad] [int] NULL,
	[subtotal] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[DetallePedidoType]    Script Date: 18/2/2025 19:11:23 ******/
CREATE TYPE [dbo].[DetallePedidoType] AS TABLE(
	[idDetallePedido] [uniqueidentifier] NULL,
	[idProducto] [uniqueidentifier] NULL,
	[cantidad] [int] NULL,
	[subtotal] [decimal](18, 2) NULL
)
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idCliente] [int] IDENTITY(1,1) NOT NULL,
	[nroDocumento] [int] NOT NULL,
	[nombre] [nvarchar](60) NOT NULL,
	[apellido] [nvarchar](60) NOT NULL,
	[direccion] [nvarchar](100) NOT NULL,
	[codPostal] [int] NOT NULL,
	[telefono] [nvarchar](20) NOT NULL,
	[mail] [nvarchar](100) NOT NULL,
	[barrio] [nvarchar](100) NOT NULL,
	[provincia] [nvarchar](100) NOT NULL,
	[fechaRegistro] [datetime] NOT NULL,
	[estado] [int] NOT NULL,
 CONSTRAINT [PK__Cliente__D5946642003B364E] PRIMARY KEY CLUSTERED 
(
	[idCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[idDetallePedido] [uniqueidentifier] NOT NULL,
	[idProducto] [uniqueidentifier] NULL,
	[IdPedido] [uniqueidentifier] NULL,
	[cantidad] [int] NULL,
	[subtotal] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[idDetallePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleado]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleado](
	[idEmpleado] [uniqueidentifier] NOT NULL,
	[idUsuario] [uniqueidentifier] NULL,
	[idSucursal] [uniqueidentifier] NOT NULL,
	[idFamilia] [uniqueidentifier] NULL,
	[nombre] [nchar](60) NULL,
	[apellido] [nchar](100) NULL,
	[mail] [nchar](60) NULL,
	[telefono] [nchar](11) NULL,
	[fechaRegistro] [datetime] NULL,
 CONSTRAINT [PK_Empleado] PRIMARY KEY CLUSTERED 
(
	[idEmpleado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventario]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventario](
	[idInventario] [uniqueidentifier] NOT NULL,
	[idProducto] [uniqueidentifier] NULL,
	[idSucursal] [uniqueidentifier] NULL,
	[cantidad] [int] NULL,
	[reserva] [int] NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_Inventario] PRIMARY KEY CLUSTERED 
(
	[idInventario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[idPedido] [uniqueidentifier] NOT NULL,
	[idEmpleado] [uniqueidentifier] NULL,
	[idCliente] [int] NULL,
	[total] [nchar](10) NULL,
	[estado] [int] NULL,
	[fechaRegistro] [datetime] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [uniqueidentifier] NOT NULL,
	[codProducto] [nchar](15) NULL,
	[nombre] [nchar](50) NULL,
	[descripcion] [nchar](60) NULL,
	[categoria] [nchar](60) NULL,
	[precioVenta] [decimal](18, 2) NULL,
	[precioCompra] [decimal](18, 2) NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[idSucursal] [uniqueidentifier] NOT NULL,
	[nombre] [nchar](75) NULL,
	[direccion] [nchar](100) NULL,
	[telefono] [nchar](15) NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[idSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[idVenta] [uniqueidentifier] NOT NULL,
	[idPedido] [uniqueidentifier] NOT NULL,
	[valorFlete] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL,
	[estado] [int] NULL,
	[fechaRegistro] [datetime] NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[idVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (1, 12345678, N'Carlos', N'Pérez', N'Calle QUINTANA', 2, N'555-1234', N'Carlos.perez@example.com', N'Cordoba', N'Cordoba', CAST(N'2024-09-19T16:42:31.077' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (11, 3452, N'Paolo', N'asdasd', N'sdas', 123, N'123', N'asdasd', N'asda', N'dasd', CAST(N'2024-10-12T12:03:23.367' AS DateTime), 0)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (12, 56784933, N'Imanol Noah', N'Marrero', N'gral urqizq 11', 1602, N'12312315', N'ima@gmial.com', N'lamara', N'entrerios', CAST(N'2024-09-19T16:59:12.893' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (13, 55901213, N'Rocio', N'Marrero', N'Gral.Justo 1942', 1064, N'01123215235', N'romarr@gmailc.om', N'varela', N'bsas', CAST(N'2024-09-19T17:19:39.393' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (14, 45074351, N'Agustin Tomas', N'Repecka', N'Parana 5926', 1602, N'01150609993', N'agustinrepecka@gmail.com', N'Carapachay', N'Buenos Aires', CAST(N'2024-09-19T19:16:13.363' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (15, 41299310, N'Maia ', N'Frances', N'Camino Moron 1922', 1902, N'011678931', N'maia@example.com', N'san isidro', N'bsas', CAST(N'2024-10-12T11:47:15.513' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (16, 23128756, N'Ada', N'Caballo', N'San Justo 6123', 9874, N'23121234', N'ada30@gmail.com', N'Ceta', N'Catamarca', CAST(N'2024-10-12T11:53:58.113' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (17, 32231949, N'Leonardo', N'Frances', N'Camino Moron 892 ', 1284, N'0118349234', N'leof@gmail.com', N'San Isidro', N'Bs.As', CAST(N'2024-10-13T14:16:27.147' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (18, 101010, N'Lionel', N'Messi', N'Miami 123', 9893, N'123123123', N'leomessi@gmail.com', N'Florida', N'Miami', CAST(N'2024-10-13T14:20:39.600' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (19, 123123, N'jose', N'perez', N'3232', 123, N'023423', N'jose@gmail.com', N'cherry', N'chubut', CAST(N'2024-10-13T14:23:52.543' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (20, 39001288, N'Karina', N'Van Eck', N'Belgrano 989', 3921, N'011528319', N'karinavaneck@gmail.com', N'Dique Lujan', N'Bs.As', CAST(N'2024-10-13T14:49:29.053' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (21, 6, N'AA', N'A', N'A', 333, N'3', N'AA', N'AA', N'AA', CAST(N'2024-10-13T14:54:17.887' AS DateTime), 0)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (22, 43992611, N'Maia Ariadna', N'Frances ', N'Camino Real Moron y Panamericana', 1609, N'01161125660', N'francesmaiaa@gmail.com', N'San Isidro', N'Bs.As', CAST(N'2024-10-13T15:52:01.257' AS DateTime), 0)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (23, 21532943, N'alejandro', N'marrero', N'gral Justo Jose de Urquiza 1942', 1602, N'0117612136', N'amarrero@gmail.com', N'florida', N'bs.as', CAST(N'2024-10-15T17:43:27.467' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (1023, 44421000, N'alejo', N'marrero', N'gra', 9, N'0', N'ale', N'h', N'h', CAST(N'2024-11-21T16:22:08.043' AS DateTime), 0)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (1024, 1, N'alma', N'naque', N'godoy cruz 1', 9, N'011', N'almanaque@gmail.com', N'mendo', N'mendoza', CAST(N'2025-01-13T19:57:21.180' AS DateTime), 0)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (1025, 3, N'chris', N'gimenez', N's3', 1604, N'011', N'cg@', N'la boca', N'buenos aires', CAST(N'2025-01-22T16:07:36.327' AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[DetallePedido] ([idDetallePedido], [idProducto], [IdPedido], [cantidad], [subtotal]) VALUES (N'101a2945-2038-48fc-b871-bb57c9345376', N'350e1131-a923-47a2-b579-a867179eeb4f', N'eb8ca63f-009f-4d2f-a142-f801ccdd8719', 3, CAST(3000.00 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([idDetallePedido], [idProducto], [IdPedido], [cantidad], [subtotal]) VALUES (N'1bbfd4f0-7d11-43fc-b1dd-f3b061a27935', N'b656f588-47a4-4aaa-813f-9efae511be36', N'6e8dcfb9-f80f-4b4b-93a9-d49b3c7e64f8', 9, CAST(720008.91 AS Decimal(18, 2)))
GO
INSERT [dbo].[Empleado] ([idEmpleado], [idUsuario], [idSucursal], [idFamilia], [nombre], [apellido], [mail], [telefono], [fechaRegistro]) VALUES (N'a41234eb-bbb4-4922-966d-09f37cb48088', N'3e9d440b-cab0-4ce6-a4e7-e6fb45aeb356', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', N'0e1ee95c-c77b-4ac4-afff-36176f7f828e', N'Lionel Andres                                               ', N'Messi                                                                                               ', N'messismo@gmail.com                                          ', N'2          ', CAST(N'2025-02-17T21:54:16.000' AS DateTime))
INSERT [dbo].[Empleado] ([idEmpleado], [idUsuario], [idSucursal], [idFamilia], [nombre], [apellido], [mail], [telefono], [fechaRegistro]) VALUES (N'68be9367-0ace-475f-8274-11fcab7b879d', N'ccb08ad8-db65-4e20-b773-0612fa53f360', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', N'98a8bdd4-0901-4dc1-930d-7887a0c07bcc', N'Karina                                                      ', N'Van Eck                                                                                             ', N'kvan@gmail.com                                              ', N'0112343    ', CAST(N'2025-02-17T21:53:45.000' AS DateTime))
INSERT [dbo].[Empleado] ([idEmpleado], [idUsuario], [idSucursal], [idFamilia], [nombre], [apellido], [mail], [telefono], [fechaRegistro]) VALUES (N'e5cc1370-0a27-449e-a280-4dcd232bfd0a', N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'Alejo                                                       ', N'Marrero                                                                                             ', N'amarrero@agpruden.com                                       ', N'01161447979', CAST(N'2025-01-09T20:40:52.000' AS DateTime))
INSERT [dbo].[Empleado] ([idEmpleado], [idUsuario], [idSucursal], [idFamilia], [nombre], [apellido], [mail], [telefono], [fechaRegistro]) VALUES (N'2f83ac8e-bf93-4f93-8c82-7f029cf20f96', N'dfee2a03-59e2-4453-9839-93afdd326b56', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', N'98a8bdd4-0901-4dc1-930d-7887a0c07bcc', N'a                                                           ', N'a                                                                                                   ', N'a                                                           ', N'02         ', CAST(N'2025-01-29T15:51:07.213' AS DateTime))
INSERT [dbo].[Empleado] ([idEmpleado], [idUsuario], [idSucursal], [idFamilia], [nombre], [apellido], [mail], [telefono], [fechaRegistro]) VALUES (N'c1b0eb0c-0dc5-45b1-afbf-97162dcdd7a3', N'f56a972c-6d3e-4d7f-a982-dfcb0c74e3ad', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', N'2447a8bf-9da6-42a4-b672-378d70ef5707', N'Jorge                                                       ', N'Marchesich                                                                                          ', N'ivanmarchar@gmail.com                                       ', N'011614474  ', CAST(N'2024-11-17T00:22:01.000' AS DateTime))
INSERT [dbo].[Empleado] ([idEmpleado], [idUsuario], [idSucursal], [idFamilia], [nombre], [apellido], [mail], [telefono], [fechaRegistro]) VALUES (N'9a645195-f159-4027-bab9-fe8a31aad47e', N'709eb156-9da5-4812-ad0d-26d99a6a2e7f', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'p                                                           ', N'p                                                                                                   ', N'p                                                           ', N'1          ', CAST(N'2025-01-29T15:20:44.000' AS DateTime))
GO
INSERT [dbo].[Inventario] ([idInventario], [idProducto], [idSucursal], [cantidad], [reserva], [estado]) VALUES (N'ff184e90-048b-421e-ac3a-132886282eac', N'b656f588-47a4-4aaa-813f-9efae511be36', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', 6, 0, 1)
INSERT [dbo].[Inventario] ([idInventario], [idProducto], [idSucursal], [cantidad], [reserva], [estado]) VALUES (N'52bd4cd5-d586-421a-9d9f-27f7a8cb0860', N'350e1131-a923-47a2-b579-a867179eeb4f', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', 5, 0, 1)
INSERT [dbo].[Inventario] ([idInventario], [idProducto], [idSucursal], [cantidad], [reserva], [estado]) VALUES (N'58976216-6022-438a-9e04-31b62b09918d', N'b7950830-45f9-49e5-b7da-939fc7be72fd', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', 104, 5, 1)
INSERT [dbo].[Inventario] ([idInventario], [idProducto], [idSucursal], [cantidad], [reserva], [estado]) VALUES (N'1190e6d2-8268-4607-82ed-5178e83ee51e', N'2db0d016-ce11-42c9-b21e-0f574cbd32d3', N'd85e0abe-74e5-4e17-a9da-1326325d05ee', 27, 2, 1)
INSERT [dbo].[Inventario] ([idInventario], [idProducto], [idSucursal], [cantidad], [reserva], [estado]) VALUES (N'8c9245c2-feac-4673-a48f-cf434ef36ddb', N'2db0d016-ce11-42c9-b21e-0f574cbd32d3', N'9c4eaf8b-d5a6-4b71-bdfd-e9a9fdbd6993', 54, 2, 1)
GO
INSERT [dbo].[Pedido] ([idPedido], [idEmpleado], [idCliente], [total], [estado], [fechaRegistro]) VALUES (N'6e8dcfb9-f80f-4b4b-93a9-d49b3c7e64f8', N'c1b0eb0c-0dc5-45b1-afbf-97162dcdd7a3', 12, N'720008.91 ', 1, CAST(N'2025-02-11T19:48:38.827' AS DateTime))
INSERT [dbo].[Pedido] ([idPedido], [idEmpleado], [idCliente], [total], [estado], [fechaRegistro]) VALUES (N'eb8ca63f-009f-4d2f-a142-f801ccdd8719', N'c1b0eb0c-0dc5-45b1-afbf-97162dcdd7a3', 1, N'3000.00   ', 0, CAST(N'2025-02-18T18:28:34.103' AS DateTime))
GO
INSERT [dbo].[Producto] ([idProducto], [codProducto], [nombre], [descripcion], [categoria], [precioVenta], [precioCompra], [estado]) VALUES (N'2db0d016-ce11-42c9-b21e-0f574cbd32d3', N'LEN-0001       ', N'Lentes                                            ', N'Lentes de sol                                               ', N'Accesorio                                                   ', CAST(10000.00 AS Decimal(18, 2)), CAST(9000.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Producto] ([idProducto], [codProducto], [nombre], [descripcion], [categoria], [precioVenta], [precioCompra], [estado]) VALUES (N'1f9e69d2-82a6-4b57-a0d9-251ba51516af', N'Prueba         ', N'Prueba                                            ', N'Prueba                                                      ', N'Prueba                                                      ', CAST(434.00 AS Decimal(18, 2)), CAST(34.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Producto] ([idProducto], [codProducto], [nombre], [descripcion], [categoria], [precioVenta], [precioCompra], [estado]) VALUES (N'b7950830-45f9-49e5-b7da-939fc7be72fd', N'MOU-001        ', N'Mouse Logi                                        ', N'Mouse silencioso                                            ', N'Tecnologia                                                  ', CAST(10000.00 AS Decimal(18, 2)), CAST(7800.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [codProducto], [nombre], [descripcion], [categoria], [precioVenta], [precioCompra], [estado]) VALUES (N'2a9d3f29-81cf-43d1-b2a1-9486e9d92c80', N'GOR-001        ', N'Gorra NY                                          ', N'Gorra New York                                              ', N'Accesorios                                                  ', CAST(10000.00 AS Decimal(18, 2)), CAST(7500.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [codProducto], [nombre], [descripcion], [categoria], [precioVenta], [precioCompra], [estado]) VALUES (N'b656f588-47a4-4aaa-813f-9efae511be36', N'CEL-001        ', N'Celular                                           ', N'Celular Motorola                                            ', N'Tecnologia                                                  ', CAST(80000.99 AS Decimal(18, 2)), CAST(600000.00 AS Decimal(18, 2)), 0)
INSERT [dbo].[Producto] ([idProducto], [codProducto], [nombre], [descripcion], [categoria], [precioVenta], [precioCompra], [estado]) VALUES (N'350e1131-a923-47a2-b579-a867179eeb4f', N'PAS-001        ', N'Pasto Verde                                       ', N'Pasto verde para jardin                                     ', N'Jardineria                                                  ', CAST(1000.00 AS Decimal(18, 2)), CAST(900.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Sucursal] ([idSucursal], [nombre], [direccion], [telefono], [estado]) VALUES (N'd85e0abe-74e5-4e17-a9da-1326325d05ee', N'Liniers                                                                    ', N'Jose Hernandez 1942                                                                                 ', N'0114378583     ', 1)
INSERT [dbo].[Sucursal] ([idSucursal], [nombre], [direccion], [telefono], [estado]) VALUES (N'9c4eaf8b-d5a6-4b71-bdfd-e9a9fdbd6993', N'Florida                                                                    ', N'Yrigoyen 1230                                                                                       ', N'011231342      ', 1)
GO
INSERT [dbo].[Venta] ([idVenta], [idPedido], [valorFlete], [total], [estado], [fechaRegistro]) VALUES (N'81a573ae-be38-4bec-b155-5e3a2723f8f8', N'eb8ca63f-009f-4d2f-a142-f801ccdd8719', CAST(900.00 AS Decimal(18, 2)), CAST(3900.00 AS Decimal(18, 2)), 0, CAST(N'2025-02-18T18:32:38.690' AS DateTime))
GO
ALTER TABLE [dbo].[Cliente] ADD  CONSTRAINT [DF__Cliente__FechaRe__60A75C0F]  DEFAULT (getdate()) FOR [fechaRegistro]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([IdPedido])
REFERENCES [dbo].[Pedido] ([idPedido])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Producto]
GO
ALTER TABLE [dbo].[Empleado]  WITH CHECK ADD  CONSTRAINT [FK_Empleado_Sucursal] FOREIGN KEY([idSucursal])
REFERENCES [dbo].[Sucursal] ([idSucursal])
GO
ALTER TABLE [dbo].[Empleado] CHECK CONSTRAINT [FK_Empleado_Sucursal]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Producto] FOREIGN KEY([idProducto])
REFERENCES [dbo].[Producto] ([idProducto])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Producto]
GO
ALTER TABLE [dbo].[Inventario]  WITH CHECK ADD  CONSTRAINT [FK_Inventario_Sucursal] FOREIGN KEY([idSucursal])
REFERENCES [dbo].[Sucursal] ([idSucursal])
GO
ALTER TABLE [dbo].[Inventario] CHECK CONSTRAINT [FK_Inventario_Sucursal]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Empleado]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([idPedido])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Pedido]
GO
/****** Object:  StoredProcedure [dbo].[ClienteSelectAll]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para seleccionar todos los clientes
CREATE PROCEDURE [dbo].[ClienteSelectAll]
AS
BEGIN
    -- Selecciona todos los clientes
    SELECT 
        [idCliente],
        [nroDocumento],
        [nombre],
        [apellido],
        [direccion],
        [codPostal],
        [telefono],
        [mail],
        [barrio],
        [provincia],
        [fechaRegistro],
        [estado]
    FROM 
        [dbo].[Cliente];
END;
GO
/****** Object:  StoredProcedure [dbo].[ClienteSelectByApellido]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[ClienteSelectByApellido]
    @apellido NVARCHAR(20)
AS
BEGIN
    -- Selecciona los clientes cuyo número de documento coincide exactamente con el proporcionado
    SELECT 
		[idCliente],
        [nroDocumento],
        [nombre],
        [apellido],
        [direccion],
        [codPostal],
        [telefono],
        [mail],
        [barrio],
        [provincia],
        [fechaRegistro],
        [estado]
    FROM 
        [dbo].[Cliente]
    WHERE 
        [apellido] = @apellido;
END;

GO
/****** Object:  StoredProcedure [dbo].[ClienteSelectByDocumento]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para seleccionar cliente por documento
CREATE PROCEDURE [dbo].[ClienteSelectByDocumento]
    @nroDocumento NVARCHAR(20)
AS
BEGIN
    -- Selecciona los clientes cuyo número de documento coincide exactamente con el proporcionado
    SELECT 
		[idCliente],
        [nroDocumento],
        [nombre],
        [apellido],
        [direccion],
        [codPostal],
        [telefono],
        [mail],
        [barrio],
        [provincia],
        [fechaRegistro],
        [estado]
    FROM 
        [dbo].[Cliente]
    WHERE 
        [nroDocumento] = @nroDocumento;
END;
GO
/****** Object:  StoredProcedure [dbo].[ClienteSelectById]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Procedimiento para seleccionar cliente por ID
CREATE PROCEDURE [dbo].[ClienteSelectById]
    @idCliente INT
AS
BEGIN
    -- Selecciona el cliente basado en el IdCliente proporcionado
    SELECT 
        [idCliente],
        [nroDocumento],
        [nombre],
        [apellido],
        [direccion],
        [codPostal],
        [telefono],
        [mail],
        [barrio],
        [provincia],
        [fechaRegistro],
        [estado]
    FROM 
        [dbo].[Cliente]
    WHERE 
        [idCliente] = @idCliente;
END;
GO
/****** Object:  StoredProcedure [dbo].[ClienteSelectByNombre]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para seleccionar cliente por documento
create PROCEDURE [dbo].[ClienteSelectByNombre]
    @nombre NVARCHAR(20)
AS
BEGIN
    -- Selecciona los clientes cuyo número de documento coincide exactamente con el proporcionado
    SELECT 
		[idCliente],
        [nroDocumento],
        [nombre],
        [apellido],
        [direccion],
        [codPostal],
        [telefono],
        [mail],
        [barrio],
        [provincia],
        [fechaRegistro],
        [estado]
    FROM 
        [dbo].[Cliente]
    WHERE 
        [nombre] = @nombre;
END;

GO
/****** Object:  StoredProcedure [dbo].[EditarCliente]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarCliente]
    @idCliente int,
    @nroDocumento int,
    @nombre nvarchar(100),
    @apellido nvarchar(100),
    @direccion nvarchar(255),
    @codPostal int,
    @telefono nvarchar(20),
    @mail nvarchar(100),
    @barrio nvarchar(100),
    @provincia nvarchar(100),
    @fechaRegistro datetime,
    @estado int,
    @resultado int OUTPUT
AS
BEGIN
    -- Código del procedimiento almacenado...
    UPDATE Cliente
    SET nroDocumento = @nroDocumento,
        nombre = @nombre,
        apellido = @apellido,
        direccion = @direccion,
        codPostal = @codPostal,
        telefono = @telefono,
        mail = @mail,
        barrio = @barrio,
        provincia = @provincia,
        fechaRegistro = @fechaRegistro,
        estado = @estado
    WHERE idCliente = @idCliente;

    SET @resultado = 1; -- Devuelve 1 si la operación fue exitosa
END
GO
/****** Object:  StoredProcedure [dbo].[RegistrarCliente]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistrarCliente]
    @nroDocumento INT,
    @nombre NVARCHAR(50),
    @apellido NVARCHAR(50),
    @direccion NVARCHAR(100),
    @codPostal INT,
    @telefono NVARCHAR(20),
    @mail NVARCHAR(50),
    @barrio NVARCHAR(50),
    @provincia NVARCHAR(50),
    @fechaRegistro DATETIME,
    @estado INT,
    @idCliente INT OUTPUT
AS
BEGIN
    INSERT INTO Cliente (nroDocumento, nombre, apellido, direccion, codPostal, telefono, mail, barrio, provincia, fechaRegistro, estado)
    VALUES (@nroDocumento, @nombre, @apellido, @direccion, @codPostal, @telefono, @mail, @barrio, @provincia, GETDATE(), @estado);
    
    SET @idCliente = SCOPE_IDENTITY(); -- Obtener el ID generado
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEstadoPedido]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarEstadoPedido]
    @IdPedido UNIQUEIDENTIFIER,
    @NuevoEstado INT
AS
BEGIN
    -- Actualizamos el estado del pedido
    UPDATE Pedido
    SET estado = @NuevoEstado
    WHERE idPedido = @IdPedido;
    
    -- Opcional: Puedes agregar una validación de que el pedido exista
    IF @@ROWCOUNT = 0
    BEGIN
        PRINT 'No se encontró el pedido con el ID proporcionado';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarProductoInventario]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_AgregarProductoInventario]
    @idSucursal UNIQUEIDENTIFIER,
    @idProducto UNIQUEIDENTIFIER,
    @cantidad INT
AS
BEGIN
    -- Verifica si el producto ya está en el inventario de la sucursal
    IF EXISTS (
        SELECT 1 FROM [dbo].[Inventario]
        WHERE idSucursal = @idSucursal AND idProducto = @idProducto
    )
    BEGIN
        -- Si el producto ya está en el inventario, aumenta la cantidad
        UPDATE [dbo].[Inventario]
        SET cantidad = cantidad + @cantidad
        WHERE idSucursal = @idSucursal AND idProducto = @idProducto;
    END
    ELSE
    BEGIN
        -- Si el producto no está en el inventario, lo inserta con la cantidad dada
        INSERT INTO [dbo].[Inventario] (idInventario, idSucursal, idProducto, cantidad, reserva, estado)
        VALUES (NEWID(), @idSucursal, @idProducto, @cantidad, 0, 1);  -- Estado 1 podría indicar activo
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_CalcularDisponibilidadInventario]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_CalcularDisponibilidadInventario]
    @idSucursal UNIQUEIDENTIFIER,
    @idProducto UNIQUEIDENTIFIER,
    @disponibilidad INT OUTPUT
AS
BEGIN
    SELECT @disponibilidad = (cantidad - reserva)
    FROM Inventario
    WHERE idSucursal = @idSucursal AND idProducto = @idProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarEmpleado]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_EditarEmpleado]
    @IdEmpleado UNIQUEIDENTIFIER,
    @IdUsuario UNIQUEIDENTIFIER,
    @IdSucursal UNIQUEIDENTIFIER,
    @IdFamilia UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Mail NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @FechaRegistro DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Empleado
    SET 
        IdUsuario = @IdUsuario,
        IdSucursal = @IdSucursal,
        IdFamilia = @IdFamilia,
        Nombre = @Nombre,
        Apellido = @Apellido,
        Mail = @Mail,
        Telefono = @Telefono,
        FechaRegistro = @FechaRegistro
    WHERE IdEmpleado = @IdEmpleado;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarProducto]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_EditarProducto]
    @idProducto uniqueidentifier,
    @codProducto NVARCHAR(50),
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(255),
    @categoria NVARCHAR(50),
    @precioVenta DECIMAL(18, 2),
    @precioCompra DECIMAL(18, 2),
    @estado BIT
AS
BEGIN
    UPDATE Producto
    SET codProducto = @codProducto,
        nombre = @nombre,
        descripcion = @descripcion,
        categoria = @categoria,
        precioVenta = @precioVenta,
        precioCompra = @precioCompra,
        estado = @estado
    WHERE idProducto = @idProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarSucursal]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para editar una sucursal existente
create PROCEDURE [dbo].[sp_EditarSucursal]
    @idSucursal UNIQUEIDENTIFIER,
    @nombre NCHAR(75),
    @direccion NCHAR(100),
    @telefono nchar(15),
	@estado int
AS
BEGIN
    UPDATE [dbo].[Sucursal]
    SET nombre = @nombre,
        direccion = @direccion,
        telefono = @telefono,
		estado = @estado
    WHERE idSucursal = @idSucursal;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllEmpleados]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetAllEmpleados]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdEmpleado, idFamilia, Nombre, Apellido, Mail, Telefono, FechaRegistro, IdSucursal
    FROM Empleado;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllPedidos]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Creamos el Stored Procedure sp_GetAllPedidos
CREATE PROCEDURE [dbo].[sp_GetAllPedidos]
AS
BEGIN
    -- Selección de todos los pedidos
    SELECT 
        [idPedido],
        [idEmpleado],
        [idCliente],
        [total],
        [estado],
        [fechaRegistro]
    FROM [dbo].[Pedido]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProductos]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllProductos]
AS
BEGIN
    SELECT idProducto, codProducto, nombre, descripcion, categoria, precioVenta, precioCompra, estado
    FROM Producto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllSucursal]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetAllSucursal]
AS
select idSucursal,nombre,direccion,telefono,estado from Sucursal
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllVentas]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetAllVentas]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [idVenta],
        [idPedido],
        [valorFlete],
        [total],
        [estado],
        [fechaRegistro]
    FROM [dbo].[Venta];
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmpleadoById]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEmpleadoById]
    @IdEmpleado UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT IdEmpleado, idFamilia, Nombre, Apellido, Mail, Telefono, FechaRegistro, IdSucursal
    FROM Empleado
    WHERE IdEmpleado = @IdEmpleado;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmpleadoPorUsuario]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetEmpleadoPorUsuario]
    @idUsuario UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT idEmpleado,idUsuario,idSucursal,idFamilia,nombre, apellido,mail,telefono,fechaRegistro
    FROM Empleado
    WHERE Empleado.idUsuario = @idUsuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPedidoByGuid]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPedidoByGuid]
    @idPedido uniqueidentifier	
AS
BEGIN
    SET NOCOUNT ON;

SELECT [idPedido]
      ,[idEmpleado]
      ,[idCliente]
      ,[total]
      ,[estado]
      ,[fechaRegistro]
  FROM [dbo].[Pedido]
    WHERE [idPedido] = @idPedido;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductoByCodigo]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_GetProductoByCodigo]
@Codigo nvarchar(60)
as
begin
SELECT [idProducto]
      ,[codProducto]
      ,[nombre]
      ,[descripcion]
      ,[categoria]
      ,[precioVenta]
      ,[precioCompra]
      ,[estado]
  FROM [dbo].[Producto]
where codProducto = @Codigo
end

GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductoById]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetProductoById]
    @idProducto uniqueidentifier
AS
BEGIN
    SELECT idProducto, codProducto, nombre, descripcion, categoria, precioVenta, precioCompra, estado
    FROM Producto
    WHERE idProducto = @idProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductoByNombre]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[sp_GetProductoByNombre]
@Nombre nvarchar(60)
as
begin
SELECT [idProducto]
      ,[codProducto]
      ,[nombre]
      ,[descripcion]
      ,[categoria]
      ,[precioVenta]
      ,[precioCompra]
      ,[estado]
  FROM [dbo].[Producto]
where nombre = @Nombre
end
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSucursalById]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_GetSucursalById]
@idSucursal uniqueidentifier
as
begin
select idSucursal, nombre,direccion, telefono, estado 
from Sucursal
where idSucursal = @idSucursal
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetSucursalByNombre]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_GetSucursalByNombre]
@nombre nchar
as
begin
select idSucursal, nombre, direccion, telefono, estado
from Sucursal
where nombre = @nombre
end;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetVentaByGuid]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetVentaByGuid]
    @idVenta uniqueidentifier	
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        [idVenta],
        [idPedido],
        [valorFlete],
        [total],
        [estado],
        [fechaRegistro]
    FROM [dbo].[Venta]
    WHERE [idVenta] = @idVenta;
END;

GO
/****** Object:  StoredProcedure [dbo].[sp_InventarioSelectAll]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InventarioSelectAll]
as
select * from inventario
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDetallePedido]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ObtenerDetallePedido]
    @IdPedido UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        dp.idDetallePedido,
        dp.idProducto,
        dp.IdPedido,
        dp.cantidad,
        dp.subtotal,
        p.nombre AS NombreProducto,
        p.precioVenta AS PrecioProducto
    FROM DetallePedido dp
    INNER JOIN Producto p ON dp.idProducto = p.idProducto
    WHERE dp.IdPedido = @IdPedido;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarEmpleado]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegistrarEmpleado]
    @IdEmpleado UNIQUEIDENTIFIER OUTPUT,
	@IdUsuario UNIQUEIDENTIFIER,
	@IdSucursal UNIQUEIDENTIFIER,
    @IdFamilia UNIQUEIDENTIFIER,
    @Nombre NVARCHAR(50),
    @Apellido NVARCHAR(50),
    @Mail NVARCHAR(100),
    @Telefono NVARCHAR(20),
    @FechaRegistro DATETIME

AS
BEGIN
    SET NOCOUNT ON;

    -- Generar nuevo GUID para el IdEmpleado
    SET @IdEmpleado = NEWID();

    INSERT INTO Empleado (IdEmpleado, idUsuario, IdSucursal, IdFamilia, Nombre, Apellido, Mail, Telefono, FechaRegistro)
    VALUES (@IdEmpleado, @IdUsuario ,@IdSucursal, @IdFamilia, @Nombre, @Apellido, @Mail, @Telefono, @FechaRegistro);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarPedido]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegistrarPedido]
    @IdPedido UNIQUEIDENTIFIER OUTPUT,
    @IdEmpleado UNIQUEIDENTIFIER,
    @IdCliente INT,
    @Total DECIMAL(18, 2),
    @Estado INT,
    @FechaRegistro DATETIME,
    @DetallePedidoDetalle [dbo].[DetallePedidoType] READONLY -- Tipo de tabla para los detalles
AS
BEGIN
    SET NOCOUNT ON;

    -- Iniciar una transacción para garantizar la integridad
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Asignar un nuevo GUID a @IdPedido
        SET @IdPedido = NEWID(); -- Generar un nuevo GUID

        -- Insertar el pedido en la tabla Pedido
        INSERT INTO [dbo].[Pedido] ([idPedido], [idEmpleado], [idCliente], [total], [estado], [fechaRegistro])
        VALUES (@IdPedido, @IdEmpleado, @IdCliente, @Total, @Estado, @FechaRegistro);

        -- Insertar los detalles del pedido utilizando el tipo de tabla
        INSERT INTO [dbo].[DetallePedido] ([idDetallePedido], [idProducto], [IdPedido], [cantidad], [subtotal])
        SELECT [idDetallePedido], [idProducto], @IdPedido, [cantidad], [subtotal]
        FROM @DetallePedidoDetalle;

        -- Confirmar la transacción
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- En caso de error, hacer rollback
        ROLLBACK TRANSACTION;
        THROW; -- Rethrow the error
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProducto]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_RegistrarProducto]
    @codProducto NVARCHAR(50),
    @nombre NVARCHAR(100),
    @descripcion NVARCHAR(255),
    @categoria NVARCHAR(50),
    @precioVenta DECIMAL(18, 2),
    @precioCompra DECIMAL(18, 2),
    @estado BIT,
    @idProducto UNIQUEIDENTIFIER OUTPUT  -- Agregar parámetro de salida
AS
BEGIN
    SET @idProducto = NEWID();  -- Generar un nuevo GUID para idProducto

    INSERT INTO Producto (idProducto, codProducto, nombre, descripcion, categoria, precioVenta, precioCompra, estado)
    VALUES (@idProducto, @codProducto, @nombre, @descripcion, @categoria, @precioVenta, @precioCompra, @estado);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarSucursal]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Procedimiento para registrar una nueva sucursal
CREATE PROCEDURE [dbo].[sp_RegistrarSucursal]
    @idSucursal UNIQUEIDENTIFIER,
    @nombre NCHAR(75),
    @direccion NCHAR(100),
	@telefono nchar(15),
	@estado int
AS
BEGIN
    INSERT INTO [dbo].[Sucursal] (idSucursal, nombre, direccion,telefono,estado)
    VALUES (@idSucursal, @nombre, @direccion, @telefono ,0);
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarVenta]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegistrarVenta]
    @idVenta UNIQUEIDENTIFIER,
    @idPedido UNIQUEIDENTIFIER,
    @valorFlete DECIMAL(18, 2),
    @total DECIMAL(18, 2),
    @estado INT,
    @fechaRegistro DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar una nueva venta en la tabla Venta
    INSERT INTO Venta (idVenta, idPedido, valorFlete, total, estado, fechaRegistro)
    VALUES (@idVenta, @idPedido, @valorFlete, @total, @estado, @fechaRegistro);
    
    -- Devolver el ID de la venta registrada (opcional, en caso de necesitar confirmación)
    SELECT @idVenta AS IdVentaRegistrada;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ReporteVenta]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ReporteVenta]
(
    @fechainicio DATE,
    @fechafin DATE
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        v.FechaRegistro AS FechaVenta,
        v.IdPedido AS IdPedido,
        p.IdCliente AS IdCliente,
        c.Nombre + ' ' + c.Apellido AS NombreCliente,
        v.Total AS ValorTotalVenta,
        dp.IdProducto AS IdProducto,
        prod.codProducto AS CodigoProducto,
        prod.nombre AS NombreProducto,
        prod.categoria AS CategoriaProducto,
        prod.precioVenta AS PrecioProducto,
        dp.Cantidad AS CantidadProducto,
        dp.Subtotal AS SubtotalProducto
    FROM Venta v
    INNER JOIN Pedido p ON v.IdPedido = p.IdPedido
    INNER JOIN Cliente c ON p.IdCliente = c.IdCliente
    INNER JOIN DetallePedido dp ON p.IdPedido = dp.IdPedido
    INNER JOIN Producto prod ON dp.IdProducto = prod.idProducto
    WHERE v.FechaRegistro BETWEEN @fechainicio AND @fechafin
    ORDER BY v.FechaRegistro;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ReservarProductoInventario]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ReservarProductoInventario]
    @idSucursal UNIQUEIDENTIFIER,
    @idProducto UNIQUEIDENTIFIER,
    @cantidadReserva INT,
    @resultado INT OUTPUT
AS
BEGIN
    -- Verifica que haya suficiente cantidad disponible para reservar
    DECLARE @disponible INT;
    SELECT @disponible = (cantidad - reserva)
    FROM Inventario
    WHERE idSucursal = @idSucursal AND idProducto = @idProducto;

    IF @disponible >= @cantidadReserva
    BEGIN
        -- Actualiza la reserva en el inventario
        UPDATE Inventario
        SET reserva = reserva + @cantidadReserva
        WHERE idSucursal = @idSucursal AND idProducto = @idProducto;

        SET @resultado = 1; -- Reserva exitosa
    END
    ELSE
    BEGIN
        SET @resultado = 0; -- No hay suficiente disponibilidad
    END
END;


GO
/****** Object:  StoredProcedure [dbo].[sp_SuspenderPedido]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SuspenderPedido]
    @IdPedido UNIQUEIDENTIFIER
AS
BEGIN
    -- Actualizamos el estado del pedido a "Suspendido" (o el valor que corresponda en tu enumeración)
    UPDATE Pedido
    SET estado = 0 -- Asumiendo que 0 es el valor de "Suspendido"
    WHERE idPedido = @IdPedido;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SuspenderProducto]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_SuspenderProducto]
    @codProducto NVARCHAR(50)
AS
BEGIN
    UPDATE Producto
    SET estado = 0
    WHERE codProducto = @codProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_SuspenderSucursal]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_SuspenderSucursal]
    @idSucursal UNIQUEIDENTIFIER
AS
BEGIN
    UPDATE [dbo].[Sucursal]
    SET estado = 0
    WHERE idSucursal = @idSucursal;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_SuspenderVenta]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_SuspenderVenta]
@idVenta UNIQUEIDENTIFIER
as
begin
	update Venta
	set estado = 0
	where idVenta = @idVenta;
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_VentaAsociadoAPedido]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_VentaAsociadoAPedido]
    @IdPedido UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- Verificar si existe una venta asociada al pedido
    IF EXISTS (SELECT 1 FROM dbo.Venta WHERE idPedido = @IdPedido)
    BEGIN
        -- Retornar 1 si existe una venta asociada
        SELECT 1 AS VentaAsociada;
    END
    ELSE
    BEGIN
        -- Retornar 0 si no existe una venta asociada
        SELECT 0 AS VentaAsociada;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_VerificarProductoEnInventario]    Script Date: 18/2/2025 19:11:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Creación del procedimiento para verificar la existencia y cantidad de un producto en el inventario de una sucursal
CREATE PROCEDURE [dbo].[sp_VerificarProductoEnInventario]
    @idSucursal UNIQUEIDENTIFIER,
    @idProducto UNIQUEIDENTIFIER,
    @existe BIT OUTPUT,       -- Parámetro de salida para indicar si el producto existe o no
    @cantidad INT OUTPUT      -- Parámetro de salida para la cantidad en inventario
AS
BEGIN
    SET NOCOUNT ON;

    -- Inicializar la cantidad a 0
    SET @cantidad = 0;

    -- Verificar si existe el producto en el inventario de la sucursal especificada
    IF EXISTS (
        SELECT 1 
        FROM [dbo].[Inventario]
        WHERE idSucursal = @idSucursal AND idProducto = @idProducto
    )
    BEGIN
        SET @existe = 1; 
        SELECT @cantidad = cantidad 
        FROM [dbo].[Inventario]
        WHERE idSucursal = @idSucursal AND idProducto = @idProducto;
    END
    ELSE
    BEGIN
        SET @existe = 0; 
    END
END;
GO
USE [master]
GO
ALTER DATABASE [OneVisionBD] SET  READ_WRITE 
GO
