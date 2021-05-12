<<<<<<< HEAD
﻿USE [PrePass]
GO

/****** Object: Table [dbo].[Districts] Script Date: 08/04/2021 12:38:44 ******/
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
=======
﻿INSERT INTO STAFF VALUES ('B235','Michael Johnson','mikejon@gmail.com','263667', 1, 1)
INSERT INTO STAFF VALUES ('C146','Michael Jagger','mickj@gmail.com','263742', 2, 1)
INSERT INTO STAFF VALUES ('D47','Michael Jordan','mikej@gmail.com','263817', 3, 1)
INSERT INTO STAFF VALUES ('A765','Michael Judge','mikejud@gmail.com','263892', 1, 1)
>>>>>>> b58f33365bfe5175350beecc8dc09b3f399cac66
