
/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClienteInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ClienteInsert]
GO

CREATE PROCEDURE [dbo].[ClienteInsert] (
	@IdCliente uniqueidentifier,
	@Nombre nchar(30),
	@Apellido nchar(30),
	@Direccion nchar(30),
	@CodPostal nchar(6),
	@Telefono nchar(15),
	@Mail nchar(50),
	@NroDocumento nchar(20),
	@CantCompras int,
	@Barrio nchar(30),
	@Provincia nchar(30),
	@TelefonoAuxiliar nchar(15),
	@FechaRegistro datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Cliente] (
	[IdCliente],
	[Nombre],
	[Apellido],
	[Direccion],
	[CodPostal],
	[Telefono],
	[Mail],
	[NroDocumento],
	[CantCompras],
	[Barrio],
	[Provincia],
	[TelefonoAuxiliar],
	[FechaRegistro]
) VALUES (
	@IdCliente,
	@Nombre,
	@Apellido,
	@Direccion,
	@CodPostal,
	@Telefono,
	@Mail,
	@NroDocumento,
	@CantCompras,
	@Barrio,
	@Provincia,
	@TelefonoAuxiliar,
	@FechaRegistro
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClienteUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ClienteUpdate]
GO

CREATE PROCEDURE [dbo].[ClienteUpdate] (
	@IdCliente uniqueidentifier,
	@Nombre nchar(30),
	@Apellido nchar(30),
	@Direccion nchar(30),
	@CodPostal nchar(6),
	@Telefono nchar(15),
	@Mail nchar(50),
	@NroDocumento nchar(20),
	@CantCompras int,
	@Barrio nchar(30),
	@Provincia nchar(30),
	@TelefonoAuxiliar nchar(15),
	@FechaRegistro datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Cliente]
SET
	[Nombre] = @Nombre,
	[Apellido] = @Apellido,
	[Direccion] = @Direccion,
	[CodPostal] = @CodPostal,
	[Telefono] = @Telefono,
	[Mail] = @Mail,
	[NroDocumento] = @NroDocumento,
	[CantCompras] = @CantCompras,
	[Barrio] = @Barrio,
	[Provincia] = @Provincia,
	[TelefonoAuxiliar] = @TelefonoAuxiliar,
	[FechaRegistro] = @FechaRegistro
WHERE
	 [IdCliente] = @IdCliente

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClienteDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ClienteDelete]
GO

CREATE PROCEDURE [dbo].[ClienteDelete] (
	@IdCliente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Cliente]
WHERE
	[IdCliente] = @IdCliente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClienteSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ClienteSelect]
GO

CREATE PROCEDURE [dbo].[ClienteSelect] (
	@IdCliente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdCliente],
	[Nombre],
	[Apellido],
	[Direccion],
	[CodPostal],
	[Telefono],
	[Mail],
	[NroDocumento],
	[CantCompras],
	[Barrio],
	[Provincia],
	[TelefonoAuxiliar],
	[FechaRegistro]
FROM
	[Cliente]
WHERE
	[IdCliente] = @IdCliente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ClienteSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ClienteSelectAll]
GO

CREATE PROCEDURE [dbo].[ClienteSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdCliente],
	[Nombre],
	[Apellido],
	[Direccion],
	[CodPostal],
	[Telefono],
	[Mail],
	[NroDocumento],
	[CantCompras],
	[Barrio],
	[Provincia],
	[TelefonoAuxiliar],
	[FechaRegistro]
FROM
	[Cliente]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Detalle_VentaInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Detalle_VentaInsert]
GO

CREATE PROCEDURE [dbo].[Detalle_VentaInsert] (
	@IdDetalleVenta int,
	@IdProducto int,
	@Cantidad int,
	@SubTotal decimal(18, 2)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Detalle_Venta] (
	[IdDetalleVenta],
	[IdProducto],
	[Cantidad],
	[SubTotal]
) VALUES (
	@IdDetalleVenta,
	@IdProducto,
	@Cantidad,
	@SubTotal
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Detalle_VentaUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Detalle_VentaUpdate]
GO

