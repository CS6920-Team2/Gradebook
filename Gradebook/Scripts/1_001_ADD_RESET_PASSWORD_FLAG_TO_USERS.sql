﻿USE [gradebook]

BEGIN TRANSACTION
GO
ALTER TABLE dbo.Users ADD
	resetPassword bit NOT NULL CONSTRAINT DF_Users_resetPassword DEFAULT 0
GO
COMMIT