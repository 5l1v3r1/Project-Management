/*
   Tuesday, July 25, 20177:11:04 PM
   User: 
   Server: KRUNO-PC\SQLEXPRESS
   Database: PMDatabase
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/

CREATE TABLE dbo.TaskComment
	(
	Id uniqueidentifier NOT NULL,
	TaskId uniqueidentifier NOT NULL,
	UserId uniqueidentifier NOT NULL,
	Text nvarchar(MAX) NOT NULL,
	DateCreated datetime NOT NULL,
	DateUpdated datetime NOT NULL,
	TimeStamp timestamp NOT NULL
	)  ON [PRIMARY]
	 TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE dbo.TaskComment ADD CONSTRAINT
	PK_TaskComment PRIMARY KEY CLUSTERED 
	(
	Id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_TaskComment ON dbo.TaskComment
	(
	TaskId,
	UserId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.TaskComment ADD CONSTRAINT
	FK_TaskComment_Task FOREIGN KEY
	(
	TaskId
	) REFERENCES dbo.Task
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.TaskComment ADD CONSTRAINT
	FK_TaskComment_User FOREIGN KEY
	(
	UserId
	) REFERENCES dbo.[User]
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO