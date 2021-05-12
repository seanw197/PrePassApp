USE [PrePass]
GO
/*test*/
/****** Object: Table [dbo].[Applicants] Script Date: 07/04/2021 10:54:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Applicants];


GO
CREATE TABLE [dbo].[Applicants] (
    [AppID]            INT            IDENTITY (1, 1) NOT NULL,
    [PPSN]             NVARCHAR (MAX) NULL,
    [Name]             NVARCHAR (MAX) NULL,
    [DateOfBirth]      DATETIME2 (7)  NOT NULL,
    [ContactNumber]    NVARCHAR (MAX) NULL,
    [LastKnownAddress] NVARCHAR (MAX) NULL,
    [Gender]           INT            NOT NULL,
    [Ethnicity]        INT            NOT NULL,
    [LastUpdated]      DATETIME2 (7)  NOT NULL,
    [StaffMemberID]    NVARCHAR (MAX) NULL,
    [Active]           BIT            NOT NULL
);

INSERT INTO APPLICANTS VALUES (0,'7484458K','James Johnson',408-496-7223,'10932 Bigge Rd.','Menlo Park','CA','USA',94025)

