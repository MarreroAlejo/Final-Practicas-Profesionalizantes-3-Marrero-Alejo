USE [OneVisionBD]
GO
/****** Object:  UserDefinedTableType [dbo].[DetallePedido]    Script Date: 25/4/2025 15:15:41 ******/
CREATE TYPE [dbo].[DetallePedido] AS TABLE(
	[idProducto] [uniqueidentifier] NULL,
	[cantidad] [int] NULL,
	[subtotal] [decimal](18, 2) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[DetallePedidoType]    Script Date: 25/4/2025 15:15:41 ******/
CREATE TYPE [dbo].[DetallePedidoType] AS TABLE(
	[idDetallePedido] [uniqueidentifier] NULL,
	[idProducto] [uniqueidentifier] NULL,
	[cantidad] [int] NULL,
	[subtotal] [decimal](18, 2) NULL
)
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 25/4/2025 15:15:41 ******/
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
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 25/4/2025 15:15:41 ******/
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
/****** Object:  Table [dbo].[Empleado]    Script Date: 25/4/2025 15:15:41 ******/
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
/****** Object:  Table [dbo].[Inventario]    Script Date: 25/4/2025 15:15:41 ******/
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
/****** Object:  Table [dbo].[Pedido]    Script Date: 25/4/2025 15:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[idPedido] [uniqueidentifier] NOT NULL,
	[nroPedido] [int] IDENTITY(1,1) NOT NULL,
	[idEmpleado] [uniqueidentifier] NULL,
	[idCliente] [int] NULL,
	[idSucursal] [uniqueidentifier] NULL,
	[total] [decimal](18, 2) NULL,
	[estado] [int] NULL,
	[fechaRegistro] [datetime] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[idPedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 25/4/2025 15:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[idProducto] [uniqueidentifier] NOT NULL,
	[codProducto] [nvarchar](50) NULL,
	[nombre] [nvarchar](50) NULL,
	[descripcion] [nvarchar](60) NULL,
	[categoria] [nvarchar](60) NULL,
	[precioVenta] [decimal](18, 2) NULL,
	[precioCompra] [decimal](18, 2) NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[idProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sucursal]    Script Date: 25/4/2025 15:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sucursal](
	[idSucursal] [uniqueidentifier] NOT NULL,
	[nombre] [nvarchar](75) NULL,
	[direccion] [nvarchar](100) NULL,
	[telefono] [nvarchar](50) NULL,
	[estado] [int] NULL,
 CONSTRAINT [PK_Sucursal] PRIMARY KEY CLUSTERED 
(
	[idSucursal] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 25/4/2025 15:15:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[idVenta] [uniqueidentifier] NOT NULL,
	[nroVenta] [int] IDENTITY(1,1) NOT NULL,
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

INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (2, 44421000, N'Alejo', N'Marrero', N'Gral. Justo José de Urquiza 1942', 1602, N'01161447979', N'amarrero@agpruden.com', N'Vicente Lopéz', N'Buenos Aires', CAST(N'2025-03-27T20:57:38.227' AS DateTime), 1)
INSERT [dbo].[Cliente] ([idCliente], [nroDocumento], [nombre], [apellido], [direccion], [codPostal], [telefono], [mail], [barrio], [provincia], [fechaRegistro], [estado]) VALUES (3, 21532943, N'Alejandro Manuel', N'Marrero', N'Gral. Justo José de Urquiza 1942', 1602, N'01189320339', N'amarrero@mymlogistic.com', N'Vicente Lopez', N'Buenos Aires', CAST(N'2025-04-23T18:19:04.167' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
INSERT [dbo].[DetallePedido] ([idDetallePedido], [idProducto], [IdPedido], [cantidad], [subtotal]) VALUES (N'7e5f4201-26cf-46d6-a33a-2803d8f01cc3', N'b2ac7669-9677-4809-b9a1-06b2ddf2e1e8', N'114212c7-2ffa-4a9d-9024-4f49276e7f3a', 2, CAST(36000.00 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([idDetallePedido], [idProducto], [IdPedido], [cantidad], [subtotal]) VALUES (N'ed13706d-1f89-4b11-8e1a-f6714c223de9', N'4bbde450-bcdf-47fe-85ac-ce4ef95e5f00', N'5fab32e0-30b7-443b-8d62-0989c5ded264', 1, CAST(15000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[Empleado] ([idEmpleado], [idUsuario], [idSucursal], [idFamilia], [nombre], [apellido], [mail], [telefono], [fechaRegistro]) VALUES (N'e5cc1370-0a27-449e-a280-4dcd232bfd0a', N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'cdb5cf54-8886-49a0-8899-58836077b083', N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'Alejo                                                       ', N'Marrero                                                                                             ', N'amarrero@agpruden.com                                       ', N'01161447979', CAST(N'2025-01-09T20:40:52.000' AS DateTime))
INSERT [dbo].[Empleado] ([idEmpleado], [idUsuario], [idSucursal], [idFamilia], [nombre], [apellido], [mail], [telefono], [fechaRegistro]) VALUES (N'7f6b6983-2e77-43e6-90d7-d4dc3186b146', N'df5524fb-4a17-4be9-a4fd-32f398f93c71', N'e91f05bf-5a96-41a8-aec2-b6d61fe2d587', N'0c3a69e1-71ff-4ac7-83f0-67e206c8a5e3', N'kiki                                                        ', N'kiki                                                                                                ', N'kiki                                                        ', N'765456     ', CAST(N'2025-03-30T20:54:11.417' AS DateTime))
GO
INSERT [dbo].[Inventario] ([idInventario], [idProducto], [idSucursal], [cantidad], [reserva], [estado]) VALUES (N'8dd66ff5-32bd-41fc-b244-1d6f84cce98d', N'4bbde450-bcdf-47fe-85ac-ce4ef95e5f00', N'e91f05bf-5a96-41a8-aec2-b6d61fe2d587', 10, -1, 1)
INSERT [dbo].[Inventario] ([idInventario], [idProducto], [idSucursal], [cantidad], [reserva], [estado]) VALUES (N'2ad25fee-9029-4295-8903-751e14c830bd', N'b2ac7669-9677-4809-b9a1-06b2ddf2e1e8', N'e91f05bf-5a96-41a8-aec2-b6d61fe2d587', 9, 0, 1)
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([idPedido], [nroPedido], [idEmpleado], [idCliente], [idSucursal], [total], [estado], [fechaRegistro]) VALUES (N'5fab32e0-30b7-443b-8d62-0989c5ded264', 2, N'e5cc1370-0a27-449e-a280-4dcd232bfd0a', 3, N'e91f05bf-5a96-41a8-aec2-b6d61fe2d587', CAST(15000.00 AS Decimal(18, 2)), 1, CAST(N'2025-04-23T18:45:38.243' AS DateTime))
INSERT [dbo].[Pedido] ([idPedido], [nroPedido], [idEmpleado], [idCliente], [idSucursal], [total], [estado], [fechaRegistro]) VALUES (N'114212c7-2ffa-4a9d-9024-4f49276e7f3a', 1, N'e5cc1370-0a27-449e-a280-4dcd232bfd0a', 2, N'e91f05bf-5a96-41a8-aec2-b6d61fe2d587', CAST(36000.00 AS Decimal(18, 2)), 3, CAST(N'2025-03-30T20:48:46.440' AS DateTime))
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
INSERT [dbo].[Producto] ([idProducto], [codProducto], [nombre], [descripcion], [categoria], [precioVenta], [precioCompra], [estado]) VALUES (N'b2ac7669-9677-4809-b9a1-06b2ddf2e1e8', N'COD-001', N'Gorra Puma', N'Gorra de color negro con estampa de Puma', N'Accesorios', CAST(19000.00 AS Decimal(18, 2)), CAST(13000.00 AS Decimal(18, 2)), 1)
INSERT [dbo].[Producto] ([idProducto], [codProducto], [nombre], [descripcion], [categoria], [precioVenta], [precioCompra], [estado]) VALUES (N'4bbde450-bcdf-47fe-85ac-ce4ef95e5f00', N'COD-002', N'Gorra Pepo', N'Gorra de color negro con estampa de Halcon', N'Accesorios', CAST(15000.00 AS Decimal(18, 2)), CAST(10000.00 AS Decimal(18, 2)), 1)
GO
INSERT [dbo].[Sucursal] ([idSucursal], [nombre], [direccion], [telefono], [estado]) VALUES (N'cdb5cf54-8886-49a0-8899-58836077b083', N'Sin asignar', N'nula', N'011', 1)
INSERT [dbo].[Sucursal] ([idSucursal], [nombre], [direccion], [telefono], [estado]) VALUES (N'e91f05bf-5a96-41a8-aec2-b6d61fe2d587', N'Boulogne', N'Jose Hernandez 1924', N'0117834924', 1)
GO
SET IDENTITY_INSERT [dbo].[Venta] ON 

INSERT [dbo].[Venta] ([idVenta], [nroVenta], [idPedido], [valorFlete], [total], [estado], [fechaRegistro]) VALUES (N'6aff1ba2-75d3-454a-a8e7-70247b0e103d', 1, N'114212c7-2ffa-4a9d-9024-4f49276e7f3a', CAST(0.00 AS Decimal(18, 2)), CAST(36000.00 AS Decimal(18, 2)), 1, CAST(N'2025-03-30T20:49:40.483' AS DateTime))
SET IDENTITY_INSERT [dbo].[Venta] OFF
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
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente1] FOREIGN KEY([idCliente])
REFERENCES [dbo].[Cliente] ([idCliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente1]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Empleado] FOREIGN KEY([idEmpleado])
REFERENCES [dbo].[Empleado] ([idEmpleado])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Empleado]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Sucursal] FOREIGN KEY([idSucursal])
REFERENCES [dbo].[Sucursal] ([idSucursal])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Sucursal]
GO
ALTER TABLE [dbo].[Venta]  WITH CHECK ADD  CONSTRAINT [FK_Venta_Pedido] FOREIGN KEY([idPedido])
REFERENCES [dbo].[Pedido] ([idPedido])
GO
ALTER TABLE [dbo].[Venta] CHECK CONSTRAINT [FK_Venta_Pedido]
GO
/****** Object:  StoredProcedure [dbo].[ClienteSelectAll]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[ClienteSelectByApellido]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[ClienteSelectByDocumento]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[ClienteSelectById]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[ClienteSelectByNombre]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[EditarCliente]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[RegistrarCliente]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ActualizarEstadoPedido]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ActualizarEstadoPedido]
    @NroPedido int,
    @NuevoEstado INT
AS
BEGIN
    -- Actualizamos el estado del pedido
    UPDATE Pedido
    SET estado = @NuevoEstado
    WHERE nroPedido = @NroPedido;
    
    -- Opcional: Puedes agregar una validación de que el pedido exista
    IF @@ROWCOUNT = 0
    BEGIN
        PRINT 'No se encontró el pedido con el ID proporcionado';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarInventarioPedido]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarInventarioPedido]
    @idPedido UNIQUEIDENTIFIER,
    @idSucursal UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE i
    SET i.reserva = i.reserva - dp.cantidad
    FROM Inventario i
    INNER JOIN DetallePedido dp ON i.idProducto = dp.idProducto
    WHERE dp.IdPedido = @idPedido
      AND i.idSucursal = @idSucursal;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ActualizarStockVenta]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_ActualizarStockVenta]
    @idPedido UNIQUEIDENTIFIER,
    @idSucursal UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    -- Actualizar inventario y reserva
    UPDATE i
    SET 
        i.cantidad = i.cantidad - dp.cantidad,
        i.reserva = CASE 
                        WHEN (i.reserva - dp.cantidad) < 0 THEN 0 
                        ELSE (i.reserva - dp.cantidad) 
                    END
    FROM Inventario i
    INNER JOIN DetallePedido dp ON i.idProducto = dp.idProducto
    WHERE dp.IdPedido = @idPedido
      AND i.idSucursal = @idSucursal;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_AgregarProductoInventario]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_CalcularDisponibilidadInventario]    Script Date: 25/4/2025 15:15:42 ******/
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
    SELECT @disponibilidad = (cantidad + reserva)
    FROM Inventario
    WHERE idSucursal = @idSucursal AND idProducto = @idProducto;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_EditarEmpleado]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EditarProducto]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_EditarSucursal]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetAllEmpleados]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetAllPedidos]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Creamos el Stored Procedure sp_GetAllPedidos
