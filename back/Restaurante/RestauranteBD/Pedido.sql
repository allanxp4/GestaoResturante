CREATE TABLE [dbo].[Pedido]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Viagem] BIT NOT NULL,
    [ContaId] INT NOT NULL, 
    [DataHora] DATETIME2 NOT NULL DEFAULT getdate(), 
    [UsuarioId] INT NULL, 
    [Entregue] BIT NOT NULL DEFAULT 0, 
    [Cancelado] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Pedido_ToConta] FOREIGN KEY ([ContaId]) REFERENCES [Conta]([Id]), 
    CONSTRAINT [FK_Pedido_ToUsuario] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario]([Id])
)