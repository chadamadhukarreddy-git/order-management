CREATE TABLE [dbo].[Role] (
    [RoleId]      INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]    VARCHAR (100) NOT NULL,
    [IsActive]    BIT           CONSTRAINT [DF_Role_IsActive] DEFAULT ((0)) NOT NULL,
    [CreatedBy]   BIGINT        NULL,
    [CreatedDate] DATETIME      CONSTRAINT [DF_Role_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]   BIGINT        NULL,
    [UpdatedDate] DATETIME      NULL,
    CONSTRAINT [PK_Role_RoleId] PRIMARY KEY CLUSTERED ([RoleId] ASC),
    CONSTRAINT [UK_Role_RoleName] UNIQUE NONCLUSTERED ([RoleName] ASC)
);

