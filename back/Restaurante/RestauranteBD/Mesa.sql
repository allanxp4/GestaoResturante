CREATE TABLE [dbo].[Mesa]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Capacidade] INT NOT NULL, 
    [Ocupada] BIT NOT NULL, 
    [AmbienteId] INT NOT NULL, 
    [ContaId] INT NOT NULL, 
    CONSTRAINT [FK_Mesa_ToAmbiente] FOREIGN KEY ([AmbienteId]) REFERENCES [Ambiente]([Id]), 
    CONSTRAINT [FK_Mesa_ToConta] FOREIGN KEY ([ContaId]) REFERENCES [Conta]([Id])
)
