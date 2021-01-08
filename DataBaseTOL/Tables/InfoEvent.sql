CREATE TABLE [dbo].[InfoEvent]
(
	[Id] INT NOT NULL identity, 
    [Date] DATETIME2 NOT NULL, 
    [IdSalle] INT NOT NULL, 
    [IdEvent] INT NOT NULL, 
    [PlaceRestante] INT NOT NULL, 
    [PrixPlace] INT NOT NULL, 
    CONSTRAINT [PK_InfoEvent] PRIMARY KEY ([Id]),
    constraint [fk_infoEvent_Salle] foreign key ([IdSalle]) references [Salles](Id), 
    CONSTRAINT [FK_InfoEvent_event] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id])
)
