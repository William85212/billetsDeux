CREATE TABLE [dbo].[Reservation]
(
	[Id] INT NOT NULL PRIMARY KEY identity, 
    [DateReservation] DATETIME2 NOT NULL, 
    [ NbrPlace] NCHAR(10) NOT NULL, 
    [IdClient] INT NOT NULL, 
    [IdEvent] INT NOT NULL, 
    [prix] NCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Reservation_Client] FOREIGN KEY ([IdClient]) REFERENCES [Client]([Id]), 
    CONSTRAINT [FK_Reservation_Event] FOREIGN KEY ([IdEvent]) REFERENCES [Event]([Id])
)
