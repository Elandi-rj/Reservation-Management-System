ALTER TABLE [Reservations] DROP CONSTRAINT [FK_Reservations_People_CustomerId1];

GO

DROP INDEX [IX_Reservations_CustomerId1] ON [Reservations];

GO

ALTER TABLE [People] DROP CONSTRAINT [PK_People];

GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservations]') AND [c].[name] = N'CustomerId1');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Reservations] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [Reservations] DROP COLUMN [CustomerId1];

GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[People]') AND [c].[name] = N'Id');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [People] DROP CONSTRAINT [' + @var1 + '];');
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

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Reservations]') AND [c].[name] = N'DateTime');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Reservations] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Reservations] DROP COLUMN [DateTime];

GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[People]') AND [c].[name] = N'PersonId');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [People] DROP CONSTRAINT [' + @var3 + '];');
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

