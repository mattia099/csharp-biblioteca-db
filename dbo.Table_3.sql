CREATE TABLE [dbo].books_genres
(
    [book_id] INT NULL, 
    [genres_id] INT NULL, 
    CONSTRAINT [FK_books_id] FOREIGN KEY ([book_id]) REFERENCES [books]([id]), 
    CONSTRAINT [FK_genres_id] FOREIGN KEY ([genres_id]) REFERENCES [genres]([id])
)
