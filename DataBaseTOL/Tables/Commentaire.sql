CREATE TABLE [dbo].[Commentaire]
(
	[Id] INT NOT NULL identity, 
    [Commentaire ] NVARCHAR(MAX) NULL, 
    [Jaime] INT NULL, 
    [JaimePas] INT NULL, 
    [IdClient] INT NOT NULL, 
    [IdEvent] INT NOT NULL, 
    CONSTRAINT [PK_Commentaire] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_Commentaire_Event] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id]), 
    CONSTRAINT [FK_Commentaire_Client] FOREIGN KEY ([IdClient]) REFERENCES [Client]([Id]) 
)
