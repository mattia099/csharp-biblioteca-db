CREATE TABLE [dbo].copies
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [book_id] INT NULL, 
    [condition_id] INT NULL, 
    [library_code] VARCHAR(50) NULL, 
    [publisher] DATE NULL, 
    [language] VARCHAR(50) NULL, 
    [isbn] VARCHAR(50) NULL, 
    [pages] INT NULL, 
    CONSTRAINT [FK_copies_books] FOREIGN KEY (book_id) REFERENCES [books]([id]), 
    CONSTRAINT [FK_copies_conditions] FOREIGN KEY ([condition_id]) REFERENCES [conditions]([id]) 
)
