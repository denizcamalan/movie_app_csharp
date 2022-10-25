CREATE TABLE [dbo].[Movies] (
    [movie_id]          INT           NOT NULL,
    [movie_name]        VARCHAR (50)  NOT NULL,
    [movie_description] VARCHAR (200) DEFAULT (NULL) NULL,
    [movie_idquantity]  VARCHAR (200) DEFAULT (NULL) NULL,
    PRIMARY KEY CLUSTERED ([movie_id] ASC)
);


GO

