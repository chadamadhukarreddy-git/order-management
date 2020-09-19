CREATE TABLE [dbo].[Product] (
    [ProductId]         BIGINT          IDENTITY (1, 1) NOT NULL,
    [ProductName]       VARCHAR (100)   NOT NULL,
    [Height]            DECIMAL (10, 2) NULL,
    [Weight]            DECIMAL (10, 2) NULL,
    [StockKeepingUnit]  DECIMAL (10, 2) NULL,
    [AvailableQuantity] DECIMAL (10, 2) NULL,
    [BarCode]           VARCHAR (150)   NULL,
    [IsActive]          BIT             CONSTRAINT [DF_Product_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]         BIGINT          NULL,
    [CreatedDate]       DATETIME        CONSTRAINT [DF_Product_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]         BIGINT          NULL,
    [UpdatedDate]       DATETIME        NULL,
    CONSTRAINT [PK_Product_ProductId] PRIMARY KEY CLUSTERED ([ProductId] ASC),
    CONSTRAINT [UK_Product_ProductName] UNIQUE NONCLUSTERED ([ProductName] ASC)
);

