CREATE TABLE [dbo].[Event]
(
    [Id] int not null identity,
    [NomSpectacle] NVARCHAR(50) NOT NULL , 
    [Realisateur] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(MAX) NOT NULL, 
    [Duree] INT NOT NULL, 
    [Image] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [PK_Event] PRIMARY KEY ([Id]) 

)
