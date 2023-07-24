CREATE TABLE [Client] 
(
	[Id] INT PRIMARY KEY IDENTITY(20230,1),
    [Name] NVARCHAR(250) NOT NULL,
    [Bi] NVARCHAR(50) NOT NULL,
    [Province] NVARCHAR(100) NOT NULL,
    [Address] NVARCHAR(200) NOT NULL,
    [BirthDate] DATE NOT NULL,
    [Genre] CHAR(1) NOT NULL,
    [Profession] NVARCHAR(100) NOT NULL,
    [Income] DECIMAL(18, 2) NOT NULL,
    [PhoneNumber] NVARCHAR(20) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL

	CONSTRAINT [UQ_Client_Email] UNIQUE ([Email]),
    CONSTRAINT [UQ_Client_Bi] UNIQUE ([Bi])
)