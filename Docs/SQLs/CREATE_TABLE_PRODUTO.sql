USE [Estoque]
GO

/****** Object:  Table [dbo].[Produto]    Script Date: 24/03/2021 02:11:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Produto](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](50) NOT NULL,
	[Quantidade] [float] NOT NULL,
	[Valor] [decimal](9, 2) NOT NULL,
	[CodigoCategoria] [int] NOT NULL,
 CONSTRAINT [PK_Produto] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Produto]  WITH CHECK ADD  CONSTRAINT [FK_CodigoCategoria_Produto] FOREIGN KEY([CodigoCategoria])
REFERENCES [dbo].[Categoria] ([Codigo])
GO

ALTER TABLE [dbo].[Produto] CHECK CONSTRAINT [FK_CodigoCategoria_Produto]
GO


