USE [PrePass]
GO

/****** Object: Table [dbo].[Districts] Script Date: 28/04/2021 17:27:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Districts];


GO
CREATE TABLE [dbo].[Districts] (
    [DistrictID]   INT            IDENTITY (1, 1) NOT NULL,
    [DistrictName] NVARCHAR (MAX) NOT NULL,
    [Active]       BIT            NOT NULL
);


USE [PrePass]
GO

/****** Object: Table [dbo].[Staff] Script Date: 28/04/2021 17:28:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Staff];


GO
CREATE TABLE [dbo].[Staff] (
    [EmpID]       NVARCHAR (450) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Email]       NVARCHAR (MAX) NULL,
    [Passwd]      NVARCHAR (MAX) NULL,
    [accessLevel] INT            NOT NULL,
    [Active]      BIT            NOT NULL
);



USE [PrePass]
GO

/****** Object: Table [dbo].[Assessments] Script Date: 28/04/2021 17:33:57 ******/
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



USE [PrePass]
GO

/****** Object: Table [dbo].[Applicants] Script Date: 28/04/2021 17:29:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Applicants];


GO
CREATE TABLE [dbo].[Applicants] (
    [AppID]            INT            IDENTITY (1, 1) NOT NULL,
    [PPSN]             NVARCHAR (MAX) NULL,
    [FName]            NVARCHAR (MAX) NULL,
    [LName]            NVARCHAR (MAX) NULL,
    [DateOfBirth]      DATETIME2 (7)  NOT NULL,
    [ContactNumber]    NVARCHAR (MAX) NULL,
    [LastKnownAddress] NVARCHAR (MAX) NULL,
    [Gender]           INT            NOT NULL,
    [Ethnicity]        INT            NOT NULL,
    [LastUpdated]      DATETIME2 (7)  NOT NULL,
    [EmpID]    NVARCHAR (MAX) NULL,
    [Active]           BIT            NOT NULL
);


INSERT INTO APPLICANTS VALUES ('7484458A','James', 'Johnson','1950-1-21','83-6858239','1 Main St, Maynooth',0,0,'2021-1-21','A123', 1)
INSERT INTO APPLICANTS VALUES ('7484503B','Royal', 'Rueter','1951-1-2','84-6858251','2 Main St, Naas',1,1,'2021-1-2','A577', 1)
INSERT INTO APPLICANTS VALUES ('7484548C','Craig', 'Cothren','1952-1-3','85-6858263','3 Main St, Clane',2,2,'2021-1-3','A765', 1)
INSERT INTO APPLICANTS VALUES ('7484593A','Steve', 'Soderstrom','1953-1-4','86-6858275','4 Main St, Celbridge',0,3,'2021-1-4','A357', 1)
INSERT INTO APPLICANTS VALUES ('7484638B','Estela', 'Eisenman','1954-2-5','87-6858287','5 Main St, Newbridge',1,4,'2021-2-5','B123', 1)
INSERT INTO APPLICANTS VALUES ('7484683X','Susan', 'Sam','1955-2-6','84-6858299','6 Main St, Athy',2,5,'2021-2-6','B235', 1)
INSERT INTO APPLICANTS VALUES ('7484728A','Orpha', 'Onorato','1956-3-7','85-6858311','7 Main St, Leixlip',0,6,'2021-3-7','C146', 1)
INSERT INTO APPLICANTS VALUES ('7484773B','Isa', 'Isakson','1957-3-8','86-6858323','8 Main St, Robertstown',1,7,'2021-3-8','C146', 1)
INSERT INTO APPLICANTS VALUES ('7484818C','Jeneva', 'Jeansonne','1958-4-9','87-6858335','9 Main St, Sallins',2,8,'2021-4-9','A123', 1)
INSERT INTO APPLICANTS VALUES ('7484863B','Wynell', 'Waguespack','1959-4-10','88-6858347','10 Main St, Maynooth',0,9,'2021-4-10','A577', 1)
INSERT INTO APPLICANTS VALUES ('7484908C','Tereasa', 'Thiede','1960-1-11','85-6858359','11 Main St, Naas',1,0,'2021-1-11','A765', 1)
INSERT INTO APPLICANTS VALUES ('7484953B','Wanetta', 'Wehrle','1961-1-12','86-6858371','12 Main St, Clane',2,1,'2021-1-12','A357', 1)
INSERT INTO APPLICANTS VALUES ('7484998C','Beverlee', 'Bickham','1962-1-13','87-6858383','13 Main St, Celbridge',0,2,'2021-1-13','B123', 1)
INSERT INTO APPLICANTS VALUES ('7485043B','Monty', 'Mance','1963-1-14','88-6858395','14 Main St, Newbridge',1,3,'2021-1-14','B235', 1)
INSERT INTO APPLICANTS VALUES ('7485088C','Kandi', 'Kivi','1964-2-15','89-6858407','15 Main St, Athy',2,4,'2021-2-15','C146', 1)
INSERT INTO APPLICANTS VALUES ('7485133B','Rosalina', 'Rakowski','1965-2-16','86-6858419','16 Main St, Leixlip',0,5,'2021-2-16','C146', 1)
INSERT INTO APPLICANTS VALUES ('7485178C','Thelma', 'Tansey','1966-3-17','87-6858431','17 Main St, Robertstown',1,6,'2021-3-17','A123', 1)
INSERT INTO APPLICANTS VALUES ('7485223B','Antionette', 'Anson','1967-3-18','88-6858443','18 Main St, Sallins',2,7,'2021-3-18','A577', 1)
INSERT INTO APPLICANTS VALUES ('7485268C','Terrance', 'Tack','1968-4-19','89-6858455','19 Main St, Maynooth',0,8,'2021-4-19','A765', 1)
INSERT INTO APPLICANTS VALUES ('7485313B','Marco', 'Minick','1969-4-20','90-6858467','20 Main St, Naas',1,9,'2021-4-20','A357', 1)
INSERT INTO APPLICANTS VALUES ('7485358C','Lea', 'Lafon','1970-1-21','87-6858479','21 Main St, Clane',2,0,'2021-1-21','B123', 1)
INSERT INTO APPLICANTS VALUES ('7485403B','Ignacio', 'Ingerson','1971-1-22','88-6858491','22 Main St, Celbridge',0,1,'2021-1-22','B235', 1)
INSERT INTO APPLICANTS VALUES ('7485448C','Perry', 'Prill','1972-1-23','86-6858503','23 Main St, Newbridge',1,2,'2021-1-23','C146', 1)
INSERT INTO APPLICANTS VALUES ('7485493B','Roger', 'Ragin','1973-1-24','87-6858515','24 Main St, Athy',2,3,'2021-1-24','C146', 1)
INSERT INTO APPLICANTS VALUES ('7485538C','Williams', 'Woolston','1974-2-25','88-6858527','25 Main St, Leixlip',0,4,'2021-2-25','A123', 1)
INSERT INTO APPLICANTS VALUES ('7485583B','Cher', 'Carrillo','1975-2-26','89-6858539','26 Main St, Robertstown',1,5,'2021-2-26','A577', 1)
INSERT INTO APPLICANTS VALUES ('7485628C','Meryl', 'Mei','1976-3-1','90-6858551','27 Main St, Sallins',2,6,'2021-3-1','A765', 1)
INSERT INTO APPLICANTS VALUES ('7485673B','Debbie', 'Devos','1977-3-2','87-6858563','28 Main St, Maynooth',0,7,'2021-3-2','A357', 1)
INSERT INTO APPLICANTS VALUES ('7485718C','Antonia', 'Arwood','1978-4-3','88-6858575','29 Main St, Naas',1,8,'2021-4-3','B123', 1)
INSERT INTO APPLICANTS VALUES ('7485763B','Juli', 'Janson','1979-4-4','89-6858587','30 Main St, Clane',2,9,'2021-4-4','B235', 1)
INSERT INTO APPLICANTS VALUES ('7485808C','Ferne', 'Fults','1980-1-5','90-6858599','31 Main St, Celbridge',0,0,'2021-1-5','C146', 1)
INSERT INTO APPLICANTS VALUES ('7485853B','Layne', 'Lesperance','1981-1-6','91-6858611','32 Main St, Newbridge',1,1,'2021-1-6','C146', 1)
INSERT INTO APPLICANTS VALUES ('7485898C','Melida', 'Mishoe','1982-1-7','88-6858623','33 Main St, Athy',2,2,'2021-1-7','A123', 1)
INSERT INTO APPLICANTS VALUES ('7485943B','Micaela', 'Marrero','1983-1-8','89-6858635','34 Main St, Leixlip',0,3,'2021-1-8','A577', 1)
INSERT INTO APPLICANTS VALUES ('7485988C','Livia', 'Lavallie','1984-2-9','87-6858647','35 Main St, Robertstown',1,4,'2021-2-9','A765', 1)
INSERT INTO APPLICANTS VALUES ('7486033B','Remona', 'Ruffino','1985-2-10','88-6858659','36 Main St, Sallins',2,5,'2021-2-10','A357', 1)
INSERT INTO APPLICANTS VALUES ('7486078C','Herta', 'Haymond','1986-3-11','89-6858671','37 Main St, Maynooth',0,6,'2021-3-11','B123', 1)
INSERT INTO APPLICANTS VALUES ('7486123B','Sherly', 'Stout','1987-3-12','90-6858683','38 Main St, Naas',1,7,'2021-3-12','B235', 1)
INSERT INTO APPLICANTS VALUES ('7486168C','Melany', 'Meikle','1988-4-13','91-6858695','39 Main St, Clane',2,8,'2021-4-13','C146', 1)
INSERT INTO APPLICANTS VALUES ('7486213B','Lorina', 'Lantz','1989-4-14','88-6858707','40 Main St, Celbridge',0,9,'2021-4-14','C146', 1)
INSERT INTO APPLICANTS VALUES ('7486258C','Phoebe', 'Puett','1990-1-15','89-6858719','41 Main St, Newbridge',1,0,'2021-1-15','A123', 1)
INSERT INTO APPLICANTS VALUES ('7486303B','Tawanna', 'Trevizo','1991-1-16','90-6858731','42 Main St, Athy',2,1,'2021-1-16','A577', 1)
INSERT INTO APPLICANTS VALUES ('7486348C','Lean', 'Levron','1992-1-17','91-6858743','43 Main St, Leixlip',0,2,'2021-1-17','A765', 1)
INSERT INTO APPLICANTS VALUES ('7486393B','Katharine', 'Kubicek','1993-1-18','92-6858755','44 Main St, Robertstown',1,3,'2021-1-18','A357', 1)
INSERT INTO APPLICANTS VALUES ('7486438C','Yulanda', 'Yamamoto','1994-2-19','89-6858767','45 Main St, Sallins',2,4,'2021-2-19','B123', 1)
INSERT INTO APPLICANTS VALUES ('7486483B','Huong', 'Hickmon','1995-2-20','90-6858779','46 Main St, Maynooth',0,5,'2021-2-20','B235', 1)
INSERT INTO APPLICANTS VALUES ('7486528C','Christy', 'Crosson','1996-3-21','88-6858791','47 Main St, Naas',1,6,'2021-3-21','C146', 1)
INSERT INTO APPLICANTS VALUES ('7486573B','Harold', 'Hutchinson','1997-3-22','89-6858803','48 Main St, Clane',2,7,'2021-3-22','A357', 1)
INSERT INTO APPLICANTS VALUES ('7486618C','Katheryn', 'Kile','1998-4-23','90-6858815','49 Main St, Celbridge',0,8,'2021-4-23','B123', 1)
INSERT INTO APPLICANTS VALUES ('7486663B','Grisel', 'Guizar','1999-4-24','91-6858827','50 Main St, Newbridge',1,9,'2021-4-24','B235', 1)
INSERT INTO APPLICANTS VALUES ('7486708C','Linsey', 'Leitz','2000-4-25','92-6858839','51 Main St, Athy',2,0,'2021-4-25','C146', 1)



INSERT INTO STAFF VALUES ('A123','Dave Smythe','davesmyth1234@gmail.com','abcd4567',1,1)
INSERT INTO STAFF VALUES ('A577','Adam J Assessor','adam.as@gmail.com','dfhjdhf',1,1)
INSERT INTO STAFF VALUES ('A765','Michael Judge','mikejud@gmail.com','hh88ww',0,1)
INSERT INTO STAFF VALUES ('A357','Mark Small','marks@hotmail.com','105148',0,1)
INSERT INTO STAFF VALUES ('B123','Bob Assessor','bobbyboy@gmail.com','4545',0,1)
INSERT INTO STAFF VALUES ('B235','Michael Johnson','mikejon@gmail.com','263667',1,1)
INSERT INTO STAFF VALUES ('C146','Michael Jagger','mickj@gmail.com','263742',2,1)

INSERT INTO DISTRICTS VALUES ('Athy', 1)
INSERT INTO DISTRICTS VALUES ('Celbridge-Leixlip', 1)
INSERT INTO DISTRICTS VALUES ('Clane-Maynooth', 1)
INSERT INTO DISTRICTS VALUES ('Kildare-Newbridge', 1)
INSERT INTO DISTRICTS VALUES ('Naas', 1)
INSERT INTO DISTRICTS VALUES ('Carlow County Council', 1)
INSERT INTO DISTRICTS VALUES ('Dublin City Council', 1)
INSERT INTO DISTRICTS VALUES ('Dun Laoghaire–Rathdown County Council', 1)
INSERT INTO DISTRICTS VALUES ('Fingal County Council', 1)
INSERT INTO DISTRICTS VALUES ('South Dublin County Council', 1)
INSERT INTO DISTRICTS VALUES ('Kilkenny County Council', 1)
INSERT INTO DISTRICTS VALUES ('Laois County Council', 1)
INSERT INTO DISTRICTS VALUES ('Longford County Council', 1)
INSERT INTO DISTRICTS VALUES ('Louth County Council', 1)
INSERT INTO DISTRICTS VALUES ('Meath County Council', 1)
INSERT INTO DISTRICTS VALUES ('Offaly County Council', 1)
INSERT INTO DISTRICTS VALUES ('Westmeath County Council', 1)
INSERT INTO DISTRICTS VALUES ('Wexford County Council', 1)
INSERT INTO DISTRICTS VALUES ('Wicklow County Council', 1)
INSERT INTO DISTRICTS VALUES ('Cavan County Council', 1)
INSERT INTO DISTRICTS VALUES ('Clare County Council', 1)
INSERT INTO DISTRICTS VALUES ('Cork City Council', 1)
INSERT INTO DISTRICTS VALUES ('Cork County Council', 1)
INSERT INTO DISTRICTS VALUES ('Donegal County Council', 1)
INSERT INTO DISTRICTS VALUES ('Galway City Council', 1)
INSERT INTO DISTRICTS VALUES ('Galway County Council', 1)
INSERT INTO DISTRICTS VALUES ('Kerry County Council', 1)
INSERT INTO DISTRICTS VALUES ('Leitrim County Council', 1)
INSERT INTO DISTRICTS VALUES ('Limerick City and County Council', 1)
INSERT INTO DISTRICTS VALUES ('Mayo County Council', 1)
INSERT INTO DISTRICTS VALUES ('Monaghan County Council', 1)
INSERT INTO DISTRICTS VALUES ('Roscommon County Council', 1)
INSERT INTO DISTRICTS VALUES ('Sligo County Council', 1)
INSERT INTO DISTRICTS VALUES ('Tipperary County Council', 1)
INSERT INTO DISTRICTS VALUES ('Waterford City and County Council', 1)

INSERT INTO Assessments VALUES (0,'A123','2021-1-1 09:00:00','2021-1-4 09:00:00','2021/11',0,0,1,1,0,0,0,0,'Blind in one eye',1,1,1,0,1,0,1,1,1,'Tusla','Hospital','Further',0)
INSERT INTO Assessments VALUES (1,'A577','2021-2-2 09:00:00','2021-2-5 09:00:00','2021/22',1,1,2,1,1,0,0,0,'Partial hearing',0,0,1,1,0,1,0,0,0,'','','',1)
INSERT INTO Assessments VALUES (2,'A765','2021-3-3 09:00:00','2021-3-6 09:00:00','2021/33',2,2,3,0,2,1,0,0,'Wheelchair bound',0,0,1,0,0,0,0,0,0,'','','',2)
INSERT INTO Assessments VALUES (3,'A357','2021-4-4 09:00:00','2021-4-7 09:00:00','2021/44',3,0,4,0,3,1,1,1,'',0,0,0,0,0,0,0,0,0,'','','',3)
INSERT INTO Assessments VALUES (4,'B123','2021-1-5 09:00:00','2021-1-8 09:00:00','2021/51',4,1,5,0,4,2,1,1,'Arthritis',0,1,0,0,1,0,1,0,1,'Tusla','Hospital','Further',4)
INSERT INTO Assessments VALUES (5,'B235','2021-2-6 09:00:00','2021-2-9 09:00:00','2021/62',5,2,6,1,0,2,1,2,'',1,1,0,1,1,1,1,0,1,'','','',5)
INSERT INTO Assessments VALUES (6,'C146','2021-3-7 09:00:00','2021-3-10 09:00:00','2021/73',6,0,7,1,1,3,2,2,'COPD',1,0,1,1,0,1,0,0,0,'','','',0)
INSERT INTO Assessments VALUES (7,'A123','2021-4-8 09:00:00','2021-4-11 09:00:00','2021/84',7,1,8,0,2,3,2,3,'',0,0,1,0,0,0,0,1,0,'','','',1)
INSERT INTO Assessments VALUES (8,'A577','2021-1-9 09:00:00','2021-1-12 09:00:00','2021/91',8,2,9,1,3,4,2,3,'Blindness',0,0,0,0,0,0,0,1,0,'Tusla','Hospital','Further',2)
INSERT INTO Assessments VALUES (9,'A765','2021-2-10 09:00:00','2021-2-13 09:00:00','2021/102',9,0,10,1,4,4,3,0,'',0,0,0,0,0,0,0,0,0,'','','',3)
INSERT INTO Assessments VALUES (10,'A357','2021-3-11 09:00:00','2021-3-14 09:00:00','2021/113',10,1,11,1,0,5,3,0,'',0,1,0,0,1,0,1,0,1,'','','',4)
INSERT INTO Assessments VALUES (11,'B123','2021-4-12 09:00:00','2021-4-15 09:00:00','2021/124',11,2,12,0,1,6,3,0,'Blindness',1,1,0,1,1,1,1,0,1,'','','',5)
INSERT INTO Assessments VALUES (12,'B235','2021-1-13 09:00:00','2021-1-16 09:00:00','2021/131',12,0,13,0,2,0,0,1,'',1,0,1,1,0,1,0,0,0,'Tusla','Hospital','Further',0)
INSERT INTO Assessments VALUES (13,'C146','2021-2-14 09:00:00','2021-2-17 09:00:00','2021/142',0,1,14,0,3,0,0,1,'',0,0,1,0,0,0,0,1,0,'','','',1)
INSERT INTO Assessments VALUES (14,'A123','2021-3-15 09:00:00','2021-3-18 09:00:00','2021/153',1,2,15,1,4,1,0,2,'Blind in one eye',0,0,0,0,0,0,0,1,0,'','','',2)
INSERT INTO Assessments VALUES (15,'A577','2021-4-16 09:00:00','2021-4-19 09:00:00','2021/164',2,0,16,1,0,1,0,2,'Partial hearing',0,0,0,0,0,0,0,0,0,'','','',3)
INSERT INTO Assessments VALUES (16,'A765','2021-1-17 09:00:00','2021-1-20 09:00:00','2021/171',3,1,17,0,1,2,0,3,'Wheelchair bound',0,1,0,0,1,0,1,0,1,'Tusla','Hospital','Further',4)
INSERT INTO Assessments VALUES (17,'A357','2021-2-18 09:00:00','2021-2-21 09:00:00','2021/182',4,2,18,1,2,2,0,3,'',1,1,0,1,1,1,1,0,1,'','','',5)
INSERT INTO Assessments VALUES (18,'B123','2021-3-19 09:00:00','2021-3-22 09:00:00','2021/193',5,0,19,1,3,3,0,0,'Arthritis',1,0,1,1,0,1,0,0,0,'','','',0)
INSERT INTO Assessments VALUES (19,'B235','2021-01-20 09:00:00','2021-01-23 09:00:00','2021/204',6,1,20,1,4,3,1,0,'',0,0,1,0,0,0,0,1,0,'','','',1)
INSERT INTO Assessments VALUES (20,'C146','2021-01-21 09:00:00','2021-01-24 09:00:00','2021/211',7,2,1,0,0,4,1,0,'COPD',0,0,0,0,0,0,0,1,0,'Tusla','Hospital','Further',2)
INSERT INTO Assessments VALUES (21,'A123','2021-01-22 09:00:00','2021-01-25 09:00:00','2021/222',8,0,2,0,1,4,1,1,'',0,0,0,0,0,0,0,0,0,'Tusla','Hospital','Further',3)
INSERT INTO Assessments VALUES (22,'A577','2021-01-23 09:00:00','2021-01-26 09:00:00','2021/233',9,1,3,0,2,5,3,1,'',0,1,0,0,1,0,1,0,1,'','','',4)
INSERT INTO Assessments VALUES (23,'A765','2021-01-24 09:00:00','2021-01-27 09:00:00','2021/244',10,2,4,1,3,6,3,2,'',1,1,0,1,1,1,1,0,1,'','','',5)
INSERT INTO Assessments VALUES (24,'A357','2021-01-25 09:00:00','2021-01-28 09:00:00','2021/251',11,0,5,1,4,0,0,2,'Blindness',1,0,1,1,0,1,0,0,0,'','','',0)
INSERT INTO Assessments VALUES (25,'B123','2021-01-1 09:00:00','2021-01-4 09:00:00','2021/12',12,1,2,0,0,0,0,3,'',0,0,1,0,0,0,0,1,0,'Tusla','Hospital','Further',1)
INSERT INTO Assessments VALUES (26,'B235','2021-01-2 09:00:00','2021-01-5 09:00:00','2021/23',0,2,3,1,1,1,0,3,'',0,0,0,0,0,0,0,1,0,'','','',2)
INSERT INTO Assessments VALUES (27,'C146','2021-01-3 09:00:00','2021-01-6 09:00:00','2021/34',1,0,4,1,2,1,1,0,'',0,0,0,0,0,0,0,0,0,'','','',3)
INSERT INTO Assessments VALUES (28,'A123','2021-01-4 09:00:00','2021-01-7 09:00:00','2021/41',2,1,5,1,3,2,1,0,'Blind in one eye',0,1,0,0,1,0,1,0,1,'','','',4)
INSERT INTO Assessments VALUES (29,'A577','2021-01-5 09:00:00','2021-01-8 09:00:00','2021/52',3,2,10,0,4,2,1,0,'Partial hearing',1,1,0,1,1,1,1,0,1,'Tusla','Hospital','Further',5)
INSERT INTO Assessments VALUES (30,'A765','2021-01-6 09:00:00','2021-01-9 09:00:00','2021/63',4,0,11,0,0,3,2,1,'Wheelchair bound',1,0,1,1,0,1,0,0,0,'','','',0)
INSERT INTO Assessments VALUES (31,'A357','2021-01-7 09:00:00','2021-01-10 09:00:00','2021/74',5,1,5,0,1,3,2,1,'',0,0,1,0,0,0,0,1,0,'','','',1)
INSERT INTO Assessments VALUES (32,'B123','2021-01-8 09:00:00','2021-01-11 09:00:00','2021/81',6,2,2,1,2,4,2,2,'Arthritis',0,0,0,0,0,0,0,1,0,'','','',2)
INSERT INTO Assessments VALUES (33,'B235','2021-01-9 09:00:00','2021-01-12 09:00:00','2021/92',7,0,3,1,3,4,3,2,'',0,0,0,0,0,0,0,0,0,'Tusla','Hospital','Further',3)
INSERT INTO Assessments VALUES (34,'C146','2021-01-10 09:00:00','2021-01-13 09:00:00','2021/103',8,1,4,0,4,5,3,3,'COPD',0,1,0,0,1,0,1,0,1,'Tusla','Hospital','Further',4)
INSERT INTO Assessments VALUES (35,'A123','2021-01-11 09:00:00','2021-01-14 09:00:00','2021/114',9,2,5,1,0,6,3,3,'',1,0,0,1,0,1,0,0,0,'','','',5)
INSERT INTO Assessments VALUES (36,'A577','2021-01-12 09:00:00','2021-01-15 09:00:00','2021/121',10,0,17,1,1,0,0,0,'',0,0,1,0,0,0,0,0,0,'','','',0)
INSERT INTO Assessments VALUES (37,'A765','2021-01-13 09:00:00','2021-01-16 09:00:00','2021/132',11,1,18,1,2,0,0,0,'Blind in one eye',0,0,0,0,0,0,0,1,0,'','','',1)
INSERT INTO Assessments VALUES (38,'A357','2021-01-14 09:00:00','2021-01-17 09:00:00','2021/143',12,2,19,0,3,1,0,0,'Partial hearing',0,1,0,0,1,0,1,0,1,'Tusla','Hospital','Further',2)
INSERT INTO Assessments VALUES (39,'B123','2021-01-15 09:00:00','2021-01-18 09:00:00','2021/154',0,0,20,0,4,1,0,1,'Wheelchair bound',1,0,0,1,0,1,0,0,0,'','','',3)
INSERT INTO Assessments VALUES (40,'B235','2021-01-16 09:00:00','2021-01-19 09:00:00','2021/161',1,1,21,0,0,2,0,1,'',0,0,1,0,0,0,0,0,0,'','','',4)
INSERT INTO Assessments VALUES (41,'C146','2021-01-17 09:00:00','2021-01-20 09:00:00','2021/172',2,2,22,1,1,2,0,2,'Arthritis',0,1,0,0,1,0,1,1,1,'','','',5)
INSERT INTO Assessments VALUES (42,'A123','2021-01-18 09:00:00','2021-01-21 09:00:00','2021/183',3,0,23,1,2,3,0,2,'',1,0,0,1,0,1,0,0,0,'Tusla','Hospital','Further',0)
INSERT INTO Assessments VALUES (43,'A577','2021-01-19 09:00:00','2021-01-22 09:00:00','2021/194',4,1,24,0,3,0,1,3,'COPD',0,0,1,0,0,0,0,0,0,'','','',1)
INSERT INTO Assessments VALUES (44,'A765','2021-01-20 09:00:00','2021-01-23 09:00:00','2021/201',5,2,25,1,4,0,1,3,'',0,1,0,0,1,0,1,1,1,'','','',2)
INSERT INTO Assessments VALUES (45,'A357','2021-01-21 09:00:00','2021-01-24 09:00:00','2021/212',6,0,26,1,0,1,1,0,'',1,0,0,1,0,1,0,0,0,'','','',3)
INSERT INTO Assessments VALUES (46,'B123','2021-01-22 09:00:00','2021-01-25 09:00:00','2021/223',7,1,27,1,1,1,3,0,'Blindness',0,0,1,0,0,0,0,0,0,'Tusla','Hospital','Further',4)
INSERT INTO Assessments VALUES (47,'B235','2021-01-23 09:00:00','2021-01-26 09:00:00','2021/234',8,2,28,0,2,2,3,0,'',0,0,0,0,0,0,0,1,0,'','','',5)
INSERT INTO Assessments VALUES (48,'C146','2021-01-24 09:00:00','2021-01-27 09:00:00','2021/241',9,0,29,0,3,2,0,1,'',0,1,0,0,1,0,1,0,1,'','','',0)
INSERT INTO Assessments VALUES (49,'A123','2021-01-25 09:00:00','2021-01-28 09:00:00','2021/252',10,1,30,0,4,3,0,1,'Blind in one eye',1,0,0,1,0,1,0,0,0,'Tusla','Hospital','Further',1)
INSERT INTO Assessments VALUES (50,'A577','2021-01-1 09:00:00','2021-01-4 09:00:00','2021/13',11,2,31,1,0,3,0,2,'Partial hearing',0,0,1,0,0,0,0,0,0,'','','',2)
INSERT INTO Assessments VALUES (51,'A765','2021-01-2 09:00:00','2021-01-5 09:00:00','2021/24',12,0,32,1,1,0,1,2,'Wheelchair bound',0,0,0,0,0,0,0,1,0,'','','',3)
