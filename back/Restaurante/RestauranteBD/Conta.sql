CREATE TABLE [dbo].[Conta]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MesaId] INT NOT NULL, 
    [Desconto] DECIMAL NOT NULL, 
    [Pago] BIT NOT NULL, 
    [DataHoraPagamento] DATETIME2 NULL, 
    [UsuarioId] INT NOT NULL, 
    CONSTRAINT [FK_Conta_ToMesa] FOREIGN KEY ([MesaId]) REFERENCES [Mesa]([Id]), 
    CONSTRAINT [FK_Conta_ToUsuario] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario]([Id])
)
