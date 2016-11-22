CREATE TABLE [dbo].[Usuario]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Nome] NVARCHAR(100) NOT NULL, 
    [Login] NVARCHAR(100) NOT NULL, 
    [Senha] NVARCHAR(100) NOT NULL, 
    [TipoId] INT NOT NULL, 
    CONSTRAINT [FK_Usuario_ToTipo] FOREIGN KEY ([TipoId]) REFERENCES [TipoUsuario]([Id])
)
