CREATE TABLE [dbo].[Pedido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Viagem] BIT NOT NULL, 
    [ProdutoId] INT NOT NULL, 
    [Observacoes] NVARCHAR(2000) NOT NULL, 
    [ContaId] INT NOT NULL, 
    [DataHora] DATETIME2 NOT NULL, 
    [UsuarioId] INT NOT NULL, 
    CONSTRAINT [FK_Pedido_ToProduto] FOREIGN KEY ([ProdutoId]) REFERENCES [Produto]([Id]), 
    CONSTRAINT [FK_Pedido_ToConta] FOREIGN KEY ([ContaId]) REFERENCES [Conta]([Id]), 
    CONSTRAINT [FK_Pedido_ToUsuario] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario]([Id])
)