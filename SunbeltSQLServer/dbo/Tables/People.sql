CREATE TABLE [dbo].[People] (
    [PersonId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [PartyId]  BIGINT         NULL,
    CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED ([PersonId] ASC),
    CONSTRAINT [FK_People_Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([PartyId])
);


GO
CREATE NONCLUSTERED INDEX [IX_People_PartyId]
    ON [dbo].[People]([PartyId] ASC);

