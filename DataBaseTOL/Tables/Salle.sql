CREATE TABLE [dbo].[Salles]
(
    [Id] int not null primary key identity, 
    [NomSalle] NVARCHAR(MAX) NOT NULL, 
    [AdresseSalle] NVARCHAR(MAX) NOT NULL, 
    [Capacite] INT NOT NULL, 
    [ImageSalles] NVARCHAR(MAX) NULL, 
    [HistoireSalle] NVARCHAR(MAX) NULL,
)
