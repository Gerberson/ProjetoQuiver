CREATE DATABASE ProjetoQuiver; -- 1° Crie o banco primeiro.

USE [ProjetoQuiver] -- 2° Rode o script.
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 18/09/2020 21:52:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contato]    Script Date: 18/09/2020 21:52:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contato](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](15) NOT NULL,
	[Sobrenome] [nvarchar](15) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[CorretoraId] [int] NULL,
 CONSTRAINT [PK_Contato] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Corretora]    Script Date: 18/09/2020 21:52:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Corretora](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [nvarchar](15) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[Role] [nvarchar](max) NULL,
 CONSTRAINT [PK_Corretora] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Telefone]    Script Date: 18/09/2020 21:52:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Telefone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](15) NOT NULL,
	[ContatoId] [int] NULL,
 CONSTRAINT [PK_Telefone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200917174527_Initial', N'3.1.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200918140934_AddTabelaCorretora', N'3.1.8')
GO
SET IDENTITY_INSERT [dbo].[Contato] ON 

INSERT [dbo].[Contato] ([Id], [Nome], [Sobrenome], [Email], [CorretoraId]) VALUES (1, N'Luiz', N'Roberto', N'luiz@gmail.com', 1)
INSERT [dbo].[Contato] ([Id], [Nome], [Sobrenome], [Email], [CorretoraId]) VALUES (2, N'Maria', N'Santos', N'maria@gmail.com', 1)
INSERT [dbo].[Contato] ([Id], [Nome], [Sobrenome], [Email], [CorretoraId]) VALUES (3, N'Leonardo', N'Souza', N'leonardo@gmail.com', 2)
INSERT [dbo].[Contato] ([Id], [Nome], [Sobrenome], [Email], [CorretoraId]) VALUES (4, N'Pedro', N'Soares', N'pedro@gmail.com', 2)
INSERT [dbo].[Contato] ([Id], [Nome], [Sobrenome], [Email], [CorretoraId]) VALUES (5, N'Roberto', N'Cavalcante', N'roberto@gmail.com', 3)
INSERT [dbo].[Contato] ([Id], [Nome], [Sobrenome], [Email], [CorretoraId]) VALUES (6, N'Rafael', N'Dumon', N'rafael@gmail.com', 3)
SET IDENTITY_INSERT [dbo].[Contato] OFF
GO
SET IDENTITY_INSERT [dbo].[Corretora] ON 

INSERT [dbo].[Corretora] ([Id], [Nome], [Password], [Role]) VALUES (1, N'Porto Seguro', N'sdfert', N'funcionario')
INSERT [dbo].[Corretora] ([Id], [Nome], [Password], [Role]) VALUES (2, N'Caixa Seguros', N'errtyy', N'gerente')
INSERT [dbo].[Corretora] ([Id], [Nome], [Password], [Role]) VALUES (3, N'Quiver Seguro', N'wsderf', N'diretor')
SET IDENTITY_INSERT [dbo].[Corretora] OFF
GO
SET IDENTITY_INSERT [dbo].[Telefone] ON 

INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (1, N'(012)98888-7777', 1)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (2, N'(012)96666-5555', 1)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (3, N'(012)91111-8888', 2)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (4, N'(012)92222-6666', 2)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (5, N'(012)93333-5555', 3)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (6, N'(012)94444-4444', 3)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (7, N'(012)95555-3333', 4)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (8, N'(012)96666-2222', 4)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (9, N'(012)97777-1111', 5)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (10, N'(012)98888-9999', 5)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (11, N'(012)90000-1111', 6)
INSERT [dbo].[Telefone] ([Id], [Numero], [ContatoId]) VALUES (12, N'(012)97474-0101', 6)
SET IDENTITY_INSERT [dbo].[Telefone] OFF
GO
ALTER TABLE [dbo].[Contato]  WITH CHECK ADD  CONSTRAINT [FK_Contato_Corretora_CorretoraId] FOREIGN KEY([CorretoraId])
REFERENCES [dbo].[Corretora] ([Id])
GO
ALTER TABLE [dbo].[Contato] CHECK CONSTRAINT [FK_Contato_Corretora_CorretoraId]
GO
ALTER TABLE [dbo].[Telefone]  WITH CHECK ADD  CONSTRAINT [FK_Telefone_Contato_ContatoId] FOREIGN KEY([ContatoId])
REFERENCES [dbo].[Contato] ([Id])
GO
ALTER TABLE [dbo].[Telefone] CHECK CONSTRAINT [FK_Telefone_Contato_ContatoId]
GO
