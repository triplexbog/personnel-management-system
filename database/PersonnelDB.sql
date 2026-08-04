/*
    PersonnelDB — схема базы данных и безопасные справочные данные.

    Скрипт подготовлен из BACPAC-дампа. Персональные профили, учётные записи,
    хеши паролей, документы, достижения и история статусов намеренно исключены.

    Требования: Microsoft SQL Server 2019 или новее.
*/

SET NOCOUNT ON;
SET XACT_ABORT ON;

IF DB_ID(N'PersonnelDB') IS NOT NULL
BEGIN
    THROW 50001, N'База PersonnelDB уже существует. Скрипт остановлен без изменений.', 1;
END;
GO

CREATE DATABASE [PersonnelDB];
GO

USE [PersonnelDB];
GO

SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE dbo.Roles
(
    RoleId   INT IDENTITY(1, 1) NOT NULL,
    RoleName NVARCHAR(50) NOT NULL,
    CONSTRAINT PK_Roles PRIMARY KEY CLUSTERED (RoleId),
    CONSTRAINT UQ_Roles_RoleName UNIQUE (RoleName)
);
GO

CREATE TABLE dbo.Users
(
    UserId       INT IDENTITY(1, 1) NOT NULL,
    Login        NVARCHAR(100) NOT NULL,
    PasswordHash VARBINARY(256) NOT NULL,
    RoleId       INT NOT NULL,
    IsActive     BIT NOT NULL CONSTRAINT DF_Users_IsActive DEFAULT (1),
    CreatedAt    DATETIME2(7) NOT NULL CONSTRAINT DF_Users_CreatedAt DEFAULT (GETDATE()),
    CONSTRAINT PK_Users PRIMARY KEY CLUSTERED (UserId),
    CONSTRAINT UQ_Users_Login UNIQUE (Login),
    CONSTRAINT FK_Users_Roles FOREIGN KEY (RoleId) REFERENCES dbo.Roles (RoleId)
);
GO

CREATE TABLE dbo.Profiles
(
    ProfileId       INT IDENTITY(1, 1) NOT NULL,
    UserId          INT NULL,
    FirstName       NVARCHAR(100) NOT NULL,
    LastName        NVARCHAR(100) NOT NULL,
    MiddleName      NVARCHAR(100) NULL,
    BirthDate       DATE NULL,
    Gender          CHAR(1) NULL,
    Phone           NVARCHAR(20) NULL,
    Email           NVARCHAR(100) NULL,
    Address         NVARCHAR(250) NULL,
    PassportData    NVARCHAR(100) NULL,
    SNILS           NVARCHAR(20) NULL,
    INN             NVARCHAR(20) NULL,
    ProfileType     TINYINT NOT NULL,
    HireDate        DATE NULL,
    TerminationDate DATE NULL,
    IsActive        BIT NOT NULL CONSTRAINT DF_Profiles_IsActive DEFAULT (1),
    CONSTRAINT PK_Profiles PRIMARY KEY CLUSTERED (ProfileId),
    CONSTRAINT FK_Profiles_Users FOREIGN KEY (UserId) REFERENCES dbo.Users (UserId)
);
GO

CREATE TABLE dbo.ProfileStatusHistory
(
    HistoryId INT IDENTITY(1, 1) NOT NULL,
    ProfileId INT NOT NULL,
    Status    NVARCHAR(50) NOT NULL,
    ChangedBy INT NOT NULL,
    ChangedAt DATETIME2(7) NOT NULL CONSTRAINT DF_ProfileStatusHistory_ChangedAt DEFAULT (GETDATE()),
    CONSTRAINT PK_ProfileStatusHistory PRIMARY KEY CLUSTERED (HistoryId),
    CONSTRAINT FK_StatusHistory_Profile FOREIGN KEY (ProfileId) REFERENCES dbo.Profiles (ProfileId),
    CONSTRAINT FK_StatusHistory_User FOREIGN KEY (ChangedBy) REFERENCES dbo.Users (UserId)
);
GO

CREATE TABLE dbo.MenuItems
(
    MenuId    INT IDENTITY(1, 1) NOT NULL,
    ParentId  INT NULL,
    Title     NVARCHAR(100) NOT NULL,
    FormName  NVARCHAR(100) NOT NULL,
    SortOrder INT NOT NULL CONSTRAINT DF_MenuItems_SortOrder DEFAULT (0),
    CONSTRAINT PK_MenuItems PRIMARY KEY CLUSTERED (MenuId),
    CONSTRAINT FK_Menu_Parent FOREIGN KEY (ParentId) REFERENCES dbo.MenuItems (MenuId)
);
GO

CREATE TABLE dbo.RoleMenuPermissions
(
    RoleId INT NOT NULL,
    MenuId INT NOT NULL,
    CanView BIT NOT NULL CONSTRAINT DF_RoleMenuPermissions_CanView DEFAULT (1),
    CanEdit BIT NOT NULL CONSTRAINT DF_RoleMenuPermissions_CanEdit DEFAULT (0),
    CONSTRAINT PK_RoleMenuPermissions PRIMARY KEY CLUSTERED (RoleId, MenuId),
    CONSTRAINT FK_RoleMenu_Role FOREIGN KEY (RoleId) REFERENCES dbo.Roles (RoleId),
    CONSTRAINT FK_RoleMenu_Menu FOREIGN KEY (MenuId) REFERENCES dbo.MenuItems (MenuId)
);
GO

CREATE TABLE dbo.DocumentFolders
(
    FolderId INT IDENTITY(1, 1) NOT NULL,
    ParentId INT NULL,
    Name     NVARCHAR(100) NOT NULL,
    CONSTRAINT PK_DocumentFolders PRIMARY KEY CLUSTERED (FolderId),
    CONSTRAINT FK_Folders_Parent FOREIGN KEY (ParentId) REFERENCES dbo.DocumentFolders (FolderId)
);
GO

