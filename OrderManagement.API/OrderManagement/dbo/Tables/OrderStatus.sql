CREATE TABLE [dbo].[OrderStatus] (
    [OrderStatusId]   INT           IDENTITY (1, 1) NOT NULL,
    [OrderStatusName] VARCHAR (100) NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_OrderStatus_IsActive] DEFAULT ((0)) NOT NULL,
    [CreatedBy]       BIGINT        NULL,
    [CreatedDate]     DATETIME      CONSTRAINT [DF_OrderStatus_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]       BIGINT        NULL,
    [UpdatedDate]     DATETIME      NULL,
    CONSTRAINT [PK_OrderStatus_OrderStatusId] PRIMARY KEY CLUSTERED ([OrderStatusId] ASC),
    CONSTRAINT [UK_OrderStatus_OrderStatusName] UNIQUE NONCLUSTERED ([OrderStatusName] ASC)
);

