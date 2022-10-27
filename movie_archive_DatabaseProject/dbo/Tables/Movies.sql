CREATE TABLE [dbo].[Movies] (
    [movie_id]          INT           IDENTITY (1, 1) NOT NULL,
    [movie_name]        VARCHAR (50)  NOT NULL,
    [movie_description] VARCHAR (200) DEFAULT (NULL) NULL,
    [movie_type]        VARCHAR (200) DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([movie_id] ASC),
    UNIQUE NONCLUSTERED ([movie_name] ASC),
    UNIQUE NONCLUSTERED ([movie_name] ASC)
);


GO

