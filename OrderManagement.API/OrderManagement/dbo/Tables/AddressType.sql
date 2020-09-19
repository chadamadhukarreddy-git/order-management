CREATE TABLE [dbo].[AddressType] (
    [AddressTypeId]   INT           IDENTITY (1, 1) NOT NULL,
    [AddressTypeName] VARCHAR (100) NOT NULL,
    [IsActive]        BIT           CONSTRAINT [DF_AddressType_IsActive] DEFAULT ((0)) NOT NULL,
    [CreatedBy]       BIGINT        NULL,
    [CreatedDate]     DATETIME      CONSTRAINT [DF_AddressType_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]       BIGINT        NULL,
    [UpdatedDate]     DATETIME      NULL,
    CONSTRAINT [PK_AddressType_AddressTypeId] PRIMARY KEY CLUSTERED ([AddressTypeId] ASC),
    CONSTRAINT [UK_AddressType_AddressTypeName] UNIQUE NONCLUSTERED ([AddressTypeName] ASC)
);

