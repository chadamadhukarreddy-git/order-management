CREATE TABLE [dbo].[UserRole] (
    [UserRoleId]  BIGINT   IDENTITY (1, 1) NOT NULL,
    [UserId]      BIGINT   NULL,
    [RoleId]      INT      NULL,
    [IsActive]    BIT      CONSTRAINT [DF_UserRole_IsActive] DEFAULT ((1)) NOT NULL,
    [CreatedBy]   BIGINT   NULL,
    [CreatedDate] DATETIME CONSTRAINT [DF_UserRole_CreatedDate] DEFAULT (getdate()) NOT NULL,
    [UpdatedBy]   BIGINT   NULL,
    [UpdatedDate] DATETIME NULL,
    CONSTRAINT [PK_UserRole_UserRoleId] PRIMARY KEY CLUSTERED ([UserRoleId] ASC),
    CONSTRAINT [FK_UserRole_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([RoleId]),
    CONSTRAINT [FK_UserRole_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

