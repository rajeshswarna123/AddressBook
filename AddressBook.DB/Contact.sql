CREATE TABLE [dbo].[Contact] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NOT NULL,
    [Email]    NVARCHAR (MAX) NOT NULL,
    [Mobile]   NVARCHAR (MAX) NOT NULL,
    [Landline] NVARCHAR (MAX) NULL,
    [Website]  NVARCHAR (MAX) NOT NULL,
    [Address]  NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.AddressBooks] PRIMARY KEY CLUSTERED ([Id] ASC)
);


