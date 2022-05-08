CREATE TABLE [dbo].[ExceptionLogging] (
    [ExceptionLoggingID] INT             IDENTITY (1, 1) NOT NULL,
    [StackTrace]         NVARCHAR (1000) NULL,
    [Message]            NVARCHAR (100)  NOT NULL,
    [Source]             NVARCHAR (100)  NULL,
    [Url]                NVARCHAR (100)  NULL,
    [LogDate]            DATETIME        CONSTRAINT [DF_ExceptionLogging_LogDate] DEFAULT (getdate()) NOT NULL,
    CONSTRAINT [PK__ExeceptionLogging] PRIMARY KEY CLUSTERED ([ExceptionLoggingID] ASC)
);

