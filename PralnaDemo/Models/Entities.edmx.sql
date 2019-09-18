
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/24/2016 14:20:49
-- Generated from EDMX file: E:\inetpub\wwwroot\Pralna\Source\PralnaDemo\Models\Entities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Pralna];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoleAspNetRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoleAspNetRole];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoleAspNetUser1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoleAspNetUser1];
GO
IF OBJECT_ID(N'[dbo].[FK_Photo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUsers] DROP CONSTRAINT [FK_Photo];
GO
IF OBJECT_ID(N'[dbo].[FK_PublicFilePublicVideo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PublicFiles] DROP CONSTRAINT [FK_PublicFilePublicVideo];
GO
IF OBJECT_ID(N'[dbo].[FK_OrganizationCity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Organizations] DROP CONSTRAINT [FK_OrganizationCity];
GO
IF OBJECT_ID(N'[dbo].[FK_DivisionDivision]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Divisions] DROP CONSTRAINT [FK_DivisionDivision];
GO
IF OBJECT_ID(N'[dbo].[FK_DivisionOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Divisions] DROP CONSTRAINT [FK_DivisionOrganization];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkPlaceDivision]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[WorkPlaces] DROP CONSTRAINT [FK_WorkPlaceDivision];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkerWorkPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Workers] DROP CONSTRAINT [FK_WorkerWorkPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_WorkerAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Workers] DROP CONSTRAINT [FK_WorkerAspNetUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceTypeWorkPlace]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceTypes] DROP CONSTRAINT [FK_ServiceTypeWorkPlace];
GO
IF OBJECT_ID(N'[dbo].[FK_ProvidedServiceWorker]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceToClients] DROP CONSTRAINT [FK_ProvidedServiceWorker];
GO
IF OBJECT_ID(N'[dbo].[FK_ProvidedServiceServiceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceToClients] DROP CONSTRAINT [FK_ProvidedServiceServiceType];
GO
IF OBJECT_ID(N'[dbo].[FK_ViolationTypeOrganization]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ViolationTypes] DROP CONSTRAINT [FK_ViolationTypeOrganization];
GO
IF OBJECT_ID(N'[dbo].[FK_AllowedViolationServiceType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AllowedViolations] DROP CONSTRAINT [FK_AllowedViolationServiceType];
GO
IF OBJECT_ID(N'[dbo].[FK_AllowedViolationViolationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AllowedViolations] DROP CONSTRAINT [FK_AllowedViolationViolationType];
GO
IF OBJECT_ID(N'[dbo].[FK_FoundViolationProvidedService]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoundViolations] DROP CONSTRAINT [FK_FoundViolationProvidedService];
GO
IF OBJECT_ID(N'[dbo].[FK_FoundViolationViolationType]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FoundViolations] DROP CONSTRAINT [FK_FoundViolationViolationType];
GO
IF OBJECT_ID(N'[dbo].[FK_ServiceToClientAspNetUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ServiceToClients] DROP CONSTRAINT [FK_ServiceToClientAspNetUser];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Cities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Cities];
GO
IF OBJECT_ID(N'[dbo].[PublicFiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PublicFiles];
GO
IF OBJECT_ID(N'[dbo].[PublicImages]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PublicImages];
GO
IF OBJECT_ID(N'[dbo].[PublicVideos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PublicVideos];
GO
IF OBJECT_ID(N'[dbo].[Organizations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organizations];
GO
IF OBJECT_ID(N'[dbo].[Divisions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Divisions];
GO
IF OBJECT_ID(N'[dbo].[WorkPlaces]', 'U') IS NOT NULL
    DROP TABLE [dbo].[WorkPlaces];
GO
IF OBJECT_ID(N'[dbo].[Workers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Workers];
GO
IF OBJECT_ID(N'[dbo].[ServiceTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceTypes];
GO
IF OBJECT_ID(N'[dbo].[ServiceToClients]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ServiceToClients];
GO
IF OBJECT_ID(N'[dbo].[ViolationTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ViolationTypes];
GO
IF OBJECT_ID(N'[dbo].[AllowedViolations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AllowedViolations];
GO
IF OBJECT_ID(N'[dbo].[FoundViolations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FoundViolations];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [RussianName] nvarchar(max)  NULL,
    [IdAsInt] int  NULL,
    [IsNotForUsers] bit  NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [UserId] nvarchar(128)  NOT NULL,
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RoleId] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [Name] nvarchar(max)  NULL,
    [PhotoId] bigint  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [Skype] nvarchar(max)  NULL,
    [Viber] nvarchar(max)  NULL,
    [Website] nvarchar(max)  NULL,
    [About] nvarchar(max)  NULL,
    [FacebookProfile] nvarchar(max)  NULL,
    [VkontakteProfile] nvarchar(max)  NULL,
    [RequiresModeration] bit  NULL,
    [Email] nvarchar(max)  NULL,
    [EmailConfirmed] bit  NULL,
    [PhoneNumberConfirmed] bit  NULL,
    [TwoFactorEnabled] bit  NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NULL,
    [AccessFailedCount] int  NULL,
    [IsDeleted] bit  NULL,
    [UserId] nvarchar(max)  NULL,
    [TaxNumber] nvarchar(max)  NOT NULL,
    [Index] int  NULL,
    [Photo] nvarchar(max)  NULL,
    [Discriminator] nvarchar(max)  NULL
);
GO

-- Creating table 'Cities'
CREATE TABLE [dbo].[Cities] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PublicFiles'
CREATE TABLE [dbo].[PublicFiles] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [OriginalName] nvarchar(max)  NOT NULL,
    [LocalFolder] nvarchar(max)  NOT NULL,
    [FolderForDownload] nvarchar(max)  NOT NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [Size] bigint  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [ParentId] nvarchar(50)  NULL,
    [ResourceType] smallint  NULL,
    [Index] int  NULL,
    [PublicVideoId] int  NULL,
    [VideoConvertInProgress] bit  NULL
);
GO

-- Creating table 'PublicImages'
CREATE TABLE [dbo].[PublicImages] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(max)  NOT NULL,
    [OriginalFile] nvarchar(max)  NOT NULL,
    [BigFile] nvarchar(max)  NOT NULL,
    [MediumFile] nvarchar(max)  NOT NULL,
    [SmallFile] nvarchar(max)  NOT NULL,
    [IconFile] nvarchar(max)  NOT NULL,
    [IdControl] nvarchar(max)  NULL,
    [LocalFolder] nvarchar(max)  NOT NULL,
    [FolderForDownload] nvarchar(max)  NOT NULL,
    [ParentId] nvarchar(50)  NULL,
    [Description] nvarchar(max)  NULL,
    [ResourceType] smallint  NULL,
    [Index] int  NULL
);
GO

-- Creating table 'PublicVideos'
CREATE TABLE [dbo].[PublicVideos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [LocalFolder] nvarchar(max)  NOT NULL,
    [FolderForDownload] nvarchar(max)  NOT NULL,
    [ParentId] nvarchar(max)  NULL,
    [Description] nvarchar(max)  NULL,
    [Index] int  NULL,
    [ResourceType] smallint  NULL,
    [MpgName] nvarchar(max)  NULL,
    [AviName] nvarchar(max)  NULL,
    [ArchiveName] nvarchar(max)  NULL,
    [Mp4Name] nvarchar(max)  NULL,
    [OgvName] nvarchar(max)  NULL,
    [WebmName] nvarchar(max)  NULL,
    [MovName] nvarchar(max)  NULL,
    [OriginalName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Organizations'
CREATE TABLE [dbo].[Organizations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [CityId] int  NOT NULL
);
GO

-- Creating table 'Divisions'
CREATE TABLE [dbo].[Divisions] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ParentDivisionId] int  NULL,
    [OrganizationId] int  NOT NULL
);
GO

-- Creating table 'WorkPlaces'
CREATE TABLE [dbo].[WorkPlaces] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [DivisionId] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL
);
GO

-- Creating table 'Workers'
CREATE TABLE [dbo].[Workers] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WorkPlaceId] int  NOT NULL,
    [IsFormer] bit  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [AspNetUserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'ServiceTypes'
CREATE TABLE [dbo].[ServiceTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [TimeLimit] time  NULL,
    [UseTimeLimit] bit  NULL,
    [WorkPlaceId] int  NOT NULL
);
GO

-- Creating table 'ServiceToClients'
CREATE TABLE [dbo].[ServiceToClients] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [WorkerId] int  NOT NULL,
    [ServiceTypeId] int  NOT NULL,
    [Value] smallint  NOT NULL,
    [UniqueKey] nvarchar(max)  NOT NULL,
    [ValueSet] datetime  NULL,
    [IsCallbackAllowed] bit  NOT NULL,
    [ClientFeedback] nvarchar(max)  NULL,
    [Assigned] datetime  NULL,
    [Started] datetime  NULL,
    [Finished] datetime  NULL,
    [ClientId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'ViolationTypes'
CREATE TABLE [dbo].[ViolationTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [OrganizationId] int  NOT NULL
);
GO

-- Creating table 'AllowedViolations'
CREATE TABLE [dbo].[AllowedViolations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ServiceTypeId] int  NOT NULL,
    [ViolationTypeId] int  NOT NULL
);
GO

-- Creating table 'FoundViolations'
CREATE TABLE [dbo].[FoundViolations] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [ServiceToClientId] int  NOT NULL,
    [ViolationTypeId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [UserId], [LoginProvider], [ProviderKey] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([UserId], [LoginProvider], [ProviderKey] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Cities'
ALTER TABLE [dbo].[Cities]
ADD CONSTRAINT [PK_Cities]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PublicFiles'
ALTER TABLE [dbo].[PublicFiles]
ADD CONSTRAINT [PK_PublicFiles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PublicImages'
ALTER TABLE [dbo].[PublicImages]
ADD CONSTRAINT [PK_PublicImages]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PublicVideos'
ALTER TABLE [dbo].[PublicVideos]
ADD CONSTRAINT [PK_PublicVideos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [PK_Organizations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [PK_Divisions]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'WorkPlaces'
ALTER TABLE [dbo].[WorkPlaces]
ADD CONSTRAINT [PK_WorkPlaces]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Workers'
ALTER TABLE [dbo].[Workers]
ADD CONSTRAINT [PK_Workers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceTypes'
ALTER TABLE [dbo].[ServiceTypes]
ADD CONSTRAINT [PK_ServiceTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ServiceToClients'
ALTER TABLE [dbo].[ServiceToClients]
ADD CONSTRAINT [PK_ServiceToClients]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ViolationTypes'
ALTER TABLE [dbo].[ViolationTypes]
ADD CONSTRAINT [PK_ViolationTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AllowedViolations'
ALTER TABLE [dbo].[AllowedViolations]
ADD CONSTRAINT [PK_AllowedViolations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FoundViolations'
ALTER TABLE [dbo].[FoundViolations]
ADD CONSTRAINT [PK_FoundViolations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [RoleId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoleAspNetRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoleAspNetRole'
CREATE INDEX [IX_FK_AspNetUserRoleAspNetRole]
ON [dbo].[AspNetUserRoles]
    ([RoleId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_User_Id]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserId] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoleAspNetUser1]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoleAspNetUser1'
CREATE INDEX [IX_FK_AspNetUserRoleAspNetUser1]
ON [dbo].[AspNetUserRoles]
    ([UserId]);
GO

-- Creating foreign key on [PhotoId] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [FK_Photo]
    FOREIGN KEY ([PhotoId])
    REFERENCES [dbo].[PublicImages]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Photo'
CREATE INDEX [IX_FK_Photo]
ON [dbo].[AspNetUsers]
    ([PhotoId]);
GO

-- Creating foreign key on [PublicVideoId] in table 'PublicFiles'
ALTER TABLE [dbo].[PublicFiles]
ADD CONSTRAINT [FK_PublicFilePublicVideo]
    FOREIGN KEY ([PublicVideoId])
    REFERENCES [dbo].[PublicVideos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PublicFilePublicVideo'
CREATE INDEX [IX_FK_PublicFilePublicVideo]
ON [dbo].[PublicFiles]
    ([PublicVideoId]);
GO

-- Creating foreign key on [CityId] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [FK_OrganizationCity]
    FOREIGN KEY ([CityId])
    REFERENCES [dbo].[Cities]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_OrganizationCity'
CREATE INDEX [IX_FK_OrganizationCity]
ON [dbo].[Organizations]
    ([CityId]);
GO

-- Creating foreign key on [ParentDivisionId] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [FK_DivisionDivision]
    FOREIGN KEY ([ParentDivisionId])
    REFERENCES [dbo].[Divisions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DivisionDivision'
CREATE INDEX [IX_FK_DivisionDivision]
ON [dbo].[Divisions]
    ([ParentDivisionId]);
GO

-- Creating foreign key on [OrganizationId] in table 'Divisions'
ALTER TABLE [dbo].[Divisions]
ADD CONSTRAINT [FK_DivisionOrganization]
    FOREIGN KEY ([OrganizationId])
    REFERENCES [dbo].[Organizations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_DivisionOrganization'
CREATE INDEX [IX_FK_DivisionOrganization]
ON [dbo].[Divisions]
    ([OrganizationId]);
GO

-- Creating foreign key on [DivisionId] in table 'WorkPlaces'
ALTER TABLE [dbo].[WorkPlaces]
ADD CONSTRAINT [FK_WorkPlaceDivision]
    FOREIGN KEY ([DivisionId])
    REFERENCES [dbo].[Divisions]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkPlaceDivision'
CREATE INDEX [IX_FK_WorkPlaceDivision]
ON [dbo].[WorkPlaces]
    ([DivisionId]);
GO

-- Creating foreign key on [WorkPlaceId] in table 'Workers'
ALTER TABLE [dbo].[Workers]
ADD CONSTRAINT [FK_WorkerWorkPlace]
    FOREIGN KEY ([WorkPlaceId])
    REFERENCES [dbo].[WorkPlaces]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkerWorkPlace'
CREATE INDEX [IX_FK_WorkerWorkPlace]
ON [dbo].[Workers]
    ([WorkPlaceId]);
GO

-- Creating foreign key on [AspNetUserId] in table 'Workers'
ALTER TABLE [dbo].[Workers]
ADD CONSTRAINT [FK_WorkerAspNetUser]
    FOREIGN KEY ([AspNetUserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_WorkerAspNetUser'
CREATE INDEX [IX_FK_WorkerAspNetUser]
ON [dbo].[Workers]
    ([AspNetUserId]);
GO

-- Creating foreign key on [WorkPlaceId] in table 'ServiceTypes'
ALTER TABLE [dbo].[ServiceTypes]
ADD CONSTRAINT [FK_ServiceTypeWorkPlace]
    FOREIGN KEY ([WorkPlaceId])
    REFERENCES [dbo].[WorkPlaces]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceTypeWorkPlace'
CREATE INDEX [IX_FK_ServiceTypeWorkPlace]
ON [dbo].[ServiceTypes]
    ([WorkPlaceId]);
GO

-- Creating foreign key on [WorkerId] in table 'ServiceToClients'
ALTER TABLE [dbo].[ServiceToClients]
ADD CONSTRAINT [FK_ProvidedServiceWorker]
    FOREIGN KEY ([WorkerId])
    REFERENCES [dbo].[Workers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvidedServiceWorker'
CREATE INDEX [IX_FK_ProvidedServiceWorker]
ON [dbo].[ServiceToClients]
    ([WorkerId]);
GO

-- Creating foreign key on [ServiceTypeId] in table 'ServiceToClients'
ALTER TABLE [dbo].[ServiceToClients]
ADD CONSTRAINT [FK_ProvidedServiceServiceType]
    FOREIGN KEY ([ServiceTypeId])
    REFERENCES [dbo].[ServiceTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ProvidedServiceServiceType'
CREATE INDEX [IX_FK_ProvidedServiceServiceType]
ON [dbo].[ServiceToClients]
    ([ServiceTypeId]);
GO

-- Creating foreign key on [OrganizationId] in table 'ViolationTypes'
ALTER TABLE [dbo].[ViolationTypes]
ADD CONSTRAINT [FK_ViolationTypeOrganization]
    FOREIGN KEY ([OrganizationId])
    REFERENCES [dbo].[Organizations]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ViolationTypeOrganization'
CREATE INDEX [IX_FK_ViolationTypeOrganization]
ON [dbo].[ViolationTypes]
    ([OrganizationId]);
GO

-- Creating foreign key on [ServiceTypeId] in table 'AllowedViolations'
ALTER TABLE [dbo].[AllowedViolations]
ADD CONSTRAINT [FK_AllowedViolationServiceType]
    FOREIGN KEY ([ServiceTypeId])
    REFERENCES [dbo].[ServiceTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AllowedViolationServiceType'
CREATE INDEX [IX_FK_AllowedViolationServiceType]
ON [dbo].[AllowedViolations]
    ([ServiceTypeId]);
GO

-- Creating foreign key on [ViolationTypeId] in table 'AllowedViolations'
ALTER TABLE [dbo].[AllowedViolations]
ADD CONSTRAINT [FK_AllowedViolationViolationType]
    FOREIGN KEY ([ViolationTypeId])
    REFERENCES [dbo].[ViolationTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AllowedViolationViolationType'
CREATE INDEX [IX_FK_AllowedViolationViolationType]
ON [dbo].[AllowedViolations]
    ([ViolationTypeId]);
GO

-- Creating foreign key on [ServiceToClientId] in table 'FoundViolations'
ALTER TABLE [dbo].[FoundViolations]
ADD CONSTRAINT [FK_FoundViolationProvidedService]
    FOREIGN KEY ([ServiceToClientId])
    REFERENCES [dbo].[ServiceToClients]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FoundViolationProvidedService'
CREATE INDEX [IX_FK_FoundViolationProvidedService]
ON [dbo].[FoundViolations]
    ([ServiceToClientId]);
GO

-- Creating foreign key on [ViolationTypeId] in table 'FoundViolations'
ALTER TABLE [dbo].[FoundViolations]
ADD CONSTRAINT [FK_FoundViolationViolationType]
    FOREIGN KEY ([ViolationTypeId])
    REFERENCES [dbo].[ViolationTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FoundViolationViolationType'
CREATE INDEX [IX_FK_FoundViolationViolationType]
ON [dbo].[FoundViolations]
    ([ViolationTypeId]);
GO

-- Creating foreign key on [ClientId] in table 'ServiceToClients'
ALTER TABLE [dbo].[ServiceToClients]
ADD CONSTRAINT [FK_ServiceToClientAspNetUser]
    FOREIGN KEY ([ClientId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_ServiceToClientAspNetUser'
CREATE INDEX [IX_FK_ServiceToClientAspNetUser]
ON [dbo].[ServiceToClients]
    ([ClientId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------