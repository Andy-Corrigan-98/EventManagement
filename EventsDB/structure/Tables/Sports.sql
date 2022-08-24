CREATE TABLE [structure].[Sports] (
    [id]   INT            IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Sports] PRIMARY KEY CLUSTERED ([id] ASC)
);

