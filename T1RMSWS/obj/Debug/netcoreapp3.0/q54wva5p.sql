CREATE TABLE [Restaurants] (
    [Id] int NOT NULL IDENTITY,
    [Phone] nvarchar(max) NULL,
    [Email] nvarchar(max) NULL,
    CONSTRAINT [PK_Restaurants] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [People] (
    [Id] nvarchar(450) NOT NULL,
    [RestaurantId] int NULL,
    CONSTRAINT [PK_People] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_People_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_People_RestaurantId] ON [People] ([RestaurantId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200311070933_AddedRestaurantAndPersonClass', N'3.0.0');

GO

ALTER TABLE [Restaurants] ADD [Address] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200318125805_SecondMigration', N'3.0.0');

GO

ALTER TABLE [People] DROP CONSTRAINT [FK_People_Restaurants_RestaurantId];

GO

DROP INDEX [IX_People_RestaurantId] ON [People];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[People]') AND [c].[name] = N'RestaurantId');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [People] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [People] DROP COLUMN [RestaurantId];

GO

ALTER TABLE [Restaurants] ADD [SittingCapacity] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [People] ADD [Discriminator] nvarchar(max) NOT NULL DEFAULT N'';

GO

ALTER TABLE [People] ADD [Email] nvarchar(max) NULL;

GO

ALTER TABLE [People] ADD [FirstName] nvarchar(max) NULL;

GO

ALTER TABLE [People] ADD [LastName] nvarchar(max) NULL;

GO

ALTER TABLE [People] ADD [PhoneNumber] nvarchar(max) NULL;

GO

ALTER TABLE [People] ADD [UserId] nvarchar(max) NULL;

GO

CREATE TABLE [ReservationTypes] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_ReservationTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [SittingTypes] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_SittingTypes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Sittings] (
    [Id] int NOT NULL IDENTITY,
    [RestaurantId] int NOT NULL,
    [Start] datetime2 NOT NULL,
    [End] datetime2 NOT NULL,
    [Capacity] int NOT NULL,
    [SittingTypeId] int NOT NULL,
    CONSTRAINT [PK_Sittings] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Sittings_Restaurants_RestaurantId] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurants] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Sittings_SittingTypes_SittingTypeId] FOREIGN KEY ([SittingTypeId]) REFERENCES [SittingTypes] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Reservations] (
    [Id] int NOT NULL IDENTITY,
    [SittingId] int NOT NULL,
    [CustomerId] int NOT NULL,
    [CustomerId1] nvarchar(450) NULL,
    [ReservationTypeId] int NOT NULL,
    [Guests] int NOT NULL,
    [DateTime] datetime2 NOT NULL,
    CONSTRAINT [PK_Reservations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Reservations_People_CustomerId1] FOREIGN KEY ([CustomerId1]) REFERENCES [People] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Reservations_ReservationTypes_ReservationTypeId] FOREIGN KEY ([ReservationTypeId]) REFERENCES [ReservationTypes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Reservations_Sittings_SittingId] FOREIGN KEY ([SittingId]) REFERENCES [Sittings] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Reservations_CustomerId1] ON [Reservations] ([CustomerId1]);

GO

CREATE INDEX [IX_Reservations_ReservationTypeId] ON [Reservations] ([ReservationTypeId]);

GO

CREATE INDEX [IX_Reservations_SittingId] ON [Reservations] ([SittingId]);

GO

CREATE INDEX [IX_Sittings_RestaurantId] ON [Sittings] ([RestaurantId]);

GO

CREATE INDEX [IX_Sittings_SittingTypeId] ON [Sittings] ([SittingTypeId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200319043854_AddedAlotOfClasses', N'3.0.0');

GO

ALTER TABLE [Reservations] DROP CONSTRAINT [FK_Reservations_People_CustomerId1];

GO

DROP INDEX [IX_Reservations_CustomerId1] ON [Reservations];

GO

ALTER TABLE [People] DROP CONSTRAINT [PK_People];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservations]') AND [c].[name] = N'CustomerId1');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Reservations] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Reservations] DROP COLUMN [CustomerId1];

GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[People]') AND [c].[name] = N'Id');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [People] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [People] DROP COLUMN [Id];

GO

ALTER TABLE [People] ADD [PersonId] int NOT NULL IDENTITY;

GO

ALTER TABLE [People] ADD CONSTRAINT [PK_People] PRIMARY KEY ([PersonId]);

GO

CREATE INDEX [IX_Reservations_CustomerId] ON [Reservations] ([CustomerId]);

GO

ALTER TABLE [Reservations] ADD CONSTRAINT [FK_Reservations_People_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [People] ([PersonId]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200325024232_testfixstep1', N'3.0.0');

GO

ALTER TABLE [Reservations] DROP CONSTRAINT [FK_Reservations_People_CustomerId];

GO

ALTER TABLE [People] DROP CONSTRAINT [PK_People];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservations]') AND [c].[name] = N'DateTime');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Reservations] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Reservations] DROP COLUMN [DateTime];

GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[People]') AND [c].[name] = N'PersonId');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [People] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [People] DROP COLUMN [PersonId];

GO

ALTER TABLE [Reservations] ADD [Duration] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [Reservations] ADD [Note] nvarchar(max) NULL;

GO

ALTER TABLE [Reservations] ADD [ReservationStatusId] int NOT NULL DEFAULT 0;

GO

ALTER TABLE [Reservations] ADD [StartTime] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

GO

ALTER TABLE [People] ADD [Id] int NOT NULL IDENTITY;

GO

ALTER TABLE [People] ADD CONSTRAINT [PK_People] PRIMARY KEY ([Id]);

GO

CREATE TABLE [ReservationStatus] (
    [Id] int NOT NULL IDENTITY,
    [Description] nvarchar(max) NULL,
    CONSTRAINT [PK_ReservationStatus] PRIMARY KEY ([Id])
);

GO

CREATE INDEX [IX_Reservations_ReservationStatusId] ON [Reservations] ([ReservationStatusId]);

GO

ALTER TABLE [Reservations] ADD CONSTRAINT [FK_Reservations_People_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [People] ([Id]) ON DELETE CASCADE;

GO

ALTER TABLE [Reservations] ADD CONSTRAINT [FK_Reservations_ReservationStatus_ReservationStatusId] FOREIGN KEY ([ReservationStatusId]) REFERENCES [ReservationStatus] ([Id]) ON DELETE CASCADE;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200325025241_testfixstep2', N'3.0.0');

GO

ALTER TABLE [Sittings] ADD [Open] bit NOT NULL DEFAULT CAST(1 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200325031106_PersonintIdReservationSittingUpdate', N'3.0.0');

GO

