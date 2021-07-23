CREATE TABLE [dbo].[Drinks] (
    [DrinkId] INT            IDENTITY (1, 1) NOT NULL,
    [Name]    NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Drinks] PRIMARY KEY CLUSTERED ([DrinkId] ASC)
);

