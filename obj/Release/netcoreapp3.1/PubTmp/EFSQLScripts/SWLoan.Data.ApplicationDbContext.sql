IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200829014111_InitialMigration')
BEGIN
    CREATE TABLE [Loans] (
        [No] int NOT NULL IDENTITY,
        [Cost] money NOT NULL,
        [AccountNo] int NOT NULL,
        [Bank] nvarchar(max) NOT NULL,
        [LoanDate] datetime2 NOT NULL,
        [RepaymentDate] datetime2 NOT NULL,
        [UserNo] int NOT NULL,
        [UserName] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Loans] PRIMARY KEY ([No])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200829014111_InitialMigration')
BEGIN
    CREATE TABLE [Users] (
        [No] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [Id] nvarchar(max) NOT NULL,
        [Password] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([No])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20200829014111_InitialMigration')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20200829014111_InitialMigration', N'3.1.7');
END;

GO