CREATE PROCEDURE [dbo].[sp_GetAllPedidos]
AS
BEGIN
    -- Selección de todos los pedidos
SELECT [idPedido]
      ,[nroPedido]
      ,[idEmpleado]
      ,[idCliente]
      ,[idSucursal]
      ,[total]
      ,[estado]
      ,[fechaRegistro]
  FROM [dbo].[Pedido]
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllProductos]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetAllSucursal]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetAllSucursal]
AS
select idSucursal,nombre,direccion,telefono,estado from Sucursal
GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllVentas]    Script Date: 25/4/2025 15:15:42 ******/
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
		      [nroVenta],
        [idPedido],
        [valorFlete],
        [total],
        [estado],
        [fechaRegistro]
    FROM [dbo].[Venta];
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_GetEmpleadoById]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetEmpleadoPorUsuario]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetPedidoByGuid]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetPedidoByGuid]
    @idPedido UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        idPedido,
        nroPedido, -- Asegúrate de incluir esta columna
        idEmpleado,
        idCliente,
        idSucursal,
        total,
        estado,
        fechaRegistro
    FROM Pedido
    WHERE idPedido = @idPedido;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_GetPedidoByNro]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_GetPedidoByNro]
    @nroPedido int	
AS
BEGIN
    SET NOCOUNT ON;

