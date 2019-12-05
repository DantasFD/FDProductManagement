IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Brand] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    CONSTRAINT [PK_Brand] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Product] (
    [Id] uniqueidentifier NOT NULL,
    [Name] varchar(100) NOT NULL,
    [Description] varchar(500) NOT NULL,
    [Price] decimal(18,2) NOT NULL,
    [BrandId] uniqueidentifier NOT NULL,
    [FabricationDate] datetime2 NOT NULL,
    [WarrantyExpireDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Product] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Product_Brand_BrandId] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Product_BrandId] ON [Product] ([BrandId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191204170716_InitialCreate', N'3.1.0');

GO

