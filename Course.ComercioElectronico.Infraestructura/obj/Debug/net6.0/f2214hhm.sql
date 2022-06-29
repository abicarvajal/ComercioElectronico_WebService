
ALTER TABLE [ProductType] DROP CONSTRAINT [PK_ProductType];
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductType]') AND [c].[name] = N'Id');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [ProductType] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [ProductType] DROP COLUMN [Id];
--GO

--DECLARE @var1 sysname;
--SELECT @var1 = [d].[name]
--FROM [sys].[default_constraints] [d]
--INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
--WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ProductType]') AND [c].[name] = N'Name');
--IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [ProductType] DROP CONSTRAINT [' + @var1 + '];');

--GO

ALTER TABLE [ProductType] ADD [Code] nvarchar(4) NOT NULL DEFAULT N'';
GO

ALTER TABLE [ProductType] ADD [Description] nvarchar(256) NOT NULL DEFAULT N'';
GO

ALTER TABLE [ProductType] DROP COLUMN [Name];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Product]') AND [c].[name] = N'Name');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Product] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Product] ALTER COLUMN [Name] nvarchar(100) NOT NULL;
GO

ALTER TABLE [ProductType] ADD CONSTRAINT [PK_ProductType] PRIMARY KEY ([Code]);
GO

CREATE TABLE [Brand] (
    [Code] nvarchar(4) NOT NULL,
    [Description] nvarchar(256) NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY ([Code])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220628141712_AgregarConfiguracion', N'6.0.6');
GO

