CREATE TABLE [dbo].[OrderDetail] (
    [OrderDetailId] BIGINT          IDENTITY (1, 1) NOT NULL,
    [OrderId]       BIGINT          NULL,
    [ProductId]     BIGINT          NULL,
    [Quantity]      DECIMAL (10, 2) NULL,
    [IsActive]      BIT             CONSTRAINT [DF_OrderDetail_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]     BIGINT          NULL,
    [CreatedDate]   DATETIME        CONSTRAINT [DF_OrderDetail_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]     BIGINT          NULL,
    [UpdatedDate]   DATETIME        NULL,
    CONSTRAINT [PK_OrderDetail_OrderDetailId] PRIMARY KEY CLUSTERED ([OrderDetailId] ASC),
    CONSTRAINT [FK_OrderDetail_OrderId] FOREIGN KEY ([OrderId]) REFERENCES [dbo].[Order] ([OrderId]),
    CONSTRAINT [FK_OrderDetail_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([ProductId])
);