CREATE PROCEDURE [dbo].[Detalle_VentaUpdate] (
	@IdDetalleVenta int,
	@IdProducto int,
	@Cantidad int,
	@SubTotal decimal(18, 2)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Detalle_Venta]
SET
	[IdProducto] = @IdProducto,
	[Cantidad] = @Cantidad,
	[SubTotal] = @SubTotal
WHERE
	 [IdDetalleVenta] = @IdDetalleVenta

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Detalle_VentaDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Detalle_VentaDelete]
GO

CREATE PROCEDURE [dbo].[Detalle_VentaDelete] (
	@IdDetalleVenta int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Detalle_Venta]
WHERE
	[IdDetalleVenta] = @IdDetalleVenta


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Detalle_VentaDeleteByIdProducto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Detalle_VentaDeleteByIdProducto]
GO

CREATE PROCEDURE [dbo].[Detalle_VentaDeleteByIdProducto] (
	@IdProducto int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Detalle_Venta]
WHERE
	[IdProducto] = @IdProducto


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Detalle_VentaSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Detalle_VentaSelect]
GO

CREATE PROCEDURE [dbo].[Detalle_VentaSelect] (
	@IdDetalleVenta int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdDetalleVenta],
	[IdProducto],
	[Cantidad],
	[SubTotal]
FROM
	[Detalle_Venta]
WHERE
	[IdDetalleVenta] = @IdDetalleVenta


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Detalle_VentaSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Detalle_VentaSelectAll]
GO

CREATE PROCEDURE [dbo].[Detalle_VentaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdDetalleVenta],
	[IdProducto],
	[Cantidad],
	[SubTotal]
FROM
	[Detalle_Venta]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Detalle_VentaSelectByIdProducto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Detalle_VentaSelectByIdProducto]
GO

CREATE PROCEDURE [dbo].[Detalle_VentaSelectByIdProducto] (
	@IdProducto int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdDetalleVenta],
	[IdProducto],
	[Cantidad],
	[SubTotal]
FROM
	[Detalle_Venta]
WHERE
	[IdProducto] = @IdProducto


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InventarioInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InventarioInsert]
GO

CREATE PROCEDURE [dbo].[InventarioInsert] (
	@IdInventario int,
	@IdProducto int,
	@Total decimal(18, 2)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Inventario] (
	[IdInventario],
	[IdProducto],
	[Total]
) VALUES (
	@IdInventario,
	@IdProducto,
	@Total
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InventarioUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InventarioUpdate]
GO

CREATE PROCEDURE [dbo].[InventarioUpdate] (
	@IdInventario int,
	@IdProducto int,
	@Total decimal(18, 2)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Inventario]
SET
	[IdProducto] = @IdProducto,
	[Total] = @Total
WHERE
	 [IdInventario] = @IdInventario

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InventarioDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InventarioDelete]
GO

CREATE PROCEDURE [dbo].[InventarioDelete] (
	@IdInventario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Inventario]
WHERE
	[IdInventario] = @IdInventario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InventarioDeleteByIdProducto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InventarioDeleteByIdProducto]
GO

CREATE PROCEDURE [dbo].[InventarioDeleteByIdProducto] (
	@IdProducto int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Inventario]
WHERE
	[IdProducto] = @IdProducto


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InventarioSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InventarioSelect]
GO

CREATE PROCEDURE [dbo].[InventarioSelect] (
	@IdInventario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdInventario],
	[IdProducto],
	[Total]
FROM
	[Inventario]
WHERE
	[IdInventario] = @IdInventario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InventarioSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InventarioSelectAll]
GO

CREATE PROCEDURE [dbo].[InventarioSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdInventario],
	[IdProducto],
	[Total]
FROM
	[Inventario]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[InventarioSelectByIdProducto]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[InventarioSelectByIdProducto]
GO

CREATE PROCEDURE [dbo].[InventarioSelectByIdProducto] (
	@IdProducto int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdInventario],
	[IdProducto],
	[Total]