SELECT [idPedido]
      ,[nroPedido]
      ,[idEmpleado]
      ,[idCliente]
      ,[idSucursal]
      ,[total]
      ,[estado]
      ,[fechaRegistro]

  FROM [dbo].[Pedido]
    WHERE [nroPedido] = @nroPedido;
END;


GO
/****** Object:  StoredProcedure [dbo].[sp_GetProductoByCodigo]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetProductoById]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetProductoByNombre]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetSucursalById]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetSucursalByNombre]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_GetVentaByGuid]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_GetVentaByGuid]
    @idVenta uniqueidentifier	
AS
BEGIN
    SET NOCOUNT ON;

SELECT [idVenta]
      ,[nroVenta]
      ,[idPedido]
      ,[valorFlete]
      ,[total]
      ,[estado]
      ,[fechaRegistro]
  FROM [dbo].[Venta]
    WHERE [idVenta] = @idVenta;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_InventarioSelectAll]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[sp_InventarioSelectAll]
as
select * from inventario
GO
/****** Object:  StoredProcedure [dbo].[sp_ObtenerDetallePedido]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RegistrarEmpleado]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RegistrarPedido]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_RegistrarPedido]
    @IdPedido UNIQUEIDENTIFIER OUTPUT,
    @NroPedido INT OUTPUT,
    @IdEmpleado UNIQUEIDENTIFIER,
    @IdCliente INT,
    @IdSucursal UNIQUEIDENTIFIER,  -- Nuevo parámetro para la sucursal
    @Total DECIMAL(18, 2),
    @Estado INT,
    @FechaRegistro DATETIME,
    @DetallePedidoDetalle [dbo].[DetallePedidoType] READONLY
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Generar un nuevo GUID para el pedido
        SET @IdPedido = NEWID();

        -- Insertar el pedido sin incluir la columna nroPedido (ya que es identity)
        INSERT INTO [dbo].[Pedido] 
            ([idPedido], [idEmpleado], [idCliente], [idSucursal], [total], [estado], [fechaRegistro])
        VALUES 
            (@IdPedido, @IdEmpleado, @IdCliente, @IdSucursal, @Total, @Estado, @FechaRegistro);

        -- Capturar el valor generado para nroPedido
        SET @NroPedido = CAST(SCOPE_IDENTITY() AS INT);

        -- Insertar los detalles del pedido utilizando el tipo de tabla
        INSERT INTO [dbo].[DetallePedido] 
            ([idDetallePedido], [idProducto], [IdPedido], [cantidad], [subtotal])
        SELECT [idDetallePedido], [idProducto], @IdPedido, [cantidad], [subtotal]
        FROM @DetallePedidoDetalle;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW; -- Relanza el error para que la aplicación lo capture
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_RegistrarProducto]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RegistrarSucursal]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_RegistrarVenta]    Script Date: 25/4/2025 15:15:42 ******/
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
    @fechaRegistro DATETIME,
    @nroVenta INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Insertar una nueva venta sin incluir nroVenta, ya que es identity
    INSERT INTO Venta (idVenta, idPedido, valorFlete, total, estado, fechaRegistro)
    VALUES (@idVenta, @idPedido, @valorFlete, @total, @estado, @fechaRegistro);
    
    -- Capturar el valor generado para nroVenta
    SET @nroVenta = CAST(SCOPE_IDENTITY() AS INT);
    
    -- Devolver el ID de la venta registrada y el nroVenta generado (opcional)
    SELECT @idVenta AS IdVentaRegistrada, @nroVenta AS NroVentaRegistrado;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_ReportePedido]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_ReportePedido]
