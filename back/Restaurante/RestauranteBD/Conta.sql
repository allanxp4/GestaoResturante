CREATE TABLE [dbo].[Conta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
    [Desconto] DECIMAL NOT NULL, 
    [Pago] BIT NOT NULL DEFAULT 0, 
    [DataHoraPagamento] DATETIME2 NULL, 
    [UsuarioId] INT NOT NULL, 
    [MesaId] INT NOT NULL, 
    [Fechada] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_Conta_ToUsuario] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario]([Id]), 
    CONSTRAINT [FK_Conta_ToMesa] FOREIGN KEY ([MesaId]) REFERENCES [Mesa]([Id])
)
