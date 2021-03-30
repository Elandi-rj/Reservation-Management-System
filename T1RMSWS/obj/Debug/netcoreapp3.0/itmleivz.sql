ALTER TABLE [Sittings] ADD [Open] bit NOT NULL DEFAULT CAST(1 AS bit);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200325031106_PersonintIdReservationSittingUpdate', N'3.0.0');

GO

