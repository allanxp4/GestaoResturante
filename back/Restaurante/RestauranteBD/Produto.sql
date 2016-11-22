CREATE TABLE [dbo].[Produto]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(255) NOT NULL, 
    [Valor] DECIMAL NOT NULL, 
    [Imposto] DECIMAL NULL, 
    [TipoId] INT NOT NULL, 
    CONSTRAINT [FK_Produto_ToTipo] FOREIGN KEY ([TipoId]) REFERENCES [TipoProduto]([Id])
)
