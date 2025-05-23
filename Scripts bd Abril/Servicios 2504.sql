
USE [ServicesOneVision]
GO
/****** Object:  Table [dbo].[Familia]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia](
	[IdFamilia] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](1000) NULL,
	[timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK__Familia__751F80CFAEC6D605] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Familia]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Familia](
	[IdFamilia] [uniqueidentifier] NOT NULL,
	[IdFamiliaHijo] [uniqueidentifier] NOT NULL,
	[timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK__Familia___ABFCC67EA96FECF5] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC,
	[IdFamiliaHijo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Familia_Patente]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Familia_Patente](
	[IdFamilia] [uniqueidentifier] NOT NULL,
	[IdPatente] [uniqueidentifier] NOT NULL,
	[timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK__FamiliaE__166FEEA61367E606] PRIMARY KEY CLUSTERED 
(
	[IdFamilia] ASC,
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Patente]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Patente](
	[IdPatente] [uniqueidentifier] NOT NULL,
	[Nombre] [varchar](1000) NULL,
	[DataKey] [varchar](1000) NULL,
	[TipoAcceso] [int] NULL,
	[timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK__Patente__9F4EF95C34290DD0] PRIMARY KEY CLUSTERED 
(
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[UserName] [varchar](1000) NULL,
	[Password] [varchar](1000) NULL,
	[Estado] [int] NULL,
	[timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK__Usuario__5B65BF97B1F8060E] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Familia]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Familia](
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[IdFamilia] [uniqueidentifier] NOT NULL,
	[timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK__Usuario___BC34479BE7F15ED7] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdFamilia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario_Patente]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario_Patente](
	[IdUsuario] [uniqueidentifier] NOT NULL,
	[IdPatente] [uniqueidentifier] NOT NULL,
	[timestamp] [timestamp] NOT NULL,
 CONSTRAINT [PK_Usuario_Patente] PRIMARY KEY CLUSTERED 
(
	[IdUsuario] ASC,
	[IdPatente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Familia] ([IdFamilia], [Nombre]) VALUES (N'0e1ee95c-c77b-4ac4-afff-36176f7f828e', N'Operador')
INSERT [dbo].[Familia] ([IdFamilia], [Nombre]) VALUES (N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'Administrador')
INSERT [dbo].[Familia] ([IdFamilia], [Nombre]) VALUES (N'0c3a69e1-71ff-4ac7-83f0-67e206c8a5e3', N'KIKI')
INSERT [dbo].[Familia] ([IdFamilia], [Nombre]) VALUES (N'98a8bdd4-0901-4dc1-930d-7887a0c07bcc', N'Sin Rol')
INSERT [dbo].[Familia] ([IdFamilia], [Nombre]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'Vendedor')
GO
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'0e1ee95c-c77b-4ac4-afff-36176f7f828e', N'b1c78395-7b4d-409a-aee7-5dbe7b5f8de5')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'0e1ee95c-c77b-4ac4-afff-36176f7f828e', N'29c205bd-d5ea-4ab8-b6cf-62b360157c9e')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'0e1ee95c-c77b-4ac4-afff-36176f7f828e', N'5d91c9b6-ee2b-4632-a565-99af8ef54b08')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'0e1ee95c-c77b-4ac4-afff-36176f7f828e', N'2a75959d-5ac3-4394-a023-9b2b3ff6d118')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'0e1ee95c-c77b-4ac4-afff-36176f7f828e', N'afa6bd08-ae41-4296-8266-b0c93d4fea2e')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'eb7c24f9-a95f-4951-8555-377cae7b41ae')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'04ff07a1-0f5e-4ff8-bbb9-558611a4121a')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'b1c78395-7b4d-409a-aee7-5dbe7b5f8de5')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'd4f290fc-cf00-4748-b5af-5f6c008f8288')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'2a75959d-5ac3-4394-a023-9b2b3ff6d118')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb', N'afa6bd08-ae41-4296-8266-b0c93d4fea2e')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'0c3a69e1-71ff-4ac7-83f0-67e206c8a5e3', N'2a75959d-5ac3-4394-a023-9b2b3ff6d118')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'0c3a69e1-71ff-4ac7-83f0-67e206c8a5e3', N'afa6bd08-ae41-4296-8266-b0c93d4fea2e')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'98a8bdd4-0901-4dc1-930d-7887a0c07bcc', N'eb7c24f9-a95f-4951-8555-377cae7b41ae')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'98a8bdd4-0901-4dc1-930d-7887a0c07bcc', N'2a75959d-5ac3-4394-a023-9b2b3ff6d118')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'98a8bdd4-0901-4dc1-930d-7887a0c07bcc', N'afa6bd08-ae41-4296-8266-b0c93d4fea2e')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'795a7661-49be-435a-a42a-267ac1daec86')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'572ef93c-189b-4f34-9fc2-441f9c0c5fa8')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'5fb4ace3-8ded-462e-9e66-4528fb22d150')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'b1c78395-7b4d-409a-aee7-5dbe7b5f8de5')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'4b803366-f85a-4033-b8d7-83655c3af0c9')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'e01b5957-391d-412f-a2b3-842b4d849c22')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'26c0bd2e-39ec-4c0d-bcc6-85a814a7e679')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'2a75959d-5ac3-4394-a023-9b2b3ff6d118')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'afa6bd08-ae41-4296-8266-b0c93d4fea2e')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'd7ee09a8-99cd-4045-b06b-df967a29fbad')
INSERT [dbo].[Familia_Patente] ([IdFamilia], [IdPatente]) VALUES (N'a192f706-5d9c-4b20-8d96-fe84c96f8901', N'1c5f811a-e3b1-4f30-a7b5-f286ad1f9e40')
GO
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'795a7661-49be-435a-a42a-267ac1daec86', N'Ventas', N'menuVentas', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'eb7c24f9-a95f-4951-8555-377cae7b41ae', N'Administrador', N'menuAdministrador', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'572ef93c-189b-4f34-9fc2-441f9c0c5fa8', N'Pedidos', N'menuPedidos', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'5fb4ace3-8ded-462e-9e66-4528fb22d150', N'Gestionar Ventas', N'submenuGestionarVentas', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'04ff07a1-0f5e-4ff8-bbb9-558611a4121a', N'BackUp-Restore', N'subMenuBackupRestore', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'b1c78395-7b4d-409a-aee7-5dbe7b5f8de5', N'Administrar Usuarios', N'submenuAdministrarUsuarios', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'd4f290fc-cf00-4748-b5af-5f6c008f8288', N'Gestionar Accesos', N'submenuAccesos', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'e45c22d7-b749-48b7-9e5f-61990126ab7a', N'Gestionar Productos', N'submenuGestionarProductos', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'29c205bd-d5ea-4ab8-b6cf-62b360157c9e', N'Recepcionar Productos', N'submenuRecepcionarProductos', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'4b803366-f85a-4033-b8d7-83655c3af0c9', N'Gestionar Pedidos', N'submenuGestionarClientes', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'e01b5957-391d-412f-a2b3-842b4d849c22', N'Reportes', N'menuReportes', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'26c0bd2e-39ec-4c0d-bcc6-85a814a7e679', N'Gestionar Clientes', N'submenuGestionarClientes', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'5d91c9b6-ee2b-4632-a565-99af8ef54b08', N'Inventario', N'menuInventario', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'2a75959d-5ac3-4394-a023-9b2b3ff6d118', N'Gestionar Usuario', N'submenuGestionarUsuario', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'afa6bd08-ae41-4296-8266-b0c93d4fea2e', N'Usuario', N'menuUsuario', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'd7ee09a8-99cd-4045-b06b-df967a29fbad', N'Clientes', N'menuClientes', 0)
INSERT [dbo].[Patente] ([IdPatente], [Nombre], [DataKey], [TipoAcceso]) VALUES (N'1c5f811a-e3b1-4f30-a7b5-f286ad1f9e40', N'Reporte de Pedidos', N'submenuReportePedidos', 0)
GO
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Estado]) VALUES (N'df5524fb-4a17-4be9-a4fd-32f398f93c71', N'kiki', N'8254c329a92850f6d539dd376f4816ee2764517da5e0235514af433164480d7a', 0)
INSERT [dbo].[Usuario] ([IdUsuario], [UserName], [Password], [Estado]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'a', N'ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb', 0)
GO
INSERT [dbo].[Usuario_Familia] ([IdUsuario], [IdFamilia]) VALUES (N'df5524fb-4a17-4be9-a4fd-32f398f93c71', N'0c3a69e1-71ff-4ac7-83f0-67e206c8a5e3')
INSERT [dbo].[Usuario_Familia] ([IdUsuario], [IdFamilia]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'0e1ee95c-c77b-4ac4-afff-36176f7f828e')
INSERT [dbo].[Usuario_Familia] ([IdUsuario], [IdFamilia]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'7d162d5c-2add-4ce1-8bab-4f8615e0b4fb')
INSERT [dbo].[Usuario_Familia] ([IdUsuario], [IdFamilia]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'a192f706-5d9c-4b20-8d96-fe84c96f8901')
GO
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'df5524fb-4a17-4be9-a4fd-32f398f93c71', N'2a75959d-5ac3-4394-a023-9b2b3ff6d118')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'df5524fb-4a17-4be9-a4fd-32f398f93c71', N'afa6bd08-ae41-4296-8266-b0c93d4fea2e')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'795a7661-49be-435a-a42a-267ac1daec86')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'eb7c24f9-a95f-4951-8555-377cae7b41ae')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'572ef93c-189b-4f34-9fc2-441f9c0c5fa8')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'5fb4ace3-8ded-462e-9e66-4528fb22d150')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'04ff07a1-0f5e-4ff8-bbb9-558611a4121a')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'b1c78395-7b4d-409a-aee7-5dbe7b5f8de5')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'd4f290fc-cf00-4748-b5af-5f6c008f8288')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'e45c22d7-b749-48b7-9e5f-61990126ab7a')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'29c205bd-d5ea-4ab8-b6cf-62b360157c9e')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'4b803366-f85a-4033-b8d7-83655c3af0c9')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'e01b5957-391d-412f-a2b3-842b4d849c22')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'26c0bd2e-39ec-4c0d-bcc6-85a814a7e679')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'5d91c9b6-ee2b-4632-a565-99af8ef54b08')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'2a75959d-5ac3-4394-a023-9b2b3ff6d118')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'afa6bd08-ae41-4296-8266-b0c93d4fea2e')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'd7ee09a8-99cd-4045-b06b-df967a29fbad')
INSERT [dbo].[Usuario_Patente] ([IdUsuario], [IdPatente]) VALUES (N'b3870e50-acd0-4827-82bc-fd790b6ef48c', N'1c5f811a-e3b1-4f30-a7b5-f286ad1f9e40')
GO
ALTER TABLE [dbo].[Familia_Familia]  WITH CHECK ADD  CONSTRAINT [FK__Familia_A__Famil__37A5467C] FOREIGN KEY([IdFamiliaHijo])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Familia_Familia] CHECK CONSTRAINT [FK__Familia_A__Famil__37A5467C]
GO
ALTER TABLE [dbo].[Familia_Familia]  WITH CHECK ADD  CONSTRAINT [FK__Familia_F__IdFam__656C112C] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Familia_Familia] CHECK CONSTRAINT [FK__Familia_F__IdFam__656C112C]
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Familia_Patente_Familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Familia_Patente] CHECK CONSTRAINT [FK_Familia_Patente_Familia]
GO
ALTER TABLE [dbo].[Familia_Patente]  WITH CHECK ADD  CONSTRAINT [FK_FamiliaElement_Patente] FOREIGN KEY([IdPatente])
REFERENCES [dbo].[Patente] ([IdPatente])
GO
ALTER TABLE [dbo].[Familia_Patente] CHECK CONSTRAINT [FK_FamiliaElement_Patente]
GO
ALTER TABLE [dbo].[Usuario_Familia]  WITH CHECK ADD  CONSTRAINT [FK__Usuario_F__IdUsu__693CA210] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuario_Familia] CHECK CONSTRAINT [FK__Usuario_F__IdUsu__693CA210]
GO
ALTER TABLE [dbo].[Usuario_Familia]  WITH CHECK ADD  CONSTRAINT [FK__Usuario_P__Famil__35BCFE0A] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[Familia] ([IdFamilia])
GO
ALTER TABLE [dbo].[Usuario_Familia] CHECK CONSTRAINT [FK__Usuario_P__Famil__35BCFE0A]
GO
ALTER TABLE [dbo].[Usuario_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Patente_Patente] FOREIGN KEY([IdPatente])
REFERENCES [dbo].[Patente] ([IdPatente])
GO
ALTER TABLE [dbo].[Usuario_Patente] CHECK CONSTRAINT [FK_Usuario_Patente_Patente]
GO
ALTER TABLE [dbo].[Usuario_Patente]  WITH CHECK ADD  CONSTRAINT [FK_Usuario_Patente_Usuario] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[Usuario] ([IdUsuario])
GO
ALTER TABLE [dbo].[Usuario_Patente] CHECK CONSTRAINT [FK_Usuario_Patente_Usuario]
GO
/****** Object:  StoredProcedure [dbo].[Familia_PatenteDelete]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Familia_PatenteDelete] (
	@IdFamilia uniqueidentifier,
	@IdPatente uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Familia_Patente]
WHERE
	[IdFamilia] = @IdFamilia
	AND [IdPatente] = @IdPatente


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaInsert]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaInsert] (
	@IdFamilia uniqueidentifier,
	@Nombre varchar(1000)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Familia] (
	[IdFamilia],
	[Nombre]
) VALUES (
	@IdFamilia,
	@Nombre
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaSelect]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaSelect] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[Nombre]
FROM
	[Familia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[FamiliaSelectAll]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[FamiliaSelectAll]
as
select * from familia 
GO
/****** Object:  StoredProcedure [dbo].[FamiliaUpdate]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[FamiliaUpdate] (
	@IdFamilia uniqueidentifier,
	@Nombre varchar(1000)
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE
	[Familia]
SET
	[Nombre] = @Nombre
WHERE
	 [IdFamilia] = @IdFamilia

IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PatenteSelect]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PatenteSelect]
    @IdPatente UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        IF @IdPatente IS NULL
        BEGIN
            RAISERROR('El parámetro IdPatente no puede ser NULL.', 16, 1);
            RETURN;
        END

        SELECT [IdPatente],
               [Nombre],
               [DataKey],
               [TipoAcceso]
        FROM [Patente]
        WHERE [IdPatente] = @IdPatente;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR('Error en PatenteSelect: %s', 16, 1, @ErrorMessage);
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[PatenteSelectAll]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PatenteSelectAll]

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdPatente],
	[Nombre],
	[DataKey],
	[TipoAcceso]
FROM
	[Patente]


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[PatenteSelectByFamiliaDeUsuario]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PatenteSelectByFamiliaDeUsuario]
    @IdUsuario UNIQUEIDENTIFIER
AS
BEGIN
    BEGIN TRY
        SELECT P.* 
        FROM Patente P
        INNER JOIN Familia_Patente FP ON P.IdPatente = FP.IdPatente
        INNER JOIN Usuario_Familia UF ON FP.IdFamilia = UF.IdFamilia
        WHERE UF.IdUsuario = @IdUsuario;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR('Error en PatenteSelectByFamiliaDeUsuario: %s', 16, 1, @ErrorMessage);
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[PatenteSelectByNombre]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PatenteSelectByNombre]
    @NombrePatente NVARCHAR(255)
AS
BEGIN
    BEGIN TRY
        SELECT [IdPatente],
               [Nombre],
               [DataKey],
               [TipoAcceso],
               [timestamp]
        FROM [dbo].[Patente]
        WHERE [Nombre] = @NombrePatente;
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR('Error en PatenteSelectByNombre: %s', 16, 1, @ErrorMessage);
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[PatenteSelectIndividualesByUsuario]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PatenteSelectIndividualesByUsuario]
    @IdUsuario UNIQUEIDENTIFIER
AS
BEGIN
    SELECT P.* 
    FROM Patente P
    INNER JOIN Usuario_Patente UP ON P.IdPatente = UP.IdPatente
    LEFT JOIN Familia_Patente FP ON P.IdPatente = FP.IdPatente
    LEFT JOIN Usuario_Familia UF ON FP.IdFamilia = UF.IdFamilia AND UF.IdUsuario = @IdUsuario
    WHERE UP.IdUsuario = @IdUsuario
    AND FP.IdFamilia IS NULL;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteFamilia]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteFamilia] (
    @IdFamilia UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Verificar si la familia existe antes de eliminar
        IF NOT EXISTS (SELECT 1 FROM [Familia] WHERE [IdFamilia] = @IdFamilia)
        BEGIN
            RAISERROR('La familia con el Id especificado no existe.', 16, 1);
            RETURN;
        END

        -- Eliminar relaciones asociadas a la familia (si existen)
        DELETE FROM [FamiliaPatente] WHERE [IdFamilia] = @IdFamilia;

        -- Eliminar la familia
        DELETE FROM [Familia] WHERE [IdFamilia] = @IdFamilia;

        PRINT 'Familia eliminada exitosamente.';
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteFamilia_Familia]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_DeleteFamilia_Familia] (
	@IdFamilia uniqueidentifier,
	@IdFamiliaHijo uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Familia_Familia]
WHERE
	[IdFamilia] = @IdFamilia
	AND [IdFamiliaHijo] = @IdFamiliaHijo


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteFamiliaCompleto]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DeleteFamiliaCompleto] (
    @IdFamilia UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Validar si la familia existe
        IF NOT EXISTS (SELECT 1 FROM Familia WHERE IdFamilia = @IdFamilia)
        BEGIN
            RAISERROR('La familia con el Id especificado no existe.', 16, 1);
            RETURN;
        END

        -- Paso 1: Eliminar relaciones con familias hijas
        DELETE FROM Familia_Familia WHERE IdFamilia = @IdFamilia;

        -- Paso 2: Eliminar relaciones con patentes individuales
        DELETE FROM Familia_Patente WHERE IdFamilia = @IdFamilia;

        -- Paso 3: Eliminar usuarios asociados (si es necesario reasignar a "Sin Rol", se maneja en la lógica de aplicación)
        DELETE FROM Usuario_Familia WHERE IdFamilia = @IdFamilia;

        -- Paso 4: Eliminar la familia principal
        DELETE FROM Familia WHERE IdFamilia = @IdFamilia;

        PRINT 'Familia eliminada correctamente.';
    END TRY
    BEGIN CATCH
        -- Manejo de errores
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_Familia_FamiliaSelectByIdFamilia]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_Familia_FamiliaSelectByIdFamilia] (
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
	[IdFamilia],
	[IdFamiliaHijo]
FROM
	[Familia_Familia]
WHERE
	[IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[sp_GetAllFamilia]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_GetAllFamilia]
as
select * from familia 
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertFamilia_Familia]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_InsertFamilia_Familia] (
	@IdFamilia uniqueidentifier,
	@IdFamiliaHijo uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Familia_Familia] (
	[IdFamilia],
	[IdFamiliaHijo]
) VALUES (
	@IdFamilia,
	@IdFamiliaHijo
)


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertFamilia_Patente]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertFamilia_Patente] (
    @IdFamilia UNIQUEIDENTIFIER,
    @IdPatente UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS (
        SELECT 1 
        FROM Familia_Patente
        WHERE IdFamilia = @IdFamilia
          AND IdPatente = @IdPatente
    )
    BEGIN
        INSERT INTO Familia_Patente (IdFamilia, IdPatente)
        VALUES (@IdFamilia, @IdPatente);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_SelectByIdFamiliaFamilia_Patente]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SelectByIdFamiliaFamilia_Patente] (
    @IdFamilia uniqueidentifier
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DBID INT, @DBNAME NVARCHAR(128);
    SET @DBID = DB_ID();
    SET @DBNAME = DB_NAME();

    SELECT
        fp.[IdFamilia],
        fp.[IdPatente],
        p.[Nombre] AS NombrePatente -- Asegúrate de que este campo existe en tu tabla de Patentes
    FROM
        [Familia_Patente] fp
    INNER JOIN
        [Patente] p ON fp.IdPatente = p.IdPatente -- Unir con la tabla de Patentes para obtener el nombre
    WHERE
        fp.[IdFamilia] = @IdFamilia;

    IF (@@ERROR <> 0)
        RAISERROR(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
END

GO
/****** Object:  StoredProcedure [dbo].[Usuario_FamiliaDelete]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Usuario_FamiliaDelete] (
	@IdUsuario uniqueidentifier,
	@IdFamilia uniqueidentifier
)

AS

SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

DELETE FROM
	[Usuario_Familia]
WHERE
	[IdUsuario] = @IdUsuario
	AND [IdFamilia] = @IdFamilia


IF (@@ERROR <> 0)
	RAISERROR
		(N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);

GO
/****** Object:  StoredProcedure [dbo].[Usuario_FamiliaInsert]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usuario_FamiliaInsert] (
    @IdUsuario UNIQUEIDENTIFIER,
    @IdFamilia UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    IF NOT EXISTS(
        SELECT 1 FROM Usuario_Familia
        WHERE IdUsuario = @IdUsuario
          AND IdFamilia = @IdFamilia
    )
    BEGIN
        INSERT INTO Usuario_Familia (IdUsuario, IdFamilia)
        VALUES (@IdUsuario, @IdFamilia);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Usuario_FamiliaSelectByIdUsuario]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Usuario_FamiliaSelectByIdUsuario] 
(
    @IdUsuario UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DBID INT, @DBNAME NVARCHAR(128);
    SET @DBID = DB_ID();
    SET @DBNAME = DB_NAME();

    SELECT
        uf.IdUsuario,              -- Referenciando IdUsuario de la tabla Usuario_Familia
        uf.IdFamilia,              -- Especificamos que IdFamilia viene de Usuario_Familia
        f.Nombre AS NombreFamilia   -- Asignando un alias para Nombre
    FROM
        [Usuario_Familia] uf
    INNER JOIN
        [Familia] f ON uf.IdFamilia = f.IdFamilia
    WHERE
        uf.IdUsuario = @IdUsuario;

    IF (@@ERROR <> 0)
        RAISERROR
            (N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
END
GO
/****** Object:  StoredProcedure [dbo].[Usuario_PatenteDelete]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usuario_PatenteDelete]
    @IdUsuario UNIQUEIDENTIFIER,
    @IdPatente UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM Usuario_Patente 
    WHERE IdUsuario = @IdUsuario AND IdPatente = @IdPatente;
END
GO
/****** Object:  StoredProcedure [dbo].[Usuario_PatenteInsert]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Usuario_PatenteInsert]
(
    @IdUsuario UNIQUEIDENTIFIER,
    @IdPatente UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;
    
    IF NOT EXISTS(
        SELECT 1 FROM [Usuario_Patente]
        WHERE [IdUsuario] = @IdUsuario
          AND [IdPatente] = @IdPatente
    )
    BEGIN
        INSERT INTO [Usuario_Patente] (IdUsuario, IdPatente)
        VALUES (@IdUsuario, @IdPatente);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[Usuario_PatenteSelectByIdUsuario]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

		-- Procedimiento almacenado para seleccionar todas las patentes asociadas a un usuario por su IdUsuario
CREATE PROCEDURE [dbo].[Usuario_PatenteSelectByIdUsuario] 
(
    @IdUsuario UNIQUEIDENTIFIER
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Consulta para obtener las patentes relacionadas con el usuario
    SELECT 
        up.IdPatente, 
        p.Nombre AS NombrePatente
    FROM 
        Usuario_Patente up
    INNER JOIN 
        Patente p ON up.IdPatente = p.IdPatente
    WHERE 
        up.IdUsuario = @IdUsuario;

    -- Si ocurre un error, capturar información adicional
    IF (@@ERROR <> 0)
    BEGIN
        DECLARE @DBID INT, @DBNAME NVARCHAR(128);
        SET @DBID = DB_ID();
        SET @DBNAME = DB_NAME();

        RAISERROR (N'Ocurrió un error en la base de datos %s (ID: %d)', 16, 1, @DBNAME, @DBID);
    END
END

GO
/****** Object:  StoredProcedure [dbo].[UsuarioGetAll]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioGetAll]
AS
SELECT 
    IdUsuario,
    UserName,
    Password,
    Estado -- Se agrega el nuevo atributo
FROM 
    Usuario
GO
/****** Object:  StoredProcedure [dbo].[UsuarioInsert]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioInsert] (
    @IdUsuario UNIQUEIDENTIFIER,
    @UserName VARCHAR(1000),
    @Password VARCHAR(1000),
    @Estado INT -- Nuevo parámetro para el atributo Estado
)
AS
SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

INSERT INTO [Usuario] (
    [IdUsuario],
    [UserName],
    [Password],
    [Estado] -- Se agrega el nuevo campo en el INSERT
) VALUES (
    @IdUsuario,
    @UserName,
    @Password,
    @Estado
)

IF (@@ERROR <> 0)
    RAISERROR (N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
GO
/****** Object:  StoredProcedure [dbo].[UsuarioSelect]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioSelect] (
    @IdUsuario UNIQUEIDENTIFIER
)
AS
SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

SELECT
    [IdUsuario],
    [UserName],
    [Password],
    [Estado] -- Se agrega el nuevo atributo en el SELECT
FROM
    [Usuario]
WHERE
    [IdUsuario] = @IdUsuario

IF (@@ERROR <> 0)
    RAISERROR (N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
GO
/****** Object:  StoredProcedure [dbo].[UsuarioSelectByUsername]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UsuarioSelectByUsername]
@UserName NVARCHAR(50)
AS
BEGIN
    SELECT * FROM Usuario WHERE UserName = @UserName
END
GO
/****** Object:  StoredProcedure [dbo].[UsuarioUpdate]    Script Date: 25/4/2025 15:19:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UsuarioUpdate] (
    @IdUsuario UNIQUEIDENTIFIER,
    @UserName VARCHAR(1000),
    @Password VARCHAR(1000),
    @Estado INT -- Nuevo parámetro para el atributo Estado
)
AS
SET NOCOUNT ON

DECLARE @DBID INT, @DBNAME NVARCHAR(128);
SET @DBID = DB_ID();
SET @DBNAME = DB_NAME();

UPDATE [Usuario]
SET
    [UserName] = @UserName,
    [Password] = @Password,
    [Estado] = @Estado -- Se agrega el nuevo campo en el UPDATE
WHERE
    [IdUsuario] = @IdUsuario

IF (@@ERROR <> 0)
    RAISERROR (N'El ID de la base de datos actual es: %d, con el nombre: %s.', 10, 1, @DBID, @DBNAME);
GO
USE [master]
GO
ALTER DATABASE [ServicesOneVision] SET  READ_WRITE 
GO
