USE [Estoque]
GO

/****** Object:  Table [dbo].[Venda]    Script Date: 24/03/2021 02:12:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Venda](
	[Codigo] [int] IDENTITY(1,1) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Total] [decimal](9, 2) NOT NULL,
	[CodigoCliente] [int] NOT NULL,
 CONSTRAINT [PK_Venda] PRIMARY KEY CLUSTERED 
(
	[Codigo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Venda]  WITH CHECK ADD  CONSTRAINT [FK_CodigoCliente_Cliente] FOREIGN KEY([CodigoCliente])
REFERENCES [dbo].[Cliente] ([Codigo])
GO

ALTER TABLE [dbo].[Venda] CHECK CONSTRAINT [FK_CodigoCliente_Cliente]
GO