CREATE TABLE dbo.Documents
(
    DocumentId  INT IDENTITY(1, 1) NOT NULL,
    FolderId    INT NOT NULL,
    ProfileId   INT NULL,
    Title       NVARCHAR(250) NOT NULL,
    Description NVARCHAR(500) NULL,
    CreatedBy   INT NOT NULL,
    CreatedAt   DATETIME2(7) NOT NULL CONSTRAINT DF_Documents_CreatedAt DEFAULT (GETDATE()),
    CONSTRAINT PK_Documents PRIMARY KEY CLUSTERED (DocumentId),
    CONSTRAINT FK_Documents_Folder FOREIGN KEY (FolderId) REFERENCES dbo.DocumentFolders (FolderId),
    CONSTRAINT FK_Documents_Profile FOREIGN KEY (ProfileId) REFERENCES dbo.Profiles (ProfileId),
    CONSTRAINT FK_Documents_User FOREIGN KEY (CreatedBy) REFERENCES dbo.Users (UserId)
);
GO

CREATE TABLE dbo.DocumentVersions
(
    VersionId     INT IDENTITY(1, 1) NOT NULL,
    DocumentId    INT NOT NULL,
    FileName      NVARCHAR(250) NOT NULL,
    FilePath      NVARCHAR(500) NOT NULL,
    VersionNumber INT NOT NULL,
    UploadedBy    INT NOT NULL,
    UploadedAt    DATETIME2(7) NOT NULL CONSTRAINT DF_DocumentVersions_UploadedAt DEFAULT (GETDATE()),
    CONSTRAINT PK_DocumentVersions PRIMARY KEY CLUSTERED (VersionId),
    CONSTRAINT UQ_Document_Version UNIQUE (DocumentId, VersionNumber),
    CONSTRAINT FK_Versions_Document FOREIGN KEY (DocumentId) REFERENCES dbo.Documents (DocumentId),
    CONSTRAINT FK_Versions_User FOREIGN KEY (UploadedBy) REFERENCES dbo.Users (UserId)
);
GO

CREATE TABLE dbo.Achievements
(
    AchievementId INT IDENTITY(1, 1) NOT NULL,
    ProfileId     INT NOT NULL,
    Title         NVARCHAR(250) NOT NULL,
    Level         NVARCHAR(50) NOT NULL,
    EventDate     DATE NOT NULL,
    Result        NVARCHAR(100) NULL,
    CreatedBy     INT NOT NULL,
    CreatedAt     DATETIME2(7) NOT NULL CONSTRAINT DF_Achievements_CreatedAt DEFAULT (GETDATE()),
    CONSTRAINT PK_Achievements PRIMARY KEY CLUSTERED (AchievementId),
    CONSTRAINT FK_Achievements_Profile FOREIGN KEY (ProfileId) REFERENCES dbo.Profiles (ProfileId),
    CONSTRAINT FK_Achievements_User FOREIGN KEY (CreatedBy) REFERENCES dbo.Users (UserId)
);
GO

CREATE TABLE dbo.AchievementDocs
(
    DocId         INT IDENTITY(1, 1) NOT NULL,
    AchievementId INT NOT NULL,
    FileName      NVARCHAR(250) NOT NULL,
    FilePath      NVARCHAR(500) NOT NULL,
    UploadedBy    INT NOT NULL,
    UploadedAt    DATETIME2(7) NOT NULL CONSTRAINT DF_AchievementDocs_UploadedAt DEFAULT (GETDATE()),
    CONSTRAINT PK_AchievementDocs PRIMARY KEY CLUSTERED (DocId),
    CONSTRAINT FK_AchievementDocs_Achievement FOREIGN KEY (AchievementId) REFERENCES dbo.Achievements (AchievementId),
    CONSTRAINT FK_AchievementDocs_User FOREIGN KEY (UploadedBy) REFERENCES dbo.Users (UserId)
);
GO

BEGIN TRANSACTION;

SET IDENTITY_INSERT dbo.Roles ON;
INSERT INTO dbo.Roles (RoleId, RoleName)
VALUES
    (1, N'Администратор'),
    (2, N'Кадры'),
    (3, N'Педагог'),
    (4, N'Ученик');
SET IDENTITY_INSERT dbo.Roles OFF;

SET IDENTITY_INSERT dbo.MenuItems ON;
INSERT INTO dbo.MenuItems (MenuId, ParentId, Title, FormName, SortOrder)
VALUES
    (1, NULL, N'Пользователи', N'UserForm', 1),
    (2, NULL, N'Профили', N'ProfileForm', 2),
    (3, NULL, N'Документы', N'DocumentForm', 3);
SET IDENTITY_INSERT dbo.MenuItems OFF;

INSERT INTO dbo.RoleMenuPermissions (RoleId, MenuId, CanView, CanEdit)
VALUES
    (1, 1, 1, 1),
    (2, 2, 1, 1),
    (3, 3, 1, 1),
    (4, 3, 1, 0);

SET IDENTITY_INSERT dbo.DocumentFolders ON;
INSERT INTO dbo.DocumentFolders (FolderId, ParentId, Name)
VALUES
    (1, NULL, N'Личное дело'),
    (2, NULL, N'Документы сотрудников'),
    (3, 1, N'Паспортные данные');
SET IDENTITY_INSERT dbo.DocumentFolders OFF;

COMMIT TRANSACTION;
GO

PRINT N'База PersonnelDB создана. Персональные и пользовательские данные не добавлялись.';
GO
