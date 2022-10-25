-- Create a new database called '
-- Connect to the 'master' database to run this snippet
USE movie_archice;

IF OBJECT_ID('Users', 'U') IS NOT NULL
DROP TABLE Users
GO
-- Create the table in the specified schema
CREATE TABLE Users
(
    user_id INT  NOT NULL IDENTITY(1,1) PRIMARY KEY,
    user_name varchar(200) NOT NULL,
    user_password varchar(200) NOT NULL,
    -- specify more columns here
);
GO

-- Create a new table called 'Movies' in schema '
-- Drop the table if it already exists
IF OBJECT_ID('Movies', 'U') IS NOT NULL
DROP TABLE Movies
GO
-- Create the table in the specified schema
CREATE TABLE Movies
(
    movie_id INT NOT NULL PRIMARY KEY, -- primary key column
    movie_name varchar(50) NOT NULL,
    movie_description varchar(200) DEFAULT NULL,
    movie_idquantity varchar(200) DEFAULT NULL,
    -- specify more columns here
);
GO
