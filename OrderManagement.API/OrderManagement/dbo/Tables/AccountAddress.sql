CREATE TABLE [dbo].[AccountAddress] (
    [AccountAddressId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [AccountId]        BIGINT   NULL,
    [IsActive]         BIT      CONSTRAINT [DF_AccountAddress_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]        BIGINT   NULL,
    [CreatedDate]      DATETIME CONSTRAINT [DF_AccountAddress_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]        BIGINT   NULL,
    [UpdatedDate]      DATETIME NULL,
    CONSTRAINT [PK_AccountAddress_AccountAddressId] PRIMARY KEY CLUSTERED ([AccountAddressId] ASC),
    CONSTRAINT [FK_AccountAddress_AccountId] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([AccountId])
);

