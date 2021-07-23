CREATE TABLE [dbo].[Parties] (
    [PartyId]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [PartyName] NVARCHAR (MAX) NULL,
    [PartyDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_Parties] PRIMARY KEY CLUSTERED ([PartyId] ASC)
);