FROM
	[Inventario]
WHERE
	[IdProducto] = @IdProducto


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Op_InventarioInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Op_InventarioInsert]
GO

CREATE PROCEDURE [dbo].[Op_InventarioInsert] (
	@IdOpInventario uniqueidentifier,
	@Nombre nchar(30),
	@Apellido nchar(30),
	@Telefono nchar(15),
	@Mail nchar(50),
	@CantPedidos int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Op_Inventario] (
	[IdOpInventario],
	[Nombre],
	[Apellido],
	[Telefono],
	[Mail],
	[CantPedidos]
) VALUES (
	@IdOpInventario,
	@Nombre,
	@Apellido,
	@Telefono,
	@Mail,
	@CantPedidos
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Op_InventarioUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Op_InventarioUpdate]
GO

CREATE PROCEDURE [dbo].[Op_InventarioUpdate] (
	@IdOpInventario uniqueidentifier,
	@Nombre nchar(30),
	@Apellido nchar(30),
	@Telefono nchar(15),
	@Mail nchar(50),
	@CantPedidos int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Op_Inventario]
SET
	[Nombre] = @Nombre,
	[Apellido] = @Apellido,
	[Telefono] = @Telefono,
	[Mail] = @Mail,
	[CantPedidos] = @CantPedidos
WHERE
	 [IdOpInventario] = @IdOpInventario

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Op_InventarioDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Op_InventarioDelete]
GO

CREATE PROCEDURE [dbo].[Op_InventarioDelete] (
	@IdOpInventario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Op_Inventario]
WHERE
	[IdOpInventario] = @IdOpInventario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Op_InventarioSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Op_InventarioSelect]
GO

CREATE PROCEDURE [dbo].[Op_InventarioSelect] (
	@IdOpInventario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdOpInventario],
	[Nombre],
	[Apellido],
	[Telefono],
	[Mail],
	[CantPedidos]
FROM
	[Op_Inventario]
WHERE
	[IdOpInventario] = @IdOpInventario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[Op_InventarioSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[Op_InventarioSelectAll]
GO

CREATE PROCEDURE [dbo].[Op_InventarioSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdOpInventario],
	[Nombre],
	[Apellido],
	[Telefono],
	[Mail],
	[CantPedidos]
FROM
	[Op_Inventario]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoInsert]
GO

CREATE PROCEDURE [dbo].[PedidoInsert] (
	@IdPedido uniqueidentifier,
	@Estado nchar(50),
	@IdVenta int,
	@IdOpInventario uniqueidentifier,
	@IdVendedor uniqueidentifier,
	@IdSucursal int,
	@FechaRegistro datetime,
	@FechaCancelacion datetime,
	@FechaEntrega datetime,
	@NroSeguimiento int,
	@Observaciones nchar(100)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Pedido] (
	[IdPedido],
	[Estado],
	[IdVenta],
	[IdOpInventario],
	[IdVendedor],
	[IdSucursal],
	[FechaRegistro],
	[FechaCancelacion],
	[FechaEntrega],
	[NroSeguimiento],
	[Observaciones]
) VALUES (
	@IdPedido,
	@Estado,
	@IdVenta,
	@IdOpInventario,
	@IdVendedor,
	@IdSucursal,
	@FechaRegistro,
	@FechaCancelacion,
	@FechaEntrega,
	@NroSeguimiento,
	@Observaciones
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoUpdate]
GO

CREATE PROCEDURE [dbo].[PedidoUpdate] (
	@IdPedido uniqueidentifier,
	@Estado nchar(50),
	@IdVenta int,
	@IdOpInventario uniqueidentifier,
	@IdVendedor uniqueidentifier,
	@IdSucursal int,
	@FechaRegistro datetime,
	@FechaCancelacion datetime,
	@FechaEntrega datetime,
	@NroSeguimiento int,
	@Observaciones nchar(100)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Pedido]