(
    @fechainicio DATE,
    @fechafin DATE
)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        v.FechaRegistro AS FechaPedido,
        v.IdPedido AS IdPedido,
        p.IdCliente AS IdCliente,
        c.Nombre + ' ' + c.Apellido AS NombreCliente,
        v.Total AS ValorTotalPedido,
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
/****** Object:  StoredProcedure [dbo].[sp_ReporteVenta]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_ReservarProductoInventario]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_SuspenderPedido]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SuspenderPedido]
    @NroPedido INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Actualizar el estado del pedido a "Suspendido" (0)
        UPDATE Pedido
        SET estado = 0
        WHERE nroPedido = @NroPedido;

        -- Declarar variables necesarias
        DECLARE @IdProducto UNIQUEIDENTIFIER;
        DECLARE @Cantidad INT;
        DECLARE @IdSucursal UNIQUEIDENTIFIER;
        DECLARE @IdPedido UNIQUEIDENTIFIER;
        DECLARE @VentaAsociada BIT;

        -- Obtener el IdPedido y la sucursal del pedido
        SELECT @IdPedido = idPedido, @IdSucursal = idSucursal
        FROM Pedido
        WHERE nroPedido = @NroPedido;

        -- Verificar si hay venta asociada al pedido usando el parámetro OUTPUT
        EXEC [dbo].[sp_VentaAsociadoAPedido] @IdPedido = @IdPedido, @VentaAsociada = @VentaAsociada OUTPUT;

        -- Cursor para recorrer los productos del pedido
        DECLARE producto_cursor CURSOR FOR
        SELECT idProducto, cantidad
        FROM DetallePedido
        WHERE IdPedido = @IdPedido;

        OPEN producto_cursor;
        FETCH NEXT FROM producto_cursor INTO @IdProducto, @Cantidad;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            IF @VentaAsociada = 1
            BEGIN
                -- Si tiene venta asociada, sumamos la cantidad al stock (columna 'cantidad')
                UPDATE Inventario
                SET cantidad = cantidad + @Cantidad
                WHERE idProducto = @IdProducto AND idSucursal = @IdSucursal;
            END
            ELSE
            BEGIN
                -- Si no tiene venta asociada, sumamos la cantidad a la reserva (columna 'reserva')
                UPDATE Inventario
                SET reserva = reserva + @Cantidad
                WHERE idProducto = @IdProducto AND idSucursal = @IdSucursal;
            END

            FETCH NEXT FROM producto_cursor INTO @IdProducto, @Cantidad;
        END;

        CLOSE producto_cursor;
        DEALLOCATE producto_cursor;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_SuspenderProducto]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_SuspenderSucursal]    Script Date: 25/4/2025 15:15:42 ******/
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
/****** Object:  StoredProcedure [dbo].[sp_SuspenderVenta]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SuspenderVenta]
    @idVenta UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE Venta
    SET estado = 0 -- Suponiendo que 0 es el estado "Suspendido"
    WHERE idVenta = @idVenta;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_VentaAsociadoAPedido]    Script Date: 25/4/2025 15:15:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_VentaAsociadoAPedido]
    @IdPedido UNIQUEIDENTIFIER,
    @VentaAsociada BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM dbo.Venta WHERE idPedido = @IdPedido)
    BEGIN
        SET @VentaAsociada = 1;
    END
    ELSE
    BEGIN
        SET @VentaAsociada = 0;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_VerificarProductoEnInventario]    Script Date: 25/4/2025 15:15:42 ******/
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
