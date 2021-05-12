USE [PrePass]
GO

/****** Object: Table [dbo].[Assessments] Script Date: 12/04/2021 11:55:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Assessments];

GO
CREATE TABLE [dbo].[Assessments] (
    [AssessID]         INT            IDENTITY (1, 1) NOT NULL,
    [AppID]            INT            NOT NULL,
    [EmpID]            NVARCHAR (MAX) NULL,
    [DateCreated]      DATETIME2 (7)  NOT NULL,
    [LastUpdated]      DATETIME2 (7)  NOT NULL,
    [HousingRef]       NVARCHAR (MAX) NULL,
    [Reason]           INT            NOT NULL,
    [Income]           INT            NOT NULL,
    [DistrictID]       INT            NOT NULL,
    [CriminalOff]      BIT            NOT NULL,
    [Household]        INT            NOT NULL,
    [ChildrenUnder18]  INT            NOT NULL,
    [ChildrenOver18]   INT            NOT NULL,
    [Addiction]        INT            NOT NULL,
    [HealthConditions] NVARCHAR (MAX) NULL,
    [LegalIssues]      BIT            NOT NULL,
    [TempRelease]      BIT            NOT NULL,
    [ProbationOfficer] BIT            NOT NULL,
    [SocialWorker]     BIT            NOT NULL,
    [DeptSocial]       BIT            NOT NULL,
    [AddictionSvcs]    BIT            NOT NULL,
    [MHCT]             BIT            NOT NULL,
    [DoctorGP]         BIT            NOT NULL,
    [Keyworker]        BIT            NOT NULL,
    [OtherSupports]    NVARCHAR (MAX) NULL,
    [SupprtsReferred]  NVARCHAR (MAX) NULL,
    [FurtherInfo]      NVARCHAR (MAX) NULL,
    [Status]           INT            NOT NULL
);


INSERT INTO Assessments VALUES (2, 'A123', '2021-04-01 11:56:14', '2021-04-12 10:56:14', 'B53422F', 2, 1, 1, 1, 0, 4, 0, 3, 'Big nose', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 0)
INSERT INTO Assessments VALUES (3, 'C146', '2021-04-02 12:56:14', '2021-04-12 11:56:14', 'C3426F', 2, 1, 2, 0, 0, 4, 0, 3, 'Big ears', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 1)
INSERT INTO Assessments VALUES (4, 'D47', '2021-04-03 13:56:14', '2021-04-10 12:56:14', 'D3422F', 2, 1, 3, 1, 0, 4, 0, 3, 'Big eyes', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 2)
INSERT INTO Assessments VALUES (10, 'A123', '2021-04-09 14:56:14', '2021-04-11 13:56:14', 'A1422F', 2, 4, 0, 1, 0, 4, 0, 3, 'Big feet', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 3)
INSERT INTO Assessments VALUES (7, 'D47', '2021-05-09 15:56:14', '2021-04-11 14:56:14', 'A9422F', 2, 1, 5, 1, 0, 4, 0, 3, 'Big hair', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 4)
INSERT INTO Assessments VALUES (12, 'A123', '2021-04-01 11:56:14', '2021-04-13 10:56:14', 'B53422F', 2, 1, 1, 1, 0, 4, 0, 3, 'Big nose', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 0)																	
INSERT INTO Assessments VALUES (13, 'C146', '2021-04-02 12:56:14', '2021-04-13 11:56:14', 'C3426F', 2, 1, 2, 0, 0, 4, 0, 3, 'Big ears', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 1)																	
INSERT INTO Assessments VALUES (14, 'D47', '2021-04-03 13:56:14', '2021-04-13 12:56:14', 'D3422F', 2, 1, 3, 1, 0, 4, 0, 3, 'Big eyes', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 2)																	
INSERT INTO Assessments VALUES (15, 'A123', '2021-04-09 14:56:14', '2021-04-13 13:56:14', 'A1422F', 2, 4, 0, 1, 0, 4, 0, 3, 'Big feet', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 3)																	
INSERT INTO Assessments VALUES (16, 'D47', '2021-05-09 15:56:14', '2021-04-13 14:56:14', 'A9422F', 2, 1, 5, 1, 0, 4, 0, 3, 'Big hair', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 5)																	
INSERT INTO Assessments VALUES (17, 'A123', '2021-04-01 11:56:14', '2021-04-13 10:56:14', 'B53422F', 2, 1, 1, 1, 0, 4, 0, 3, 'Big nose', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 0)																	
INSERT INTO Assessments VALUES (18, 'C146', '2021-04-02 12:56:14', '2021-04-13 11:56:14', 'C3426F', 2, 1, 2, 0, 0, 4, 0, 3, 'Big ears', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 1)																	
INSERT INTO Assessments VALUES (19, 'D47', '2021-04-03 13:56:14', '2021-04-13 12:56:14', 'D3422F', 2, 1, 3, 1, 0, 4, 0, 3, 'Big eyes', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 2)																	
INSERT INTO Assessments VALUES (20, 'A123', '2021-04-09 14:56:14', '2021-04-13 13:56:14', 'A1422F', 2, 4, 0, 1, 0, 4, 0, 3, 'Big feet', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 3)																	
INSERT INTO Assessments VALUES (21, 'D47', '2021-05-09 15:56:14', '2021-04-13 14:56:14', 'A9422F', 2, 1, 5, 1, 0, 4, 0, 3, 'Big hair', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 5)																	
INSERT INTO Assessments VALUES (22, 'A123', '2021-04-01 11:56:14', '2021-04-13 10:56:14', 'B53422F', 2, 1, 1, 1, 0, 4, 0, 3, 'Big nose', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 0)																	
INSERT INTO Assessments VALUES (23, 'C146', '2021-04-02 12:56:14', '2021-04-13 11:56:14', 'C3426F', 2, 1, 2, 0, 0, 4, 0, 3, 'Big ears', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 1)																	
INSERT INTO Assessments VALUES (24, 'D47', '2021-04-03 13:56:14', '2021-04-13 12:56:14', 'D3422F', 2, 1, 3, 1, 0, 4, 0, 3, 'Big eyes', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 2)																	
INSERT INTO Assessments VALUES (25, 'A123', '2021-04-09 14:56:14', '2021-04-13 13:56:14', 'A1422F', 2, 4, 0, 1, 0, 4, 0, 3, 'Big feet', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 3)																	
INSERT INTO Assessments VALUES (26, 'D47', '2021-05-09 15:56:14', '2021-04-13 14:56:14', 'A9422F', 2, 1, 5, 1, 0, 4, 0, 3, 'Big hair', 1, 1, 1, 1, 1, 1, 1, 1, 1, 'Tusla', 'Hospital', 'Further', 5)