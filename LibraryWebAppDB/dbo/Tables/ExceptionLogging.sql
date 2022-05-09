CREATE TABLE [dbo].[ExceptionLogging] (
    [ExceptionLoggingID] INT IDENTITY (1, 1) NOT NULL,
    [StackTrace]         NVARCHAR (MAX) NULL,
    [Message]            NVARCHAR (MAX)  NOT NULL,
    [Source]             NVARCHAR (MAX)  NULL,
    [Url]                NVARCHAR (MAX)  NULL,
    [LogDate]            DATETIME        CONSTRAINT [DF_ExceptionLogging_LogDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__ExeceptionLogging] PRIMARY KEY CLUSTERED ([ExceptionLoggingID] ASC)
);