SET
	[Estado] = @Estado,
	[IdVenta] = @IdVenta,
	[IdOpInventario] = @IdOpInventario,
	[IdVendedor] = @IdVendedor,
	[IdSucursal] = @IdSucursal,
	[FechaRegistro] = @FechaRegistro,
	[FechaCancelacion] = @FechaCancelacion,
	[FechaEntrega] = @FechaEntrega,
	[NroSeguimiento] = @NroSeguimiento,
	[Observaciones] = @Observaciones
WHERE
	 [IdPedido] = @IdPedido

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoDelete]
GO

CREATE PROCEDURE [dbo].[PedidoDelete] (
	@IdPedido uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Pedido]
WHERE
	[IdPedido] = @IdPedido


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoDeleteByIdOpInventario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoDeleteByIdOpInventario]
GO

CREATE PROCEDURE [dbo].[PedidoDeleteByIdOpInventario] (
	@IdOpInventario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Pedido]
WHERE
	[IdOpInventario] = @IdOpInventario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoDeleteByIdSucursal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoDeleteByIdSucursal]
GO

CREATE PROCEDURE [dbo].[PedidoDeleteByIdSucursal] (
	@IdSucursal int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Pedido]
WHERE
	[IdSucursal] = @IdSucursal


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoDeleteByIdVendedor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoDeleteByIdVendedor]
GO

CREATE PROCEDURE [dbo].[PedidoDeleteByIdVendedor] (
	@IdVendedor uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Pedido]
WHERE
	[IdVendedor] = @IdVendedor


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoSelect]
GO

CREATE PROCEDURE [dbo].[PedidoSelect] (
	@IdPedido uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdPedido],
	[Estado],
	[IdVenta],
	[IdOpInventario],
	[IdVendedor],
	[IdSucursal],
	[FechaRegistro],
	[FechaCancelacion],
	[FechaEntrega],
	[NroSeguimiento],
	[Observaciones]
FROM
	[Pedido]
WHERE
	[IdPedido] = @IdPedido


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoSelectAll]
GO

CREATE PROCEDURE [dbo].[PedidoSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdPedido],
	[Estado],
	[IdVenta],
	[IdOpInventario],
	[IdVendedor],
	[IdSucursal],
	[FechaRegistro],
	[FechaCancelacion],
	[FechaEntrega],
	[NroSeguimiento],
	[Observaciones]
FROM
	[Pedido]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoSelectByIdOpInventario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoSelectByIdOpInventario]
GO

CREATE PROCEDURE [dbo].[PedidoSelectByIdOpInventario] (
	@IdOpInventario uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdPedido],
	[Estado],
	[IdVenta],
	[IdOpInventario],
	[IdVendedor],
	[IdSucursal],
	[FechaRegistro],
	[FechaCancelacion],
	[FechaEntrega],
	[NroSeguimiento],
	[Observaciones]
FROM
	[Pedido]
WHERE
	[IdOpInventario] = @IdOpInventario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoSelectByIdSucursal]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoSelectByIdSucursal]
GO

CREATE PROCEDURE [dbo].[PedidoSelectByIdSucursal] (
	@IdSucursal int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdPedido],
	[Estado],
	[IdVenta],
	[IdOpInventario],
	[IdVendedor],
	[IdSucursal],
	[FechaRegistro],
	[FechaCancelacion],
	[FechaEntrega],
	[NroSeguimiento],
	[Observaciones]
FROM
	[Pedido]
WHERE
	[IdSucursal] = @IdSucursal


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[PedidoSelectByIdVendedor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[PedidoSelectByIdVendedor]
GO

CREATE PROCEDURE [dbo].[PedidoSelectByIdVendedor] (
	@IdVendedor uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdPedido],
	[Estado],
	[IdVenta],
	[IdOpInventario],
	[IdVendedor],
	[IdSucursal],
	[FechaRegistro],
	[FechaCancelacion],
	[FechaEntrega],
	[NroSeguimiento],
	[Observaciones]
FROM
	[Pedido]
WHERE
	[IdVendedor] = @IdVendedor


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoInsert]
GO

