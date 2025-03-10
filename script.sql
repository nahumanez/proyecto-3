USE [Comercio]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 10/03/2025 9:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ApellidoClien] [nvarchar](50) NOT NULL,
	[NombreClien] [nvarchar](50) NOT NULL,
	[DocumentoClien] [nvarchar](20) NULL,
	[CuitClien] [nvarchar](20) NULL,
	[DomicilioClien] [nvarchar](100) NULL,
	[PostalClien] [nvarchar](10) NULL,
	[LocalidadClien] [nvarchar](50) NULL,
	[ProvinciaClien] [nvarchar](50) NULL,
	[TelefonoClien] [nvarchar](20) NULL,
	[FechaNacimientoClien] [datetime] NULL,
	[ComentariosClien] [nvarchar](max) NULL,
	[EMailClien] [nvarchar](100) NULL,
	[Estado] [bit] NOT NULL,
	[UsuarioClien] [nvarchar](50) NULL,
	[ClaveClien] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 10/03/2025 9:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ApellidoProvee] [nvarchar](50) NOT NULL,
	[NombreProvee] [nvarchar](50) NOT NULL,
	[DocumentoProvee] [nvarchar](20) NULL,
	[CuitProvee] [nvarchar](20) NULL,
	[DomicilioProvee] [nvarchar](100) NULL,
	[PostalProvee] [nvarchar](10) NULL,
	[LocalidadProvee] [nvarchar](50) NULL,
	[ProvinciaProvee] [nvarchar](50) NULL,
	[TelefonoProvee] [nvarchar](20) NULL,
	[FechaNacimientoProvee] [datetime] NULL,
	[ComentariosProvee] [nvarchar](max) NULL,
	[EMailProvee] [nvarchar](100) NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 10/03/2025 9:21:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ApellidoUsu] [nvarchar](50) NOT NULL,
	[NombreUsu] [nvarchar](50) NOT NULL,
	[DocumentoUsu] [nvarchar](20) NULL,
	[CuitUsu] [nvarchar](20) NULL,
	[DomicilioUsu] [nvarchar](100) NULL,
	[PostalUsu] [nvarchar](10) NULL,
	[LocalidadUsu] [nvarchar](50) NULL,
	[ProvinciaUsu] [nvarchar](50) NULL,
	[TelefonoUsu] [nvarchar](20) NULL,
	[FechaNacimientoUsu] [datetime] NULL,
	[ComentariosUsu] [nvarchar](max) NULL,
	[EMailUsu] [nvarchar](100) NULL,
	[Estado] [bit] NOT NULL,
	[UsuarioUsu] [nvarchar](50) NULL,
	[ClaveUsu] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Clientes] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Proveedores] ADD  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ((1)) FOR [Estado]
GO
