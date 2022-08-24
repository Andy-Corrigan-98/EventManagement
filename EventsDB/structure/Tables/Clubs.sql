CREATE TABLE [structure].[Clubs] (
    [id]            INT            IDENTITY (1, 1) NOT NULL,
    [name]          NVARCHAR (250) NOT NULL,
    [shortName]     NVARCHAR (3)   NOT NULL,
    [currentLeague] INT            NOT NULL,
    CONSTRAINT [PK_Clubs] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Clubs_Leagues] FOREIGN KEY ([currentLeague]) REFERENCES [structure].[Leagues] ([id])
);

