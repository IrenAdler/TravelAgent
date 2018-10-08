CREATE TABLE [dbo].[Travels] (
    [TravelId]  INT           NOT NULL,
    [Country]   VARCHAR (MAX) NOT NULL,
    [City]      VARCHAR (MAX) NOT NULL,
    [Hotel]     VARCHAR (MAX) NOT NULL,
    [Price]     INT           NOT NULL,
    [PurchesId] INT           NULL,
    PRIMARY KEY CLUSTERED ([TravelId] ASC),
    CONSTRAINT [FK_Travels_ToPurcheses] FOREIGN KEY ([PurchesId]) REFERENCES [dbo].[Purcheses] ([PurchesId])
);