CREATE PROCEDURE [dbo].[ProductoInsert] (
	@IdProducto int,
	@Descripcion nchar(100),
	@Stock int,
	@ValorMin decimal(18, 2),
	@ValorMax decimal(18, 2),
	@Estado bit,
	@Categoria nchar(50),
	@Codigo nchar(20),
	@Vigencia datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Producto] (
	[IdProducto],
	[Descripcion],
	[Stock],
	[ValorMin],
	[ValorMax],
	[Estado],
	[Categoria],
	[Codigo],
	[Vigencia]
) VALUES (
	@IdProducto,
	@Descripcion,
	@Stock,
	@ValorMin,
	@ValorMax,
	@Estado,
	@Categoria,
	@Codigo,
	@Vigencia
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoUpdate]
GO

CREATE PROCEDURE [dbo].[ProductoUpdate] (
	@IdProducto int,
	@Descripcion nchar(100),
	@Stock int,
	@ValorMin decimal(18, 2),
	@ValorMax decimal(18, 2),
	@Estado bit,
	@Categoria nchar(50),
	@Codigo nchar(20),
	@Vigencia datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Producto]
SET
	[Descripcion] = @Descripcion,
	[Stock] = @Stock,
	[ValorMin] = @ValorMin,
	[ValorMax] = @ValorMax,
	[Estado] = @Estado,
	[Categoria] = @Categoria,
	[Codigo] = @Codigo,
	[Vigencia] = @Vigencia
WHERE
	 [IdProducto] = @IdProducto

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoDelete]
GO

CREATE PROCEDURE [dbo].[ProductoDelete] (
	@IdProducto int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Producto]
WHERE
	[IdProducto] = @IdProducto


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoSelect]
GO

CREATE PROCEDURE [dbo].[ProductoSelect] (
	@IdProducto int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdProducto],
	[Descripcion],
	[Stock],
	[ValorMin],
	[ValorMax],
	[Estado],
	[Categoria],
	[Codigo],
	[Vigencia]
FROM
	[Producto]
WHERE
	[IdProducto] = @IdProducto


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[ProductoSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[ProductoSelectAll]
GO

CREATE PROCEDURE [dbo].[ProductoSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdProducto],
	[Descripcion],
	[Stock],
	[ValorMin],
	[ValorMax],
	[Estado],
	[Categoria],
	[Codigo],
	[Vigencia]
FROM
	[Producto]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SucursalInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[SucursalInsert]
GO

CREATE PROCEDURE [dbo].[SucursalInsert] (
	@IdSucural int,
	@Direccion nchar(60),
	@CantPedidos int,
	@IdInventario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Sucursal] (
	[IdSucural],
	[Direccion],
	[CantPedidos],
	[IdInventario]
) VALUES (
	@IdSucural,
	@Direccion,
	@CantPedidos,
	@IdInventario
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SucursalUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[SucursalUpdate]
GO

CREATE PROCEDURE [dbo].[SucursalUpdate] (
	@IdSucural int,
	@Direccion nchar(60),
	@CantPedidos int,
	@IdInventario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Sucursal]
SET
	[Direccion] = @Direccion,
	[CantPedidos] = @CantPedidos,
	[IdInventario] = @IdInventario
WHERE
	 [IdSucural] = @IdSucural

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SucursalDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[SucursalDelete]
GO

CREATE PROCEDURE [dbo].[SucursalDelete] (
	@IdSucural int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Sucursal]
WHERE
	[IdSucural] = @IdSucural


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SucursalDeleteByIdInventario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[SucursalDeleteByIdInventario]
GO

CREATE PROCEDURE [dbo].[SucursalDeleteByIdInventario] (
	@IdInventario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Sucursal]
WHERE
	[IdInventario] = @IdInventario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SucursalSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[SucursalSelect]
GO

CREATE PROCEDURE [dbo].[SucursalSelect] (
	@IdSucural int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdSucural],
	[Direccion],
	[CantPedidos],
	[IdInventario]
FROM
	[Sucursal]
WHERE
	[IdSucural] = @IdSucural


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SucursalSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[SucursalSelectAll]
GO

CREATE PROCEDURE [dbo].[SucursalSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdSucural],
	[Direccion],
	[CantPedidos],
	[IdInventario]
FROM
	[Sucursal]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SucursalSelectByIdInventario]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[SucursalSelectByIdInventario]
GO

CREATE PROCEDURE [dbo].[SucursalSelectByIdInventario] (
	@IdInventario int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdSucural],
	[Direccion],
	[CantPedidos],
	[IdInventario]
FROM
	[Sucursal]
WHERE
	[IdInventario] = @IdInventario


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VendedorInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VendedorInsert]
GO

