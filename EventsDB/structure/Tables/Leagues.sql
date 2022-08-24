CREATE TABLE [structure].[Leagues] (
    [id]         INT            IDENTITY (1, 1) NOT NULL,
    [name]       NVARCHAR (200) NOT NULL,
    [sportID]    INT            NOT NULL,
    [promotesTo] INT            NULL,
    CONSTRAINT [PK_Leagues] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [FK_Leagues_Leagues] FOREIGN KEY ([promotesTo]) REFERENCES [structure].[Leagues] ([id]),
    CONSTRAINT [FK_Leagues_Sports] FOREIGN KEY ([sportID]) REFERENCES [structure].[Sports] ([id])
);

