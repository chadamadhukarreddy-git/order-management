CREATE TABLE [dbo].[User] (
    [UserId]          BIGINT          IDENTITY (1, 1) NOT NULL,
    [UserName]        VARCHAR (100)   NOT NULL,
    [Password]        VARBINARY (MAX) NULL,
    [IsActive]        BIT             CONSTRAINT [DF_User_IsActive] DEFAULT ((0)) NOT NULL,
    [LoginAttempts]   INT             NULL,
    [IsAccountLocked] BIT             CONSTRAINT [DF_User_IsAccountLocked] DEFAULT ((0)) NOT NULL,
    [CreatedBy]       BIGINT          NULL,
    [CreatedDate]     DATETIME        CONSTRAINT [DF_User_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]       BIGINT          NULL,
    [UpdatedDate]     DATETIME        NULL,
    CONSTRAINT [PK_User_UserId] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [UK_User_UserName] UNIQUE NONCLUSTERED ([UserName] ASC)
);

