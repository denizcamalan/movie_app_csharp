CREATE TABLE [dbo].[Users] (
    [user_id]       INT           IDENTITY (1, 1) NOT NULL,
    [user_name]     VARCHAR (200) NOT NULL,
    [user_password] VARCHAR (200) NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);


GO

