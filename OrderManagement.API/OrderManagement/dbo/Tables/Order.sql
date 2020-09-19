CREATE TABLE [dbo].[Order] (
    [OrderId]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [OrderNumber]   VARCHAR (100)  NOT NULL,
    [Description]   VARCHAR (2000) NULL,
    [AccountId]     BIGINT         NULL,
    [BillTo]        BIGINT         NULL,
    [ShipTo]        BIGINT         NULL,
    [OrderStatusId] INT            NULL,
    [IsActive]      BIT            CONSTRAINT [DF_Order_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]     BIGINT         NULL,
    [CreatedDate]   DATETIME       CONSTRAINT [DF_Order_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]     BIGINT         NULL,
    [UpdatedDate]   DATETIME       NULL,
    CONSTRAINT [PK_Order_OrderId] PRIMARY KEY CLUSTERED ([OrderId] ASC),
    CONSTRAINT [FK_Order_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId]),
    CONSTRAINT [FK_Order_BillTo] FOREIGN KEY ([BillTo]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [FK_Order_OrderStatusId] FOREIGN KEY ([OrderStatusId]) REFERENCES [dbo].[OrderStatus] ([OrderStatusId]),
    CONSTRAINT [FK_Order_ShipTo] FOREIGN KEY ([ShipTo]) REFERENCES [dbo].[Address] ([AddressId]),
    CONSTRAINT [UK_Order_OrderNumber] UNIQUE NONCLUSTERED ([OrderNumber] ASC)
);

