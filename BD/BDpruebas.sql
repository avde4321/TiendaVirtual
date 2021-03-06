USE [VeterinariaQA]
GO
/****** Object:  Table [dbo].[Estados]    Script Date: 27/5/2021 08:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Estados](
	[idEstado] [varchar](3) NOT NULL,
	[Descripcion] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[idEstado] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Perfiles]    Script Date: 27/5/2021 08:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Perfiles](
	[idPerfil] [int] NOT NULL,
	[titulo] [varchar](100) NULL,
	[descripcion] [varchar](100) NULL,
	[Vista] [varchar](50) NULL,
	[txFechaIngreso] [varchar](10) NULL,
	[Estado] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[idPerfil] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PerfilesUsuario]    Script Date: 27/5/2021 08:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PerfilesUsuario](
	[idperUsuario] [int] NOT NULL,
	[idUsuario] [int] NULL,
	[idPerfil] [int] NULL,
	[txFechaIngreso] [varchar](10) NULL,
	[txfechaActualizacion] [varchar](10) NULL,
	[Estado] [varchar](3) NULL,
PRIMARY KEY CLUSTERED 
(
	[idperUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 27/5/2021 08:52:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Usuario] [nvarchar](100) NULL,
	[Clave] [nvarchar](100) NULL,
	[txEmail] [nvarchar](max) NULL,
	[txFechaIngreso] [varchar](15) NULL,
	[Estado] [varchar](3) NULL,
 CONSTRAINT [PK__Usuario__2A50F1CE8ED86DF4] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Perfiles]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[Estados] ([idEstado])
GO
ALTER TABLE [dbo].[PerfilesUsuario]  WITH CHECK ADD FOREIGN KEY([Estado])
REFERENCES [dbo].[Estados] ([idEstado])
GO
ALTER TABLE [dbo].[PerfilesUsuario]  WITH CHECK ADD FOREIGN KEY([idPerfil])
REFERENCES [dbo].[Perfiles] ([idPerfil])
GO
ALTER TABLE [dbo].[PerfilesUsuario]  WITH CHECK ADD  CONSTRAINT [FK__PerfilesU__idUsu__182C9B23] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[PerfilesUsuario] CHECK CONSTRAINT [FK__PerfilesU__idUsu__182C9B23]
GO