CREATE PROCEDURE [dbo].[VendedorInsert] (
	@IdVendedor uniqueidentifier,
	@Nombre nchar(30),
	@Apellido nchar(30),
	@Telefono nchar(15),
	@Mail nchar(50),
	@CantVentas int,
	@FechaRegistro datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Vendedor] (
	[IdVendedor],
	[Nombre],
	[Apellido],
	[Telefono],
	[Mail],
	[CantVentas],
	[FechaRegistro]
) VALUES (
	@IdVendedor,
	@Nombre,
	@Apellido,
	@Telefono,
	@Mail,
	@CantVentas,
	@FechaRegistro
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VendedorUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VendedorUpdate]
GO

CREATE PROCEDURE [dbo].[VendedorUpdate] (
	@IdVendedor uniqueidentifier,
	@Nombre nchar(30),
	@Apellido nchar(30),
	@Telefono nchar(15),
	@Mail nchar(50),
	@CantVentas int,
	@FechaRegistro datetime
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Vendedor]
SET
	[Nombre] = @Nombre,
	[Apellido] = @Apellido,
	[Telefono] = @Telefono,
	[Mail] = @Mail,
	[CantVentas] = @CantVentas,
	[FechaRegistro] = @FechaRegistro
WHERE
	 [IdVendedor] = @IdVendedor

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VendedorDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VendedorDelete]
GO

CREATE PROCEDURE [dbo].[VendedorDelete] (
	@IdVendedor uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Vendedor]
WHERE
	[IdVendedor] = @IdVendedor


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VendedorSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VendedorSelect]
GO

CREATE PROCEDURE [dbo].[VendedorSelect] (
	@IdVendedor uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdVendedor],
	[Nombre],
	[Apellido],
	[Telefono],
	[Mail],
	[CantVentas],
	[FechaRegistro]
FROM
	[Vendedor]
WHERE
	[IdVendedor] = @IdVendedor


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VendedorSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VendedorSelectAll]
GO

CREATE PROCEDURE [dbo].[VendedorSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdVendedor],
	[Nombre],
	[Apellido],
	[Telefono],
	[Mail],
	[CantVentas],
	[FechaRegistro]
FROM
	[Vendedor]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaInsert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaInsert]
GO

CREATE PROCEDURE [dbo].[VentaInsert] (
	@IdVenta int,
	@IdVendedor uniqueidentifier,
	@IdCliente uniqueidentifier,
	@Total decimal(18, 2),
	@Estado nchar(20),
	@FechaRegistro datetime,
	@FechaCancelacion datetime,
	@NroVenta int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Venta] (
	[IdVenta],
	[IdVendedor],
	[IdCliente],
	[Total],
	[Estado],
	[FechaRegistro],
	[FechaCancelacion],
	[NroVenta]
) VALUES (
	@IdVenta,
	@IdVendedor,
	@IdCliente,
	@Total,
	@Estado,
	@FechaRegistro,
	@FechaCancelacion,
	@NroVenta
)

SELECT SCOPE_IDENTITY() AS IdDetalleVenta
IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
ELSE
	SELECT SCOPE_IDENTITY() AS IdDetalleVenta
GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaUpdate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaUpdate]
GO

