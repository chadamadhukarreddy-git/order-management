CREATE TABLE [dbo].[Account] (
    [AccountId]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [UserId]          BIGINT        NULL,
    [FirstName]       VARCHAR (100) NOT NULL,
    [LastName]        VARCHAR (100) NULL,
    [Email]           VARCHAR (100) NULL,
    [Mobile]          VARCHAR (16)  NOT NULL,
    [AlternateMobile] VARCHAR (16)  NULL,
    [IsActive]        BIT           CONSTRAINT [DF_Account_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]       BIGINT        NULL,
    [CreatedDate]     DATETIME      CONSTRAINT [DF_Account_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]       BIGINT        NULL,
    [UpdatedDate]     DATETIME      NULL,
    CONSTRAINT [PK_Account_AccountId] PRIMARY KEY CLUSTERED ([AccountId] ASC),
    CONSTRAINT [FK_Account_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

