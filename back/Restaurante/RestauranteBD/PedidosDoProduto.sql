CREATE TABLE [dbo].[PedidosDoProduto]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProdutoId] INT NOT NULL, 
    [PedidoId] INT NOT NULL, 
    [Quantidade] INT NOT NULL, 
    [Observacoes] NVARCHAR(2000) NOT NULL, 
    [Valor] DECIMAL NOT NULL, 
    CONSTRAINT [FK_PedidoProduto_ToProduto] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto]([Id]), 
    CONSTRAINT [FK_PedidoProduto_ToPedido] FOREIGN KEY ([PedidoId]) REFERENCES [Pedido]([Id])
)
