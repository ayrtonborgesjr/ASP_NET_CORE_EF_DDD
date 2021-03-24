USE [Estoque]
GO

/****** Object:  Table [dbo].[VendaProdutos]    Script Date: 24/03/2021 02:13:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VendaProdutos](
	[CodigoVenda] [int] NOT NULL,
	[CodigoProduto] [int] NOT NULL,
	[Quantidade] [float] NOT NULL,
	[ValorUnitario] [decimal](9, 2) NOT NULL,
	[ValorTotal] [decimal](9, 2) NOT NULL,
 CONSTRAINT [PK_VendaProdutos] PRIMARY KEY CLUSTERED 
(
	[CodigoVenda] ASC,
	[CodigoProduto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[VendaProdutos]  WITH CHECK ADD  CONSTRAINT [FK_VendaProdutos_CodigoProduto] FOREIGN KEY([CodigoProduto])
REFERENCES [dbo].[Produto] ([Codigo])
GO

ALTER TABLE [dbo].[VendaProdutos] CHECK CONSTRAINT [FK_VendaProdutos_CodigoProduto]
GO

ALTER TABLE [dbo].[VendaProdutos]  WITH CHECK ADD  CONSTRAINT [FK_VendaProdutos_CodigoVenda] FOREIGN KEY([CodigoVenda])
REFERENCES [dbo].[Venda] ([Codigo])
GO

ALTER TABLE [dbo].[VendaProdutos] CHECK CONSTRAINT [FK_VendaProdutos_CodigoVenda]
GO


