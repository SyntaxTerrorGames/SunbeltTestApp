CREATE TABLE [dbo].[PartyAttendees] (
    [PartyAttendeeId] BIGINT IDENTITY (1, 1) NOT NULL,
    [PartyId]         BIGINT NOT NULL,
    [DrinkId]         INT    NOT NULL,
    [PersonId]        BIGINT DEFAULT (CONVERT([bigint],(0))) NOT NULL,
    CONSTRAINT [PK_PartyAttendees] PRIMARY KEY CLUSTERED ([PartyAttendeeId] ASC),
    CONSTRAINT [FK_PartyAttendees_Drinks_DrinkId] FOREIGN KEY ([DrinkId]) REFERENCES [dbo].[Drinks] ([DrinkId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PartyAttendees_Parties_PartyId] FOREIGN KEY ([PartyId]) REFERENCES [dbo].[Parties] ([PartyId]) ON DELETE CASCADE,
    CONSTRAINT [FK_PartyAttendees_People_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [dbo].[People] ([PersonId]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_PartyAttendees_DrinkId]
    ON [dbo].[PartyAttendees]([DrinkId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PartyAttendees_PartyId]
    ON [dbo].[PartyAttendees]([PartyId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_PartyAttendees_PersonId]
    ON [dbo].[PartyAttendees]([PersonId] ASC);

