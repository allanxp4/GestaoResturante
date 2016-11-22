CREATE TABLE [dbo].[Pagamento]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Valor] DECIMAL NOT NULL, 
    [TipoId] INT NOT NULL, 
    [ContaId] INT NOT NULL, 
    CONSTRAINT [FK_Pagamento_ToConta] FOREIGN KEY ([ContaId]) REFERENCES [Conta]([Id]), 
    CONSTRAINT [FK_Pagamento_ToTipo] FOREIGN KEY ([TipoId]) REFERENCES [TipoPagamento]([Id])
)