CREATE PROCEDURE [dbo].[VentaUpdate] (
	@IdVenta int,
	@IdVendedor uniqueidentifier,
	@IdCliente uniqueidentifier,
	@IdDetalleVenta int,
	@Total decimal(18, 2),
	@Estado nchar(20),
	@FechaRegistro datetime,
	@FechaCancelacion datetime,
	@NroVenta int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Venta]
SET
	[IdVendedor] = @IdVendedor,
	[IdCliente] = @IdCliente,
	[Total] = @Total,
	[Estado] = @Estado,
	[FechaRegistro] = @FechaRegistro,
	[FechaCancelacion] = @FechaCancelacion,
	[NroVenta] = @NroVenta
WHERE
	 [IdVenta] = @IdVenta

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaDelete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaDelete]
GO

CREATE PROCEDURE [dbo].[VentaDelete] (
	@IdVenta int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Venta]
WHERE
	[IdVenta] = @IdVenta


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaDeleteByIdDetalleVenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaDeleteByIdDetalleVenta]
GO

CREATE PROCEDURE [dbo].[VentaDeleteByIdDetalleVenta] (
	@IdDetalleVenta int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Venta]
WHERE
	[IdDetalleVenta] = @IdDetalleVenta


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaDeleteByIdCliente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaDeleteByIdCliente]
GO

CREATE PROCEDURE [dbo].[VentaDeleteByIdCliente] (
	@IdCliente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Venta]
WHERE
	[IdCliente] = @IdCliente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaDeleteByIdVendedor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaDeleteByIdVendedor]
GO

CREATE PROCEDURE [dbo].[VentaDeleteByIdVendedor] (
	@IdVendedor uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Venta]
WHERE
	[IdVendedor] = @IdVendedor


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaSelect]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaSelect]
GO

CREATE PROCEDURE [dbo].[VentaSelect] (
	@IdVenta int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdVenta],
	[IdVendedor],
	[IdCliente],
	[IdDetalleVenta],
	[Total],
	[Estado],
	[FechaRegistro],
	[FechaCancelacion],
	[NroVenta]
FROM
	[Venta]
WHERE
	[IdVenta] = @IdVenta


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaSelectAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaSelectAll]
GO

CREATE PROCEDURE [dbo].[VentaSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdVenta],
	[IdVendedor],
	[IdCliente],
	[IdDetalleVenta],
	[Total],
	[Estado],
	[FechaRegistro],
	[FechaCancelacion],
	[NroVenta]
FROM
	[Venta]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaSelectByIdDetalleVenta]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaSelectByIdDetalleVenta]
GO

CREATE PROCEDURE [dbo].[VentaSelectByIdDetalleVenta] (
	@IdDetalleVenta int
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdVenta],
	[IdVendedor],
	[IdCliente],
	[IdDetalleVenta],
	[Total],
	[Estado],
	[FechaRegistro],
	[FechaCancelacion],
	[NroVenta]
FROM
	[Venta]
WHERE
	[IdDetalleVenta] = @IdDetalleVenta


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaSelectByIdCliente]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaSelectByIdCliente]
GO

CREATE PROCEDURE [dbo].[VentaSelectByIdCliente] (
	@IdCliente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdVenta],
	[IdVendedor],
	[IdCliente],
	[IdDetalleVenta],
	[Total],
	[Estado],
	[FechaRegistro],
	[FechaCancelacion],
	[NroVenta]
FROM
	[Venta]
WHERE
	[IdCliente] = @IdCliente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO

/*******************************************************************************
*******************************************************************************/
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[VentaSelectByIdVendedor]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
	drop procedure [dbo].[VentaSelectByIdVendedor]
GO

CREATE PROCEDURE [dbo].[VentaSelectByIdVendedor] (
	@IdVendedor uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdVenta],
	[IdVendedor],
	[IdCliente],
	[IdDetalleVenta],
	[Total],
	[Estado],
	[FechaRegistro],
	[FechaCancelacion],
	[NroVenta]
FROM
	[Venta]
WHERE
	[IdVendedor] = @IdVendedor


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
