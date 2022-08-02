USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 02-08-2022 18:14:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
    [EmployeeID] [int] IDENTITY(1,1) NOT NULL,
    [FirstName] [nvarchar](max) NULL,
    [MiddleName] [nvarchar](max) NULL,
    [LastName] [nvarchar](max) NULL,
    [Gender] [nvarchar](max) NULL,
    [DateOfBirth] [datetime2](7) NOT NULL,
    [HireDate] [datetime2](7) NOT NULL,
    [AddressLine1] [nvarchar](max) NULL,
    [AddressLine2] [nvarchar](max) NULL,
    [AddressLine3] [nvarchar](max) NULL,
    [City] [nvarchar](max) NULL,
    [Country] [nvarchar](max) NULL,
    [CitizenshipId] [int] NOT NULL,
    [CitizenshipLegislationCode] [int] NOT NULL,
    [CitizenshipStatus] [nvarchar](max) NULL,
    [CitizenshipToDate] [datetime2](7) NOT NULL,
    [CorrespondenceLanguage] [nvarchar](max) NULL,
    [CreationDate] [datetime2](7) NOT NULL,
    [DisplayName] [nvarchar](max) NULL,
    [DriversLicenseId] [int] NOT NULL,
    [DriversLicenseIssuingCountry] [nvarchar](max) NULL,
    [EffectiveStartDate] [datetime2](7) NOT NULL,
    [Ethnicity] [nvarchar](max) NULL,
    [HomeFaxAreaCode] [nvarchar](max) NULL,
    [HomeFaxCountryCode] [nvarchar](max) NULL,
    [HomeFaxExtension] [nvarchar](max) NULL,
    [HomeFaxLegislationCode] [nvarchar](max) NULL,
    [HomeFaxNumber] [nvarchar](max) NULL,
    [HomePhoneAreaCode] [nvarchar](max) NULL,
    [HomePhoneCountryCode] [nvarchar](max) NULL,
    [HomePhoneExtension] [nvarchar](max) NULL,
    [HomePhoneLegislationCode] [nvarchar](max) NULL,
    [HomePhoneNumber] [nvarchar](max) NULL,
    [Honors] [nvarchar](max) NULL,
    [LastUpdateDate] [datetime2](7) NOT NULL,
    [LegalEntityId] [int] NOT NULL,
    [LicenseNumber] [nvarchar](max) NULL,
    [MaritalStatus] [nvarchar](max) NULL,
    [MilitaryVetStatus] [nvarchar](max) NULL,
    [NameSuffix] [nvarchar](max) NULL,
    [NationalId] [nvarchar](max) NULL,
    [NationalIdCountry] [nvarchar](max) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED
(
    [EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
USE [EmployeeDB]
GO
/****** Object:  Table [dbo].[Assignments]    Script Date: 02-08-2022 18:15:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assignments](
    [AssignmentId] [int] IDENTITY(1,1) NOT NULL,
    [ActionCode] [nvarchar](max) NULL,
    [ActionReasonCode] [nvarchar](max) NULL,
    [ActualTerminationDate] [datetime2](7) NOT NULL,
    [AssignmentCategory] [nvarchar](max) NULL,
    [AssignmentName] [nvarchar](max) NULL,
    [AssignmentNumber] [nvarchar](max) NULL,
    [AssignmentProjectedEndDate] [datetime2](7) NOT NULL,
    [AssignmentStatus] [nvarchar](max) NULL,
    [AssignmentStatusTypeId] [int] NOT NULL,
    [BusinessUnitId] [int] NOT NULL,
    [CreationDate] [datetime2](7) NOT NULL,
    [DefaultExpenseAccount] [nvarchar](max) NULL,
    [DepartmentId] [int] NOT NULL,
    [EffectiveEndDate] [datetime2](7) NOT NULL,
    [EffectiveStartDate] [datetime2](7) NOT NULL,
    [EndTime] [nvarchar](max) NULL,
    [Frequency] [nvarchar](max) NULL,
    [FullPartTime] [nvarchar](max) NULL,
    [GradeId] [int] NOT NULL,
    [GradeLadderId] [int] NOT NULL,
    [JobId] [int] NOT NULL,
    [LastUpdateDate] [datetime2](7) NOT NULL,
    [LegalEntityId] [int] NOT NULL,
    [LocationId] [int] NOT NULL,
    [ManagerAssignmentId] [int] NOT NULL,
    [ManagerId] [int] NOT NULL,
    [EmployeeId] [int] NOT NULL,
 CONSTRAINT [PK_Assignments] PRIMARY KEY CLUSTERED
(
    [AssignmentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Assignments]  WITH CHECK ADD  CONSTRAINT [FK_Assignments_Employees_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([EmployeeID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Assignments] CHECK CONSTRAINT [FK_Assignments_Employees_EmployeeId]
GO