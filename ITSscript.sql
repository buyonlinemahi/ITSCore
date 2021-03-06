USE [master]
GO
/****** Object:  Database [ITS]    Script Date: 21-02-2020 10:30:35 ******/
CREATE DATABASE [ITS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ITS', FILENAME = N'E:\SQL_Database\ITS.mdf' , SIZE = 458752KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ITS_log', FILENAME = N'E:\SQL_Database\ITS.ldf' , SIZE = 1964480KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ITS] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ITS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ITS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ITS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ITS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ITS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ITS] SET ARITHABORT OFF 
GO
ALTER DATABASE [ITS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ITS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ITS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ITS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ITS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ITS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ITS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ITS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ITS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ITS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ITS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ITS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ITS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ITS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ITS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ITS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ITS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ITS] SET RECOVERY FULL 
GO
ALTER DATABASE [ITS] SET  MULTI_USER 
GO
ALTER DATABASE [ITS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ITS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ITS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ITS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ITS] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ITS', N'ON'
GO
USE [ITS]
GO
/****** Object:  User [VSAINDIA\Developers_JAL]    Script Date: 21-02-2020 10:30:35 ******/
CREATE USER [VSAINDIA\Developers_JAL] FOR LOGIN [VSAINDIA\Developers_JAL]
GO
/****** Object:  User [uttam]    Script Date: 21-02-2020 10:30:35 ******/
CREATE USER [uttam] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [VSAINDIA\Developers_JAL]
GO
ALTER ROLE [db_owner] ADD MEMBER [uttam]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [uttam]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [uttam]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [uttam]
GO
/****** Object:  Schema [global]    Script Date: 21-02-2020 10:30:35 ******/
CREATE SCHEMA [global]
GO
/****** Object:  Schema [lookup]    Script Date: 21-02-2020 10:30:35 ******/
CREATE SCHEMA [lookup]
GO
/****** Object:  Schema [Practitioner]    Script Date: 21-02-2020 10:30:35 ******/
CREATE SCHEMA [Practitioner]
GO
/****** Object:  Schema [referrer]    Script Date: 21-02-2020 10:30:35 ******/
CREATE SCHEMA [referrer]
GO
/****** Object:  Schema [supplier]    Script Date: 21-02-2020 10:30:35 ******/
CREATE SCHEMA [supplier]
GO
/****** Object:  UserDefinedFunction [dbo].[SplitString]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	 CREATE FUNCTION [dbo].[SplitString]
(    
      @Input NVARCHAR(MAX),
      @Character CHAR(1)
)
RETURNS @Output TABLE (
      Item NVARCHAR(1000)
)
AS
BEGIN
      DECLARE @StartIndex INT, @EndIndex INT
 
      SET @StartIndex = 1
      IF SUBSTRING(@Input, LEN(@Input) - 1, LEN(@Input)) <> @Character
      BEGIN
            SET @Input = @Input + @Character
      END
 
      WHILE CHARINDEX(@Character, @Input) > 0
      BEGIN
            SET @EndIndex = CHARINDEX(@Character, @Input)
           
            INSERT INTO @Output(Item)
            SELECT SUBSTRING(@Input, @StartIndex, @EndIndex - 1)
           
            SET @Input = SUBSTRING(@Input, @EndIndex + 1, LEN(@Input))
      END
 
      RETURN
END

GO
/****** Object:  UserDefinedFunction [global].[fnSplitString]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE FUNCTION [global].[fnSplitString] 
( 
    @string NVARCHAR(MAX), 
    @delimiter CHAR(1) 
) 
RETURNS @output TABLE(splitdata NVARCHAR(MAX) 
) 
BEGIN 
    DECLARE @start INT, @end INT 
    SELECT @start = 1, @end = CHARINDEX(@delimiter, @string) 
    WHILE @start < LEN(@string) + 1 BEGIN 
        IF @end = 0  
            SET @end = LEN(@string) + 1
       
        INSERT INTO @output (splitdata)  
        VALUES(SUBSTRING(@string, @start, @end - @start)) 
        SET @start = @end + 1 
        SET @end = CHARINDEX(@delimiter, @string, @start)
        
    END 
    RETURN 
END
GO
/****** Object:  UserDefinedFunction [global].[Get_CaseNumberByTreatmentTypeIDAndCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [global].[Get_CaseNumberByTreatmentTypeIDAndCaseID] 
(
	@CaseID Int,	
	@TreatmentTypeID Int	
)
Returns Varchar(50)
As
Begin
	Declare @CaseNumberValue Varchar(50)	
	Declare @OldCaseNumberValue Int
	Declare @OldCNValue Varchar(50)
	
	Set @OldCNValue = isnull((Select Top 1 CaseNumber From Global.Cases Where TreatmentTypeID = @TreatmentTypeID and CaseID < @CaseID Order by CaseID Desc),'20000')
	Set @OldCaseNumberValue = (Select Top 1 * From Global.fnSplitString(@OldCNValue,'-' ))
	
	If ( @OldCaseNumberValue < 20000)
	Begin
		SET @CaseNumberValue = '20000'	
	End
	Else
	Begin
		SET @CaseNumberValue = 	@OldCaseNumberValue + 1 
	End
	SET @CaseNumberValue = @CaseNumberValue +'-INN-'+  (Select TreatmentTypeAbbreviation From lookup.TreatmentTypes WHERE TreatmentTypeID = @TreatmentTypeID)
	
	/* Case          When @TreatmentTypeID = 1  Then 'PHY'         When @TreatmentTypeID = 2  Then 'CHI'         When @TreatmentTypeID = 3  Then 'OST'         When @TreatmentTypeID = 4  Then 'CPSY'
         When @TreatmentTypeID = 5  Then 'EMDR'         When @TreatmentTypeID = 6  Then 'CBT'         When @TreatmentTypeID = 7  Then 'TVA'		 When @TreatmentTypeID = 8  Then 'FFA'
		 When @TreatmentTypeID = 9  Then 'MS'		 When @TreatmentTypeID = 10 Then 'CTS'		 When @TreatmentTypeID = 11 Then 'US'		 When @TreatmentTypeID = 12 Then 'XR'
		 When @TreatmentTypeID = 13 Then 'TA'		 When @TreatmentTypeID = 14 Then 'SR'		 When @TreatmentTypeID = 15 Then 'HS'		 When @TreatmentTypeID = 16 Then 'ADL'
		 When @TreatmentTypeID = 17 Then 'ADW'		 When @TreatmentTypeID = 18 Then 'CC'		 When @TreatmentTypeID = 19 Then 'CNS'		 When @TreatmentTypeID = 20 Then 'CPA'
		 When @TreatmentTypeID = 21 Then 'CA'		 When @TreatmentTypeID = 22 Then 'CTS-1'		 When @TreatmentTypeID = 23 Then 'CTS-2'		 When @TreatmentTypeID = 24 Then 'DPC'
		 When @TreatmentTypeID = 25 Then 'DSEA'		 When @TreatmentTypeID = 26 Then 'DA'		 When @TreatmentTypeID = 27 Then 'D&AT'		 When @TreatmentTypeID = 28 Then 'DDA'
		 When @TreatmentTypeID = 29 Then 'EIT'		 When @TreatmentTypeID = 30 Then 'EA'		 When @TreatmentTypeID = 31 Then 'EA-AM'		 When @TreatmentTypeID = 32 Then 'FCEC'
		 When @TreatmentTypeID = 33 Then 'FCE'		 When @TreatmentTypeID = 34 Then 'FCE/VR'		 When @TreatmentTypeID = 35 Then 'HAVs1'		 When @TreatmentTypeID = 36 Then 'HAVs4'
		 When @TreatmentTypeID = 37 Then 'HP'		 When @TreatmentTypeID = 38 Then 'HSAF2F'		 When @TreatmentTypeID = 39 Then 'HSAO'		 When @TreatmentTypeID = 40 Then 'HSAT'
		 When @TreatmentTypeID = 41 Then 'HP-POA'		 When @TreatmentTypeID = 42 Then 'Ill-HRA'		 When @TreatmentTypeID = 43 Then 'Imm'		 When @TreatmentTypeID = 44 Then 'IME'
		 When @TreatmentTypeID = 45 Then 'MR'		 When @TreatmentTypeID = 46 Then 'INA'		 When @TreatmentTypeID = 47 Then 'IT'		 When @TreatmentTypeID = 48 Then 'JDA'
		 When @TreatmentTypeID = 49 Then 'JSP'		 When @TreatmentTypeID = 50 Then 'MRCT'		 When @TreatmentTypeID = 51 Then 'MRF2F'		 When @TreatmentTypeID = 52 Then 'MR'
		 When @TreatmentTypeID = 53 Then 'MHFAT'		 When @TreatmentTypeID = 54 Then 'MCR'		 When @TreatmentTypeID = 55 Then 'MI'		 When @TreatmentTypeID = 56 Then 'MRI-1A'
		 When @TreatmentTypeID = 57 Then 'MRI-2A'	     When @TreatmentTypeID = 58 Then 'MRI-3A'	     When @TreatmentTypeID = 59 Then 'MRI-4A'	     When @TreatmentTypeID = 60 Then 'SDT'
      	 When @TreatmentTypeID = 61 Then 'NWA'		 When @TreatmentTypeID = 62 Then 'OHPA'		 When @TreatmentTypeID = 63 Then 'OHPT'		 When @TreatmentTypeID = 64 Then 'PEQ'
		 When @TreatmentTypeID = 65 Then 'PTQ'		 When @TreatmentTypeID = 66 Then 'SC-POA'		 When @TreatmentTypeID = 67 Then 'TINA'		 When @TreatmentTypeID = 68 Then 'TELP'
		 When @TreatmentTypeID = 69 Then 'TSA'		 When @TreatmentTypeID = 70 Then 'TA'		 When @TreatmentTypeID = 71 Then 'VCBTT'		 When @TreatmentTypeID = 72 Then 'VAC'
		 When @TreatmentTypeID = 73 Then 'VAS'		 When @TreatmentTypeID = 74 Then 'VA'		 When @TreatmentTypeID = 75 Then 'VRA'		 When @TreatmentTypeID = 76 Then 'WRP'
		 When @TreatmentTypeID = 77 Then 'WA'		 When @TreatmentTypeID = 78 Then 'XR-1A'		 When @TreatmentTypeID = 79 Then 'XR-2A'		 When @TreatmentTypeID = 80 Then 'XR-3A'
		 When @TreatmentTypeID = 81 Then 'IMR'		 When @TreatmentTypeID = 82 Then 'MHT'		 When @TreatmentTypeID = 83 Then 'C'		 When @TreatmentTypeID = 84 Then 'SA'
		 When @TreatmentTypeID = 85 Then 'WHP'		 When @TreatmentTypeID = 86 Then 'HAV'		 When @TreatmentTypeID = 87 Then 'AT'		 When @TreatmentTypeID = 88 Then 'LFT'
		 When @TreatmentTypeID = 89 Then 'HS'		 When @TreatmentTypeID = 90 Then 'M'		 When @TreatmentTypeID = 91 Then 'DAM'      END
     */
	RETURN @CaseNumberValue
END



GO
/****** Object:  UserDefinedFunction [global].[String_To_Int_Table]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [global].[String_To_Int_Table]
(
         @WorkflowIds VARCHAR(1024)
       , @delimiter CHAR(1) = ',' --Defaults to CSV
)
RETURNS
    @tableList TABLE(
       value INT
       )
AS

BEGIN
   DECLARE @value NVARCHAR(11)
   DECLARE @position INT

   SET @WorkflowIds = LTRIM(RTRIM(@WorkflowIds))+ ','
   SET @position = CHARINDEX(@delimiter, @WorkflowIds, 1)

   IF REPLACE(@WorkflowIds, @delimiter, '') <> ''
   BEGIN
          WHILE @position > 0
          BEGIN 
                 SET @value = LTRIM(RTRIM(LEFT(@WorkflowIds, @position - 1)));
                 INSERT INTO @tableList (value)
                 VALUES (cast(@value as int));
                 SET @WorkflowIds = RIGHT(@WorkflowIds, LEN(@WorkflowIds) - @position);
                 SET @position = CHARINDEX(@delimiter, @WorkflowIds, 1);

          END
   END   
   RETURN
END
GO
/****** Object:  Table [global].[CaseAppointmentDates]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAppointmentDates](
	[CaseID] [int] NOT NULL,
	[AppointmentDateTime] [datetime] NOT NULL,
	[FirstAppointmentOfferedDate] [datetime] NULL,
	[CaseBookIADate] [datetime] NULL,
	[IsCaseBookIADateUsed] [bit] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentCustoms]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentCustoms](
	[CaseAssessmentID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NULL,
	[Message] [nvarchar](max) NULL,
	[IsFurtherTreatment] [bit] NULL,
	[isAccepted] [bit] NULL,
	[AssessmentAuthorisationID] [int] NULL,
	[ReviewAssessmentMessage] [nvarchar](max) NULL,
	[FinalAssessmentMessage] [nvarchar](max) NULL,
 CONSTRAINT [PK_global.CaseAssessmentCustom] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentDetail]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentDetail](
	[CaseAssessmentDetailID] [int] IDENTITY(1,1) NOT NULL,
	[AssessmentServiceID] [int] NOT NULL,
	[CaseID] [int] NOT NULL,
	[HasThePatientHadTimeOff] [bit] NULL,
	[AbsentDetail] [varchar](500) NULL,
	[AbsentPeriod] [int] NULL,
	[AbsentPeriodDurationID] [int] NULL,
	[HasThePatientReturnedToWork] [bit] NULL,
	[PatientImpactOnWorkID] [int] NOT NULL,
	[PatientWorkstatusID] [int] NOT NULL,
	[PatientRecommendedTreatmentSessions] [int] NOT NULL,
	[PatientRecommendedTreatmentSessionsDetail] [varchar](max) NULL,
	[PatientTreatmentPeriod] [int] NOT NULL,
	[PatientTreatmentPeriodDetail] [varchar](500) NULL,
	[PatientTreatmentPeriodDurationID] [int] NULL,
	[IsFurtherTreatmentRecommended] [bit] NULL,
	[PatientLevelOfRecoveryID] [int] NOT NULL,
	[SessionsPatientAttended] [int] NOT NULL,
	[DatesOfSessionAttended] [varchar](max) NULL,
	[SessionsPatientFailedToAttend] [int] NOT NULL,
	[FollowingTreatmentPatientLevelOfRecoveryID] [int] NULL,
	[IsFurtherInvestigationOrOnwardReferralRequired] [bit] NULL,
	[FurtherInvestigationOrOnwardReferral] [varchar](max) NULL,
	[EvidenceOfTreatmentRecommendations] [varchar](max) NULL,
	[AdditionalInformation] [varchar](max) NULL,
	[HasCompliedHomeExerciseProgramme] [bit] NULL,
	[AssessmentDate] [date] NOT NULL,
	[PractitionerID] [int] NULL,
	[EvidenceOfClinicalReasoning] [varchar](max) NULL,
	[TreatmentPeriodTypeID] [int] NULL,
	[PatientDateOfReturn] [datetime] NULL,
	[PatientRecommendationReturn] [varchar](max) NULL,
	[IsPatientReturnToPreInjuryDuties] [bit] NULL,
	[PatientPreInjuryDutiesDate] [datetime] NULL,
	[MainFactors] [varchar](max) NULL,
 CONSTRAINT [PK_CaseAssessmentDetail] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentDetailHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentDetailHistory](
	[CaseAssessmentDetailHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[AssessmentServiceID] [int] NOT NULL,
	[CaseID] [int] NOT NULL,
	[HasThePatientHadTimeOff] [bit] NULL,
	[AbsentDetail] [varchar](500) NULL,
	[AbsentPeriod] [int] NOT NULL,
	[AbsentPeriodDurationID] [int] NULL,
	[HasThePatientReturnedToWork] [bit] NULL,
	[PatientImpactOnWorkID] [int] NOT NULL,
	[PatientWorkstatusID] [int] NOT NULL,
	[PatientRecommendedTreatmentSessions] [int] NOT NULL,
	[PatientRecommendedTreatmentSessionsDetail] [varchar](max) NULL,
	[PatientTreatmentPeriod] [int] NOT NULL,
	[PatientTreatmentPeriodDetail] [varchar](500) NULL,
	[PatientTreatmentPeriodDurationID] [int] NULL,
	[IsFurtherTreatmentRecommended] [bit] NULL,
	[PatientLevelOfRecoveryID] [int] NOT NULL,
	[SessionsPatientAttended] [int] NOT NULL,
	[DatesOfSessionAttended] [varchar](max) NULL,
	[SessionsPatientFailedToAttend] [int] NOT NULL,
	[FollowingTreatmentPatientLevelOfRecoveryID] [int] NULL,
	[IsFurtherInvestigationOrOnwardReferralRequired] [bit] NULL,
	[FurtherInvestigationOrOnwardReferral] [varchar](max) NULL,
	[EvidenceOfTreatmentRecommendations] [varchar](max) NULL,
	[AdditionalInformation] [varchar](max) NULL,
	[HasCompliedHomeExerciseProgramme] [bit] NULL,
	[CaseAssessmentDetailID] [int] NOT NULL,
	[AssessmentDate] [date] NOT NULL,
	[PractitionerID] [int] NULL,
	[TreatmentPeriodTypeID] [int] NULL,
	[PatientDateOfReturn] [datetime] NULL,
	[PatientRecommendationReturn] [varchar](max) NULL,
	[IsPatientReturnToPreInjuryDuties] [bit] NULL,
	[PatientPreInjuryDutiesDate] [datetime] NULL,
	[MainFactors] [varchar](max) NULL,
 CONSTRAINT [PK_CaseAssessmentDetailHistory] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentDetailHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentHistory](
	[CaseAssessmentHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[AssessmentServiceID] [int] NOT NULL,
	[HasPatientConsentForm] [bit] NULL,
	[IncidentAndDiagnosisDescription] [varchar](max) NOT NULL,
	[NeuralSymptomDescription] [varchar](max) NULL,
	[PreExistingConditionDescription] [varchar](max) NULL,
	[IsPatientUndergoingTreatment] [bit] NULL,
	[IsPatientTakingMedication] [bit] NULL,
	[PatientRequiresFurtherInvestigation] [bit] NULL,
	[FactorsAffectingTreatmentDescription] [varchar](max) NULL,
	[PatientOccupation] [varchar](150) NULL,
	[WasPatientWorkingAtTheTimeOfTheAccident] [bit] NULL,
	[IsPatientSufferingFinancialLoss] [bit] NULL,
	[AnticipatedDateOfDischarge] [datetime] NULL,
	[HasPatientHomeExerciseProgramme] [bit] NULL,
	[HasPatientPastSymptoms] [bit] NULL,
	[AssessmentAuthorisationID] [int] NOT NULL,
	[AuthorisationDetail] [varchar](max) NULL,
	[IsAccepted] [bit] NOT NULL,
	[IsPatientDischarge] [bit] NULL,
	[DeniedMessage] [varchar](max) NULL,
	[UserID] [int] NOT NULL,
	[HasYellowFlags] [bit] NULL,
	[HasRedFlags] [bit] NULL,
	[PatientRoleID] [int] NOT NULL,
	[RelevantTestUndertaken] [varchar](max) NULL,
 CONSTRAINT [PK_CaseAssessmentHistory] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentPatientImpactHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentPatientImpactHistory](
	[CaseAssessmentPatientImpactHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientImpactID] [int] NOT NULL,
	[PatientImpactValueID] [int] NOT NULL,
	[CaseAssessmentDetailHistoryID] [int] NOT NULL,
	[Comment] [varchar](max) NULL,
 CONSTRAINT [PK_CaseAssessmentPatientImpactHistory] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentPatientImpactHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentPatientImpacts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentPatientImpacts](
	[CaseAssessmentPatientImpactID] [int] IDENTITY(1,1) NOT NULL,
	[PatientImpactID] [int] NOT NULL,
	[PatientImpactValueID] [int] NOT NULL,
	[Comment] [varchar](max) NULL,
	[CaseAssessmentDetailID] [int] NOT NULL,
 CONSTRAINT [PK_CaseAssessmentPatientImpacts] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentPatientImpactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentPatientInjuries]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentPatientInjuries](
	[CaseAssessmentPatientInjuryID] [int] IDENTITY(1,1) NOT NULL,
	[AffectedArea] [varchar](500) NULL,
	[Score] [varchar](10) NOT NULL,
	[Restriction] [varchar](500) NULL,
	[CaseAssessmentDetailID] [int] NOT NULL,
	[SymptomDescriptionID] [int] NULL,
	[StrengthTestingID] [int] NULL,
	[AffectedAreaID] [int] NULL,
	[RestrictionRangeID] [int] NULL,
	[OtherSymptomDesciption] [varchar](max) NULL,
 CONSTRAINT [PK_CaseAssessmentPatientInjuries] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentPatientInjuryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentPatientInjuryHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentPatientInjuryHistory](
	[CaseAssessmentPatientInjuryHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[AffectedArea] [varchar](500) NULL,
	[Score] [varchar](10) NOT NULL,
	[Restriction] [varchar](500) NULL,
	[CaseAssessmentDetailHistoryID] [int] NOT NULL,
	[SymptomDescriptionID] [int] NULL,
	[StrengthTestingID] [int] NULL,
	[AffectedAreaID] [int] NULL,
	[RestrictionRangeID] [int] NULL,
	[OtherSymptomDesciption] [varchar](max) NULL,
 CONSTRAINT [PK_CaseAssessmentPatientInjuryHistory] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentPatientInjuryHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentProposedTreatmentMethodHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentProposedTreatmentMethodHistory](
	[CaseAssessmentProposedTreatmentMethodHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[CaseAssessmentHistoryID] [int] NOT NULL,
	[CaseID] [int] NOT NULL,
	[ProposedTreatmentMethodID] [int] NOT NULL,
 CONSTRAINT [PK_CaseAssessmentTreatmentMethodHistory] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentProposedTreatmentMethodHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentProposedTreatmentMethods]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentProposedTreatmentMethods](
	[CaseID] [int] NOT NULL,
	[ProposedTreatmentMethodID] [int] NOT NULL,
 CONSTRAINT [PK_CaseAssessmentProposedTreatmentMethods] PRIMARY KEY CLUSTERED 
(
	[CaseID] ASC,
	[ProposedTreatmentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessmentRatings]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessmentRatings](
	[CaseAssessmentRatingID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[AssessmentServiceID] [int] NOT NULL,
	[Rating] [decimal](5, 2) NOT NULL,
	[RatingDate] [datetime] NOT NULL,
 CONSTRAINT [PK_CaseAssessmentRatings] PRIMARY KEY CLUSTERED 
(
	[CaseAssessmentRatingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseAssessments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseAssessments](
	[CaseID] [int] NOT NULL,
	[AssessmentServiceID] [int] NOT NULL,
	[HasPatientConsentForm] [bit] NULL,
	[IncidentAndDiagnosisDescription] [varchar](max) NULL,
	[NeuralSymptomDescription] [varchar](max) NULL,
	[RelevantTestUndertaken] [varchar](max) NULL,
	[PreExistingConditionDescription] [varchar](max) NULL,
	[IsPatientUndergoingTreatment] [bit] NULL,
	[IsPatientTakingMedication] [bit] NULL,
	[PatientRequiresFurtherInvestigation] [bit] NULL,
	[FactorsAffectingTreatmentDescription] [varchar](max) NULL,
	[PatientOccupation] [varchar](150) NULL,
	[PatientRoleID] [int] NOT NULL,
	[WasPatientWorkingAtTheTimeOfTheAccident] [bit] NULL,
	[IsPatientSufferingFinancialLoss] [bit] NULL,
	[AnticipatedDateOfDischarge] [datetime] NULL,
	[HasPatientHomeExerciseProgramme] [bit] NULL,
	[HasPatientPastSymptoms] [bit] NULL,
	[AssessmentAuthorisationID] [int] NULL,
	[AuthorisationDetail] [varchar](max) NULL,
	[IsAccepted] [bit] NOT NULL,
	[IsPatientDischarge] [bit] NULL,
	[DeniedMessage] [varchar](max) NULL,
	[HasYellowFlags] [bit] NULL,
	[HasRedFlags] [bit] NULL,
	[UserID] [int] NOT NULL,
	[IsSaved] [bit] NULL,
 CONSTRAINT [PK_CaseAssessments] PRIMARY KEY CLUSTERED 
(
	[CaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseBespokeServicePricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseBespokeServicePricing](
	[CaseBespokeServiceID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[TreatmentCategoryBespokeServiceID] [int] NOT NULL,
	[ReferrerPrice] [money] NOT NULL,
	[SupplierPrice] [money] NOT NULL,
	[DateOfService] [datetime] NULL,
	[PatientDidNotAttend] [bit] NULL,
	[WasAbandoned] [bit] NULL,
	[IsComplete]  AS (CONVERT([bit],case when [WasAbandoned] IS NOT NULL OR [DateOfService] IS NOT NULL OR [PatientDidNotAttend] IS NOT NULL then (1) else (0) end,(0))),
 CONSTRAINT [PK_CaseBespokeServicePricing] PRIMARY KEY CLUSTERED 
(
	[CaseBespokeServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseCommunicationHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseCommunicationHistory](
	[CaseCommunicationHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[SentTo] [varchar](300) NOT NULL,
	[SentCC] [varchar](300) NULL,
	[Subject] [varchar](max) NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[UserID] [int] NOT NULL,
	[DateAdded] [date] NOT NULL,
	[UploadPath] [varchar](100) NULL,
 CONSTRAINT [PK_CaseCommunicationHistory] PRIMARY KEY CLUSTERED 
(
	[CaseCommunicationHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseContacts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseContacts](
	[CaseContactID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_CaseContacts] PRIMARY KEY CLUSTERED 
(
	[CaseContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseDocuments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseDocuments](
	[CaseDocumentID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[DocumentTypeID] [int] NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[DocumentName] [varchar](max) NOT NULL,
	[UploadPath] [varchar](max) NOT NULL,
	[UserID] [int] NULL,
	[SupplierCheck] [bit] NULL,
	[ReferrerCheck] [bit] NULL,
 CONSTRAINT [PK_CaseDocuments] PRIMARY KEY CLUSTERED 
(
	[CaseDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseHistory](
	[CaseHistoryID] [int] IDENTITY(2128,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[EventDate] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
	[EventDescription] [varchar](max) NOT NULL,
	[EventTypeID] [int] NOT NULL,
 CONSTRAINT [PK_CaseHistory] PRIMARY KEY CLUSTERED 
(
	[CaseHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseNotes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseNotes](
	[CaseNoteID] [int] IDENTITY(1,1) NOT NULL,
	[Note] [varchar](max) NOT NULL,
	[CaseID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[DateAdded] [date] NOT NULL,
	[WorkflowID] [int] NULL,
 CONSTRAINT [PK_CaseNotes] PRIMARY KEY CLUSTERED 
(
	[CaseNoteID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CasePatientContactAttempts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CasePatientContactAttempts](
	[CasePatientContactAttemptID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[CaseID] [int] NOT NULL,
	[ContactAttemptDate] [date] NOT NULL,
 CONSTRAINT [PK_CasePatientContactAttempts] PRIMARY KEY CLUSTERED 
(
	[CasePatientContactAttemptID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseReferrerAssignedUsers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseReferrerAssignedUsers](
	[CaseReferrerAssignedUserID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[CaseID] [int] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_ReferrerAssignedUsers] PRIMARY KEY CLUSTERED 
(
	[CaseReferrerAssignedUserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[Cases]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[Cases](
	[CaseID] [int] IDENTITY(1,1) NOT NULL,
	[PatientID] [int] NOT NULL,
	[ReferrerID] [int] NOT NULL,
	[ReferrerProjectID] [int] NULL,
	[CaseNumber] [varchar](100) NULL,
	[ReferrerProjectTreatmentID] [int] NULL,
	[TreatmentTypeID] [int] NULL,
	[CaseReferrerReferenceNumber] [varchar](50) NULL,
	[CaseSpecialInstruction] [varchar](max) NULL,
	[CaseReferrerDueDate] [datetime] NULL,
	[CaseSubmittedDate] [datetime] NOT NULL,
	[SupplierID] [int] NULL,
	[WorkflowID] [int] NOT NULL,
	[PatientContactDate] [date] NULL,
	[PatientContactedByInternalUser] [bit] NOT NULL,
	[PatientContactNotes] [varchar](max) NULL,
	[IsTreatmentRequired] [bit] NOT NULL,
	[IsTriage] [bit] NOT NULL,
	[InvoiceDate] [datetime] NULL,
	[InjuryType] [varchar](50) NULL,
	[IsCustom] [bit] NULL,
	[SendInvoiceTo] [varchar](20) NULL,
	[SendInvoiceName] [varchar](50) NULL,
	[SendInvoiceEmail] [varchar](50) NULL,
	[ReferrerAssignedUser] [int] NULL,
	[SupplierAssignedUser] [int] NULL,
	[InnovateNote] [varchar](max) NULL,
	[OfficeLocationID] [int] NULL,
	[EmployeeDetailID] [int] NULL,
	[DrugTestID] [int] NULL,
	[JobDemandID] [int] NULL,
	[IsNewPolicyTypeID] [int] NULL,
	[NewPolicyReferenceNumber] [varchar](50) NULL,
 CONSTRAINT [PK_Supplier_Case] PRIMARY KEY CLUSTERED 
(
	[CaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseTreatmentPricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseTreatmentPricing](
	[CaseTreatmentPricingID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NOT NULL,
	[ReferrerPricingID] [int] NOT NULL,
	[ReferrerPrice] [money] NOT NULL,
	[DateOfService] [datetime] NULL,
	[PatientDidNotAttend] [bit] NULL,
	[WasAbandoned] [bit] NULL,
	[SupplierPrice] [money] NOT NULL,
	[Quantity] [int] NULL,
	[SupplierPriceID] [int] NOT NULL,
	[IsComplete]  AS (CONVERT([bit],case when [WasAbandoned] IS NOT NULL OR [DateOfService] IS NOT NULL OR [PatientDidNotAttend] IS NOT NULL then (1) else (0) end,(0))),
	[AuthorizationStatus] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
	[PatientDidNotAttendDate] [datetime] NULL,
	[PreviousSupplierPriceID] [int] NULL,
	[PreviousReferrerPricingID] [int] NULL,
 CONSTRAINT [PK_CaseTreatmentPricing] PRIMARY KEY CLUSTERED 
(
	[CaseTreatmentPricingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[CaseVAT]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[CaseVAT](
	[CaseID] [int] NOT NULL,
	[VAT] [decimal](5, 2) NOT NULL,
 CONSTRAINT [PK_CaseVAT_1] PRIMARY KEY CLUSTERED 
(
	[CaseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[DrugTests]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[DrugTests](
	[DrugTestID] [int] IDENTITY(1,1) NOT NULL,
	[IsDrugAndAlcohalTest] [bit] NULL,
	[NetworkRailStandardApplicableID] [int] NULL,
	[ReasonForReferralID] [int] NULL,
	[IsSentinalUpdating] [bit] NULL,
	[SentinalNumber] [varchar](100) NULL,
	[AdditionalTestID] [int] NULL,
	[AdditionalTestOther] [varchar](max) NULL,
 CONSTRAINT [PK_DrugTests] PRIMARY KEY CLUSTERED 
(
	[DrugTestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[EmployeeDetails]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[EmployeeDetails](
	[EmployeeDetailID] [int] IDENTITY(1,1) NOT NULL,
	[UsualJobRoleTypeID] [int] NULL,
	[UsualHours] [varchar](20) NULL,
	[CurrentRoleTypeID] [int] NULL,
	[CurrentHours] [varchar](20) NULL,
	[DateofFirstAbsence] [datetime] NULL,
	[OfficeLocation] [varchar](50) NULL,
	[TypeofIllness] [varchar](200) NULL,
	[PreRelatedAbsence] [varchar](200) NULL,
	[MedicationOrTreatment] [varchar](200) NULL,
	[EAP] [varchar](200) NULL,
	[IllnessEmpAbilityToPerform] [varchar](200) NULL,
	[CurrentlyAbsentFromWorkID] [int] NULL,
	[AgileWorkerID] [int] NULL,
	[OfficeBasedID] [int] NULL,
	[LineManager] [varchar](50) NULL,
	[CostCentreDivision] [varchar](50) NULL,
	[EmployeeNumber] [varchar](20) NULL,
	[AdditionalQuestion1] [varchar](max) NULL,
	[AdditionalQuestion2] [varchar](max) NULL,
	[FurtherQuestion1] [varchar](max) NULL,
	[FurtherQuestion2] [varchar](max) NULL,
	[NationalINSNumber] [varchar](20) NULL,
	[jobTitle] [varchar](25) NULL,
 CONSTRAINT [PK_EmploueeDetails] PRIMARY KEY CLUSTERED 
(
	[EmployeeDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[Employments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[Employments](
	[EmploymentId] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentTypeId] [int] NULL,
	[CompanyName] [varchar](25) NULL,
	[JobRole] [varchar](40) NULL,
	[Address] [varchar](40) NULL,
	[ContactName] [varchar](25) NULL,
	[PrimaryPhone] [varchar](25) NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Employments_1] PRIMARY KEY CLUSTERED 
(
	[EmploymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[InjuredPartyRepresentatives]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[InjuredPartyRepresentatives](
	[InjuredID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[ReferralID] [int] NULL,
	[Tel1] [varchar](16) NULL,
	[Tel2] [varchar](16) NULL,
	[Address] [varchar](300) NULL,
	[PostCode] [varchar](12) NULL,
	[Email] [varchar](50) NULL,
	[Relationship] [varchar](50) NULL,
 CONSTRAINT [PK_InjuredPartyRepresentative] PRIMARY KEY CLUSTERED 
(
	[InjuredID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[InvoiceCollectionAction]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[InvoiceCollectionAction](
	[InvoiceCollectionActionID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[Action] [varchar](max) NULL,
	[UserId] [int] NOT NULL,
	[FollowUpDate] [date] NOT NULL,
	[DateofAction] [date] NOT NULL,
 CONSTRAINT [PK_InvoiceCollectionAction] PRIMARY KEY CLUSTERED 
(
	[InvoiceCollectionActionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[InvoicePayment]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[InvoicePayment](
	[InvoicePaymentID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceID] [int] NOT NULL,
	[Payment] [money] NOT NULL,
	[AdjustedPayment] [money] NOT NULL,
	[CheckNumber] [varchar](max) NULL,
	[BACS] [varchar](max) NULL,
	[UserId] [int] NOT NULL,
	[InvoicePaymentDate] [date] NOT NULL,
 CONSTRAINT [PK_InvoicePayment] PRIMARY KEY CLUSTERED 
(
	[InvoicePaymentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[Invoices]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[Invoices](
	[InvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[InvoiceNumber] [varchar](200) NOT NULL,
	[Amount] [money] NOT NULL,
	[CaseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[InvoiceDate] [date] NOT NULL,
	[IsComplete] [bit] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[JobDemands]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[JobDemands](
	[JobDemandID] [int] IDENTITY(1,1) NOT NULL,
	[IsJobDemand] [bit] NULL,
	[IsStanding] [bit] NULL,
	[IsWalking] [bit] NULL,
	[IsWorkATHeightOrClimb] [bit] NULL,
	[IsExtendedOrProlonged] [bit] NULL,
	[IsVocationalDriving] [bit] NULL,
	[IsDrivingLGVOrPCVs] [bit] NULL,
	[IsDrivingForkliftTrucks] [bit] NULL,
	[IsWorkWithChemials] [bit] NULL,
	[IsWorkBiologicalOrChemical] [bit] NULL,
	[IsWorkWithSkinIrritants] [bit] NULL,
	[IsWorkWithDengerousMachinery] [bit] NULL,
	[IsNightWork] [bit] NULL,
	[IsShiftWork] [bit] NULL,
	[IsWorkInConfinedSpaces] [bit] NULL,
	[IsWorkWithDustOrFumes] [bit] NULL,
	[IsLiftOrCarryHeavyItems] [bit] NULL,
	[IsWorkWithComputerOrScreens] [bit] NULL,
	[IsWorkTowardsTagetOrPressuredsituation] [bit] NULL,
	[IsWorkWithAdultOrChildren] [bit] NULL,
	[IsHealthCareWorker] [bit] NULL,
	[IsOccasionalOverseasTravel] [bit] NULL,
	[IsOutsideWork] [bit] NULL,
	[IsNoisedHarzardArea] [bit] NULL,
	[IsHandlingFood] [bit] NULL,
	[FreeText] [varchar](200) NULL,
 CONSTRAINT [PK_JobDemands] PRIMARY KEY CLUSTERED 
(
	[JobDemandID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[PasswordHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[PasswordHistory](
	[PasswordHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[Password] [varchar](70) NULL,
	[CreatedOn] [datetime] NULL,
 CONSTRAINT [PK_PasswordHistory] PRIMARY KEY CLUSTERED 
(
	[PasswordHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[Patients]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[Patients](
	[PatientID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[FirstName] [varchar](80) NULL,
	[LastName] [varchar](80) NOT NULL,
	[Address] [varchar](300) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[Region] [varchar](50) NOT NULL,
	[PostCode] [varchar](12) NOT NULL,
	[InjuryDate] [date] NOT NULL,
	[BirthDate] [date] NULL,
	[HomePhone] [varchar](16) NULL,
	[WorkPhone] [varchar](16) NULL,
	[MobilePhone] [varchar](20) NULL,
	[GenderID] [int] NOT NULL,
	[Email] [varchar](50) NULL,
	[HasLegalRep] [bit] NOT NULL,
	[SolicitorID] [int] NULL,
	[HasInjuredPartyRepresentative] [int] NULL,
	[InjuredID] [int] NULL,
	[SpecialInstructionNotes] [varchar](max) NULL,
	[PolicyID] [int] NULL,
	[EmploymentID] [int] NULL,
	[PrimaryConditionID] [int] NULL,
	[PolicyOpenDetailID] [int] NULL,
 CONSTRAINT [PK_Patients] PRIMARY KEY CLUSTERED 
(
	[PatientID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[Policies]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[Policies](
	[PolicyID] [int] IDENTITY(1,1) NOT NULL,
	[PolicyTypeId] [int] NULL,
	[TypeCoverId] [int] NULL,
	[PolicyCriteriaId] [int] NULL,
	[RehabProportionateBenefit] [bit] NULL,
	[FitForWorkId] [int] NULL,
	[ReInsuredId] [bit] NULL,
	[ReferenceNo] [varchar](25) NULL,
	[AdmittedId] [int] NULL,
	[BenefitDate] [datetime] NULL,
	[MonthlyValue] [decimal](18, 2) NULL,
	[WeeklyValue] [decimal](18, 2) NULL,
	[EndBenefitDate] [datetime] NULL,
	[NameOfReinsurerID] [int] NULL,
	[PolicyWording] [varchar](max) NULL,
 CONSTRAINT [PK_Policies] PRIMARY KEY CLUSTERED 
(
	[PolicyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[PolicyOpenDetails]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[PolicyOpenDetails](
	[PolicyOpenDetailID] [int] IDENTITY(1,1) NOT NULL,
	[PolicyType] [varchar](25) NULL,
	[TypeCover] [varchar](25) NULL,
	[PolicyCriteria] [varchar](25) NULL,
	[RehabORProportionate] [varchar](25) NULL,
	[FitforWork] [varchar](25) NULL,
	[ReInsured] [varchar](25) NULL,
	[ReferenceNo] [varchar](25) NULL,
	[Admitted] [varchar](25) NULL,
	[OpenBenefitDate] [datetime] NULL,
	[OpenMonthlyValue] [money] NULL,
	[OpenEndBenefitDate] [datetime] NULL,
	[NameofReinsurer] [varchar](25) NULL,
	[OpenPolicyWording] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [global].[PractitionerExpertise]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[PractitionerExpertise](
	[PractitionerExpertiseID] [int] IDENTITY(1,1) NOT NULL,
	[PractitionerID] [int] NOT NULL,
	[AreaofExpertiseID] [int] NOT NULL,
 CONSTRAINT [PK_PractitionerExpertise] PRIMARY KEY CLUSTERED 
(
	[PractitionerExpertiseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[PractitionerRegistrations]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[PractitionerRegistrations](
	[PractitionerRegistrationID] [int] IDENTITY(1,1) NOT NULL,
	[PractitionerID] [int] NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
	[RegistrationTypeID] [int] NULL,
	[RegistrationNumber] [varchar](50) NOT NULL,
	[Qualification] [varchar](100) NOT NULL,
	[QualificationDate] [date] NOT NULL,
	[ExpiryDate] [date] NOT NULL,
	[YearsQualified] [int] NOT NULL,
	[IsActive]  AS (CONVERT([bit],case when getdate()>[ExpiryDate] then (0) else (1) end,(0))),
 CONSTRAINT [PK_PractitionerRegistrations] PRIMARY KEY CLUSTERED 
(
	[PractitionerRegistrationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[Practitioners]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[Practitioners](
	[PractitionerID] [int] IDENTITY(1,1) NOT NULL,
	[PractitionerFirstName] [varchar](50) NOT NULL,
	[PractitionerLastName] [varchar](50) NOT NULL,
	[DateAdded] [date] NOT NULL,
 CONSTRAINT [PK_global.Practitioner] PRIMARY KEY CLUSTERED 
(
	[PractitionerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[Solicitors]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[Solicitors](
	[SolicitorID] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [varchar](50) NULL,
	[Address] [varchar](300) NULL,
	[Phone] [varchar](16) NULL,
	[Email] [varchar](50) NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[PostCode] [varchar](12) NULL,
	[Fax] [varchar](16) NULL,
	[ReferenceNumber] [varchar](16) NULL,
	[City] [nvarchar](100) NULL,
	[Region] [nvarchar](50) NULL,
	[IsReferralUnderJointInstruction] [bit] NULL,
 CONSTRAINT [PK_Solicitors] PRIMARY KEY CLUSTERED 
(
	[SolicitorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[UserProject]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[UserProject](
	[UserProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ReferrerProjectID] [int] NULL,
	[UserID] [int] NULL,
 CONSTRAINT [PK_UserProject] PRIMARY KEY CLUSTERED 
(
	[UserProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [global].[Users]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [global].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Password] [varchar](70) NOT NULL,
	[FirstName] [varchar](30) NULL,
	[LastName] [varchar](30) NULL,
	[UserTypeID] [int] NOT NULL,
	[IsLocked] [bit] NOT NULL,
	[SupplierTypes] [varchar](30) NULL,
	[SupplierID] [int] NULL,
	[ReferrerTypes] [varchar](30) NULL,
	[ReferrerID] [int] NULL,
	[ReferrerLocationID] [int] NULL,
	[Email] [varchar](50) NOT NULL,
	[Fax] [varchar](16) NULL,
	[Telephone] [varchar](16) NULL,
	[LastLoginDate] [datetime] NULL,
	[FailedAttemptCount] [int] NOT NULL,
	[DateAdded] [date] NOT NULL,
	[PasswordExpirationDate] [datetime] NULL,
	[UserSessionID] [varchar](255) NULL,
	[PasswordOTP] [char](6) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[AdditionalTests]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[AdditionalTests](
	[AdditionalTestID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_AdditionalTest] PRIMARY KEY CLUSTERED 
(
	[AdditionalTestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Admitteds]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Admitteds](
	[AdmittedID] [int] IDENTITY(1,1) NOT NULL,
	[AdmittedName] [varchar](50) NULL,
 CONSTRAINT [PK_Admitteds] PRIMARY KEY CLUSTERED 
(
	[AdmittedID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[AffectedAreas]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[AffectedAreas](
	[AffectedAreaID] [int] IDENTITY(1,1) NOT NULL,
	[AffectedAreaDescription] [varchar](100) NULL,
 CONSTRAINT [PK_SideAffected] PRIMARY KEY CLUSTERED 
(
	[AffectedAreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[AreasofExpertise]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[AreasofExpertise](
	[AreasofExpertiseID] [int] NOT NULL,
	[AreasofExpertiseName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AreasofExpertise] PRIMARY KEY CLUSTERED 
(
	[AreasofExpertiseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[AssessmentAuthorisations]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[AssessmentAuthorisations](
	[AssessmentAuthorisationID] [int] IDENTITY(1,1) NOT NULL,
	[AssessmentAuthorisationName] [text] NOT NULL,
 CONSTRAINT [PK_AssessmentAuthorisations] PRIMARY KEY CLUSTERED 
(
	[AssessmentAuthorisationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [lookup].[AssessmentServices]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[AssessmentServices](
	[AssessmentServiceID] [int] NOT NULL,
	[AssessmentServiceName] [varchar](50) NULL,
 CONSTRAINT [PK_AssessmentServices] PRIMARY KEY CLUSTERED 
(
	[AssessmentServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[AssessmentTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[AssessmentTypes](
	[AssessmentTypeID] [int] NOT NULL,
	[AssessmentTypeName] [varchar](10) NULL,
 CONSTRAINT [PK_AssessmentTypes] PRIMARY KEY CLUSTERED 
(
	[AssessmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[BankHolidays]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[BankHolidays](
	[BankHolidayID] [int] IDENTITY(1,1) NOT NULL,
	[BankHolidayName] [varchar](50) NOT NULL,
	[BankHolidayDate] [date] NOT NULL,
 CONSTRAINT [PK_BankHolidays] PRIMARY KEY CLUSTERED 
(
	[BankHolidayID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[BespokeServices]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[BespokeServices](
	[BespokeServiceID] [int] IDENTITY(1,1) NOT NULL,
	[BespokeServiceName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BespokeService] PRIMARY KEY CLUSTERED 
(
	[BespokeServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[CaseStopReasons]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[CaseStopReasons](
	[CaseStopReasonID] [int] NOT NULL,
	[CaseStopReasonName] [varchar](50) NULL,
 CONSTRAINT [PK_CaseStopReasons] PRIMARY KEY CLUSTERED 
(
	[CaseStopReasonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[ComplaintStatus]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[ComplaintStatus](
	[ComplaintStatusID] [int] NOT NULL,
	[ComplaintStatusName] [varchar](50) NULL,
 CONSTRAINT [PK_ComplaintStatus] PRIMARY KEY CLUSTERED 
(
	[ComplaintStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[ComplaintTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[ComplaintTypes](
	[ComplaintTypeID] [int] NOT NULL,
	[ComplaintTypeName] [varchar](50) NULL,
 CONSTRAINT [PK_ComplaintTypes] PRIMARY KEY CLUSTERED 
(
	[ComplaintTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[DelegatedAuthorisation]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[DelegatedAuthorisation](
	[DelegatedAuthorisationID] [int] NOT NULL,
	[DeletegatedAuthorisationName] [varchar](50) NULL,
 CONSTRAINT [PK_DelegatedAuthorisation] PRIMARY KEY CLUSTERED 
(
	[DelegatedAuthorisationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[DelegatedAuthorisationTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[DelegatedAuthorisationTypes](
	[DelegatedAuthorisationTypeID] [int] NOT NULL,
	[DelegatedAuthorisationTypeName] [varchar](50) NULL,
 CONSTRAINT [PK_DelegatedAuthorisationTypes] PRIMARY KEY CLUSTERED 
(
	[DelegatedAuthorisationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[DocumentSetupTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[DocumentSetupTypes](
	[DocumentSetupTypeID] [int] NOT NULL,
	[DocumentSetupTypeName] [varchar](50) NULL,
 CONSTRAINT [PK_DocumentSetupTypes] PRIMARY KEY CLUSTERED 
(
	[DocumentSetupTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[DocumentTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[DocumentTypes](
	[DocumentTypeID] [int] NOT NULL,
	[DocumentTypeName] [varchar](50) NULL,
 CONSTRAINT [PK_DocumentTypes] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Durations]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Durations](
	[DurationID] [int] NOT NULL,
	[DurationName] [varchar](50) NULL,
 CONSTRAINT [PK_Durations] PRIMARY KEY CLUSTERED 
(
	[DurationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[ElRehabs]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[ElRehabs](
	[ElRehabID] [int] IDENTITY(1,1) NOT NULL,
	[ElRehabName] [varchar](50) NULL,
 CONSTRAINT [PK_ElRehabs] PRIMARY KEY CLUSTERED 
(
	[ElRehabID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[EmailSendingOptions]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[EmailSendingOptions](
	[EmailSendingOptionID] [int] NOT NULL,
	[EmailSendingOptionName] [varchar](20) NULL,
 CONSTRAINT [PK_EmailSendingOptions] PRIMARY KEY CLUSTERED 
(
	[EmailSendingOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[EmailTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[EmailTypes](
	[EmailTypeID] [int] NOT NULL,
	[EmailTypeName] [varchar](80) NOT NULL,
	[UserTypeID] [int] NOT NULL,
 CONSTRAINT [PK_EmailTypes] PRIMARY KEY CLUSTERED 
(
	[EmailTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[EmailTypeValues]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[EmailTypeValues](
	[EmailTypeValueID] [int] NOT NULL,
	[EmailTypeValueName] [varchar](20) NULL,
 CONSTRAINT [PK_EmailTypeValues] PRIMARY KEY CLUSTERED 
(
	[EmailTypeValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[EmploymentTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[EmploymentTypes](
	[EmploymentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentTypeName] [varchar](50) NULL,
 CONSTRAINT [PK_Employments] PRIMARY KEY CLUSTERED 
(
	[EmploymentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[EventTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[EventTypes](
	[EventTypeID] [int] NOT NULL,
	[EventTypeName] [varchar](20) NOT NULL,
 CONSTRAINT [PK_EventTypes] PRIMARY KEY CLUSTERED 
(
	[EventTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[FitForWorks]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[FitForWorks](
	[FitforWorkID] [int] IDENTITY(1,1) NOT NULL,
	[FitforWorkName] [varchar](50) NULL,
 CONSTRAINT [PK_FitForWorks] PRIMARY KEY CLUSTERED 
(
	[FitforWorkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Genders]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Genders](
	[GenderID] [int] NOT NULL,
	[GenderName] [varchar](10) NULL,
 CONSTRAINT [PK_Gender] PRIMARY KEY CLUSTERED 
(
	[GenderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Gips]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Gips](
	[GipID] [int] IDENTITY(1,1) NOT NULL,
	[GipName] [varchar](50) NULL,
 CONSTRAINT [PK_Gips] PRIMARY KEY CLUSTERED 
(
	[GipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Iips]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Iips](
	[IipID] [int] IDENTITY(1,1) NOT NULL,
	[IipName] [varchar](50) NULL,
 CONSTRAINT [PK_Iips] PRIMARY KEY CLUSTERED 
(
	[IipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[InjuredRepresentativeOptions]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[InjuredRepresentativeOptions](
	[InjuredRepresentativeOptionID] [int] IDENTITY(1,1) NOT NULL,
	[InjuredRepresentativeOptionName] [varchar](50) NULL,
 CONSTRAINT [PK_InjuredRepresentativeOption] PRIMARY KEY CLUSTERED 
(
	[InjuredRepresentativeOptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[InvoiceMethods]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[InvoiceMethods](
	[InvoiceMethodID] [int] NOT NULL,
	[InvoiceMethodName] [varchar](50) NULL,
 CONSTRAINT [PK_InvoiceMethods] PRIMARY KEY CLUSTERED 
(
	[InvoiceMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[NetworkRailStandardApplicable]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[NetworkRailStandardApplicable](
	[NetworkRailStandardApplicableID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_NetworkRailStandardApplicable] PRIMARY KEY CLUSTERED 
(
	[NetworkRailStandardApplicableID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PatientImpactOnWork]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PatientImpactOnWork](
	[PatientImpactOnWorkID] [int] IDENTITY(1,1) NOT NULL,
	[PatientImpactOnWorkName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PatientImpactOnWork] PRIMARY KEY CLUSTERED 
(
	[PatientImpactOnWorkID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PatientImpacts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PatientImpacts](
	[PatientImpactID] [int] IDENTITY(1,1) NOT NULL,
	[PatientImpactName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PatientImpacts] PRIMARY KEY CLUSTERED 
(
	[PatientImpactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PatientImpactValues]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PatientImpactValues](
	[PatientImpactValueID] [int] IDENTITY(1,1) NOT NULL,
	[PatientImpactValueName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PatientImpactValues] PRIMARY KEY CLUSTERED 
(
	[PatientImpactValueID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PatientLevelOfRecoveries]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PatientLevelOfRecoveries](
	[PatientLevelOfRecoveryID] [int] IDENTITY(1,1) NOT NULL,
	[PatientLevelOfRecoveryName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_PatientLevelOfRecoveries] PRIMARY KEY CLUSTERED 
(
	[PatientLevelOfRecoveryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PatientRoles]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PatientRoles](
	[PatientRoleID] [int] IDENTITY(1,1) NOT NULL,
	[PatientRoleName] [varchar](50) NULL,
 CONSTRAINT [PK_PatientRoles] PRIMARY KEY CLUSTERED 
(
	[PatientRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PatientWorkstatus]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PatientWorkstatus](
	[PatientWorkstatusID] [int] IDENTITY(1,1) NOT NULL,
	[PatientWorkstatusName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PatientWorkStatus] PRIMARY KEY CLUSTERED 
(
	[PatientWorkstatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PolicyCriterias]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PolicyCriterias](
	[PolicyCriteriaID] [int] IDENTITY(1,1) NOT NULL,
	[PolicyCriteriaName] [varchar](50) NULL,
 CONSTRAINT [PK_PolicyCriterias] PRIMARY KEY CLUSTERED 
(
	[PolicyCriteriaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PolicyTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PolicyTypes](
	[PolicyTypeID] [int] IDENTITY(1,1) NOT NULL,
	[PolicyTypeName] [varchar](50) NULL,
 CONSTRAINT [PK_PolicyTypes] PRIMARY KEY CLUSTERED 
(
	[PolicyTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PricingTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PricingTypes](
	[PricingTypeID] [int] NOT NULL,
	[PricingTypeName] [varchar](80) NULL,
 CONSTRAINT [PK_PricingTypes] PRIMARY KEY CLUSTERED 
(
	[PricingTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[PrimaryConditions]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[PrimaryConditions](
	[PrimaryConditionID] [int] IDENTITY(1,1) NOT NULL,
	[PrimaryConditionName] [varchar](100) NULL,
 CONSTRAINT [PK_PrimaryConditions] PRIMARY KEY CLUSTERED 
(
	[PrimaryConditionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[ProposedTreatmentMethods]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[ProposedTreatmentMethods](
	[ProposedTreatmentMethodID] [int] IDENTITY(1,1) NOT NULL,
	[ProposedTreatmentMethodName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_ProposedTreatmentMethods] PRIMARY KEY CLUSTERED 
(
	[ProposedTreatmentMethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[ReasonForReferral]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[ReasonForReferral](
	[ReasonForReferralID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](200) NULL,
 CONSTRAINT [PK_ReasonForReferral] PRIMARY KEY CLUSTERED 
(
	[ReasonForReferralID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[ReferrerDocumentType]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[ReferrerDocumentType](
	[ReferrerDocumentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[ReferrerDocumentTypeDesc] [varchar](50) NULL,
 CONSTRAINT [PK_ReferrerDocumentType] PRIMARY KEY CLUSTERED 
(
	[ReferrerDocumentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[RegistrationTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[RegistrationTypes](
	[RegistrationTypeID] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationTypeName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RegistrationTypes] PRIMARY KEY CLUSTERED 
(
	[RegistrationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Reinsurers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Reinsurers](
	[ReinsurerID] [int] IDENTITY(1,1) NOT NULL,
	[NameOfReinsurer] [varchar](50) NULL,
 CONSTRAINT [PK_Reinsurers] PRIMARY KEY CLUSTERED 
(
	[ReinsurerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[RestrictionRanges]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[RestrictionRanges](
	[RestrictionRangeID] [int] IDENTITY(1,1) NOT NULL,
	[RestrictionRangeDescription] [varchar](100) NULL,
 CONSTRAINT [PK_RestrictionRange] PRIMARY KEY CLUSTERED 
(
	[RestrictionRangeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[RoleTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[RoleTypes](
	[RoleTypeID] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [varchar](10) NULL,
 CONSTRAINT [PK_RoleTypes] PRIMARY KEY CLUSTERED 
(
	[RoleTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[ServiceLevelAgreements]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[ServiceLevelAgreements](
	[ServiceLevelAgreementID] [int] NOT NULL,
	[ServiceLevelAgreementName] [varchar](80) NULL,
 CONSTRAINT [PK_ServiceLevelAgreements] PRIMARY KEY CLUSTERED 
(
	[ServiceLevelAgreementID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Status]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Status](
	[StatusID] [int] NOT NULL,
	[StatusName] [varchar](20) NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[StrengthTestings]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[StrengthTestings](
	[StrengthTestingID] [int] IDENTITY(1,1) NOT NULL,
	[StrengthTestingDescription] [varchar](100) NULL,
 CONSTRAINT [PK_StrenghtTesting] PRIMARY KEY CLUSTERED 
(
	[StrengthTestingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[SymptomDescriptions]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[SymptomDescriptions](
	[SymptomDescriptionID] [int] IDENTITY(1,1) NOT NULL,
	[SymptomDescriptionName] [varchar](100) NULL,
 CONSTRAINT [PK_Symptom Description] PRIMARY KEY CLUSTERED 
(
	[SymptomDescriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Tpds]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Tpds](
	[TpdID] [int] IDENTITY(1,1) NOT NULL,
	[TpdName] [varchar](50) NULL,
 CONSTRAINT [PK_Tpds] PRIMARY KEY CLUSTERED 
(
	[TpdID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentCategories]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentCategories](
	[TreatmentCategoryID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentCategoryName] [varchar](80) NULL,
 CONSTRAINT [PK_TreatmentCategories_1] PRIMARY KEY CLUSTERED 
(
	[TreatmentCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentCategoryAreasofExpetises]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentCategoryAreasofExpetises](
	[TreatmentCategoryAreasofExpertiseID] [int] NOT NULL,
	[AreasofExpertiseID] [int] NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
 CONSTRAINT [PK_TreatmentCategoryAreasofExpetises] PRIMARY KEY CLUSTERED 
(
	[TreatmentCategoryAreasofExpertiseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentCategoryBespokeServices]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentCategoryBespokeServices](
	[TreatmentCategoryBespokeServiceID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
	[BespokeServiceID] [int] NOT NULL,
 CONSTRAINT [PK_TreatmentCategoriesBespokeServices] PRIMARY KEY CLUSTERED 
(
	[TreatmentCategoryBespokeServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentCategoryPricingTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentCategoryPricingTypes](
	[TreatmentCategoryPricingTypeID] [int] NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
	[PricingTypeID] [int] NOT NULL,
 CONSTRAINT [PK_TreatmentCategoryPricingTypes] PRIMARY KEY CLUSTERED 
(
	[TreatmentCategoryPricingTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentCategoryRegistrationTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentCategoryRegistrationTypes](
	[TreatmentCategoryRegistrationTypeID] [int] NOT NULL,
	[RegistrationTypeID] [int] NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
 CONSTRAINT [PK_TreatmentCategoryRegistrationTypes] PRIMARY KEY CLUSTERED 
(
	[TreatmentCategoryRegistrationTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentCategoryTreatmentTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentCategoryTreatmentTypes](
	[TreatmentCategoryTreatmentTypeID] [int] NOT NULL,
	[TreatmentTypeID] [int] NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TreatmentCategoryTreatmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentPeriodType]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentPeriodType](
	[TreatmentPeriodTypeID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentPeriodTypeDesc] [varchar](20) NULL,
 CONSTRAINT [PK_TreatmentPeriodType] PRIMARY KEY CLUSTERED 
(
	[TreatmentPeriodTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentSessions]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentSessions](
	[TreatmentSessionID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentSessionValue] [int] NULL,
 CONSTRAINT [PK_TreatmentSessions] PRIMARY KEY CLUSTERED 
(
	[TreatmentSessionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TreatmentTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TreatmentTypes](
	[TreatmentTypeID] [int] NOT NULL,
	[TreatmentTypeName] [varchar](90) NOT NULL,
	[TreatmentTypeAbbreviation] [varchar](10) NULL,
 CONSTRAINT [PK_TreatmentType] PRIMARY KEY CLUSTERED 
(
	[TreatmentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[TypeCovers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[TypeCovers](
	[TypeCoverID] [int] NOT NULL,
	[TypeCoverName] [varchar](50) NULL,
 CONSTRAINT [PK_TypeCovers] PRIMARY KEY CLUSTERED 
(
	[TypeCoverID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[UKPostCodes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[UKPostCodes](
	[PostCode] [nvarchar](8) NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
	[Easting] [int] NOT NULL,
	[Northing] [int] NOT NULL,
	[GridRef] [nvarchar](8) NOT NULL,
	[County] [nvarchar](23) NOT NULL,
	[District] [nvarchar](44) NOT NULL,
	[Ward] [nvarchar](62) NOT NULL,
	[DistrictCode] [nvarchar](9) NOT NULL,
	[WardCode] [nvarchar](9) NOT NULL,
	[Country] [nvarchar](16) NOT NULL,
	[CountyCode] [nvarchar](9) NOT NULL,
	[RadiansLatitude] [float] NULL,
	[RadiansLongitude] [float] NULL,
 CONSTRAINT [PK_UKPostCodes] PRIMARY KEY CLUSTERED 
(
	[PostCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[UserTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[UserTypes](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserType] [varchar](30) NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[Workflows]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[Workflows](
	[WorkflowID] [int] NOT NULL,
	[Definition] [varchar](80) NOT NULL,
 CONSTRAINT [PK_ProcessLevels] PRIMARY KEY CLUSTERED 
(
	[WorkflowID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [lookup].[WorkTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [lookup].[WorkTypes](
	[WorkTypeID] [int] IDENTITY(1,1) NOT NULL,
	[WorkName] [varchar](10) NULL,
 CONSTRAINT [PK_WorkTypes] PRIMARY KEY CLUSTERED 
(
	[WorkTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ProjectTreatmentSLAs]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ProjectTreatmentSLAs](
	[ProjectTreatmentSLAID] [int] IDENTITY(1,1) NOT NULL,
	[ReferrerProjectTreatmentID] [int] NOT NULL,
	[ServiceLevelAgreementID] [int] NOT NULL,
	[NumberOfDays] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_ReferrerServiceLevelAgreements] PRIMARY KEY CLUSTERED 
(
	[ProjectTreatmentSLAID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerCaseAssessmentModifications]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerCaseAssessmentModifications](
	[ReferrerCaseAssessmentModificationID] [int] IDENTITY(1,1) NOT NULL,
	[CaseID] [int] NULL,
	[TreatmentSession] [int] NULL,
	[AssessmentServiceID] [int] NULL,
 CONSTRAINT [PK_ReferrerCaseModifications] PRIMARY KEY CLUSTERED 
(
	[ReferrerCaseAssessmentModificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerCaseContacts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerCaseContacts](
	[CaseReferrerContactID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[CaseID] [int] NOT NULL,
 CONSTRAINT [PK_ReferrerCaseContacts] PRIMARY KEY CLUSTERED 
(
	[CaseReferrerContactID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerDocuments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerDocuments](
	[ReferrerDocumentID] [int] IDENTITY(1,1) NOT NULL,
	[ReferrerID] [int] NOT NULL,
	[DocumentName] [varchar](100) NULL,
	[DocumentDate] [datetime] NULL,
	[DocumentTypeID] [int] NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[UserID] [int] NOT NULL,
	[UploadPath] [varchar](200) NOT NULL,
	[ReferrerProjectTreatmentID] [int] NULL,
	[ReferrerDocumentTypeID] [int] NULL,
	[CaseID] [int] NULL,
	[SupplierCheck] [bit] NULL,
	[ReferrerCheck] [bit] NULL,
 CONSTRAINT [PK_ReferrerDocuments] PRIMARY KEY CLUSTERED 
(
	[ReferrerDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerGroups]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerGroups](
	[GroupID] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [varchar](50) NULL,
	[UserID] [int] NULL,
	[ReferrerID] [int] NULL,
 CONSTRAINT [PK_ReferrerGroups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerLocations]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerLocations](
	[ReferrerLocationID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[City] [varchar](100) NULL,
	[Region] [varchar](100) NULL,
	[PostCode] [varchar](12) NOT NULL,
	[IsMainOffice] [bit] NOT NULL,
	[ReferrerID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_ReferrerLocations] PRIMARY KEY CLUSTERED 
(
	[ReferrerLocationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerProjects]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerProjects](
	[ReferrerProjectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [varchar](150) NOT NULL,
	[ReferrerID] [int] NOT NULL,
	[StatusID] [int] NOT NULL,
	[FirstAppointmentOffered] [bit] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[IsTriage] [bit] NOT NULL,
	[CentralEmail] [varchar](50) NOT NULL,
	[EmailSendingOptionID] [int] NOT NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_referrer.ReferrerProjects] PRIMARY KEY CLUSTERED 
(
	[ReferrerProjectID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerProjectTreatmentAssessments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerProjectTreatmentAssessments](
	[ReferrerProjectTreatmentAssessmentID] [int] IDENTITY(1,1) NOT NULL,
	[AssessmentServiceID] [int] NOT NULL,
	[AssessmentTypeID] [int] NOT NULL,
	[ReferrerProjectTreatmentID] [int] NOT NULL,
 CONSTRAINT [PK_ReferrerProjectTreatmentAssessments] PRIMARY KEY CLUSTERED 
(
	[ReferrerProjectTreatmentAssessmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerProjectTreatmentAuthorisations]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerProjectTreatmentAuthorisations](
	[ReferrerProjectTreatmentAuthorisationID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
	[DelegatedAuthorisationTypeID] [int] NOT NULL,
	[Amount] [money] NULL,
	[ReferrerProjectTreatmentID] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_ReferrerProjectTreatmentAuthorisations] PRIMARY KEY CLUSTERED 
(
	[ReferrerProjectTreatmentAuthorisationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerProjectTreatmentDocumentSetup]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerProjectTreatmentDocumentSetup](
	[ReferrerProjectTreatmentDocumentSetupID] [int] IDENTITY(1,1) NOT NULL,
	[AssessmentServiceID] [int] NOT NULL,
	[DocumentSetupTypeID] [int] NOT NULL,
	[ReferrerProjectTreatmentID] [int] NOT NULL,
 CONSTRAINT [PK_ReferrerProjectTreatmentDocumentSetup] PRIMARY KEY CLUSTERED 
(
	[ReferrerProjectTreatmentDocumentSetupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerProjectTreatmentEmails]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerProjectTreatmentEmails](
	[ReferrerProjectTreatmentEmailID] [int] IDENTITY(1,1) NOT NULL,
	[ReferrerProjectTreatmentID] [int] NOT NULL,
	[EmailTypeID] [int] NOT NULL,
	[EmailTypeValueID] [int] NOT NULL,
 CONSTRAINT [PK_ReferrerProjectTreatmentEmail] PRIMARY KEY CLUSTERED 
(
	[ReferrerProjectTreatmentEmailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerProjectTreatmentInvoice]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerProjectTreatmentInvoice](
	[ReferrerProjectTreatmentInvoiceID] [int] IDENTITY(1,1) NOT NULL,
	[InvoicePrice] [money] NULL,
	[ManagementPrice] [money] NULL,
	[ManagementFeeEnabled] [bit] NULL,
	[InvoiceMethodID] [int] NOT NULL,
	[ReferrerProjectTreatmentID] [int] NOT NULL,
 CONSTRAINT [PK_ReferrerProjectTreatmentInvoice] PRIMARY KEY CLUSTERED 
(
	[ReferrerProjectTreatmentInvoiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerProjectTreatmentPricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerProjectTreatmentPricing](
	[PricingID] [int] IDENTITY(1,1) NOT NULL,
	[PricingTypeID] [int] NOT NULL,
	[Price] [money] NULL,
	[ReferrerProjectTreatmentID] [int] NOT NULL,
 CONSTRAINT [PK_ReferrerProjectTreatmentPricing] PRIMARY KEY CLUSTERED 
(
	[PricingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[ReferrerProjectTreatments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[ReferrerProjectTreatments](
	[ReferrerProjectTreatmentID] [int] IDENTITY(1,1) NOT NULL,
	[ReferrerProjectID] [int] NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
	[AccountReceivableChasingPoint] [int] NULL,
	[AccountReceivableCollection] [int] NULL,
	[Enabled] [bit] NULL,
 CONSTRAINT [PK_ProjectTreatments] PRIMARY KEY CLUSTERED 
(
	[ReferrerProjectTreatmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [referrer].[Referrers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [referrer].[Referrers](
	[ReferrerID] [int] IDENTITY(1,1) NOT NULL,
	[ReferrerName] [varchar](50) NOT NULL,
	[ReferrerContactFirstName] [varchar](50) NOT NULL,
	[ReferrerContactLastName] [varchar](50) NOT NULL,
	[ReferrerMainContactEmail] [varchar](50) NULL,
	[ReferrerMainContactFax] [varchar](16) NULL,
	[ReferrerMainContactPhone] [varchar](16) NOT NULL,
	[DateAdded] [date] NOT NULL,
	[IsPolicyDetail] [bit] NULL,
	[IsEmploymentDetail] [bit] NULL,
	[IsEmploeeDetail] [bit] NULL,
	[IsDrugandAlcoholTest] [bit] NULL,
	[IsRepresentation] [bit] NULL,
	[IsAdditionalQuestion] [bit] NULL,
	[IsJobDemand] [bit] NULL,
	[IsPolicyDetailOpenOrDropdowns] [varchar](10) NULL,
	[IsNewPolicyTypes] [varchar](10) NULL,
 CONSTRAINT [PK_Referrers] PRIMARY KEY CLUSTERED 
(
	[ReferrerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [supplier].[SupplierClinicalAudit]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[SupplierClinicalAudit](
	[SupplierClinicalAuditID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[AuditPass] [bit] NOT NULL,
	[UserID] [int] NOT NULL,
	[AuditDate] [datetime] NOT NULL,
	[CaseID] [int] NOT NULL,
	[SupplierDocumentID] [int] NOT NULL,
 CONSTRAINT [PK_supplier.SupplierClinicalAudit] PRIMARY KEY CLUSTERED 
(
	[SupplierClinicalAuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [supplier].[SupplierComplaints]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[SupplierComplaints](
	[SupplierComplaintID] [int] IDENTITY(1,1) NOT NULL,
	[ComplaintTypeID] [int] NOT NULL,
	[ComplaintStatusID] [int] NOT NULL,
	[ComplaintDescription] [varchar](max) NULL,
	[ComplaintDate] [datetime] NOT NULL,
	[SupplierID] [int] NOT NULL,
 CONSTRAINT [PK_SupplierComplaints] PRIMARY KEY CLUSTERED 
(
	[SupplierComplaintID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [supplier].[SupplierDocuments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[SupplierDocuments](
	[SupplierDocumentID] [int] IDENTITY(1,1) NOT NULL,
	[DocumentTypeID] [int] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UploadDate] [datetime] NOT NULL,
	[DocumentName] [varchar](100) NOT NULL,
	[UploadPath] [varchar](150) NOT NULL,
	[ReferrerProjectTreatmentID] [int] NULL,
	[CaseId] [int] NULL,
 CONSTRAINT [PK_SupplierDocuments] PRIMARY KEY CLUSTERED 
(
	[SupplierDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [supplier].[SupplierInsurance]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[SupplierInsurance](
	[SupplierInsuredID] [int] IDENTITY(1,1) NOT NULL,
	[LevelOfCover] [varchar](150) NOT NULL,
	[RenewalDate] [datetime] NOT NULL,
	[SupplierDocumentID] [int] NOT NULL,
	[SupplierID] [int] NOT NULL,
 CONSTRAINT [PK_SupplierInsured] PRIMARY KEY CLUSTERED 
(
	[SupplierInsuredID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [supplier].[SupplierPractitioners]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[SupplierPractitioners](
	[SupplierPractitionerID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierID] [int] NOT NULL,
	[PractitionerRegistrationID] [int] NOT NULL,
 CONSTRAINT [PK_SupplierPractitioners] PRIMARY KEY CLUSTERED 
(
	[SupplierPractitionerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [supplier].[Suppliers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[Suppliers](
	[SupplierID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierName] [varchar](100) NOT NULL,
	[Address] [varchar](200) NOT NULL,
	[City] [varchar](100) NOT NULL,
	[Region] [varchar](100) NOT NULL,
	[PostCode] [varchar](12) NOT NULL,
	[Phone] [varchar](16) NOT NULL,
	[Fax] [varchar](16) NULL,
	[Website] [varchar](50) NULL,
	[Ranking] [int] NULL,
	[Notes] [varchar](max) NULL,
	[IsWheelChairAccessibility] [bit] NOT NULL,
	[IsWeekends] [bit] NOT NULL,
	[IsEvenings] [bit] NOT NULL,
	[IsParking] [bit] NOT NULL,
	[IsHomeVisit] [bit] NOT NULL,
	[StatusID] [int] NOT NULL,
	[DateAdded] [date] NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[IsTriage] [bit] NOT NULL,
 CONSTRAINT [PK_Suppliers] PRIMARY KEY CLUSTERED 
(
	[SupplierID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [supplier].[SupplierSiteAudit]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[SupplierSiteAudit](
	[SupplierSiteAuditID] [int] IDENTITY(1,1) NOT NULL,
	[AuditNotes] [varchar](max) NOT NULL,
	[AuditDate] [datetime] NOT NULL,
	[AuditPass] [bit] NOT NULL,
	[UserID] [int] NOT NULL,
	[SupplierDocumentID] [int] NULL,
	[SupplierID] [int] NOT NULL,
 CONSTRAINT [PK_SupplierSiteAudit] PRIMARY KEY CLUSTERED 
(
	[SupplierSiteAuditID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [supplier].[SupplierTreatmentPricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[SupplierTreatmentPricing](
	[PricingID] [int] IDENTITY(1,1) NOT NULL,
	[PricingTypeID] [int] NOT NULL,
	[Price] [money] NULL,
	[SupplierTreatmentID] [int] NOT NULL,
 CONSTRAINT [PK_SupplierTreatmentPricing] PRIMARY KEY CLUSTERED 
(
	[PricingID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [supplier].[SupplierTreatments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [supplier].[SupplierTreatments](
	[SupplierTreatmentID] [int] IDENTITY(1,1) NOT NULL,
	[TreatmentCategoryID] [int] NOT NULL,
	[SupplierID] [int] NOT NULL,
	[Enabled] [bit] NOT NULL,
 CONSTRAINT [PK_SupplierTreatments] PRIMARY KEY CLUSTERED 
(
	[SupplierTreatmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [lookup].[TreatmentCategoriesTreatmentTypes ]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [lookup].[TreatmentCategoriesTreatmentTypes ]
AS
SELECT     lookup.TreatmentCategoryTreatmentTypes.TreatmentCategoryTreatmentTypeID, lookup.TreatmentCategoryTreatmentTypes.TreatmentTypeID, 
                      lookup.TreatmentCategoryTreatmentTypes.TreatmentCategoryID, lookup.TreatmentTypes.TreatmentTypeName
FROM         lookup.TreatmentCategoryTreatmentTypes INNER JOIN
                      lookup.TreatmentTypes ON lookup.TreatmentCategoryTreatmentTypes.TreatmentTypeID = lookup.TreatmentTypes.TreatmentTypeID

GO
/****** Object:  View [referrer].[ReferrerProjectTreatmentTreatmentType]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [referrer].[ReferrerProjectTreatmentTreatmentType]
AS
SELECT        lookup.[TreatmentCategoriesTreatmentTypes ].TreatmentTypeID, lookup.[TreatmentCategoriesTreatmentTypes ].TreatmentTypeName, 
                         referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID
FROM            lookup.[TreatmentCategoriesTreatmentTypes ] INNER JOIN
                         referrer.ReferrerProjectTreatments ON 
                         lookup.[TreatmentCategoriesTreatmentTypes ].TreatmentCategoryID = referrer.ReferrerProjectTreatments.TreatmentCategoryID

GO
/****** Object:  View [dbo].[CaseUploads]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CaseUploads]
AS
SELECT        global.CaseDocuments.CaseDocumentID, global.CaseDocuments.DocumentTypeID, global.CaseDocuments.UploadDate, global.CaseDocuments.DocumentName, 
                         global.Users.Username, lookup.DocumentTypes.DocumentTypeName, global.Users.FirstName, global.Users.LastName, 
                         supplier.SupplierDocuments.SupplierDocumentID, supplier.SupplierDocuments.DocumentName AS Expr1
FROM            global.CaseDocuments INNER JOIN
                         global.Users ON global.CaseDocuments.UserID = global.Users.UserID INNER JOIN
                         lookup.DocumentTypes ON global.CaseDocuments.DocumentTypeID = lookup.DocumentTypes.DocumentTypeID INNER JOIN
                         supplier.SupplierDocuments ON global.Users.UserID = supplier.SupplierDocuments.UserID AND global.Users.UserID = supplier.SupplierDocuments.UserID AND 
                         lookup.DocumentTypes.DocumentTypeID = supplier.SupplierDocuments.DocumentTypeID AND 
                         lookup.DocumentTypes.DocumentTypeID = supplier.SupplierDocuments.DocumentTypeID

GO
/****** Object:  View [global].[CaseInvoicePatientReferrer]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [global].[CaseInvoicePatientReferrer]
AS
SELECT     global.Invoices.InvoiceNumber, global.Invoices.Amount, global.Cases.CaseID, global.Cases.CaseNumber, global.Patients.FirstName, global.Patients.LastName, 
                      global.Cases.CaseReferrerReferenceNumber, referrer.Referrers.ReferrerContactFirstName, referrer.Referrers.ReferrerContactLastName, 
                      referrer.Referrers.ReferrerMainContactEmail, global.Invoices.InvoiceID, global.Patients.PatientID, referrer.Referrers.ReferrerID, 
                      referrer.Referrers.ReferrerMainContactPhone
FROM         global.Cases INNER JOIN
                      global.Patients ON global.Cases.PatientID = global.Patients.PatientID INNER JOIN
                      referrer.Referrers ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID INNER JOIN
                      global.Invoices ON global.Cases.CaseID = global.Invoices.CaseId
WHERE     (global.Invoices.Amount > 0.00) AND (global.Invoices.IsComplete <> 1)

GO
/****** Object:  View [global].[CasePatient]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [global].[CasePatient]
AS
SELECT        global.Patients.PatientID, global.Patients.Title, global.Patients.FirstName, global.Patients.LastName, global.Patients.Address, global.Patients.PostCode, 
                         global.Patients.InjuryDate, global.Patients.BirthDate, global.Patients.Email, lookup.Genders.GenderName AS Gender, global.Cases.CaseID, 
                         global.Cases.CaseNumber, global.Cases.WorkflowID, lookup.Genders.GenderID, global.Patients.HomePhone, global.Patients.WorkPhone, 
                         global.Patients.MobilePhone, lookup.TreatmentTypes.TreatmentTypeName, lookup.TreatmentTypes.TreatmentTypeID, global.Patients.City, global.Patients.Region, 
                         global.Cases.CaseReferrerReferenceNumber, global.Cases.CaseSpecialInstruction, global.Cases.PatientContactedByInternalUser, 
                         global.Cases.PatientContactNotes, referrer.ReferrerProjectTreatments.TreatmentCategoryID, lookup.TreatmentCategories.TreatmentCategoryName, 
                         global.Cases.CaseSubmittedDate, global.Cases.SupplierID, global.Patients.SpecialInstructionNotes
FROM            referrer.ReferrerProjectTreatments INNER JOIN
                         global.Cases INNER JOIN
                         global.Patients ON global.Cases.PatientID = global.Patients.PatientID INNER JOIN
                         lookup.Genders ON global.Patients.GenderID = lookup.Genders.GenderID AND global.Patients.GenderID = lookup.Genders.GenderID ON 
                         referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID AND 
                         referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID INNER JOIN
                         lookup.TreatmentCategories ON referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND 
                         referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND 
                         referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND 
                         referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID INNER JOIN
                         lookup.TreatmentTypes ON global.Cases.TreatmentTypeID = lookup.TreatmentTypes.TreatmentTypeID

GO
/****** Object:  View [global].[CasePatientReferrerSupplier]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [global].[CasePatientReferrerSupplier]
AS
SELECT     global.Cases.CaseID, supplier.Suppliers.SupplierID, referrer.Referrers.ReferrerID, global.Patients.PatientID, global.Patients.FirstName, global.Patients.LastName, 
                      global.Patients.Address, global.Patients.City, global.Patients.Region, global.Patients.PostCode, global.Cases.CaseNumber, referrer.Referrers.ReferrerName, 
                      global.Patients.Title, supplier.Suppliers.SupplierName, supplier.Suppliers.Address AS SuppliersAddress, supplier.Suppliers.City AS SuppliersCity, 
                      supplier.Suppliers.Region AS SuppliersRegion, supplier.Suppliers.PostCode AS SuppliersPostCode, supplier.Suppliers.Phone, 
                      lookup.TreatmentTypes.TreatmentTypeName, lookup.TreatmentTypes.TreatmentTypeID
FROM         global.Cases INNER JOIN
                      supplier.Suppliers ON global.Cases.SupplierID = supplier.Suppliers.SupplierID INNER JOIN
                      referrer.Referrers ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID INNER JOIN
                      global.Patients ON global.Cases.PatientID = global.Patients.PatientID INNER JOIN
                      lookup.TreatmentTypes ON global.Cases.TreatmentTypeID = lookup.TreatmentTypes.TreatmentTypeID

GO
/****** Object:  View [global].[CasePatientSupplierPractitioner]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [global].[CasePatientSupplierPractitioner]
AS
SELECT     global.Patients.FirstName, global.Patients.LastName, global.Cases.CaseReferrerReferenceNumber, supplier.Suppliers.PostCode, 
                      global.Practitioners.PractitionerFirstName, global.Practitioners.PractitionerLastName, global.Cases.CaseNumber, global.Patients.BirthDate, 
                      supplier.Suppliers.SupplierName, supplier.Suppliers.Phone, global.Patients.PatientID, global.Practitioners.PractitionerID, 
                      global.PractitionerRegistrations.PractitionerRegistrationID, supplier.SupplierPractitioners.SupplierPractitionerID, global.Cases.CaseID, 
                      supplier.Suppliers.SupplierID
FROM         global.Practitioners INNER JOIN
                      global.PractitionerRegistrations ON global.Practitioners.PractitionerID = global.PractitionerRegistrations.PractitionerID AND 
                      global.Practitioners.PractitionerID = global.PractitionerRegistrations.PractitionerID AND 
                      global.Practitioners.PractitionerID = global.PractitionerRegistrations.PractitionerID INNER JOIN
                      supplier.SupplierPractitioners ON global.PractitionerRegistrations.PractitionerRegistrationID = supplier.SupplierPractitioners.PractitionerRegistrationID AND 
                      global.PractitionerRegistrations.PractitionerRegistrationID = supplier.SupplierPractitioners.PractitionerRegistrationID AND 
                      global.PractitionerRegistrations.PractitionerRegistrationID = supplier.SupplierPractitioners.PractitionerRegistrationID INNER JOIN
                      global.Cases INNER JOIN
                      global.Patients ON global.Cases.PatientID = global.Patients.PatientID AND global.Cases.PatientID = global.Patients.PatientID INNER JOIN
                      supplier.Suppliers ON global.Cases.SupplierID = supplier.Suppliers.SupplierID AND global.Cases.SupplierID = supplier.Suppliers.SupplierID ON 
                      supplier.SupplierPractitioners.SupplierID = supplier.Suppliers.SupplierID AND supplier.SupplierPractitioners.SupplierID = supplier.Suppliers.SupplierID AND 
                      supplier.SupplierPractitioners.SupplierID = supplier.Suppliers.SupplierID

GO
/****** Object:  View [global].[CasePatientTreatmentWorkflows]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [global].[CasePatientTreatmentWorkflows]
AS
SELECT     global.Cases.CaseID, lookup.TreatmentTypes.TreatmentTypeName, global.Cases.TreatmentTypeID, referrer.ReferrerProjectTreatments.TreatmentCategoryID, 
                      lookup.TreatmentCategories.TreatmentCategoryName, lookup.Workflows.Definition, global.Cases.WorkflowID, global.Cases.CaseReferrerReferenceNumber, 
                      global.Cases.CaseNumber, global.Patients.PostCode, global.Patients.FirstName, global.Patients.LastName, global.Patients.PatientID, 
                      referrer.Referrers.ReferrerName
FROM         referrer.ReferrerProjectTreatments INNER JOIN
                      global.Cases INNER JOIN
                      global.Patients ON global.Cases.PatientID = global.Patients.PatientID ON 
                      referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID AND 
                      referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID INNER JOIN
                      lookup.TreatmentCategories ON referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND 
                      referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND 
                      referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND 
                      referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID INNER JOIN
                      lookup.TreatmentTypes ON global.Cases.TreatmentTypeID = lookup.TreatmentTypes.TreatmentTypeID INNER JOIN
                      lookup.Workflows ON global.Cases.WorkflowID = lookup.Workflows.WorkflowID INNER JOIN
                      referrer.ReferrerProjects ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID INNER JOIN
                      referrer.Referrers ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID AND global.Cases.ReferrerID = referrer.Referrers.ReferrerID AND 
                      referrer.ReferrerProjects.ReferrerID = referrer.Referrers.ReferrerID AND referrer.ReferrerProjects.ReferrerID = referrer.Referrers.ReferrerID AND 
                      referrer.ReferrerProjects.ReferrerID = referrer.Referrers.ReferrerID AND referrer.ReferrerProjects.ReferrerID = referrer.Referrers.ReferrerID AND 
                      referrer.ReferrerProjects.ReferrerID = referrer.Referrers.ReferrerID AND referrer.ReferrerProjects.ReferrerID = referrer.Referrers.ReferrerID

GO
/****** Object:  View [global].[CaseWorkflowCounts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [global].[CaseWorkflowCounts]
AS
SELECT     'Referrals' AS Description, COUNT(WorkflowID) AS CaseCount, 1 AS Ordinal
FROM         global.Cases
WHERE     (WorkflowID IN (10, 20, 30))
UNION
SELECT     'Triage Assessment QA' AS Description, COUNT(WorkflowID) AS CaseCount, 2 AS Ordinal
FROM         global.Cases
WHERE     WorkflowID = 65
UNION
SELECT     'Initial Assessment QA' AS Description, COUNT(WorkflowID) AS CaseCount, 3 AS Ordinal
FROM         global.Cases
WHERE     WorkflowID in (70,72)
UNION
SELECT     'Authorisation' AS Description, COUNT(WorkflowID) AS CaseCount, 4 AS Ordinal
FROM         global.Cases
WHERE     WorkflowID in( 100,102)
UNION
SELECT     'Review Assessment QA' AS Description, COUNT(WorkflowID) AS CaseCount, 5 AS Ordinal
FROM         global.Cases
WHERE     WorkflowID in( 130,132)
UNION
SELECT     'Final Assessment QA' AS Description, COUNT(WorkflowID) AS CaseCount, 6 AS Ordinal
FROM         global.Cases
WHERE     WorkflowID in (160 ,162)
UNION
SELECT     'Case Stopped' AS Description, COUNT(WorkflowID) AS CaseCount, 7 AS Ordinal
FROM         global.Cases
WHERE     WorkflowID = 200
UNION
SELECT     'Case Completed' AS Description, COUNT(WorkflowID) AS CaseCount, 8 AS Ordinal
FROM         global.Cases
WHERE     WorkflowID = 210
UNION
SELECT     'Referral Tasks Due Today' AS Description, COUNT(WorkflowID) AS CaseCount, 9 AS Ordinal
FROM         global.Cases
WHERE     CaseReferrerDueDate = getdate()



GO
/****** Object:  View [global].[ReferrerSupplierCases]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [global].[ReferrerSupplierCases]
AS
SELECT        global.Patients.PatientID, global.Patients.Title, global.Patients.FirstName, global.Patients.LastName, global.Patients.Address, global.Patients.PostCode, global.Patients.InjuryDate, global.Patients.BirthDate, 
                         global.Patients.Email, lookup.Genders.GenderName AS Gender, global.Cases.CaseID, global.Cases.CaseNumber, global.Cases.WorkflowID, lookup.Genders.GenderID, global.Patients.HomePhone, global.Patients.WorkPhone, 
                         global.Patients.MobilePhone, lookup.TreatmentTypes.TreatmentTypeName, lookup.TreatmentTypes.TreatmentTypeID, global.Patients.City, global.Patients.Region, global.Cases.CaseReferrerReferenceNumber, 
                         global.Cases.CaseSpecialInstruction, global.Cases.PatientContactedByInternalUser, global.Cases.PatientContactNotes, referrer.ReferrerProjectTreatments.TreatmentCategoryID, 
                         lookup.TreatmentCategories.TreatmentCategoryName, global.Cases.CaseSubmittedDate, global.Cases.SupplierID, global.Cases.ReferrerID, global.CaseReferrerAssignedUsers.UserID AS ReferrerAssignedUser, 
                         global.Cases.SupplierAssignedUser, global.CaseReferrerAssignedUsers.Status,
                             (SELECT        TOP (1) ISNULL(AssessmentDate, NULL) AS AssessmentDate
                               FROM            global.CaseAssessmentDetail AS asd
                               WHERE        (AssessmentServiceID = 1) AND (CaseID = global.Cases.CaseID)) AS InitialAssessmentDate,
                             (SELECT        TOP (1) ISNULL(AssessmentDate, NULL) AS AssessmentDate
                               FROM            global.CaseAssessmentDetail AS asd
                               WHERE        (AssessmentServiceID = 3) AND (CaseID = global.Cases.CaseID)) AS FinalAssessmentDate,
                             (SELECT        TOP (1) CaseAssessmentDetailID
                               FROM            global.CaseAssessmentDetail AS asd
                               WHERE        (AssessmentServiceID = 1) AND (CaseID = global.Cases.CaseID)) AS InitialCaseAssessmentDetailID,
                             (SELECT        TOP (1) CaseAssessmentDetailID
                               FROM            global.CaseAssessmentDetail AS asd
                               WHERE        (AssessmentServiceID = 3) AND (CaseID = global.Cases.CaseID)) AS FinalCaseAssessmentDetailID,
                             (SELECT        TOP (1) AssessmentServiceID
                               FROM            global.CaseAssessmentDetail AS asd
                               WHERE        (AssessmentServiceID = 1) AND (CaseID = global.Cases.CaseID)) AS InitialAssessmentServiceID,
                             (SELECT        TOP (1) AssessmentServiceID
                               FROM            global.CaseAssessmentDetail AS asd
                               WHERE        (AssessmentServiceID = 3) AND (CaseID = global.Cases.CaseID)) AS FinalAssessmentServiceID
FROM            referrer.ReferrerProjectTreatments INNER JOIN
                         global.Cases INNER JOIN
                         global.Patients ON global.Cases.PatientID = global.Patients.PatientID INNER JOIN
                         lookup.Genders ON global.Patients.GenderID = lookup.Genders.GenderID AND global.Patients.GenderID = lookup.Genders.GenderID ON 
                         referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID AND 
                         referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID INNER JOIN
                         lookup.TreatmentCategories ON referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND 
                         referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID AND
                          referrer.ReferrerProjectTreatments.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID INNER JOIN
                         lookup.TreatmentTypes ON global.Cases.TreatmentTypeID = lookup.TreatmentTypes.TreatmentTypeID LEFT OUTER JOIN
                         global.CaseReferrerAssignedUsers ON global.Cases.CaseID = global.CaseReferrerAssignedUsers.CaseID

GO
/****** Object:  View [lookup].[PractitionerTreatmentRegistrations]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [lookup].[PractitionerTreatmentRegistrations]
AS
SELECT     global.Practitioners.PractitionerFirstName, lookup.TreatmentCategories.TreatmentCategoryName, global.PractitionerRegistrations.RegistrationNumber, 
                      global.Practitioners.PractitionerLastName, global.Practitioners.PractitionerID, lookup.RegistrationTypes.RegistrationTypeName, 
                      global.PractitionerRegistrations.IsActive, global.PractitionerRegistrations.PractitionerRegistrationID
FROM         global.PractitionerRegistrations INNER JOIN
                      global.Practitioners ON global.PractitionerRegistrations.PractitionerID = global.Practitioners.PractitionerID INNER JOIN
                      lookup.TreatmentCategories ON global.PractitionerRegistrations.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID LEFT OUTER JOIN
                      lookup.RegistrationTypes ON global.PractitionerRegistrations.RegistrationTypeID = lookup.RegistrationTypes.RegistrationTypeID


GO
/****** Object:  View [lookup].[TreatmentCategoriesAreasofExpertises]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [lookup].[TreatmentCategoriesAreasofExpertises]
AS
SELECT     lookup.AreasofExpertise.AreasofExpertiseName, lookup.TreatmentCategories.TreatmentCategoryName, 
                      lookup.TreatmentCategoryAreasofExpetises.AreasofExpertiseID, lookup.TreatmentCategoryAreasofExpetises.TreatmentCategoryID, 
                      lookup.TreatmentCategoryAreasofExpetises.TreatmentCategoryAreasofExpertiseID
FROM         lookup.AreasofExpertise INNER JOIN
                      lookup.TreatmentCategoryAreasofExpetises ON 
                      lookup.AreasofExpertise.AreasofExpertiseID = lookup.TreatmentCategoryAreasofExpetises.AreasofExpertiseID INNER JOIN
                      lookup.TreatmentCategories ON lookup.TreatmentCategoryAreasofExpetises.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID


GO
/****** Object:  View [lookup].[TreatmentCategoriesBespokeServices]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [lookup].[TreatmentCategoriesBespokeServices]
AS
SELECT     lookup.TreatmentCategories.TreatmentCategoryName, lookup.BespokeServices.BespokeServiceName, 
                      lookup.TreatmentCategoryBespokeServices.TreatmentCategoryBespokeServiceID, lookup.TreatmentCategoryBespokeServices.TreatmentCategoryID, 
                      lookup.TreatmentCategoryBespokeServices.BespokeServiceID
FROM         lookup.TreatmentCategoryBespokeServices INNER JOIN
                      lookup.TreatmentCategories ON lookup.TreatmentCategoryBespokeServices.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID INNER JOIN
                      lookup.BespokeServices ON lookup.TreatmentCategoryBespokeServices.BespokeServiceID = lookup.BespokeServices.BespokeServiceID

GO
/****** Object:  View [lookup].[TreatmentCategoriesPricingTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [lookup].[TreatmentCategoriesPricingTypes]
AS
SELECT     lookup.TreatmentCategoryPricingTypes.TreatmentCategoryPricingTypeID, lookup.TreatmentCategories.TreatmentCategoryID, 
                      lookup.TreatmentCategories.TreatmentCategoryName, lookup.PricingTypes.PricingTypeName, lookup.PricingTypes.PricingTypeID
FROM         lookup.PricingTypes INNER JOIN
                      lookup.TreatmentCategoryPricingTypes ON lookup.PricingTypes.PricingTypeID = lookup.TreatmentCategoryPricingTypes.PricingTypeID INNER JOIN
                      lookup.TreatmentCategories ON lookup.TreatmentCategoryPricingTypes.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID

GO
/****** Object:  View [lookup].[TreatmentCategoriesRegistrationTypes]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create VIEW [lookup].[TreatmentCategoriesRegistrationTypes]
AS
SELECT     lookup.RegistrationTypes.RegistrationTypeName, lookup.TreatmentCategories.TreatmentCategoryName, 
                      lookup.TreatmentCategoryRegistrationTypes.TreatmentCategoryRegistrationTypeID, lookup.TreatmentCategoryRegistrationTypes.RegistrationTypeID, 
                      lookup.TreatmentCategoryRegistrationTypes.TreatmentCategoryID
FROM         lookup.RegistrationTypes INNER JOIN
                      lookup.TreatmentCategoryRegistrationTypes ON 
                      lookup.RegistrationTypes.RegistrationTypeID = lookup.TreatmentCategoryRegistrationTypes.RegistrationTypeID INNER JOIN
                      lookup.TreatmentCategories ON lookup.TreatmentCategoryRegistrationTypes.TreatmentCategoryID = lookup.TreatmentCategories.TreatmentCategoryID


GO
/****** Object:  View [referrer].[ReferrerAuthorisations]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [referrer].[ReferrerAuthorisations]
AS
SELECT     global.Cases.CaseReferrerDueDate, global.Patients.FirstName, global.Patients.LastName, global.Cases.CaseReferrerReferenceNumber, global.Cases.CaseNumber, 
                      lookup.TreatmentTypes.TreatmentTypeName, global.Cases.WorkflowID, global.Cases.ReferrerID, global.Patients.PatientID, global.Cases.SupplierID, 
                      global.Cases.CaseID
FROM         global.Cases INNER JOIN
                      global.Patients ON global.Cases.PatientID = global.Patients.PatientID INNER JOIN
                      lookup.TreatmentTypes ON global.Cases.TreatmentTypeID = lookup.TreatmentTypes.TreatmentTypeID
WHERE     (global.Cases.WorkflowID IN (90,92, 180,182, 150,152))



GO
/****** Object:  View [supplier].[SupplierDocumentsUsers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [supplier].[SupplierDocumentsUsers]
AS
SELECT [supplier].[SupplierDocuments].*,[Users].[Username] FROM [supplier].[SupplierDocuments]
INNER JOIN [global].[Users]
ON [supplier].[SupplierDocuments].[UserID]=[global].[Users].[UserID]



GO
/****** Object:  View [supplier].[SupplierSearch]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [supplier].[SupplierSearch]
AS
SELECT     suppliers.SupplierName, suppliers.SupplierID, suppliers.PostCode, suppliers.Address, suppliers.City, suppliers.Region, suppliers.DateAdded, SUBSTRING
                          ((SELECT     + ', ' + lookup.TreatmentCategories.TreatmentCategoryName AS [text()]
                              FROM         supplier.SupplierTreatments INNER JOIN
                                                    lookup.TreatmentCategories ON lookup.TreatmentCategories.TreatmentCategoryID = supplier.SupplierTreatments.TreatmentCategoryID AND 
                                                    supplier.SupplierTreatments.SupplierID = suppliers.SupplierID
                              WHERE     supplier.SupplierTreatments.Enabled = 1
                              FOR XML PATH('')), 3, 350) AS TreatmentCategoryName
FROM         supplier.Suppliers suppliers

GO
/****** Object:  Index [IX_CaseAssessmentRatings_CaseID_AssessmentTypeID]    Script Date: 21-02-2020 10:30:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_CaseAssessmentRatings_CaseID_AssessmentTypeID] ON [global].[CaseAssessmentRatings]
(
	[CaseID] ASC,
	[AssessmentServiceID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Unique_Username]    Script Date: 21-02-2020 10:30:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Unique_Username] ON [global].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Referrers_ReferrerName]    Script Date: 21-02-2020 10:30:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Referrers_ReferrerName] ON [referrer].[Referrers]
(
	[ReferrerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Suppliers_Email]    Script Date: 21-02-2020 10:30:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Suppliers_Email] ON [supplier].[Suppliers]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Suppliers_Name]    Script Date: 21-02-2020 10:30:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Suppliers_Name] ON [supplier].[Suppliers]
(
	[SupplierName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SupplierTreatments_SupplierIDTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_SupplierTreatments_SupplierIDTreatmentCategoryID] ON [supplier].[SupplierTreatments]
(
	[SupplierID] ASC,
	[TreatmentCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [global].[CaseAssessmentDetail] ADD  CONSTRAINT [DF_CaseAssessmentDetail_SessionsPatientFailedToAttend]  DEFAULT ((0)) FOR [SessionsPatientFailedToAttend]
GO
ALTER TABLE [global].[CaseAssessmentDetail] ADD  CONSTRAINT [DF_CaseAssessmentDetail_AssessmentDate]  DEFAULT (getdate()) FOR [AssessmentDate]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] ADD  CONSTRAINT [DF_CaseAssessmentDetailHistory_SessionsPatientFailedToAttend]  DEFAULT ((0)) FOR [SessionsPatientFailedToAttend]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] ADD  CONSTRAINT [DF_CaseAssessmentDetailHistory_AssessmentDate]  DEFAULT (getdate()) FOR [AssessmentDate]
GO
ALTER TABLE [global].[CaseAssessmentHistory] ADD  CONSTRAINT [DF_CaseAssessmentHistory_IsAccepted]  DEFAULT ((0)) FOR [IsAccepted]
GO
ALTER TABLE [global].[CaseAssessmentHistory] ADD  CONSTRAINT [DF_CaseAssessmentHistory_IsPatientDischarge]  DEFAULT ((0)) FOR [IsPatientDischarge]
GO
ALTER TABLE [global].[CaseAssessmentRatings] ADD  CONSTRAINT [DF_CaseAssessmentRatings_RatingDate]  DEFAULT (getdate()) FOR [RatingDate]
GO
ALTER TABLE [global].[CaseAssessments] ADD  CONSTRAINT [DF_CaseAssessments_IsAccepted]  DEFAULT ((0)) FOR [IsAccepted]
GO
ALTER TABLE [global].[CaseAssessments] ADD  CONSTRAINT [DF_CaseAssessments_IsPatientDischarge]  DEFAULT ((0)) FOR [IsPatientDischarge]
GO
ALTER TABLE [global].[CaseCommunicationHistory] ADD  CONSTRAINT [DF_CaseCommunicationHistory_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [global].[CaseHistory] ADD  CONSTRAINT [DF_CaseHistory_EventDate]  DEFAULT (getdate()) FOR [EventDate]
GO
ALTER TABLE [global].[CaseNotes] ADD  CONSTRAINT [DF_CaseNotes_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [global].[Cases] ADD  CONSTRAINT [DF_Cases_CaseNumber]  DEFAULT ((0)) FOR [CaseNumber]
GO
ALTER TABLE [global].[Cases] ADD  CONSTRAINT [DF_Cases_CaseSubmittedDate]  DEFAULT (getdate()) FOR [CaseSubmittedDate]
GO
ALTER TABLE [global].[Cases] ADD  CONSTRAINT [DF_Cases_PatientContacted]  DEFAULT ((0)) FOR [PatientContactedByInternalUser]
GO
ALTER TABLE [global].[Cases] ADD  CONSTRAINT [DF_Cases_IsTreatmentRequired]  DEFAULT ((1)) FOR [IsTreatmentRequired]
GO
ALTER TABLE [global].[Cases] ADD  CONSTRAINT [DF_Cases_IsTriage]  DEFAULT ((1)) FOR [IsTriage]
GO
ALTER TABLE [global].[Cases] ADD  CONSTRAINT [DF_Cases_IsCustom]  DEFAULT ((0)) FOR [IsCustom]
GO
ALTER TABLE [global].[CaseTreatmentPricing] ADD  CONSTRAINT [DF_CaseTreatmentPricing_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [global].[InvoicePayment] ADD  CONSTRAINT [DF_InvoicePayment_Payment]  DEFAULT ((0.00)) FOR [Payment]
GO
ALTER TABLE [global].[InvoicePayment] ADD  CONSTRAINT [DF_InvoicePayment_AdjustedPayment]  DEFAULT ((0.00)) FOR [AdjustedPayment]
GO
ALTER TABLE [global].[Invoices] ADD  CONSTRAINT [DF_Invoices_Amount]  DEFAULT ((0.00)) FOR [Amount]
GO
ALTER TABLE [global].[Invoices] ADD  CONSTRAINT [DF_Invoices_IsComplete]  DEFAULT ((0)) FOR [IsComplete]
GO
ALTER TABLE [global].[JobDemands] ADD  CONSTRAINT [DF_JobDemands_IsJobDemand]  DEFAULT ((0)) FOR [IsJobDemand]
GO
ALTER TABLE [global].[Patients] ADD  CONSTRAINT [DF_Patients_HasLegalRep]  DEFAULT ((0)) FOR [HasLegalRep]
GO
ALTER TABLE [global].[Practitioners] ADD  CONSTRAINT [DF_Practitioners_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [global].[Users] ADD  CONSTRAINT [DF_Users_IsLocked]  DEFAULT ((0)) FOR [IsLocked]
GO
ALTER TABLE [global].[Users] ADD  CONSTRAINT [DF_Users_FailedAttemptCount]  DEFAULT ((0)) FOR [FailedAttemptCount]
GO
ALTER TABLE [global].[Users] ADD  CONSTRAINT [DF_Users_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [referrer].[ProjectTreatmentSLAs] ADD  CONSTRAINT [DF_ReferrerServiceLevelAgreements_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [referrer].[ReferrerDocuments] ADD  CONSTRAINT [DF_ReferrerDocuments_UploadDate]  DEFAULT (getdate()) FOR [UploadDate]
GO
ALTER TABLE [referrer].[ReferrerLocations] ADD  CONSTRAINT [DF_ReferrerLocations_IsHeadLocation]  DEFAULT ((0)) FOR [IsMainOffice]
GO
ALTER TABLE [referrer].[ReferrerLocations] ADD  CONSTRAINT [DF_ReferrerLocations_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [referrer].[ReferrerProjects] ADD  CONSTRAINT [DF_ReferrerProjects_StatusID]  DEFAULT ((2)) FOR [StatusID]
GO
ALTER TABLE [referrer].[ReferrerProjects] ADD  CONSTRAINT [DF_ReferrerProjects_FirstAppointmentOffered]  DEFAULT ((0)) FOR [FirstAppointmentOffered]
GO
ALTER TABLE [referrer].[ReferrerProjects] ADD  CONSTRAINT [DF_ReferrerProjects_Enabled]  DEFAULT ((0)) FOR [Enabled]
GO
ALTER TABLE [referrer].[ReferrerProjects] ADD  CONSTRAINT [DF_ReferrerProjects_IsTriage]  DEFAULT ((0)) FOR [IsTriage]
GO
ALTER TABLE [referrer].[ReferrerProjects] ADD  CONSTRAINT [DF_ReferrerProjects_EmailSendingOptionID]  DEFAULT ((3)) FOR [EmailSendingOptionID]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentDocumentSetup] ADD  CONSTRAINT [DF_ReferrerProjectTreatmentDocumentSetup_DocumentSetupTypeID]  DEFAULT ((1)) FOR [DocumentSetupTypeID]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentInvoice] ADD  CONSTRAINT [DF_ReferrerProjectTreatmentInvoice_InvoiceMethodID]  DEFAULT ((1)) FOR [InvoiceMethodID]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatments] ADD  CONSTRAINT [DF_ReferrerProjectTreatments_Enabled]  DEFAULT ((1)) FOR [Enabled]
GO
ALTER TABLE [referrer].[Referrers] ADD  CONSTRAINT [DF_Referrers_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [supplier].[SupplierComplaints] ADD  CONSTRAINT [DF_SupplierComplaints_ComplaintDate]  DEFAULT (getdate()) FOR [ComplaintDate]
GO
ALTER TABLE [supplier].[SupplierDocuments] ADD  CONSTRAINT [DF_SupplierDocuments_UploadDate]  DEFAULT (getdate()) FOR [UploadDate]
GO
ALTER TABLE [supplier].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_IsWheelChairAccessibility]  DEFAULT ((0)) FOR [IsWheelChairAccessibility]
GO
ALTER TABLE [supplier].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_IsWeekends]  DEFAULT ((0)) FOR [IsWeekends]
GO
ALTER TABLE [supplier].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_IsEvenings]  DEFAULT ((0)) FOR [IsEvenings]
GO
ALTER TABLE [supplier].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_IsParking]  DEFAULT ((0)) FOR [IsParking]
GO
ALTER TABLE [supplier].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_IsHomeVisit]  DEFAULT ((0)) FOR [IsHomeVisit]
GO
ALTER TABLE [supplier].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_StatusID]  DEFAULT ((2)) FOR [StatusID]
GO
ALTER TABLE [supplier].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [supplier].[Suppliers] ADD  CONSTRAINT [DF_Suppliers_IsTriage]  DEFAULT ((0)) FOR [IsTriage]
GO
ALTER TABLE [supplier].[SupplierTreatments] ADD  CONSTRAINT [DF_SupplierTreatments_Enabled]  DEFAULT ((0)) FOR [Enabled]
GO
ALTER TABLE [global].[CaseAppointmentDates]  WITH CHECK ADD  CONSTRAINT [FK_CaseAppointmentDates_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseAppointmentDates] CHECK CONSTRAINT [FK_CaseAppointmentDates_Cases]
GO
ALTER TABLE [global].[CaseAssessmentCustoms]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentCustoms_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
GO
ALTER TABLE [global].[CaseAssessmentCustoms] CHECK CONSTRAINT [FK_CaseAssessmentCustoms_Cases]
GO
ALTER TABLE [global].[CaseAssessmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetail_AssessmentServices] FOREIGN KEY([AssessmentServiceID])
REFERENCES [lookup].[AssessmentServices] ([AssessmentServiceID])
GO
ALTER TABLE [global].[CaseAssessmentDetail] CHECK CONSTRAINT [FK_CaseAssessmentDetail_AssessmentServices]
GO
ALTER TABLE [global].[CaseAssessmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetail_CaseAssessments] FOREIGN KEY([CaseID])
REFERENCES [global].[CaseAssessments] ([CaseID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseAssessmentDetail] CHECK CONSTRAINT [FK_CaseAssessmentDetail_CaseAssessments]
GO
ALTER TABLE [global].[CaseAssessmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetail_Durations_AbsentPeriodDuration] FOREIGN KEY([AbsentPeriodDurationID])
REFERENCES [lookup].[Durations] ([DurationID])
GO
ALTER TABLE [global].[CaseAssessmentDetail] CHECK CONSTRAINT [FK_CaseAssessmentDetail_Durations_AbsentPeriodDuration]
GO
ALTER TABLE [global].[CaseAssessmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetail_PatientImpactOnWork] FOREIGN KEY([PatientImpactOnWorkID])
REFERENCES [lookup].[PatientImpactOnWork] ([PatientImpactOnWorkID])
GO
ALTER TABLE [global].[CaseAssessmentDetail] CHECK CONSTRAINT [FK_CaseAssessmentDetail_PatientImpactOnWork]
GO
ALTER TABLE [global].[CaseAssessmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetail_PatientLevelOfRecoveries] FOREIGN KEY([PatientLevelOfRecoveryID])
REFERENCES [lookup].[PatientLevelOfRecoveries] ([PatientLevelOfRecoveryID])
GO
ALTER TABLE [global].[CaseAssessmentDetail] CHECK CONSTRAINT [FK_CaseAssessmentDetail_PatientLevelOfRecoveries]
GO
ALTER TABLE [global].[CaseAssessmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetail_PatientLevelOfRecoveries1] FOREIGN KEY([FollowingTreatmentPatientLevelOfRecoveryID])
REFERENCES [lookup].[PatientLevelOfRecoveries] ([PatientLevelOfRecoveryID])
GO
ALTER TABLE [global].[CaseAssessmentDetail] CHECK CONSTRAINT [FK_CaseAssessmentDetail_PatientLevelOfRecoveries1]
GO
ALTER TABLE [global].[CaseAssessmentDetail]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetail_Practitioners] FOREIGN KEY([PractitionerID])
REFERENCES [global].[Practitioners] ([PractitionerID])
GO
ALTER TABLE [global].[CaseAssessmentDetail] CHECK CONSTRAINT [FK_CaseAssessmentDetail_Practitioners]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_AssessmentServices] FOREIGN KEY([AssessmentServiceID])
REFERENCES [lookup].[AssessmentServices] ([AssessmentServiceID])
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_AssessmentServices]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_CaseAssessmentDetail] FOREIGN KEY([CaseAssessmentDetailID])
REFERENCES [global].[CaseAssessmentDetail] ([CaseAssessmentDetailID])
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_CaseAssessmentDetail]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_CaseAssessments] FOREIGN KEY([CaseID])
REFERENCES [global].[CaseAssessments] ([CaseID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_CaseAssessments]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_Durations_AbsentPeriodDuration] FOREIGN KEY([AbsentPeriodDurationID])
REFERENCES [lookup].[Durations] ([DurationID])
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_Durations_AbsentPeriodDuration]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_Durations_PatientTreatmentPeriodDuration] FOREIGN KEY([PatientTreatmentPeriodDurationID])
REFERENCES [lookup].[Durations] ([DurationID])
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_Durations_PatientTreatmentPeriodDuration]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_PatientImpactOnWork] FOREIGN KEY([PatientImpactOnWorkID])
REFERENCES [lookup].[PatientImpactOnWork] ([PatientImpactOnWorkID])
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_PatientImpactOnWork]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_PatientLevelOfRecoveries] FOREIGN KEY([PatientLevelOfRecoveryID])
REFERENCES [lookup].[PatientLevelOfRecoveries] ([PatientLevelOfRecoveryID])
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_PatientLevelOfRecoveries]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_PatientLevelOfRecoveries1] FOREIGN KEY([FollowingTreatmentPatientLevelOfRecoveryID])
REFERENCES [lookup].[PatientLevelOfRecoveries] ([PatientLevelOfRecoveryID])
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_PatientLevelOfRecoveries1]
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentDetailHistory_Practitioners] FOREIGN KEY([PractitionerID])
REFERENCES [global].[Practitioners] ([PractitionerID])
GO
ALTER TABLE [global].[CaseAssessmentDetailHistory] CHECK CONSTRAINT [FK_CaseAssessmentDetailHistory_Practitioners]
GO
ALTER TABLE [global].[CaseAssessmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentHistory_AssessmentAuthorisations] FOREIGN KEY([AssessmentAuthorisationID])
REFERENCES [lookup].[AssessmentAuthorisations] ([AssessmentAuthorisationID])
GO
ALTER TABLE [global].[CaseAssessmentHistory] CHECK CONSTRAINT [FK_CaseAssessmentHistory_AssessmentAuthorisations]
GO
ALTER TABLE [global].[CaseAssessmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentHistory_AssessmentServices] FOREIGN KEY([AssessmentServiceID])
REFERENCES [lookup].[AssessmentServices] ([AssessmentServiceID])
GO
ALTER TABLE [global].[CaseAssessmentHistory] CHECK CONSTRAINT [FK_CaseAssessmentHistory_AssessmentServices]
GO
ALTER TABLE [global].[CaseAssessmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentHistory_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
GO
ALTER TABLE [global].[CaseAssessmentHistory] CHECK CONSTRAINT [FK_CaseAssessmentHistory_Cases]
GO
ALTER TABLE [global].[CaseAssessmentHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentHistory_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [global].[CaseAssessmentHistory] CHECK CONSTRAINT [FK_CaseAssessmentHistory_Users]
GO
ALTER TABLE [global].[CaseAssessmentPatientImpactHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentPatientImpactHistory_CaseAssessmentDetailHistory] FOREIGN KEY([CaseAssessmentDetailHistoryID])
REFERENCES [global].[CaseAssessmentDetailHistory] ([CaseAssessmentDetailHistoryID])
GO
ALTER TABLE [global].[CaseAssessmentPatientImpactHistory] CHECK CONSTRAINT [FK_CaseAssessmentPatientImpactHistory_CaseAssessmentDetailHistory]
GO
ALTER TABLE [global].[CaseAssessmentPatientImpactHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentPatientImpactHistory_PatientImpacts] FOREIGN KEY([PatientImpactID])
REFERENCES [lookup].[PatientImpacts] ([PatientImpactID])
GO
ALTER TABLE [global].[CaseAssessmentPatientImpactHistory] CHECK CONSTRAINT [FK_CaseAssessmentPatientImpactHistory_PatientImpacts]
GO
ALTER TABLE [global].[CaseAssessmentPatientImpactHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentPatientImpactHistory_PatientImpactValues] FOREIGN KEY([PatientImpactValueID])
REFERENCES [lookup].[PatientImpactValues] ([PatientImpactValueID])
GO
ALTER TABLE [global].[CaseAssessmentPatientImpactHistory] CHECK CONSTRAINT [FK_CaseAssessmentPatientImpactHistory_PatientImpactValues]
GO
ALTER TABLE [global].[CaseAssessmentPatientImpacts]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentPatientImpacts_CaseAssessmentDetail] FOREIGN KEY([CaseAssessmentDetailID])
REFERENCES [global].[CaseAssessmentDetail] ([CaseAssessmentDetailID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseAssessmentPatientImpacts] CHECK CONSTRAINT [FK_CaseAssessmentPatientImpacts_CaseAssessmentDetail]
GO
ALTER TABLE [global].[CaseAssessmentPatientImpacts]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentPatientImpacts_PatientImpacts] FOREIGN KEY([PatientImpactID])
REFERENCES [lookup].[PatientImpacts] ([PatientImpactID])
GO
ALTER TABLE [global].[CaseAssessmentPatientImpacts] CHECK CONSTRAINT [FK_CaseAssessmentPatientImpacts_PatientImpacts]
GO
ALTER TABLE [global].[CaseAssessmentPatientImpacts]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentPatientImpacts_PatientImpactValues] FOREIGN KEY([PatientImpactValueID])
REFERENCES [lookup].[PatientImpactValues] ([PatientImpactValueID])
GO
ALTER TABLE [global].[CaseAssessmentPatientImpacts] CHECK CONSTRAINT [FK_CaseAssessmentPatientImpacts_PatientImpactValues]
GO
ALTER TABLE [global].[CaseAssessmentPatientInjuryHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentPatientInjuryHistory_CaseAssessmentDetailHistory] FOREIGN KEY([CaseAssessmentDetailHistoryID])
REFERENCES [global].[CaseAssessmentDetailHistory] ([CaseAssessmentDetailHistoryID])
GO
ALTER TABLE [global].[CaseAssessmentPatientInjuryHistory] CHECK CONSTRAINT [FK_CaseAssessmentPatientInjuryHistory_CaseAssessmentDetailHistory]
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethodHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentTreatmentMethodHistory_CaseAssessmentHistory] FOREIGN KEY([CaseAssessmentHistoryID])
REFERENCES [global].[CaseAssessmentHistory] ([CaseAssessmentHistoryID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethodHistory] CHECK CONSTRAINT [FK_CaseAssessmentTreatmentMethodHistory_CaseAssessmentHistory]
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethodHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentTreatmentMethodHistory_CaseAssessments] FOREIGN KEY([CaseID])
REFERENCES [global].[CaseAssessments] ([CaseID])
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethodHistory] CHECK CONSTRAINT [FK_CaseAssessmentTreatmentMethodHistory_CaseAssessments]
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethodHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentTreatmentMethodHistory_ProposedTreatmentMethods] FOREIGN KEY([ProposedTreatmentMethodID])
REFERENCES [lookup].[ProposedTreatmentMethods] ([ProposedTreatmentMethodID])
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethodHistory] CHECK CONSTRAINT [FK_CaseAssessmentTreatmentMethodHistory_ProposedTreatmentMethods]
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethods]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentTreatmentMethods_CaseAssessments] FOREIGN KEY([CaseID])
REFERENCES [global].[CaseAssessments] ([CaseID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethods] CHECK CONSTRAINT [FK_CaseAssessmentTreatmentMethods_CaseAssessments]
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethods]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentTreatmentMethods_ProposedTreatmentMethods] FOREIGN KEY([ProposedTreatmentMethodID])
REFERENCES [lookup].[ProposedTreatmentMethods] ([ProposedTreatmentMethodID])
GO
ALTER TABLE [global].[CaseAssessmentProposedTreatmentMethods] CHECK CONSTRAINT [FK_CaseAssessmentTreatmentMethods_ProposedTreatmentMethods]
GO
ALTER TABLE [global].[CaseAssessmentRatings]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentRatings_AssessmentServices] FOREIGN KEY([AssessmentServiceID])
REFERENCES [lookup].[AssessmentServices] ([AssessmentServiceID])
ON UPDATE CASCADE
GO
ALTER TABLE [global].[CaseAssessmentRatings] CHECK CONSTRAINT [FK_CaseAssessmentRatings_AssessmentServices]
GO
ALTER TABLE [global].[CaseAssessmentRatings]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessmentRatings_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseAssessmentRatings] CHECK CONSTRAINT [FK_CaseAssessmentRatings_Cases]
GO
ALTER TABLE [global].[CaseAssessments]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessments_AssessmentAuthorisations] FOREIGN KEY([AssessmentAuthorisationID])
REFERENCES [lookup].[AssessmentAuthorisations] ([AssessmentAuthorisationID])
GO
ALTER TABLE [global].[CaseAssessments] CHECK CONSTRAINT [FK_CaseAssessments_AssessmentAuthorisations]
GO
ALTER TABLE [global].[CaseAssessments]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessments_AssessmentServices] FOREIGN KEY([AssessmentServiceID])
REFERENCES [lookup].[AssessmentServices] ([AssessmentServiceID])
GO
ALTER TABLE [global].[CaseAssessments] CHECK CONSTRAINT [FK_CaseAssessments_AssessmentServices]
GO
ALTER TABLE [global].[CaseAssessments]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessments_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
GO
ALTER TABLE [global].[CaseAssessments] CHECK CONSTRAINT [FK_CaseAssessments_Cases]
GO
ALTER TABLE [global].[CaseAssessments]  WITH CHECK ADD  CONSTRAINT [FK_CaseAssessments_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [global].[CaseAssessments] CHECK CONSTRAINT [FK_CaseAssessments_Users]
GO
ALTER TABLE [global].[CaseBespokeServicePricing]  WITH CHECK ADD  CONSTRAINT [FK_CaseBespokeServicePricing_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
GO
ALTER TABLE [global].[CaseBespokeServicePricing] CHECK CONSTRAINT [FK_CaseBespokeServicePricing_Cases]
GO
ALTER TABLE [global].[CaseBespokeServicePricing]  WITH CHECK ADD  CONSTRAINT [FK_CaseBespokeServicePricing_TreatmentCategoryBespokeServices] FOREIGN KEY([TreatmentCategoryBespokeServiceID])
REFERENCES [lookup].[TreatmentCategoryBespokeServices] ([TreatmentCategoryBespokeServiceID])
GO
ALTER TABLE [global].[CaseBespokeServicePricing] CHECK CONSTRAINT [FK_CaseBespokeServicePricing_TreatmentCategoryBespokeServices]
GO
ALTER TABLE [global].[CaseCommunicationHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseCommunicationHistory_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseCommunicationHistory] CHECK CONSTRAINT [FK_CaseCommunicationHistory_Cases]
GO
ALTER TABLE [global].[CaseCommunicationHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseCommunicationHistory_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [global].[CaseCommunicationHistory] CHECK CONSTRAINT [FK_CaseCommunicationHistory_Users]
GO
ALTER TABLE [global].[CaseContacts]  WITH CHECK ADD  CONSTRAINT [FK_CaseContacts_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseContacts] CHECK CONSTRAINT [FK_CaseContacts_Cases]
GO
ALTER TABLE [global].[CaseContacts]  WITH CHECK ADD  CONSTRAINT [FK_CaseContacts_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseContacts] CHECK CONSTRAINT [FK_CaseContacts_Users]
GO
ALTER TABLE [global].[CaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseHistory_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
GO
ALTER TABLE [global].[CaseHistory] CHECK CONSTRAINT [FK_CaseHistory_Cases]
GO
ALTER TABLE [global].[CaseHistory]  WITH CHECK ADD  CONSTRAINT [FK_CaseHistory_EventTypes] FOREIGN KEY([EventTypeID])
REFERENCES [lookup].[EventTypes] ([EventTypeID])
GO
ALTER TABLE [global].[CaseHistory] CHECK CONSTRAINT [FK_CaseHistory_EventTypes]
GO
ALTER TABLE [global].[CaseNotes]  WITH CHECK ADD  CONSTRAINT [FK_CaseNotes_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [global].[CaseNotes] CHECK CONSTRAINT [FK_CaseNotes_Users]
GO
ALTER TABLE [global].[CasePatientContactAttempts]  WITH CHECK ADD  CONSTRAINT [FK_CasePatientContactAttempts_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CasePatientContactAttempts] CHECK CONSTRAINT [FK_CasePatientContactAttempts_Cases]
GO
ALTER TABLE [global].[Cases]  WITH CHECK ADD  CONSTRAINT [FK_Cases_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
GO
ALTER TABLE [global].[Cases] CHECK CONSTRAINT [FK_Cases_Cases]
GO
ALTER TABLE [global].[Cases]  WITH CHECK ADD  CONSTRAINT [FK_Cases_DrugTests] FOREIGN KEY([DrugTestID])
REFERENCES [global].[DrugTests] ([DrugTestID])
GO
ALTER TABLE [global].[Cases] CHECK CONSTRAINT [FK_Cases_DrugTests]
GO
ALTER TABLE [global].[Cases]  WITH CHECK ADD  CONSTRAINT [FK_Cases_JobDemands] FOREIGN KEY([JobDemandID])
REFERENCES [global].[JobDemands] ([JobDemandID])
GO
ALTER TABLE [global].[Cases] CHECK CONSTRAINT [FK_Cases_JobDemands]
GO
ALTER TABLE [global].[CaseTreatmentPricing]  WITH CHECK ADD  CONSTRAINT [FK_CaseTreatmentPricing_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
GO
ALTER TABLE [global].[CaseTreatmentPricing] CHECK CONSTRAINT [FK_CaseTreatmentPricing_Cases]
GO
ALTER TABLE [global].[CaseTreatmentPricing]  WITH CHECK ADD  CONSTRAINT [FK_CaseTreatmentPricing_ReferrerProjectTreatmentPricing] FOREIGN KEY([ReferrerPricingID])
REFERENCES [referrer].[ReferrerProjectTreatmentPricing] ([PricingID])
GO
ALTER TABLE [global].[CaseTreatmentPricing] CHECK CONSTRAINT [FK_CaseTreatmentPricing_ReferrerProjectTreatmentPricing]
GO
ALTER TABLE [global].[CaseTreatmentPricing]  WITH CHECK ADD  CONSTRAINT [FK_CaseTreatmentPricing_SupplierTreatmentPricing] FOREIGN KEY([SupplierPriceID])
REFERENCES [supplier].[SupplierTreatmentPricing] ([PricingID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseTreatmentPricing] CHECK CONSTRAINT [FK_CaseTreatmentPricing_SupplierTreatmentPricing]
GO
ALTER TABLE [global].[CaseVAT]  WITH CHECK ADD  CONSTRAINT [FK_CaseVAT_Cases1] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[CaseVAT] CHECK CONSTRAINT [FK_CaseVAT_Cases1]
GO
ALTER TABLE [global].[InvoiceCollectionAction]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceCollectionAction_Invoices] FOREIGN KEY([InvoiceID])
REFERENCES [global].[Invoices] ([InvoiceID])
GO
ALTER TABLE [global].[InvoiceCollectionAction] CHECK CONSTRAINT [FK_InvoiceCollectionAction_Invoices]
GO
ALTER TABLE [global].[InvoiceCollectionAction]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceCollectionAction_Users] FOREIGN KEY([UserId])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [global].[InvoiceCollectionAction] CHECK CONSTRAINT [FK_InvoiceCollectionAction_Users]
GO
ALTER TABLE [global].[InvoicePayment]  WITH CHECK ADD  CONSTRAINT [FK_InvoicePayment_Invoices] FOREIGN KEY([InvoiceID])
REFERENCES [global].[Invoices] ([InvoiceID])
GO
ALTER TABLE [global].[InvoicePayment] CHECK CONSTRAINT [FK_InvoicePayment_Invoices]
GO
ALTER TABLE [global].[InvoicePayment]  WITH CHECK ADD  CONSTRAINT [FK_InvoicePayment_Users] FOREIGN KEY([UserId])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [global].[InvoicePayment] CHECK CONSTRAINT [FK_InvoicePayment_Users]
GO
ALTER TABLE [global].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Cases] FOREIGN KEY([CaseId])
REFERENCES [global].[Cases] ([CaseID])
GO
ALTER TABLE [global].[Invoices] CHECK CONSTRAINT [FK_Invoices_Cases]
GO
ALTER TABLE [global].[Invoices]  WITH CHECK ADD  CONSTRAINT [FK_Invoices_Users] FOREIGN KEY([UserId])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [global].[Invoices] CHECK CONSTRAINT [FK_Invoices_Users]
GO
ALTER TABLE [global].[PasswordHistory]  WITH CHECK ADD  CONSTRAINT [FK_PasswordHistory_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [global].[PasswordHistory] CHECK CONSTRAINT [FK_PasswordHistory_Users]
GO
ALTER TABLE [global].[Patients]  WITH NOCHECK ADD  CONSTRAINT [FK_Patients_Gender] FOREIGN KEY([GenderID])
REFERENCES [lookup].[Genders] ([GenderID])
GO
ALTER TABLE [global].[Patients] CHECK CONSTRAINT [FK_Patients_Gender]
GO
ALTER TABLE [global].[Patients]  WITH CHECK ADD  CONSTRAINT [FK_Patients_PrimaryConditions] FOREIGN KEY([PrimaryConditionID])
REFERENCES [lookup].[PrimaryConditions] ([PrimaryConditionID])
GO
ALTER TABLE [global].[Patients] CHECK CONSTRAINT [FK_Patients_PrimaryConditions]
GO
ALTER TABLE [global].[PractitionerExpertise]  WITH NOCHECK ADD  CONSTRAINT [FK_PractitionerExpertise_AreasofExpertise] FOREIGN KEY([AreaofExpertiseID])
REFERENCES [lookup].[AreasofExpertise] ([AreasofExpertiseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [global].[PractitionerExpertise] CHECK CONSTRAINT [FK_PractitionerExpertise_AreasofExpertise]
GO
ALTER TABLE [global].[PractitionerExpertise]  WITH CHECK ADD  CONSTRAINT [FK_PractitionerExpertise_Practitioner] FOREIGN KEY([PractitionerID])
REFERENCES [global].[Practitioners] ([PractitionerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [global].[PractitionerExpertise] CHECK CONSTRAINT [FK_PractitionerExpertise_Practitioner]
GO
ALTER TABLE [global].[PractitionerRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_PractitionerRegistrations_Practitioners] FOREIGN KEY([PractitionerID])
REFERENCES [global].[Practitioners] ([PractitionerID])
ON DELETE CASCADE
GO
ALTER TABLE [global].[PractitionerRegistrations] CHECK CONSTRAINT [FK_PractitionerRegistrations_Practitioners]
GO
ALTER TABLE [global].[PractitionerRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_PractitionerRegistrations_RegistrationTypes] FOREIGN KEY([RegistrationTypeID])
REFERENCES [lookup].[RegistrationTypes] ([RegistrationTypeID])
GO
ALTER TABLE [global].[PractitionerRegistrations] CHECK CONSTRAINT [FK_PractitionerRegistrations_RegistrationTypes]
GO
ALTER TABLE [global].[PractitionerRegistrations]  WITH CHECK ADD  CONSTRAINT [FK_PractitionerRegistrations_TreatmentCategories] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
GO
ALTER TABLE [global].[PractitionerRegistrations] CHECK CONSTRAINT [FK_PractitionerRegistrations_TreatmentCategories]
GO
ALTER TABLE [global].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_ReferrerLocations] FOREIGN KEY([ReferrerLocationID])
REFERENCES [referrer].[ReferrerLocations] ([ReferrerLocationID])
GO
ALTER TABLE [global].[Users] CHECK CONSTRAINT [FK_Users_ReferrerLocations]
GO
ALTER TABLE [global].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [supplier].[Suppliers] ([SupplierID])
GO
ALTER TABLE [global].[Users] CHECK CONSTRAINT [FK_Users_Suppliers]
GO
ALTER TABLE [global].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_UserTypes] FOREIGN KEY([UserTypeID])
REFERENCES [lookup].[UserTypes] ([UserTypeID])
GO
ALTER TABLE [global].[Users] CHECK CONSTRAINT [FK_Users_UserTypes]
GO
ALTER TABLE [lookup].[EmailTypes]  WITH CHECK ADD  CONSTRAINT [FK_EmailTypes_UserTypes] FOREIGN KEY([UserTypeID])
REFERENCES [lookup].[UserTypes] ([UserTypeID])
GO
ALTER TABLE [lookup].[EmailTypes] CHECK CONSTRAINT [FK_EmailTypes_UserTypes]
GO
ALTER TABLE [lookup].[TreatmentCategoryAreasofExpetises]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryAreasofExpetises_AreasofExpertise] FOREIGN KEY([AreasofExpertiseID])
REFERENCES [lookup].[AreasofExpertise] ([AreasofExpertiseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [lookup].[TreatmentCategoryAreasofExpetises] CHECK CONSTRAINT [FK_TreatmentCategoryAreasofExpetises_AreasofExpertise]
GO
ALTER TABLE [lookup].[TreatmentCategoryAreasofExpetises]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryAreasofExpetises_TreatmentCategories] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [lookup].[TreatmentCategoryAreasofExpetises] CHECK CONSTRAINT [FK_TreatmentCategoryAreasofExpetises_TreatmentCategories]
GO
ALTER TABLE [lookup].[TreatmentCategoryBespokeServices]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryBespokeServices_BespokeServices] FOREIGN KEY([BespokeServiceID])
REFERENCES [lookup].[BespokeServices] ([BespokeServiceID])
GO
ALTER TABLE [lookup].[TreatmentCategoryBespokeServices] CHECK CONSTRAINT [FK_TreatmentCategoryBespokeServices_BespokeServices]
GO
ALTER TABLE [lookup].[TreatmentCategoryBespokeServices]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryBespokeServices_TreatmentCategories] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
GO
ALTER TABLE [lookup].[TreatmentCategoryBespokeServices] CHECK CONSTRAINT [FK_TreatmentCategoryBespokeServices_TreatmentCategories]
GO
ALTER TABLE [lookup].[TreatmentCategoryPricingTypes]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryPricingTypes_PricingTypes] FOREIGN KEY([PricingTypeID])
REFERENCES [lookup].[PricingTypes] ([PricingTypeID])
GO
ALTER TABLE [lookup].[TreatmentCategoryPricingTypes] CHECK CONSTRAINT [FK_TreatmentCategoryPricingTypes_PricingTypes]
GO
ALTER TABLE [lookup].[TreatmentCategoryPricingTypes]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryPricingTypes_TreatmentCategories] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
GO
ALTER TABLE [lookup].[TreatmentCategoryPricingTypes] CHECK CONSTRAINT [FK_TreatmentCategoryPricingTypes_TreatmentCategories]
GO
ALTER TABLE [lookup].[TreatmentCategoryRegistrationTypes]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryRegistrationTypes_RegistrationTypes] FOREIGN KEY([RegistrationTypeID])
REFERENCES [lookup].[RegistrationTypes] ([RegistrationTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [lookup].[TreatmentCategoryRegistrationTypes] CHECK CONSTRAINT [FK_TreatmentCategoryRegistrationTypes_RegistrationTypes]
GO
ALTER TABLE [lookup].[TreatmentCategoryRegistrationTypes]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryRegistrationTypes_TreatmentCategories] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [lookup].[TreatmentCategoryRegistrationTypes] CHECK CONSTRAINT [FK_TreatmentCategoryRegistrationTypes_TreatmentCategories]
GO
ALTER TABLE [lookup].[TreatmentCategoryTreatmentTypes]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryTreatmentTypes_TreatmentCategories] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [lookup].[TreatmentCategoryTreatmentTypes] CHECK CONSTRAINT [FK_TreatmentCategoryTreatmentTypes_TreatmentCategories]
GO
ALTER TABLE [lookup].[TreatmentCategoryTreatmentTypes]  WITH CHECK ADD  CONSTRAINT [FK_TreatmentCategoryTreatmentTypes_TreatmentTypes] FOREIGN KEY([TreatmentTypeID])
REFERENCES [lookup].[TreatmentTypes] ([TreatmentTypeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [lookup].[TreatmentCategoryTreatmentTypes] CHECK CONSTRAINT [FK_TreatmentCategoryTreatmentTypes_TreatmentTypes]
GO
ALTER TABLE [referrer].[ProjectTreatmentSLAs]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTreatmentSLAs_ProjectTreatmentSLAs] FOREIGN KEY([ReferrerProjectTreatmentID])
REFERENCES [referrer].[ReferrerProjectTreatments] ([ReferrerProjectTreatmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ProjectTreatmentSLAs] CHECK CONSTRAINT [FK_ProjectTreatmentSLAs_ProjectTreatmentSLAs]
GO
ALTER TABLE [referrer].[ProjectTreatmentSLAs]  WITH CHECK ADD  CONSTRAINT [FK_ProjectTreatmentSLAs_ServiceLevelAgreements] FOREIGN KEY([ServiceLevelAgreementID])
REFERENCES [lookup].[ServiceLevelAgreements] ([ServiceLevelAgreementID])
GO
ALTER TABLE [referrer].[ProjectTreatmentSLAs] CHECK CONSTRAINT [FK_ProjectTreatmentSLAs_ServiceLevelAgreements]
GO
ALTER TABLE [referrer].[ReferrerCaseAssessmentModifications]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerCaseModifications_CaseAssessments] FOREIGN KEY([CaseID])
REFERENCES [global].[CaseAssessments] ([CaseID])
GO
ALTER TABLE [referrer].[ReferrerCaseAssessmentModifications] CHECK CONSTRAINT [FK_ReferrerCaseModifications_CaseAssessments]
GO
ALTER TABLE [referrer].[ReferrerCaseContacts]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerCaseContacts_Cases] FOREIGN KEY([CaseID])
REFERENCES [global].[Cases] ([CaseID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerCaseContacts] CHECK CONSTRAINT [FK_ReferrerCaseContacts_Cases]
GO
ALTER TABLE [referrer].[ReferrerCaseContacts]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerCaseContacts_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [referrer].[ReferrerCaseContacts] CHECK CONSTRAINT [FK_ReferrerCaseContacts_Users]
GO
ALTER TABLE [referrer].[ReferrerDocuments]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerDocuments_DocumentTypes] FOREIGN KEY([ReferrerDocumentTypeID])
REFERENCES [lookup].[ReferrerDocumentType] ([ReferrerDocumentTypeID])
GO
ALTER TABLE [referrer].[ReferrerDocuments] CHECK CONSTRAINT [FK_ReferrerDocuments_DocumentTypes]
GO
ALTER TABLE [referrer].[ReferrerDocuments]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerDocuments_ReferrerDocuments] FOREIGN KEY([ReferrerID])
REFERENCES [referrer].[Referrers] ([ReferrerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerDocuments] CHECK CONSTRAINT [FK_ReferrerDocuments_ReferrerDocuments]
GO
ALTER TABLE [referrer].[ReferrerDocuments]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerDocuments_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [referrer].[ReferrerDocuments] CHECK CONSTRAINT [FK_ReferrerDocuments_Users]
GO
ALTER TABLE [referrer].[ReferrerLocations]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerLocations_Referrers] FOREIGN KEY([ReferrerID])
REFERENCES [referrer].[Referrers] ([ReferrerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerLocations] CHECK CONSTRAINT [FK_ReferrerLocations_Referrers]
GO
ALTER TABLE [referrer].[ReferrerProjects]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjects_EmailSendingOptions] FOREIGN KEY([EmailSendingOptionID])
REFERENCES [lookup].[EmailSendingOptions] ([EmailSendingOptionID])
ON UPDATE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjects] CHECK CONSTRAINT [FK_ReferrerProjects_EmailSendingOptions]
GO
ALTER TABLE [referrer].[ReferrerProjects]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjects_Referrers] FOREIGN KEY([ReferrerID])
REFERENCES [referrer].[Referrers] ([ReferrerID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjects] CHECK CONSTRAINT [FK_ReferrerProjects_Referrers]
GO
ALTER TABLE [referrer].[ReferrerProjects]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjects_Status] FOREIGN KEY([StatusID])
REFERENCES [lookup].[Status] ([StatusID])
GO
ALTER TABLE [referrer].[ReferrerProjects] CHECK CONSTRAINT [FK_ReferrerProjects_Status]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAssessments]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentAssessments_ReferrerProjectTreatments] FOREIGN KEY([ReferrerProjectTreatmentID])
REFERENCES [referrer].[ReferrerProjectTreatments] ([ReferrerProjectTreatmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAssessments] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentAssessments_ReferrerProjectTreatments]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAuthorisations]  WITH NOCHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentAuthorisations_DelegatedAuthorisationTypes] FOREIGN KEY([DelegatedAuthorisationTypeID])
REFERENCES [lookup].[DelegatedAuthorisationTypes] ([DelegatedAuthorisationTypeID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAuthorisations] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentAuthorisations_DelegatedAuthorisationTypes]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAuthorisations]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentAuthorisations_ReferrerProjectTreatments] FOREIGN KEY([ReferrerProjectTreatmentID])
REFERENCES [referrer].[ReferrerProjectTreatments] ([ReferrerProjectTreatmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAuthorisations] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentAuthorisations_ReferrerProjectTreatments]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAuthorisations]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentAuthorisations_TreatmentCategories] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAuthorisations] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentAuthorisations_TreatmentCategories]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentDocumentSetup]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentDocumentSetup_AssessmentServices] FOREIGN KEY([AssessmentServiceID])
REFERENCES [lookup].[AssessmentServices] ([AssessmentServiceID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentDocumentSetup] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentDocumentSetup_AssessmentServices]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentDocumentSetup]  WITH NOCHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentDocumentSetup_DocumentSetupTypes] FOREIGN KEY([DocumentSetupTypeID])
REFERENCES [lookup].[DocumentSetupTypes] ([DocumentSetupTypeID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentDocumentSetup] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentDocumentSetup_DocumentSetupTypes]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentDocumentSetup]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentDocumentSetup_ReferrerProjectTreatments] FOREIGN KEY([ReferrerProjectTreatmentID])
REFERENCES [referrer].[ReferrerProjectTreatments] ([ReferrerProjectTreatmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentDocumentSetup] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentDocumentSetup_ReferrerProjectTreatments]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentEmails]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentEmails_EmailTypes] FOREIGN KEY([EmailTypeID])
REFERENCES [lookup].[EmailTypes] ([EmailTypeID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentEmails] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentEmails_EmailTypes]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentEmails]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentEmails_EmailTypeValues] FOREIGN KEY([EmailTypeValueID])
REFERENCES [lookup].[EmailTypeValues] ([EmailTypeValueID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentEmails] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentEmails_EmailTypeValues]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentEmails]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentEmails_ReferrerProjectTreatments] FOREIGN KEY([ReferrerProjectTreatmentID])
REFERENCES [referrer].[ReferrerProjectTreatments] ([ReferrerProjectTreatmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentEmails] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentEmails_ReferrerProjectTreatments]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentInvoice_InvoiceMethods] FOREIGN KEY([InvoiceMethodID])
REFERENCES [lookup].[InvoiceMethods] ([InvoiceMethodID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentInvoice] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentInvoice_InvoiceMethods]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentInvoice]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentInvoice_ReferrerProjectTreatments] FOREIGN KEY([ReferrerProjectTreatmentID])
REFERENCES [referrer].[ReferrerProjectTreatments] ([ReferrerProjectTreatmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentInvoice] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentInvoice_ReferrerProjectTreatments]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentPricing]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentPricing_PricingTypes] FOREIGN KEY([PricingTypeID])
REFERENCES [lookup].[PricingTypes] ([PricingTypeID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentPricing] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentPricing_PricingTypes]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentPricing]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatmentPricing_ReferrerProjectTreatments] FOREIGN KEY([ReferrerProjectTreatmentID])
REFERENCES [referrer].[ReferrerProjectTreatments] ([ReferrerProjectTreatmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentPricing] CHECK CONSTRAINT [FK_ReferrerProjectTreatmentPricing_ReferrerProjectTreatments]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatments]  WITH CHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatments_ReferrerProjects] FOREIGN KEY([ReferrerProjectID])
REFERENCES [referrer].[ReferrerProjects] ([ReferrerProjectID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [referrer].[ReferrerProjectTreatments] CHECK CONSTRAINT [FK_ReferrerProjectTreatments_ReferrerProjects]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatments]  WITH NOCHECK ADD  CONSTRAINT [FK_ReferrerProjectTreatments_TreatmentCategories] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
GO
ALTER TABLE [referrer].[ReferrerProjectTreatments] CHECK CONSTRAINT [FK_ReferrerProjectTreatments_TreatmentCategories]
GO
ALTER TABLE [supplier].[SupplierClinicalAudit]  WITH CHECK ADD  CONSTRAINT [FK_SupplierClinicalAudit_SupplierDocuments] FOREIGN KEY([SupplierDocumentID])
REFERENCES [supplier].[SupplierDocuments] ([SupplierDocumentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierClinicalAudit] CHECK CONSTRAINT [FK_SupplierClinicalAudit_SupplierDocuments]
GO
ALTER TABLE [supplier].[SupplierClinicalAudit]  WITH CHECK ADD  CONSTRAINT [FK_SupplierClinicalAudit_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [supplier].[Suppliers] ([SupplierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierClinicalAudit] CHECK CONSTRAINT [FK_SupplierClinicalAudit_Suppliers]
GO
ALTER TABLE [supplier].[SupplierClinicalAudit]  WITH CHECK ADD  CONSTRAINT [FK_SupplierClinicalAudit_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierClinicalAudit] CHECK CONSTRAINT [FK_SupplierClinicalAudit_Users]
GO
ALTER TABLE [supplier].[SupplierComplaints]  WITH CHECK ADD  CONSTRAINT [FK_SupplierComplaints_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [supplier].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierComplaints] CHECK CONSTRAINT [FK_SupplierComplaints_Suppliers]
GO
ALTER TABLE [supplier].[SupplierDocuments]  WITH CHECK ADD  CONSTRAINT [FK_SupplierDocuments_DocumentTypes] FOREIGN KEY([DocumentTypeID])
REFERENCES [lookup].[DocumentTypes] ([DocumentTypeID])
GO
ALTER TABLE [supplier].[SupplierDocuments] CHECK CONSTRAINT [FK_SupplierDocuments_DocumentTypes]
GO
ALTER TABLE [supplier].[SupplierDocuments]  WITH CHECK ADD  CONSTRAINT [FK_SupplierDocuments_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [supplier].[Suppliers] ([SupplierID])
GO
ALTER TABLE [supplier].[SupplierDocuments] CHECK CONSTRAINT [FK_SupplierDocuments_Suppliers]
GO
ALTER TABLE [supplier].[SupplierDocuments]  WITH CHECK ADD  CONSTRAINT [FK_SupplierDocuments_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [supplier].[SupplierDocuments] CHECK CONSTRAINT [FK_SupplierDocuments_Users]
GO
ALTER TABLE [supplier].[SupplierInsurance]  WITH CHECK ADD  CONSTRAINT [FK_SupplierInsured_SupplierDocuments] FOREIGN KEY([SupplierDocumentID])
REFERENCES [supplier].[SupplierDocuments] ([SupplierDocumentID])
GO
ALTER TABLE [supplier].[SupplierInsurance] CHECK CONSTRAINT [FK_SupplierInsured_SupplierDocuments]
GO
ALTER TABLE [supplier].[SupplierInsurance]  WITH CHECK ADD  CONSTRAINT [FK_SupplierInsured_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [supplier].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierInsurance] CHECK CONSTRAINT [FK_SupplierInsured_Suppliers]
GO
ALTER TABLE [supplier].[SupplierPractitioners]  WITH CHECK ADD  CONSTRAINT [FK_SupplierPractitioners_PractitionerRegistrations] FOREIGN KEY([PractitionerRegistrationID])
REFERENCES [global].[PractitionerRegistrations] ([PractitionerRegistrationID])
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierPractitioners] CHECK CONSTRAINT [FK_SupplierPractitioners_PractitionerRegistrations]
GO
ALTER TABLE [supplier].[SupplierPractitioners]  WITH CHECK ADD  CONSTRAINT [FK_SupplierPractitioners_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [supplier].[Suppliers] ([SupplierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierPractitioners] CHECK CONSTRAINT [FK_SupplierPractitioners_Suppliers]
GO
ALTER TABLE [supplier].[Suppliers]  WITH CHECK ADD  CONSTRAINT [FK_Suppliers_Status] FOREIGN KEY([StatusID])
REFERENCES [lookup].[Status] ([StatusID])
GO
ALTER TABLE [supplier].[Suppliers] CHECK CONSTRAINT [FK_Suppliers_Status]
GO
ALTER TABLE [supplier].[SupplierSiteAudit]  WITH CHECK ADD  CONSTRAINT [FK_SupplierSiteAudit_SupplierDocuments] FOREIGN KEY([SupplierDocumentID])
REFERENCES [supplier].[SupplierDocuments] ([SupplierDocumentID])
GO
ALTER TABLE [supplier].[SupplierSiteAudit] CHECK CONSTRAINT [FK_SupplierSiteAudit_SupplierDocuments]
GO
ALTER TABLE [supplier].[SupplierSiteAudit]  WITH CHECK ADD  CONSTRAINT [FK_SupplierSiteAudit_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [supplier].[Suppliers] ([SupplierID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierSiteAudit] CHECK CONSTRAINT [FK_SupplierSiteAudit_Suppliers]
GO
ALTER TABLE [supplier].[SupplierSiteAudit]  WITH CHECK ADD  CONSTRAINT [FK_SupplierSiteAudit_Users] FOREIGN KEY([UserID])
REFERENCES [global].[Users] ([UserID])
GO
ALTER TABLE [supplier].[SupplierSiteAudit] CHECK CONSTRAINT [FK_SupplierSiteAudit_Users]
GO
ALTER TABLE [supplier].[SupplierTreatmentPricing]  WITH CHECK ADD  CONSTRAINT [FK_SupplierTreatmentPricing_PricingTypes] FOREIGN KEY([PricingTypeID])
REFERENCES [lookup].[PricingTypes] ([PricingTypeID])
GO
ALTER TABLE [supplier].[SupplierTreatmentPricing] CHECK CONSTRAINT [FK_SupplierTreatmentPricing_PricingTypes]
GO
ALTER TABLE [supplier].[SupplierTreatmentPricing]  WITH CHECK ADD  CONSTRAINT [FK_SupplierTreatmentPricing_SupplierTreatments] FOREIGN KEY([SupplierTreatmentID])
REFERENCES [supplier].[SupplierTreatments] ([SupplierTreatmentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierTreatmentPricing] CHECK CONSTRAINT [FK_SupplierTreatmentPricing_SupplierTreatments]
GO
ALTER TABLE [supplier].[SupplierTreatments]  WITH CHECK ADD  CONSTRAINT [FK_SupplierTreatments_Suppliers] FOREIGN KEY([SupplierID])
REFERENCES [supplier].[Suppliers] ([SupplierID])
ON DELETE CASCADE
GO
ALTER TABLE [supplier].[SupplierTreatments] CHECK CONSTRAINT [FK_SupplierTreatments_Suppliers]
GO
ALTER TABLE [supplier].[SupplierTreatments]  WITH CHECK ADD  CONSTRAINT [FK_SupplierTreatments_SupplierTreatments] FOREIGN KEY([TreatmentCategoryID])
REFERENCES [lookup].[TreatmentCategories] ([TreatmentCategoryID])
GO
ALTER TABLE [supplier].[SupplierTreatments] CHECK CONSTRAINT [FK_SupplierTreatments_SupplierTreatments]
GO
ALTER TABLE [global].[Users]  WITH CHECK ADD  CONSTRAINT [CK_User_Supplier_Referrer_Relation_Check] CHECK  (([ReferrerID] IS NOT NULL AND [ReferrerLocationID] IS NOT NULL AND [SupplierID] IS NULL OR [SupplierID] IS NOT NULL AND [ReferrerID] IS NULL AND [ReferrerLocationID] IS NULL OR [ReferrerID] IS NULL AND [ReferrerLocationID] IS NULL AND [SupplierID] IS NULL))
GO
ALTER TABLE [global].[Users] CHECK CONSTRAINT [CK_User_Supplier_Referrer_Relation_Check]
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAuthorisations]  WITH CHECK ADD  CONSTRAINT [CK_ReferrerProjectTreatmentAuthorisations] CHECK  (([DelegatedAuthorisationTypeID]=(1) AND [Amount] IS NULL AND [Quantity] IS NOT NULL OR [DelegatedAuthorisationTypeID]=(2) AND [Amount] IS NOT NULL AND [Quantity] IS NULL))
GO
ALTER TABLE [referrer].[ReferrerProjectTreatmentAuthorisations] CHECK CONSTRAINT [CK_ReferrerProjectTreatmentAuthorisations]
GO
/****** Object:  StoredProcedure [dbo].[FindMyData_String]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- FindMyData_String '@skip'


CREATE PROCEDURE [dbo].[FindMyData_String]
    @DataToFind NVARCHAR(4000),
    @ExactMatch BIT = 0
AS
SET NOCOUNT ON

DECLARE @Temp TABLE(RowId INT IDENTITY(1,1), SchemaName sysname, TableName sysname, ColumnName SysName, DataType VARCHAR(100), DataFound BIT)

    INSERT  INTO @Temp(TableName,SchemaName, ColumnName, DataType)
    SELECT  C.Table_Name,C.TABLE_SCHEMA, C.Column_Name, C.Data_Type
    FROM    Information_Schema.Columns AS C
            INNER Join Information_Schema.Tables AS T
                ON C.Table_Name = T.Table_Name
        AND C.TABLE_SCHEMA = T.TABLE_SCHEMA
    WHERE   Table_Type = 'Base Table'
            And Data_Type In ('ntext','text','nvarchar','nchar','varchar','char')


DECLARE @i INT
DECLARE @MAX INT
DECLARE @TableName sysname
DECLARE @ColumnName sysname
DECLARE @SchemaName sysname
DECLARE @SQL NVARCHAR(4000)
DECLARE @PARAMETERS NVARCHAR(4000)
DECLARE @DataExists BIT
DECLARE @SQLTemplate NVARCHAR(4000)

SELECT  @SQLTemplate = CASE WHEN @ExactMatch = 1
                            THEN 'If Exists(Select *
                                          From   ReplaceTableName
                                          Where  Convert(nVarChar(4000), [ReplaceColumnName])
                                                       = ''' + @DataToFind + '''
                                          )
                                     Set @DataExists = 1
                                 Else
                                     Set @DataExists = 0'
                            ELSE 'If Exists(Select *
                                          From   ReplaceTableName
                                          Where  Convert(nVarChar(4000), [ReplaceColumnName])
                                                       Like ''%' + @DataToFind + '%''
                                          )
                                     Set @DataExists = 1
                                 Else
                                     Set @DataExists = 0'
                            END,
        @PARAMETERS = '@DataExists Bit OUTPUT',
        @i = 1

SELECT @i = 1, @MAX = MAX(RowId)
FROM   @Temp

WHILE @i <= @MAX
    BEGIN
        SELECT  @SQL = REPLACE(REPLACE(@SQLTemplate, 'ReplaceTableName', QUOTENAME(SchemaName) + '.' + QUOTENAME(TableName)), 'ReplaceColumnName', ColumnName)
        FROM    @Temp
        WHERE   RowId = @i


        PRINT @SQL
        EXEC SP_EXECUTESQL @SQL, @PARAMETERS, @DataExists = @DataExists OUTPUT

        IF @DataExists =1
            UPDATE @Temp SET DataFound = 1 WHERE RowId = @i

        SET @i = @i + 1
    END

SELECT  SchemaName,TableName, ColumnName
FROM    @Temp
WHERE   DataFound = 1



GO
/****** Object:  StoredProcedure [global].[Add_Case]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
-- =============================================   
-- Author:  <Robin Singh>   
-- Create date: <01-25-2013>   
-- Description: <Create the procedure to add global Case,>   
-- =============================================   
-- =============================================   
-- Author:  ftan   
-- Create date: 03-22-2013   
-- Description: Modified columns for insert statement   
-- =============================================   

-- =============================================   
-- Author:  RKUMAR
-- Create date: 09-06-2018
-- Description: #3376 - Referrer Portal - Add Referral - Treatment Type Dropdown
-- =============================================   

-- =============================================  
-- Author:  Rohit Kumar
-- Create date: 05-10-2018
-- Description: Add new column OfficeLocationID against task 3389
-- =============================================  
CREATE PROCEDURE [global].[Add_Case]  
   
@PatientID INT,   
@ReferrerID INT,  
@ReferrerProjectID INT,
@ReferrerProjectTreatmentID INT,   
@TreatmentTypeID INT,   
@CaseReferrerReferenceNumber VARCHAR(50),   
@CaseSpecialInstruction VARCHAR(MAX),   
@CaseReferrerDueDate DATETIME,   
@WorkflowID INT,   
@IsTriage BIT,
@InjuryType varchar(50) ,
@SendInvoiceTo  varchar(20),
@SendInvoiceName varchar(50),
@SendInvoiceEmail varchar(50),
@ReferrerAssignedUser int,
@SupplierAssignedUser int,
@InnovateNote varchar(max),
@OfficeLocationID int,
@EmployeeDetailID int,
@DrugTestID int,
@JobDemandID int,
@IsNewPolicyTypeID int, 
@NewPolicyReferenceNumber varchar(50) 
AS
BEGIN TRAN 
    DECLARE @CaseID INT 
     
   INSERT INTO [global].[Cases]   
           ([PatientID]   
           ,[ReferrerID]   
		   ,[ReferrerProjectID]
           ,[ReferrerProjectTreatmentID]   
           ,[TreatmentTypeID]   
           ,[CaseReferrerReferenceNumber]   
           ,[CaseSpecialInstruction]   
           ,[CaseReferrerDueDate]   
           ,[WorkflowID]   
           ,[IsTriage]   
           ,InjuryType
		   ,[SendInvoiceTo]
		   ,[SendInvoiceName]
		   ,[SendInvoiceEmail]
		   ,[ReferrerAssignedUser]
		   ,SupplierAssignedUser
		   ,InnovateNote
		   ,OfficeLocationID
		   ,EmployeeDetailID
		   ,DrugTestID
		   ,JobDemandID
		   ,IsNewPolicyTypeID 
           ,NewPolicyReferenceNumber 
           )   
     VALUES   
           (@PatientID   
           ,@ReferrerID   
		   ,@ReferrerProjectID
           ,@ReferrerProjectTreatmentID   
           ,@TreatmentTypeID   
           ,@CaseReferrerReferenceNumber
           ,@CaseSpecialInstruction
           ,@CaseReferrerDueDate
           ,@WorkflowID
           ,@IsTriage
           ,@InjuryType
		   ,@SendInvoiceTo
		   ,@SendInvoiceName
		   ,@SendInvoiceEmail
		   ,@ReferrerAssignedUser
		   ,@SupplierAssignedUser
		   ,@InnovateNote
		   ,@OfficeLocationID
		   ,@EmployeeDetailID
		   ,@DrugTestID
		   ,@JobDemandID
		   ,@IsNewPolicyTypeID
		   ,@NewPolicyReferenceNumber
		   )
            
  
              
    select @CaseID = SCOPE_IDENTITY()  
 


	UPDATE       global.Cases
	SET                TreatmentTypeID = TreatmentCategoryID
	FROM            global.Cases INNER JOIN
							 referrer.ReferrerProjectTreatments ON global.Cases.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID 
							 where referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID
	SET @TreatmentTypeID = (SELECT         TreatmentTypeID FROM            global.Cases WHERE CaseID =@CaseID)
     
   UPDATE [global].[Cases] SET CaseNumber = global.Get_CaseNumberByTreatmentTypeIDAndCaseID(@CaseID ,@TreatmentTypeID)  
   WHERE [global].[Cases].CaseID = @CaseID 
    
    
    
    
    if((SELECT     top 1 DocumentSetupTypeID 
	FROM         referrer.ReferrerProjectTreatmentDocumentSetup
	where ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID) = 1)
	begin
		UPDATE    global.Cases
	SET              IsCustom = 0   WHERE [global].[Cases].CaseID = @CaseID
	end
	else
	begin
		UPDATE    global.Cases
	SET              IsCustom = 1  WHERE [global].[Cases].CaseID = @CaseID
	end
	
	select @CaseID
    
   COMMIT TRAN
   


GO
/****** Object:  StoredProcedure [global].[Add_CaseAppointmentDate]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0
-- =============================================  
-- Author:  Robin Singh  
-- Create date: 18-April-2013
-- Description: Added Procedure Add_CaseAppointmentDate
-- Version : 1.0   
-- =============================================  


CREATE PROCEDURE [global].[Add_CaseAppointmentDate]  
 -- Add the parameters for the stored procedure here  
   (@CaseID INT, 
    @AppointmentDateTime  DATETIME,
    @FirstAppointmentOfferedDate DATETIME
    )  
AS  
BEGIN   
INSERT INTO [global].[CaseAppointmentDates]
           ([CaseID]
           ,[AppointmentDateTime]
           ,[FirstAppointmentOfferedDate]
           ,[CaseBookIADate]
           ,[IsCaseBookIADateUsed])
     VALUES
           (@CaseID  
           ,@AppointmentDateTime
           ,@FirstAppointmentOfferedDate
           ,getdate()
           ,1
           )  
     
END  


GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessment]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Latest Version: 1.1    
    
-- Author:  Manjit Singh    
-- Create date: April 30, 2013    
-- Description: to add CaseAssessments    
--  
-- Updated By : Robin Singh    
-- Create date: May 23, 2013    
-- updated Version : 1.1  
-- Description: added and update coloumn for model CaseAssessments    

-- Updated By : Vishal sen    
-- Create date: 14/8/2013    
-- updated Version : 1.2  
-- Description: Change as per new model



-- =============================================    
CREATE PROCEDURE [global].[Add_CaseAssessment] 
      @CaseID  int,
@AssessmentServiceID  int,
@HasPatientConsentForm  bit,
@IncidentAndDiagnosisDescription  VARCHAR(MAX),
@NeuralSymptomDescription  VARCHAR(MAX),
@PreExistingConditionDescription  VARCHAR(MAX),
@IsPatientUndergoingTreatment  bit,
@IsPatientTakingMedication  bit,
@PatientRequiresFurtherInvestigation  bit,
@FactorsAffectingTreatmentDescription  VARCHAR(MAX),
@PatientOccupation  varchar(150),
@PatientRoleID  int,
@WasPatientWorkingAtTheTimeOfTheAccident  bit,
@IsPatientSufferingFinancialLoss  bit,
@AnticipatedDateOfDischarge  datetime,
@HasPatientHomeExerciseProgramme  bit,
@HasPatientPastSymptoms  bit,
@AssessmentAuthorisationID  int,
@AuthorisationDetail  VARCHAR(MAX),
@IsAccepted  bit,
@IsPatientDischarge  bit,
@DeniedMessage  VARCHAR(MAX),
@HasYellowFlags  bit,
@HasRedFlags  bit,
@UserID  int,
@IsSaved int,
@RelevantTestUndertaken varchar(MAX)

 AS 
 begin
 
 INSERT INTO CaseAssessments(
 [CaseID],
 [AssessmentServiceID],
 [HasPatientConsentForm],
 [IncidentAndDiagnosisDescription],
 [NeuralSymptomDescription],
 [PreExistingConditionDescription],
 [IsPatientUndergoingTreatment],
 [IsPatientTakingMedication],
 [PatientRequiresFurtherInvestigation],
 [FactorsAffectingTreatmentDescription],
 [PatientOccupation],[PatientRoleID],
 [WasPatientWorkingAtTheTimeOfTheAccident],
 [IsPatientSufferingFinancialLoss],
 [AnticipatedDateOfDischarge],
 [HasPatientHomeExerciseProgramme],
 [HasPatientPastSymptoms],
 [AssessmentAuthorisationID],
 [AuthorisationDetail],
 [IsAccepted],
 [IsPatientDischarge],
 [DeniedMessage],
 [HasYellowFlags],
 [HasRedFlags],
 [UserID],
 [IsSaved],
 [RelevantTestUndertaken])
  
 VALUES(@CaseID,@AssessmentServiceID,@HasPatientConsentForm,@IncidentAndDiagnosisDescription,@NeuralSymptomDescription,@PreExistingConditionDescription,
 @IsPatientUndergoingTreatment,@IsPatientTakingMedication,@PatientRequiresFurtherInvestigation,@FactorsAffectingTreatmentDescription,
 @PatientOccupation,@PatientRoleID,@WasPatientWorkingAtTheTimeOfTheAccident,@IsPatientSufferingFinancialLoss,@AnticipatedDateOfDischarge,
 @HasPatientHomeExerciseProgramme,@HasPatientPastSymptoms,@AssessmentAuthorisationID,@AuthorisationDetail,@IsAccepted,@IsPatientDischarge,
 @DeniedMessage,@HasYellowFlags,@HasRedFlags,@UserID,
@IsSaved,@RelevantTestUndertaken)

select @CaseID

end

GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentCustom]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [global].[Add_CaseAssessmentCustom]
	-- Add the parameters for the stored procedure here
	@CaseID int,
	@Message nvarchar(MAX),
	@IsFurtherTreatment bit,
	@isAccepted bit
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into global.CaseAssessMentCustoms(CaseID,[Message],IsFurtherTreatment,isAccepted) values(@CaseID,@Message,@IsFurtherTreatment,@isAccepted)
	
	 
	
	
	
END



GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentDetail]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Vishal sen
-- Create date: 08/14/2013  
-- Description: Create SP
-- Version: 1.0  
-- =============================================  
-- Author:  HSingh
-- Create date: 01/20/2015
-- Description: add new fields named IsFurtherInvestigationOrOnwardReferralRequired, 
--	            FurtherInvestigationOrOnwardReferral, EvidenceOfTreatmentRecommendations
-- Version: 1.1
-- =============================================  

CREATE PROCEDURE [global].[Add_CaseAssessmentDetail]
(
@AssessmentServiceID  int,
@CaseID  int,
@HasThePatientHadTimeOff  bit,
@AbsentDetail  varchar(250),
@HasThePatientReturnedToWork  bit,
@PatientImpactOnWorkID  int,
@PatientWorkstatusID  int,
@PatientRecommendedTreatmentSessions  int,
@PatientRecommendedTreatmentSessionsDetail  VARCHAR(MAX),
@PatientTreatmentPeriod  int,
@IsFurtherTreatmentRecommended  bit,
@PatientLevelOfRecoveryID  int,
@SessionsPatientAttended  int,
@DatesOfSessionAttended  VARCHAR(MAX),
@SessionsPatientFailedToAttend  int,
@FollowingTreatmentPatientLevelOfRecoveryID  int,
@AdditionalInformation  VARCHAR(MAX),
@HasCompliedHomeExerciseProgramme  bit,
@AbsentPeriod int,
@AbsentPeriodDurationID int,
@PatientTreatmentPeriodDetail varchar(500),
@PatientTreatmentPeriodDurationID int,
@PractitionerID INT,
@EvidenceOfClinicalReasoning varchar(max),
@IsFurtherInvestigationOrOnwardReferralRequired bit,
@FurtherInvestigationOrOnwardReferral varchar(max),
@EvidenceOfTreatmentRecommendations varchar(max),
@TreatmentPeriodTypeID int,
@PatientDateOfReturn datetime,
@PatientRecommendationReturn varchar(Max),
@IsPatientReturnToPreInjuryDuties bit,
@PatientPreInjuryDutiesDate datetime,
@MainFactors varchar(MAX))
as
BEGIN
 
	 INSERT INTO global.CaseAssessmentDetail
	 ([AssessmentServiceID],
	 [CaseID],
	 [HasThePatientHadTimeOff],
	 [AbsentDetail],
	 [HasThePatientReturnedToWork],
	 [PatientImpactOnWorkID],
	 [PatientWorkstatusID],
	 [PatientRecommendedTreatmentSessions],
	 [PatientRecommendedTreatmentSessionsDetail],
	 [PatientTreatmentPeriod]
	 ,[IsFurtherTreatmentRecommended],
	 [PatientLevelOfRecoveryID],
	 [SessionsPatientAttended],
	 [DatesOfSessionAttended],
	 [SessionsPatientFailedToAttend],
	 [FollowingTreatmentPatientLevelOfRecoveryID],
	 [AdditionalInformation],
	 [HasCompliedHomeExerciseProgramme],[AbsentPeriod],[AbsentPeriodDurationID],[PatientTreatmentPeriodDetail],
	 [PatientTreatmentPeriodDurationID],[PractitionerID],[EvidenceOfClinicalReasoning],IsFurtherInvestigationOrOnwardReferralRequired, 
	  FurtherInvestigationOrOnwardReferral, EvidenceOfTreatmentRecommendations,
	  TreatmentPeriodTypeID, PatientDateOfReturn, PatientRecommendationReturn, IsPatientReturnToPreInjuryDuties, PatientPreInjuryDutiesDate, MainFactors)
	 VALUES(
	 @AssessmentServiceID,
	 @CaseID,
	 @HasThePatientHadTimeOff,
	 @AbsentDetail,
	 @HasThePatientReturnedToWork,
	 @PatientImpactOnWorkID,
	 @PatientWorkstatusID,
	 @PatientRecommendedTreatmentSessions,
	 @PatientRecommendedTreatmentSessionsDetail,
	 @PatientTreatmentPeriod,
	 @IsFurtherTreatmentRecommended,
	 @PatientLevelOfRecoveryID,
	 @SessionsPatientAttended,
	 @DatesOfSessionAttended,
	 @SessionsPatientFailedToAttend,
	 @FollowingTreatmentPatientLevelOfRecoveryID,
	 @AdditionalInformation,
	 @HasCompliedHomeExerciseProgramme,
	 @AbsentPeriod ,
	 @AbsentPeriodDurationID ,
	 @PatientTreatmentPeriodDetail,
	 @PatientTreatmentPeriodDurationID ,
	 @PractitionerID,
	 @EvidenceOfClinicalReasoning,
	 @IsFurtherInvestigationOrOnwardReferralRequired, 
	 @FurtherInvestigationOrOnwardReferral, @EvidenceOfTreatmentRecommendations,
	 @TreatmentPeriodTypeID, @PatientDateOfReturn, @PatientRecommendationReturn, @IsPatientReturnToPreInjuryDuties, @PatientPreInjuryDutiesDate, @MainFactors
	 )


select SCOPE_IDENTITY()

END

GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentDetailHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  Vishal sen
-- Create date: 08/14/2013  
-- Description: Create SP
-- Version: 1.0  
-- ========================================================================================
-- Author:  HSingh
-- Create date: 01/22/2015
-- Description: add new fields named IsFurtherInvestigationOrOnwardReferralRequired, 
--	            FurtherInvestigationOrOnwardReferral, EvidenceOfTreatmentRecommendations
-- Version: 1.1
-- =========================================================================================  


CREATE PROCEDURE [global].[Add_CaseAssessmentDetailHistory]
(
@AssessmentServiceID  int,
@CaseID  int,
@HasThePatientHadTimeOff  bit,
@AbsentDetail  VARCHAR(500),
@HasThePatientReturnedToWork  bit,
@PatientImpactOnWorkID  int,
@PatientWorkstatusID  int,
@PatientRecommendedTreatmentSessions  int,
@PatientRecommendedTreatmentSessionsDetail  VARCHAR(MAX),
@PatientTreatmentPeriod  int,
@IsFurtherTreatmentRecommended  bit,
@PatientLevelOfRecoveryID  int,
@SessionsPatientAttended  int,
@DatesOfSessionAttended  VARCHAR(MAX),
@SessionsPatientFailedToAttend  int,
@FollowingTreatmentPatientLevelOfRecoveryID  int,
@AdditionalInformation  VARCHAR(MAX),
@HasCompliedHomeExerciseProgramme  bit,
@CaseAssessmentDetailID  int,
@AbsentPeriod int,
@AbsentPeriodDurationID int,
@PatientTreatmentPeriodDetail varchar(500),
@PatientTreatmentPeriodDurationID int,
@PractitionerID INT,
@IsFurtherInvestigationOrOnwardReferralRequired bit,
@FurtherInvestigationOrOnwardReferral varchar(max),
@EvidenceOfTreatmentRecommendations varchar(max),
@TreatmentPeriodTypeID int,
@PatientDateOfReturn datetime,
@PatientRecommendationReturn varchar(Max),
@IsPatientReturnToPreInjuryDuties bit,
@PatientPreInjuryDutiesDate datetime,
@MainFactors varchar(MAX)
)
 AS 
 BEGIN
 
	 INSERT INTO global.CaseAssessmentDetailHistory
	 ( [AssessmentServiceID],
	 [CaseID],
	 [HasThePatientHadTimeOff],
	 [AbsentDetail],
	 [HasThePatientReturnedToWork],
	 [PatientImpactOnWorkID],
	 [PatientWorkstatusID],
	 [PatientRecommendedTreatmentSessions],
	 [PatientRecommendedTreatmentSessionsDetail],
	 [PatientTreatmentPeriod],
	 [IsFurtherTreatmentRecommended],
	 [PatientLevelOfRecoveryID],
	 [SessionsPatientAttended],
	 [DatesOfSessionAttended],
	 [SessionsPatientFailedToAttend],
	 [FollowingTreatmentPatientLevelOfRecoveryID],
	 [AdditionalInformation],
	 [HasCompliedHomeExerciseProgramme],
	 [CaseAssessmentDetailID],
	 [AbsentPeriod],[AbsentPeriodDurationID],[PatientTreatmentPeriodDetail],[PatientTreatmentPeriodDurationID]
	 ,[PractitionerID],IsFurtherInvestigationOrOnwardReferralRequired, FurtherInvestigationOrOnwardReferral, EvidenceOfTreatmentRecommendations
	 ,TreatmentPeriodTypeID
	 ,PatientDateOfReturn
	 ,PatientRecommendationReturn
	 ,IsPatientReturnToPreInjuryDuties
	 ,PatientPreInjuryDutiesDate
	 ,MainFactors
	 ) 
	 VALUES(
	 @AssessmentServiceID,
	 @CaseID,
	 @HasThePatientHadTimeOff,
	 @AbsentDetail,
	 @HasThePatientReturnedToWork,
	 @PatientImpactOnWorkID,
	 @PatientWorkstatusID,
	 @PatientRecommendedTreatmentSessions,
	 @PatientRecommendedTreatmentSessionsDetail,
	 @PatientTreatmentPeriod,
	 @IsFurtherTreatmentRecommended,
	 @PatientLevelOfRecoveryID,
	 @SessionsPatientAttended,
	 @DatesOfSessionAttended,
	 @SessionsPatientFailedToAttend,
	 @FollowingTreatmentPatientLevelOfRecoveryID,
	 @AdditionalInformation,
	 @HasCompliedHomeExerciseProgramme,
	 @CaseAssessmentDetailID,
	 @AbsentPeriod ,
	 @AbsentPeriodDurationID ,
	 @PatientTreatmentPeriodDetail,@PatientTreatmentPeriodDurationID,@PractitionerID,
	 @IsFurtherInvestigationOrOnwardReferralRequired, 
	@FurtherInvestigationOrOnwardReferral, @EvidenceOfTreatmentRecommendations,@TreatmentPeriodTypeID,
	@PatientDateOfReturn,
	@PatientRecommendationReturn,
	@IsPatientReturnToPreInjuryDuties,
	@PatientPreInjuryDutiesDate,
	@MainFactors)

SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Latest Version: 1.0    
    
-- Author:  Manjit Singh    
-- Create date: April 30, 2013    
-- Description: to add CaseAssessments History    
--  
-- Updated By:  Robin Singh    
-- Create date: May 23, 2013    
-- Description: added and update coloumn for model CaseAssessments History  
------------------------------------------------------------------------   
-- Updated By:  Satya    
-- Create date: May 28, 2013    
-- Description: update coloumn for model CaseAssessments History   
-- =============================================    

-- Updated By:  Vishal sen    
-- Create date: 08/14/2013    
-- Description: update coloumn for model CaseAssessments History   
-- =============================================  


CREATE PROCEDURE [global].[Add_CaseAssessmentHistory]     
        (
@CaseID  int,
@AssessmentServiceID  int,
@HasPatientConsentForm  bit,
@IncidentAndDiagnosisDescription  VARCHAR(MAX),
@NeuralSymptomDescription  VARCHAR(MAX),
@PreExistingConditionDescription  VARCHAR(MAX),
@IsPatientUndergoingTreatment  bit,
@IsPatientTakingMedication  bit,
@PatientRequiresFurtherInvestigation  bit,
@FactorsAffectingTreatmentDescription  VARCHAR(MAX),
@PatientOccupation  varchar(150),
@WasPatientWorkingAtTheTimeOfTheAccident  bit,
@IsPatientSufferingFinancialLoss  bit,
@AnticipatedDateOfDischarge  datetime,
@HasPatientHomeExerciseProgramme  bit,
@HasPatientPastSymptoms  bit,
@AssessmentAuthorisationID  int,
@AuthorisationDetail  VARCHAR(MAX),
@IsAccepted  bit,
@IsPatientDischarge  bit,
@DeniedMessage  VARCHAR(MAX),
@UserID  int,
@HasYellowFlags  bit,
@HasRedFlags  bit,
@PatientRoleID  int,
@RelevantTestUndertaken varchar(MAX)

           )    
AS    
BEGIN    
  
INSERT INTO  [global].[CaseAssessmentHistory]  
           ([CaseID],
 [AssessmentServiceID],
 [HasPatientConsentForm],
 [IncidentAndDiagnosisDescription],
 [NeuralSymptomDescription],
 [PreExistingConditionDescription],
 [IsPatientUndergoingTreatment],
 [IsPatientTakingMedication],
 [PatientRequiresFurtherInvestigation],
 [FactorsAffectingTreatmentDescription],
 [PatientOccupation],
 [WasPatientWorkingAtTheTimeOfTheAccident],
 [IsPatientSufferingFinancialLoss],
 [AnticipatedDateOfDischarge],
 [HasPatientHomeExerciseProgramme],
 [HasPatientPastSymptoms],
 [AssessmentAuthorisationID],
 [AuthorisationDetail],
 [IsAccepted],
 [IsPatientDischarge],
 [DeniedMessage],
 [UserID],
 [HasYellowFlags],
 [HasRedFlags],
 [PatientRoleID],
 [RelevantTestUndertaken]
           )  
   VALUES(@CaseID,@AssessmentServiceID,@HasPatientConsentForm,@IncidentAndDiagnosisDescription,
   @NeuralSymptomDescription,@PreExistingConditionDescription,@IsPatientUndergoingTreatment,
   @IsPatientTakingMedication,@PatientRequiresFurtherInvestigation,@FactorsAffectingTreatmentDescription,
   @PatientOccupation,@WasPatientWorkingAtTheTimeOfTheAccident,@IsPatientSufferingFinancialLoss,
   @AnticipatedDateOfDischarge,@HasPatientHomeExerciseProgramme,
   @HasPatientPastSymptoms,@AssessmentAuthorisationID,
   @AuthorisationDetail,@IsAccepted,@IsPatientDischarge,
   @DeniedMessage,@UserID,@HasYellowFlags,@HasRedFlags,@PatientRoleID,@RelevantTestUndertaken)
               
           select SCOPE_IDENTITY()    
END 

GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentPatientImpact]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================    
-- Author:  Anuj batra  
-- Create date: May 23, 2013    
-- Description: to add CaseAssessmentPatientImpact  
--  
-- =============================================   

-- Author:  Vishal
-- Create date: 08/14/2013    
-- Description: Update SP  
--  
-- =============================================   
CREATE PROCEDURE [global].[Add_CaseAssessmentPatientImpact]   
        (  
 @PatientImpactID  int,
@PatientImpactValueID  int,
@Comment  VARCHAR(MAX),
@CaseAssessmentDetailID  int
        )  
AS    
BEGIN    
  
INSERT INTO  [global].[CaseAssessmentPatientImpacts]  
           ([PatientImpactID],[PatientImpactValueID],[Comment],[CaseAssessmentDetailID])
            VALUES(@PatientImpactID,@PatientImpactValueID,@Comment,@CaseAssessmentDetailID) 
            
                 select SCOPE_IDENTITY()     
               
END 








GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentPatientImpactHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		Vishal 
-- Create date: 08/16/2013
-- Description:	Add CaseAssessmentPatientImpactHistory
-- Version: 1.0



CREATE PROCEDURE [global].[Add_CaseAssessmentPatientImpactHistory]  
(  
@PatientImpactID INT,  
@PatientImpactValueID INT,  
@CaseAssessmentDetailHistoryID INT,  
@Comment VARCHAR(MAX)  
)  
AS  
  
INSERT INTO [global].[CaseAssessmentPatientImpactHistory]  
       (PatientImpactID,PatientImpactValueID,CaseAssessmentDetailHistoryID,Comment)  
VALUES  
       (@PatientImpactID,@PatientImpactValueID,@CaseAssessmentDetailHistoryID,@Comment)  

GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentPatientInjury]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
-- Author:  Vishal Sen      
-- Create date: 08/14/2013      
-- Description: CREATE SP Add_CaseAssessmentPatientInjury  
-- Version: 1.0      
-- =============================================   
    
CREATE PROCEDURE [global].[Add_CaseAssessmentPatientInjury]    
(    
@CaseAssessmentDetailID int,    
@AffectedArea varchar(500) = '',    
@Score varchar(10),    
@Restriction varchar(500) = ' ',    
@SymptomDescriptionID int,
@StrengthTestingID int,
@AffectedAreaID int,
@RestrictionRangeID int,
@OtherSymptomDesciption varchar(MAX)
)    
as   
BEGIN   
insert into global.CaseAssessmentPatientInjuries  
(CaseAssessmentDetailID,AffectedArea,Score,Restriction,SymptomDescriptionID,StrengthTestingID,AffectedAreaID,RestrictionRangeID,OtherSymptomDesciption)  
 values(@CaseAssessmentDetailID,    
@AffectedArea,    
@Score,    
@Restriction
,@SymptomDescriptionID
,@StrengthTestingID
,@AffectedAreaID
,@RestrictionRangeID
,@OtherSymptomDesciption)    
    
    
  select SCOPE_IDENTITY()  
  END  

GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentPatientInjuryHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
-- =============================================    
-- Author:  Vishal Sen    
-- Create date: 05/24/2013    
-- Description: alter PROCEDURE for CaseAssessmentPatientInjuryHistory Task No #807    
-- Version: 1.0    
-- =============================================    
-- UPDATOR:  Vishal Sen    
-- Create date: 08/14/2013    
-- Description: Update SP as per new model  
-- Version: 1.1    
-- =============================================    
    
CREATE PROCEDURE [global].[Add_CaseAssessmentPatientInjuryHistory]    
 -- Add the parameters for the stored procedure here     
    
@CaseAssessmentDetailHistoryID INT ,    
@AffectedArea varchar(500) = ' ',    
@Score varchar(10),    
@Restriction varchar(200) = ' ',  
@SymptomDescriptionID int,
@StrengthTestingID int,
@AffectedAreaID int,
@RestrictionRangeID int,
@OtherSymptomDesciption varchar(MAX)
    
AS    
BEGIN     
    INSERT INTO global.CaseAssessmentPatientInjuryHistory    
 (     
    [CaseAssessmentDetailHistoryID]    
      ,[AffectedArea]    
      ,[Score]    
      ,[Restriction]
	  ,[SymptomDescriptionID]
	   ,[StrengthTestingID]
	   ,[AffectedAreaID]
	   ,[RestrictionRangeID]
	   ,[OtherSymptomDesciption])    
   VALUES    
   (       
  @CaseAssessmentDetailHistoryID,    
  @AffectedArea,    
  @Score,    
  @Restriction,
  @SymptomDescriptionID,
  @StrengthTestingID,
  @AffectedAreaID,
  @RestrictionRangeID,
  @OtherSymptomDesciption  
   )    
  SELECT SCOPE_IDENTITY()    
END    

GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentProposedTreatmentMethod]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--==============================================
-- Author By: Vishal sen     
-- Create date: 23/10/2013      
-- Description: Add_CaseAssessmentProposedTreatmentMethod
-- Version: 1.0
-- ============================================= 

CREATE PROCEDURE [global].[Add_CaseAssessmentProposedTreatmentMethod]
(

@CaseID  INT,
@ProposedTreatmentMethodID INT

)
 AS 
  BEGIN
     INSERT INTO [global].[CaseAssessmentProposedTreatmentMethods]
     (          
      [CaseID],
      [ProposedTreatmentMethodID]
      
     ) 

VALUES(
      
       @CaseID,
       @ProposedTreatmentMethodID
       
       )    

END 






GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentProposedTreatmentMethodHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--==============================================
-- Author By: Vishal sen     
-- Create date: 23/10/2013      
-- Description: Add CaseAssessmentProposedTreatmentMethodHistory.  
-- Version: 1.0
-- ============================================= 

CREATE PROCEDURE [global].[Add_CaseAssessmentProposedTreatmentMethodHistory]
(
@CaseAssessmentHistoryID  INT,
@CaseID  INT,
@ProposedTreatmentMethodID INT

)
 AS 
  BEGIN
     INSERT INTO [global].[CaseAssessmentProposedTreatmentMethodHistory](    
      [CaseAssessmentHistoryID],
      [CaseID],
      [ProposedTreatmentMethodID]
      
     ) 

VALUES(
        
       @CaseAssessmentHistoryID,
       @CaseID,
       @ProposedTreatmentMethodID
       
       )    

SELECt SCOPE_IDENTITY();

END 






GO
/****** Object:  StoredProcedure [global].[Add_CaseAssessmentRating]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Robin
-- Create date: 04/30/2013
-- Description:	Create stored procedure to Add CaseAssessmentRating
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [global].[Add_CaseAssessmentRating] 
	-- Add the parameters for the stored procedure here
	   @CaseID INT
	  ,@AssessmentServiceID INT
      ,@Rating decimal(5,2)
      ,@RatingDate DATETIME
AS
BEGIN	

INSERT INTO [global].[CaseAssessmentRatings]
           ([CaseID]
           ,[AssessmentServiceID]
           ,[Rating]
           ,[RatingDate])
     VALUES
           (@CaseID
           ,@AssessmentServiceID
           ,@Rating
           ,@RatingDate)
           
            SELECT SCOPE_IDENTITY()
           
END








GO
/****** Object:  StoredProcedure [global].[Add_CaseBespokeServicePricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  Anuj Batra  
-- Create date: 30-May-2013
-- Description: Created Procedure for add [CaseBespokeServicePricing]
-- Version : 1.0   
-- =============================================  


CREATE PROCEDURE [global].[Add_CaseBespokeServicePricing]  
 -- Add the parameters for the stored procedure here  
   (@CaseID INT, 
    @TreatmentCategoryBespokeServiceID INT,
    @ReferrerPrice Money,
    @SupplierPrice Money,
     @DateOfService DateTime,
      @PatientDidNotAttend Bit,
      @WasAbandoned Bit
    ) 
     
AS  
BEGIN   
INSERT INTO  [global].[CaseBespokeServicePricing]
           ([CaseID]
           ,[TreatmentCategoryBespokeServiceID]
           ,[ReferrerPrice]
           ,[SupplierPrice]
           ,[DateOfService]
           ,[PatientDidNotAttend]
           ,[WasAbandoned])
     VALUES
           (@CaseID ,
           @TreatmentCategoryBespokeServiceID ,
           @ReferrerPrice ,
           @SupplierPrice ,
           @DateOfService,
           @PatientDidNotAttend ,
           @WasAbandoned
           )
     
END  


GO
/****** Object:  StoredProcedure [global].[Add_CaseCommunicationHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Robin  
-- Create date: 10/10/2013  
-- Description: Create stored procedure to Add CaseCommunicationHistory  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Add_CaseCommunicationHistory]   
 -- Add the parameters for the stored procedure here  
      (    
       @CaseID INT  
           ,@SentTo VARCHAR(300)  
           ,@SentCC VARCHAR(300)  
           ,@Subject VARCHAR(MAX)  
           ,@Message NVARCHAR(MAX)  
           ,@UserID INT 
           ,@UploadPath VARCHAR(100)
             
           )  
             
AS  
INSERT INTO [global].[CaseCommunicationHistory]  
           (  
           [CaseID]  
           ,[SentTo]  
           ,[SentCC]  
           ,[Subject]  
           ,[Message]  
           ,[UserID] 
           ,[UploadPath] 
           )  
     VALUES  
           (  
           @CaseID  
           ,@SentTo  
           ,@SentCC  
           ,@Subject  
           ,@Message  
           ,@UserID  
           ,@UploadPath
           )  
              
           SELECT SCOPE_IDENTITY()  
  
  
  

GO
/****** Object:  StoredProcedure [global].[Add_CaseContact]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Add_CaseContact] 
	@CaseID int,
	@UserID int
AS
	INSERT INTO [global].[CaseContacts]
           ([CaseID]
           ,[UserID])
     VALUES
           (@CaseID
           ,@UserID)
	SELECT SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [global].[Add_CaseDocument]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Vishal Sen  
-- Create date: 06-15-2013  
-- Description: Add case document  
-- =============================================  
CREATE PROCEDURE [global].[Add_CaseDocument]  
        @CaseID INT,  
        @DocumentTypeID INT,  
		@UploadDate DATETIME,  
        @DocumentName VARCHAR(MAX),  
        @UploadPath VARCHAR(MAX),
        @UserID INT
		
AS  
BEGIN
     DECLARE @CaseDocumentID INT 
  INSERT INTO  [global].[CaseDocuments]  
           ([CaseID]  
           ,[DocumentTypeID]  
           ,[UploadDate]  
           ,[DocumentName]  
           ,[UploadPath]
           ,[UserID]
		  
           )  
     VALUES  
           (@CaseID,  
			@DocumentTypeID,  
			@UploadDate,  
			@DocumentName,  
			@UploadPath,
			@UserID
			
        )  
             
             
    SET @CaseDocumentID = SCOPE_IDENTITY()  
	SELECT @CaseDocumentID
END


GO
/****** Object:  StoredProcedure [global].[Add_CaseHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Add_CaseHistory]
	(
		   @CaseID INT,
		   @EventDate DATETIME,
		   @UserID INT,
		   @EventDescription varchar(max),
		   @EventType INT
	)	
AS
	INSERT INTO [global].[CaseHistory]
           ([CaseID]
           ,[EventDate]
           ,[UserID]
           ,[EventDescription]
           ,[EventTypeID])
     VALUES
           (@CaseID,
		   @EventDate,
		   @UserID,
		   @EventDescription,
		   @EventType)

	select SCOPE_IDENTITY()

	


GO
/****** Object:  StoredProcedure [global].[Add_CaseNote]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--==============================================
-- Modified By: Vishal sen     
-- Create date: 17-Sept-2013      
-- Description: Add Case Note.  
-- Version: 1.0
-- ============================================= 

CREATE PROCEDURE [global].[Add_CaseNote]
(
@Note  VARCHAR(MAX),
@CaseID  INT,
@UserID INT,
@WorkflowID INT
)
 AS 
  BEGIN
     INSERT INTO [global].[CaseNotes](
      [Note],
      [CaseID],
      [UserID],
	  [WorkflowID]
     ) 

VALUES(
         @Note,
         @CaseID,
         @UserID,
         @WorkflowID
	  )

  SELECT SCOPE_IDENTITY()      

END 






GO
/****** Object:  StoredProcedure [global].[Add_CaseReferrerAssignedUser]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 02-05-2019
-- Description:	To get case referrer assigned user by caseID
-- =============================================
CREATE PROCEDURE [global].[Add_CaseReferrerAssignedUser](@UserID int, @CaseID int)
AS
BEGIN
	SET NOCOUNT ON;	

	if exists(select * from global.CaseReferrerAssignedUsers where UserID = @UserID and CaseID = @CaseID and status = 0)
	begin 	
		update global.CaseReferrerAssignedUsers set status=1 OUTPUT Convert(decimal, INSERTED.CaseReferrerAssignedUserID) where CaseID=@CaseID and UserID=@UserID
	end 
	else
	begin	
			if not exists(select * from global.CaseReferrerAssignedUsers where UserID = @UserID and CaseID = @CaseID )
			begin
				Insert into global.CaseReferrerAssignedUsers (UserID, CaseID,status) values(@UserID, @CaseID,1)
				select SCOPE_IDENTITY() as CaseReferrerAssignedUserID
			end
	end
END

GO
/****** Object:  StoredProcedure [global].[Add_CaseTreatmentPricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  Vishal Sen    
-- Create date: 05-30-2013    
-- Description: Add CaseTreatmentPricing    
-- =============================================    
-- =============================================  
-- Author:  rkumar
-- Create date: 08/13/2018
-- Description: User Story #3357: Supplier Portal - RA / FA - Treatment Matrix Display
-- Version: 1.1
-- =============================================  
CREATE PROCEDURE [global].[Add_CaseTreatmentPricing]    
    
   
      @CaseID INT  
      ,@ReferrerPricingID INT  
      ,@ReferrerPrice MONEY  
      ,@DateOfService DATETIME  
      ,@PatientDidNotAttend BIT  
      ,@WasAbandoned BIT  
      ,@SupplierPrice  MONEY  
	  ,@Quantity INT
      ,@SupplierPriceID INT  
      ,@AuthorizationStatus BIT= NULL 
	  ,@PatientDidNotAttendDate DATETIME
     
    
AS    
      
   INSERT INTO [global].[CaseTreatmentPricing]    
           (    
       [CaseID]  
      ,[ReferrerPricingID]  
      ,[ReferrerPrice]  
      ,[DateOfService]  
      ,[PatientDidNotAttend]  
      ,[WasAbandoned]  
      ,[SupplierPrice]   
	  ,[Quantity]
      ,[SupplierPriceID] 
      ,[AuthorizationStatus]
	  ,[PatientDidNotAttendDate]
	  ,[PreviousSupplierPriceID] 
	  ,[PreviousReferrerPricingID]
      )    
     VALUES    
           (    
  @CaseID  
      ,@ReferrerPricingID  
      ,@ReferrerPrice  
      ,@DateOfService  
      ,@PatientDidNotAttend  
      ,@WasAbandoned  
       ,@SupplierPrice   
	   ,@Quantity 
      ,@SupplierPriceID 
      ,@AuthorizationStatus 
	  ,@PatientDidNotAttendDate
	  ,@SupplierPriceID 
	  ,@ReferrerPricingID  
      )    
               
    select SCOPE_IDENTITY() 

GO
/****** Object:  StoredProcedure [global].[Add_CaseVAT]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--==============================================
-- Author By: Vishal sen     
-- Create date: 23/10/2013      
-- Description: Add Case VAT.  
-- Version: 1.0
-- ============================================= 

CREATE PROCEDURE [global].[Add_CaseVAT]
(
@CaseID  INT,
@VAT DECIMAL(5,2)

)
 AS 
  BEGIN
     INSERT INTO [global].[CaseVAT](    
      [CaseID],
      [VAT]
     ) 

VALUES(        
         @CaseID,
         @VAT
       )    

END 






GO
/****** Object:  StoredProcedure [global].[Add_DrugTest]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tarun Gosain
-- Create date: 03-21-2019
-- Description:	Add into Drug Test table
-- =============================================
CREATE PROCEDURE [global].[Add_DrugTest](@IsDrugAndAlcohalTest bit, @NetworkRailStandardApplicableID int, @ReasonForReferralID int, @IsSentinalUpdating bit, @SentinalNumber varchar(100), @AdditionalTestID int, @AdditionalTestOther varchar(max))
AS
BEGIN	
	SET NOCOUNT ON;
	Insert into global.DrugTests Values(@IsDrugAndAlcohalTest, @NetworkRailStandardApplicableID, @ReasonForReferralID, @IsSentinalUpdating, @SentinalNumber, @AdditionalTestID, @AdditionalTestOther)
END

GO
/****** Object:  StoredProcedure [global].[Add_Employment]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Author:		Mahinder Singh 
-- Create date: 11 Aug 2018
-- Description:	Add Employments fields
-- Version: 1.0
           
CREATE PROCEDURE  [global].[Add_Employment] 
	-- Add the parameters for the stored procedure here
(	
		 @EmploymentTypeId INT
		,@CompanyName varchar(25)
		,@JobRole varchar(40)
		,@Address varchar(40)
		,@ContactName varchar(25)
		,@PrimaryPhone varchar(25)
		,@Email varchar(50)

   )
AS
BEGIN	

    INSERT 
	INTO [global].[Employments]  
			(
			     [EmploymentTypeId]
				,[CompanyName]
				,[JobRole]
				,[Address]
				,[ContactName]
				,[PrimaryPhone]
				,[Email]

           )
	  VALUES
			(
			     @EmploymentTypeId
				,@CompanyName
				,@JobRole
				,@Address
				,@ContactName
				,@PrimaryPhone
				,@Email

            )
	  
 SELECT SCOPE_IDENTITY()
 
END


GO
/****** Object:  StoredProcedure [global].[Add_InjuredPartyRepresentatives]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP Name: Add_InjuredPartyRepresentatives
--Latest Version: 1.0


-- Author:		Mahinder Singh 
-- Create date: 04/04/2018
-- Description:	Add InjuredPartyRepresentatives information
-- Version: 1.0
           
CREATE PROCEDURE  [global].[Add_InjuredPartyRepresentatives] 
	-- Add the parameters for the stored procedure here
(
@FirstName VARCHAR(50)
,@LastName VARCHAR(50)
,@ReferralID INT
,@Tel1 VARCHAR(16)
,@Tel2 VARCHAR(16)
,@Address VARCHAR(300)
,@PostCode VARCHAR(12)
,@Email VARCHAR(50)
,@Relationship VARCHAR(50)
 )
AS
BEGIN	

    INSERT 
	INTO [global].InjuredPartyRepresentatives  
			(
			 FirstName
			,LastName
			,ReferralID
			,Tel1
			,Tel2
			,[Address]
			,PostCode
			,Email
			,Relationship)
	  VALUES
	      (
		   @FirstName
          ,@LastName
          ,@ReferralID
          ,@Tel1
          ,@Tel2
          ,@Address
          ,@PostCode
          ,@Email
          ,@Relationship)
		  
		   
 SELECT SCOPE_IDENTITY()
 
END


GO
/****** Object:  StoredProcedure [global].[Add_Invoice]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Add_Invoice]  
 -- Add the parameters for the stored procedure here  
   (		@InvoiceNumber varchar(200)
           ,@Amount money
           ,@CaseId int
           ,@UserId int
           ,@InvoiceDate date
           ,@IsComplete bit
           )  
  
AS  
BEGIN   
  
INSERT INTO [global].[Invoices]
           ([InvoiceNumber]
           ,[Amount]
           ,[CaseId]
           ,[UserId]
           ,[InvoiceDate]
           ,[IsComplete])

     VALUES
           (@InvoiceNumber
           ,@Amount
           ,@CaseId
           ,@UserId
           ,@InvoiceDate
           ,@IsComplete)
     
   SELECT SCOPE_IDENTITY()  
END  



GO
/****** Object:  StoredProcedure [global].[Add_InvoiceCollectionAction]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Add_InvoiceCollectionAction]  
 -- Add the parameters for the stored procedure here  
   (		@InvoiceID int
           ,@Action varchar(max)
           ,@UserId int
           ,@FollowUpDate date
           ,@DateofAction date
           )  
AS  
BEGIN   
  
INSERT INTO  [global].[InvoiceCollectionAction]
           ([InvoiceID]
           ,[Action]
           ,[UserId]
           ,[FollowUpDate]
           ,[DateofAction])
       VALUES
           (@InvoiceID 
           ,@Action 
           ,@UserId 
           ,@FollowUpDate 
           ,@DateofAction )
     
   SELECT SCOPE_IDENTITY()  
END  



GO
/****** Object:  StoredProcedure [global].[Add_InvoicePayment]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Add_InvoicePayment]  
 -- Add the parameters for the stored procedure here  
   (		@InvoiceID int
           ,@Payment money
           ,@AdjustedPayment money
           ,@CheckNumber varchar(max)
           ,@BACS varchar(max)
           ,@UserId int
           ,@InvoicePaymentDate date
           )  
AS  
BEGIN   
  
INSERT INTO [global].[InvoicePayment]
           ([InvoiceID]
           ,[Payment]
           ,[AdjustedPayment]
           ,[CheckNumber]
           ,[BACS]
           ,[UserId]
           ,[InvoicePaymentDate])
     VALUES
           (@InvoiceID 
           ,@Payment 
           ,@AdjustedPayment 
           ,@CheckNumber 
           ,@BACS 
           ,@UserId 
           ,@InvoicePaymentDate )
     
   SELECT SCOPE_IDENTITY()  
END  



GO
/****** Object:  StoredProcedure [global].[Add_JobDemands]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jaskaran	
-- Create date: 09-04-2019
-- Description:	Add Data into JobDemands Table
-- =============================================
CREATE PROCEDURE [global].[Add_JobDemands] 
	
	(@IsJobDemand bit,
	@IsStanding	bit,	
	@IsWalking	bit,
	@IsWorkATHeightOrClimb	bit,
	@IsExtendedOrProlonged	bit,
	@IsVocationalDriving	bit,
	@IsDrivingLGVOrPCVs	bit,
	@IsDrivingForkliftTrucks	bit,
	@IsWorkWithChemials	bit,
	@IsWorkBiologicalOrChemical	bit,
	@IsWorkWithSkinIrritants	bit,
	@IsWorkWithDengerousMachinery bit,
	@IsNightWork bit,
	@IsShiftWork	bit,
	@IsWorkInConfinedSpaces	bit,
	@IsWorkWithDustOrFumes	bit,
	@IsLiftOrCarryHeavyItems	bit,
	@IsWorkWithComputerOrScreens	bit,
	@IsWorkTowardsTagetOrPressuredsituation	bit,
	@IsWorkWithAdultOrChildren	bit,
	@IsHealthCareWorker	bit,
	@IsOccasionalOverseasTravel	bit,
	@IsOutsideWork	bit,
	@IsNoisedHarzardArea bit,
	@IsHandlingFood	bit,
	@FreeText	varchar(200))
	AS
BEGIN
	
	SET NOCOUNT ON;
    
INSERT INTO global.JobDemands
                         (IsJobDemand, IsStanding, IsWalking, IsWorkATHeightOrClimb, IsExtendedOrProlonged, IsVocationalDriving, IsDrivingLGVOrPCVs, IsDrivingForkliftTrucks, IsWorkWithChemials, IsWorkBiologicalOrChemical, 
                         IsWorkWithSkinIrritants, IsWorkWithDengerousMachinery, IsNightWork, IsShiftWork, IsWorkInConfinedSpaces, IsWorkWithDustOrFumes, IsLiftOrCarryHeavyItems, IsWorkWithComputerOrScreens, 
                         IsWorkTowardsTagetOrPressuredsituation, IsWorkWithAdultOrChildren, IsHealthCareWorker, IsOccasionalOverseasTravel, IsOutsideWork, IsNoisedHarzardArea, IsHandlingFood, [FreeText])
values(
	@IsJobDemand,
	@IsStanding,
	@IsWalking,
	@IsWorkATHeightOrClimb,
	@IsExtendedOrProlonged,
	@IsVocationalDriving,
	@IsDrivingLGVOrPCVs,
	@IsDrivingForkliftTrucks,
	@IsWorkWithChemials,
	@IsWorkBiologicalOrChemical,
	@IsWorkWithSkinIrritants,
	@IsWorkWithDengerousMachinery,
	@IsNightWork,
	@IsShiftWork,
	@IsWorkInConfinedSpaces,
	@IsWorkWithDustOrFumes,
	@IsLiftOrCarryHeavyItems,
	@IsWorkWithComputerOrScreens,
	@IsWorkTowardsTagetOrPressuredsituation,
	@IsWorkWithAdultOrChildren,
	@IsHealthCareWorker,
	@IsOccasionalOverseasTravel,
	@IsOutsideWork,
	@IsNoisedHarzardArea,
	@IsHandlingFood,
	@FreeText	
	)
	 SELECT SCOPE_IDENTITY() 
END

GO
/****** Object:  StoredProcedure [global].[Add_Patient]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP Name: Add_Patient
--Latest Version: 1.0


-- Author:		Satya 
-- Create date: 12/01/2012
-- Description:	Add User information
-- Version: 1.0
-- Author:		Mahinder Singh 
-- Create date: 11 Aug 2018
-- Description:	Add PolicyID fields,EmploymentID fields
-- Version: 1.1
-- Author:		Param kaur
-- Create date: 11 Feb 2019
-- Description:	PrimaryConditionID field Added
-- Version: 1.2           
CREATE PROCEDURE  [global].[Add_Patient] 
	-- Add the parameters for the stored procedure here
(			@Title varchar(50)
           ,@FirstName varchar(80)
           ,@LastName varchar(80)
           ,@Address varchar(300)
           ,@City varchar(100)
           ,@Region varchar(50)
           ,@PostCode varchar(12)
           ,@InjuryDate date
           ,@BirthDate date
           ,@HomePhone varchar(16)
           ,@WorkPhone varchar(16)
           ,@MobilePhone varchar(16)
           ,@GenderID int
           ,@Email varchar(50)
           ,@HasLegalRep bit
           ,@SolicitorID int
		   ,@HasInjuredPartyRepresentative int
		   ,@InjuredID int
		   ,@PolicyID int
		   ,@EmploymentID int
		   ,@PrimaryConditionID int
		   ,@PolicyOpenDetailID int
           )
AS
BEGIN	

    INSERT 
	INTO [global].Patients  
			([Title]
           ,[FirstName]
           ,[LastName]
           ,[Address]
           ,[City]
           ,[Region]
           ,[PostCode]
           ,[InjuryDate]
           ,[BirthDate]
           ,[HomePhone]
           ,[WorkPhone]
           ,[MobilePhone]
           ,[GenderID]
           ,[Email]
           ,[HasLegalRep]
           ,[SolicitorID]
		   ,[HasInjuredPartyRepresentative]
		   ,[InjuredID]
		   ,[PolicyID]
		   ,[EmploymentID]
		   ,[PrimaryConditionID]
		   ,[PolicyOpenDetailID]
           )
	  VALUES
			(@Title
           ,@FirstName
           ,@LastName
           ,@Address
           ,@City
           ,@Region
           ,@PostCode
           ,@InjuryDate
           ,@BirthDate
           ,@HomePhone
           ,@WorkPhone
           ,@MobilePhone
           ,@GenderID
           ,@Email
           ,@HasLegalRep
           ,@SolicitorID
		   ,@HasInjuredPartyRepresentative 
		   ,@InjuredID 
		   ,@PolicyID
		   ,@EmploymentID
		   ,@PrimaryConditionID
		   ,@PolicyOpenDetailID
           )
	  
 SELECT SCOPE_IDENTITY()
 
END


GO
/****** Object:  StoredProcedure [global].[Add_PatientContactAttempt]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Pardeep Kumar>
-- Create date: <04-19-2013>
-- Description:	< Create the procedure to add PatientContactAttempt>
-- =============================================



CREATE PROCEDURE [global].[Add_PatientContactAttempt]
(
@PatientID int,
@CaseID int,
@ContactAttemptDate date
)
as
insert into global.CasePatientContactAttempts (PatientID,CaseID,ContactAttemptDate)values(@PatientID,@CaseID,@ContactAttemptDate)
select @@Identity as id

GO
/****** Object:  StoredProcedure [global].[Add_Policie]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Author:		Mahinder Singh 
-- Create date: 11 Aug 2018
-- Description:	Add PolicyID fields,EmploymentID fields
-- Version: 1.0
           
CREATE PROCEDURE  [global].[Add_Policie] 
	-- Add the parameters for the stored procedure here
(	
		@PolicyTypeId INT
		,@TypeCoverId INT
		,@PolicyCriteriaId INT
		,@RehabProportionateBenefit BIT
		,@FitForWorkId INT	
		,@ReInsuredId INT
		,@ReferenceNo VARCHAR(25)
		,@AdmittedId INT
		,@BenefitDate DATE
		,@MonthlyValue DECIMAL
		,@WeeklyValue DECIMAL
		,@EndBenefitDate DATE	
		,@NameOfReinsurerID INT
		,@PolicyWording VARCHAR(25)
   )
AS
BEGIN	

    INSERT 
	INTO [global].[Policies]  
			(
			 [PolicyTypeId]
			,[TypeCoverId]
			,[PolicyCriteriaId]
			,[RehabProportionateBenefit]
			,[FitForWorkId]
			,[ReInsuredId]
			,[ReferenceNo]
			,[AdmittedId]
			,[BenefitDate]
			,[MonthlyValue]
			,[WeeklyValue]
			,[EndBenefitDate]
			,[NameOfReinsurerID]
			,[PolicyWording]
           )
	  VALUES
			(
			@PolicyTypeId 
			,@TypeCoverId 
			,@PolicyCriteriaId 
			,@RehabProportionateBenefit 
			,@FitForWorkId 	
			,@ReInsuredId 
			,@ReferenceNo 
			,@AdmittedId 
			,@BenefitDate 
			,@MonthlyValue 
			,@WeeklyValue
			,@EndBenefitDate 	
			,@NameOfReinsurerID 
			,@PolicyWording 
            )
	  
 SELECT SCOPE_IDENTITY()
 
END


GO
/****** Object:  StoredProcedure [global].[Add_PolicyOpenDetail]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh	
-- Create date: 03-09-2019
-- Description:	Add Open Policy Detail
-- =============================================
CREATE PROCEDURE [global].[Add_PolicyOpenDetail] 
	
		(@PolicyType	varchar(25),
		@TypeCover	varchar(25),
		@PolicyCriteria	varchar(25),
		@RehabORProportionate	varchar(25),
		@FitforWork	varchar(25),
		@ReInsured	varchar(25),
		@ReferenceNo varchar(25),
		@Admitted	varchar(25),
		@OpenBenefitDate	datetime,
		@OpenMonthlyValue	money,
		@OpenEndBenefitDate	datetime,
		@NameofReinsurer	varchar(25),
		@OpenPolicyWording	varchar(MAX))
		
AS
BEGIN
	
	INSERT INTO [global].[PolicyOpenDetails]
	(
		PolicyType,
		TypeCover,
		PolicyCriteria,
		RehabORProportionate,
		FitforWork,
		ReInsured,
		ReferenceNo,
		Admitted,
		OpenBenefitDate,
		OpenMonthlyValue,
		OpenEndBenefitDate,
		NameofReinsurer,
		OpenPolicyWording
	)
	VALUES
	(
		@PolicyType,
		@TypeCover,
		@PolicyCriteria,
		@RehabORProportionate,
		@FitforWork,
		@ReInsured,
		@ReferenceNo,
		@Admitted,
		@OpenBenefitDate,
		@OpenMonthlyValue,
		@OpenEndBenefitDate,
		@NameofReinsurer,
		@OpenPolicyWording
	)
	 SELECT SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [global].[Add_Practitioner]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

    

    
    
     
-- =============================================      
-- Latest Version: 1.1  
-- Author:  Pardeep Kumar      
-- Create date: 31-Jan-2013      
-- Description: Add Practitioner      
-- Version: 1.0   
     
-- MOdified By:  Robin Singh      
-- Create date: 07-Feb-2013      
-- Description: Modify table Practitioner to Practitioners  
-- Version: 1.1      

-- Modified By: Anuj Batra     
-- Create date: 08-Mar-2013      
-- Description: Removed the fields from the SP as per the tables design changes.  
-- Version: 1.2
-- =============================================      
CREATE PROCEDURE [global].[Add_Practitioner]       
 -- Add the parameters for the stored procedure here      
   (@PractitionerFirstName varchar(50)    
   ,@PractitionerLastName varchar(50)   
                 
     )      
      
AS      
BEGIN       
      
INSERT INTO [Global].[Practitioners]      
           ([PractitionerFirstName]
           ,[PractitionerLastName]   
            )      
     VALUES      
     (  @PractitionerFirstName
		,@PractitionerLastName
     )      
         
   SELECT SCOPE_IDENTITY()      
END
 

GO
/****** Object:  StoredProcedure [global].[Add_PractitionerExpertise]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.1
-- =============================================  
-- Author:  Pardeep Kumar  
-- Create date: 31-Jan-2013
-- Description: Add PractitionerExpertise 
-- Version : 1.0   
-- =============================================  
-- Modified By:  Manjit Singh  
-- Create date: 08-March-2013
-- Description: Remove Field and parameter named TreatmentCategoryID 
-- Version : 1.1   
-- =============================================  


CREATE PROCEDURE [global].[Add_PractitionerExpertise]  
 -- Add the parameters for the stored procedure here  
   (@PractitionerID INT  
           ,@AreaofExpertiseID INT
          
           )  
  
AS  
BEGIN   
  
INSERT INTO [global].[PractitionerExpertise]  
           (PractitionerID  
           ,AreaofExpertiseID)  
     VALUES  
          (@PractitionerID  
           ,@AreaofExpertiseID)  
     
   SELECT SCOPE_IDENTITY()  
END  


GO
/****** Object:  StoredProcedure [global].[Add_PractitionerRegistration]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Satya  
-- Create date: 03/08/2013  
-- Description: Create stored procedure to Add PractitionerRegistration  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Add_PractitionerRegistration]   
 -- Add the parameters for the stored procedure here  
    @PractitionerID INT  
   ,@TreatmentCategoryID INT  
      ,@RegistrationTypeID INT  = NULL
      ,@RegistrationNumber NVARCHAR(50)  
      ,@Qualification NVARCHAR(100)  
      ,@QualificationDate DATE  
      ,@ExpiryDate DATE  
      ,@YearsQualified INT  
AS  
BEGIN   
  
INSERT INTO [global].[PractitionerRegistrations]  
           ([PractitionerID]  
           ,[TreatmentCategoryID]  
           ,[RegistrationTypeID]  
           ,[RegistrationNumber]  
           ,[Qualification]  
           ,[QualificationDate]  
           ,[ExpiryDate]  
           ,[YearsQualified])  
           VALUES  
           (@PractitionerID  
           ,@TreatmentCategoryID  
           ,@RegistrationTypeID  
           ,@RegistrationNumber  
           ,@Qualification  
           ,@QualificationDate  
           ,@ExpiryDate  
           ,@YearsQualified)  
             
            SELECT SCOPE_IDENTITY()  
             
END  
  
  
  
  
  
  

GO
/****** Object:  StoredProcedure [global].[Add_Solicitor]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vishal s
-- Create date: 12/15/2012
-- Description:	alter PROCEDURE for Add_Solicitors Task No #279
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [global].[Add_Solicitor]
	-- Add the parameters for the stored procedure here	
	@CompanyName varchar(50),
	@Address varchar(300),
	@Phone varchar(16),
	@Email varchar(50),
	@FirstName varchar(30),
	@LastName varchar(30),
	@PostCode varchar(12),
	@Fax varchar(16),
	@ReferenceNumber varchar(16),	
	@City varchar(100),
	@Region varchar(50),
	@IsReferralUnderJointInstruction Bit
	
	
AS
BEGIN	
    INSERT INTO [global].[Solicitors]
	( [CompanyName]
           ,[Address]
           ,[Phone]
           ,[Email]
           ,[FirstName]
           ,[LastName]
           ,[PostCode]
           ,[Fax]
           ,[ReferenceNumber]
           ,[City]
           ,[Region]
		   ,[IsReferralUnderJointInstruction] 
           )
	  VALUES
	  (
			@CompanyName,
			@Address,
			@Phone,
			@Email,
			@FirstName,
			@LastName,
			@PostCode,
			@Fax,
			@ReferenceNumber,
			@City,
			@Region,
			@IsReferralUnderJointInstruction
	  )
  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [global].[Add_User]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP Name: Add_User
--Latest Version: 1.1


-- Author:		Satya 
-- Create date: 11/03/2012
-- Description:	Add User information
-- Version: 1.0
--
-- Author:		Satya 
-- Version: 1.0
-- Description:	Added User fields

-- Author:		Vijay Kumar 
-- Create date: 11/06/2012
-- Version: 1.1
-- Description:	Add 3 more Fields: 
-- 1) SupplierID
-- 2) ReferrerID
-- 3) ReferrerLocationID
-- Author:		ftan 
-- Create date: 11/06/2012
-- Version: 1.2
-- Description:	Add 3 more Fields: 
-- 1) Email
-- 2) Telephone
-- 3) Fax

-- Author:		rkumar
-- Version:		1.3
-- Date:		07/10/2018
-- Description:	90 day Password Expiration check



CREATE PROCEDURE  [global].[Add_User] 
	-- Add the parameters for the stored procedure here
	   @UserName varchar(30)
      ,@Password varchar(70)
      ,@FirstName varchar(30)
      ,@LastName varchar(30)
      ,@UserTypeID int
	  ,@IsLocked bit
	  ,@SupplierTypes varchar(30)
	  ,@SupplierID int
	  ,@ReferrerTypes varchar(30)
	  ,@ReferrerID int
	  ,@ReferrerLocationID INT
	  ,@Email VARCHAR(50)
	  ,@Fax VARCHAR(16)
	  ,@Telephone VARCHAR(16)

AS
BEGIN	

    INSERT 
	INTO [global].Users  
	(  [UserName]
      ,[Password]
      ,[FirstName]
      ,[LastName]
      ,[UserTypeID]
      ,[IsLocked]
	  ,[SupplierTypes]
	  ,[SupplierID]
	  ,[ReferrerTypes]
	  ,[ReferrerID]
	  ,[ReferrerLocationID]
	  ,[Email]
	  ,[Fax]
	  ,[Telephone]
	  ,[PasswordExpirationDate]
	)
	  VALUES
	  (
	  @UserName,
	  @Password,
	  @FirstName,
	  @LastName,
	  @UserTypeID,
	  @IsLocked,
	  @SupplierTypes,
	  @SupplierID,
	  @ReferrerTypes,
	  @ReferrerID,
	  @ReferrerLocationID,
	  @Email,
	  @Fax,
	  @Telephone,
	  DATEADD(DD,90,getdate())
	  )
	  SELECT SCOPE_IDENTITY()

END


GO
/****** Object:  StoredProcedure [global].[Add_UserProject]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 05-06-2018
-- Description:	To insert in UserProject table (A link of User and Projects)
-- =============================================
CREATE PROCEDURE [global].[Add_UserProject](@ReferrerProjectID int, @UserID int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists(select * from global.Users where ReferrerTypes = 'Referrer Project User' and UserID = @UserID)
	begin 
		Delete from global.UserProject Where UserID = @UserID
	end
		Insert into global.UserProject(ReferrerProjectID, UserID) 
		Values(@ReferrerProjectID, @UserID)
	
	
END


GO
/****** Object:  StoredProcedure [global].[Delete_CaseAssessmentPatientInjuryByCaseAssessmentDetailID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
-- Author:  Rohit Kumar
-- Create date: 05/31/2019      
-- Description: CREATE SP Delete CaseAssessment Patient Injury By CaseAssessmentDetailID
-- Version: 1.0      
-- =============================================   
    
create PROCEDURE [global].[Delete_CaseAssessmentPatientInjuryByCaseAssessmentDetailID]    
(    
@CaseAssessmentDetailID int
)    
as   
BEGIN   
	delete from global.CaseAssessmentPatientInjuries  where CaseAssessmentDetailID=@CaseAssessmentDetailID
END  

GO
/****** Object:  StoredProcedure [global].[Delete_CaseAssessmentProposedTreatmentMethodByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--==============================================
-- Author By: Vishal sen     
-- Create date: 23/10/2013      
-- Description: Delete_CaseAssessmentProposedTreatmentMethodByCaseID
-- Version: 1.0
-- ============================================= 

CREATE PROCEDURE [global].[Delete_CaseAssessmentProposedTreatmentMethodByCaseID]
(
@CaseID  INT


)
 AS 
  BEGIN
  
  
  DELETE FROM  [global].[CaseAssessmentProposedTreatmentMethods]
      WHERE CaseID=@CaseID
  
        
END 








GO
/****** Object:  StoredProcedure [global].[Delete_CaseBespokeServiceByCaseBespokeServiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  SATYA
-- Create date: 09/16/2013  
-- Description: Stored procedure to Delete CaseBespokeService By CaseBespokeServiceID 
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Delete_CaseBespokeServiceByCaseBespokeServiceID]  
  @CaseBespokeServiceID INT  
AS  
 DELETE FROM [global].CaseBespokeServicePricing
      WHERE CaseBespokeServiceID = @CaseBespokeServiceID

GO
/****** Object:  StoredProcedure [global].[Delete_CaseByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Robin Singh  
-- Create date: 01/25/2013  
-- Description: Stored procedure to Delete Case By CaseID  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Delete_CaseByCaseID]  
  @CaseID INT  
AS  
 DELETE FROM [global].[Cases]
      WHERE CaseID=@CaseID

GO
/****** Object:  StoredProcedure [global].[Delete_CaseContactByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Delete_CaseContactByID] 
	@CaseContactID int,
	@IsDeleted bit	
AS	
	Update [global].[CaseContacts] SET IsDeleted = @IsDeleted where  CaseContactID = @CaseContactID
	
		        
	


GO
/****** Object:  StoredProcedure [global].[Delete_CasePatientContactAttemptByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh	
-- Create date: 20-07-2018
-- Description:	Delete Case patient Contact Attempt By ID 
-- =============================================
CREATE PROCEDURE [global].[Delete_CasePatientContactAttemptByID] 
	@CasePatientContactAttemptID INT  
AS  
 DELETE FROM [global].[CasePatientContactAttempts]
      WHERE CasePatientContactAttemptID=@CasePatientContactAttemptID


GO
/****** Object:  StoredProcedure [global].[Delete_CaseReferrerAssignedUserByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 03-05-2019
-- Description:	To get case referrer assigned user by caseID
-- =============================================
CREATE PROCEDURE [global].[Delete_CaseReferrerAssignedUserByID](@CaseReferrerAssignedUserID int)
AS
BEGIN
	SET NOCOUNT ON;	
	update global.CaseReferrerAssignedUsers set status=0 where CaseReferrerAssignedUserID=@CaseReferrerAssignedUserID
END

GO
/****** Object:  StoredProcedure [global].[Delete_CaseTreatmentPricingByCaseIDCaseStopped]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  MAHINDER SINGH
-- Create date: 03/03/2015
-- Description: Stored procedure to Update CaseTreatmentPricing By CaseID
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Delete_CaseTreatmentPricingByCaseIDCaseStopped]  
  @CaseID INT  
AS  
 
 DECLARE @ReferrerPricingID INT,@SupplierPriceID INT
 
 SELECT TOP 1 @ReferrerPricingID = ReferrerPricingID ,@SupplierPriceID = SupplierPriceID FROM [global].CaseTreatmentPricing  WHERE CaseID = @CaseID
 
 UPDATE [global].CaseTreatmentPricing 
         SET IsDeleted = 1,AuthorizationStatus = 0
         WHERE CaseID = @CaseID AND ReferrerPricingID != @ReferrerPricingID AND SupplierPriceID != @SupplierPriceID
         

GO
/****** Object:  StoredProcedure [global].[Delete_CaseTreatmentPricingByCaseTreatmentPricingID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  SATYA
-- Create date: 09/16/2013  
-- Description: Stored procedure to Delete CaseTreatmentPricing By CaseTreatmentPricingID 
-- Version: 1.0  
-- =============================================  
-- =============================================  
-- Author:  MAHINDER SINGH
-- Create date: 03/03/2015
-- Description: Stored procedure to Update CaseTreatmentPricing By CaseTreatmentPricingID 
-- Version: 1.1  
-- =============================================  
  
CREATE PROCEDURE [global].[Delete_CaseTreatmentPricingByCaseTreatmentPricingID]  
  @CaseTreatmentPricingID INT  
AS  
 --DELETE FROM [global].CaseTreatmentPricing
 --     WHERE CaseTreatmentPricingID = @CaseTreatmentPricingID
 
 UPDATE [global].CaseTreatmentPricing 
         SET IsDeleted = 1,AuthorizationStatus = 0
         WHERE CaseTreatmentPricingID = @CaseTreatmentPricingID
         

GO
/****** Object:  StoredProcedure [global].[Delete_PractitionerByPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Anuj Batra
-- Create date: 01/25/2013  
-- Description: Stored procedure to Delete Practitioner By PractitionerID  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Delete_PractitionerByPractitionerID]  
  @PractitionerID INT  
AS  
 DELETE FROM [global].Practitioners
      WHERE PractitionerID=@PractitionerID

GO
/****** Object:  StoredProcedure [global].[Delete_PractitionerExpertiseByPractitionerExpertiseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Pardeep Kumar  
-- Create date: 31-Jan-2013
-- Description: <Delete  PractitionerExpertise By PractitionerExpertiseID>  
-- Version : 1.0   
-- =============================================  
  
CREATE PROCEDURE [global].[Delete_PractitionerExpertiseByPractitionerExpertiseID]    
@PractitionerExpertiseID INT  
  
AS   
 BEGIN  
  
DELETE FROM global.PractitionerExpertise  
WHERE PractitionerExpertiseID=@PractitionerExpertiseID  
 END  

GO
/****** Object:  StoredProcedure [global].[Delete_PractitionerExpertiseByPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Pardeep Kumar  
-- Create date: 31-Jan-2013
-- Description: <Delete  PractitionerExpertise By PractitionerID>  
-- Version : 1.0   
-- =============================================  
  
CREATE PROCEDURE [global].[Delete_PractitionerExpertiseByPractitionerID]    
@PractitionerID INT  
  
AS   
 BEGIN  
  
DELETE FROM global.PractitionerExpertise  
WHERE PractitionerID=@PractitionerID  
 END  

GO
/****** Object:  StoredProcedure [global].[Delete_PractitionerRegistrationByPractitionerRegistrationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 03/08/2013
-- Description:	Create stored procedure to Delete PractitionerRegistrations By PractitionerRegistrationID
-- Version: 1.0
-- =============================================


CREATE PROCEDURE [global].[Delete_PractitionerRegistrationByPractitionerRegistrationID]
	-- Add the parameters for the stored procedure here
	   @PractitionerRegistrationID int

AS
BEGIN	

DELETE FROM
	 [global].[PractitionerRegistrations] 
	  Where PractitionerRegistrationID=@PractitionerRegistrationID
END

GO
/****** Object:  StoredProcedure [global].[Delete_UserProject]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 06-08-2018
-- Description:	Delete from User Project Assigned to User
-- =============================================
CREATE PROCEDURE [global].[Delete_UserProject](@referrerProjectID int, @userID int)	
AS
BEGIN	
	SET NOCOUNT ON;
	Delete from global.UserProject
	where ReferrerProjectID = @referrerProjectID and UserID = @userID
END


GO
/****** Object:  StoredProcedure [global].[Get_CaseAppointmentDateByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Robin Singh  
-- Create date: 18-April-2013
-- Description: < Get_CaseAppointmentDateByCaseID By CaseID>  
-- Version : 1.0   
-- =============================================  
-- Author:  Rohit Kumar
-- Create date: 17-Jan-2015
-- Description: < update as per task 2163>  
-- Version : 1.1   
-- =============================================  
-- Author:  HSingh
-- Create date: 30-Jan-2015
-- Description: Delete condition to get appointment date conditionaly whereas appointment date always fetched from table caseApppointmentDates.  
-- Version : 1.2   
-- ================================================================================================================================================
  
CREATE PROCEDURE [global].[Get_CaseAppointmentDateByCaseID]    
@CaseID INT
AS   
BEGIN  
	
	SELECT   CaseID, AppointmentDateTime, FirstAppointmentOfferedDate ,  convert(varchar(5),AppointmentDateTime,108) as strAppointmentTime , convert(varchar(10),AppointmentDateTime,103) as strAppointmentDate ,
	convert(varchar(10),AppointmentDateTime,101) as strAppointmentDate1 ,	
    AppointmentDateTime as CaseBookIADate,  isnull(IsCaseBookIADateUsed,0) as IsCaseBookIADateUsed
	FROM         global.CaseAppointmentDates WHERE CaseID=@CaseID 
	
END

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentAndValuesByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  ftan  
-- Create date: 12/14/2013
-- Description: Get case assessment data and the values for fk columns by passing case id. Used for reporting.  

-- Author:  HSingh
-- Create date: 06/18/2014
-- Description: Update to get data for Initial assesment and Initial assesment QA report.
-- =============================================  

CREATE PROCEDURE [global].[Get_CaseAssessmentAndValuesByCaseID]
 @CaseID INT,
 @ReportType varchar(10)='QA'
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
if @ReportType='QA'
BEGIN
	
	SELECT     global.CaseAssessments.AssessmentServiceID, global.CaseAssessments.CaseID, global.CaseAssessments.HasPatientConsentForm, 
						  global.CaseAssessments.IncidentAndDiagnosisDescription, global.CaseAssessments.NeuralSymptomDescription, 
						  global.CaseAssessments.PreExistingConditionDescription, global.CaseAssessments.IsPatientTakingMedication, 
						  global.CaseAssessments.FactorsAffectingTreatmentDescription, global.CaseAssessments.IsPatientUndergoingTreatment, 
						  global.CaseAssessments.PatientRequiresFurtherInvestigation, global.CaseAssessments.PatientRoleID, global.CaseAssessments.PatientOccupation, 
						  global.CaseAssessments.WasPatientWorkingAtTheTimeOfTheAccident, global.CaseAssessments.IsPatientSufferingFinancialLoss, 
						  global.CaseAssessments.AnticipatedDateOfDischarge, global.CaseAssessments.HasPatientHomeExerciseProgramme, 
						  global.CaseAssessments.HasPatientPastSymptoms, global.CaseAssessments.AssessmentAuthorisationID, global.CaseAssessments.IsAccepted, 
						  global.CaseAssessments.AuthorisationDetail, global.CaseAssessments.IsPatientDischarge, global.CaseAssessments.DeniedMessage, 
						  global.CaseAssessments.HasYellowFlags, global.CaseAssessments.UserID, global.CaseAssessments.HasRedFlags, lookup.PatientRoles.PatientRoleName
	FROM         global.CaseAssessments INNER JOIN
						  lookup.PatientRoles ON global.CaseAssessments.PatientRoleID = lookup.PatientRoles.PatientRoleID
	WHERE [CaseID] = @CaseID  
	
END
ELSE
BEGIN      

	SELECT     global.CaseAssessmentHistory.AssessmentServiceID, global.CaseAssessmentHistory.CaseID, global.CaseAssessmentHistory.HasPatientConsentForm, 
						  global.CaseAssessmentHistory.IncidentAndDiagnosisDescription, global.CaseAssessmentHistory.NeuralSymptomDescription, 
						  global.CaseAssessmentHistory.PreExistingConditionDescription, global.CaseAssessmentHistory.IsPatientTakingMedication, 
						  global.CaseAssessmentHistory.FactorsAffectingTreatmentDescription, global.CaseAssessmentHistory.IsPatientUndergoingTreatment, 
						  global.CaseAssessmentHistory.PatientRequiresFurtherInvestigation, global.CaseAssessmentHistory.PatientRoleID, global.CaseAssessmentHistory.PatientOccupation, 
						  global.CaseAssessmentHistory.WasPatientWorkingAtTheTimeOfTheAccident, global.CaseAssessmentHistory.IsPatientSufferingFinancialLoss, 
						  global.CaseAssessmentHistory.AnticipatedDateOfDischarge, global.CaseAssessmentHistory.HasPatientHomeExerciseProgramme, 
						  global.CaseAssessmentHistory.HasPatientPastSymptoms, global.CaseAssessmentHistory.AssessmentAuthorisationID, global.CaseAssessmentHistory.IsAccepted, 
						  global.CaseAssessmentHistory.AuthorisationDetail, global.CaseAssessmentHistory.IsPatientDischarge, global.CaseAssessmentHistory.DeniedMessage, 
						  global.CaseAssessmentHistory.HasYellowFlags, global.CaseAssessmentHistory.UserID, global.CaseAssessmentHistory.HasRedFlags, lookup.PatientRoles.PatientRoleName
	FROM         global.CaseAssessmentHistory INNER JOIN
						  lookup.PatientRoles ON global.CaseAssessmentHistory.PatientRoleID = lookup.PatientRoles.PatientRoleID
	WHERE [CaseID] = @CaseID
	
END

END

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  ftan  
-- Create date: 5/24/2013  
-- Description: Get case assessment data by passing case id  
-- =============================================  
-- Author:  Vishal sen  
-- Create date: 8/14/2013  
-- Description: Update SP as per new Model
-- =============================================  
-- [global].[Get_CaseAssessmentByCaseID]  1049
CREATE PROCEDURE [global].[Get_CaseAssessmentByCaseID]  
 @CaseID INT  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
     SELECT CaseID,AssessmentServiceID,HasPatientConsentForm,IncidentAndDiagnosisDescription,ISNULL(NeuralSymptomDescription,'') AS NeuralSymptomDescription,ISNULL(PreExistingConditionDescription,'') AS PreExistingConditionDescription,IsPatientUndergoingTreatment,
        IsPatientUndergoingTreatment,IsPatientTakingMedication,PatientRequiresFurtherInvestigation,ISNULL(FactorsAffectingTreatmentDescription,'') AS FactorsAffectingTreatmentDescription,PatientOccupation,PatientRoleID,WasPatientWorkingAtTheTimeOfTheAccident,
		IsPatientSufferingFinancialLoss,AnticipatedDateOfDischarge,HasPatientHomeExerciseProgramme,HasPatientPastSymptoms,AssessmentAuthorisationID,ISNULL(AuthorisationDetail,'') AS AuthorisationDetail,IsAccepted,IsPatientDischarge,ISNULL(DeniedMessage,'') AS DeniedMessage,
		HasYellowFlags,HasRedFlags,UserID,ISNULL(IsSaved,0) AS IsSaved,RelevantTestUndertaken
      FROM [global].[CaseAssessments]  
      WHERE [CaseID] = @CaseID 
END  





GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentCustom]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================================================
-- Author     :	Mahinder Singh
-- Create date: 18 DEC 2014
-- Description:	GET Case Assessment Custom according to Caseid
-- ==========================================================================================================
CREATE PROCEDURE [global].[Get_CaseAssessmentCustom]	
	@CaseID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	SELECT * FROM  global.CaseAssessMentCustoms WITH(READPAST,ROWLOCK) WHERE CaseID=@CaseID
END



GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentCustomsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================     
-- Latest Version : 1.0   
-- Author:  Rohit Kumar
-- Create date: 12-19-2014
-- Description: Get Case Assessment Customs to check the case status 
-- Version : 1.0       
-- =============================================    
CREATE PROCEDURE [global].[Get_CaseAssessmentCustomsByCaseID] --728   
 -- Add the parameters for the stored procedure here      
    @CaseID INT 
AS      
BEGIN       

	SELECT top 1 AssessmentServiceID FROM global.CaseAssessmentRatings WHERE (CaseID = @CaseID) order by CaseAssessmentRatingID desc
	
END




GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentDetailAndValuesByCaseIDAndAssessmentServiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=========================================================
-- Create By : ftan
-- Create date: 12/14/2013    
-- updated Version : 1.0  
-- Description: return caseassessment detail and the corresponding value names for all its fk columns. Primarily used for reporting.

-- Author:  HSingh
-- Create date: 06/26/2014
-- Description: Update to get data for Initial assesment and Initial assesment QA report.
--=========================================================


CREATE PROCEDURE [global].[Get_CaseAssessmentDetailAndValuesByCaseIDAndAssessmentServiceID]  
 @CaseID INT ,
 @AssessmentServiceID INT,
 @ReportType varchar(10)='QA'
AS  
BEGIN  

declare @AssessmentDate as datetime
set @AssessmentDate = (SELECT AppointmentDateTime FROM global.CaseAppointmentDates where CaseID = @CaseID)

if @ReportType='QA'
BEGIN
	SELECT    global.CaseAssessmentDetail.CaseAssessmentDetailID, global.CaseAssessmentDetail.AssessmentServiceID, global.CaseAssessmentDetail.CaseID, 
						  global.CaseAssessmentDetail.HasThePatientHadTimeOff, global.CaseAssessmentDetail.AbsentDetail, global.CaseAssessmentDetail.AbsentPeriod, 
						  global.CaseAssessmentDetail.HasThePatientReturnedToWork, global.CaseAssessmentDetail.PatientRecommendedTreatmentSessions, 
						  global.CaseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail, global.CaseAssessmentDetail.PatientTreatmentPeriod, 
						  global.CaseAssessmentDetail.PatientTreatmentPeriodDetail, global.CaseAssessmentDetail.IsFurtherTreatmentRecommended, 
						  global.CaseAssessmentDetail.SessionsPatientAttended, global.CaseAssessmentDetail.DatesOfSessionAttended, 
						  global.CaseAssessmentDetail.SessionsPatientFailedToAttend, global.CaseAssessmentDetail.AdditionalInformation, 
						  global.CaseAssessmentDetail.HasCompliedHomeExerciseProgramme, @AssessmentDate as AssessmentDate, 
						  lookup.PatientImpactOnWork.PatientImpactOnWorkName, lookup.PatientWorkstatus.PatientWorkstatusName, 
						  lookup.Durations.DurationName AS PatientTreatmentPeriodDuration, lookup.PatientLevelOfRecoveries.PatientLevelOfRecoveryName, 
						  PatientLevelOfRecoveries_1.PatientLevelOfRecoveryName AS FollowingTreatmentPatientLevelOfRecovery, global.Practitioners.PractitionerFirstName, 
						  global.Practitioners.PractitionerLastName, Durations_1.DurationName AS AbsentPeriodDuration
	FROM         global.CaseAssessmentDetail INNER JOIN
						  lookup.PatientImpactOnWork ON global.CaseAssessmentDetail.PatientImpactOnWorkID = lookup.PatientImpactOnWork.PatientImpactOnWorkID INNER JOIN
						  lookup.PatientWorkstatus ON global.CaseAssessmentDetail.PatientWorkstatusID = lookup.PatientWorkstatus.PatientWorkstatusID LEFT OUTER JOIN
						  lookup.Durations ON global.CaseAssessmentDetail.PatientTreatmentPeriodDurationID = lookup.Durations.DurationID INNER JOIN
						  lookup.PatientLevelOfRecoveries ON 
						  global.CaseAssessmentDetail.PatientLevelOfRecoveryID = lookup.PatientLevelOfRecoveries.PatientLevelOfRecoveryID LEFT OUTER JOIN
						  lookup.Durations AS Durations_1 ON global.CaseAssessmentDetail.AbsentPeriodDurationID = Durations_1.DurationID LEFT OUTER JOIN
						  lookup.PatientLevelOfRecoveries AS PatientLevelOfRecoveries_1 ON 
						  global.CaseAssessmentDetail.FollowingTreatmentPatientLevelOfRecoveryID = PatientLevelOfRecoveries_1.PatientLevelOfRecoveryID LEFT OUTER JOIN
						  global.Practitioners ON global.CaseAssessmentDetail.PractitionerID = global.Practitioners.PractitionerID
	WHERE [CaseID] = @CaseID  and AssessmentServiceID=@AssessmentServiceID
END	
ELSE
BEGIN
	SELECT     global.CaseAssessmentDetailHistory.CaseAssessmentDetailHistoryID as CaseAssessmentDetailID, global.CaseAssessmentDetailHistory.AssessmentServiceID, global.CaseAssessmentDetailHistory.CaseID, 
						  global.CaseAssessmentDetailHistory.HasThePatientHadTimeOff, global.CaseAssessmentDetailHistory.AbsentDetail, global.CaseAssessmentDetailHistory.AbsentPeriod, 
						  global.CaseAssessmentDetailHistory.HasThePatientReturnedToWork, global.CaseAssessmentDetailHistory.PatientRecommendedTreatmentSessions, 
						  global.CaseAssessmentDetailHistory.PatientRecommendedTreatmentSessionsDetail, global.CaseAssessmentDetailHistory.PatientTreatmentPeriod, 
						  global.CaseAssessmentDetailHistory.PatientTreatmentPeriodDetail, global.CaseAssessmentDetailHistory.IsFurtherTreatmentRecommended, 
						  global.CaseAssessmentDetailHistory.SessionsPatientAttended, global.CaseAssessmentDetailHistory.DatesOfSessionAttended, 
						  global.CaseAssessmentDetailHistory.SessionsPatientFailedToAttend, global.CaseAssessmentDetailHistory.AdditionalInformation, 
						  global.CaseAssessmentDetailHistory.HasCompliedHomeExerciseProgramme, @AssessmentDate as  AssessmentDate, 
						  lookup.PatientImpactOnWork.PatientImpactOnWorkName, lookup.PatientWorkstatus.PatientWorkstatusName, 
						  lookup.Durations.DurationName AS PatientTreatmentPeriodDuration, lookup.PatientLevelOfRecoveries.PatientLevelOfRecoveryName, 
						  PatientLevelOfRecoveries_1.PatientLevelOfRecoveryName AS FollowingTreatmentPatientLevelOfRecovery, global.Practitioners.PractitionerFirstName, 
						  global.Practitioners.PractitionerLastName, Durations_1.DurationName AS AbsentPeriodDuration
	FROM         global.CaseAssessmentDetailHistory INNER JOIN
						  lookup.PatientImpactOnWork ON global.CaseAssessmentDetailHistory.PatientImpactOnWorkID = lookup.PatientImpactOnWork.PatientImpactOnWorkID INNER JOIN
						  lookup.PatientWorkstatus ON global.CaseAssessmentDetailHistory.PatientWorkstatusID = lookup.PatientWorkstatus.PatientWorkstatusID LEFT OUTER JOIN
						  lookup.Durations ON global.CaseAssessmentDetailHistory.PatientTreatmentPeriodDurationID = lookup.Durations.DurationID INNER JOIN
						  lookup.PatientLevelOfRecoveries ON 
						  global.CaseAssessmentDetailHistory.PatientLevelOfRecoveryID = lookup.PatientLevelOfRecoveries.PatientLevelOfRecoveryID LEFT OUTER JOIN
						  lookup.Durations AS Durations_1 ON global.CaseAssessmentDetailHistory.AbsentPeriodDurationID = Durations_1.DurationID LEFT OUTER JOIN
						  lookup.PatientLevelOfRecoveries AS PatientLevelOfRecoveries_1 ON 
						  global.CaseAssessmentDetailHistory.FollowingTreatmentPatientLevelOfRecoveryID = PatientLevelOfRecoveries_1.PatientLevelOfRecoveryID LEFT OUTER JOIN
						  global.Practitioners ON global.CaseAssessmentDetailHistory.PractitionerID = global.Practitioners.PractitionerID
	WHERE [CaseID] = @CaseID  and AssessmentServiceID=@AssessmentServiceID

END  

END

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentDetailByCaseAssessmentDetailID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=========================================================
-- Create By : Vishal sen    
-- Create date: 10/17/2013    
-- updated Version : 1.0  
-- Description: create sp GetCaseAssessmentDetailByCaseAssessmentDetailID
--=========================================================


CREATE PROCEDURE [global].[Get_CaseAssessmentDetailByCaseAssessmentDetailID] 
 @CaseAssessmentDetailID INT 
 
AS  
BEGIN  
SELECT        global.CaseAssessmentDetail.CaseAssessmentDetailID, global.CaseAssessmentDetail.AssessmentServiceID, global.CaseAssessmentDetail.CaseID, global.CaseAssessmentDetail.HasThePatientHadTimeOff, 
                         global.CaseAssessmentDetail.AbsentDetail, global.CaseAssessmentDetail.AbsentPeriod, global.CaseAssessmentDetail.AbsentPeriodDurationID, global.CaseAssessmentDetail.HasThePatientReturnedToWork, 
                         global.CaseAssessmentDetail.PatientImpactOnWorkID, global.CaseAssessmentDetail.PatientWorkstatusID, global.CaseAssessmentDetail.PatientRecommendedTreatmentSessions, 
                         global.CaseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail, global.CaseAssessmentDetail.PatientTreatmentPeriod, global.CaseAssessmentDetail.PatientTreatmentPeriodDetail, 
                         global.CaseAssessmentDetail.PatientTreatmentPeriodDurationID, global.CaseAssessmentDetail.IsFurtherTreatmentRecommended, global.CaseAssessmentDetail.PatientLevelOfRecoveryID, 
                         global.CaseAssessmentDetail.SessionsPatientAttended, global.CaseAssessmentDetail.DatesOfSessionAttended, global.CaseAssessmentDetail.SessionsPatientFailedToAttend, 
                         global.CaseAssessmentDetail.FollowingTreatmentPatientLevelOfRecoveryID, global.CaseAssessmentDetail.IsFurtherInvestigationOrOnwardReferralRequired, 
                         global.CaseAssessmentDetail.FurtherInvestigationOrOnwardReferral, global.CaseAssessmentDetail.EvidenceOfTreatmentRecommendations, global.CaseAssessmentDetail.AdditionalInformation, 
                         global.CaseAssessmentDetail.HasCompliedHomeExerciseProgramme, global.CaseAssessmentDetail.AssessmentDate, global.CaseAssessmentDetail.PractitionerID, global.CaseAssessmentDetail.EvidenceOfClinicalReasoning, 
                         isnull(global.CaseAssessmentDetail.TreatmentPeriodTypeID,0) as TreatmentPeriodTypeID, global.CaseAssessmentDetail.PatientDateOfReturn, global.CaseAssessmentDetail.PatientRecommendationReturn, 
                         global.CaseAssessmentDetail.IsPatientReturnToPreInjuryDuties, global.CaseAssessmentDetail.PatientPreInjuryDutiesDate, global.CaseAssessmentDetail.MainFactors, global.CaseAssessments.CaseID AS Expr1, 
                         global.CaseAssessments.AssessmentServiceID AS Expr2, global.CaseAssessments.HasPatientConsentForm, global.CaseAssessments.IncidentAndDiagnosisDescription, global.CaseAssessments.NeuralSymptomDescription, 
                         global.CaseAssessments.RelevantTestUndertaken, global.CaseAssessments.PreExistingConditionDescription, global.CaseAssessments.IsPatientUndergoingTreatment, global.CaseAssessments.IsPatientTakingMedication, 
                         global.CaseAssessments.PatientRequiresFurtherInvestigation, global.CaseAssessments.FactorsAffectingTreatmentDescription, global.CaseAssessments.PatientOccupation, global.CaseAssessments.PatientRoleID, 
                         global.CaseAssessments.WasPatientWorkingAtTheTimeOfTheAccident, global.CaseAssessments.IsPatientSufferingFinancialLoss, global.CaseAssessments.AnticipatedDateOfDischarge, 
                         global.CaseAssessments.HasPatientHomeExerciseProgramme, global.CaseAssessments.HasPatientPastSymptoms, global.CaseAssessments.AssessmentAuthorisationID, global.CaseAssessments.AuthorisationDetail, 
                         global.CaseAssessments.IsAccepted, global.CaseAssessments.IsPatientDischarge, global.CaseAssessments.DeniedMessage, global.CaseAssessments.HasYellowFlags, global.CaseAssessments.HasRedFlags, 
                         global.CaseAssessments.UserID, global.CaseAssessments.IsSaved
FROM            global.CaseAssessmentDetail INNER JOIN
                         global.CaseAssessments ON global.CaseAssessmentDetail.CaseID = global.CaseAssessments.CaseID

where global.CaseAssessmentDetail.CaseAssessmentDetailID=@CaseAssessmentDetailID
END  

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentDetailByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=========================================================
-- Create By : Vishal sen    
-- Create date: 10/17/2013    
-- updated Version : 1.0  
-- Description: create sp Get_CaseAssessmentDetailByCaseID
--=========================================================


CREATE PROCEDURE [global].[Get_CaseAssessmentDetailByCaseID]  
 @CaseID INT 
 
AS  
BEGIN  

SELECT  CaseAssessmentDetailID, AssessmentServiceID, CaseID, HasThePatientHadTimeOff, AbsentDetail, AbsentPeriod, AbsentPeriodDurationID, HasThePatientReturnedToWork, PatientImpactOnWorkID, PatientWorkstatusID, 
                         PatientRecommendedTreatmentSessions, PatientRecommendedTreatmentSessionsDetail, PatientTreatmentPeriod, PatientTreatmentPeriodDetail, PatientTreatmentPeriodDurationID, IsFurtherTreatmentRecommended, 
                         PatientLevelOfRecoveryID, SessionsPatientAttended, DatesOfSessionAttended, SessionsPatientFailedToAttend, FollowingTreatmentPatientLevelOfRecoveryID, IsFurtherInvestigationOrOnwardReferralRequired, 
                         FurtherInvestigationOrOnwardReferral, EvidenceOfTreatmentRecommendations, AdditionalInformation, HasCompliedHomeExerciseProgramme, AssessmentDate, PractitionerID, EvidenceOfClinicalReasoning, 
                         ISNULL(TreatmentPeriodTypeID,0) as TreatmentPeriodTypeID, PatientDateOfReturn, PatientRecommendationReturn, IsPatientReturnToPreInjuryDuties, PatientPreInjuryDutiesDate, MainFactors
FROM            global.CaseAssessmentDetail
      WHERE [CaseID] = @CaseID  
END  

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentDetailByCaseIDAndAssessmentServiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=========================================================
-- Create By : Vishal sen    
-- Create date: 8/19/2013    
-- updated Version : 1.0  
-- Description: create sp Get_CaseAssessmentDetailByCaseIDAndAssessmentServiceID

--=========================================================
-- Create By : Rohit Kumar 
-- Create date: 1/15/2015    
-- updated Version : 1.1  
-- Description: create apply the check of Case Book IA Date as per task-2163
--=========================================================
-- Create By : Tarun Gosain
-- Create date: 1/19/2015    
-- updated Version : 1.2  
-- Description: New field inserted EvidenceOfClinicalReasoning
--=================================================================================================
-- Create By : HSingh
-- Create date: 1/20/2015    
-- updated Version : 1.3
-- Description: New field inserted IsFurtherInvestigationOrOnwardReferralRequired, 
--              FurtherInvestigationOrOnwardReferral, EvidenceOfTreatmentRecommendations
--=================================================================================================
-- Create By : HSingh
-- Create date: 1/30/2015
-- updated Version : 1.4
-- Description: Delete check of Case Book IA Date because appointment date is fetched with another SP
--=====================================================================================================

--   [global].[Get_CaseAssessmentDetailByCaseIDAndAssessmentServiceID]  4364,1
CREATE PROCEDURE [global].[Get_CaseAssessmentDetailByCaseIDAndAssessmentServiceID]  
 @CaseID INT ,
 @AssessmentServiceID INT
AS  
BEGIN  
	
	SELECT        CaseAssessmentDetailID, AssessmentServiceID, CaseID, HasThePatientHadTimeOff, AbsentDetail, AbsentPeriod, AbsentPeriodDurationID, 
                         HasThePatientReturnedToWork, PatientImpactOnWorkID, PatientWorkstatusID, PatientRecommendedTreatmentSessions, 
                         PatientRecommendedTreatmentSessionsDetail, PatientTreatmentPeriod, PatientTreatmentPeriodDetail, PatientTreatmentPeriodDurationID, 
                         IsFurtherTreatmentRecommended, PatientLevelOfRecoveryID, SessionsPatientAttended, DatesOfSessionAttended, SessionsPatientFailedToAttend, 
                         FollowingTreatmentPatientLevelOfRecoveryID, IsFurtherInvestigationOrOnwardReferralRequired, FurtherInvestigationOrOnwardReferral, 
                         EvidenceOfTreatmentRecommendations, AdditionalInformation, HasCompliedHomeExerciseProgramme, AssessmentDate, PractitionerID, 
                         EvidenceOfClinicalReasoning, ISNULL(TreatmentPeriodTypeID,0) As TreatmentPeriodTypeID, PatientDateOfReturn, PatientRecommendationReturn, IsPatientReturnToPreInjuryDuties, 
                         PatientPreInjuryDutiesDate, MainFactors
FROM            global.CaseAssessmentDetail
	WHERE [CaseID] = @CaseID  and AssessmentServiceID=@AssessmentServiceID
	
END

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentDetailReviewByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--=========================================================
-- Create By : Mahinder Singh    
-- Create date: 06/30/2014    
-- updated Version : 1.0  
-- Description: create sp Get_CaseAssessmentDetailReviewByCaseID
--=========================================================


CREATE PROCEDURE [global].[Get_CaseAssessmentDetailReviewByCaseID]  
 @CaseID INT 
 
AS  
BEGIN  

 SELECT *
      FROM [global].[CaseAssessmentDetail]  
      WHERE [CaseID] = @CaseID  and  AssessmentServiceID = 2 
END  

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentDetailsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_CaseAssessmentDetailsByCaseID]
(
@CaseID INT,
@ReportType VARCHAR(20)
)
AS 
  	BEGIN    
 	if (@ReportType = 'Review Assessment' OR @ReportType = 'Final Assessment')
	BEGIN
		 SELECT 
global.CaseAssessments.HasYellowFlags, global.CaseAssessments.HasRedFlags,global.CaseAssessments.HasPatientConsentForm,global.CaseAssessments.PatientOccupation,
global.CaseAssessments.HasPatientPastSymptoms, global.CaseAssessments.PatientRequiresFurtherInvestigation, global.CaseAssessments.IsPatientTakingMedication ,
global.CaseAssessments.IsPatientUndergoingTreatment,  global.CaseAssessments.RelevantTestUndertaken ,
CASE WHEN global.CaseAssessments.HasYellowFlags=1 OR global.CaseAssessments.HasRedFlags=1 OR
global.CaseAssessments.HasPatientPastSymptoms=1 OR global.CaseAssessments.PatientRequiresFurtherInvestigation=1 OR global.CaseAssessments.IsPatientTakingMedication =1 OR
global.CaseAssessments.IsPatientUndergoingTreatment=1 THEN global.CaseAssessments.FactorsAffectingTreatmentDescription 
ELSE '' END AS FactorsAffectingTreatmentDescription
FROM global.CaseAssessments INNER JOIN [lookup].[AssessmentServices] _AS ON _AS.AssessmentServiceID= global.CaseAssessments.AssessmentServiceID where _AS.AssessmentServiceName= 
@ReportType AND global.CaseAssessments.CaseID=@CaseID

  	END	
	ELSE
	BEGIN

 SELECT 
global.CaseAssessments.HasYellowFlags, global.CaseAssessments.HasRedFlags,global.CaseAssessments.HasPatientConsentForm,global.CaseAssessments.PatientOccupation,
global.CaseAssessments.HasPatientPastSymptoms, global.CaseAssessments.PatientRequiresFurtherInvestigation, global.CaseAssessments.IsPatientTakingMedication ,
global.CaseAssessments.IsPatientUndergoingTreatment,  global.CaseAssessments.RelevantTestUndertaken ,
CASE WHEN global.CaseAssessments.HasYellowFlags=1 OR global.CaseAssessments.HasRedFlags=1 OR
global.CaseAssessments.HasPatientPastSymptoms=1 OR global.CaseAssessments.PatientRequiresFurtherInvestigation=1 OR global.CaseAssessments.IsPatientTakingMedication =1 OR
global.CaseAssessments.IsPatientUndergoingTreatment=1 THEN global.CaseAssessments.FactorsAffectingTreatmentDescription 
ELSE '' END AS FactorsAffectingTreatmentDescription
FROM global.CaseAssessments INNER JOIN [lookup].[AssessmentServices] _AS ON _AS.AssessmentServiceID= global.CaseAssessments.AssessmentServiceID where _AS.AssessmentServiceName= 
@ReportType AND global.CaseAssessments.CaseID=@CaseID


  END
END
 
  
 






GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentExistsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_CaseAssessmentExistsByCaseID]  
 @CaseID INT    
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here    
 SELECT ISNULL((SELECT CONVERT(BIT,1)	
      FROM [global].[CaseAssessments]    
      WHERE [CaseID] = @CaseID ),CONVERT(BIT,0))   
END 

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentPatientImpactsAndValuesByCaseAssessmentDetailID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  
-- =============================================  
-- Author:  ftan  
-- Create date: 12/14/2013  
-- Description:  Will return patient impacts and their corresponding values names. Primaly used in reporting.
-- =============================================  
-- Author:  HSingh
-- Create date: 06/26/2014
-- Description: Update to get data for Initial assesment and Initial assesment QA report.
--=========================================================

  
CREATE PROCEDURE [global].[Get_CaseAssessmentPatientImpactsAndValuesByCaseAssessmentDetailID]   
(  
@CaseAssessmentDetailID int,
@ReportType varchar(10)='QA'
)  
as  
BEGIN
	if @ReportType='QA'
	BEGIN
		SELECT p.[PatientImpactName]
			  ,piv.[PatientImpactValueName]
			  ,cpi.[Comment]
			   FROM global.CaseAssessmentPatientImpacts cpi 
		INNER JOIN lookup.PatientImpactValues piv ON cpi.PatientImpactValueID = piv.PatientImpactValueID
		INNER JOIN lookup.PatientImpacts p ON cpi.PatientImpactID = p.PatientImpactID
		WHERE cpi.[CaseAssessmentDetailID] = @CaseAssessmentDetailID
	END	
	ELSE
	BEGIN
		SELECT p.[PatientImpactName]
			  ,piv.[PatientImpactValueName]
			  ,cpi.[Comment]
			   FROM global.CaseAssessmentPatientImpactHistory cpi 
		INNER JOIN lookup.PatientImpactValues piv ON cpi.PatientImpactValueID = piv.PatientImpactValueID
		INNER JOIN lookup.PatientImpacts p ON cpi.PatientImpactID = p.PatientImpactID
		WHERE cpi.[CaseAssessmentDetailHistoryID] = @CaseAssessmentDetailID
	end
end

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentPatientImpactsByCaseAssessmentDetailID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Anuj Batra  
-- Create date: 05/23/2013  
-- Description:  Create Sp for Get_CaseAssessmentPatientImpactsByCaseID.  
-- =============================================  
-- Updator:  Vishal  
-- Create date: 08/14/2013  
-- Description:  Modify Name and SP .  
-- =============================================  
  
CREATE PROCEDURE [global].[Get_CaseAssessmentPatientImpactsByCaseAssessmentDetailID]   
(  
@CaseAssessmentDetailID int  
)  
as  
select * from global.CaseAssessmentPatientImpacts where CaseAssessmentDetailID = @CaseAssessmentDetailID

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentPatientImpactsByPatientImpactID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anuj Batra
-- Create date: 05/23/2013
-- Description:	 Create Sp for Get_AssessmentPatientImpactsByPatientImpactID.
-- =============================================

CREATE PROCEDURE [global].[Get_CaseAssessmentPatientImpactsByPatientImpactID]
(
@PatientImpactID int
)
as
select * from global.CaseAssessmentPatientImpacts where PatientImpactID = @PatientImpactID

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentPatientImpactsByPatientImpactValueID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Anuj Batra
-- Create date: 05/23/2013
-- Description:	 Create Sp for Get_AssessmentPatientImpactsByPatientImpactValueID.
-- =============================================

CREATE PROCEDURE [global].[Get_CaseAssessmentPatientImpactsByPatientImpactValueID] 
(
@PatientImpactValueID int
)
as
select * from global.CaseAssessmentPatientImpacts where PatientImpactValueID = @PatientImpactValueID

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentPatientInjuriesByCaseAssessmentDetailID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Harpreet singh  
-- Create date: 24/05/2013  
-- Description: alter PROCEDURE for Get_CaseAssessmentPatientInjuriesByCaseID   
-- Version: 1.0  
-- =============================================  
-- Updator:  Vishal sen 
-- Create date: 08/14/2013  
-- Description: Update Procedure name and colummn
-- Version: 1.1  
-- =============================================  
-- Author:  HSingh
-- Create date: 06/26/2014
-- Description: Update to get data for Initial assesment and Initial assesment QA report.
--  [global].[Get_CaseAssessmentPatientInjuriesByCaseAssessmentDetailID] 1046
--=========================================================
  
CREATE PROCEDURE [global].[Get_CaseAssessmentPatientInjuriesByCaseAssessmentDetailID]  
(  
@CaseAssessmentDetailID int,
@ReportType varchar(10)='QA'
)  
as
BEGIN
	if @ReportType='QA'
	BEGIN
		SELECT CAI.CaseAssessmentPatientInjuryID,(CASE WHEN CAI.AffectedArea  IS NULL THEN AA.AffectedAreaDescription Else CAI.AffectedArea END) AS AffectedArea ,CAI.Score,
			(CASE WHEN CAI.Restriction IS NULL THEN RR.RestrictionRangeDescription Else CAI.Restriction END) AS  Restriction,CAI.CaseAssessmentDetailID,
			ISNULL(CAI.SymptomDescriptionID, 0) AS SymptomDescriptionID,ISNULL(CAI.StrengthTestingID, 0) AS StrengthTestingID ,CAI.OtherSymptomDesciption,
			ISNULL(CAI.AffectedAreaID, 0) AS AffectedAreaID ,ISNULL(CAI.RestrictionRangeID, 0) AS RestrictionRangeID
			FROM  [global].[CaseAssessmentPatientInjuries] CAI
				LEFT JOIN [lookup].[SymptomDescriptions]  SD ON SD.SymptomDescriptionID = CAI.SymptomDescriptionID
				LEFT JOIN [lookup].[StrengthTestings] ST ON ST.StrengthTestingID = CAI.StrengthTestingID
				LEFT JOIN [lookup].[AffectedAreas] AA ON AA.AffectedAreaID = CAI.AffectedAreaID
				LEFT JOIN [lookup].[RestrictionRanges] RR ON RR.RestrictionRangeID = CAI.RestrictionRangeID
			WHERE CAI.CaseAssessmentDetailID = @CaseAssessmentDetailID
	END	
	ELSE
	BEGIN
		SELECT CAPH.CaseAssessmentPatientInjuryHistoryID,(CASE WHEN CAPH.AffectedArea  IS NULL THEN AA.AffectedAreaDescription Else CAPH.AffectedArea END) AS AffectedArea ,CAPH.Score,
			(CASE WHEN CAPH.Restriction IS NULL THEN RR.RestrictionRangeDescription Else CAPH.Restriction END) AS  Restriction,CAPH.CaseAssessmentPatientInjuryHistoryID,ISNULL(CAPH.SymptomDescriptionID,0) AS SymptomDescriptionID,
			ISNULL(CAPH.StrengthTestingID, 0) AS StrengthTestingID ,ISNULL(CAPH.AffectedAreaID, 0) AS AffectedAreaID,ISNULL(CAPH.RestrictionRangeID, 0) AS RestrictionRangeID, CAPH.OtherSymptomDesciption
			FROM  global.CaseAssessmentPatientInjuryHistory CAPH
				LEFT JOIN [lookup].[SymptomDescriptions]  SD ON SD.SymptomDescriptionID = CAPH.SymptomDescriptionID
				LEFT JOIN [lookup].[StrengthTestings] ST ON ST.StrengthTestingID = CAPH.StrengthTestingID
				LEFT JOIN [lookup].[AffectedAreas] AA ON AA.AffectedAreaID = CAPH.AffectedAreaID
				LEFT JOIN [lookup].[RestrictionRanges] RR ON RR.RestrictionRangeID = CAPH.RestrictionRangeID
		WHERE (CAPH.CaseAssessmentPatientInjuryHistoryID = @CaseAssessmentDetailID)
	end
end

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentPatientInjuriesByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 08-08-2018
-- Description:	Get CaseAssessmentPatientInjuries list by caseID
-- =============================================
CREATE PROCEDURE [global].[Get_CaseAssessmentPatientInjuriesByCaseID] (@CaseID int)
AS
BEGIN	
	SET NOCOUNT ON;
    -- Insert statements for procedure here	
		SELECT      capi.CaseAssessmentPatientInjuryID
					, capi.Score, capi.CaseAssessmentDetailID
					, isnull(capi.SymptomDescriptionID,0) as SymptomDescriptionID
					, isnull(capi.StrengthTestingID,0) as StrengthTestingID, isnull(capi.AffectedAreaID, 0) as AffectedAreaID, isnull(capi.RestrictionRangeID, 0) as RestrictionRangeID, capi.OtherSymptomDesciption
					, sd.SymptomDescriptionName, st.StrengthTestingDescription, aa.AffectedAreaDescription

		FROM            Global.CaseAssessmentPatientInjuries AS capi LEFT OUTER JOIN 
						lookup.SymptomDescriptions AS sd ON sd.SymptomDescriptionID = capi.SymptomDescriptionID LEFT OUTER JOIN 
						lookup.StrengthTestings AS st ON st.StrengthTestingID = capi.StrengthTestingID LEFT OUTER JOIN
						lookup.AffectedAreas as aa on aa.AffectedAreaID = capi.AffectedAreaID LEFT OUTER JOIN
						lookup.RestrictionRanges rr on rr.RestrictionRangeID = capi.RestrictionRangeID

		WHERE        (capi.CaseAssessmentDetailID IN
									 (SELECT        CaseAssessmentDetailID
									   FROM            global.CaseAssessmentDetail
									   WHERE        (CaseID = @CaseID)))
END


GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentProposedTreatmentMethodsAndValuesByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  HSingh
-- Create date: 06/26/2014
-- Description: Update to get data for Initial assesment and Initial assesment QA report.
--=========================================================
CREATE PROCEDURE [global].[Get_CaseAssessmentProposedTreatmentMethodsAndValuesByCaseID]    
 @CaseID INT,
@ReportType varchar(10)='QA'
AS    
BEGIN    
 	if @ReportType='QA'
	BEGIN
		  -- Insert statements for procedure here    
		  SELECT [ProposedTreatmentMethodName],[CaseID]
		  FROM global.[CaseAssessmentProposedTreatmentMethods]  
		  INNER JOIN lookup.ProposedTreatmentMethods ON global.CaseAssessmentProposedTreatmentMethods.ProposedTreatmentMethodID = lookup.ProposedTreatmentMethods.ProposedTreatmentMethodID  
		  WHERE [CaseID] = @CaseID
  	END	
	ELSE
	BEGIN
		  SELECT [ProposedTreatmentMethodName],[CaseID]
		  FROM global.[CaseAssessmentProposedTreatmentMethodHistory]  
		  INNER JOIN lookup.ProposedTreatmentMethods ON global.CaseAssessmentProposedTreatmentMethodHistory.ProposedTreatmentMethodID = lookup.ProposedTreatmentMethods.ProposedTreatmentMethodID  
		  WHERE [CaseID] = @CaseID
  END
END

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentProposedTreatmentMethodsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 

CREATE PROCEDURE [global].[Get_CaseAssessmentProposedTreatmentMethodsByCaseID]  
 @CaseID INT  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
 SELECT *
      FROM [global].[CaseAssessmentProposedTreatmentMethods]  
      WHERE [CaseID] = @CaseID  
END  

GO
/****** Object:  StoredProcedure [global].[Get_CaseAssessmentRatingByCaseIDAndAssessmentServiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vishal sen
-- Description:	Get CaseAssessmentRating By CaseID And AssessmentServiceID 
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [global].[Get_CaseAssessmentRatingByCaseIDAndAssessmentServiceID]
	-- Add the parameters for the stored procedure here
	@CaseID INT,
	@AssessmentServiceID INT
AS
BEGIN	
 
    SELECT [CaseAssessmentRatingID]
      ,[CaseID]
      ,[AssessmentServiceID]
      ,[Rating]
      ,[RatingDate]
    FROM [global].[CaseAssessmentRatings] where CaseID=@CaseID 
    and AssessmentServiceID=@AssessmentServiceID
   
    END
 


GO
/****** Object:  StoredProcedure [global].[Get_CaseBespokeServicePricingByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anuj Batra
-- Create date: 30-May2013
-- Description:	Get CaseBespokeServicePricing data by passing case id
-- =============================================
CREATE PROCEDURE [global].[Get_CaseBespokeServicePricingByCaseID]
	@CaseID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  
	SELECT *
      FROM [global].CaseBespokeServicePricing
      WHERE [CaseID] = @CaseID
END


GO
/****** Object:  StoredProcedure [global].[Get_CaseBespokeServicePricingByCaseIDAndIsComplete]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

    
-- =============================================    
-- Author:  Pardeep     
-- Create date: 16-Sep-2013    
-- Description: Get CaseBespokeServicePricing By CaseID And IsComplete  
-- =============================================    
    
CREATE PROCEDURE [global].[Get_CaseBespokeServicePricingByCaseIDAndIsComplete]      
@CaseID INT,  
@IsComplete BIT  
  
AS      
SELECT     global.CaseBespokeServicePricing.*, lookup.BespokeServices.BespokeServiceName
FROM         global.CaseBespokeServicePricing INNER JOIN
                      lookup.TreatmentCategoryBespokeServices ON 
                      global.CaseBespokeServicePricing.TreatmentCategoryBespokeServiceID = lookup.TreatmentCategoryBespokeServices.TreatmentCategoryBespokeServiceID INNER JOIN
                      lookup.BespokeServices ON lookup.TreatmentCategoryBespokeServices.BespokeServiceID = lookup.BespokeServices.BespokeServiceID
  WHERE CaseID=@CaseID  --AND IsComplete = @IsComplete  
    

GO
/****** Object:  StoredProcedure [global].[Get_CaseByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[global].[Get_CaseByCaseID] 1106
CREATE PROCEDURE [global].[Get_CaseByCaseID]  
@CaseID int  
AS  
   SELECT   CaseID,  PatientID,   ReferrerID,ISNULL(ReferrerProjectID,0) AS ReferrerProjectID,  CaseNumber,   ReferrerProjectTreatmentID,   TreatmentTypeID,   CaseReferrerReferenceNumber, CaseSpecialInstruction, 
	 CaseReferrerDueDate, CaseSubmittedDate,  SupplierID,  WorkflowID,  PatientContactDate, PatientContactedByInternalUser, PatientContactNotes,  IsTreatmentRequired, 
	 IsTriage,  InvoiceDate,  InjuryType, isnull( IsCustom,0) as IsCustom,  SendInvoiceTo,  SendInvoiceName,  SendInvoiceEmail,ReferrerAssignedUser,SupplierAssignedUser,InnovateNote,
	 OfficeLocationID,ISNULL(EmployeeDetailID,0) AS EmployeeDetailID, ISNULL(DrugTestID,0) AS DrugTestID, ISNULL(JobDemandID,0) AS JobDemandID,ISNULL(IsNewPolicyTypeID,0) AS IsNewPolicyTypeID,NewPolicyReferenceNumber

	FROM  global.Cases  
	WHERE   CaseID=@CaseID
  

 

GO
/****** Object:  StoredProcedure [global].[Get_CaseByLikeCaseNumber]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  <Robin Singh>  
-- Create date: <01-25-2013>  
-- Description: <Create the procedure to Get the Cases by casenumber Like ,>  
-- =============================================  
CREATE PROCEDURE [global].[Get_CaseByLikeCaseNumber] 
@CaseNumber varchar(20)  
AS  
SELECT *
  FROM [global].[Cases]
  WHERE (CaseNumber LIKE (@CaseNumber + '%') )  

GO
/****** Object:  StoredProcedure [global].[Get_CaseByPatientID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
---[global].[Get_CaseByPatientID] 1106
CREATE PROCEDURE [global].[Get_CaseByPatientID]  
@PatientID int  
AS  
   SELECT   CaseID,  PatientID,   ReferrerID,ISNULL(ReferrerProjectID,0) AS ReferrerProjectID,  CaseNumber,   ReferrerProjectTreatmentID,   TreatmentTypeID,   CaseReferrerReferenceNumber, CaseSpecialInstruction, 
	 CaseReferrerDueDate, CaseSubmittedDate,  SupplierID,  WorkflowID,  PatientContactDate, PatientContactedByInternalUser, PatientContactNotes,  IsTreatmentRequired, 
	 IsTriage,  InvoiceDate,  InjuryType, isnull( IsCustom,0) as IsCustom,  SendInvoiceTo,  SendInvoiceName,  SendInvoiceEmail,ReferrerAssignedUser,SupplierAssignedUser
	FROM  global.Cases  
	WHERE   PatientID=@PatientID
  

 

GO
/****** Object:  StoredProcedure [global].[Get_CaseCommunicationHistoriesByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Vishal  
-- Create date: 10/10/2013  
-- Description: Create stored procedure to Add GetCaseCommunicationHistoriesByCaseID  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Get_CaseCommunicationHistoriesByCaseID]  
   @CaseID int           
AS  
BEGIN  
  
if((SELECT isnull(IsCustom,0) FROM global.Cases where CaseID = @CaseID ) >0)
begin

declare @SupplierID int
declare @ReferrerProjectTreatmentID int
SELECT  @ReferrerProjectTreatmentID = ReferrerProjectTreatmentID, @SupplierID = SupplierID FROM global.Cases where CaseID = @CaseID

SELECT      global.CaseCommunicationHistory.CaseCommunicationHistoryID, 
                      global.CaseCommunicationHistory.CaseID, global.CaseCommunicationHistory.SentTo, global.CaseCommunicationHistory.SentCC, 
                      global.CaseCommunicationHistory.Subject, global.CaseCommunicationHistory.Message, global.CaseCommunicationHistory.UserID, 
                      global.CaseCommunicationHistory.DateAdded, global.CaseCommunicationHistory.UploadPath +'|' +convert(varchar(10),@SupplierID) +'|' + convert(varchar(10),@ReferrerProjectTreatmentID)
                      +'|' +convert(varchar(10),@CaseID)
                      as UploadPath ,[global].[Users].FirstName,[global].[Users].LastName ,[global].[Users].Username 
FROM         global.CaseCommunicationHistory INNER JOIN
                      global.Users ON global.CaseCommunicationHistory.UserID = global.Users.UserID
WHERE     (global.CaseCommunicationHistory.CaseID = @CaseID)

end
else
  
     SELECT [global].[CaseCommunicationHistory].* ,[global].[Users].FirstName,[global].[Users].LastName ,[global].[Users].Username  
	 FROM [global].[CaseCommunicationHistory]   
	inner join [global].[Users] on     
	   [global].[CaseCommunicationHistory].UserID = [global].[Users].UserID       
	  where  [global].[CaseCommunicationHistory].CaseID = @CaseID 
END  

  
  

GO
/****** Object:  StoredProcedure [global].[Get_CaseContactsByCaseID ]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Get_CaseContactsByCaseID ]
	@CaseID int
AS
	SET NOCOUNT ON
	SELECT distinct CaseContactID,CaseID,UserID,ISNUll(IsDeleted, 0) IsDeleted FROM global.CaseContacts WHERE CaseID = @CaseID
	RETURN


GO
/****** Object:  StoredProcedure [global].[Get_CaseCountByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================   
-- Latest Version : 1.1 
-- Author:  ftan    
-- Create date: 04-15-2013    
-- Description: Get number of cases by treatmentcategoryid  
-- Version : 1.0  
-- =============================================   

-- =============================================   
-- Author:  Pardeep Kumar    
-- Create date: 09-13-2013    
-- Description: Updated   "Case Completed" sub query
-- Version : 1.1  
-- =============================================    

 
CREATE PROCEDURE [global].[Get_CaseCountByTreatmentCategoryID]  
 -- Add the parameters for the stored procedure here    
 @TreatmentCategoryID INT    
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here    
 WITH Case_CTE(WorkflowID, TreatmentCategoryID, CaseReferrerDueDate)    
 AS    
 (     
  SELECT c.WorkflowID, rpt.TreatmentCategoryID, c.CaseReferrerDueDate    
  FROM  [global].[Cases] c     
  INNER JOIN  [referrer].ReferrerProjectTreatments rpt ON c.ReferrerProjectTreatmentID = rpt.ReferrerProjectTreatmentID    
  WHERE rpt.TreatmentCategoryID = @TreatmentCategoryID    
 )    
 SELECT     'Referrals' AS Description, COUNT(WorkflowID) AS CaseCount, 1 as Ordinal    
 FROM         Case_CTE    
 WHERE     (WorkflowID IN (10, 20, 30))    
 UNION    
 SELECT     'Triage Assessment QA' AS Description, COUNT(WorkflowID) AS CaseCount, 2 as Ordinal    
 FROM         Case_CTE    
 WHERE     WorkflowID = 65  
 UNION    
 SELECT     'Initial Assessment QA' AS Description, COUNT(WorkflowID) AS CaseCount, 3 as Ordinal    
 FROM         Case_CTE    
 WHERE     WorkflowID = 70    
 UNION    
 SELECT 'Authorisation' AS Description, COUNT(WorkflowID) AS CaseCount, 4 as Ordinal    
 FROM         Case_CTE    
 WHERE     WorkflowID = 100    
 UNION    
 SELECT 'Review Assessment QA' AS Description, COUNT(WorkflowID) AS CaseCount, 5 as Ordinal    
 FROM         Case_CTE    
 WHERE     WorkflowID = 130    
 UNION    
 SELECT 'Final Assessment QA' AS Description, COUNT(WorkflowID) AS CaseCount, 6 as Ordinal    
 FROM         Case_CTE    
 WHERE     WorkflowID = 160    
 UNION    
 SELECT 'Case Stopped' AS Description, COUNT(WorkflowID) AS CaseCount, 7 as Ordinal    
 FROM         Case_CTE    
 WHERE     WorkflowID = 200    
 
UNION
SELECT     'Case Completed' AS Description, COUNT(WorkflowID) AS CaseCount, 8 AS Ordinal
FROM         Case_CTE
WHERE     WorkflowID = 210
UNION
SELECT     'Referral Tasks Due Today' AS Description, COUNT(WorkflowID) AS CaseCount, 9 AS Ordinal
FROM         Case_CTE
WHERE     CaseReferrerDueDate = getdate()
 
 
 
END 

GO
/****** Object:  StoredProcedure [global].[Get_CaseCounts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<SATYA>
-- Create date: <04-16-2013>
-- Description:	Get Case Counts>
-- =============================================
CREATE PROCEDURE [global].[Get_CaseCounts]	


AS

 BEGIN

	SELECT *
	FROM [global].[CaseWorkflowCounts]
	
  END
	


GO
/****** Object:  StoredProcedure [global].[Get_CaseDocumentByCaseIDAndDocumentTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal Sen
-- Create date: 06-15-2013
-- Description:	get case document by caseID and Document type Id
-- =============================================
---[global].[Get_CaseDocumentByCaseIDAndDocumentTypeID] 
CREATE PROCEDURE [global].[Get_CaseDocumentByCaseIDAndDocumentTypeID] 
        @CaseID INT,
        @DocumentTypeID INT
		
AS
  
SELECT * FROM  [global].[CaseDocuments]
WHERE [CaseID]=@CaseID AND [DocumentTypeID]=@DocumentTypeID
           





GO
/****** Object:  StoredProcedure [global].[Get_CaseDocumentForReferrerUserByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--
  
-- =============================================  
-- Author : MMSINGH
-- Date :- 07-August-2018
-- [global].[Get_CaseDocumentForReferrerUserByCaseID]  2269
-- 1.3 Only show Documents that are checked in Internal Portal - Case Search - Patient Details - Case Uploads
-- =============================================  
CREATE PROCEDURE [global].[Get_CaseDocumentForReferrerUserByCaseID]  
        @CaseID INT  
    
AS  
SELECT         global.CaseDocuments.CaseID, global.CaseDocuments.DocumentTypeID,global.CaseDocuments.UploadDate,global.CaseDocuments.UploadPath, global.CaseDocuments.DocumentName, 
                         global.CaseDocuments.UserID, global.Users.FirstName, global.Users.LastName, global.Users.Username,
						 --c.CaseNumber, 
                         '' AS ReferrerDocumentTypeDesc,'' as ReferrerDocumentID
FROM            global.CaseDocuments INNER JOIN
                         global.Cases AS c ON c.CaseID = global.CaseDocuments.CaseID LEFT OUTER JOIN
                         global.Users ON global.CaseDocuments.UserID = global.Users.UserID
WHERE        (global.CaseDocuments.CaseID = @CaseID and global.CaseDocuments.ReferrerCheck = 1)

UNION ALL

SELECT     referrer.ReferrerDocuments.CaseID, referrer.ReferrerDocuments.DocumentTypeID,referrer.ReferrerDocuments.UploadDate,referrer.ReferrerDocuments.UploadPath,(referrer.ReferrerDocuments.DocumentName) AS DocumentName,
                 global.Users.UserID,global.Users.FirstName, global.Users.LastName, global.Users.Username, Rdt.ReferrerDocumentTypeDesc AS ReferrerDocumentTypeDesc, ReferrerDocumentID
FROM            referrer.ReferrerDocuments LEFT OUTER JOIN
                         global.Users ON referrer.ReferrerDocuments.UserID = global.Users.UserID 
						 INNER JOIN [lookup].[ReferrerDocumentType] Rdt On Rdt.ReferrerDocumentTypeID = referrer.ReferrerDocuments.ReferrerDocumentTypeID
						 INNER JOIN global.Cases AS c ON c.CaseID =  referrer.ReferrerDocuments.CaseID 
						 WHERE (referrer.ReferrerDocuments.CaseID = @CaseID and referrer.ReferrerDocuments.ReferrerCheck = 1)
             
  
  
  

GO
/****** Object:  StoredProcedure [global].[Get_CaseDocumentForSupplierUserByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--
  
-- =============================================  
-- Author		: TGosain
-- Date			:- 06-08-2018
-- Description	: To get document for case supplier where supplier check is set to true from internal portal.
-- =============================================  
CREATE PROCEDURE [global].[Get_CaseDocumentForSupplierUserByCaseID] 
        @CaseID INT  
AS  
SELECT         global.CaseDocuments.CaseID, global.CaseDocuments.DocumentTypeID,global.CaseDocuments.UploadDate,global.CaseDocuments.UploadPath, global.CaseDocuments.DocumentName, 
                         global.CaseDocuments.UserID, global.Users.FirstName, global.Users.LastName, global.Users.Username,
						 --c.CaseNumber, 
                         '' AS ReferrerDocumentTypeDesc
FROM            global.CaseDocuments INNER JOIN
                         global.Cases AS c ON c.CaseID = global.CaseDocuments.CaseID LEFT OUTER JOIN
                         global.Users ON global.CaseDocuments.UserID = global.Users.UserID
WHERE        (global.CaseDocuments.CaseID = @CaseID and global.CaseDocuments.SupplierCheck = 1)

union all

SELECT     referrer.ReferrerDocuments.CaseID, referrer.ReferrerDocuments.DocumentTypeID,referrer.ReferrerDocuments.UploadDate,referrer.ReferrerDocuments.UploadPath,(referrer.ReferrerDocuments.DocumentName) AS DocumentName,
                 global.Users.UserID,global.Users.FirstName, global.Users.LastName, global.Users.Username, Rdt.ReferrerDocumentTypeDesc AS ReferrerDocumentTypeDesc
FROM            referrer.ReferrerDocuments LEFT OUTER JOIN
                         global.Users ON referrer.ReferrerDocuments.UserID = global.Users.UserID 
						 INNER JOIN [lookup].[ReferrerDocumentType] Rdt On Rdt.ReferrerDocumentTypeID = referrer.ReferrerDocuments.ReferrerDocumentTypeID
						 INNER JOIN global.Cases AS c ON c.CaseID =  referrer.ReferrerDocuments.CaseID 
						 WHERE (referrer.ReferrerDocuments.CaseID = @CaseID and referrer.ReferrerDocuments.SupplierCheck = 1)
             
  
  
  

GO
/****** Object:  StoredProcedure [global].[Get_CaseDocumentUserByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--
  
-- =============================================  
-- Author:  Satya 
-- Create date: 09-19-2013  
-- Description: Get CaseDocumentUser By CaseID  
-- 1.1 :- ReferrreDocuments table Marged for getting the records by CaseID
-- Author : Jasingh
-- Date :- 28-05-2018
-- [global].[Get_CaseDocumentUserByCaseID]  4393
-- =============================================

-- =============================================
-- Author:		jasingh	/ rkumar
-- Create date: 16-08-2018
-- Description:	Update Case Document And referrer document by Case ID
-- [global].[Update_CaseAndReferrerDocumentByCaseID] 2269,7,'2018-08-06 13:36:11',0,0,0  

-- History
-- 1.2	:	01-24-2019	:	TGosain
--			Added new columns SupplierCheck and ReferrerCheck


CREATE PROCEDURE [global].[Get_CaseDocumentUserByCaseID] 
        @CaseID INT  
    
AS  
SELECT       global.CaseDocuments.CaseID, global.CaseDocuments.DocumentTypeID,global.CaseDocuments.UploadDate,global.CaseDocuments.UploadPath, global.CaseDocuments.DocumentName, 
                         global.CaseDocuments.UserID, global.Users.FirstName, global.Users.LastName, global.Users.Username,
						 --c.CaseNumber, 
                         dt.DocumentTypeName AS ReferrerDocumentTypeDesc, 0 as ReferrerDocumentID, global.CaseDocuments.CaseDocumentID,SupplierCheck,ReferrerCheck 
FROM            global.CaseDocuments INNER JOIN
                         global.Cases AS c ON c.CaseID = global.CaseDocuments.CaseID LEFT OUTER JOIN
                         global.Users ON global.CaseDocuments.UserID = global.Users.UserID
						 INNER JOIN [lookup].[DocumentTypes] dt on dt.DocumentTypeID = CaseDocuments.DocumentTypeID
WHERE        (global.CaseDocuments.CaseID = @CaseID)

UNION ALL

SELECT     referrer.ReferrerDocuments.CaseID, referrer.ReferrerDocuments.DocumentTypeID,referrer.ReferrerDocuments.UploadDate,referrer.ReferrerDocuments.UploadPath,(referrer.ReferrerDocuments.DocumentName) AS DocumentName,
                 global.Users.UserID,global.Users.FirstName, global.Users.LastName, global.Users.Username, Rdt.ReferrerDocumentTypeDesc AS ReferrerDocumentTypeDesc, ReferrerDocumentID , 0 as CaseDocumentID ,SupplierCheck,ReferrerCheck
FROM            referrer.ReferrerDocuments LEFT OUTER JOIN
                         global.Users ON referrer.ReferrerDocuments.UserID = global.Users.UserID 
						 INNER JOIN [lookup].[ReferrerDocumentType] Rdt On Rdt.ReferrerDocumentTypeID = referrer.ReferrerDocuments.ReferrerDocumentTypeID
						 INNER JOIN global.Cases AS c ON c.CaseID =  referrer.ReferrerDocuments.CaseID 
						 WHERE (referrer.ReferrerDocuments.CaseID = @CaseID )
             
  
  
  

GO
/****** Object:  StoredProcedure [global].[Get_CaseEmailContactsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh
-- Create date: 03-02-2020
-- Description:	Get case Email Contacts by Case ID
-- [global].[Get_CaseEmailContactsByCaseID] 6052
-- =============================================
CREATE PROCEDURE [global].[Get_CaseEmailContactsByCaseID]
	@CaseID int
AS
BEGIN
	SET NOCOUNT ON
	SELECT distinct CC.CaseContactID,CC.CaseID,CC.UserID,ISNULL(CC.IsDeleted, 0) as IsDeleted,U.Email, (U.FirstName + ' ' + U.LastName) as UserName
	  FROM global.CaseContacts CC
	INNER Join [global].[Users] U on U.UserID = CC.UserID
	 WHERE CaseID = @CaseID AND  (IsDeleted IS NULL OR  IsDeleted != 1) 
	RETURN

END

GO
/****** Object:  StoredProcedure [global].[Get_CaseHistories]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Get_CaseHistories]	
AS
	SELECT * FROM CaseHistory


GO
/****** Object:  StoredProcedure [global].[Get_CaseHistoriesByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Vishal sen>
-- Create date: <18-9-2013>
-- Description:	<Create SP to get Case Histories by CaseID >
-- =============================================
CREATE PROCEDURE [global].[Get_CaseHistoriesByCaseID] 
	-- Add the parameters for the stored procedure here
	@CaseID INT
AS
BEGIN
	
	SELECT [global].[CaseHistory].* ,[global].[Users].FirstName,[global].[Users].LastName ,[global].[Users].Username
 FROM  [global].[CaseHistory] 
inner join [global].[Users] on   
   [global].[CaseHistory].UserID = [global].[Users].UserID     
  where  [global].[CaseHistory].CaseID = @CaseID
	
	 
END


GO
/****** Object:  StoredProcedure [global].[Get_CaseInvoicePatientReferrer]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_CaseInvoicePatientReferrer]-- 0,4
@Skip int,    
@Take int         
AS         
    
    
Begin    
with PagedSearch as     
(    
SELECT       
  ROW_NUMBER() over (order by InvoiceID asc) as Row,  
	   [InvoiceNumber]
      ,[Amount] AS [InvoiceActualAmount]
      ,
      (
      
      SELECT SUM(InvoicePayment.Payment + InvoicePayment.AdjustedPayment) 
      FROM [global].[InvoicePayment] WHERE InvoicePayment.InvoiceID = [global].[CaseInvoicePatientReferrer].InvoiceID ) 
      AS [TotalAmountReceived]

      
      ,[CaseID]
      ,[CaseNumber]
      ,[FirstName]
      ,[LastName]
      ,[CaseReferrerReferenceNumber]
      ,[ReferrerContactFirstName]
      ,[ReferrerContactLastName]
      ,[ReferrerMainContactEmail]
      ,[InvoiceID]
      ,[PatientID]
      ,[ReferrerID] 
      ,[ReferrerMainContactPhone]
      FROM [global].[CaseInvoicePatientReferrer]      
 
)                   
    
SELECT prp.*,
      CASE WHEN (prp.InvoiceActualAmount - prp.TotalAmountReceived) IS NULL
    THEN prp.[InvoiceActualAmount]
    ELSE (prp.InvoiceActualAmount - prp.TotalAmountReceived) END AS [OutstandingAmount] 
FROM PagedSearch prp         
WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take      
    
End

GO
/****** Object:  StoredProcedure [global].[Get_CaseInvoicePatientReferrerByInvoiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_CaseInvoicePatientReferrerByInvoiceID]-- 0,4
@InvoiceID int    
AS         
    
    
Begin    
with PagedSearch as     
(    
SELECT       
  ROW_NUMBER() over (order by InvoiceID asc) as Row,  
	   [InvoiceNumber]
      ,[Amount] AS [InvoiceActualAmount]
      ,
      (
      
      SELECT SUM(InvoicePayment.Payment + InvoicePayment.AdjustedPayment) 
      FROM [global].[InvoicePayment] WHERE InvoicePayment.InvoiceID = [global].[CaseInvoicePatientReferrer].InvoiceID ) 
      AS [TotalAmountReceived]

      
      ,[CaseID]
      ,[CaseNumber]
      ,[FirstName]
      ,[LastName]
      ,[CaseReferrerReferenceNumber]
      ,[ReferrerContactFirstName]
      ,[ReferrerContactLastName]
      ,[ReferrerMainContactEmail]
      ,[InvoiceID]
      ,[PatientID]
      ,[ReferrerID] 
      ,[ReferrerMainContactPhone]
      FROM [global].[CaseInvoicePatientReferrer]      
 
)                   
    
SELECT prp.*,
      CASE WHEN (prp.InvoiceActualAmount - prp.TotalAmountReceived) IS NULL
    THEN prp.[InvoiceActualAmount]
    ELSE (prp.InvoiceActualAmount - prp.TotalAmountReceived) END AS [OutstandingAmount] 
FROM PagedSearch prp         
WHERE prp.InvoiceID = @InvoiceID 
    
End

GO
/****** Object:  StoredProcedure [global].[Get_CaseInvoicePatientReferrerCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_CaseInvoicePatientReferrerCount]            
AS             
        
        
Begin        
with PagedSearch as         
(        
SELECT       
  ROW_NUMBER() over (order by InvoiceID asc) as Row,  
	   [InvoiceNumber]
      ,[Amount] AS [InvoiceActualAmount]
      ,(SELECT SUM(InvoicePayment.Payment + InvoicePayment.AdjustedPayment) FROM [global].[InvoicePayment] WHERE InvoicePayment.InvoiceID = [global].[CaseInvoicePatientReferrer].InvoiceID ) AS [TotalAmountReceived]
      ,[CaseID]
      ,[CaseNumber]
      ,[FirstName]
      ,[LastName]
      ,[CaseReferrerReferenceNumber]
      ,[ReferrerContactFirstName]
      ,[ReferrerContactLastName]
      ,[ReferrerMainContactEmail]
      ,[InvoiceID]
      ,[PatientID]
      ,[ReferrerID]  
      FROM [global].[CaseInvoicePatientReferrer]           
)                       
        
SELECT COUNT(InvoiceID)'Count' FROM PagedSearch         
        
End

GO
/****** Object:  StoredProcedure [global].[Get_CaseNoteByCaseIDAndWorkflowID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 07-31-2018
-- Description:	get case note record for BookIA
-- =============================================
CREATE PROCEDURE [global].[Get_CaseNoteByCaseIDAndWorkflowID](@caseID int, @workflowID int)
AS
BEGIN	
	SET NOCOUNT ON;
	Select top 1 * from global.CaseNotes where CaseID = @caseID and WorkflowID = @workflowID order by CaseNoteID desc
END


GO
/****** Object:  StoredProcedure [global].[Get_CaseNotesByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--==============================================
-- Modified By: Vishal sen     
-- Create date: 17-Sept-2013      
-- Description: GEt Case Notes by Case ID.  
-- Version: 1.0
-- ============================================= 

--==============================================
-- Modified By: Rkumar
-- Create date: 07/19/2018
-- Description: #3316: Internal Portal - Case Search - Case Details - Case Notes - Update
-- Version: 1.0
-- ============================================= 


CREATE PROCEDURE [global].[Get_CaseNotesByCaseID]
(
@CaseID  INT
)
 AS 
BEGIN 

		SELECT			global.Users.FirstName, global.Users.LastName, global.Users.Username, 
						global.CaseNotes.CaseNoteID, global.CaseNotes.Note, global.CaseNotes.CaseID, 
						global.CaseNotes.UserID, global.CaseNotes.DateAdded, global.CaseNotes.WorkflowID, 
						lookup.Workflows.Definition AS WorkflowDefination
		FROM            global.CaseNotes INNER JOIN
						global.Users ON global.CaseNotes.UserID = global.Users.UserID LEFT OUTER JOIN
						lookup.Workflows ON global.CaseNotes.WorkflowID = lookup.Workflows.WorkflowID
		WHERE CaseID=@CaseID
 
END





                     
                      
                      

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientByCaseIDAndWorkflowID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Get_CasePatientByCaseIDAndWorkflowID]   
@CaseID INT,
@WorkflowID INT
AS    
SELECT 
[PatientID]
      ,[Title]
      ,[FirstName]
      ,[LastName]
      ,[Address]
      ,[PostCode]
      ,[InjuryDate]
      ,[BirthDate]
      ,[Email]
      ,[Gender]
      ,[CaseID]
      ,[CaseNumber]
      ,[HomePhone]
      ,[WorkPhone]
      ,[MobilePhone]
      ,CaseSubmittedDate
  FROM [global].[CasePatient]
  WHERE CaseID=@CaseID and WorkflowID=@WorkflowID 

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientLikeCaseNumber]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================     
-- Latest Version: 1.1  
-- Author:  Vikas Mahant     
-- Create date: 19-06-2013    
-- Description: <Get CasePatientLikeCaseNumber By CaseNumber>       
-- Version : 1.0       
-- 
-- Updated By:  Robin Singh    
-- Create date: 24-06-2013    
-- Description: <Update Get_CasePatientLikeCaseNumber to diplay CaseNumber(added new coloumn)>       
-- Version : 1.1       
-- =============================================      
      
CREATE PROCEDURE [global].[Get_CasePatientLikeCaseNumber] 
       
      
 @CaseNumber varchar(100)      
      
AS       
 BEGIN      
      
SELECT     global.Cases.CaseID, global.Patients.FirstName AS PatientFirstName, global.Patients.LastName AS [PatientLastName], global.Cases.CaseNumber    
FROM         global.Cases INNER JOIN   
                      global.Patients ON global.Cases.PatientID = global.Patients.PatientID      
WHERE  global.Cases.CaseNumber LIKE (@CaseNumber + '%')     
      
 END 

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientReferrerByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  <Satya>  
-- Create date: <09-19-2013>  
-- Description: <CasePatientReferrer By CaseID>  
-- =============================================  
CREATE PROCEDURE [global].[Get_CasePatientReferrerByCaseID] 
@CaseID INT
AS  

SELECT     global.Patients.FirstName, global.Patients.LastName, global.Patients.PatientID, global.Cases.CaseReferrerReferenceNumber, global.Cases.CaseNumber, 
                      global.Cases.CaseID, global.Cases.InvoiceDate, referrer.Referrers.ReferrerName, global.Cases.ReferrerID,referrer.ReferrerLocations.Address,
                      referrer.ReferrerLocations.Region,referrer.ReferrerLocations.City,referrer.ReferrerLocations.PostCode

                      
FROM         global.Cases INNER JOIN
                      global.Patients ON global.Cases.PatientID = global.Patients.PatientID AND global.Cases.PatientID = global.Patients.PatientID AND 
                      global.Cases.PatientID = global.Patients.PatientID INNER JOIN
                      referrer.Referrers ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID AND global.Cases.ReferrerID = referrer.Referrers.ReferrerID AND 
                      global.Cases.ReferrerID = referrer.Referrers.ReferrerID INNER JOIN
                      referrer.ReferrerLocations ON referrer.Referrers.ReferrerID = referrer.ReferrerLocations.ReferrerID AND 
                      referrer.Referrers.ReferrerID = referrer.ReferrerLocations.ReferrerID
WHERE     (referrer.ReferrerLocations.IsMainOffice = 1) AND (global.Cases.CaseID = @CaseID)

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientReferrerSupplierByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================   
-- Latest Version: 1.0
-- Author:  Satya   
-- Create date: 06-May-2013  
-- Description: <Get CasePatientReferrerSupplier By CaseID>     
-- Version : 1.0     
-- =============================================    
    
CREATE PROCEDURE [global].[Get_CasePatientReferrerSupplierByCaseID]      
    
 @CaseID INT    
    
AS     
 BEGIN    
    
SELECT [FirstName]
      ,[LastName]
       ,[Title]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostCode]
      ,[CaseNumber]
      ,[ReferrerName]
      ,[SupplierName]
      ,[SuppliersAddress]
      ,[SuppliersCity]
      ,[SuppliersRegion]
      ,[SuppliersPostCode]
      ,[Phone]
      ,[TreatmentTypeName]
       FROM [global].CasePatientReferrerSupplier    
WHERE CaseID = @CaseID    
    
 END 

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientReferrerSupplierWorkflowByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  
/*  
  
Latest Version : 1.0  
  
======================================================================  
Author      : Pardeep Kumar  
Date        : 19-Sep-2013  
Description : Get CaseParient and Referrer and Supplier workflow by CaseID  
Version     : 1.0  
  
======================================================================  
Modified by      : Vishal sen  
Date        : 17-Jan-2014  
Description : Modify SP Add PatientID for further use
Version     : 1.1  
  
======================================================================  
*/  
---- [global].[Get_CasePatientReferrerSupplierWorkflowByCaseID] 4667
CREATE PROCEDURE [global].[Get_CasePatientReferrerSupplierWorkflowByCaseID]   
(  
@CaseID bigint  
)  
as  
  
SELECT  global.CasePatient.FirstName, global.CasePatient.LastName, global.CasePatient.PostCode, global.CasePatient.InjuryDate, global.CasePatient.BirthDate, global.CasePatient.Email, global.CasePatient.Gender, global.CasePatient.CaseID, 
            global.CasePatient.CaseNumber, global.CasePatient.HomePhone, global.CasePatient.TreatmentTypeName, supplier.Suppliers.SupplierName, referrer.ReferrerProjects.ProjectName, supplier.Suppliers.Phone AS SupplierPhone, 
            lookup.Workflows.Definition AS [Current Status], referrer.Referrers.ReferrerName, global.CasePatient.CaseReferrerReferenceNumber, global.CasePatient.TreatmentCategoryName, global.CasePatient.TreatmentTypeID, global.CasePatient.WorkPhone, 
            global.CasePatient.MobilePhone, global.CasePatient.PatientID, global.CasePatient.Title, global.CasePatient.Address, global.CasePatient.City, global.CasePatient.Region, global.CasePatient.GenderID,
			ISNULL(global.CasePatient.CaseSpecialInstruction, '') AS SpecialInstructionNotes, global.Patients.HasLegalRep,
            global.Patients.SolicitorID
FROM    global.CasePatient INNER JOIN
            global.Cases ON global.CasePatient.CaseID = global.Cases.CaseID INNER JOIN
            referrer.ReferrerProjectTreatments ON global.Cases.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID INNER JOIN
            referrer.ReferrerProjects ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID left JOIN
            supplier.Suppliers ON global.CasePatient.SupplierID = supplier.Suppliers.SupplierID INNER JOIN
            lookup.Workflows ON global.Cases.WorkflowID = lookup.Workflows.WorkflowID AND global.Cases.WorkflowID = lookup.Workflows.WorkflowID INNER JOIN
            referrer.Referrers ON referrer.ReferrerProjects.ReferrerID = referrer.Referrers.ReferrerID INNER JOIN
            global.Patients ON global.Cases.PatientID = global.Patients.PatientID
WHERE  (global.CasePatient.CaseID = @CaseID)

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientSupplierPractitionerByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Latest Version 1.0
-- =============================================  
-- Author:  Satya 
-- Create date: 30-April-2013
-- Description: Added Procedure Get_CasePatientSupplierPractitionerByCaseID
-- Version : 1.0   
-- =============================================  
CREATE PROCEDURE [global].[Get_CasePatientSupplierPractitionerByCaseID]  
 -- Add the parameters for the stored procedure here  
   (@CaseID INT
    )  
AS  
BEGIN   
	SET NOCOUNT ON;

SELECT [FirstName]
      ,[LastName]
      ,[CaseReferrerReferenceNumber]
      ,[PostCode]
      ,[PractitionerFirstName]
      ,[PractitionerLastName]
      ,[CaseNumber]
      ,[BirthDate]
      ,[SupplierName]
      ,[Phone]
  FROM [global].[CasePatientSupplierPractitioner]
  WHERE [global].[CasePatientSupplierPractitioner].[CaseID]= @CaseID
     
END  


GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeCaseNumber]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like CaseNumber>    
-- =============================================    

--[global].[Get_CasePatientTreatmentWorkflowLikeCaseNumber] 'AllCases','%',0,14
--[global].[Get_CasePatientTreatmentWorkflowLikeCaseNumber] 'Active','%',0,14
--[global].[Get_CasePatientTreatmentWorkflowLikeCaseNumber] 'InActive','%',0,14

CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeCaseNumber] --'P',0,14
@AdditionalParam varchar(10),
@CaseNumber varchar(50),
 @Skip INT,        
 @Take INT   
AS    
BEGIN


  

if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseNumber LIKE  @CaseNumber + '%') 
	)tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseNumber LIKE  @CaseNumber + '%')  and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseNumber LIKE  @CaseNumber + '%')  and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
 

 
   

 


--SELECT * FROM UserMatched prp     
--WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take    
    
 END     

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeCaseNumberCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Satya>
-- Create date: <09-17-2013>
-- Description:	<Get CasePaitentTreatmentWorkflow Like CaseNumber Count >
-- Version	:	1.0	
-- ====================================================
 
--[global].[Get_CasePatientTreatmentWorkflowLikeCaseNumberCount] 'AllCases','%'
--[global].[Get_CasePatientTreatmentWorkflowLikeCaseNumberCount] 'Active','%'
--[global].[Get_CasePatientTreatmentWorkflowLikeCaseNumberCount] 'InActive','%'


CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeCaseNumberCount] --'p'
@AdditionalParam varchar(10),
@CaseNumber varchar(50)

AS 
BEGIN 
	if(ltrim(rtrim(@AdditionalParam))='AllCases')
	begin
		SELECT count(*) as 'count'
		FROM [global].[CasePatientTreatmentWorkflows]   
		WHERE     ( global.CasePatientTreatmentWorkflows.CaseNumber LIKE  @CaseNumber + '%') 
	end
	else if(ltrim(rtrim(@AdditionalParam))='Active')
	begin

		SELECT count(*) as 'count'
		FROM [global].[CasePatientTreatmentWorkflows]   
		WHERE     ( global.CasePatientTreatmentWorkflows.CaseNumber LIKE  @CaseNumber + '%')   and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	end
	else
	begin

		SELECT count(*) as 'count'
		FROM [global].[CasePatientTreatmentWorkflows]   
		WHERE     ( global.CasePatientTreatmentWorkflows.CaseNumber LIKE  @CaseNumber + '%')  and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	end
End

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like CaseReferrerReferenceNumber>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber] 
@AdditionalParam varchar(10),
@CaseReferrerReferenceNumber varchar(50),
 @Skip INT,        
 @Take INT   
AS    
BEGIN
   

if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseReferrerReferenceNumber LIKE  @CaseReferrerReferenceNumber + '%') )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseReferrerReferenceNumber LIKE  @CaseReferrerReferenceNumber + '%')  and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseReferrerReferenceNumber LIKE  @CaseReferrerReferenceNumber + '%')   and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end   
    
 END     













  

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like CaseReferrerReferenceNumber>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount] 
@AdditionalParam varchar(10),
@CaseReferrerReferenceNumber varchar(50) 
AS    
BEGIN
   

if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	SELECT count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseReferrerReferenceNumber LIKE  @CaseReferrerReferenceNumber + '%')
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	SELECT count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseReferrerReferenceNumber LIKE  @CaseReferrerReferenceNumber + '%')  and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	 
end
else
begin

	SELECT count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.CaseReferrerReferenceNumber LIKE  @CaseReferrerReferenceNumber + '%')   and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	  
end   
    
 END     













  

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikePatientName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like PatientName>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikePatientName] 
@AdditionalParam varchar(10),
@PatientName varchar(50),
 @Skip INT,        
 @Take INT   
AS    
BEGIN
  
  
if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     (( global.CasePatientTreatmentWorkflows.FirstName LIKE  @PatientName + '%') 
                      or (global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')
                      or (global.CasePatientTreatmentWorkflows.FirstName + ' '+ global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')   
  ) )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     (( global.CasePatientTreatmentWorkflows.FirstName LIKE  @PatientName + '%') 
                      or (global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')
                      or (global.CasePatientTreatmentWorkflows.FirstName + ' '+ global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')   
  ) and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     (( global.CasePatientTreatmentWorkflows.FirstName LIKE  @PatientName + '%') 
                      or (global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')
                      or (global.CasePatientTreatmentWorkflows.FirstName + ' '+ global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')   
  )  and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
  
  
    
 END          






GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikePatientNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like PatientName>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikePatientNameCount] 
@AdditionalParam varchar(10),
@PatientName varchar(50)  
AS    
BEGIN
  
  
if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	
	SELECT count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     (( global.CasePatientTreatmentWorkflows.FirstName LIKE  @PatientName + '%') 
                      or (global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')
                      or (global.CasePatientTreatmentWorkflows.FirstName + ' '+ global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')   
  ) 
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	SELECT count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     (( global.CasePatientTreatmentWorkflows.FirstName LIKE  @PatientName + '%') 
                      or (global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')
                      or (global.CasePatientTreatmentWorkflows.FirstName + ' '+ global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')   
  ) and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	
end
else
begin

	SELECT count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     (( global.CasePatientTreatmentWorkflows.FirstName LIKE  @PatientName + '%') 
                      or (global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')
                      or (global.CasePatientTreatmentWorkflows.FirstName + ' '+ global.CasePatientTreatmentWorkflows.LastName LIKE  @PatientName + '%')   
  )  and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	  
end
  
  
    
 END          






GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikePostCode]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like PostCode>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikePostCode] --'p',0,2
@AdditionalParam varchar(10),
 @PostCode varchar(50),
 @Skip INT,        
 @Take INT   
AS    
BEGIN

if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.PostCode LIKE  @PostCode + '%')  )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.PostCode LIKE  @PostCode + '%')   and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.PostCode LIKE  @PostCode + '%')   and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
 
 
 END     



 

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikePostCodeCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like PostCode>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikePostCodeCount] --'p',0,2
@AdditionalParam varchar(10),
 @PostCode varchar(50)  
AS    
BEGIN

if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.PostCode LIKE  @PostCode + '%')   
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.PostCode LIKE  @PostCode + '%')   and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	  
end
else
begin

	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.PostCode LIKE  @PostCode + '%')   and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	 
end
 
 
 END     



 

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeReferrerName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like ReferrerName>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeReferrerName] --'P',0,14
@AdditionalParam varchar(10),
@ReferrerName varchar(50),
 @Skip INT,        
 @Take INT   
AS    
BEGIN



if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.ReferrerName LIKE  @ReferrerName + '%')
	
	)tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.ReferrerName LIKE  @ReferrerName + '%')and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.ReferrerName LIKE  @ReferrerName + '%') and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
 

    
 END     




  

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeReferrerNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like ReferrerName>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeReferrerNameCount] --'P',0,14
@AdditionalParam varchar(10),
@ReferrerName varchar(50) 
AS    
BEGIN 
if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin
	select count(*) as 'count' 
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.ReferrerName LIKE  @ReferrerName + '%')
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin
	select count(*) as 'count' 
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.ReferrerName LIKE  @ReferrerName + '%')and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
end
else
begin
	select count(*) as 'count' 
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.ReferrerName LIKE  @ReferrerName + '%') and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
end
END     




  

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeTreatmentCategoryName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like TreatmentCategoryName>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeTreatmentCategoryName] 
 @AdditionalParam varchar(10),
 @TreatmentCategoryName varchar(50),
 @Skip INT,        
 @Take INT   
AS    
BEGIN


  

if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentCategoryName LIKE  @TreatmentCategoryName + '%') 
	)tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentCategoryName LIKE  @TreatmentCategoryName + '%')  and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentCategoryName LIKE  @TreatmentCategoryName + '%')and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
 



    
 END     





GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like TreatmentCategoryName>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount] 
 @AdditionalParam varchar(10),
 @TreatmentCategoryName varchar(50) 
AS    
BEGIN


  

if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentCategoryName LIKE  @TreatmentCategoryName + '%') 
	 
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentCategoryName LIKE  @TreatmentCategoryName + '%')  and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	  
end
else
begin

	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentCategoryName LIKE  @TreatmentCategoryName + '%')and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)

end
 



    
 END     





GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeTreatmentTypeName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like TreatmentTypeName>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeTreatmentTypeName] 
 @AdditionalParam varchar(10),
 @TreatmentTypeName varchar(50),
 @Skip INT,        
 @Take INT   
AS    
BEGIN
  
if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentTypeName LIKE  @TreatmentTypeName + '%')    
	)tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentTypeName LIKE  @TreatmentTypeName + '%')     and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
else
begin

	select * from (
	SELECT ROW_NUMBER() Over (Order By global.CasePatientTreatmentWorkflows.CaseID) As ROW,  *
	FROM [global].[CasePatientTreatmentWorkflows]   
	 WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentTypeName LIKE  @TreatmentTypeName + '%')     and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
	
	 )tbl  where row BETWEEN @Skip + 1 AND @Skip + @Take    
end
 

    
 END
 
 
 
   

GO
/****** Object:  StoredProcedure [global].[Get_CasePatientTreatmentWorkflowLikeTreatmentTypeNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Satya>    
-- Create date: <09-17-2013>    
-- Description: <Create the procedure to Get the Cases Like TreatmentTypeName>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CasePatientTreatmentWorkflowLikeTreatmentTypeNameCount] 
 @AdditionalParam varchar(10),
 @TreatmentTypeName varchar(50) 
AS    
BEGIN
if(ltrim(rtrim(@AdditionalParam))='AllCases')
begin
	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentTypeName LIKE  @TreatmentTypeName + '%')    
end
else if(ltrim(rtrim(@AdditionalParam))='Active')
begin
	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentTypeName LIKE  @TreatmentTypeName + '%')     and  global.CasePatientTreatmentWorkflows.WorkflowID  not in (210,212)
end
else
begin
	select count(*) as 'count'
	FROM [global].[CasePatientTreatmentWorkflows]   
	WHERE     ( global.CasePatientTreatmentWorkflows.TreatmentTypeName LIKE  @TreatmentTypeName + '%')     and  global.CasePatientTreatmentWorkflows.WorkflowID  in (210,212)
end
END
 
 
 
   

GO
/****** Object:  StoredProcedure [global].[Get_CaseReferralWorkflowPatientReferrerProjects]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================        
-- Author:  ftan        
-- Create date: 04-23-2013        
-- Description: get all cases that are currently in internal workflow(1,2,3,7,10,14,16,20)        
-- Updated By:  Robin Singh        
-- Create date: 06-04-2013        
-- Description: Added paging parameter skip and Take to get all cases that are currently in internal workflow(10,20,30,70,100,140,160,200)       
-- =============================================        
-- [global].[Get_CaseReferralWorkflowPatientReferrerProjects] 0,100
CREATE PROCEDURE [global].[Get_CaseReferralWorkflowPatientReferrerProjects]-- 0,100     
(      
@Skip INT,        
@Take INT         
)       
AS        
BEGIN        
      
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
 WITH PatientReferrerProjects AS        
 (        
  SELECT ROW_NUMBER() Over (Order By global.Cases.CaseID) As ROW, global.Cases.CaseID        
        
  FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID        
    INNER JOIN  referrer.ReferrerProjects         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID        
     INNER JOIN  referrer.Referrers         
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID        
     INNER JOIN  global.Patients        
    ON global.Cases.PatientID = global.Patients.PatientID        
    INNER JOIN  lookup.TreatmentTypes         
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID        
     LEFT JOIN  global.CaseAssessments         
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID        
    LEFT JOIN  lookup.[AssessmentAuthorisations]         
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID        
    WHERE Cases.WorkflowID IN (10,20,30)      
 )        
  SELECT    global.Cases.CaseID,global.Cases.PatientID,global.Cases.ReferrerID,global.Cases.CaseNumber,global.Patients.InjuryDate As CaseDateOfInquiry,global.Cases.ReferrerProjectTreatmentID,
  global.Cases.TreatmentTypeID,global.Cases.CaseReferrerReferenceNumber,global.Cases.CaseSpecialInstruction,global.Cases.CaseReferrerDueDate,global.Cases.CaseSubmittedDate,
  global.Cases.SupplierID,global.Cases.WorkflowID,lookup.TreatmentTypes.TreatmentTypeName,ISNULL(global.Cases.ReferrerProjectID,0) AS ReferrerProjectID,referrer.ReferrerProjects.ProjectName,referrer.Referrers.ReferrerName,
  global.Patients.FirstName, global.Patients.LastName,lookup.AssessmentAuthorisations.AssessmentAuthorisationName, global.Cases.IsTriage,global.Cases.IsTreatmentRequired   
  FROM  referrer.ReferrerProjectTreatments INNER JOIN  global.Cases         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID        
    INNER JOIN  referrer.ReferrerProjects         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID        
     INNER JOIN  referrer.Referrers         
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID        
     INNER JOIN  global.Patients        
    ON global.Cases.PatientID = global.Patients.PatientID        
    INNER JOIN  lookup.TreatmentTypes         
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID        
     LEFT JOIN  global.CaseAssessments         
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID        
    LEFT JOIN  lookup.[AssessmentAuthorisations]         
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID        
    INNER JOIN PatientReferrerProjects prp ON prp.CaseID =  global.Cases.CaseID        
    WHERE Cases.WorkflowID IN (10,20,30) AND prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take        
        
END 

GO
/****** Object:  StoredProcedure [global].[Get_CaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================        
-- Author:  ftan        
-- Create date: 04-23-2013        
-- Description: get all cases that are currently in the 'referral' workflow(10,20,30)      
-- Updated By:  Robin Singh        
-- Create date: 06-04-2013        
-- Description: Added Paging parameter to get all cases that are currently in internal workflow(10,20,30)          
-- =============================================        
CREATE PROCEDURE [global].[Get_CaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryID]
 @TreatmentCategoryID INT,      
 @Skip INT,        
 @Take INT          
AS        
BEGIN        
 -- SET NOCOUNT ON added to prevent extra result sets from        
 -- interfering with SELECT statements.        
 SET NOCOUNT ON;        
 WITH PatientReferrerProjects AS        
 (        
  SELECT ROW_NUMBER() Over (Order By global.Cases.CaseID) As ROW, global.Cases.CaseID        
  FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID        
    INNER JOIN  referrer.ReferrerProjects         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID        
     INNER JOIN  referrer.Referrers         
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID        
     INNER JOIN  global.Patients        
    ON global.Cases.PatientID = global.Patients.PatientID        
    INNER JOIN  lookup.TreatmentTypes         
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID        
      LEFT JOIN  global.CaseAssessments         
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID        
    LEFT JOIN  lookup.[AssessmentAuthorisations]         
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID        
              WHERE Cases.WorkflowID IN (10,20,30) AND referrer.ReferrerProjectTreatments.TreatmentCategoryID = @TreatmentCategoryID        
 )        
    -- Insert statements for procedure here        
 SELECT     global.Cases.*,lookup.TreatmentTypes.TreatmentTypeName, referrer.ReferrerProjects.ReferrerProjectID,        
     referrer.ReferrerProjects.ProjectName,global.Cases.IsTriage,referrer.Referrers.ReferrerName,global.Patients.FirstName, global.Patients.LastName        
      ,lookup.AssessmentAuthorisations.AssessmentAuthorisationName,prp.ROW        
 FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID        
    INNER JOIN  referrer.ReferrerProjects         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID        
     INNER JOIN  referrer.Referrers         
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID        
     INNER JOIN  global.Patients        
    ON global.Cases.PatientID = global.Patients.PatientID        
    INNER JOIN  lookup.TreatmentTypes         
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID        
      LEFT JOIN  global.CaseAssessments         
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID        
    LEFT JOIN  lookup.[AssessmentAuthorisations]         
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID        
    INNER JOIN PatientReferrerProjects prp ON prp.CaseID =  global.Cases.CaseID        
              WHERE Cases.WorkflowID IN (10,20,30) AND referrer.ReferrerProjectTreatments.TreatmentCategoryID = @TreatmentCategoryID        
              AND prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take        
        
END 

GO
/****** Object:  StoredProcedure [global].[Get_CaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCounts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Robin Singh  
-- Create date: 06-04-2013  
-- Description: count all cases that are currently in internal workflow(10,20,30)  
-- =============================================  
CREATE PROCEDURE [global].[Get_CaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCounts] 
 @TreatmentCategoryID INT 
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
    -- Insert statements for procedure here  
 SELECT  COUNT(*) as [Count]
  FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases   
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID  
    INNER JOIN  referrer.ReferrerProjects   
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID  
     INNER JOIN  referrer.Referrers   
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID  
     INNER JOIN  global.Patients  
    ON global.Cases.PatientID = global.Patients.PatientID  
    INNER JOIN  lookup.TreatmentTypes   
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID  
      LEFT JOIN  global.CaseAssessments   
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID  
    LEFT JOIN  lookup.[AssessmentAuthorisations]   
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID  
   
              WHERE Cases.WorkflowID IN (10,20,30) AND referrer.ReferrerProjectTreatments.TreatmentCategoryID = @TreatmentCategoryID 
  
END  

GO
/****** Object:  StoredProcedure [global].[Get_CaseReferralWorkflowPatientReferrerProjectsCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Robin Singh  
-- Create date: 06-04-2013  
-- Description: count all cases that are currently in internal workflow(10,20,30,70,100,140,160,200)  
-- =============================================  
CREATE PROCEDURE [global].[Get_CaseReferralWorkflowPatientReferrerProjectsCount] 
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
      -- Insert statements for procedure here  
 SELECT count(*) as [Count]
    FROM   referrer.ReferrerProjectTreatments INNER JOIN  global.Cases   
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID  
    INNER JOIN  referrer.ReferrerProjects   
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID  
     INNER JOIN  referrer.Referrers   
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID  
     INNER JOIN  global.Patients  
    ON global.Cases.PatientID = global.Patients.PatientID  
    INNER JOIN  lookup.TreatmentTypes   
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID  
     LEFT JOIN  global.CaseAssessments   
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID  
    LEFT JOIN  lookup.[AssessmentAuthorisations] 
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID  
 WHERE Cases.WorkflowID IN (10,20,30)  
END  

GO
/****** Object:  StoredProcedure [global].[Get_CaseReferrerAssignedUsersByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 02-05-2019
-- Description:	To get case referrer assigned user by caseID
-- =============================================
CREATE PROCEDURE [global].[Get_CaseReferrerAssignedUsersByCaseID](@CaseID int)
AS
BEGIN
	SET NOCOUNT ON;	
	Select cr.CaseReferrerAssignedUserID, cr.UserID
	,cr.UserID, u.FirstName + ' ' + u.LastName as UserName 
	from global.CaseReferrerAssignedUsers cr
	Inner Join global.Users u on cr.UserID = u.UserID
	where CaseID = @CaseID and cr.status=1
END

GO
/****** Object:  StoredProcedure [global].[Get_CasesByWorkFlowID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <Vishal sen>  
-- Create date: <04-12-2013>  
-- Description: <Create the sp to Get Cases By WorkflowID>  
-- =============================================  
   
CREATE PROCEDURE [global].[Get_CasesByWorkFlowID]  
(  
@WorkflowID INT

)  
as  
select * from global.Cases where WorkflowID = @WorkflowID

GO
/****** Object:  StoredProcedure [global].[Get_CaseSearchLikePatientName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  <Vishal Sen>    
-- Create date: <05-09-2013>    
-- Description: <Create the procedure to Get the Cases Like PatientName ,>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CaseSearchLikePatientName] 
@PatientName varchar(50)    
AS    
SELECT 

[PatientID]
  
      ,[FirstName]
      ,[LastName]
    ,[CaseSubmittedDate]
      ,[PostCode]   
      ,[CaseID]
      ,[CaseNumber]    
      ,[WorkflowID] 
      ,[CaseReferrerReferenceNumber]    
  FROM [global].[CasePatient]  
               WHERE     (( global.CasePatient.FirstName LIKE  @PatientName + '%') 
                      or (global.CasePatient.LastName LIKE  @PatientName + '%')
                      or (global.CasePatient.FirstName + ' '+ global.CasePatient.LastName LIKE  @PatientName + '%')
                       )    and global.CasePatient.WorkflowID in (70,180,190)           
        


GO
/****** Object:  StoredProcedure [global].[Get_CaseSearchLikeReferrerReferenceNumber]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  <Vishal Sen>    
-- Create date: <05-09-2013>    
-- Description: <Create the procedure to Get the Cases Get_CaseSearchLikeReferrerReferenceNumber ,>    
-- =============================================    
CREATE PROCEDURE [global].[Get_CaseSearchLikeReferrerReferenceNumber]
@ReferrerReferenceNumber varchar(50)    
AS    
SELECT 

		[PatientID] 
		,[CaseSubmittedDate]
      ,[FirstName]
      ,[LastName]    
      ,[PostCode]   
      ,[CaseID]
      ,[CaseNumber]    
      ,[WorkflowID] 
      ,[CaseReferrerReferenceNumber]    
  FROM [global].[CasePatient]  
             
  WHERE ( global.CasePatient.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%') and global.CasePatient.WorkflowID in (70,180,190)
                   
                                
        


GO
/****** Object:  StoredProcedure [global].[Get_CaseTreatmentPricingByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal Sen
-- Create date: 05-29-2013
-- Description:	GET CaseTreatmentPricing by case ID
-- =============================================
-- =============================================
-- Author:		Mahinder Singh
-- Updated date: 03-03-2015
-- Description:	GET CaseTreatmentPricing by case ID And IsDeleted = 0
-- =============================================
--- [global].[Get_CaseTreatmentPricingByCaseID] 1046
CREATE PROCEDURE [global].[Get_CaseTreatmentPricingByCaseID]  
@CaseID INT  
AS  
SELECT CaseTreatmentPricingID,CaseID,ReferrerPricingID,ReferrerPrice,DateOfService,PatientDidNotAttend,WasAbandoned,SupplierPrice,PatientDidNotAttendDate,
		  ISNULL(Quantity,0) as Quantity,SupplierPriceID,IsComplete,AuthorizationStatus,IsDeleted, 0 as IsChanged
		  FROM [global].[CaseTreatmentPricing]
		  WHERE CaseID=@CaseID  and IsDeleted =0




GO
/****** Object:  StoredProcedure [global].[Get_CaseTreatmentPricingByCaseIDAndIsComplete]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  Satya    
-- Create date: 08-13-2013    
-- Description: GET CaseTreatmentPricing By CaseIDA nd IsComplete    
-- ============================================= 
-- =============================================    
-- Author:  Mahinder Singh    
-- Create date: 03-04-2015    
-- Description: GET CaseTreatmentPricing By CaseIDA nd IsComplete nd Isdelete   
-- =============================================    

-- =============================================    
-- Author:  Rkumar    
-- Create date: 08-10-2018
-- Description: #3357 - Supplier Portal - RA / FA - Treatment Matrix Display
-- =============================================    

 -- [global].[Get_CaseTreatmentPricingByCaseIDAndIsComplete]       4393,2
    
CREATE PROCEDURE [global].[Get_CaseTreatmentPricingByCaseIDAndIsComplete]      
@CaseID INT,  
@IsComplete BIT  
  
AS      
-- declare @CaseID as int= 822
--declare @DateOfService as datetime
--set @DateOfService = (SELECT     convert(date,AppointmentDateTime) FROM         global.CaseAppointmentDates where CaseID =@CaseID)
--select @DateOfService

SELECT     global.CaseTreatmentPricing.CaseTreatmentPricingID, global.CaseTreatmentPricing.CaseID, global.CaseTreatmentPricing.ReferrerPricingID, 
                      global.CaseTreatmentPricing.ReferrerPrice, --(case when supplier.SupplierTreatmentPricing.PricingTypeID = 1 then  @DateOfService                           else global.CaseTreatmentPricing.DateOfService end ) as DateOfService, 
						   global.CaseTreatmentPricing.DateOfService as DateOfService, 
						   global.CaseTreatmentPricing.PatientDidNotAttendDate as PatientDidNotAttendDate,
						   global.CaseTreatmentPricing.PatientDidNotAttend, 
                      global.CaseTreatmentPricing.WasAbandoned, global.CaseTreatmentPricing.SupplierPrice, global.CaseTreatmentPricing.SupplierPriceID, 
                      global.CaseTreatmentPricing.IsComplete, global.CaseTreatmentPricing.AuthorizationStatus, lookup.PricingTypes.PricingTypeName
FROM         global.CaseTreatmentPricing INNER JOIN
                      supplier.SupplierTreatmentPricing ON global.CaseTreatmentPricing.SupplierPriceID = supplier.SupplierTreatmentPricing.PricingID AND 
                      global.CaseTreatmentPricing.SupplierPriceID = supplier.SupplierTreatmentPricing.PricingID AND 
                      global.CaseTreatmentPricing.SupplierPriceID = supplier.SupplierTreatmentPricing.PricingID INNER JOIN
                      lookup.PricingTypes ON supplier.SupplierTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID
WHERE     (global.CaseTreatmentPricing.CaseID = @CaseID) AND (global.CaseTreatmentPricing.IsDeleted =0) 


--AND (global.CaseTreatmentPricing.IsComplete = @IsComplete) 
    

GO
/****** Object:  StoredProcedure [global].[Get_CaseTreatmentPricingByCaseIDCaseSearch]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Get_CaseTreatmentPricingByCaseIDCaseSearch]      
@CaseID INT 
  
AS      

declare @AppointmentDateTime as date

set @AppointmentDateTime = (SELECT  Top 1   AppointmentDateTime  FROM global.CaseAppointmentDates where CaseID = @CaseID)

SELECT global.CaseTreatmentPricing.CaseTreatmentPricingID, global.CaseTreatmentPricing.CaseID, global.CaseTreatmentPricing.ReferrerPricingID, 
                      global.CaseTreatmentPricing.ReferrerPrice, 
                      
                      (case when lookup.PricingTypes.PricingTypeID = 1 then @AppointmentDateTime else  global.CaseTreatmentPricing.DateOfService end) as DateOfService, global.CaseTreatmentPricing.PatientDidNotAttend, 
                      global.CaseTreatmentPricing.WasAbandoned, global.CaseTreatmentPricing.SupplierPrice, global.CaseTreatmentPricing.SupplierPriceID, 
                      global.CaseTreatmentPricing.IsComplete,global.CaseTreatmentPricing.PatientDidNotAttendDate, global.CaseTreatmentPricing.AuthorizationStatus, lookup.PricingTypes.PricingTypeName 
FROM         global.CaseTreatmentPricing INNER JOIN
                      supplier.SupplierTreatmentPricing ON global.CaseTreatmentPricing.SupplierPriceID = supplier.SupplierTreatmentPricing.PricingID AND 
global.CaseTreatmentPricing.SupplierPriceID = supplier.SupplierTreatmentPricing.PricingID AND 
                      global.CaseTreatmentPricing.SupplierPriceID = supplier.SupplierTreatmentPricing.PricingID INNER JOIN
                      lookup.PricingTypes ON supplier.SupplierTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID  INNER JOIN
                       global.Cases ON global.CaseTreatmentPricing.CaseID = global.Cases.CaseID  
  WHERE global.CaseTreatmentPricing.CaseID=@CaseID  and global.Cases.WorkflowID >=90
GO
/****** Object:  StoredProcedure [global].[Get_CaseVATByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  Vishal sen  
-- Create date: 23/10/2013  
-- Description: Get_CaseVATByCaseID
-- =============================================  

CREATE PROCEDURE [global].[Get_CaseVATByCaseID]  
 @CaseID INT  
AS  
BEGIN    
 
 SELECT *
      FROM [global].[CaseVAT]  
      WHERE [CaseID] = @CaseID  
END  

GO
/****** Object:  StoredProcedure [global].[Get_CaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--sp_helptext [global.Get_CaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID]    
      
-- =============================================          
-- Author:  <Satya>          
-- Create date: <16-12-2013>          
-- Description: <Create the sp to Get CaseWorkflowPatientReferrerProject By WorkflowID And TreatmentCategoryID>        
--      
-- Updated By:  <Robin Singh>          
-- Create date: <06-04-2013>          
-- Description: <Added paging parameter in sp to Get CaseWorkflowPatientReferrerProject By WorkflowID And TreatmentCategoryID>         
-- =============================================          
           
           
CREATE PROCEDURE [global].[Get_CaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID]      
(          
@WorkflowID INT,        
@TreatmentCategoryID INT ,      
@Skip INT,        
@Take INT        
)          
as        
WITH PatientReferrerProjects AS        
 (        
  SELECT ROW_NUMBER() Over (Order By global.Cases.CaseID) As ROW,global.Cases.CaseID        
  FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID        
    INNER JOIN  referrer.ReferrerProjects         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID        
     INNER JOIN  referrer.Referrers         
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID        
     INNER JOIN  global.Patients        
    ON global.Cases.PatientID = global.Patients.PatientID        
    INNER JOIN  lookup.TreatmentTypes         
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID        
      LEFT JOIN  global.CaseAssessments         
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID        
    LEFT JOIN  lookup.[AssessmentAuthorisations]         
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID      
              WHERE Cases.WorkflowID = @WorkflowID AND ReferrerProjectTreatments.TreatmentCategoryID = @TreatmentCategoryID      
 )          
SELECT     global.Cases.*,lookup.TreatmentTypes.TreatmentTypeName, referrer.ReferrerProjects.ReferrerProjectID,        
     referrer.ReferrerProjects.ProjectName,global.Cases.IsTriage,referrer.ReferrerProjects.IsTriage,referrer.Referrers.ReferrerName,global.Patients.FirstName, global.Patients.LastName        
     ,lookup.AssessmentAuthorisations.AssessmentAuthorisationName,prp.ROW        
FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID        
    INNER JOIN  referrer.ReferrerProjects         
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID        
     INNER JOIN  referrer.Referrers         
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID        
     INNER JOIN  global.Patients        
    ON global.Cases.PatientID = global.Patients.PatientID        
    INNER JOIN  lookup.TreatmentTypes         
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID        
      LEFT JOIN  global.CaseAssessments         
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID        
    LEFT JOIN  lookup.[AssessmentAuthorisations]         
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID      
    INNER JOIN PatientReferrerProjects prp ON prp.CaseID =  global.Cases.CaseID          
              WHERE Cases.WorkflowID = @WorkflowID AND ReferrerProjectTreatments.TreatmentCategoryID = @TreatmentCategoryID      
              AND prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take 

GO
/****** Object:  StoredProcedure [global].[Get_CaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCounts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

     
CREATE PROCEDURE [global].[Get_CaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCounts]    
(    
@WorkflowID INT,  
@TreatmentCategoryID INT 
)    
as  
SELECT    COUNT(*) as [count]
FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases   
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID  
    INNER JOIN  referrer.ReferrerProjects   
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID  
     INNER JOIN  referrer.Referrers   
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID  
     INNER JOIN  global.Patients  
    ON global.Cases.PatientID = global.Patients.PatientID  
    INNER JOIN  lookup.TreatmentTypes   
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID  
      LEFT JOIN  global.CaseAssessments   
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID  
    LEFT JOIN  lookup.[AssessmentAuthorisations]   
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID
              WHERE Cases.WorkflowID = @WorkflowID AND ReferrerProjectTreatments.TreatmentCategoryID = @TreatmentCategoryID
              

GO
/****** Object:  StoredProcedure [global].[Get_CaseWorkflowPatientReferrerProjectsByWorkflowID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================      
-- Author:  ftan      
-- Create date: 04-23-2013      
-- Description: Get CaseWorkflowPatientReferrerProject By WorkflowID    
-- =============================================      
       
---[global].[Get_CaseWorkflowPatientReferrerProjectsByWorkflowID] 10,20,30      
CREATE PROCEDURE [global].[Get_CaseWorkflowPatientReferrerProjectsByWorkflowID] --130,132,0,112   
(      
@WorkflowID varchar(50), 
--@WorkflowIDCustom INT, 
@Skip INT,    
@Take INT     
)      
as     

 
WITH PatientReferrerProjects AS    
 (    
  SELECT ROW_NUMBER() Over (Order By global.Cases.CaseID) As ROW, global.Cases.CaseID   
  FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases     
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID    
    INNER JOIN  referrer.ReferrerProjects     
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID    
     INNER JOIN  referrer.Referrers     
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID    
     INNER JOIN  global.Patients    
    ON global.Cases.PatientID = global.Patients.PatientID    
    INNER JOIN  lookup.TreatmentTypes     
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID    
     LEFT JOIN  global.CaseAssessments     
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID    
    LEFT JOIN  lookup.[AssessmentAuthorisations]     
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID    
              WHERE Cases.WorkflowID in (SELECT Value FROM   global.String_to_int_table(@WorkflowID, ',') )   
              
	                
 )       
SELECT    global.Cases.CaseID,global.Cases.PatientID,global.Cases.ReferrerID,global.Cases.CaseNumber,global.Patients.InjuryDate As CaseDateOfInquiry,global.Cases.ReferrerProjectTreatmentID,
  global.Cases.TreatmentTypeID,global.Cases.CaseReferrerReferenceNumber,global.Cases.CaseSpecialInstruction,global.Cases.CaseReferrerDueDate,global.Cases.CaseSubmittedDate,
  global.Cases.SupplierID,global.Cases.WorkflowID,lookup.TreatmentTypes.TreatmentTypeName,ISNULL(global.Cases.ReferrerProjectID,0) AS ReferrerProjectID,referrer.ReferrerProjects.ProjectName,referrer.Referrers.ReferrerName,
  global.Patients.FirstName, global.Patients.LastName,lookup.AssessmentAuthorisations.AssessmentAuthorisationName, global.Cases.IsTriage,global.Cases.IsTreatmentRequired     
FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases     
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID    
    INNER JOIN  referrer.ReferrerProjects     
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID    
     INNER JOIN  referrer.Referrers     
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID    
     INNER JOIN  global.Patients    
    ON global.Cases.PatientID = global.Patients.PatientID    
    INNER JOIN  lookup.TreatmentTypes     
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID    
     LEFT JOIN  global.CaseAssessments     
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID    
    LEFT JOIN  lookup.[AssessmentAuthorisations]     
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID    
    INNER JOIN PatientReferrerProjects prp ON prp.CaseID =  global.Cases.CaseID      
              WHERE Cases.WorkflowID in (SELECT Value FROM   global.String_to_int_table(@WorkflowID, ',') )  
              AND prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take 
              
 
              
             
              

GO
/****** Object:  StoredProcedure [global].[Get_CaseWorkflowPatientReferrerProjectsByWorkflowIDCounts]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_CaseWorkflowPatientReferrerProjectsByWorkflowIDCounts] 
(    
@WorkflowID varchar(100)
)    
as   
SELECT COUNT(*) as [Count]   
FROM         referrer.ReferrerProjectTreatments INNER JOIN  global.Cases   
    ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID  
    INNER JOIN  referrer.ReferrerProjects   
    ON referrer.ReferrerProjectTreatments.ReferrerProjectID = referrer.ReferrerProjects.ReferrerProjectID  
     INNER JOIN  referrer.Referrers   
    ON global.Cases.ReferrerID = referrer.Referrers.ReferrerID  
     INNER JOIN  global.Patients  
    ON global.Cases.PatientID = global.Patients.PatientID  
    INNER JOIN  lookup.TreatmentTypes   
    ON lookup.TreatmentTypes.TreatmentTypeID = global.Cases.TreatmentTypeID  
     LEFT JOIN  global.CaseAssessments   
    ON global.CaseAssessments.CaseID  = global.Cases.CaseID  
    LEFT JOIN  lookup.[AssessmentAuthorisations]   
    ON lookup.AssessmentAuthorisations.AssessmentAuthorisationID  = global.CaseAssessments.AssessmentAuthorisationID  
              WHERE Cases.WorkflowID in (SELECT Value FROM   global.String_to_int_table(@WorkflowID, ',') )  

GO
/****** Object:  StoredProcedure [global].[Get_CheckCaseTreatmentPricingByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rohit Kumar
-- Create date: 01-20-2015
-- Description:	GET Check Case Treatment Pricing by case ID
-- =============================================

CREATE PROCEDURE [global].[Get_CheckCaseTreatmentPricingByCaseID]  
@CaseID INT  ,
@AssessmentServiceID int
AS  

begin
	--declare @CaseId as int = 806
			declare @ReferrerProjectTreatmentID as int = 0
			declare @TreatmentPricing as decimal(18,2)=0
			declare @DelegatedAuthorisationCostPrice as decimal(18,2)=0
			
	if(@AssessmentServiceID=1)
		begin
			

				Set @ReferrerProjectTreatmentID = (SELECT     ReferrerProjectTreatmentID FROM         global.Cases where CaseID = @CaseId)
				
			

					Set @TreatmentPricing = (select sum(Price) from (SELECT     referrer.ReferrerProjectTreatmentPricing.Price as Price 
											FROM         referrer.ReferrerProjectTreatmentPricing INNER JOIN
											lookup.PricingTypes ON referrer.ReferrerProjectTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID
											where referrer.ReferrerProjectTreatmentPricing.ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID and 
											referrer.ReferrerProjectTreatmentPricing.PricingTypeID in (1)
										union
											SELECT sum([SupplierPrice]) as Price
											FROM  [global].[CaseTreatmentPricing]
											where [CaseID] = @CaseId) tbl)

				SELECT    @DelegatedAuthorisationCostPrice =  isnull(Amount,0)  
				FROM         referrer.ReferrerProjectTreatmentAuthorisations
				WHERE     (ReferrerProjectTreatmentID IN (@ReferrerProjectTreatmentID)) AND (DelegatedAuthorisationTypeID IN (2))  

			  if (@TreatmentPricing >= @DelegatedAuthorisationCostPrice)
				  begin
					-- Now we can go for Authorisation 
					Select 1 as IsAuthorisation 
				  end
			  else
				  begin
					-- No Authorisation	
					select 0 as IsAuthorisation
				  end
		  
		end
	else
		begin
				Set @ReferrerProjectTreatmentID = (SELECT     ReferrerProjectTreatmentID FROM         global.Cases where CaseID = @CaseId)
					Set @TreatmentPricing = (select sum(Price) from (SELECT     SUM(referrer.ReferrerProjectTreatmentPricing.Price) as Price 
											FROM         referrer.ReferrerProjectTreatmentPricing INNER JOIN
											lookup.PricingTypes ON referrer.ReferrerProjectTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID
											where referrer.ReferrerProjectTreatmentPricing.ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID and 
											referrer.ReferrerProjectTreatmentPricing.PricingTypeID in (2,5,6)
										union
											SELECT sum([SupplierPrice]) as Price
											FROM  [global].[CaseTreatmentPricing]
											where [CaseID] = @CaseId) tbl)
				 
				SELECT    @DelegatedAuthorisationCostPrice =  isnull(Amount,0)  
				FROM         referrer.ReferrerProjectTreatmentAuthorisations
				WHERE     (ReferrerProjectTreatmentID IN (@ReferrerProjectTreatmentID)) AND (DelegatedAuthorisationTypeID IN (2))  

			  if (@TreatmentPricing >= @DelegatedAuthorisationCostPrice)
				  begin
					-- Now we can go for Authorisation 
					Select 1 as IsAuthorisation 
				  end
			  else
				  begin
					-- No Authorisation	
					select 0 as IsAuthorisation
				  end
		  
		end
		 
	
	   




 end
	




GO
/****** Object:  StoredProcedure [global].[Get_DrugTestByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tarun Gosain
-- Create date: 03-21-2019
-- Description:	Update Drug Test table
-- =============================================
Create PROCEDURE [global].[Get_DrugTestByCaseID] (@CaseID int)
AS
BEGIN	
	SET NOCOUNT ON;
	Select * from global.DrugTests 	
	where DrugTestID = (Select DrugTestID from global.Cases where CaseID = @CaseID)
END

GO
/****** Object:  StoredProcedure [global].[Get_EmploymentByEmploymentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 09-28-2018
-- Description:	Get Employment Details
-- =============================================
CREATE PROCEDURE [global].[Get_EmploymentByEmploymentID](@EmploymentID int)
AS
BEGIN
	SET NOCOUNT ON;
	select * from global.Employments
	where EmploymentId = @EmploymentID
END

GO
/****** Object:  StoredProcedure [global].[Get_EPNATreatmentSessionDetail]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,RKumar>
-- Create date: <Create Date,11-May-2018>
-- Description:	<Description,>
-- =============================================

-- [global].[Get_EPNATreatmentSessionDetail] 1046

CREATE PROCEDURE [global].[Get_EPNATreatmentSessionDetail]  
@CaseID INT    
AS    
BEGIN    
	SET NOCOUNT ON;
	select 
	(SELECT count(*) FROM global.CaseTreatmentPricing  WHERE CaseID = @CaseID and isnull(AuthorizationStatus,0)=1) as SessionsAuthorised ,
	(SELECT count(*) FROM global.CaseTreatmentPricing  WHERE CaseID = @CaseID and isnull(PatientDidNotAttend,0)=1) as SessionsAttended
END 


 











GO
/****** Object:  StoredProcedure [global].[Get_EvaluateDelegatedAuthorisationCost]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Latest Version 1.0
-- Author:  RKumar    
-- Create date: 06/22/2018    
-- Description: Get_EvaluateDelegatedAuthorisationCost
-- Version: 1.0     
-- =============================================    
-- [global].[Get_EvaluateDelegatedAuthorisationCost] 4445,1
CREATE PROCEDURE [global].[Get_EvaluateDelegatedAuthorisationCost] 
 (
 @CaseID int,
 @AssessmentTypeID int
 )   
AS    
BEGIN     

	Declare @Cost as decimal(18,2)
	Declare @Session as decimal(18,2)
	Declare @price as decimal(18,2)
	declare @TreatmentSession as int
	if(@AssessmentTypeID=1)
		begin
			set @TreatmentSession = (SELECT        sum(isnull(PatientRecommendedTreatmentSessions,0))  FROM            global.CaseAssessmentDetail where CaseID = @CaseID and AssessmentServiceID = @AssessmentTypeID)
		end
	else 
		begin
			set @TreatmentSession = (SELECT        sum(isnull(PatientRecommendedTreatmentSessions,0))  FROM            global.CaseAssessmentDetail where CaseID = @CaseID and AssessmentServiceID = @AssessmentTypeID)
		end

	set @Cost =		(Select	isnull(referrer.referrerprojecttreatmentauthorisations.amount,0)
					from	referrer.referrerprojecttreatmentauthorisations inner join
							global.cases on referrer.referrerprojecttreatmentauthorisations.referrerprojecttreatmentid = global.cases.referrerprojecttreatmentid
					where	global.cases.caseid = @CaseID and referrer.referrerprojecttreatmentauthorisations.delegatedauthorisationtypeid = 2)

	set @Session =		(Select	isnull(referrer.referrerprojecttreatmentauthorisations.amount,0)
					from	referrer.referrerprojecttreatmentauthorisations inner join
							global.cases on referrer.referrerprojecttreatmentauthorisations.referrerprojecttreatmentid = global.cases.referrerprojecttreatmentid
					where	global.cases.caseid = @CaseID and referrer.referrerprojecttreatmentauthorisations.delegatedauthorisationtypeid = 1)

	
	--if(@AssessmentTypeID=1)
	--begin
	--	Set @Price = (Select	sum(isnull(referrer.referrerprojecttreatmentpricing.price,0))
	--					from    referrer.referrerprojecttreatmentpricing inner join
	--							global.cases on referrer.referrerprojecttreatmentpricing.referrerprojecttreatmentid = global.cases.referrerprojecttreatmentid inner join
	--							lookup.pricingtypes on referrer.referrerprojecttreatmentpricing.pricingtypeid = lookup.pricingtypes.pricingtypeid
	--					where	(global.cases.caseid = @CaseID) 
	--							and (referrer.referrerprojecttreatmentpricing.pricingtypeid in (4)))
	--end
	--else 
	--begin


		Set @Price = (Select	sum(isnull(referrer.referrerprojecttreatmentpricing.price,0))
						from    referrer.referrerprojecttreatmentpricing inner join
								global.cases on referrer.referrerprojecttreatmentpricing.referrerprojecttreatmentid = global.cases.referrerprojecttreatmentid inner join
								lookup.pricingtypes on referrer.referrerprojecttreatmentpricing.pricingtypeid = lookup.pricingtypes.pricingtypeid
						where	(global.cases.caseid = @CaseID) and (referrer.referrerprojecttreatmentpricing.pricingtypeid in (4)))
	--end
	if(@Cost >0)
		begin
			if(@Cost = (@Price * @TreatmentSession))
				begin
					select 0 as Cnt, @Cost as Amount
				end
			else
				begin
					select 1 as Cnt , @Price as Amount
				end
		end
	   else
	   begin
		begin
			if(@Session = (@Price * @TreatmentSession))
				begin
					select 0 as Cnt, @Session as Amount
				end
			else
				begin
					select 1 as Cnt , @Price as Amount
				end
		end
	   end
END 




GO
/****** Object:  StoredProcedure [global].[Get_FinalUploadByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 07-28-2018
-- Description:	Get final upload by caseID
-- =============================================
CREATE PROCEDURE [global].[Get_FinalUploadByCaseID](@CaseID int, @DocumentTypeID int)
AS
BEGIN	
	SET NOCOUNT ON;
	Select top 1 * from global.CaseDocuments where DocumentTypeid = @DocumentTypeID and CaseID = @CaseID
	Order by UploadDate desc
END


GO
/****** Object:  StoredProcedure [global].[Get_ImpactOnWorkDetailsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================   
-- Author:  <pkaur>   
-- Create date: <10-07-2018 >   
-- Description: < Get Impact On Work for report by CaseId>   
-- =============================================   
CREATE PROCEDURE [global].[Get_ImpactOnWorkDetailsByCaseID] 
(
@CaseID INT,
@ReportType VARCHAR(20)
)
AS 

BEGIN    
 if (@ReportType = 'Review Assessment' OR @ReportType = 'Final Assessment')
BEGIN
SELECT TOP 1 CAD.CaseAssessmentDetailID,PW.PatientWorkstatusName,PR.PatientRoleName,CAD.IsPatientReturnToPreInjuryDuties,CAD.PatientPreInjuryDutiesDate,CAD.PatientWorkstatusID,
CAD.PatientRecommendationReturn,CAD.MainFactors,CAD.HasThePatientHadTimeOff,CAD.HasThePatientReturnedToWork,
CA.PatientRoleID, CAD.PatientDateOfReturn from [global].[CaseAssessmentDetail] CAD
INNER JOIN [global].[CaseAssessments] CA on CA.CaseID = CAD.CaseID 
INNER JOIN [lookup].[PatientRoles] PR on PR.PatientRoleID = CA.PatientRoleID
INNER JOIN [lookup].[PatientWorkstatus] PW on PW.PatientWorkstatusID = CAD.PatientWorkstatusID 
INNER JOIN [lookup].[AssessmentServices] _AS ON _AS.AssessmentServiceID=CAD.AssessmentServiceID
 where CA.CaseID = @CaseID and _AS.AssessmentServiceName=@ReportType ORDER BY CAD.CaseAssessmentDetailID DESC
END	
ELSE
BEGIN
SELECT TOP 1 CAD.CaseAssessmentDetailID,PW.PatientWorkstatusName,PR.PatientRoleName,CAD.IsPatientReturnToPreInjuryDuties,CAD.PatientPreInjuryDutiesDate,CAD.PatientWorkstatusID,
CAD.PatientRecommendationReturn,CAD.MainFactors,CAD.HasThePatientHadTimeOff,CAD.HasThePatientReturnedToWork,
CA.PatientRoleID, CAD.PatientDateOfReturn from [global].[CaseAssessmentDetail] CAD
INNER JOIN [global].[CaseAssessments] CA on CA.CaseID = CAD.CaseID 
INNER JOIN [lookup].[PatientRoles] PR on PR.PatientRoleID = CA.PatientRoleID
INNER JOIN [lookup].[PatientWorkstatus] PW on PW.PatientWorkstatusID = CAD.PatientWorkstatusID 
INNER JOIN [lookup].[AssessmentServices] _AS ON _AS.AssessmentServiceID=CAD.AssessmentServiceID
 where CA.CaseID = @CaseID and _AS.AssessmentServiceName=@ReportType ORDER BY CAD.CaseAssessmentDetailID DESC
  END
END

GO
/****** Object:  StoredProcedure [global].[Get_InitialReviewAssessmentByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh	
-- Create date: 26-06-2018
-- Description:	Get Initial/Review Assessment by CaseID
--  [global].[Get_InitialReviewAssessmentByCaseID] 1046
-- =============================================
CREATE PROCEDURE [global].[Get_InitialReviewAssessmentByCaseID] 
 
	@CaseID int
AS
BEGIN
	  SELECT global.Cases.CaseReferrerReferenceNumber, supplier.Suppliers.SupplierName, supplier.Suppliers.Email, global.Patients.FirstName +' '+ global.Patients.LastName as PatientFullName, referrer.ReferrerProjectTreatmentAuthorisations.DelegatedAuthorisationTypeID
       FROM  referrer.ReferrerProjectTreatments INNER JOIN
                         referrer.ReferrerProjectTreatmentAuthorisations ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatmentAuthorisations.ReferrerProjectTreatmentID AND 
                         referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatmentAuthorisations.ReferrerProjectTreatmentID AND 
                         referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatmentAuthorisations.ReferrerProjectTreatmentID CROSS JOIN

                         global.Cases INNER JOIN supplier.Suppliers ON global.Cases.SupplierID = supplier.Suppliers.SupplierID INNER JOIN
                         global.Patients ON global.Cases.PatientID = global.Patients.PatientID
						 where global.Cases.ReferrerProjectTreatmentID= referrer.ReferrerProjectTreatmentAuthorisations.ReferrerProjectTreatmentID and global.Cases.CaseID=@CaseID and referrer.ReferrerProjectTreatmentAuthorisations.DelegatedAuthorisationTypeID=2
						
END






GO
/****** Object:  StoredProcedure [global].[Get_InjuredPartyRepresentativesByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Rohit>
-- Create date: <03-10-2018>
-- Description:	#3389- Get Injured Party Representatives By ID>
-- =============================================
CREATE PROCEDURE [global].[Get_InjuredPartyRepresentativesByID]	
(
@InjuredID int
)

AS

 BEGIN

	 Select  * From Global.InjuredPartyRepresentatives Where InjuredID = @InjuredID
	
  END
	


GO
/****** Object:  StoredProcedure [global].[Get_InjuredPartyRepresentativesByReferralID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Get_InjuredPartyRepresentativesByReferralID]  
@ReferralID INT  
AS  
	SELECT InjuredID,FirstName,LastName,ReferralID,Tel1,Tel2,[Address],PostCode,Email,Relationship  
	FROM [global].[InjuredPartyRepresentatives]
	WHERE ReferralID = @ReferralID


GO
/****** Object:  StoredProcedure [global].[Get_IntialAssessmentReportDetailsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Pkaur  
-- Create date: 06/21/2018
-- Description: Get IntialAssessment ReportDetails by  case id  
--=================================================
-- [global].[Get_IntialAssessmentReportDetailsByCaseID]  1049

CREATE PROCEDURE [global].[Get_IntialAssessmentReportDetailsByCaseID]  
 @CaseID INT  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
SELECT global.Cases.CaseReferrerReferenceNumber, supplier.Suppliers.SupplierName, global.Patients.FirstName +' '+global.Patients.LastName as PatientFullName
FROM global.Cases INNER JOIN
global.Patients ON global.Cases.PatientID = global.Patients.PatientID INNER JOIN
supplier.Suppliers ON global.Cases.SupplierID = supplier.Suppliers.SupplierID
 WHERE [CaseID] = @CaseID  
END  

GO
/****** Object:  StoredProcedure [global].[Get_InvoiceByInvoiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoiceByInvoiceID] 
	-- Add the parameters for the stored procedure here
	@InvoiceID INT
AS
BEGIN
	
SELECT *
  FROM [global].[Invoices]   
  where [global].[Invoices].InvoiceID = @InvoiceID
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_InvoiceCollectionActionByInvoiceCollectionActionID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoiceCollectionActionByInvoiceCollectionActionID] 
	-- Add the parameters for the stored procedure here
	@InvoiceCollectionActionID INT
AS
BEGIN
	
SELECT *
  FROM [global].[InvoiceCollectionAction]   
  where [global].[InvoiceCollectionAction].InvoiceCollectionActionID = @InvoiceCollectionActionID
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_InvoiceCollectionActionByInvoiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoiceCollectionActionByInvoiceID] 
	-- Add the parameters for the stored procedure here
	@InvoiceID INT
AS
BEGIN
	
SELECT [global].[InvoiceCollectionAction].*,[global].[Users].Username
  FROM [global].[InvoiceCollectionAction]   
   INNER JOIN [global].[Users] ON  [global].[InvoiceCollectionAction] .UserId = [global].[Users].UserID
  where [global].[InvoiceCollectionAction].InvoiceID = @InvoiceID
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_InvoiceCollectionActionByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoiceCollectionActionByUserID] 
	-- Add the parameters for the stored procedure here
	@UserId INT
AS
BEGIN
	
SELECT *
  FROM [global].[InvoiceCollectionAction]   
  where [global].[InvoiceCollectionAction].UserId = @UserId
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_InvoicePaymentByInvoiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoicePaymentByInvoiceID] 
	-- Add the parameters for the stored procedure here
	@InvoiceID INT
AS
BEGIN
	
SELECT [global].[InvoicePayment].*,[global].[Users].Username
  FROM [global].[InvoicePayment]   
  INNER JOIN [global].[Users] ON  [global].[InvoicePayment] .UserId = [global].[Users].UserID
  where [global].[InvoicePayment].InvoiceID = @InvoiceID
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_InvoicePaymentByInvoicePaymentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoicePaymentByInvoicePaymentID] 
	-- Add the parameters for the stored procedure here
	@InvoicePaymentID INT
AS
BEGIN
	
SELECT *
  FROM [global].[InvoicePayment]   
  where [global].[InvoicePayment].InvoicePaymentID = @InvoicePaymentID
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_InvoicePaymentByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoicePaymentByUserID] 
	-- Add the parameters for the stored procedure here
	@UserID INT
AS
BEGIN
	
SELECT *
  FROM [global].[InvoicePayment]   
  where [global].[InvoicePayment].UserID = @UserID
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_InvoicesByCaseId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoicesByCaseId] 
	-- Add the parameters for the stored procedure here
	@CaseID INT
AS
BEGIN
	
SELECT *
  FROM [global].[Invoices]   
  where [global].[Invoices].CaseId = @CaseID
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_InvoicesByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_InvoicesByUserID] 
	-- Add the parameters for the stored procedure here
	@UserID INT
AS
BEGIN
	
SELECT *
  FROM [global].[Invoices]   
  where [global].[Invoices].UserID = @UserID
	
	 
END



GO
/****** Object:  StoredProcedure [global].[Get_JobDemandByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		jaskaran
-- Create date: 09-04-2019
-- Description:	get Job Demand Record By CaseID
-- =============================================
CREATE PROCEDURE [global].[Get_JobDemandByCaseID]
	@CaseID int
AS
BEGIN
	Select * from  [global].[JobDemands]	
	where JobDemandID = (Select JobDemandID from global.Cases where CaseID = @CaseID)
END

GO
/****** Object:  StoredProcedure [global].[Get_PasswordHistoryByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Param Kaur  
-- Create date: 02/21/2019  
-- Description: Get PasswordHistory By UserID
-- =============================================  
-- [global].[Get_PasswordHistoryByUserID]  546
CREATE PROCEDURE [global].[Get_PasswordHistoryByUserID]  
 @UserID INT  
AS  
BEGIN  
     SELECT * FROM [global].[PasswordHistory]  WHERE [UserID] = @UserID 
END  





GO
/****** Object:  StoredProcedure [global].[Get_PatientAndCaseByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_PatientAndCaseByCaseID]
(
@CaseID INT
)
AS 
  	SELECT     global.CasePatient.PatientID, global.CasePatient.Title, global.CasePatient.FirstName, global.CasePatient.LastName, global.CasePatient.Address, 
                      global.CasePatient.PostCode, global.CasePatient.InjuryDate, global.CasePatient.BirthDate, global.CasePatient.Email, global.CasePatient.Gender, 
                      global.CasePatient.CaseNumber, global.CasePatient.HomePhone, global.CasePatient.WorkPhone, global.CasePatient.MobilePhone, 
                      global.CasePatient.TreatmentCategoryID, global.CasePatient.TreatmentCategoryName, global.CasePatient.TreatmentTypeName, global.CasePatient.City, 
                      global.CasePatient.Region, global.CasePatient.CaseReferrerReferenceNumber, global.CasePatient.CaseSpecialInstruction,
                      global.CasePatient.PatientContactedByInternalUser, global.CasePatient.PatientContactNotes, global.CasePatient.CaseSubmittedDate, global.CasePatient.SupplierID, 
                      global.Cases.InjuryType ,ISNULL(global.Cases.IsTriage,0) AS IsTriage
	FROM         global.CasePatient INNER JOIN
                      global.Cases ON global.CasePatient.CaseID = global.Cases.CaseID
	WHERE     (global.CasePatient.CaseID = @CaseId)
 
  
 


GO
/****** Object:  StoredProcedure [global].[Get_PatientAndCaseDetailsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================   
-- Author:  <pkaur>   
-- Create date: <10-07-2018 >   
-- Description: < Get Pateint and CaseDetails for Initial report by CaseId>   
-- =============================================   

CREATE PROCEDURE [global].[Get_PatientAndCaseDetailsByCaseID] 
(
@CaseID INT
)
AS 
 SELECT TOP 1 global.Patients.FirstName+' '+global.Patients.LastName AS PatientFullName,SUP.PostCode,global.Patients.InjuryDate, global.Patients.BirthDate,global.CaseAppointmentDates.FirstAppointmentOfferedDate, 
global.CaseAppointmentDates.CaseBookIADate, global.Cases.PatientContactDate,global.Cases.CaseSubmittedDate, global.Cases.CaseReferrerReferenceNumber,global.Cases.CaseReferrerDueDate
FROM  global.Cases INNER JOIN global.CaseAppointmentDates ON global.Cases.CaseID = global.CaseAppointmentDates.CaseID INNER JOIN
[supplier].[Suppliers] SUP ON SUP.SupplierID=global.Cases.SupplierID INNER JOIN
 global.Patients ON global.Cases.PatientID = global.Patients.PatientID 
WHERE global.Cases.CaseID=@CaseID  ORDER BY global.CaseAppointmentDates.CaseBookIADate DESC 












GO
/****** Object:  StoredProcedure [global].[Get_PatientByPatientID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP Name: Get_PatientByPatientID
--Latest Version: 1.0


-- Author:		Anuj Batra 
-- Create date: 01/01/2013
-- Description:	Get Patient By Id
-- Version: 1.0

CREATE PROCEDURE [global].[Get_PatientByPatientID] 
(
--Add Parameters here    
@PatientID int
)

AS
BEGIN 
SET NOCOUNT ON; 

--Retrieve User Information from single table Patient(Global)

	Select *  FROM [global].Patients 
	WHERE PatientID=@PatientID

END


GO
/****** Object:  StoredProcedure [global].[Get_PatientContactAttemptsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Pardeep Kumar>
-- Create date: <04-19-2013>
-- Description:	< Create the procedure to Get PatientContactAttempts By CaseID>
-- =============================================



CREATE PROCEDURE [global].[Get_PatientContactAttemptsByCaseID] 
(
@CaseID int
)
as
select * from global.CasePatientContactAttempts where CaseID = @CaseID

GO
/****** Object:  StoredProcedure [global].[Get_PatientContactDate]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [global].[Get_PatientContactDate] 
(
@CaseID INT
)
AS 
SELECT PatientContactDate FROM global.Cases WHERE CaseID=@CaseID

GO
/****** Object:  StoredProcedure [global].[Get_PatientImapctOnLifeDetailsByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================   
-- Author:  <pkaur>   
-- Create date: <10-07-2018 >   
-- Description: < Get Patient ImapctOnLife for report by CaseId>   
-- =============================================   

CREATE PROCEDURE [global].[Get_PatientImapctOnLifeDetailsByCaseID] 
(
@CaseAssessmentDetailID INT
)
AS 
  	

SELECT PIV.PatientImpactValueName, CAPI.Comment FROM  [global].[CaseAssessmentPatientImpacts] AS CAPI 
INNER JOIN  [lookup].[PatientImpacts] AS PI ON PI.PatientImpactID=CAPI.PatientImpactID
INNER JOIN  [lookup].[PatientImpactValues] AS PIV ON PIV.PatientImpactValueID=CAPI.PatientImpactValueID WHERE CAPI.CaseAssessmentDetailID=@CaseAssessmentDetailID
						
 
  
 





GO
/****** Object:  StoredProcedure [global].[Get_PatientInjurySymptomByCaseAssessmentDetailID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================   
-- Author:  <pkaur>   
-- Create date: <10-07-2018 >   
-- Description: < Get Patient Injury Symptom for CaseAssessmentDetailID>   
-- =============================================   

CREATE PROCEDURE [global].[Get_PatientInjurySymptomByCaseAssessmentDetailID] 
(
@CaseAssessmentDetailID INT
)
AS 
Select AA.AffectedAreaDescription,St.StrengthTestingDescription,SD.SymptomDescriptionName,RR.RestrictionRangeDescription,
CAPI.Score from [global].[CaseAssessmentPatientInjuries] CAPI 
LEFT JOIN [lookup].[AffectedAreas] AA on AA.AffectedAreaID = CAPI.AffectedAreaID
LEFT JOIN  [lookup].[StrengthTestings] ST on ST.StrengthTestingID = CAPI.StrengthTestingID
LEFT JOIN [lookup].[SymptomDescriptions] SD on SD.SymptomDescriptionID = CAPI.SymptomDescriptionID
LEFT JOIN [lookup].[RestrictionRanges] RR ON RR.RestrictionRangeID = CAPI.RestrictionRangeID  Where  CAPI.CaseAssessmentDetailID =@CaseAssessmentDetailID
  	





GO
/****** Object:  StoredProcedure [global].[Get_PatientTreatmentSessionByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================   
-- Author:  <pkaur>   
-- Create date: <10-07-2018 >   
-- Description: < Get Patient TreatmentSession  by CaseId>   
-- =============================================   
CREATE PROCEDURE [global].[Get_PatientTreatmentSessionByCaseID] 
(
@CaseID INT,
@ReportType VARCHAR(20)
)
AS 
BEGIN    
 	if (@ReportType = 'Review Assessment' OR @ReportType = 'Final Assessment')
	BEGIN
		   SELECT TOP 1 CAD.SessionsPatientAttended,CAD.IsFurtherTreatmentRecommended,TPT.TreatmentPeriodTypeDesc,CAD.AdditionalInformation,CAD.EvidenceOfClinicalReasoning
 FROM  [global].[CaseAssessmentDetail] AS CAD  INNER JOIN  [lookup].[TreatmentPeriodType] AS TPT ON CAD.PatientTreatmentPeriodDurationID=TPT.TreatmentPeriodTypeID
 INNER JOIN [lookup].[AssessmentServices] AS _AS ON CAD.AssessmentServiceID=_AS.AssessmentServiceID
 WHERE CAD.CaseID=@CaseID AND _AS.AssessmentServiceName=@ReportType ORDER BY CAD.CaseAssessmentDetailID DESC
  	END	
	ELSE
	BEGIN
 SELECT TOP 1 CAD.SessionsPatientAttended,CAD.IsFurtherTreatmentRecommended,TPT.TreatmentPeriodTypeDesc,CAD.AdditionalInformation,CAD.EvidenceOfClinicalReasoning
 FROM  [global].[CaseAssessmentDetail] AS CAD  INNER JOIN  [lookup].[TreatmentPeriodType] AS TPT ON CAD.PatientTreatmentPeriodDurationID=TPT.TreatmentPeriodTypeID
 INNER JOIN [lookup].[AssessmentServices] AS _AS ON CAD.AssessmentServiceID=_AS.AssessmentServiceID
 WHERE CAD.CaseID=@CaseID AND _AS.AssessmentServiceName=@ReportType ORDER BY CAD.CaseAssessmentDetailID DESC
  END
END




GO
/****** Object:  StoredProcedure [global].[Get_PolicyByPolicyId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 09-28-2018
-- Description:	Get Policy Details
-- =============================================
CREATE PROCEDURE [global].[Get_PolicyByPolicyId](@PolicyID int)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT p.*,re.NameOfReinsurer FROM GLOBAL.Policies p
	INNER JOIN [lookup].[Reinsurers] re ON p.NameOfReinsurerID = re.ReinsurerID
	WHERE PolicyID = @PolicyID
END

GO
/****** Object:  StoredProcedure [global].[Get_PolicyOpenDetailById]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh	
-- Create date: 06-09-2019
-- Description:	Get Open policy detail by id
-- =============================================
CREATE PROCEDURE [global].[Get_PolicyOpenDetailById] 
	@PolicyOpenDetailID int
AS
BEGIN
	Select * from [global].[PolicyOpenDetails] where PolicyOpenDetailID = @PolicyOpenDetailID
END

GO
/****** Object:  StoredProcedure [global].[Get_PracitionersByTreatmentCategoryIDAndSupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================   
-- Latest Version: 1.0 
-- Author:  Satya    
-- Create date: 24-May-2013  
-- Description: <Get Pracitioners By TreatmentCategoryID And SupplierID>     
-- Version : 1.0     

-- =============================================    
    
CREATE PROCEDURE [global].[Get_PracitionersByTreatmentCategoryIDAndSupplierID]   
    

 @SupplierID INT  ,
  @TreatmentCategoryID INT  
    
AS     
 BEGIN    
    
SELECT     global.Practitioners.PractitionerFirstName, global.Practitioners.PractitionerLastName, supplier.SupplierPractitioners.SupplierID, 
                      supplier.SupplierPractitioners.SupplierPractitionerID, global.PractitionerRegistrations.PractitionerRegistrationID, global.PractitionerRegistrations.PractitionerID, 
                      global.PractitionerRegistrations.TreatmentCategoryID
FROM         global.PractitionerRegistrations INNER JOIN
                      global.Practitioners ON global.PractitionerRegistrations.PractitionerID = global.Practitioners.PractitionerID INNER JOIN
                      supplier.SupplierPractitioners ON global.PractitionerRegistrations.PractitionerRegistrationID = supplier.SupplierPractitioners.PractitionerRegistrationID
                     WHERE global.PractitionerRegistrations.TreatmentCategoryID = @TreatmentCategoryID AND supplier.SupplierPractitioners.SupplierID = @SupplierID
    
 END 

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerByPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================   
-- Latest Version: 1.1 
-- Author:  Pardeep Kumar    
-- Create date: 31-Jan-2013  
-- Description: <Get Practitioner By PractitionerID>     
-- Version : 1.0     

-- Modified By: Robin Singh    
-- Created date: 07-Feb-2013    
-- Description: Modify table name Practitioner to Practitioners
-- Version: 1.1    
-- =============================================    
    
CREATE PROCEDURE [global].[Get_PractitionerByPractitionerID]      
    
 @PractitionerID INT    
    
AS     
 BEGIN    
    
SELECT * FROM [global].Practitioners    
WHERE PractitionerID = @PractitionerID    
    
 END 

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerExpertiseByAreaofExpertiseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Pardeep Kumar  
-- Create date: 31-Jan-2013
-- Description: <Get PractitionerExpertise By AreaofExpertiseID>  
-- Version : 1.0   
-- =============================================   
  
CREATE PROCEDURE [global].[Get_PractitionerExpertiseByAreaofExpertiseID]    
 @AreaofExpertiseID INT  
  
AS   
 BEGIN  
  
SELECT * FROM global.PractitionerExpertise  
WHERE AreaofExpertiseID=@AreaofExpertiseID  
 END  

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerExpertiseByPractitionerExpertiseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Pardeep Kumar  
-- Create date: 31-Jan-2013
-- Description: <Get PractitionerExpertise By PractitionerExpertiseID>
-- Version : 1.0   
-- =============================================   
  
CREATE PROCEDURE [global].[Get_PractitionerExpertiseByPractitionerExpertiseID]    
@PractitionerExpertiseID INT  
  
AS   
 BEGIN  
  
SELECT * FROM [global].[PractitionerExpertise]
WHERE PractitionerExpertiseID  = @PractitionerExpertiseID
 END  

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerExpertiseByPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Pardeep Kumar  
-- Create date: 31-Jan-2013
-- Description: <Get PractitionerExpertise By PractitionerID>  
-- Version : 1.0   
-- =============================================  
  
CREATE PROCEDURE [global].[Get_PractitionerExpertiseByPractitionerID]    
 @PractitionerID INT  
  
AS   
 BEGIN  
  
SELECT * FROM [global].[PractitionerExpertise]
WHERE PractitionerID=@PractitionerID  
 END  

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerLikePractitionerName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Latest Version: 1.1    
-- Author:  Pardeep Kumar    
-- Create date: 31-Jan-2013  
-- Description: <Get Practitioner Like PractitionerName>     
-- Version : 1.0    
-- ============================================= 
-- Modified By: Robin Singh    
-- Created date: 07-Feb-2013    
-- Description: Modify table name Practitioner to Practitioners
-- Version: 1.1   
-- =============================================     
-- [global].[Get_PractitionerLikePractitionerName] '   vspra123 asdsa'      
CREATE PROCEDURE [global].[Get_PractitionerLikePractitionerName]         
 @PractitionerFirstName VARCHAR(50)        
AS     
 BEGIN    
      
      SELECT      PractitionerID,PractitionerFirstName,PractitionerLastName,DateAdded,FullName  FROM(
                                                                                          SELECT PractitionerID,PractitionerFirstName,PractitionerLastName,DateAdded, 
																						  (PractitionerFirstName + ' ' + PractitionerLastName) as [FullName] FROM [global].Practitioners ) T  
      WHERE ([PractitionerFirstName] LIKE (LTRIM(RTRIM(@PractitionerFirstName)) + '%'))    or  ([PractitionerLastName]	LIKE (LTRIM(RTRIM(@PractitionerFirstName)) + '%')) or ([FullName] LIKE '%' + (LTRIM(RTRIM(@PractitionerFirstName)) + '%'))
    
 END 

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerRegistrationByPractitionerRegistrationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 03/08/2013
-- Description:	Create stored procedure to Get PractitionerRegistrations By PractitionerRegistrationID
-- Version: 1.0
-- =============================================


CREATE PROCEDURE [global].[Get_PractitionerRegistrationByPractitionerRegistrationID]
	-- Add the parameters for the stored procedure here
	   @PractitionerRegistrationID int

AS
BEGIN	

SELECT * FROM
	 [global].[PractitionerRegistrations] 
	  Where PractitionerRegistrationID=@PractitionerRegistrationID
END

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP_HELPTEXT [GLOBAL.Get_PractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID]
  
CREATE PROCEDURE [global].[Get_PractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID]      
@PractitionerID INT  
,@TreatmentCategoryID INT,  
@RegistrationTypeID INT =NULL   
AS      
BEGIN      
 -- SET NOCOUNT ON added to prevent extra result sets from      
 -- interfering with SELECT statements.      
 SET NOCOUNT ON;      
      
    -- Insert statements for procedure here      
 SELECT * FROM GLOBAL.PractitionerRegistrations     
      WHERE PractitionerID = @PractitionerID AND TreatmentCategoryID = @TreatmentCategoryID 
      AND (RegistrationTypeID = @RegistrationTypeID OR  RegistrationTypeID IS NULL  )
END 

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerRegistrationsByPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 03/08/2013
-- Description:	Create stored procedure to Get PractitionerRegistrations By PractitionerID
-- Version: 1.0
-- =============================================


CREATE PROCEDURE [global].[Get_PractitionerRegistrationsByPractitionerID]
	-- Add the parameters for the stored procedure here
	   @PractitionerID int

AS
BEGIN	

SELECT * FROM
	 [global].[PractitionerRegistrations] 
	  Where PractitionerID=@PractitionerID
END

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerRegistrationsByRegistrationTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP_HELPTEXT [GLOBAL.Get_PractitionerRegistrationsByRegistrationTypeID]
-- =============================================  
-- Author:  Satya  
-- Create date: 03/08/2013  
-- Description: Create stored procedure to Get PractitionerRegistrations By RegistrationTypeID  
-- Version: 1.0  
-- =============================================  
  
  
CREATE PROCEDURE [global].[Get_PractitionerRegistrationsByRegistrationTypeID]  
 -- Add the parameters for the stored procedure here  
    @RegistrationTypeID int = NULL  
  
AS  
BEGIN   
  
SELECT * FROM  
  [global].[PractitionerRegistrations]   
   Where (RegistrationTypeID = @RegistrationTypeID OR  RegistrationTypeID IS NULL  ) 
END

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerRegistrationsByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 03/08/2013
-- Description:	Create stored procedure to Get PractitionerRegistrations By TreatmentCategoryID
-- Version: 1.0
-- =============================================


CREATE PROCEDURE [global].[Get_PractitionerRegistrationsByTreatmentCategoryID]
	-- Add the parameters for the stored procedure here
	   @TreatmentCategoryID int

AS
BEGIN	

SELECT * FROM
	 [global].[PractitionerRegistrations] 
	  Where TreatmentCategoryID=@TreatmentCategoryID
END

GO
/****** Object:  StoredProcedure [global].[Get_PractitionersRecentlyAdded]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 06/24/2013
-- Description:	Get_PractitionersRecentlyAdded
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [global].[Get_PractitionersRecentlyAdded]
	-- Add the parameters for the stored procedure here
AS
BEGIN	
	
    Select TOP 10 * From global.Practitioners 
    ORDER BY global.Practitioners.DateAdded DESC
   
    END
 


GO
/****** Object:  StoredProcedure [global].[Get_PractitionerTreatmentRegistrationsLikePractitionerName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0  
-- Author : Pardeep Kumar  
-- Date   : 01-July-2013  
-- Description : Procedure to get the PractitionerTreatment Registration Like practitioner Name with skip and take  
          


CREATE PROCEDURE [global].[Get_PractitionerTreatmentRegistrationsLikePractitionerName]       
        
 @PractitionerName VARCHAR(50),         
 @Skip INT,            
 @Take INT         
        
AS         
begin      
      
with PractitionerTreatmentRegistrations AS      
(      
      
Select         
distinct         
           ST2.PractitionerID,PractitionerFirstName,ST2.PractitionerLastName,      
           SUBSTRING(((Select + ',' +ST1.TreatmentCategoryName  AS [text()]      
            From [lookup].[PractitionerTreatmentRegistrations]  ST1      
            Where ST1.PractitionerID = ST2.PractitionerID      
            ORDER BY ST1.PractitionerRegistrationID      
            For XML PATH (''))),2,350)      
            as TreatmentCategoryName,      
                  
            SUBSTRING(((Select + ',' + ST1.RegistrationTypeName  AS [text()]      
            From [lookup].[PractitionerTreatmentRegistrations]  ST1      
            Where ST1.PractitionerID = ST2.PractitionerID      
            ORDER BY ST1.PractitionerRegistrationID      
            For XML PATH (''))),2,350)      
             as RegistrationTypeName,      
                  
            SUBSTRING(      
            ((Select + ','+  ST1.RegistrationNumber AS [text()]      
            From [lookup].[PractitionerTreatmentRegistrations]  ST1      
            Where ST1.PractitionerID = ST2.PractitionerID      
            ORDER BY ST1.PractitionerRegistrationID      
            For XML PATH (''))),2,350)as RegistrationNumber      
                  
     From [lookup].[PractitionerTreatmentRegistrations]  ST2        
     WHERE     (( ST2.PractitionerFirstName LIKE  @PractitionerName + '%')           
               or (ST2.PractitionerLastName LIKE  @PractitionerName + '%')          
               or (ST2.PractitionerFirstName + ' '+ ST2.PractitionerLastName LIKE '%' + @PractitionerName + '%'))      
),      
PractitionerTreatmentRegistrationsPagging as      
(      
 select ROW_NUMBER() over(order By PractitionerTreatmentRegistrations.PractitionerID) As ROW,      
 *      
  from PractitionerTreatmentRegistrations       
)      
       
select * ,
(select top 1 IsActive from [lookup].[PractitionerTreatmentRegistrations] as a where a.PractitionerID = PractitionerTreatmentRegistrationsPagging.PractitionerID)'IsActive' ,
(select top 1 PractitionerRegistrationID from [lookup].[PractitionerTreatmentRegistrations] as a where a.PractitionerID = PractitionerTreatmentRegistrationsPagging.PractitionerID)'PractitionerRegistrationID'    
 from PractitionerTreatmentRegistrationsPagging where ROW between @Skip +1 and @Skip + @Take       
      
end

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerTreatmentRegistrationsLikePractitionerNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- Description:	<This Procedure Used to Get Count of PractitionerTreatmentRegistrations Like PractitionerName  >
-- Version	:	1.0	
-- =============================================
-- Created By : Pardeep Kumar 
-- Create date: 29-June-2013  
-- Description: Get_PractitionerTreatmentRegistrationsLikePractitionerNameCount
-- Version: 1.0  
-- ======================================================

--[global].[Get_PractitionerTreatmentRegistrationsLikePractitionerNameCount] 'har'

CREATE PROCEDURE [global].[Get_PractitionerTreatmentRegistrationsLikePractitionerNameCount]

 @PractitionerName VARCHAR(50)
AS 
BEGIN

with PractitionerTreatmentRegistrations AS
(

Select   
distinct   
           ST2.PractitionerID
            
     From [lookup].[PractitionerTreatmentRegistrations]  ST2  
     WHERE     (( ST2.PractitionerFirstName LIKE  @PractitionerName + '%')     
               or (ST2.PractitionerLastName LIKE  @PractitionerName + '%')    
               or (ST2.PractitionerFirstName + ' '+ ST2.PractitionerLastName LIKE  '%' + @PractitionerName + '%'))
)
 
select COUNT(*)'Count' from PractitionerTreatmentRegistrations 
  
     

 END

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerTreatmentRegistrationsLikeTreatmentCategoryName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


  
  
      
      
-- Description: <This Procedure Used to Get PractitionerTreatmentRegistrationLikeTreatmentCategoryName with skip and take >      
-- Version : 1.0       
-- =============================================      
-- Created By : Pardeep Kumar       
-- Create date: 29-June-2013        
-- Description: Get PractitionerTreatmentRegistrationLikeTreatmentCategoryName with skip and take      
-- Version: 1.0        
-- ======================================================      
      

--exec [global].[Get_PractitionerTreatmentRegistrationsLikeTreatmentCategoryName]  'psy',0,8
   

CREATE PROCEDURE [global].[Get_PractitionerTreatmentRegistrationsLikeTreatmentCategoryName]        
      
 @TreatmentCategoryName VARCHAR(50),       
 @Skip INT,          
 @Take INT       
      
AS       
BEGIN      
      
WITH PractitionerTreatmentRegistration AS      
(      
 SELECT   distinct  PractitionerID,TreatmentCategoryName,PractitionerFirstName,PractitionerLastName,
                
            SUBSTRING(((Select + ',' + ST1.RegistrationTypeName  AS [text()]    
            From [lookup].[PractitionerTreatmentRegistrations]  ST1    
            Where ST1.PractitionerID = ST2.PractitionerID and ST1.TreatmentCategoryName Like (@TreatmentCategoryName+ '%')    
            ORDER BY ST1.PractitionerRegistrationID    
            For XML PATH (''))),2,350)    
             as RegistrationTypeName,    
    
   SUBSTRING(    
            ((Select + ','+  ST1.RegistrationNumber AS [text()]    
            From [lookup].[PractitionerTreatmentRegistrations]  ST1    
            Where ST1.PractitionerID = ST2.PractitionerID and ST1.TreatmentCategoryName Like (@TreatmentCategoryName+ '%')    
            ORDER BY ST1.PractitionerRegistrationID    
            For XML PATH (''))),2,350)as RegistrationNumber    
     
From [lookup].[PractitionerTreatmentRegistrations]  ST2        
WHERE ST2.TreatmentCategoryName like(@TreatmentCategoryName+ '%')      
        
), PractitionerTreatmentRegistrationPagging as    
(    
select ROW_NUMBER() over(order By ptr.PractitionerID) As ROW,    
* from PractitionerTreatmentRegistration ptr     
    
)    
select *,(select top 1 PractitionerRegistrationID from [lookup].[PractitionerTreatmentRegistrations] as a where a.PractitionerID = prp.PractitionerID)'PractitionerRegistrationID'
,(select top 1 IsActive from [lookup].[PractitionerTreatmentRegistrations] as a where a.PractitionerID = prp.PractitionerID)'IsActive'
 from  PractitionerTreatmentRegistrationPagging as prp    
where prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take      
      
 END
 
 

GO
/****** Object:  StoredProcedure [global].[Get_PractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
-- Description: <This Procedure Used to Get PractitionerTreatmentRegistrationLikeTreatmentCategoryName Count >    
-- Version : 1.0     
-- =============================================    
-- Created By : Pardeep Kumar     
-- Create date: 29-June-2013      
-- Description: Get_PractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount     
-- Version: 1.0      
-- ======================================================    
    
    
CREATE PROCEDURE [global].[Get_PractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount]    
 @TreatmentCategoryName VARCHAR(50)    
AS     
BEGIN    
    
 SELECT   COUNT(distinct PractitionerID)'Count' FROM [lookup].[PractitionerTreatmentRegistrations]      
where lookup.PractitionerTreatmentRegistrations.TreatmentCategoryName like(@TreatmentCategoryName+ '%')    
    
 END

GO
/****** Object:  StoredProcedure [global].[Get_PricingTypesByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=========================================================
-- Create By : Vishal sen    
-- Create date: 12/11/2013    
-- updated Version : 1.0  
-- Description: create sp Get_PricingTypesByTreatmentCategoryID
--=========================================================


CREATE PROCEDURE [global].[Get_PricingTypesByTreatmentCategoryID] 
(
 @TreatmentCategoryID INT 
)
AS  
BEGIN  

 SELECT *  FROM   [lookup].[TreatmentCategoryPricingTypes]    


where [TreatmentCategoryID]= @TreatmentCategoryID
END  

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  ftan  
-- Create date: 08-21-2013  
-- Description: Get supplier and referrer treatment pricing for a treatmentcategory.  
-- Test params : on freddie's database @ReferrerProjectTreatmentID 88, @SupplierID 35, @TreatmentCategory 1  
--[global].[Get_ReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID] 10075,634,9
-- =============================================  
CREATE PROCEDURE [global].[Get_ReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID]  
 -- Add the parameters for the stored procedure here  
 @ReferrerProjectTreatmentID INT,  
 @SupplierID INT,  
 @TreatmentCategoryID INT   
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
 SELECT     referrer.ReferrerProjectTreatmentPricing.PricingID AS ReferrerPricingID, referrer.ReferrerProjectTreatmentPricing.Price AS ReferrerPrice,   
                      supplier.SupplierTreatmentPricing.PricingID AS SupplierPriceID, supplier.SupplierTreatmentPricing.Price AS SupplierPrice,   
                      referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID, supplier.SupplierTreatments.SupplierID, referrer.ReferrerProjectTreatmentPricing.PricingTypeID,   
                      lookup.PricingTypes.PricingTypeName, supplier.SupplierTreatments.SupplierTreatmentID  
 FROM         supplier.SupplierTreatments INNER JOIN  
        supplier.SupplierTreatmentPricing ON supplier.SupplierTreatments.SupplierTreatmentID = supplier.SupplierTreatmentPricing.SupplierTreatmentID INNER JOIN  
        referrer.ReferrerProjectTreatmentPricing INNER JOIN  
        referrer.ReferrerProjectTreatments ON   
        referrer.ReferrerProjectTreatmentPricing.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID ON   
        supplier.SupplierTreatments.TreatmentCategoryID = referrer.ReferrerProjectTreatments.TreatmentCategoryID AND   
        supplier.SupplierTreatmentPricing.PricingTypeID = referrer.ReferrerProjectTreatmentPricing.PricingTypeID  
        INNER JOIN lookup.PricingTypes ON referrer.ReferrerProjectTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID  
 WHERE     (referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID) AND (supplier.SupplierTreatments.SupplierID = @SupplierID) AND   
      (referrer.ReferrerProjectTreatments.TreatmentCategoryID = @TreatmentCategoryID) AND (supplier.SupplierTreatments.TreatmentCategoryID = @TreatmentCategoryID)  
END  

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Satya  
-- Create date: 08-27-2013  
-- Description: Get supplier and referrer treatment pricing for a treatmentcategory.  
-- =============================================  
CREATE PROCEDURE [global].[Get_ReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID]  
 -- Add the parameters for the stored procedure here  
 @ReferrerProjectTreatmentID INT,  
 @SupplierID INT,  
 @TreatmentCategoryID INT,
 @PricingTypeID INT
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
 SELECT     referrer.ReferrerProjectTreatmentPricing.PricingID AS ReferrerPricingID, referrer.ReferrerProjectTreatmentPricing.Price AS ReferrerPrice,   
                      supplier.SupplierTreatmentPricing.PricingID AS SupplierPriceID, supplier.SupplierTreatmentPricing.Price AS SupplierPrice,   
                      referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID, supplier.SupplierTreatments.SupplierID, referrer.ReferrerProjectTreatmentPricing.PricingTypeID,   
                      lookup.PricingTypes.PricingTypeName, supplier.SupplierTreatments.SupplierTreatmentID  
 FROM         supplier.SupplierTreatments INNER JOIN  
        supplier.SupplierTreatmentPricing ON supplier.SupplierTreatments.SupplierTreatmentID = supplier.SupplierTreatmentPricing.SupplierTreatmentID INNER JOIN  
        referrer.ReferrerProjectTreatmentPricing INNER JOIN  
        referrer.ReferrerProjectTreatments ON   
        referrer.ReferrerProjectTreatmentPricing.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID ON   
        supplier.SupplierTreatments.TreatmentCategoryID = referrer.ReferrerProjectTreatments.TreatmentCategoryID AND   
        supplier.SupplierTreatmentPricing.PricingTypeID = referrer.ReferrerProjectTreatmentPricing.PricingTypeID  
        INNER JOIN lookup.PricingTypes ON referrer.ReferrerProjectTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID  
 WHERE     (referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID) AND (supplier.SupplierTreatments.SupplierID = @SupplierID) AND   
      (referrer.ReferrerProjectTreatments.TreatmentCategoryID = @TreatmentCategoryID) AND (supplier.SupplierTreatments.TreatmentCategoryID = @TreatmentCategoryID) AND
      (referrer.ReferrerProjectTreatmentPricing.PricingTypeID = @PricingTypeID) 
END  

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerCasesByWorkflowID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




-- =============================================
-- Author:		<Pardeep Kumar>
-- Create date: <04-06-2013>
-- Description:	<Create the Get ReferrerCases By WorkflowID>
-- =============================================

CREATE PROCEDURE [global].[Get_ReferrerCasesByWorkflowID]
(
@WorkflowID int,
@ReferrerID int
)
as
select * from global.Cases where WorkflowID = @WorkflowID and ReferrerID = @ReferrerID

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerProjectTreatmentDocumentSetup]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================     
-- Latest Version : 1.0   
-- Author:  Rohit Kumar
-- Create date: 12-12-2014
-- Description: Get Referrer Project Treatment Document Setup
-- Version : 1.0       
-- =============================================    
CREATE PROCEDURE [global].[Get_ReferrerProjectTreatmentDocumentSetup]       
 -- Add the parameters for the stored procedure here      
    @CaseID INT 
    ,@AssessmentServiceID INT      
     
AS      
BEGIN       
      
      
	SELECT     referrer.ReferrerProjectTreatmentDocumentSetup.DocumentSetupTypeID
	FROM         global.Cases INNER JOIN
                      referrer.ReferrerProjectTreatmentDocumentSetup ON 
                      global.Cases.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatmentDocumentSetup.ReferrerProjectTreatmentID
	WHERE     (global.Cases.CaseID = @CaseID) AND (referrer.ReferrerProjectTreatmentDocumentSetup.AssessmentServiceID =@AssessmentServiceID)
	
END




GO
/****** Object:  StoredProcedure [global].[Get_ReferrerReferrerAndSupplierTreatmentPricingByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ftan
-- Create date: 10-20-2013
-- Description:	get the attached referrer and supplier treatment pricing for a case by passing case id. pricingtypeid is optional.
-- if pricing type id is passed it will only return the pricing for the specific pricingtypeid 
-- =============================================
CREATE PROCEDURE [global].[Get_ReferrerReferrerAndSupplierTreatmentPricingByCaseID]
	@CaseID INT,
	@PricingTypeID INT = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT referrer.ReferrerProjectTreatmentPricing.PricingID AS ReferrerPricingID, referrer.ReferrerProjectTreatmentPricing.Price AS ReferrerPrice,   
                      supplier.SupplierTreatmentPricing.PricingID AS SupplierPriceID, supplier.SupplierTreatmentPricing.Price AS SupplierPrice,   
                      referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID, supplier.SupplierTreatments.SupplierID, referrer.ReferrerProjectTreatmentPricing.PricingTypeID,   
                      lookup.PricingTypes.PricingTypeName, supplier.SupplierTreatments.SupplierTreatmentID 
	FROM global.Cases 
	INNER JOIN referrer.ReferrerProjectTreatments ON referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = global.Cases.ReferrerProjectTreatmentID
	LEFT JOIN referrer.ReferrerProjectTreatmentPricing ON referrer.ReferrerProjectTreatmentPricing.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID 
	LEFT JOIN supplier.SupplierTreatments ON global.Cases.SupplierID = supplier.SupplierTreatments.SupplierID AND referrer.ReferrerProjectTreatments.TreatmentCategoryID = supplier.SupplierTreatments.TreatmentCategoryID
	AND supplier.SupplierTreatments.TreatmentCategoryID = referrer.ReferrerProjectTreatments.TreatmentCategoryID 
	LEFT JOIN  supplier.SupplierTreatmentPricing ON supplier.SupplierTreatments.SupplierTreatmentID = supplier.SupplierTreatmentPricing.SupplierTreatmentID
	AND supplier.SupplierTreatmentPricing.PricingTypeID = referrer.ReferrerProjectTreatmentPricing.PricingTypeID  
	LEFT JOIN lookup.PricingTypes ON referrer.ReferrerProjectTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID  
	WHERE global.Cases.CaseID = @CaseID AND (@PricingTypeID IS NULL OR referrer.ReferrerProjectTreatmentPricing.PricingTypeID = @PricingTypeID)
END


GO
/****** Object:  StoredProcedure [global].[Get_ReferrerSupplierCaseLikeCaseNumberAndSupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================              
-- Author:  <Pardeep Kumar>              
-- Create date: <11-Oct-2013>              
-- Description: <Create the procedure to Get the CasesCount Like PatientName and SupplierID >              
-- =============================================         
-- Author:  <Mahinder Singh>          
-- Create date: <10-OCt-2018>          
-- Description: <UserPermission>          
-- ============================================= 
CREATE PROCEDURE [global].[Get_ReferrerSupplierCaseLikeCaseNumberAndSupplierID]        
@CaseNumber varchar(100),      
@SupplierID bigint ,  
@UserID bigint,    
@Skip bigint,      
@Take bigint           
AS           
      
      
Begin  
 DECLARE @UserRole VARCHAR(50)

  SET @UserRole = (SELECT SupplierTypes  FROM [global].[Users]  where UserID = @UserID)

  IF((@UserRole = 'Supplier Admin'))
  BEGIN     
			with PagedSearch as       
			(      
			SELECT         
			  ROW_NUMBER() over (order by CaseID asc) as Row,      
			[PatientID]        
			,[FirstName]        
			,[LastName]        
			,[CaseSubmittedDate]        
			,[PostCode]           
			,[CaseID]        
			,[CaseNumber]            
			,[WorkflowID]         
			,[CaseReferrerReferenceNumber] ,      
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]      
			  FROM [global].[ReferrerSupplierCases]          
						   WHERE     (global.ReferrerSupplierCases.CaseNumber LIKE  @CaseNumber + '%')                                   
								  and global.ReferrerSupplierCases.SupplierID = @SupplierID   
								 --- and global.ReferrerSupplierCases.SupplierAssignedUser = @UserID     
			)                     
      
			SELECT * FROM PagedSearch prp           
			WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take   
  END
  ELSE IF(@UserRole = 'Supplier User')
  BEGIN 
          with PagedSearch as       
			(      
			SELECT         
			  ROW_NUMBER() over (order by CaseID asc) as Row,      
			[PatientID]        
			,[FirstName]        
			,[LastName]        
			,[CaseSubmittedDate]        
			,[PostCode]           
			,[CaseID]        
			,[CaseNumber]            
			,[WorkflowID]         
			,[CaseReferrerReferenceNumber] ,      
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]      
			  FROM [global].[ReferrerSupplierCases]          
						   WHERE     (global.ReferrerSupplierCases.CaseNumber LIKE  @CaseNumber + '%')                                   
								  and global.ReferrerSupplierCases.SupplierID = @SupplierID   
								  and global.ReferrerSupplierCases.SupplierAssignedUser = @UserID     
			)                     
      
			SELECT * FROM PagedSearch prp           
			WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take    
  END    
      
End

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
          
-- =============================================          
-- Author:  <Pardeep Kumar>          
-- Create date: <11-Oct-2013>          
-- Description: <Create the procedure to Get the Cases Number Count Like CaseNumber and SupplierID >          
-- =============================================     
         
         
         
CREATE PROCEDURE [global].[Get_ReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount]       
@CaseNumber varchar(100),    
@SupplierID bigint,
@UserID bigint   
AS         
    
    
Begin   
   DECLARE @UserRole VARCHAR(50)

  SET @UserRole = (SELECT SupplierTypes  FROM [global].[Users]  where UserID = @UserID)

  IF((@UserRole = 'Supplier Admin'))
  BEGIN 
		with PagedSearch as     
		(    
		SELECT       
			ROW_NUMBER() over (order by CaseID asc) as Row,    
		[PatientID]      
		,[FirstName]      
		,[LastName]      
		,[CaseSubmittedDate]      
		,[PostCode]         
		,[CaseID]      
		,[CaseNumber]          
		,[WorkflowID]       
		,[CaseReferrerReferenceNumber] ,    
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]    
			FROM [global].[ReferrerSupplierCases]        
						WHERE     (global.ReferrerSupplierCases.CaseNumber LIKE  @CaseNumber + '%')                                 
								and global.ReferrerSupplierCases.SupplierID = @SupplierID 
								---- and global.ReferrerSupplierCases.SupplierAssignedUser = @UserID       
		)                   
    
		SELECT COUNT(CaseID)'Count' FROM PagedSearch   
  END
  ELSE IF(@UserRole = 'Supplier User')
  BEGIN 
        with PagedSearch as     
		(    
		SELECT       
			ROW_NUMBER() over (order by CaseID asc) as Row,    
		[PatientID]      
		,[FirstName]      
		,[LastName]      
		,[CaseSubmittedDate]      
		,[PostCode]         
		,[CaseID]      
		,[CaseNumber]          
		,[WorkflowID]       
		,[CaseReferrerReferenceNumber] ,    
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]    
			FROM [global].[ReferrerSupplierCases]        
						WHERE     (global.ReferrerSupplierCases.CaseNumber LIKE  @CaseNumber + '%')                                 
								and global.ReferrerSupplierCases.SupplierID = @SupplierID 
							    and global.ReferrerSupplierCases.SupplierAssignedUser = @UserID       
		)                   
    
		SELECT COUNT(CaseID)'Count' FROM PagedSearch   
  END	  
    
End

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerSupplierCaseLikePatientNameAndReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
          
-- =============================================          
-- Author:  <Pardeep Kumar>          
-- Create date: <11-Oct-2013>          
-- Description: <Create the procedure to Get the Cases Like PatientName and ReferrerID >          
-- =============================================   
-- =============================================          
-- Author:  <Mahinder Singh>          
-- Create date: <10-Oct-2018>          
-- Description: <User Permission>          
-- =============================================       
 --- [global].[Get_ReferrerSupplierCaseLikePatientNameAndReferrerID] 'AllCases','',566,498,0,20
CREATE PROCEDURE [global].[Get_ReferrerSupplierCaseLikePatientNameAndReferrerID]    
@AdditionalParam varchar(10),   
@PatientName varchar(50),    
@ReferrerID bigint ,   
@UserID bigint,  
@Skip bigint,    
@Take bigint         
AS         
    
    

Begin
    DECLARE @UserRole VARCHAR(50)

	SET @UserRole = (SELECT ReferrerTypes  FROM [global].[Users]  where UserID = @UserID)
 
 IF((@UserRole = 'Referrer Admin') OR (@UserRole = 'Referrer Project Admin'))
 BEGIN  
	    if(ltrim(rtrim(@AdditionalParam))='AllCases')
		begin
		with PagedSearch as     
		(    
		SELECT       
		  ROW_NUMBER() over (order by CaseID asc) as Row,    
		[PatientID]      
		,[FirstName]      
		,[LastName]      
		,[CaseSubmittedDate]      
		,[PostCode]         
		,[CaseID]      
		,[CaseNumber]          
		,[WorkflowID]       
		,[CaseReferrerReferenceNumber] ,    
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID
		  FROM [global].[ReferrerSupplierCases]        
					   WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
							  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
							  or (global.ReferrerSupplierCases.FirstName  + ' '+ global.ReferrerSupplierCases.LastName LIKE  '%' + @PatientName + '%' ) )     
                                                     
							  and  global.ReferrerSupplierCases.ReferrerID = @ReferrerID)                 
    
		SELECT *  FROM PagedSearch prp         
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take      
		 end

		else if(ltrim(rtrim(@AdditionalParam))='Active')
		begin
		with PagedSearch as     
		(    
		SELECT       
		  ROW_NUMBER() over (order by CaseID asc) as Row,    
		[PatientID]      
		,[FirstName]      
		,[LastName]      
		,[CaseSubmittedDate]      
		,[PostCode]         
		,[CaseID]      
		,[CaseNumber]          
		,[WorkflowID]       
		,[CaseReferrerReferenceNumber] ,    
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID] ,InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID   
		  FROM [global].[ReferrerSupplierCases]        
					   WHERE    ( (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
							  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
							  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  '%' + @PatientName + '%'))      

							  and global.ReferrerSupplierCases.ReferrerID = @ReferrerID    
							 and global.ReferrerSupplierCases.WorkflowID  not in (210,212) )
		)                   
    
		SELECT * FROM PagedSearch prp         
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take      
		end
		else
		begin
		with PagedSearch as     
		(    
		SELECT       
		  ROW_NUMBER() over (order by CaseID asc) as Row,    
		[PatientID]      
		,[FirstName]      
		,[LastName]      
		,[CaseSubmittedDate]      
		,[PostCode]         
		,[CaseID]      
		,[CaseNumber]          
		,[WorkflowID]       
		,[CaseReferrerReferenceNumber] ,    
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID] ,InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID
		  FROM [global].[ReferrerSupplierCases]        
					   WHERE     ((( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
							  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
							  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  '%' + @PatientName + '%'))      
                                                     
							  and global.ReferrerSupplierCases.ReferrerID = @ReferrerID    
							  and global.ReferrerSupplierCases.WorkflowID  in (210,212) )  
		)                  
    
		SELECT * FROM PagedSearch prp         
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take  
		end
 END
 ELSE IF(@UserRole = 'Referrer Project User')
 BEGIN 
			if(ltrim(rtrim(@AdditionalParam))='AllCases')
			begin
			with PagedSearch as     
			(    
			SELECT       
				ROW_NUMBER()over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID
				FROM [global].[ReferrerSupplierCases]        
							WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
									or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
									or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  '%' + @PatientName + '%') )     

									and global.ReferrerSupplierCases.ReferrerID = @ReferrerID 
									and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID )                   
    
			SELECT * FROM PagedSearch prp         
			WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take      
				end

			else if(ltrim(rtrim(@AdditionalParam))='Active')
			begin
			with PagedSearch as     
			(    
			SELECT       
				ROW_NUMBER() over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID] ,InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID   
				FROM [global].[ReferrerSupplierCases]        
							WHERE    ( (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
									or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
									or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  '%' + @PatientName + '%'))      
                                                      
									and global.ReferrerSupplierCases.ReferrerID = @ReferrerID  
									and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID    
									and global.ReferrerSupplierCases.WorkflowID  not in (210,212) )
			)                   
    
			SELECT * FROM PagedSearch prp         
			WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take      
			end
			else
			begin
			with PagedSearch as     
			(    
			SELECT
				ROW_NUMBER() over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID] ,InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID
				FROM [global].[ReferrerSupplierCases]        
							WHERE     ((( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
									or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
									or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  '%' + @PatientName + '%'))      

									and global.ReferrerSupplierCases.ReferrerID = @ReferrerID 
									and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID   
									and global.ReferrerSupplierCases.WorkflowID  in (210,212) )  
			)                  
    
			SELECT * FROM PagedSearch prp         
			WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take  
			end
 END
   


End

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
        
        
              
-- =============================================              
-- Author:  <Pardeep Kumar>              
-- Create date: <11-Oct-2013>              
-- Description: <Create the procedure to Get the CasesCount Like PatientName and ReferrerID >              
-- =============================================         
-- =============================================          
-- Author:  <Mahinder Singh>          
-- Create date: <10-Oct-2018>          
-- Description: <Create the procedure to Get the Cases Like PatientName and ReferrerID >          
-- =============================================                  
CREATE PROCEDURE [global].[Get_ReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount]    
@AdditionalParam varchar(10),        
@PatientName varchar(50),        
@ReferrerID bigint ,
@UserID bigint    
AS             

BEGIN   
 DECLARE @UserRole VARCHAR(50)

	SET @UserRole = (SELECT ReferrerTypes  FROM [global].[Users]  where UserID = @UserID)
 
 IF((@UserRole = 'Referrer Admin') OR (@UserRole = 'Referrer Project Admin'))
 BEGIN 
            if(ltrim(rtrim(@AdditionalParam))='AllCases')
			begin
			with PagedSearch as     
			(    
			SELECT       
			  ROW_NUMBER() over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID 
			  FROM [global].[ReferrerSupplierCases]        
						   WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
								  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
								  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%'))      
                                                      
								  and global.ReferrerSupplierCases.ReferrerID = @ReferrerID)-- and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID)                   
    
			SELECT COUNT(CaseID)'Count' FROM PagedSearch       
			 end

			else if(ltrim(rtrim(@AdditionalParam))='Active')
			begin
			with PagedSearch as     
			(    
			SELECT       
			  ROW_NUMBER() over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID    
			  FROM [global].[ReferrerSupplierCases]        
						   WHERE     ((( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
								  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
								  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')     ) 
                                                      
								  and global.ReferrerSupplierCases.ReferrerID = @ReferrerID )--- and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID )  
								 and global.ReferrerSupplierCases.WorkflowID  not in (210,212)  
			)                   
    
			SELECT COUNT(CaseID)'Count' FROM PagedSearch       
			end
			else
			begin
			with PagedSearch as     
			(    
			SELECT       
			  ROW_NUMBER() over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID   
			  FROM [global].[ReferrerSupplierCases]        
						   WHERE     ((( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
								  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
								  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      )
                                                       
								  and global.ReferrerSupplierCases.ReferrerID = @ReferrerID)---  and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID) 
								  and global.ReferrerSupplierCases.WorkflowID  in (210,212)   
			)                   
    
			SELECT COUNT(CaseID)'Count' FROM PagedSearch   
			end 
 END 
 ELSE IF(@UserRole = 'Referrer Project User')
 BEGIN
            if(ltrim(rtrim(@AdditionalParam))='AllCases')
			begin
			with PagedSearch as     
			(    
			SELECT       
			  ROW_NUMBER() over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID 
			  FROM [global].[ReferrerSupplierCases]        
						   WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
								  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
								  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%'))      
                                                      
								  and global.ReferrerSupplierCases.ReferrerID = @ReferrerID
								   and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID)                   
    
			SELECT COUNT(CaseID)'Count' FROM PagedSearch       
			 end

			else if(ltrim(rtrim(@AdditionalParam))='Active')
			begin
			with PagedSearch as     
			(    
			SELECT       
			  ROW_NUMBER() over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID    
			  FROM [global].[ReferrerSupplierCases]        
						   WHERE     ((( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
								  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
								  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')     ) 
                                                      
								  and global.ReferrerSupplierCases.ReferrerID = @ReferrerID 
								  and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID )  
								 and global.ReferrerSupplierCases.WorkflowID  not in (210,212)  
			)                   
    
			SELECT COUNT(CaseID)'Count' FROM PagedSearch       
			end
			else
			begin
			with PagedSearch as     
			(    
			SELECT       
			  ROW_NUMBER() over (order by CaseID asc) as Row,    
			[PatientID]      
			,[FirstName]      
			,[LastName]      
			,[CaseSubmittedDate]      
			,[PostCode]         
			,[CaseID]      
			,[CaseNumber]          
			,[WorkflowID]       
			,[CaseReferrerReferenceNumber] ,    
			[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID   
			  FROM [global].[ReferrerSupplierCases]        
						   WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
								  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
								  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%'))
                                                       
								  and global.ReferrerSupplierCases.ReferrerID = @ReferrerID and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID 
								  and global.ReferrerSupplierCases.WorkflowID  in (210,212)   
			)                   
    
			SELECT COUNT(CaseID)'Count' FROM PagedSearch   
			end 
  END
END 
			 



GO
/****** Object:  StoredProcedure [global].[Get_ReferrerSupplierCaseLikePatientNameAndSupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
          
-- =============================================          
-- Author:  <Pardeep Kumar>          
-- Create date: <11-Oct-2013>          
-- Description: <Create the procedure to Get the Cases Like PatientName and SupplierID >          
-- =============================================     
 -- Author:  <Mahinder Singh>          
-- Create date: <10-OCt-2018>          
-- Description: <UserPermission>          
-- =============================================       
---[global].[Get_ReferrerSupplierCaseLikePatientNameAndSupplierID]  't',634,499,0,100         
CREATE PROCEDURE [global].[Get_ReferrerSupplierCaseLikePatientNameAndSupplierID]       
@PatientName varchar(50),    
@SupplierID bigint ,  
@UserID bigint,  
@Skip bigint,    
@Take bigint         
AS         
    
    
BEGIN  
  DECLARE @UserRole VARCHAR(50)

 SET @UserRole = (SELECT SupplierTypes  FROM [global].[Users]  where UserID = @UserID)

  IF((@UserRole = 'Supplier Admin'))
  BEGIN   
		 with PagedSearch as     
		(    
		SELECT       
		  ROW_NUMBER() over (order by CaseID asc) as Row,    
		[PatientID]      
		,[FirstName]      
		,[LastName]      
		,[CaseSubmittedDate]      
		,[PostCode]         
		,[CaseID]      
		,[CaseNumber]          
		,[WorkflowID]       
		,[CaseReferrerReferenceNumber] ,    
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]    
		  FROM [global].[ReferrerSupplierCases]        
					   WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
							  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
							  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
							   )       
							  --and global.CaseSearch.WorkflowID in (70,180,190)                            
							  and global.ReferrerSupplierCases.SupplierID = @SupplierID      
							  --and global.ReferrerSupplierCases.SupplierAssignedUser = @UserID
		)                   
    
		SELECT * FROM PagedSearch prp         
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take     
  END
  ELSE IF(@UserRole = 'Supplier User')
  BEGIN  
		with PagedSearch as     
		(    
		SELECT       
		  ROW_NUMBER() over (order by CaseID asc) as Row,    
		[PatientID]      
		,[FirstName]      
		,[LastName]      
		,[CaseSubmittedDate]      
		,[PostCode]         
		,[CaseID]      
		,[CaseNumber]          
		,[WorkflowID]       
		,[CaseReferrerReferenceNumber] ,    
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]    
		  FROM [global].[ReferrerSupplierCases]        
					   WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')       
							  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
							  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')      
							   )       
							  --and global.CaseSearch.WorkflowID in (70,180,190)                            
							  and global.ReferrerSupplierCases.SupplierID = @SupplierID      
							  and global.ReferrerSupplierCases.SupplierAssignedUser = @UserID
		)                   
    
		SELECT * FROM PagedSearch prp         
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take 
  END
    
End

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
        
        
              
-- =============================================              
-- Author:  <Pardeep Kumar>              
-- Create date: <11-Oct-2013>              
-- Description: <Create the procedure to Get the CasesCount Like PatientName and SupplierID >              
-- =============================================         
-- Author:  <Mahinder Singh>          
-- Create date: <10-OCt-2018>          
-- Description: <UserPermission>          
-- =============================================                     
CREATE PROCEDURE [global].[Get_ReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount]           
@PatientName varchar(50),        
@SupplierID bigint,
@UserID bigint     
AS             
        
        
BEGIN  
  DECLARE @UserRole VARCHAR(50)

  SET @UserRole = (SELECT SupplierTypes  FROM [global].[Users]  where UserID = @UserID)

  IF((@UserRole = 'Supplier Admin'))
  BEGIN       
		with PagedSearch as         
		(        
		SELECT           
		  ROW_NUMBER() over (order by CaseID asc) as Row,        
		[PatientID]          
		,[FirstName]          
		,[LastName]          
		,[CaseSubmittedDate]          
		,[PostCode]             
		,[CaseID]          
		,[CaseNumber]              
		,[WorkflowID]           
		,[CaseReferrerReferenceNumber] ,        
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]        
		  FROM [global].[ReferrerSupplierCases]            
					   WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')           
							  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')          
							  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')          
							   )           
							  --and global.CaseSearch.WorkflowID in (70,180,190)                                
							  and global.ReferrerSupplierCases.SupplierID = @SupplierID 
							 --- and global.ReferrerSupplierCases.SupplierAssignedUser = @UserID         
		)                       
        
		SELECT COUNT(CaseID)'Count' FROM PagedSearch prp             
  END
  ELSE IF(@UserRole = 'Supplier User')
  BEGIN  
        with PagedSearch as         
		(        
		SELECT           
		  ROW_NUMBER() over (order by CaseID asc) as Row,        
		[PatientID]          
		,[FirstName]          
		,[LastName]          
		,[CaseSubmittedDate]          
		,[PostCode]             
		,[CaseID]          
		,[CaseNumber]              
		,[WorkflowID]           
		,[CaseReferrerReferenceNumber] ,        
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]        
		  FROM [global].[ReferrerSupplierCases]            
					   WHERE     (( global.ReferrerSupplierCases.FirstName LIKE  @PatientName + '%')           
							  or (global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')          
							  or (global.ReferrerSupplierCases.FirstName + ' '+ global.ReferrerSupplierCases.LastName LIKE  @PatientName + '%')          
							   )           
							  --and global.CaseSearch.WorkflowID in (70,180,190)                                
							  and global.ReferrerSupplierCases.SupplierID = @SupplierID 
							 and global.ReferrerSupplierCases.SupplierAssignedUser = @UserID         
		)                       
        
		SELECT COUNT(CaseID)'Count' FROM PagedSearch prp        
  END     
End

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
          
-- =============================================          
-- Author:  <Pardeep Kumar>          
-- Create date: <11-OCt-2013>          
-- Description: <Create the procedure to Get the Cases Get_CaseSearchLikeReferrerReferenceNumber And RefferrerID >          
-- =============================================        
-- Author:  <Mahinder Singh>          
-- Create date: <10-OCt-2018>          
-- Description: <User Permission >          
-- =============================================        
-- [global].[Get_ReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID] 'AllCases','rohit','',566,522,0,20   
CREATE PROCEDURE [global].[Get_ReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID]    
@AdditionalParam varchar(10),   
@ReferrerReferenceNumber varchar(50),    
@ReferrerID bigint , 
@UserID bigint,   
@Skip int,    
@Take int         
AS       
    
Begin    

 DECLARE @UserRole VARCHAR(50)

 SET @UserRole = (SELECT ReferrerTypes  FROM [global].[Users]  where UserID = @UserID)

  IF((@UserRole = 'Referrer Admin') OR (@UserRole = 'Referrer Project Admin'))
  BEGIN  
        if(ltrim(rtrim(@AdditionalParam))='AllCases')
		begin    
		with PagedSearch as         
		(        
		SELECT           
		  ROW_NUMBER() over (order by CaseID asc) as Row,        
		[PatientID]          
		,[FirstName]          
		,[LastName]          
		,[CaseSubmittedDate]          
		,[PostCode]             
		,[CaseID]          
		,[CaseNumber]              
		,[WorkflowID]     
		,[CaseReferrerReferenceNumber] ,        
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID        
		  FROM [global].[ReferrerSupplierCases]            
						WHERE (global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')       
						and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID   
		)                       
        
		SELECT * FROM PagedSearch prp           
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take           
		end   
 

		 else if(ltrim(rtrim(@AdditionalParam))='Active')
		begin
		with PagedSearch as         
		(        
		SELECT           
		  ROW_NUMBER() over (order by CaseID asc) as Row,        
		[PatientID]          
		,[FirstName]          
		,[LastName]          
		,[CaseSubmittedDate]          
		,[PostCode]             
		,[CaseID]          
		,[CaseNumber]              
		,[WorkflowID]           
		,[CaseReferrerReferenceNumber] ,        
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID       
		  FROM [global].[ReferrerSupplierCases]            
						WHERE ( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')       
						and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID    
						and global.ReferrerSupplierCases.WorkflowID  not in (210,212)  
		)                       
        
		SELECT * FROM PagedSearch prp           
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take 
		end

		else
		begin
		with PagedSearch as         
		(        
		SELECT           
		  ROW_NUMBER() over (order by CaseID asc) as Row,        
		[PatientID]          
		,[FirstName]          
		,[LastName]          
		,[CaseSubmittedDate]          
		,[PostCode]             
		,[CaseID]          
		,[CaseNumber]              
		,[WorkflowID]           
		,[CaseReferrerReferenceNumber] ,        
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID        
		  FROM [global].[ReferrerSupplierCases]            
						WHERE ( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')       
						and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID   
						and global.ReferrerSupplierCases.WorkflowID  in (210,212)  
				
		)                       
        
		SELECT * FROM PagedSearch prp           
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take 
		end
  END
  ELSE IF(@UserRole = 'Referrer Project User')
  BEGIN 
       if(ltrim(rtrim(@AdditionalParam))='AllCases')
		begin    
		with PagedSearch as         
		(        
		SELECT           
		  ROW_NUMBER() over (order by CaseID asc) as Row,        
		[PatientID]          
		,[FirstName]          
		,[LastName]          
		,[CaseSubmittedDate]          
		,[PostCode]             
		,[CaseID]          
		,[CaseNumber]              
		,[WorkflowID]     
		,[CaseReferrerReferenceNumber] ,        
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID        
		  FROM [global].[ReferrerSupplierCases]            
						WHERE (global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')       
						and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID   and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID  
		)                       
        
		SELECT * FROM PagedSearch prp           
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take           
		end   
 

		 else if(ltrim(rtrim(@AdditionalParam))='Active')
		begin
		with PagedSearch as         
		(        
		SELECT           
		  ROW_NUMBER() over (order by CaseID asc) as Row,        
		[PatientID]          
		,[FirstName]          
		,[LastName]          
		,[CaseSubmittedDate]          
		,[PostCode]             
		,[CaseID]          
		,[CaseNumber]              
		,[WorkflowID]           
		,[CaseReferrerReferenceNumber] ,        
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID       
		  FROM [global].[ReferrerSupplierCases]            
						WHERE ( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')       
						and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID   and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID  
						and global.ReferrerSupplierCases.WorkflowID  not in (210,212)  
		)                       
        
		SELECT * FROM PagedSearch prp           
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take 
		end

		else
		begin
		with PagedSearch as         
		(        
		SELECT           
		  ROW_NUMBER() over (order by CaseID asc) as Row,        
		[PatientID]          
		,[FirstName]          
		,[LastName]          
		,[CaseSubmittedDate]          
		,[PostCode]             
		,[CaseID]          
		,[CaseNumber]              
		,[WorkflowID]           
		,[CaseReferrerReferenceNumber] ,        
		[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID        
		  FROM [global].[ReferrerSupplierCases]            
						WHERE ( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')       
						and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID  and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID  
						and global.ReferrerSupplierCases.WorkflowID  in (210,212)  
				
		)                       
        
		SELECT * FROM PagedSearch prp           
		WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take 
		end
  END
		 

End 

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
          
-- =============================================          
-- Author:  <Pardeep Kumar>          
-- Create date: <11-OCt-2013>          
-- Description: <Create the procedure to Get the CasesCount Get_CaseSearchLikeReferrerReferenceNumber And RefferrerID >          
-- =============================================        
 -- Author:  <Mahinder Singh>          
-- Create date: <10-OCt-2018>          
-- Description: <Create the procedure to Get the Cases Get_CaseSearchLikeReferrerReferenceNumber And RefferrerID >          
-- =============================================             
CREATE PROCEDURE [global].[Get_ReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount]  
@AdditionalParam varchar(10),     
@ReferrerReferenceNumber varchar(50),    
@ReferrerID bigint ,    
@UserID bigint
AS       
    
Begin   
DECLARE @UserRole VARCHAR(50)

 SET @UserRole = (SELECT ReferrerTypes  FROM [global].[Users]  where UserID = @UserID)

  IF((@UserRole = 'Referrer Admin') OR (@UserRole = 'Referrer Project Admin'))
  BEGIN 
			  if(ltrim(rtrim(@AdditionalParam))='AllCases')
				begin
				with PagedSearch as     
				(    
				SELECT           
					ROW_NUMBER() over (order by CaseID asc) as Row,        
				[PatientID]          
				,[FirstName]          
				,[LastName]          
				,[CaseSubmittedDate]          
				,[PostCode]             
				,[CaseID]          
				,[CaseNumber]              
				,[WorkflowID]           
				,[CaseReferrerReferenceNumber] ,        
				[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID       
					FROM [global].[ReferrerSupplierCases]            
								WHERE ( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')   
                     
								and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID ---   and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID 
				)                      
    
				SELECT COUNT(CaseID)'Count' FROM PagedSearch       
					end

				else if(ltrim(rtrim(@AdditionalParam))='Active')
				begin
				with PagedSearch as     
				(    
				SELECT           
					ROW_NUMBER() over (order by CaseID asc) as Row,        
				[PatientID]          
				,[FirstName]          
				,[LastName]          
				,[CaseSubmittedDate]          
				,[PostCode]             
				,[CaseID]          
				,[CaseNumber]              
				,[WorkflowID]           
				,[CaseReferrerReferenceNumber] ,        
				[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID       
					FROM [global].[ReferrerSupplierCases]            
								WHERE (( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')   
                     
								and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID ) --- and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID  )
									and global.ReferrerSupplierCases.WorkflowID  not in (210,212) 
				)         
				SELECT COUNT(CaseID)'Count' FROM PagedSearch       
				end
				else
				begin
				with PagedSearch as     
				(    
				SELECT           
					ROW_NUMBER() over (order by CaseID asc) as Row,        
				[PatientID]          
				,[FirstName]          
				,[LastName]          
				,[CaseSubmittedDate]          
				,[PostCode]             
				,[CaseID]          
				,[CaseNumber]              
				,[WorkflowID]           
				,[CaseReferrerReferenceNumber] ,        
				[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID        
					FROM [global].[ReferrerSupplierCases]            
								WHERE (( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')   
                     
								and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID  ) --- and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID) 
										and global.ReferrerSupplierCases.WorkflowID  in (210,212)   
				)                   
    
				SELECT COUNT(CaseID)'Count' FROM PagedSearch   
				end
  END
  ELSE IF(@UserRole = 'Referrer Project User')
  BEGIN 
                        if(ltrim(rtrim(@AdditionalParam))='AllCases')
						begin
						with PagedSearch as     
						(    
						SELECT           
						  ROW_NUMBER() over (order by CaseID asc) as Row,        
						[PatientID]          
						,[FirstName]          
						,[LastName]          
						,[CaseSubmittedDate]          
						,[PostCode]             
						,[CaseID]          
						,[CaseNumber]              
						,[WorkflowID]           
						,[CaseReferrerReferenceNumber] ,        
						[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID       
						  FROM [global].[ReferrerSupplierCases]            
										WHERE ( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')   
                     
										and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID   and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID 
						)                      
    
						SELECT COUNT(CaseID)'Count' FROM PagedSearch       
						 end

						else if(ltrim(rtrim(@AdditionalParam))='Active')
						begin
						with PagedSearch as     
						(    
						SELECT           
						  ROW_NUMBER() over (order by CaseID asc) as Row,        
						[PatientID]          
						,[FirstName]          
						,[LastName]          
						,[CaseSubmittedDate]          
						,[PostCode]             
						,[CaseID]          
						,[CaseNumber]              
						,[WorkflowID]           
						,[CaseReferrerReferenceNumber] ,        
						[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID       
						  FROM [global].[ReferrerSupplierCases]            
										WHERE ( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')   
                     
										and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID   and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID  
										 and global.ReferrerSupplierCases.WorkflowID  not in (210,212) 
						)         
						SELECT COUNT(CaseID)'Count' FROM PagedSearch       
						end
						else
						begin
						with PagedSearch as     
						(    
						SELECT           
						  ROW_NUMBER() over (order by CaseID asc) as Row,        
						[PatientID]          
						,[FirstName]          
						,[LastName]          
						,[CaseSubmittedDate]          
						,[PostCode]             
						,[CaseID]          
						,[CaseNumber]              
						,[WorkflowID]           
						,[CaseReferrerReferenceNumber] ,        
						[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID],InitialAssessmentDate,FinalAssessmentDate,InitialCaseAssessmentDetailID,FinalCaseAssessmentDetailID,InitialAssessmentServiceID,FinalAssessmentServiceID        
						  FROM [global].[ReferrerSupplierCases]            
										WHERE ( global.ReferrerSupplierCases.CaseReferrerReferenceNumber LIKE  @ReferrerReferenceNumber + '%')  
										and   global.ReferrerSupplierCases.ReferrerID = @ReferrerID   and global.ReferrerSupplierCases.ReferrerAssignedUser = @UserID
											  and global.ReferrerSupplierCases.WorkflowID  in (210,212)   
						)                   
    
						SELECT COUNT(CaseID)'Count' FROM PagedSearch   
						end
  END

End

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerUsersByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Get_ReferrerUsersByCaseID]
@CaseID int
AS
BEGIN
	SET NOCOUNT ON;



   --- SELECT * FROM global.Users WHERE ReferrerLocationID = @ReferrerLocationID 
	SELECT * FROM global.Users WHERE UserID in (
	select UserID from [global].[CaseContacts] where CaseID = (SELECT CaseID FROM global.Cases where CaseID = @CaseID) )    
	
END

 

GO
/****** Object:  StoredProcedure [global].[Get_ReferrerUsersByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Get_ReferrerUsersByID]
@ReferrerID INT
AS
BEGIN
	SET NOCOUNT ON;
	 SELECT * FROM global.Users WHERE ReferrerID=@ReferrerID
END

 

GO
/****** Object:  StoredProcedure [global].[Get_SolicitorByPatientID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
----[global].[Get_SolicitorByPatientID] 959
CREATE PROCEDURE [global].[Get_SolicitorByPatientID]
	-- Add the parameters for the stored procedure here	
	@PatientID INT
	
AS
BEGIN	
SELECT  global.Solicitors.SolicitorID, global.Solicitors.CompanyName, global.Solicitors.Address, global.Solicitors.Phone, global.Solicitors.Email, global.Solicitors.FirstName, global.Solicitors.LastName, global.Solicitors.PostCode, global.Solicitors.Fax, 
global.Solicitors.City,global.Solicitors.Region, global.Solicitors.IsReferralUnderJointInstruction, 
            global.Solicitors.ReferenceNumber
FROM    global.Patients INNER JOIN
            global.Solicitors ON global.Patients.SolicitorID = global.Solicitors.SolicitorID AND global.Patients.SolicitorID = global.Solicitors.SolicitorID AND global.Patients.SolicitorID = global.Solicitors.SolicitorID AND 
            global.Patients.SolicitorID = global.Solicitors.SolicitorID AND global.Patients.SolicitorID = global.Solicitors.SolicitorID AND global.Patients.SolicitorID = global.Solicitors.SolicitorID
WHERE  (global.Patients.PatientID = @PatientID)
END

GO
/****** Object:  StoredProcedure [global].[Get_SolicitorBySolicitorID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal Sen
-- Create date: 01/17/2014
-- Description:	alter PROCEDURE for GetSolicitorBySolicitorID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [global].[Get_SolicitorBySolicitorID] 
	-- Add the parameters for the stored procedure here	
	@SolicitorID INT
	
AS
BEGIN	
SELECT *
  FROM [global].[Solicitors]
  where SolicitorID=@SolicitorID
END


GO
/****** Object:  StoredProcedure [global].[Get_TreatmentCategoriesPricingTypesByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--=========================================================
-- Create By : Vishal sen    
-- Create date: 12/11/2013    
-- updated Version : 1.0  
-- Description: create sp Get_PricingTypesByTreatmentCategoryID
--=========================================================


CREATE PROCEDURE [global].[Get_TreatmentCategoriesPricingTypesByTreatmentCategoryID] 
(
 @TreatmentCategoryID INT 
)
AS  
BEGIN  

 SELECT *   FROM  [lookup].[TreatmentCategoriesPricingTypes]  


where [TreatmentCategoryID]= @TreatmentCategoryID
END  

GO
/****** Object:  StoredProcedure [global].[Get_TreatmentPeriodType]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 06-26-2018
-- Description:	Get TreatmentPeriodType
-- =============================================
CREATE PROCEDURE [global].[Get_TreatmentPeriodType]
AS
BEGIN	
	SET NOCOUNT ON;
	Select * from lookup.TreatmentPeriodType    
END


GO
/****** Object:  StoredProcedure [global].[Get_TreatmentSessionByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author: Rkumar
-- Create date: 08-06-2018
-- Description: Get Treatment Session By CaseID
-- =============================================    
-- [global].[Get_TreatmentSessionByCaseID] 4381
CREATE PROCEDURE [global].[Get_TreatmentSessionByCaseID] (
@CaseID int
)
as
    begin
		Select 
		(SELECT        count (*) 
                      
		FROM            global.CaseTreatmentPricing INNER JOIN
								 referrer.ReferrerProjectTreatmentPricing ON global.CaseTreatmentPricing.ReferrerPricingID = referrer.ReferrerProjectTreatmentPricing.PricingID INNER JOIN
								 lookup.PricingTypes ON referrer.ReferrerProjectTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID 
		WHERE        (global.CaseTreatmentPricing.CaseID = @CaseID) and  lookup.PricingTypes.PricingTypeID in(4,5) 
		
		) as AllTreatmentSessions,
		(
		SELECT  STUFF((SELECT '; ' + CAST(convert(varchar(10),global.CaseTreatmentPricing.DateOfService,101) AS VARCHAR(10))  
				 FROM            global.CaseTreatmentPricing INNER JOIN
								 referrer.ReferrerProjectTreatmentPricing ON global.CaseTreatmentPricing.ReferrerPricingID = referrer.ReferrerProjectTreatmentPricing.PricingID INNER JOIN
								 lookup.PricingTypes ON referrer.ReferrerProjectTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID 
			WHERE        (global.CaseTreatmentPricing.CaseID = @CaseID) and  lookup.PricingTypes.PricingTypeID = 4 and isnull(AuthorizationStatus,0)= 1
			FOR XML PATH(''), TYPE)
			.value('.','NVARCHAR(MAX)'),1,2,' ') ) as ShowAllAttendedSessionsDateOfService,
			   
	
		(SELECT        count (*) 
                      
		FROM            global.CaseTreatmentPricing INNER JOIN
								 referrer.ReferrerProjectTreatmentPricing ON global.CaseTreatmentPricing.ReferrerPricingID = referrer.ReferrerProjectTreatmentPricing.PricingID INNER JOIN
								 lookup.PricingTypes ON referrer.ReferrerProjectTreatmentPricing.PricingTypeID = lookup.PricingTypes.PricingTypeID 
		WHERE        (global.CaseTreatmentPricing.CaseID = @CaseID) and   ((isnull(PatientDidNotAttend,0)= 1) or isnull(WasAbandoned,0)= 1)
		) as AllFailedTreatmentSessions
 end

GO
/****** Object:  StoredProcedure [global].[Get_UnsuccessfulContactDate]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_UnsuccessfulContactDate] 
(
@CaseID INT
)
AS 
SELECT ContactAttemptDate FROM global.CasePatientContactAttempts WHERE CaseID=@CaseID

GO
/****** Object:  StoredProcedure [global].[Get_UserByUsername]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Harpreet Singh>
-- Create date: <10-26-2012,,>
-- Description:	<The Storeprocedure will return the user credentials based upon Username,,>
-- =============================================
CREATE PROCEDURE [global].[Get_UserByUsername]	
  ---Add Parameters here    
	@username varchar(100)

as
 begin

 --Insert Statements here

  --select userid,Username,Password from Users where Username=@username	
    SELECT     * FROM            global.Users where Username=@username	

  end
	


GO
/****** Object:  StoredProcedure [global].[Get_UserByUserTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anuj Batra
-- Create date: <12-28-2012,,>
-- Description:	<The Storeprocedure will return the users based upon UserTypeID,,>
-- =============================================
CREATE PROCEDURE [global].[Get_UserByUserTypeID]
  ---Add Parameters here    
	@UserTypeID int

as
 begin

 --Insert Statements here

       SELECT        UserID, Username, null as Password, FirstName, LastName, UserTypeID, IsLocked, SupplierTypes, SupplierID, ReferrerTypes, ReferrerID, ReferrerLocationID, Email, Fax, 
                         Telephone, LastLoginDate, FailedAttemptCount, DateAdded, PasswordExpirationDate, UserSessionID,PasswordOTP
FROM            global.Users where UserTypeID=@UserTypeID	

  end
	


GO
/****** Object:  StoredProcedure [global].[Get_UserEmailsByCaseContactByCaseID ]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Mahinder Singh  
-- Create date: 05-JULY-2018 
-- Description: Create stored procedure to Get multiple UserEmails By CaseContacts By CaseID  in email section
-- Version: 1.0  
-- =============================================  
--[global].[Get_UserEmailsByCaseContactByCaseID ] 1044
CREATE PROCEDURE [global].[Get_UserEmailsByCaseContactByCaseID ]
	@CaseID int
AS
	SET NOCOUNT ON
	SELECT Email FROM  [global].[Users] WHERE UserID IN(
                                                       SELECT UserID   FROM  [global].[CaseContacts] WHERE CaseID = @CaseID)
	RETURN


GO
/****** Object:  StoredProcedure [global].[Get_UserExistsByName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Get_UserExistsByName]    
 @UserName varchar(100)  
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here    
 SELECT ISNULL((SELECT CONVERT(BIT,1)	
      FROM [global].Users   
      WHERE [Username] = @UserName ),CONVERT(BIT,0))   
END 

GO
/****** Object:  StoredProcedure [global].[Get_UserInfoByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*************************************************************/  
/*                                                           */  
/*  Procedure Name:  Get_UserInfoByUserID                    */  
/*                                                           */  
/*  Version:  1.0                                            */  
/*                                                           */  
/*  Purpose:  Select records from Users(global) with given   */  
/*           parameters                                      */  
/*                                                           */  
/*  Input Parameters:  @Userid                               */  
/*  Output:  Records from User(global) Table                 */  
/*                                                           */  
/*  Returns:  Rows with data                                 */  
/*                                                           */  
/*  Dependencies:                                            */  
/*                                                           */  
/*        Tables:  ITS.dbo.Users(global)                     */  
/*                                                           */  
/*    Procedures:   none                                     */  
/*    Functions:    none                                     */  
/*                                                           */  
/*  Implementation:                                          */  
/*     - Select records from Users(global) with given        */  
/*           parameters                                      */  
/*                                                           */  
/*  Revision History:                                        */  
/*                                                           */  
/*     1.0 – 10/26/2012 Robin Singh                          */  
/*           updated documentation                           */  
/*                                                           */
/*     1.1 – 10/27/2012 Pardeep Kumar                        */  
/*           Changes done to retreive all records            */  
/*                                                           */
/*************************************************************/ 


CREATE PROCEDURE [global].[Get_UserInfoByUserID] 
(
--Add Parameters here    
@UserID int
)

AS
BEGIN 
SET NOCOUNT ON; 

--Retrieve User Information from single table Users(Global)

	    SELECT     * FROM [global].Users 
	WHERE UserID=@UserID

END


GO
/****** Object:  StoredProcedure [global].[Get_UserRecordByEmailAndUserName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0
-- =============================================  
-- Author:  Jasingh
-- Create date: 25-jan-2018
-- Description: Added Procedure Update/reset User Password and UserName
-- [global].[Get_UserRecordByEmailIDAndUserName] 'rkumar@vsaindia.com','rkumar'
-- =============================================  


CREATE PROCEDURE [global].[Get_UserRecordByEmailAndUserName]  
   (
   @EmailID varchar(100),
   @Username Varchar(50)
    )  
AS  
BEGIN
	    SELECT    * FROM global.Users where  Email = @EmailID  AND  Username = @Username
END

GO
/****** Object:  StoredProcedure [global].[Get_UserRecordByEmailID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0
-- =============================================  
-- Author:  Rkumar
-- Create date: 09-May-2018
-- Description: Added Procedure Update/reset User Password

-- =============================================  


CREATE PROCEDURE [global].[Get_UserRecordByEmailID]  
   (
   @EmailID varchar(100)
    )  
AS  
BEGIN
	    SELECT    * FROM global.Users where  Email = @EmailID 
END

GO
/****** Object:  StoredProcedure [global].[Get_UsersLikeUsername]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vishal Sen>
-- Create date: <10-26-2012>
-- Description:	<This Procedure Used For Autocomplete UserName Task NO: 11>
-- Version	:	1.0	
-- =============================================
-- =============================================
-- Author:		<Vijay Kumar>
-- Create date: <10-26-2012>
-- Description:	<Cahnge the Select Protion To * >
-- Version	:	1.0	
-- =============================================

	
CREATE PROCEDURE [global].[Get_UsersLikeUsername]

/*Here @UserName Add ParameterHere For AutoComplete*/

 @UserName NVARCHAR(100)

AS 
    BEGIN
	    SELECT        UserID, Username, null as Password, FirstName, LastName, UserTypeID, IsLocked, SupplierTypes, SupplierID, ReferrerTypes, ReferrerID, ReferrerLocationID, Email, Fax, 
                         Telephone, LastLoginDate, FailedAttemptCount, DateAdded, PasswordExpirationDate, UserSessionID,PasswordOTP
FROM            global.Users
	WHERE [Username] LIKE (@UserName + '%')

 END



GO
/****** Object:  StoredProcedure [global].[Get_UsersRecentlyAdded]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 07/15/2013
-- Description:	Get_UsersRecentlyAdded
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [global].[Get_UsersRecentlyAdded]
	-- Add the parameters for the stored procedure here
AS
BEGIN	
	
	
	SELECT        TOP (10) UserID, Username, null as Password, FirstName, LastName, UserTypeID, IsLocked, SupplierTypes, SupplierID, ReferrerTypes, ReferrerID, ReferrerLocationID, 
                         Email, Fax, Telephone, LastLoginDate, FailedAttemptCount, DateAdded, PasswordExpirationDate, UserSessionID,PasswordOTP
FROM            global.Users
    ORDER BY [global].Users.DateAdded DESC
   
    END
 


GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  <Satya>    
-- Create date: <07-15-2013>    
-- Description: < Paged Get UserTypeUsers Like Name>    
-- Version : 1.0     
-- =============================================    
     
CREATE PROCEDURE [global].[Get_UserTypeUsersLikeName]
 @Name NVARCHAR(100),    
 @Skip INT,        
 @Take INT     
    
AS     
--declare @Name NVARCHAR(100) ='m'  
--declare  @Skip INT = 0  
--declare @Take INT     = 12  
   
BEGIN    
WITH UserMatched AS    
(    
 SELECT ROW_NUMBER() Over (Order By global.Users.UserID) As ROW,  
 global.Users.ReferrerID,global.Users.SupplierID,  
 lookup.UserTypes.UserType,global.Users.UserID, global.Users.Username, global.Users.FirstName, global.Users.LastName, global.Users.UserTypeID, global.Users.Email    
  ,'UserTypeName' =
    CASE 
    WHEN supplier.Suppliers.SupplierName IS NOT NULL THEN
	supplier.Suppliers.SupplierName
	WHEN Referrer.Referrers.ReferrerName IS NOT NULL THEN
	Referrer.Referrers.ReferrerName
    ELSE 
        NULL
    END
 FROM  global.Users INNER JOIN    
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID 
  LEFT OUTER JOIN supplier.Suppliers ON  supplier.Suppliers.SupplierID = global.Users.SupplierID 
LEFT OUTER JOIN Referrer.Referrers ON  Referrer.Referrers.ReferrerID = global.Users.ReferrerID    
 WHERE (  ([FirstName] LIKE (@Name + '%'))  OR ([LastName] LIKE (@Name + '%')) OR (([FirstName]+' '+[LastName]) LIKE (@Name + '%')))    
  ), Result as (  
SELECT * FROM UserMatched prp      
WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take   
)   
 SELECT * FROM UserMatched prp      
WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take  
   
    
 END    
    
    

GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Satya>
-- Create date: <15-07-2013>
-- Description:	<This Procedure Used for Count UserTypeUsers Like by   name >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [global].[Get_UserTypeUsersLikeNameCount] -- 'i'

 @Name NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  FROM  global.Users INNER JOIN
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID
 WHERE (  ([FirstName] LIKE (@Name + '%'))  OR ([LastName] LIKE (@Name + '%')) OR (([FirstName]+' '+[LastName]) LIKE (@Name + '%')))
 
 End

GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeReferrerName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Robin Singh>    
-- Create date: <07-22-2013>    
-- Description: < Paged Get UserTypeUsers Like ReferrerName>    
-- Version : 1.0     
-- =============================================    
     
CREATE PROCEDURE [global].[Get_UserTypeUsersLikeReferrerName]    
 @ReferrerName NVARCHAR(100),    
 @Skip INT,        
 @Take INT     
    
AS     
BEGIN    
WITH UserMatched AS    
(    
SELECT ROW_NUMBER() Over (Order By global.Users.UserID) As ROW,  
global.Users.ReferrerID,global.Users.SupplierID,  
lookup.UserTypes.UserType,global.Users.UserID, global.Users.Username, global.Users.FirstName, global.Users.LastName, global.Users.UserTypeID, global.Users.Email, referrer.Referrers.ReferrerName AS [UserTypeName]    
 FROM  global.Users INNER JOIN    
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID INNER JOIN     
 referrer.Referrers ON global.Users.ReferrerID = referrer.Referrers.ReferrerID     
     
 WHERE referrer.Referrers.ReferrerName LIKE (@ReferrerName + '%')    
  )    
SELECT * FROM UserMatched prp     
WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take    
    
 END    
    
    
     

GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeReferrerNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Robin Singh>
-- Create date: <22-07-2013>
-- Description:	<This Procedure Used for Count UserTypeUsers Like by  ReferrerName >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [global].[Get_UserTypeUsersLikeReferrerNameCount] 

 @ReferrerName NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  FROM  global.Users INNER JOIN
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID
 INNER JOIN 
 referrer.Referrers ON global.Users.ReferrerID = referrer.Referrers.ReferrerID 
 WHERE referrer.Referrers.ReferrerName LIKE (@ReferrerName + '%')

 
 End


GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeSupplierName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  <Robin Singh>    
-- Create date: <07-22-2013>    
-- Description: < Paged Get UserTypeUsers Like SupplierName>    
-- Version : 1.0     
-- =============================================    
     
CREATE PROCEDURE [global].[Get_UserTypeUsersLikeSupplierName]   
 @SupplierName NVARCHAR(100),    
 @Skip INT,        
 @Take INT     
    
AS     
BEGIN    
WITH UserMatched AS    
(    
SELECT ROW_NUMBER() Over (Order By global.Users.UserID) As ROW,  
global.Users.ReferrerID,global.Users.SupplierID,  
lookup.UserTypes.UserType,global.Users.UserID, global.Users.Username, global.Users.FirstName, global.Users.LastName, global.Users.UserTypeID, global.Users.Email,supplier.Suppliers.SupplierName as [UserTypeName]
 FROM  global.Users INNER JOIN    
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID INNER JOIN     
 supplier.Suppliers ON global.Users.SupplierID = supplier.Suppliers.SupplierID     
     
 WHERE supplier.Suppliers.SupplierName LIKE (@SupplierName + '%')    
  )    
SELECT * FROM UserMatched prp     
WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take    
    
 END    
    
    
     

GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeSupplierNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Robin Singh>
-- Create date: <22-07-2013>
-- Description:	<This Procedure Used for Count UserTypeUsers Like by  SupplierName >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [global].[Get_UserTypeUsersLikeSupplierNameCount] 

 @SupplierName NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  FROM  global.Users INNER JOIN
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID
 INNER JOIN 
 supplier.Suppliers ON global.Users.SupplierID = supplier.Suppliers.SupplierID 
 
 WHERE supplier.Suppliers.SupplierName LIKE (@SupplierName + '%')

 
 End


GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeUsername]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  <Satya>    
-- Create date: <07-15-2013>    
-- Description: < Paged Get UserTypeUsers Like Username>    
-- Version : 1.0     
-- =============================================    
     
CREATE PROCEDURE [global].[Get_UserTypeUsersLikeUsername]  
 @UserName NVARCHAR(100),    
 @Skip INT,        
 @Take INT     
    
AS     
  
BEGIN    
WITH UserMatched AS    
(    
SELECT ROW_NUMBER() Over (Order By global.Users.UserID) As ROW,  
global.Users.ReferrerID,global.Users.SupplierID,  
lookup.UserTypes.UserType,global.Users.UserID, global.Users.Username, global.Users.FirstName, global.Users.LastName, global.Users.UserTypeID, global.Users.Email    
 ,'UserTypeName' =
    CASE 
    WHEN supplier.Suppliers.SupplierName IS NOT NULL THEN
	supplier.Suppliers.SupplierName
	WHEN Referrer.Referrers.ReferrerName IS NOT NULL THEN
	Referrer.Referrers.ReferrerName
    ELSE 
        NULL
    END
 FROM  global.Users INNER JOIN    
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID 
 LEFT OUTER JOIN supplier.Suppliers ON  supplier.Suppliers.SupplierID = global.Users.SupplierID 
LEFT OUTER JOIN Referrer.Referrers ON  Referrer.Referrers.ReferrerID = global.Users.ReferrerID    
 WHERE [Username] LIKE (@UserName + '%')    
  )    
SELECT * FROM UserMatched prp      
WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take    
    
 END    
    
    

GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeUsernameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Satya>
-- Create date: <15-07-2013>
-- Description:	<This Procedure Used for Count UserTypeUsers Like by  TreatmentCategoryType >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [global].[Get_UserTypeUsersLikeUsernameCount] 

 @UserName NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  FROM  global.Users INNER JOIN
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID
 WHERE [Username] LIKE (@UserName + '%')
 
 End

GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeUserType]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  <Satya>    
-- Create date: <07-15-2013>    
-- Description: < Paged Get UserTypeUsers Like UserTYPE>    
-- Version : 1.0     
-- =============================================    
     
CREATE PROCEDURE [global].[Get_UserTypeUsersLikeUserType]  
 @UserType NVARCHAR(100),    
 @Skip INT,        
 @Take INT     
    
AS     
  
BEGIN    
WITH UserMatched AS    
(    
SELECT ROW_NUMBER() Over (Order By global.Users.UserID) As ROW,  
global.Users.ReferrerID,global.Users.SupplierID,lookup.UserTypes.UserType,global.Users.UserID, global.Users.Username, global.Users.FirstName, global.Users.LastName, global.Users.UserTypeID, global.Users.Email    
 ,'UserTypeName' =
    CASE 
    WHEN supplier.Suppliers.SupplierName IS NOT NULL THEN
	supplier.Suppliers.SupplierName
	WHEN Referrer.Referrers.ReferrerName IS NOT NULL THEN
	Referrer.Referrers.ReferrerName
    ELSE 
        NULL
    END
     FROM  global.Users INNER JOIN    
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID    
LEFT OUTER JOIN supplier.Suppliers ON  supplier.Suppliers.SupplierID = global.Users.SupplierID 
LEFT OUTER JOIN Referrer.Referrers ON  Referrer.Referrers.ReferrerID = global.Users.ReferrerID 
 WHERE [UserType] LIKE (@UserType + '%')    
  )    
SELECT * FROM UserMatched prp          
WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take    
    
 END    
    
    -- 

GO
/****** Object:  StoredProcedure [global].[Get_UserTypeUsersLikeUserTypeCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Author:		<Satya>
-- Create date: <15-07-2013>
-- Description:	<This Procedure Used for Count UserTypeUsers Like by   Username >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [global].[Get_UserTypeUsersLikeUserTypeCount]  --'i'

 @UserType NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  FROM  global.Users INNER JOIN
 lookup.UserTypes ON global.Users.UserTypeID = lookup.UserTypes.UserTypeID
 WHERE [UserType] LIKE (@UserType + '%')
 
 End

GO
/****** Object:  StoredProcedure [global].[global.Get_ReferrerSupplierCaseLikeCaseNumberAndSupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
          
-- =============================================          
-- Author:  <Pardeep Kumar>          
-- Create date: <11-Oct-2013>          
-- Description: <Create the procedure to Get the Cases Like CaseNumber and SupplierID >          
-- =============================================     
         
         
         
         
CREATE PROCEDURE [global].[global.Get_ReferrerSupplierCaseLikeCaseNumberAndSupplierID]       
@CaseNumber varchar(100),    
@SupplierID bigint ,    
@Skip bigint,    
@Take bigint         
AS         
    
    
Begin    
with PagedSearch as     
(    
SELECT       
  ROW_NUMBER() over (order by CaseID asc) as Row,    
[PatientID]      
,[FirstName]      
,[LastName]      
,[CaseSubmittedDate]      
,[PostCode]         
,[CaseID]      
,[CaseNumber]          
,[WorkflowID]       
,[CaseReferrerReferenceNumber] ,    
[HomePhone],[WorkPhone],[MobilePhone],[ReferrerID],[SupplierID]    
  FROM [global].[ReferrerSupplierCases]        
               WHERE     (global.ReferrerSupplierCases.CaseNumber LIKE  @CaseNumber + '%')                                 
                      and global.ReferrerSupplierCases.SupplierID = @SupplierID      
)                   
    
SELECT * FROM PagedSearch prp         
WHERE prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take      
    
End

GO
/****** Object:  StoredProcedure [global].[Reset_UserPassword]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0
-- =============================================  
-- Author:  Rkumar
-- Create date: 09-May-2018
-- Description: Added Procedure Update/reset User Password
-- Version : 1.0
-- =============================================  

-- =============================================  
-- Author:  Rkumar
-- Create date: 10-July-2018
-- Description: #3307- Security - Password Reset Function
-- Version : 1.1
-- =============================================  


CREATE PROCEDURE [global].[Reset_UserPassword]  
   (@UserId INT, 
    @UserPasssword  varchar(100) 
    )  
AS  
BEGIN
	UPDATE global.Users SET Password = @UserPasssword, FailedAttemptCount = 0 ,	PasswordExpirationDate = DATEADD(DD,90,getdate()), PasswordOTP= null 	 where UserID = @UserId
END

GO
/****** Object:  StoredProcedure [global].[Reset_UserSessionID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0
-- =============================================  
-- Author:  Rkumar
-- Create date: 29-Oct-2018
-- Description: Reset User Session ID
-- Version : 1.0
-- =============================================  
 


CREATE PROCEDURE [global].[Reset_UserSessionID]  
   (
		@UserID int
   )  
AS  
BEGIN
	BEGIN TRANSACTION [Trans1]  
		BEGIN TRY
			DECLARE @UserSessionID as varchar(50) = null
			SET @UserSessionID = (Select global.Users.UserSessionID from global.Users where UserID = @UserID)
			UPDATE global.Users SET UserSessionID = null where UserID = @UserID
			DELETE from [ITSSessionState].[dbo].[ASPStateTempSessions] where SessionID like (ltrim(rtrim(@UserSessionID)) + '%')
		COMMIT TRANSACTION	[Trans1]			
    END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION [Tran1]
	END CATCH		
END

GO
/****** Object:  StoredProcedure [global].[Update_AssessmentServiceIDByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vishal Sen
-- Create date: 20-08-2013
-- Description:	Sp to Update_AssessmentServiceIDByCaseID
-- =============================================
CREATE PROCEDURE  [global].[Update_AssessmentServiceIDByCaseID](
	-- Add the parameters for the stored procedure here
	@CaseID int ,
	@AssessmentServiceID INT	
	)
AS
BEGIN
	update global.CaseAssessments set AssessmentServiceID=@AssessmentServiceID
	where CaseID=@CaseID
	
END


GO
/****** Object:  StoredProcedure [global].[Update_CaseAndReferrerDocumentByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		jasingh	
-- Create date: 06-08-2018
-- Description:	Update Case Document And referrer document by Case ID
-- [global].[Update_CaseAndReferrerDocumentByCaseID] 2269,7,'2018-08-06 13:36:11',0,0,0
-- =============================================
-- =============================================
-- Author:		jasingh	/ rkumar
-- Create date: 16-08-2018
-- Description:	Update Case Document And referrer document by Case ID
-- [global].[Update_CaseAndReferrerDocumentByCaseID] 2269,7,'2018-08-06 13:36:11',0,0,0
-- =============================================
CREATE PROCEDURE [global].[Update_CaseAndReferrerDocumentByCaseID] 
		@CaseDocumentID int ,
		@ReferrerDocumentID int ,
		/*@CaseID INT,  
        @DocumentTypeID INT,	
		@UploadDate DATETIME,
		@ReferrerDocumentID int,*/
		@ReferrerCheck bit,
		@SupplierCheck bit
AS
BEGIN
	if @ReferrerDocumentID = 0
	BEGIN
	    update [global].[CaseDocuments] Set SupplierCheck = @SupplierCheck, ReferrerCheck = @ReferrerCheck 
		where CaseDocumentID = @CaseDocumentID
		 --where CaseID = @CaseID AND DocumentTypeID = @DocumentTypeID  		AND FORMAT(UploadDate, 'dd-MM-yyyy hh:mm:ss') = FORMAT(@UploadDate, 'dd-MM-yyyy hh:mm:ss')
		END
		else
		BEGIN
			Update [referrer].[ReferrerDocuments]  Set SupplierCheck = @SupplierCheck, ReferrerCheck = @ReferrerCheck where ReferrerDocumentID = @ReferrerDocumentID
		END

END



GO
/****** Object:  StoredProcedure [global].[Update_CaseAppointmentDate]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0
-- =============================================  
-- Author:  Harpreet Singh
-- Create date: 28-May-2014
-- Description: Added Procedure Update_CaseAppointmentDate
-- Version : 1.0
-- =============================================  

-- Latest Version 1.1
-- =============================================  
-- Author:  Param Kaur
-- Create date: 12-Feb-2019
-- Description: FirstAppointmentOfferedDate Field has been added
-- Version : 1.1
-- ============================================= 
CREATE PROCEDURE [global].[Update_CaseAppointmentDate]  
 -- Add the parameters for the stored procedure here
   (@CaseID INT, 
    @AppointmentDateTime  DATETIME,
	@FirstAppointmentOfferedDate DATETIME
    )  
AS  
BEGIN

	UPDATE    global.CaseAppointmentDates
	SET              AppointmentDateTime = @AppointmentDateTime,FirstAppointmentOfferedDate=@FirstAppointmentOfferedDate
	WHERE     (CaseID = @CaseID)
     
END

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessment_HasPatientConsentForm_ByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Harpreet Singh 
-- Create date: 12/15/2014  
-- Description: Created stored procedure Update_CaseAssessment_HasPatientConsentForm_ByCaseID to update caseassessment HasPatientConsentForm.  
-- Version: 1.0  
-- =============================================  

-- Author:  Vishal sen 
-- Create date: 08/14/2013  
-- Description: Modify SP as per new model.  
-- Version: 1.1  
-- =============================================  
  
CREATE PROCEDURE [global].[Update_CaseAssessment_HasPatientConsentForm_ByCaseID]   
(
@CaseID  int,
@HasPatientConsentForm  bit

)
 AS 
 
 UPDATE CaseAssessments SET 
 
 
 [HasPatientConsentForm]=@HasPatientConsentForm
             
       WHERE CaseID=@CaseID   
 
  
         
           
           
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentAuthorisationByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Satya  
-- Create date: 05/22/2013  
-- Description: Created stored procedure Update_CaseAssessmentAuthorisationByCasetID to update caseassessment AssessmentAuthorisationID  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Update_CaseAssessmentAuthorisationByCaseID]   
(  
--Add Parameters here    
  @CaseID INT,  
  @AssessmentAuthorisationID INT,  
  @AuthorisationDetail varchar(max)  
)  
  
AS  
BEGIN   
UPDATE [global].[CaseAssessments]  
   SET   
       AuthorisationDetail = @AuthorisationDetail,   
       AssessmentAuthorisationID= @AssessmentAuthorisationID  
       WHERE CaseID=@CaseID   
END  
  
  
  
  
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Anuj Batra  
-- Create date: 05/29/2013  
-- Description: Created stored procedure Update_CaseAssessmentByCasetID to update caseassessment.  
-- Version: 1.0  
-- =============================================  

-- Author:  Vishal sen 
-- Create date: 08/14/2013  
-- Description: Modify SP as per new model.  
-- Version: 1.1  
-- =============================================  
  
CREATE PROCEDURE [global].[Update_CaseAssessmentByCaseID]   
(
@CaseID  int,
@AssessmentServiceID  int,
@HasPatientConsentForm  bit,
@IncidentAndDiagnosisDescription  VARCHAR(MAX),
@NeuralSymptomDescription  VARCHAR(MAX),
@PreExistingConditionDescription  VARCHAR(MAX),
@IsPatientUndergoingTreatment  bit,
@IsPatientTakingMedication  bit,
@PatientRequiresFurtherInvestigation  bit,
@FactorsAffectingTreatmentDescription  VARCHAR(MAX),
@PatientOccupation  varchar(150),
@PatientRoleID  int,
@WasPatientWorkingAtTheTimeOfTheAccident  bit,
@IsPatientSufferingFinancialLoss  bit,
@AnticipatedDateOfDischarge  datetime,
@HasPatientHomeExerciseProgramme  bit,
@HasPatientPastSymptoms  bit,
@AssessmentAuthorisationID  int,
@AuthorisationDetail  VARCHAR(MAX),
@IsAccepted  bit,
@IsPatientDischarge  bit,
@DeniedMessage  VARCHAR(MAX),
@HasYellowFlags  bit,
@HasRedFlags  bit,
@UserID  int,
@IsSaved bit,
@RelevantTestUndertaken varchar(MAX)
)
 AS 
 
 UPDATE CaseAssessments SET 
 [CaseID]=@CaseID,
 [AssessmentServiceID]=@AssessmentServiceID,
 [HasPatientConsentForm]=@HasPatientConsentForm,
 [IncidentAndDiagnosisDescription]=@IncidentAndDiagnosisDescription,
 [NeuralSymptomDescription]=@NeuralSymptomDescription,
 [PreExistingConditionDescription]=@PreExistingConditionDescription,
 [IsPatientUndergoingTreatment]=@IsPatientUndergoingTreatment,
 [IsPatientTakingMedication]=@IsPatientTakingMedication,
 [PatientRequiresFurtherInvestigation]=@PatientRequiresFurtherInvestigation,
 [FactorsAffectingTreatmentDescription]=@FactorsAffectingTreatmentDescription,
 [PatientOccupation]=@PatientOccupation,
 [PatientRoleID]=@PatientRoleID,
 [WasPatientWorkingAtTheTimeOfTheAccident]=@WasPatientWorkingAtTheTimeOfTheAccident,
 [IsPatientSufferingFinancialLoss]=@IsPatientSufferingFinancialLoss,
 [AnticipatedDateOfDischarge]=@AnticipatedDateOfDischarge,
 [HasPatientHomeExerciseProgramme]=@HasPatientHomeExerciseProgramme,
 [HasPatientPastSymptoms]=@HasPatientPastSymptoms,
 [AssessmentAuthorisationID]=@AssessmentAuthorisationID,
 [AuthorisationDetail]=@AuthorisationDetail,
 [IsAccepted]=@IsAccepted,
 [IsPatientDischarge]=@IsPatientDischarge,
 [DeniedMessage]=@DeniedMessage,
 [HasYellowFlags]=@HasYellowFlags,
 [HasRedFlags]=@HasRedFlags,
 [UserID]=@UserID,
 [IsSaved]=@IsSaved,
 [RelevantTestUndertaken] = @RelevantTestUndertaken
             
       WHERE CaseID=@CaseID   
 
  
         
           
           
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentCustom]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================================================
-- Author     :	Mahinder Singh
-- Create date: 18 DEC 2014
-- Description:	UPDATE Case Assessment Custom according to Caseid
-- ==========================================================================================================
CREATE PROCEDURE [global].[Update_CaseAssessmentCustom]	
	@CaseID int,
	@IsFurtherTreatment int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE  global.CaseAssessMentCustoms SET IsFurtherTreatment =@IsFurtherTreatment  WHERE CaseID=@CaseID
END



GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentDateByCaseIDandAssessmentServiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Rohit Kumar>
-- Create date: <01-16-2015>
-- Description:	< Update Case Assessment Date By Case ID and AssessmentServiceID>
-- =============================================


CREATE PROCEDURE [global].[Update_CaseAssessmentDateByCaseIDandAssessmentServiceID]
@CaseID  int,
@AssessmentServiceID  int,
@AssessmentDate  datetime=null
 AS 
 begin
	UPDATE CaseAssessmentDetail SET  AssessmentDate  = (case when @AssessmentDate is null then null else @AssessmentDate end) WHERE CaseID=@CaseID and AssessmentServiceID =@AssessmentServiceID
 
	UPDATE    global.CaseAppointmentDates SET              IsCaseBookIADateUsed =0 	where  CaseID = @CaseID  
end

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentDeniedAuthorisationByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Satya  
-- Create date: 08/28/2013   
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Update_CaseAssessmentDeniedAuthorisationByCaseID]   
(  
--Add Parameters here    
  @CaseID INT,  
  @AssessmentAuthorisationID INT,  
  @DeniedAuthorisation TEXT  
)  
  
AS  
BEGIN   
UPDATE [global].[CaseAssessments]  
   SET   
       DeniedMessage = @DeniedAuthorisation,   
       AssessmentAuthorisationID= @AssessmentAuthorisationID  
       WHERE CaseID=@CaseID   
END  
  
  
  
  
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentDetailByCaseAssessmentDetailID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Vishal sen>
-- Create date: <08-19-2013>
-- Description:	< Create the procedure to Update CaseAssessmentDetailByCaseAssessmentDetailID>
-- =============================================  
-- Author:  HSingh
-- Create date: 01/20/2015
-- Description: add new fields named IsFurtherInvestigationOrOnwardReferralRequired, 
--	            FurtherInvestigationOrOnwardReferral, EvidenceOfTreatmentRecommendations
-- Version: 1.1
-- =============================================  


CREATE PROCEDURE [global].[Update_CaseAssessmentDetailByCaseAssessmentDetailID]
(
@CaseAssessmentDetailID  int,
@AssessmentServiceID  int,
@CaseID  int,
@HasThePatientHadTimeOff  bit,
@AbsentDetail  varchar(500),
@AbsentPeriod  int,
@AbsentPeriodDurationID  int,
@HasThePatientReturnedToWork  bit,
@PatientImpactOnWorkID  int,
@PatientWorkstatusID  int,
@PatientRecommendedTreatmentSessions  int,
@PatientRecommendedTreatmentSessionsDetail  varchar(max),
@PatientTreatmentPeriod  int,
@PatientTreatmentPeriodDetail  varchar(500),
@PatientTreatmentPeriodDurationID  int,
@IsFurtherTreatmentRecommended  bit,
@PatientLevelOfRecoveryID  int,
@SessionsPatientAttended  int,
@DatesOfSessionAttended  varchar(max),
@SessionsPatientFailedToAttend  int,
@FollowingTreatmentPatientLevelOfRecoveryID  int,
@AdditionalInformation  varchar(max),
@HasCompliedHomeExerciseProgramme  bit,
@PractitionerID INT,
@EvidenceOfClinicalReasoning varchar(max),
@IsFurtherInvestigationOrOnwardReferralRequired bit,
@FurtherInvestigationOrOnwardReferral varchar(max),
@EvidenceOfTreatmentRecommendations varchar(max),
@TreatmentPeriodTypeID int,
@PatientDateOfReturn datetime,
@PatientRecommendationReturn varchar(Max),
@IsPatientReturnToPreInjuryDuties bit,
@PatientPreInjuryDutiesDate datetime,
@MainFactors varchar(MAX)
)
AS 
BEGIN
	 UPDATE CaseAssessmentDetail SET [AssessmentServiceID]=@AssessmentServiceID,
	 [CaseID]=@CaseID,[HasThePatientHadTimeOff]=@HasThePatientHadTimeOff,
	 [AbsentDetail]=@AbsentDetail,[AbsentPeriod]=@AbsentPeriod,
	 [AbsentPeriodDurationID]=@AbsentPeriodDurationID,
	 [HasThePatientReturnedToWork]=@HasThePatientReturnedToWork,
	 [PatientImpactOnWorkID]=@PatientImpactOnWorkID,[PatientWorkstatusID]=@PatientWorkstatusID,
	 [PatientRecommendedTreatmentSessions]=@PatientRecommendedTreatmentSessions,
	 [PatientRecommendedTreatmentSessionsDetail]=@PatientRecommendedTreatmentSessionsDetail,
	 [PatientTreatmentPeriod]=@PatientTreatmentPeriod,
	 [PatientTreatmentPeriodDetail]=@PatientTreatmentPeriodDetail,
	 [PatientTreatmentPeriodDurationID]=@PatientTreatmentPeriodDurationID,
	 [IsFurtherTreatmentRecommended]=@IsFurtherTreatmentRecommended,
	 [PatientLevelOfRecoveryID]=@PatientLevelOfRecoveryID,[SessionsPatientAttended]=@SessionsPatientAttended,[DatesOfSessionAttended]=@DatesOfSessionAttended,[SessionsPatientFailedToAttend]=@SessionsPatientFailedToAttend,[FollowingTreatmentPatientLevelOfRecoveryID]=@FollowingTreatmentPatientLevelOfRecoveryID,[AdditionalInformation]=@AdditionalInformation,
	 [HasCompliedHomeExerciseProgramme]=@HasCompliedHomeExerciseProgramme,
	 [PractitionerID]= @PractitionerID,
	 [EvidenceOfClinicalReasoning] = @EvidenceOfClinicalReasoning,
	 IsFurtherInvestigationOrOnwardReferralRequired = @IsFurtherInvestigationOrOnwardReferralRequired,
	 FurtherInvestigationOrOnwardReferral = @FurtherInvestigationOrOnwardReferral, EvidenceOfTreatmentRecommendations=@EvidenceOfTreatmentRecommendations
	 ,TreatmentPeriodTypeID = @TreatmentPeriodTypeID
	 , PatientDateOfReturn = @PatientDateOfReturn
	 , PatientRecommendationReturn = @PatientRecommendationReturn
	 , IsPatientReturnToPreInjuryDuties = @IsPatientReturnToPreInjuryDuties
	 , PatientPreInjuryDutiesDate = @PatientPreInjuryDutiesDate
	 , MainFactors = @MainFactors
	 WHERE [CaseAssessmentDetailID] = @CaseAssessmentDetailID
 END

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentISavedByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 05-17-2018
-- Description:	To Update Case Assessment IsSaved
-- =============================================
CREATE PROCEDURE [global].[Update_CaseAssessmentISavedByCaseID](@CaseID int)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Update global.CaseAssessments  set IsSaved = null where CaseID = @CaseID
END


GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentPatientImpactByCaseAssessmentPatientImpactID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Anuj Batra  
-- Create date: 05/23/2013  
-- Description: Created stored procedure Update_CaseAssessmentPatientImpactByCaseAssessmentPatientImpactID to update CaseAssessmentPatientImpact  
-- =============================================  

-- Author:  Vishal
-- Create date: 08/14/2013  
-- Description: Modify SP as per new model
-- =============================================  
  
CREATE PROCEDURE [global].[Update_CaseAssessmentPatientImpactByCaseAssessmentPatientImpactID]  
 (  
@CaseAssessmentPatientImpactID  int,
@PatientImpactID  int,
@PatientImpactValueID  int,
@Comment  varchar(max),
@CaseAssessmentDetailID  int
 ) 
  
AS  
BEGIN  

UPDATE [global].[CaseAssessmentPatientImpacts]  
   SET   
 [PatientImpactID]=@PatientImpactID,
 [PatientImpactValueID]=@PatientImpactValueID,
 [Comment]=@Comment,
 [CaseAssessmentDetailID]=@CaseAssessmentDetailID 
 
    WHERE CaseAssessmentPatientImpactID=@CaseAssessmentPatientImpactID  
END  
  
  
  
  
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  Harpreet singh    
-- Create date: 24/05/2013    
-- Description: alter PROCEDURE for Update_CaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID     
-- Version: 1.0    
-- =============================================    
-- Updator:  Vishal sen  
-- Create date: 08/14/2013    
-- Description: Modify SP as per new Model  
-- Version: 1.0    
-- =============================================    
    
CREATE PROCEDURE [global].[Update_CaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID]     
(    
@CaseAssessmentPatientInjuryID int,    
@CaseAssessmentDetailID int,    
@AffectedArea varchar(500),    
@Score varchar(10),    
@Restriction VARCHAR(500),
@SymptomDescriptionID int,
@StrengthTestingID int,
@AffectedAreaID int,
@RestrictionRangeID int,
@OtherSymptomDesciption varchar(MAX)   
)    
as    
update global.CaseAssessmentPatientInjuries set   
CaseAssessmentDetailID=@CaseAssessmentDetailID,  
AffectedArea=@AffectedArea,  
Score=@Score,  
Restriction=@Restriction,
SymptomDescriptionID = @SymptomDescriptionID,
StrengthTestingID =  @StrengthTestingID,
AffectedAreaID = @AffectedAreaID,
RestrictionRangeID = @RestrictionRangeID,
OtherSymptomDesciption = @OtherSymptomDesciption
     
where CaseAssessmentPatientInjuryID=@CaseAssessmentPatientInjuryID    

GO
/****** Object:  StoredProcedure [global].[Update_CaseAssessmentRatingByCaseIDAndAssessmentServiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal sen
-- Create date: 3/9/2013
-- Description:	Created stored procedure Update_CaseAssessmentRatingByCaseIDAndAssessmentServiceID to Update Assesment Rating
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [global].[Update_CaseAssessmentRatingByCaseIDAndAssessmentServiceID] 
(
--Add Parameters here  
 @CaseID INT,
 @AssessmentServiceID INT,
 @Rating DECIMAL(5,2)
)

AS
BEGIN 
UPDATE [global].[CaseAssessmentRatings]
   SET 
       Rating = @Rating, 
       RatingDate= GETDATE()
       WHERE CaseID=@CaseID and AssessmentServiceID=@AssessmentServiceID
       
END









GO
/****** Object:  StoredProcedure [global].[Update_CaseBespokeReferrerPriceByCaseBespokeServiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================  
-- Author:  Vishal
-- Create date: 09/17/2013  
-- Description: Created stored procedure Update CaseBespokeReferrerPrice By CaseBespokeServiceID.  
-- Version: 1.0  
-- =============================================  

CREATE PROCEDURE [global].[Update_CaseBespokeReferrerPriceByCaseBespokeServiceID]   
(
@CaseBespokeServiceID  int,
@ReferrerPrice MONEY
)
 AS 
 
 UPDATE [global].[CaseBespokeServicePricing]
   SET [ReferrerPrice]=@ReferrerPrice
WHERE CaseBespokeServiceID = @CaseBespokeServiceID

GO
/****** Object:  StoredProcedure [global].[Update_CaseBespokeServicePricingByCaseBespokeServiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  Satya
-- Create date: 08/16/2013  
-- Description: Created stored procedure Update CaseBespokeServicePricing By CaseBespokeServiceID.  
-- Version: 1.0  
-- =============================================  

CREATE PROCEDURE [global].[Update_CaseBespokeServicePricingByCaseBespokeServiceID]   
(
@CaseBespokeServiceID  int,
@WasAbandoned  bit,
@PatientDidNotAttend  VARCHAR(MAX),
@DateOfService  VARCHAR(MAX)
)
 AS 
 
 UPDATE [global].[CaseBespokeServicePricing]
   SET [DateOfService] = @DateOfService
      ,[PatientDidNotAttend] = @PatientDidNotAttend
      ,[WasAbandoned] = @WasAbandoned
WHERE CaseBespokeServiceID = @CaseBespokeServiceID

GO
/****** Object:  StoredProcedure [global].[Update_CaseByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Update_CaseByCaseID]
(
@CaseID int,         
@PatientID INT,   
@ReferrerID INT,  
@ReferrerProjectID INT,
@ReferrerProjectTreatmentID INT,   
@TreatmentTypeID INT,   
@CaseReferrerReferenceNumber VARCHAR(50),   
@CaseSpecialInstruction VARCHAR(MAX),   
@CaseReferrerDueDate DATETIME,   
@WorkflowID INT,   
@IsTriage BIT,
@InjuryType varchar(50) ,
@SendInvoiceTo  varchar(20),
@SendInvoiceName varchar(50),
@SendInvoiceEmail varchar(50),
@ReferrerAssignedUser int,
@SupplierAssignedUser int,
@InnovateNote varchar(max),
@OfficeLocationID int,
@EmployeeDetailID int,
@DrugTestID int,
@JobDemandID int,
@IsNewPolicyTypeID int, 
@NewPolicyReferenceNumber varchar(50) 
)
AS
	update [global].[Cases]
		set [PatientID]   = @PatientID
           ,[ReferrerID]   =@ReferrerID
		   ,[ReferrerProjectID]=@ReferrerProjectID
           ,[ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID
           ,[TreatmentTypeID]   = @TreatmentTypeID
           ,[CaseReferrerReferenceNumber]   =@CaseReferrerReferenceNumber
           ,[CaseSpecialInstruction]   = @CaseSpecialInstruction
           ,[CaseReferrerDueDate]   = @CaseReferrerDueDate
           ,[WorkflowID]   = @WorkflowID
           ,[IsTriage]   = @IsTriage
           ,InjuryType = @InjuryType
		   ,[SendInvoiceTo] = @SendInvoiceTo
		   ,[SendInvoiceName] = @SendInvoiceName
		   ,[SendInvoiceEmail] = @SendInvoiceEmail
		   ,[ReferrerAssignedUser] = @ReferrerAssignedUser
		   ,SupplierAssignedUser = @SupplierAssignedUser
		   ,InnovateNote = @InnovateNote
		   ,OfficeLocationID = @OfficeLocationID
		   ,EmployeeDetailID = @EmployeeDetailID
		   ,DrugTestID = @DrugTestID
		   ,JobDemandID = @JobDemandID
		   ,IsNewPolicyTypeID=@IsNewPolicyTypeID 
           ,NewPolicyReferenceNumber=@NewPolicyReferenceNumber where CaseID = @CaseID

	


GO
/****** Object:  StoredProcedure [global].[Update_CaseContactByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Update_CaseContactByCaseID] 
	@CaseID int,
	@UserID int
AS
	Update [global].[CaseContacts] set [UserID] = @UserID where  CaseID = @CaseID
		        
	


GO
/****** Object:  StoredProcedure [global].[Update_CaseDocumentByCaseIDAndDocumentTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Vishal Sen  
-- Create date: 06-15-2013  
-- Description: Update case document  
-- =============================================  
CREATE PROCEDURE [global].[Update_CaseDocumentByCaseIDAndDocumentTypeID]   
        @CaseID INT,  
        @DocumentTypeID INT,  
		@UploadDate DATETIME,  
        @DocumentName VARCHAR(MAX),  
        @UploadPath VARCHAR(MAX),
        @UserID INT,
		@SupplierCheck bit,
		@ReferrerCheck bit	
AS  
    
  UPDATE  [global].[CaseDocuments]  
          SET    
           [UploadDate]=@UploadDate  
           ,[DocumentName]=@DocumentName  
           ,[UploadPath]=@UploadPath  
           ,[UserID]=@UserID
		   ,[SupplierCheck] =@SupplierCheck
		   ,[ReferrerCheck] =@ReferrerCheck
		      WHERE [CaseID]=@CaseID AND [DocumentTypeID]=@DocumentTypeID  
             
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseFinalAssessmentMessageCustom]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================================================
-- Author     :	Ranjeet Singh
-- Create date: 23 DEC 2014
-- Description:	UPDATE Supplier Message in Final Assessment Custom according to Caseid
-- ==========================================================================================================
CREATE PROCEDURE [global].[Update_CaseFinalAssessmentMessageCustom]
	@CaseID int,
	@FinalAssessmentMessage nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE  global.CaseAssessMentCustoms SET FinalAssessmentMessage =@FinalAssessmentMessage  WHERE CaseID=@CaseID
END



GO
/****** Object:  StoredProcedure [global].[Update_CaseHistory]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Update_CaseHistory]
(
	@CaseID INT,
	@EventDate DATETIME,
	@UserID INT,
	@EventDescription varchar(max),
	@EventType INT,
	@CaseHistoryID int
)
AS
	update [global].[CaseHistory]
	set [CaseID] = @caseid
        ,[EventDate] = @EventDate
        ,[UserID] = @UserID
        ,[EventDescription]	= @EventDescription
        ,[EventTypeID] = @EventType
		where 	CaseHistoryID = @CaseHistoryID

	


GO
/****** Object:  StoredProcedure [global].[Update_CaseInitialAssessmentMessageCustom]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================================================
-- Author     :	Harpreet Singh
-- Create date: 30 DEC 2014
-- Description:	UPDATE Supplier Message in Initial Assessment Custom according to Caseid
-- ==========================================================================================================
CREATE PROCEDURE [global].[Update_CaseInitialAssessmentMessageCustom]
	@CaseID int,
	@Message nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE  global.CaseAssessMentCustoms SET [Message] =@Message  WHERE CaseID=@CaseID
END



GO
/****** Object:  StoredProcedure [global].[Update_CaseInvoiceDateByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  

-- Author:  Satya
-- Create date: 09/19/2013  
-- Description: Update Case InvoiceDate By CaseID.  
-- Version: 1.1  
-- =============================================  
  
CREATE PROCEDURE [global].[Update_CaseInvoiceDateByCaseID]   
(
@InvoiceDate datetime,
@CaseID  int
)
 AS 
 UPDATE Cases SET 
 [InvoiceDate]= @InvoiceDate 
 WHERE CaseID=@CaseID   
 
  
         
           
           
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseIsTreatmentRequired]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Latest Version : 1.00

Created by   : Pardeep Kumar
Date         : 29-June-2013
Description  : Update IsTreatmentRequired field in Case table 
Version      : 1.00

*/

CREATE PROCEDURE [global].[Update_CaseIsTreatmentRequired]
(
@IsTreatmentRequired bit,
@CaseID bigint
)
as

update global.Cases set IsTreatmentRequired = @IsTreatmentRequired where CaseID = @CaseID

GO
/****** Object:  StoredProcedure [global].[Update_CasePatientContactDateByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Update_CasePatientContactDateByCaseID] 
	@CaseID int,
	@PatientContactDate date,
	@SupplierAssignedUser int = null,
	@InnovateNote varchar(max) = null
AS
BEGIN

	UPDATE global.Cases SET PatientContactDate = @PatientContactDate, SupplierAssignedUser = @SupplierAssignedUser, InnovateNote = @InnovateNote WHERE (CaseID = @CaseID)

END



GO
/****** Object:  StoredProcedure [global].[Update_CaseReferrerReferenceNumber]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--SP Name: UPPATE Patient
--Latest Version: 1.0


-- Author:		Rohit
-- Create date: 17/09/2014
-- Description:	Update Case Referrer Reference Number
-- Version: 1.0
           
CREATE PROCEDURE  [global].[Update_CaseReferrerReferenceNumber] 
	-- Add the parameters for the stored procedure here
	(
          @CaseID int
          ,@CaseReferrerReferenceNumber varchar(50)
           )
AS
BEGIN	

	  -- update CaseReferrerReferenceNumber against unique CaseNumber
	  
	  
	  UPDATE    global.Cases SET              CaseReferrerReferenceNumber = @CaseReferrerReferenceNumber   where CaseID =@CaseID

 
END


GO
/****** Object:  StoredProcedure [global].[Update_CaseRiewAssessmentMessageCustom]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ==========================================================================================================
-- Author     :	Ranjeet Singh
-- Create date: 23 DEC 2014
-- Description:	UPDATE Supplier Message in Review Assessment Custom according to Caseid
-- ==========================================================================================================
CREATE PROCEDURE [global].[Update_CaseRiewAssessmentMessageCustom]
	@CaseID int,
	@ReviewAssessmentMessage nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	UPDATE  global.CaseAssessMentCustoms SET ReviewAssessmentMessage =@ReviewAssessmentMessage  WHERE CaseID=@CaseID
END



GO
/****** Object:  StoredProcedure [global].[Update_CaseSupplier]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anuj Batra
-- Create date:04-17-2013
-- Description:	Sp to update supplier id in case table by CaseId
-- =============================================
CREATE PROCEDURE  [global].[Update_CaseSupplier](
	-- Add the parameters for the stored procedure here
	@CaseID int, 
	@SupplierID int
	)
AS
BEGIN
	update global.Cases set SupplierID=@SupplierID 
	where CaseID=@CaseID
	
END


GO
/****** Object:  StoredProcedure [global].[Update_CaseTreatmentPricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  Rohit Kumar
-- Create date: 01-28-2015
-- Description: Update CaseTreatmentPricing    
-- =============================================    
CREATE PROCEDURE [global].[Update_CaseTreatmentPricing]    
    
	   @CaseTreatmentPricingID	int
      ,@CaseID INT  
      ,@ReferrerPricingID INT  
      ,@ReferrerPrice MONEY  
      ,@DateOfService DATETIME  
      ,@PatientDidNotAttend BIT  
      ,@WasAbandoned BIT  
      ,@SupplierPrice  MONEY 
	  ,@Quantity INT
      ,@SupplierPriceID INT  
	  ,@PatientDidNotAttendDate DATETIME
     
    
AS    
      
	UPDATE    global.CaseTreatmentPricing
	SET              CaseID = @CaseID, ReferrerPricingID = @ReferrerPricingID, ReferrerPrice = @ReferrerPrice, DateOfService = @DateOfService, Quantity = @Quantity,
                      PatientDidNotAttend = @PatientDidNotAttend, WasAbandoned = @WasAbandoned, SupplierPrice = @SupplierPrice, SupplierPriceID = @SupplierPriceID,PatientDidNotAttendDate=@PatientDidNotAttendDate  
     where CaseTreatmentPricingID = @CaseTreatmentPricingID	
                      
	
                      
	                      
               
    select 2

GO
/****** Object:  StoredProcedure [global].[Update_CaseTreatmentPricingAuthorisationStatusByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  MAHINDER SINGH
-- Create date: 03/03/2015
-- Description: Stored procedure to Update CaseTreatmentPricing By CaseID
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [global].[Update_CaseTreatmentPricingAuthorisationStatusByCaseID]  
  @CaseID INT  
AS  
 
 UPDATE [global].CaseTreatmentPricing 
         SET AuthorizationStatus = 1
         WHERE CaseID = @CaseID and IsDeleted = 0
         

GO
/****** Object:  StoredProcedure [global].[Update_CaseTreatmentPricingByCaseTreatmentPricingID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Satya
-- Create date: 08/16/2013  
-- Description: Created stored procedure Update CaseTreatmentPricing By CaseTreatmentPricingID.  
-- Version: 1.0  
-- =============================================  
-- =============================================  
-- Author:  rkumar
-- Create date: 07/27/2018
-- Description: User Story #3335: Case Details - Treatment Matrix Update --if DateOfService is null then not need to update entry in CaseAppointmentDates as PatientDidNotAttend
-- Version: 1.1  
-- =============================================  
-- =============================================  
-- Author:  rkumar
-- Create date: 08/13/2018
-- Description: User Story #3357: Supplier Portal - RA / FA - Treatment Matrix Display
-- Version: 1.2
-- =============================================  

CREATE PROCEDURE [global].[Update_CaseTreatmentPricingByCaseTreatmentPricingID]   
(
@CaseTreatmentPricingID  int,
@WasAbandoned  bit,
@PatientDidNotAttend  VARCHAR(MAX),
@DateOfService  datetime

)
 AS 
 if ((SELECT     supplier.SupplierTreatmentPricing.PricingTypeID 
	FROM         GLOBAL.CaseTreatmentPricing INNER JOIN
						  supplier.SupplierTreatmentPricing ON GLOBAL.CaseTreatmentPricing.SupplierPriceID = supplier.SupplierTreatmentPricing.PricingID AND 
						  GLOBAL.CaseTreatmentPricing.SupplierPriceID = supplier.SupplierTreatmentPricing.PricingID INNER JOIN
						  LOOKUP.PricingTypes ON supplier.SupplierTreatmentPricing.PricingTypeID = LOOKUP.PricingTypes.PricingTypeID
	WHERE     (GLOBAL.CaseTreatmentPricing.CaseTreatmentPricingID = @CaseTreatmentPricingID)) = 1) 
		
		BEGIN
			DECLARE @CaseID AS INT
			SET @CaseID = (SELECT      CaseID FROM         GLOBAL.CaseTreatmentPricing WHERE CaseTreatmentPricingID = @CaseTreatmentPricingID )
			 
			 if(@DateOfService!=null)
			 BEGIN
				UPDATE    GLOBAL.CaseAppointmentDates
				SET              AppointmentDateTime = CONVERT(DATETIME,convert(VARCHAR(50),(@DateOfService  +' '+ CONVERT(VARCHAR(5),AppointmentDateTime,108))))
				WHERE     (CaseID = @CaseID)
			 END
		END

		IF((SELECT ISNULL(PatientDidNotAttend,0) FROM GLOBAL.CaseTreatmentPricing WHERE CaseTreatmentPricingID=@CaseTreatmentPricingID) = 1)
		BEGIN
			--DECLARE @SupplierPriceID AS INT
			--SET  @SupplierPriceID = (SELECT	PricingID
			--						FROM	supplier.SupplierTreatmentPricing
			--						WHERE	(PricingTypeID IN (4)) and  SupplierTreatmentID in
			--								((SELECT SupplierTreatmentID FROM supplier.SupplierTreatmentPricing
			--								WHERE (PricingID IN (SELECT SupplierPriceID FROM
			--								GLOBAL.CaseTreatmentPricing WHERE CaseTreatmentPricingID = @CaseTreatmentPricingID)))))
			
			UPDATE [global].[CaseTreatmentPricing]  SET  SupplierPriceID = PreviousSupplierPriceID , ReferrerPricingID = PreviousReferrerPricingID  
			WHERE CaseTreatmentPricingID = @CaseTreatmentPricingID
		END

		UPDATE [global].[CaseTreatmentPricing] SET [DateOfService] = @DateOfService ,[PatientDidNotAttend] = @PatientDidNotAttend  , PatientDidNotAttendDate = null
		,[WasAbandoned] = @WasAbandoned WHERE CaseTreatmentPricingID = @CaseTreatmentPricingID          
 
	
	
 
    

GO
/****** Object:  StoredProcedure [global].[Update_CaseTreatmentPricingPriceByCaseTreatmentPricingID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Satya
-- Create date: 08/27/2013  
-- Description: Created stored procedure Update CaseTreatmentPricingPrice By CaseTreatmentPricingID.  
-- Version: 1.1  
-- Revision History:
-- 
-- 1.1	-	19-02-2015 Tarun Gosain
--			User Story #2287: Internal Portal - Case Search - Case Treatment Pricing Grid - Modify Pop-up
-- =============================================  

CREATE PROCEDURE [global].[Update_CaseTreatmentPricingPriceByCaseTreatmentPricingID]  --1166,null,null,'2015-02-02 00:00:00.000',5267,1,1,7917,null
(
@CaseTreatmentPricingID  int,
@WasAbandoned  bit,
@PatientDidNotAttend  VARCHAR(MAX),
@DateOfService datetime,
@ReferrerPricingID INT,
@ReferrerPrice MONEY,
@SupplierPrice MONEY,
@SupplierPriceID INT,
@AuthorizationStatus bit,
@PatientDidNotAttendDate datetime

)
 AS 
 
 UPDATE [global].[CaseTreatmentPricing]
   SET [DateOfService] = null
      ,[PatientDidNotAttend] = @PatientDidNotAttend
      ,[WasAbandoned] = @WasAbandoned
      ,[ReferrerPricingID] = @ReferrerPricingID
      ,[ReferrerPrice] = @ReferrerPrice
      ,[SupplierPrice] = @SupplierPrice
      ,[SupplierPriceID] = @SupplierPriceID
      ,[AuthorizationStatus] =@AuthorizationStatus
	  ,[PatientDidNotAttendDate] = @PatientDidNotAttendDate
WHERE CaseTreatmentPricingID=@CaseTreatmentPricingID  

 
if ((SELECT     referrer.ReferrerProjectTreatmentPricing.PricingTypeID
FROM         global.CaseTreatmentPricing INNER JOIN
                      referrer.ReferrerProjectTreatmentPricing ON global.CaseTreatmentPricing.ReferrerPricingID = referrer.ReferrerProjectTreatmentPricing.PricingID
                      where CaseTreatmentPricingID  = @CaseTreatmentPricingID)=1)
 begin
 
			declare @CaseID as int
			set @CaseID = (SELECT      CaseID FROM         global.CaseTreatmentPricing where CaseTreatmentPricingID = @CaseTreatmentPricingID )
			 
			UPDATE    global.CaseAppointmentDates
			SET              AppointmentDateTime = CONVERT(DATETIME,convert(VARCHAR(50),(@DateOfService  +' '+ convert(varchar(5),AppointmentDateTime,108))))
			WHERE     (CaseID = @CaseID)
	
 
 end
  
         
           
           
 
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseTreatmentPricingPriceByReferrerPricingID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Rohit umar
-- Create date: 02/17/2015  
-- Description: Update Case Treatment Pricing Price By ReferrerPricingID
-- Version: 1.0  
-- =============================================  

CREATE PROCEDURE [global].[Update_CaseTreatmentPricingPriceByReferrerPricingID]   
(
@SupplierPriceID INT,
@PricingTypeId int

)
 AS 
 
 
 
 UPDATE     supplier.SupplierTreatmentPricing SET              PricingTypeID = @PricingTypeId  where PricingID = @SupplierPriceID
           
           
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_CaseTreatmentReferrerPriceByCaseTreatmentPricingID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Vishal
-- Create date: 09/17/2013  
-- Description: Created stored procedure Update CaseTreatmentReferrerPrice By CaseTreatmentPricingID.  
-- Version: 1.0  
-- ============================================= 

CREATE PROCEDURE [global].[Update_CaseTreatmentReferrerPriceByCaseTreatmentPricingID]   
(
@CaseTreatmentPricingID  int,
@ReferrerPrice MONEY,
@ReferrerPricingID INT,
@DateOfService DATETIME


)
 AS 
 
 UPDATE [global].[CaseTreatmentPricing]
   SET 
      [ReferrerPrice] = @ReferrerPrice    
      ,      [ReferrerPricingID] = @ReferrerPricingID    
      ,      [DateOfService] = @DateOfService    
WHERE CaseTreatmentPricingID=@CaseTreatmentPricingID  

GO
/****** Object:  StoredProcedure [global].[Update_CaseWorkflowByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================     
-- Latest Version : 1.0   
-- Author:  Satya      
-- Create date: 06-Mar-2013    
-- Description: Update CaseWorkflow By CaseID     
-- Version : 1.0       
-- =============================================    
CREATE PROCEDURE [global].[Update_CaseWorkflowByCaseID]       
 -- Add the parameters for the stored procedure here      
    @CaseID INT 
    ,@WorkflowID INT      
     
AS      
BEGIN       
      
UPDATE [global].[Cases]
    SET [WorkflowID] = @WorkflowID
	WHERE 
	[CaseID] = @CaseID   
END




GO
/****** Object:  StoredProcedure [global].[Update_CaseWorkflowByCaseID_StoppedCase]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================     
-- Latest Version : 1.0   
-- Author:  MMSingh      
-- Create date: 24-June-2014    
-- Description: Update CaseWorkflow By CaseID  Stopped the Case in Middle of Treatment   
-- Version : 1.0       
-- =============================================    
CREATE PROCEDURE [global].[Update_CaseWorkflowByCaseID_StoppedCase]       
 -- Add the parameters for the stored procedure here      
    @CaseID INT        
     
AS      
BEGIN       
      
UPDATE [global].[Cases]
    SET [WorkflowID] = 200
	WHERE 
	[CaseID] = @CaseID   
END




GO
/****** Object:  StoredProcedure [global].[Update_CaseWorkflowCustomByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================     
-- Latest Version : 1.0   
-- Author:  Rohit Kumar
-- Create date: 12-12-2014
-- Description: Update Case Workflow Custom By CaseID
-- Version : 1.0       
-- =============================================    
CREATE PROCEDURE [global].[Update_CaseWorkflowCustomByCaseID]       
 -- Add the parameters for the stored procedure here      
    @CaseID INT 
    ,@UserId int
    ,@WorkflowID INT      
     
AS      
BEGIN       
      
	UPDATE [global].[Cases] SET [WorkflowID] = @WorkflowID, IsCustom = 1 WHERE [CaseID] = @CaseID   
	
	declare @Definition varchar(500) 
	set @Definition  = (SELECT      [Definition] FROM         lookup.Workflows where WorkflowID = @WorkflowID)
	
	INSERT INTO global.CaseHistory
                      (CaseID, EventDate, UserID, EventDescription, EventTypeID)
	VALUES     (@CaseID, GETDATE(),@UserId,@Definition, 1)
	
END




GO
/****** Object:  StoredProcedure [global].[Update_DrugTestByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Tarun Gosain
-- Create date: 03-21-2019
-- Description:	Update Drug Test table
-- =============================================
CREATE PROCEDURE [global].[Update_DrugTestByID] (@DrugTestID int, @IsDrugAndAlcohalTest bit, @NetworkRailStandardApplicableID int, @ReasonForReferralID int, @IsSentinalUpdating bit, @SentinalNumber varchar(100), @AdditionalTestID int, @AdditionalTestOther varchar(200))
AS
BEGIN	
	SET NOCOUNT ON;
	Update global.DrugTests set IsDrugAndAlcohalTest = @IsDrugAndAlcohalTest, NetworkRailStandardApplicableID = @NetworkRailStandardApplicableID, ReasonForReferralID = @ReasonForReferralID, IsSentinalUpdating = @IsSentinalUpdating, SentinalNumber = @SentinalNumber, AdditionalTestID = @AdditionalTestID, AdditionalTestOther = @AdditionalTestOther
	where DrugTestID = @DrugTestID
END

GO
/****** Object:  StoredProcedure [global].[Update_EmploymentByEmploymentId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Author:		TGosain
-- Create date: 27 Aug 2018
-- Description:	Update Employments fields
-- Version: 1.0
           
CREATE PROCEDURE  [global].[Update_EmploymentByEmploymentId] 	
	(	
		 @EmploymentTypeId INT
		,@CompanyName varchar(25)
		,@JobRole varchar(40)
		,@Address varchar(40)
		,@ContactName varchar(25)
		,@PrimaryPhone varchar(25)
		,@Email varchar(50)
		,@EmploymentId int
   )
AS
BEGIN	

    Update [global].[Employments]  
	set 	[EmploymentTypeId] = @EmploymentTypeId
			,[CompanyName] = @CompanyName
			,[JobRole] = @JobRole
			,[Address] = @Address
			,[ContactName] = @ContactName
			,[PrimaryPhone] = @PrimaryPhone
			,[Email] = @Email
			where EmploymentId = @EmploymentId 
END


GO
/****** Object:  StoredProcedure [global].[Update_InjuredPartyRepresentatives]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--SP Name: Update_InjuredPartyRepresentatives
--Latest Version: 1.0


-- Author:		Mahinder Singh 
-- Create date: 04/04/2018
-- Description:	Update InjuredPartyRepresentatives information
-- Version: 1.0
           
CREATE PROCEDURE  [global].[Update_InjuredPartyRepresentatives] 
	-- Add the parameters for the stored procedure here
(		
@InjuredID INT
,@FirstName VARCHAR(50)
,@LastName VARCHAR(50)
,@ReferralID INT
,@Tel1 VARCHAR(16)
,@Tel2 VARCHAR(16)
,@Address VARCHAR(300)
,@PostCode VARCHAR(12)
,@Email VARCHAR(50)
,@Relationship VARCHAR(50)
 )
AS
BEGIN	

    UPDATE  [global].InjuredPartyRepresentatives  SET	
			[FirstName] = @FirstName,
			[LastName] = @LastName,
			[ReferralID] = @ReferralID,
			[Tel1] = @Tel1,
			[Tel2] = @Tel2,
			[Address] = @Address,
			[PostCode] = @PostCode,
			[Email] = @Email,
			[Relationship] = @Relationship
			WHERE InjuredID = @InjuredID

	
 
END


GO
/****** Object:  StoredProcedure [global].[Update_InvoiceIsCompleteByInvoiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [global].[Update_InvoiceIsCompleteByInvoiceID]   
(
@IsComplete BIT,
@InvoiceID  int
)
 AS 
 UPDATE Invoices SET 
 [IsComplete]= @IsComplete 
 WHERE InvoiceID = @InvoiceID
 
  
         
           
           
  
  
  

GO
/****** Object:  StoredProcedure [global].[Update_IsPatientDischargeByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal Sen
-- Create date: 20-08-2013
-- Description:	Sp to update IsPatientDischargeByCaseID
-- =============================================
CREATE PROCEDURE  [global].[Update_IsPatientDischargeByCaseID](
	-- Add the parameters for the stored procedure here
	@CaseID int ,
	@IsPatientDischarge bit
	)
AS
BEGIN
	update global.CaseAssessments set IsPatientDischarge=@IsPatientDischarge
	where CaseID=@CaseID
	
END




 
 
 

GO
/****** Object:  StoredProcedure [global].[Update_JobDemandByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		jaskaran	
-- Create date: 09-04-2019
-- Description:	update Values by Id in Job Demand Table
-- =============================================
CREATE PROCEDURE [global].[Update_JobDemandByID]
	@JobDemandID int,
	@IsJobDemand bit,
	@IsStanding	bit,
	@IsWalking	bit,
	@IsWorkATHeightOrClimb	bit,
	@IsExtendedOrProlonged	bit,
	@IsVocationalDriving	bit,
	@IsDrivingLGVOrPCVs	bit,
	@IsDrivingForkliftTrucks	bit,
	@IsWorkWithChemials	bit,
	@IsWorkBiologicalOrChemical	bit,
	@IsWorkWithSkinIrritants	bit,
	@IsWorkWithDengerousMachinery bit,
	@IsNightWork bit,
	@IsShiftWork	bit,
	@IsWorkInConfinedSpaces	bit,
	@IsWorkWithDustOrFumes	bit,
	@IsLiftOrCarryHeavyItems	bit,
	@IsWorkWithComputerOrScreens	bit,
	@IsWorkTowardsTagetOrPressuredsituation	bit,
	@IsWorkWithAdultOrChildren	bit,
	@IsHealthCareWorker	bit,
	@IsOccasionalOverseasTravel	bit,
	@IsOutsideWork	bit,
	@IsNoisedHarzardArea bit,
	@IsHandlingFood	bit,
	@FreeText	varchar(200)
AS
BEGIN
	
	SET NOCOUNT ON;

	update [global].[JobDemands] SET
	IsJobDemand = @IsJobDemand,
	IsStanding = @IsStanding,
	IsWalking = @IsWalking,
	IsWorkATHeightOrClimb = @IsWorkATHeightOrClimb,
	IsExtendedOrProlonged = @IsExtendedOrProlonged,
	IsVocationalDriving = @IsVocationalDriving,
	IsDrivingLGVOrPCVs = @IsDrivingLGVOrPCVs,
	IsDrivingForkliftTrucks = @IsDrivingForkliftTrucks,
	IsWorkWithChemials = @IsWorkWithChemials,
	IsWorkBiologicalOrChemical = @IsWorkBiologicalOrChemical,
	IsWorkWithSkinIrritants = @IsWorkWithSkinIrritants,
	IsWorkWithDengerousMachinery = @IsWorkWithDengerousMachinery,
	IsNightWork = @IsNightWork,
	IsShiftWork = @IsShiftWork,
	IsWorkInConfinedSpaces = @IsWorkInConfinedSpaces,
	IsWorkWithDustOrFumes = @IsWorkWithDustOrFumes,
	IsLiftOrCarryHeavyItems = @IsLiftOrCarryHeavyItems,
	IsWorkWithComputerOrScreens = @IsWorkWithComputerOrScreens,
	IsWorkTowardsTagetOrPressuredsituation = @IsWorkTowardsTagetOrPressuredsituation,
	IsWorkWithAdultOrChildren = @IsWorkWithAdultOrChildren,
	IsHealthCareWorker = @IsHealthCareWorker,
	IsOccasionalOverseasTravel = @IsOccasionalOverseasTravel,
	IsOutsideWork = @IsOutsideWork,
	IsNoisedHarzardArea = @IsNoisedHarzardArea,
	IsHandlingFood = @IsHandlingFood,
	[FreeText] = @FreeText
	where JobDemandID = @JobDemandID

   
END

GO
/****** Object:  StoredProcedure [global].[Update_PasswordOTPByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0
-- =============================================  
-- Author:  Rkumar
-- Create date: 09-May-2018
-- Description: Added Procedure Update/reset User Password
-- Version : 1.0
-- =============================================  

-- =============================================  
-- Author:  Rkumar
-- Create date: 10-July-2018
-- Description: #3307- Security - Password Reset Function
-- Version : 1.1
-- =============================================  


create PROCEDURE [global].[Update_PasswordOTPByID]  
   (@UserId INT, 
    @PasswordOTP  varchar(100) 
    )  
AS  
BEGIN
	UPDATE global.Users SET PasswordOTP= @PasswordOTP 	 where UserID = @UserId
END

GO
/****** Object:  StoredProcedure [global].[Update_PatientByPatientID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--SP Name: UPPATE Patient
--Latest Version: 1.0


-- Author:		Vishal 
-- Create date: 18/01/2014
-- Description:	Update Patient information
-- Version: 1.0
-- History: 
-- 1.1	:	TGosain
--			Removed caseid parameter as it is not needed
-- 1.2	:	Param Kaur
--			PrimaryConditionID Fileld Added 
CREATE PROCEDURE  [global].[Update_PatientByPatientID] 
	-- Add the parameters for the stored procedure here
(	@PatientID	INT
	,@Title varchar(50)
	,@FirstName varchar(80)
	,@LastName varchar(80)
	,@Address varchar(300)
	,@City varchar(100)
	,@Region varchar(50)
	,@PostCode varchar(12)
	,@InjuryDate date
	,@BirthDate date
	,@HomePhone varchar(16)
	,@WorkPhone varchar(16)
	,@MobilePhone varchar(16)
	,@GenderID int
	,@Email varchar(50)
	,@HasLegalRep bit
	,@SolicitorID int           
	,@HasInjuredPartyRepresentative int
	,@InjuredID int
	,@SpecialInstructionNotes varchar(MAX)           
	,@PolicyID int
	,@EmploymentID int
	 ,@PrimaryConditionID int
	 ,@PolicyOpenDetailID int
)
AS
BEGIN	
    UPDATE  [global].Patients      
    SET		[Title] = @Title
           ,[FirstName] = @FirstName
           ,[LastName] = @LastName
           ,[Address] = @Address
           ,[City]= @City
           ,[Region]= @Region
           ,[PostCode]= @PostCode
           ,[InjuryDate]= @InjuryDate
           ,[BirthDate]= @BirthDate
           ,[HomePhone]= @HomePhone
           ,[WorkPhone]= @WorkPhone
           ,[MobilePhone]= @MobilePhone
           ,[GenderID]= @GenderID
           ,[Email]	= @Email
           ,[HasLegalRep]=@HasLegalRep
           ,[SolicitorID]=@SolicitorID
		   , HasInjuredPartyRepresentative = @HasInjuredPartyRepresentative
		   ,InjuredID = @InjuredID
		   ,[SpecialInstructionNotes] = @SpecialInstructionNotes		   
           ,PolicyID = @PolicyID
		   ,EmploymentID = @EmploymentID
		   ,PrimaryConditionID=@PrimaryConditionID
		   , PolicyOpenDetailID = @PolicyOpenDetailID
           
	  WHERE [PatientID]=@PatientID

 
END


  

GO
/****** Object:  StoredProcedure [global].[Update_Policie]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- Author:		TGosain
-- Create date: 27-09-2018
-- Description:	Update PolicyID fields, EmploymentID fields
-- Version: 1.0
           
CREATE PROCEDURE  [global].[Update_Policie] 
	-- Add the parameters for the stored procedure here
(	
		@PolicyTypeId INT
		,@TypeCoverId INT
		,@PolicyCriteriaId INT
		,@RehabProportionateBenefit BIT
		,@FitForWorkId INT	
		,@ReInsuredId INT
		,@ReferenceNo VARCHAR(25)
		,@AdmittedId INT
		,@BenefitDate DATE
		,@MonthlyValue DECIMAL
		,@WeeklyValue DECIMAL
		,@EndBenefitDate DATE	
		,@NameOfReinsurerID INT
		,@PolicyWording VARCHAR(max)
		,@PolicyID int
   )
AS
BEGIN	

    update [global].[Policies]  
			set [PolicyTypeId] = @PolicyTypeId
			,[TypeCoverId] = @TypeCoverId
			,[PolicyCriteriaId] = @PolicyCriteriaId
			,[RehabProportionateBenefit] = @RehabProportionateBenefit
			,[FitForWorkId] = @FitForWorkId
			,[ReInsuredId] = @ReInsuredId
			,[ReferenceNo] = @ReferenceNo
			,[AdmittedId] = @AdmittedId
			,[BenefitDate] = @BenefitDate
			,[MonthlyValue] = @MonthlyValue
			,[WeeklyValue] = @WeeklyValue
			,[EndBenefitDate] = @EndBenefitDate
			,[NameOfReinsurerID] = @NameOfReinsurerID
			,[PolicyWording] = @PolicyWording
	  Where PolicyID = @PolicyID
END


GO
/****** Object:  StoredProcedure [global].[Update_PolicyOpenDetail]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh
-- Create date: 03-09-2019
-- Description:	Update PolicyOpenDetail
-- =============================================
CREATE PROCEDURE [global].[Update_PolicyOpenDetail] 
	(	
		@PolicyOpenDetailID INT,
		@PolicyType	varchar(25),
		@TypeCover	varchar(25),
		@PolicyCriteria	varchar(25),
		@RehabORProportionate	varchar(25),
		@FitforWork	varchar(25),
		@ReInsured	varchar(25),
		@ReferenceNo varchar(25),
		@Admitted	varchar(25),
		@OpenBenefitDate	datetime,
		@OpenMonthlyValue	money,
		@OpenEndBenefitDate	datetime,
		@NameofReinsurer	varchar(25),
		@OpenPolicyWording	varchar(MAX)
   )
AS
BEGIN	

    update [global].[PolicyOpenDetails]  
			set PolicyType = @PolicyType
			,TypeCover = @TypeCover
			,PolicyCriteria = @PolicyCriteria
			,RehabORProportionate = @RehabORProportionate
			,FitforWork = @FitforWork
			,ReInsured = @ReInsured
			,ReferenceNo = @ReferenceNo
			,Admitted = @Admitted
			,OpenBenefitDate = @OpenBenefitDate
			,OpenMonthlyValue = @OpenMonthlyValue		
			,OpenEndBenefitDate = @OpenEndBenefitDate
			,NameofReinsurer = @NameofReinsurer
			,OpenPolicyWording = @OpenPolicyWording
	  Where PolicyOpenDetailID = @PolicyOpenDetailID
END

      

GO
/****** Object:  StoredProcedure [global].[Update_PractitionerByPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

    
-- =============================================     
-- Latest Version : 1.1   
-- Author:  Pardeep Kumar      
-- Create date: 31-Jan-2013    
-- Description: Update Practitioner      
-- Version : 1.0       
-- =============================================   
-- Modified By: Robin Singh      
-- Created date: 07-Feb-2013      
-- Description: Modify table name Practitioner to Practitioners  
-- Version: 1.1    

-- Modified By: Anuj Batra     
-- Create date: 08-Mar-2013      
-- Description: Removed the fields from the SP as per the tables design changes.  
-- Version: 1.2
-- =============================================      
    
     
CREATE PROCEDURE [global].[Update_PractitionerByPractitionerID]       
 -- Add the parameters for the stored procedure here      
         
   @PractitionerID INT      
   ,@PractitionerFirstName varchar(50)    
   ,@PractitionerLastName varchar(50)      
  
AS      
BEGIN       
      
UPDATE [global].[Practitioners]      
  SET      
  [PractitionerFirstName]=@PractitionerFirstName    
  ,[PractitionerLastName]=@PractitionerLastName    
                            
   WHERE      
   PractitionerID=@PractitionerID      
         
        
END



GO
/****** Object:  StoredProcedure [global].[Update_PractitionerExpertiseByPractitionerExpertiseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.1
-- =============================================    
-- Author:  Pardeep Kumar    
-- Create date: 31-Jan-2013  
-- Description: Update PractitionerExpertise     
-- Version : 1.0     
-- =============================================  
-- Modified By:  Manjit Singh  
-- Create date: 08-March-2013
-- Description: Remove Field and parameter named TreatmentCategoryID 
-- Version : 1.1   
-- =============================================    
   
CREATE PROCEDURE [global].[Update_PractitionerExpertiseByPractitionerExpertiseID]     
 -- Add the parameters for the stored procedure here    
   (    
   @PractitionerExpertiseID INT,    
   @PractitionerID INT    
           ,@AreaofExpertiseID INT
           )    
    
AS    
BEGIN     
    
UPDATE [global].[PractitionerExpertise]    
  SET    
           PractitionerID=@PractitionerID    
          ,AreaofExpertiseID=@AreaofExpertiseID       
  WHERE     
   PractitionerExpertiseID=@PractitionerExpertiseID    
END    
    

GO
/****** Object:  StoredProcedure [global].[Update_PractitionerRegistrationByPractitionerRegistrationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Author:  Satya    
-- Create date: 03/08/2013    
-- Description: Create stored procedure to Update PractitionerRegistration By PractitionerRegistrationID    
-- Version: 1.0    
-- =============================================    
    
CREATE PROCEDURE [global].[Update_PractitionerRegistrationByPractitionerRegistrationID]     
 -- Add the parameters for the stored procedure here    
    @PractitionerID int    
   ,@TreatmentCategoryID int    
      ,@RegistrationTypeID int  = NULL  
      ,@RegistrationNumber NVARCHAR(50)    
      ,@Qualification NVARCHAR(100)    
      ,@QualificationDate DATE    
      ,@ExpiryDate DATE    
      ,@YearsQualified INT    
      ,@PractitionerRegistrationID INT    
AS    
BEGIN     
  Update      
  [global].[PractitionerRegistrations] SET     
     
     [PractitionerID]=@PractitionerID    
     ,[TreatmentCategoryID]=@TreatmentCategoryID    
     ,[RegistrationTypeID]=@RegistrationTypeID    
     ,[RegistrationNumber]=@RegistrationNumber     
     ,[Qualification] = @Qualification    
     ,[QualificationDate] = @QualificationDate    
     ,[ExpiryDate]=@ExpiryDate    
     ,[YearsQualified]=@YearsQualified    
    Where PractitionerRegistrationID=@PractitionerRegistrationID    
END    
    
    

GO
/****** Object:  StoredProcedure [global].[Update_SolicitorBySolicitorID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Vishal s
-- Create date: 17/1/2014
-- Description:	alter PROCEDURE for Update_Solicitors
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [global].[Update_SolicitorBySolicitorID]
	-- Add the parameters for the stored procedure here	
	@SolicitorID int,
	@CompanyName varchar(50),
	@Address varchar(300),
	@Phone varchar(16),
	@Email varchar(50),
	@FirstName varchar(30),
	@LastName varchar(30),
	@PostCode varchar(12),
	@Fax varchar(16),
	@ReferenceNumber varchar(16),
	@City varchar(100),
	@Region varchar(50)	,
	@IsReferralUnderJointInstruction bit
	
AS
BEGIN	

UPDATE [global].[Solicitors]
   SET [CompanyName] = @CompanyName
      ,[Address] = @Address
      ,[Phone] = @Phone
      ,[Email] = @Email
      ,[FirstName] = @FirstName
      ,[LastName] = @LastName
      ,[PostCode] = @PostCode
      ,[Fax] = @Fax
      ,[ReferenceNumber] = @ReferenceNumber
      ,[City] =@City 
      ,[Region] =@Region
	  ,[IsReferralUnderJointInstruction] = @IsReferralUnderJointInstruction
 WHERE 
 [SolicitorID]=@SolicitorID

  
END


GO
/****** Object:  StoredProcedure [global].[Update_UserByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--SP Name: Update_UserByUserID
--version: 1.1

-- Author:		Vishal Sen
-- Create date: 11/03/2012
-- Version: 1.0
-- Description:	update store procedure


-- Author:		Vijay Kumar 
-- Create date: 11/06/2012
-- Version: 1.1
-- Description:	Add 3 more Fields: 
-- 1) SupplierID
-- 2) ReferrerID
-- 3) ReferrerLocationID

-- Author:		ftan 
-- Create date: 11/06/2012
-- Version: 1.2
-- Description:	Add 3 more Fields: 
-- 1) Email
-- 2) Fax
-- 3) Telephone


CREATE PROCEDURE [global].[Update_UserByUserID] 
	-- Add the parameters for the stored procedure here
	   @UserID int
	  ,@Username NVARCHAR(100)
      ,@Password NVARCHAR(100)
      ,@FirstName NVARCHAR(100)
      ,@LastName NVARCHAR(100)
      ,@UserTypeID int
	  ,@SupplierTypes varchar(30)
	  ,@SupplierID int
	  ,@ReferrerTypes varchar(30)
	  ,@ReferrerID int
      ,@ReferrerLocationID INT
      ,@Email VARCHAR(50)
	  ,@Fax VARCHAR(16)
	  ,@Telephone VARCHAR(16)
     
AS
BEGIN
	UPDATE [global].Users set 
	
	 [Username]=@Username,
     --[Password]=@Password,
	 [FirstName]=@FirstName,
	 [LastName]=@LastName, 
     [UserTypeID]=@UserTypeID,
	 [SupplierTypes]=@SupplierTypes,
	 [SupplierID]=@SupplierID, 
	 [ReferrerTypes] =@ReferrerTypes,
	 [ReferrerID]=@ReferrerID,
     [ReferrerLocationID]=@ReferrerLocationID,
	 [Email]=@Email,
	 [Fax]=@Fax,
	 [Telephone]=@Telephone 
	WHERE [global].Users.UserID=@UserID
END


GO
/****** Object:  StoredProcedure [global].[Update_UserFailedAttemptCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Update_UserFailedAttemptCount]
	(
	@UserID int,
	@NumberOfFailedLoginAttempts INT
	)
	
AS
BEGIN
	UPDATE [global].Users 
	SET [global].Users.FailedAttemptCount=@NumberOfFailedLoginAttempts 
	WHERE [global].Users.UserID=@UserID
END


GO
/****** Object:  StoredProcedure [global].[Update_UserFailedAttemptCountAndLastLoginDate]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Update_UserFailedAttemptCountAndLastLoginDate]
	(
	@UserID INT,
	@FailedAttemptCount INT,
	@LoginDate DATETIME
	)
	
AS
BEGIN
	UPDATE [global].Users 
	SET [global].Users.FailedAttemptCount = @FailedAttemptCount,
		[global].Users.LastLoginDate = @LoginDate
	WHERE [global].Users.UserID=@UserID
END


GO
/****** Object:  StoredProcedure [global].[Update_UserLock]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [global].[Update_UserLock]
	(
	@UserID int,
	@IsLocked bit
	)
	
AS
BEGIN
	UPDATE [global].Users set [global].Users.IsLocked=@IsLocked 
	WHERE [global].Users.UserID=@UserID
END


GO
/****** Object:  StoredProcedure [global].[Update_UserSessionIDByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Latest Version 1.0
-- =============================================  
-- Author:  Rkumar
-- Create date: 29-Oct-2018
-- Description: Update User Session ID By UserID
-- Version : 1.0
-- =============================================  
 


CREATE PROCEDURE [global].[Update_UserSessionIDByUserID]  
   (
	@UserID INT, 
    @UserSessionID  varchar(255)
   )  
AS  
BEGIN
	UPDATE global.Users SET UserSessionID = @UserSessionID	 where UserID = @UserId
END

GO
/****** Object:  StoredProcedure [referrer].[Add_ProjectTreatmentSLAs]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vishal 
-- Create date: 11-14-2012
-- Description:	Create A Sp For [Add_ProjectTreatmentSLAs]
-- =============================================
-- Author:		Vishal 
-- Create date: 11-19-2012
-- Description:	Modify Sp Add Scope Identity



CREATE PROCEDURE [referrer].[Add_ProjectTreatmentSLAs]
	-- Add the parameters for the stored procedure here
	
	@ReferrerProjectTreatmentID int,
	@ServiceLevelAgreementID int,
	@NumberOfDays int,   
    @Enabled bit
AS
BEGIN
insert into
 referrer.ProjectTreatmentSLAs
(
	ReferrerProjectTreatmentID,
	ServiceLevelAgreementID,
	NumberOfDays,
	[Enabled]
)
values
(
	@ReferrerProjectTreatmentID,
	@ServiceLevelAgreementID,
	@NumberOfDays,
	@Enabled 
)
  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [referrer].[Add_Referrer]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vishal
-- Create date: 10/27/2012
-- Description:	Add referrer information
-- Version: 1.0
--
-- Author:		ftan
-- Version: 1.1
-- Description:	updated referrer fields
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 02/27/2013
-- Description:	added the Phone and Fax columns
-- Version: 1.2
-- =============================================
-- Author:		Vishal Sen
-- Create date: 06/13/2013
-- Description:	Remove two parameter from Sp ReferrerCentralEmail,EmailSendingOptionID
-- Version: 1.3
-- =============================================
-- =============================================
-- Author:		Rohit Kumar
-- Create date: 21/09/2018
-- Description:	#3384 - Internal Portal - Referrer Setup - New Section - Referral Setup
-- Version: 1.4
-- =============================================
-- =============================================
-- Author:		Rohit Kumar
-- Create date: 08/04/2019
-- Description:	#3553 - Internal Portal -Referrer Setup - New Sections
-- Version: 1.5
-- =============================================


CREATE PROCEDURE [referrer].[Add_Referrer] 
	-- Add the parameters for the stored procedure here
	   @ReferrerName NVARCHAR(100)
      ,@ReferrerContactFirstName NVARCHAR(100)
      ,@ReferrerContactLastName NVARCHAR(100)     
      ,@ReferrerMainContactEmail NVARCHAR(100)
	  ,@ReferrerMainContactFax NVARCHAR(100)
      ,@ReferrerMainContactPhone NVARCHAR(100)
	  ,@IsPolicyDetail bit
	  ,@IsEmploymentDetail bit
	  ,@IsEmploeeDetail bit
	  ,@IsDrugandAlcoholTest bit
	  ,@IsRepresentation bit
	  ,@IsAdditionalQuestion bit
	  ,@IsJobDemand bit
	  ,@IsPolicyDetailOpenOrDropdowns VARCHAR(10)
	  ,@IsNewPolicyTypes VARCHAR(10)
AS
BEGIN	
	DECLARE @referrerID INT;
    INSERT 
	INTO [referrer].[Referrers] 
	(  [ReferrerName]
      ,[ReferrerContactFirstName]
      ,[ReferrerContactLastName]
      ,[ReferrerMainContactEmail]      
      ,[ReferrerMainContactFax]
      ,[ReferrerMainContactPhone]
	  ,IsPolicyDetail
	  ,IsEmploymentDetail 
	  ,IsEmploeeDetail
	  ,IsDrugandAlcoholTest
	  ,IsRepresentation
	  ,IsAdditionalQuestion
	  ,IsJobDemand
	  ,IsPolicyDetailOpenOrDropdowns
	  ,IsNewPolicyTypes
      )
	  VALUES
	  (
	  @ReferrerName,
	  @ReferrerContactFirstName,
	  @ReferrerContactLastName,
	  @ReferrerMainContactEmail,
	  @ReferrerMainContactFax,
	  @ReferrerMainContactPhone,
	  @IsPolicyDetail,
	  @IsEmploymentDetail,
	  @IsEmploeeDetail,
	  @IsDrugandAlcoholTest,
	  @IsRepresentation,
	  @IsAdditionalQuestion,
	  @IsJobDemand,
	  @IsPolicyDetailOpenOrDropdowns,
	  @IsNewPolicyTypes
	  )
	  
	  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerCaseAssessmentModifications]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Latest Version: 1.1    
    
-- Author:  PKAUR   
-- Create date: April 23, 2018   
-- Description: to add ReferrerCaseAssessmentModifications    
-- =============================================    
CREATE PROCEDURE [referrer].[Add_ReferrerCaseAssessmentModifications]
      @CaseID int
      ,@TreatmentSession int
      ,@AssessmentServiceID int
 AS 
 begin
 
 INSERT INTO  [referrer].[ReferrerCaseAssessmentModifications](
      [CaseID]
      ,[TreatmentSession]
      ,[AssessmentServiceID])
 VALUES(@CaseID,@TreatmentSession,@AssessmentServiceID)

end




GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerDocument]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 05/07/2013
-- Description:	Add ReferrerDocument
-- Version: 1.1

-- History: -
--	1.1:		TGosain: 05/07/2018
--				New columns added.
-- =============================================

CREATE PROCEDURE [referrer].[Add_ReferrerDocument] 
	-- Add the parameters for the stored procedure here
		   (@ReferrerID INT
           ,@DocumentTypeID INT
           ,@UploadDate DATETIME
           ,@UserID INT
           ,@UploadPath VARCHAR(200)
		   ,@ReferrerProjectTreatmentID int)
		   
AS
BEGIN	
INSERT INTO [referrer].[ReferrerDocuments]
           ([ReferrerID]
           ,[DocumentTypeID]
           ,[UploadDate]
           ,[UserID]
           ,[UploadPath]           
		   ,[ReferrerProjectTreatmentID])
	  VALUES
		   (@ReferrerID
           ,@DocumentTypeID
           ,@UploadDate
           ,@UserID
           ,@UploadPath           
		   ,@ReferrerProjectTreatmentID)
	  
	  SELECT SCOPE_IDENTITY()
END






GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerDocumentNew]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 05/07/2013
-- Description:	Add ReferrerDocument
-- Version: 1.1

-- History: -
--	1.1:		TGosain: 05/07/2018
--				New columns added.
-- =============================================

CREATE PROCEDURE [referrer].[Add_ReferrerDocumentNew] 
	-- Add the parameters for the stored procedure here
		   (@ReferrerID INT
           ,@DocumentTypeID INT
           ,@UploadDate DATETIME
           ,@UserID INT
           ,@UploadPath VARCHAR(200)
		   ,@ReferrerDocumentTypeID int
		   ,@CaseID int		   
		   ,@DocumentDate DateTime
		   ,@DocumentName varchar(100)
		   ,@SupplierCheck bit
		   ,@ReferrerCheck bit)
AS
BEGIN	
INSERT INTO [referrer].[ReferrerDocuments]
           ([ReferrerID]
           ,[DocumentTypeID]
           ,[UploadDate]
           ,[UserID]
           ,[UploadPath]           
		   ,[ReferrerDocumentTypeID]
		   ,[CaseID]
		   ,[DocumentDate]
		   ,[DocumentName]
		   ,[SupplierCheck]
		   ,[ReferrerCheck])
	  VALUES
		   (@ReferrerID
           ,@DocumentTypeID
           ,@UploadDate
           ,@UserID
           ,@UploadPath
		   ,@ReferrerDocumentTypeID
		   ,@CaseID
		   ,@DocumentDate
		   ,@DocumentName
		   ,@SupplierCheck
		   ,@ReferrerCheck)
	  
	  SELECT SCOPE_IDENTITY()
END






GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerGroup]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh
-- Create date: 21-11-2019
-- Description:	Add Group Detail

-- =============================================
CREATE PROCEDURE [referrer].[Add_ReferrerGroup] 
	-- Add the parameters for the stored procedure here
	   @GroupName Varchar(50)      
	  ,@UserID varchar(max)
	  ,@ReferrerID int	
AS

BEGIN	
	 if not exists (select GroupName from referrer.ReferrerGroups where GroupName = @GroupName)
	 begin
		INSERT INTO referrer.ReferrerGroups (GroupName, ReferrerID, UserID )
		SELECT @GroupName,@ReferrerID,Item  FROM SplitString (@UserID, ',') 
		SELECT SCOPE_IDENTITY()
	 End
END

GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerLocation]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 10/30/2012
-- Description:	Add referrer location information
-- Version: 1.0
-- =============================================
-- Author:		ftan
-- Create date: 11/07/2012
-- Description:	Added more fields
-- Version: 1.1
-- =============================================
-- Author:		Vishal s
-- Create date: 11/19/2012
-- Description:	Modify Method Add Scope Identity
-- Version: 1.2
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 02/27/2013
-- Description:	Delete the Phone and Fax columns
-- Version: 1.3
-- =============================================
-- Author:		Manjit Singh
-- Create date: 03/05/2013
-- Description:	Added IsActive Field
-- Version: 1.4
-- =============================================

CREATE PROCEDURE [referrer].[Add_ReferrerLocation]
	-- Add the parameters for the stored procedure here
	   @LocationName NVARCHAR(100)
      ,@LocationAddress NVARCHAR(200)
      ,@LocationCity NVARCHAR(100)
      ,@LocationRegion NVARCHAR(100)
      ,@LocationPostCode NVARCHAR(12)
      --,@LocationPhone NVARCHAR(100)
      --,@LocationFax NVARCHAR(100)=null
      ,@IsMainOffice BIT
	  ,@ReferrerID int
	  ,@IsActive BIT
AS
BEGIN	
    INSERT INTO [referrer].[ReferrerLocations] 
	( 
	   [Name]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostCode]
   --   ,[Phone]
	  --,[Fax]
	  ,[IsMainOffice]
      ,[ReferrerID]
      ,[IsActive]
      )
	  VALUES
	  (
	  @LocationName,
	  @LocationAddress,
	  @LocationCity,
	  @LocationRegion,
	  @LocationPostCode,
	  --@LocationPhone,
	  --@LocationFax,
	  @IsMainOffice,
	  @ReferrerID,
	  @IsActive
	  )
  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerProject]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Latest Version : 1.1
--
-- Author:  <Vishal Sen>  
-- Create date: <11-09-2012>  
-- Description: <This Procedure Used Add ReferrerProject Task NO: 130>  
-- Version : 1.0   
-- =============================================  
  
-- Author:  Vishal   
-- Create date: 11-19-2012  
-- Description: Modify Sp Add Scope Identity  
-- =============================================  
  
-- Modified By :  Pardeep Kumar   
-- Date        :  06-13-2013
-- Description :  Modified to Add EmailSendingOptionID
-- Version     :  1.1
  -- =============================================  
  
-- Author:  Vishal   
-- Create date: 06-24-2012  
-- Description: Modify Sp Add Columns
-- =============================================  
   
CREATE PROCEDURE [referrer].[Add_ReferrerProject]  
  
 -- Add the parameters for the stored procedure here  
       @ProjectName NVARCHAR(100)  
      ,@ReferrerID int  
      ,@StatusID int  
      ,@FirstAppointmentOffered bit
      ,@Enabled bit  
      ,@IsTriage bit 
      ,@CentralEmail NVARCHAR(100)
      ,@EmailSendingOptionID  int
	  ,@IsActive bit
      
AS  
BEGIN   
    INSERT INTO [referrer].[ReferrerProjects]   
 (     ProjectName  
      ,ReferrerID  
      ,StatusID  
      ,FirstAppointmentOffered  
      ,[Enabled]
      ,[IsTriage]     
      ,[CentralEmail]  
      ,[EmailSendingOptionID]
	  ,[IsActive]
      )  
   VALUES  
   (   @ProjectName   
      ,@ReferrerID  
      ,@StatusID  
      ,@FirstAppointmentOffered  
      ,@Enabled 
      ,@IsTriage     
      ,@CentralEmail
      ,@EmailSendingOptionID
	  ,@IsActive
   )  
 SELECT SCOPE_IDENTITY()  
END  
  
  
  
  

GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerProjectTreatment]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 11/09/2012
-- Description:	Add referrer project treatments  
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Add_ReferrerProjectTreatment] 
	-- Add the parameters for the stored procedure here
	   @ReferrerProjectID int
      ,@TreatmentCategoryID int
      ,@AccountReceivableChasingPoint int
      ,@AccountReceivableCollection int
      ,@Enabled bit
AS
BEGIN	
	DECLARE @referrerProjectTreatmentID INT;
    INSERT 
	INTO [referrer].[ReferrerProjectTreatments] 
	(  [ReferrerProjectID]
      ,[TreatmentCategoryID]
      ,[AccountReceivableChasingPoint]
      ,[AccountReceivableCollection]
      ,[Enabled]
      )
	  VALUES
	  (
	  @ReferrerProjectID,
	  @TreatmentCategoryID,
	  @AccountReceivableChasingPoint,
	  @AccountReceivableCollection,
	  @Enabled
	  )
	  
	  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerProjectTreatmentAssessment]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 11/10/2012
-- Description:	Add Referrer ProjectTreatment Assessments 
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Add_ReferrerProjectTreatmentAssessment] 
	-- Add the parameters for the stored procedure here
	   @AssessmentServiceID int
      ,@AssessmentTypeID int
      ,@ReferrerProjectTreatmentID int
      
AS
BEGIN	
	DECLARE @referrerProjectTreatmentAssessmentID INT
    INSERT 
	INTO [referrer].[ReferrerProjectTreatmentAssessments] 
	(  [AssessmentServiceID]
      ,[AssessmentTypeID]
      ,[ReferrerProjectTreatmentID]
      
      )
	  VALUES
	  (
		 @AssessmentServiceID 
		,@AssessmentTypeID 
		,@ReferrerProjectTreatmentID 
	  )
	  
	  
	  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerProjectTreatmentAuthorisation]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Latest Version 1.1    
    
-- Author:  Satya    
-- Create date: 11/10/2012    
-- Description: Add Referrer ProjectTreatment Authorisation    
-- Version: 1.0    
    
-- Author:  Anuj Batra    
-- Create date: 12/06/2012    
-- Description: Update the StoredProcedure.    
-- Version: 1.1    
-- =============================================    
    
CREATE PROCEDURE [referrer].[Add_ReferrerProjectTreatmentAuthorisation]     
 -- Add the parameters for the stored procedure here    
     @TreatmentCategoryID INT    
  ,@DelegatedAuthorisationTypeID INT    
  ,@Amount MONEY    
  ,@ReferrerProjectTreatmentID INT 
  ,@Enabled BIT 
  ,@Quantity INT     
          
AS    
BEGIN     
 DECLARE @referrerProjectTreatmentAuthorisationID INT    
     
    INSERT INTO [referrer].[ReferrerProjectTreatmentAuthorisations]    
     ([TreatmentCategoryID]    
           ,[DelegatedAuthorisationTypeID]    
           ,[Amount]    
           ,[ReferrerProjectTreatmentID]
           ,[Enabled]    
           ,[Quantity]
           )    
   VALUES    
   (    
   @TreatmentCategoryID     
  ,@DelegatedAuthorisationTypeID    
  ,@Amount    
  ,@ReferrerProjectTreatmentID  
   ,@Enabled  
  ,@Quantity     
   )    
         
   SELECT SCOPE_IDENTITY()    
END 

GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerProjectTreatmentDocumentSetup]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/06/2012
-- Description:	Add Add_ReferrerProjectTreatmentDocumentSetup
-- Version: 1.0
--

-- =============================================

CREATE PROCEDURE [referrer].[Add_ReferrerProjectTreatmentDocumentSetup] 
	-- Add the parameters for the stored procedure here
(	   
@AssessmentServiceID int,
@DocumentSetupTypeID int,
@ReferrerProjectTreatmentID int
)
      
AS
BEGIN	

    INSERT     
    INTO referrer.ReferrerProjectTreatmentDocumentSetup
	( 
	AssessmentServiceID,
	DocumentSetupTypeID,
    ReferrerProjectTreatmentID
      
      )
	  VALUES
	  (
	@AssessmentServiceID,
	@DocumentSetupTypeID,
    @ReferrerProjectTreatmentID
	  )
	  
	  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerProjectTreatmentEmail]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 11/14/2012
-- Description:	AddReferrerProjectTreatmentEmail
-- Version: 1.0
-- =============================================

-- Author:		Vishal 
-- Create date: 11-19-2012
-- Description:	Modify Sp Add Scope Identity


CREATE PROCEDURE [referrer].[Add_ReferrerProjectTreatmentEmail] 
	-- Add the parameters for the stored procedure here
	@ReferrerProjectTreatmentID int,
	@EmailTypeID int,
	@EmailTypeValueID int
AS
BEGIN
	insert into referrer.ReferrerProjectTreatmentEmails(ReferrerProjectTreatmentID,
	EmailTypeID ,
	EmailTypeValueID) values(@ReferrerProjectTreatmentID,
	@EmailTypeID ,
	@EmailTypeValueID)	
	
	
 SELECT SCOPE_IDENTITY()
	
END


GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerProjectTreatmentInvoice]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Satya 
-- Create date: 11-22-2012
-- Description:	Create Add stored proc for Add_ReferrerProjectTreatmentInvoice
-- =============================================

CREATE PROCEDURE [referrer].[Add_ReferrerProjectTreatmentInvoice]
	-- Add the parameters for the stored procedure here
			(@InvoicePrice MONEY
			,@ManagementPrice MONEY
			,@ManagementFeeEnabled BIT
			,@InvoiceMethodID INT
			,@ReferrerProjectTreatmentID INT)
AS
BEGIN

INSERT INTO
[referrer].[ReferrerProjectTreatmentInvoice] 
		  ([InvoicePrice]
		  ,[ManagementPrice]
		  ,[ManagementFeeEnabled]
		  ,[InvoiceMethodID]
		  ,[ReferrerProjectTreatmentID])
  
VALUES
		(@InvoicePrice
         ,@ManagementPrice
         ,@ManagementFeeEnabled
         ,@InvoiceMethodID
         ,@ReferrerProjectTreatmentID)

 SELECT SCOPE_IDENTITY()
 
END



GO
/****** Object:  StoredProcedure [referrer].[Add_ReferrerProjectTreatmentPricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vishal 
-- Create date: 11-14-2012
-- Description:	Create A Sp For Add_ReferrerProjectTreatmentPricing
-- =============================================
-- Author:		Vishal 
-- Create date: 11-19-2012
-- Description:	Modify Sp Add Scope Identity

CREATE PROCEDURE [referrer].[Add_ReferrerProjectTreatmentPricing]
	-- Add the parameters for the stored procedure here
	
	@PricingTypeID int,
	@Price money,
	@ReferrerProjectTreatmentID int
AS
BEGIN
insert into
[referrer].[ReferrerProjectTreatmentPricing] 
(
PricingTypeID,
Price,
ReferrerProjectTreatmentID
)
values
(
@PricingTypeID,
@Price,
@ReferrerProjectTreatmentID
)

 SELECT SCOPE_IDENTITY()
END



GO
/****** Object:  StoredProcedure [referrer].[AddReferrerCaseAssessmentModifications]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Latest Version: 1.1    
    
-- Author:  PKAUR   
-- Create date: April 23, 2018   
-- Description: to add ReferrerCaseAssessmentModifications    
-- =============================================    
CREATE PROCEDURE [referrer].[AddReferrerCaseAssessmentModifications]
      @CaseID int
      ,@TreatmentSession int
      ,@AssessmentServiceID int
      

 AS 
 begin
 
 INSERT INTO  [referrer].[ReferrerCaseAssessmentModifications](
      [CaseID]
      ,[TreatmentSession]
      ,[AssessmentServiceID])
 VALUES(@CaseID,@TreatmentSession,@AssessmentServiceID)

end




GO
/****** Object:  StoredProcedure [referrer].[Delete_GroupByID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh
-- Create date: 23-11-2019	
-- Description:	Delete group By Id
-- =============================================
CREATE PROCEDURE [referrer].[Delete_GroupByID]  
	@GroupID INT
AS
 DELETE FROM [referrer].[ReferrerGroups]
      WHERE GroupID=@GroupID
GO
/****** Object:  StoredProcedure [referrer].[Delete_ReferrerLocationByReferrerLocationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anuj Batra
-- Create date: 10/30/2012
-- Description:	Stored procedure to delete referrer location by referrerlocationID
-- Version: 1.0
-- =============================================
-- Author:		Manjit Singh
-- Create date: 03/05/2013
-- Description:	Updated record instead of delete
-- Version: 1.1
-- =============================================
CREATE PROCEDURE [referrer].[Delete_ReferrerLocationByReferrerLocationID] 
	 @ReferrerLocationID int
AS
	update [referrer].[ReferrerLocations] set IsActive=0 where  ReferrerLocationID=  @ReferrerLocationID

GO
/****** Object:  StoredProcedure [referrer].[Delete_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentAssessmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vijay Kumar
-- Create date: 11/15/2012
-- Description:	Delete Referrer ProjectTreatment Assessments by ReferrerProjectTreatmentAssessmentID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Delete_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentAssessmentID] 
	-- Add the parameters for the stored procedure here

	   @ReferrerProjectTreatmentAssessmentID int      
AS
BEGIN	
	  
	  DELETE FROM [referrer].[ReferrerProjectTreatmentAssessments] WHERE [ReferrerProjectTreatmentAssessmentID] = @ReferrerProjectTreatmentAssessmentID
	  
END


GO
/****** Object:  StoredProcedure [referrer].[Delete_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentAuthorisationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Vijay Kumar
-- Create date: 11/15/2012
-- Description:	Delete ReferrerProject Treatment Authorisation by ReferrerProjectTreatmentAuthorisationID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Delete_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentAuthorisationID] 
	-- Add the parameters for the stored procedure here

	    @ReferrerProjectTreatmentAuthorisationID INT      
AS
BEGIN	
	  
	DELETE FROM [referrer].[ReferrerProjectTreatmentAuthorisations] WHERE [ReferrerProjectTreatmentAuthorisationID] = @ReferrerProjectTreatmentAuthorisationID
	  
END

GO
/****** Object:  StoredProcedure [referrer].[Delete_ReferrerProjectTreatmentEmailById]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 11/14/2012
-- Description:	Delete Referrer by Email ID
-- Version: 1.0
-- =============================================
-- Author:		Vishal
-- Create date: 11/21/2012
-- Description:	Change Name Convention [DeleteReferrerProjectTreatmentEmailById] to [Delete_ReferrerProjectTreatmentEmailById] 
-- Version: 1.0
-- =============================================
CREATE PROCEDURE [referrer].[Delete_ReferrerProjectTreatmentEmailById] 
	-- Add the parameters for the stored procedure here
	@treatmentEmailId int
AS
BEGIN
	delete from referrer.ReferrerProjectTreatmentEmails where ReferrerProjectTreatmentEmailID=@treatmentEmailId
END


GO
/****** Object:  StoredProcedure [referrer].[Get_AllReferrers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* ===========================================================
   <Latest Version : 1.0 >
   <Author>      : Pardeep Kumar
   <Date>        : 27-Sep-2013
   <Description> : Get All Referrers
   <Version>     : 1.0
   ===========================================================
*/


CREATE PROCEDURE [referrer].[Get_AllReferrers]
as

select ReferrerID,ReferrerName from referrer.Referrers order by ReferrerID asc

GO
/****** Object:  StoredProcedure [referrer].[Get_CaseTreatmentPricingApproveOrPendingByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [referrer].[Get_CaseTreatmentPricingApproveOrPendingByCaseID] 
	@CaseID int
AS
BEGIN
	   Select PT.PricingTypeName as [Type],CTP.Quantity,
          (CASE WHEN CTP.AuthorizationStatus = 1 Then 'Approved' ELSE 'Pending' END) as [Status]
          FROM[global].[CaseTreatmentPricing] CTP 
              INNER JOIN [supplier].[SupplierTreatmentPricing] STP ON  STP.PricingID = CTP.SupplierPriceID
              INNER JOIN [global].[CaseAssessments] Ca ON Ca.CaseID = CTP.CaseID
              INNER JOIN [lookup].[PricingTypes] PT ON PT.PricingTypeID = STP.PricingTypeID WHERE Ca.CaseID = 1046
END


GO
/****** Object:  StoredProcedure [referrer].[Get_CaseTreatmentPricingByCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh	
-- Create date: 09-05-2018
-- Description:	Get CaseTreatmentPricing Approve Or Pending By CaseID
-- Author:		Mahinder Singh	
-- Create date: 22-Aug-2018
-- Spritn     : 15
-- Description:	User Story #3364: Referrer / Supplier Portal - Case Search - Case Treatment Tab
-- [referrer].[Get_CaseTreatmentPricingByCaseID] 1080
-- =============================================
CREATE PROCEDURE [referrer].[Get_CaseTreatmentPricingByCaseID] 
	@CaseID int
AS
BEGIN
	   Select  CTP.CaseID,PT.PricingTypeName as [Type],( CASE When PT.PricingTypeName = 'Initial Assessment' Then 1 ELSE isnull(CTP.Quantity,0) END)as [QTY],
          (CASE WHEN CTP.AuthorizationStatus = 1 Then (
		                           CASE WHEN CTP.PatientDidNotAttend = 1 THEN 'Did Not Attend'   WHEN CTP.WasAbandoned = 1 THEN 'Not Required' ELSE 'Approved' END ) 
		   WHEN CTP.AuthorizationStatus = 0 Then (
		                           CASE WHEN CTP.PatientDidNotAttend = 1 THEN 'Did Not Attend'   WHEN CTP.WasAbandoned = 1 THEN 'Not Required' ELSE 'Denied' END )  
		   ELSE (
		                           CASE WHEN CTP.PatientDidNotAttend = 1 THEN 'Did Not Attend'   WHEN CTP.WasAbandoned = 1 THEN 'Not Required' ELSE 'Pending' END ) END) as [Status], 
								   
								   (case when (isnull(CTP.DateOfService,null) is not null  or (PT.PricingTypeName= 'Did Not Attend')) then CTP.DateOfService else CTP.PatientDidNotAttendDate end) AS DateOfService

          FROM[global].[CaseTreatmentPricing] CTP 
              INNER JOIN [supplier].[SupplierTreatmentPricing] STP ON  STP.PricingID = CTP.SupplierPriceID
              INNER JOIN [global].[CaseAssessments] Ca ON Ca.CaseID = CTP.CaseID
              INNER JOIN [lookup].[PricingTypes] PT ON PT.PricingTypeID = STP.PricingTypeID WHERE Ca.CaseID = @CaseID and CTP.IsDeleted = 0
END


GO
/****** Object:  StoredProcedure [referrer].[Get_GroupUsersByReferrerIDAndName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh
-- Create date: 23-11-2019
-- Description:	Get group User by Name and ReferrerID
-- [referrer].[Get_GroupUsersByReferrerIDAndName] '565623564',566
-- =============================================
CREATE PROCEDURE [referrer].[Get_GroupUsersByReferrerIDAndName]  
@Name varchar(50),
@ReferrerID int
AS
BEGIN
	Select (u.FirstName + ' ' + u.LastName) As UserName,u.UserID,rg.ReferrerID, RG.GroupName, RG.GroupID 
	from [referrer].[ReferrerGroups] RG
	
	INNER JOIN [global].[Users] u on u.UserID = RG.UserID
    where RG.ReferrerID = @ReferrerID And RG.GroupName = @Name
END

GO
/****** Object:  StoredProcedure [referrer].[Get_ProjectTreatmentSLAsByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vishal 
-- Create date: 11-14-2012
-- Description:	Create A Sp For [Get_ProjectTreatmentSLAsByByProjectTreatmentSLAID]
-- =============================================
CREATE PROCEDURE [referrer].[Get_ProjectTreatmentSLAsByReferrerProjectTreatmentID]
	-- Add the parameters for the stored procedure here
	@ReferrerProjectTreatmentID int
AS
BEGIN
select * From 
referrer.ProjectTreatmentSLAs
where ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID

END

GO
/****** Object:  StoredProcedure [referrer].[Get_ProjectTreatmentSLAsNameByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Satya   
-- Create date: 07-26-2013  
-- Description: Get ProjectTreatmentSLAs Name By ReferrerProjectTreatmentID  
-- =============================================  
CREATE PROCEDURE [referrer].[Get_ProjectTreatmentSLAsNameByReferrerProjectTreatmentID]  
 -- Add the parameters for the stored procedure here  
 @ReferrerProjectTreatmentID int  
AS  
BEGIN  
select referrer.ProjectTreatmentSLAs.*,[lookup].[ServiceLevelAgreements].ServiceLevelAgreementName From   
referrer.ProjectTreatmentSLAs 
INNER JOIN [lookup].[ServiceLevelAgreements] 
ON referrer.ProjectTreatmentSLAs.ServiceLevelAgreementID = [lookup].[ServiceLevelAgreements] .ServiceLevelAgreementID
where ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID  

END

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerAssignedUserByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ==============================================================================
-- Author:		Jasingh	
-- Create date: 21-05-2018
-- Description:	Get  AssignedUser by ReferrerID using Conditions
---   [referrer].[Get_ReferrerAssignedUserByReferrerID] 566
-- ===============================================================================
CREATE PROCEDURE [referrer].[Get_ReferrerAssignedUserByReferrerID] 
	@ReferrerID int
AS
BEGIN
	Select USERID,(FirstName + ' ' + LastName)  as AssignedUser from global.Users where UserTypeID = 2 And ReferrerID = @ReferrerID  AND IsLocked =0 
	order by FirstName
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerAuthorisationCountByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================    
-- Author:  <Pardeep Kumar>    
-- Create date: <09-27-2013>    
-- Description: <Get_ReferrerAuthorisationCountByReferrerID>    
-- ============================================= 
-- =============================================          
-- Author:  <Mahinder Singh>          
-- Create date: <10-Oct-2018>          
-- Description: <User Permission>    
--       [referrer].[Get_ReferrerAuthorisationCountByReferrerID] 566,498
-- =============================================    
    
CREATE PROCEDURE [referrer].[Get_ReferrerAuthorisationCountByReferrerID]     
(    
@ReferrerID INT,
@UserID INT
)    
as   
BEGIN 
     DECLARE @UserRole VARCHAR(50)

	SET @UserRole = (SELECT ReferrerTypes  FROM [global].[Users]  where UserID = @UserID)
 
	 IF((@UserRole = 'Referrer Admin') OR (@UserRole = 'Referrer Project Admin'))
	 BEGIN 
		WITH Authorisations AS  
		(  
		 SELECT ROW_NUMBER() Over (Order By CaseID) As ROW, CaseID  
		  From referrer.[ReferrerAuthorisations] where ReferrerID = @ReferrerID  and WorkflowID in (90,92,150,152,180,182)
		)  
		 SELECT COUNT(*)'Count' 
			  FROM         referrer.ReferrerAuthorisations AS r INNER JOIN
							  Authorisations AS a ON a.CaseID = r.CaseID INNER JOIN
							  global.Cases ON r.CaseID = global.Cases.CaseID LEFT OUTER JOIN
							  global.CaseAssessments ON global.Cases.CaseID = global.CaseAssessments.CaseID
		

	 END
	 ELSE IF(@UserRole = 'Referrer Project User')
	 BEGIN 
	     WITH Authorisations AS  
		(  
		 SELECT ROW_NUMBER() Over (Order By CaseID) As ROW, CaseID  
		  From referrer.[ReferrerAuthorisations] where ReferrerID = @ReferrerID  and WorkflowID in (90,92,150,152,180,182)
		)  
		 SELECT COUNT(*)'Count' 
			  FROM         referrer.ReferrerAuthorisations AS r INNER JOIN
							  Authorisations AS a ON a.CaseID = r.CaseID INNER JOIN
							  global.Cases ON r.CaseID = global.Cases.CaseID LEFT OUTER JOIN
							  global.CaseAssessments ON global.Cases.CaseID = global.CaseAssessments.CaseID INNER JOIN
							  global.CaseReferrerAssignedUsers CAU ON global.Cases.CaseID = CAU.CaseID
		WHERE CAU.UserID = @UserID 
	 END
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerAuthorisationsByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  

-- =============================================  
-- Author:  <Pardeep Kumar>  
-- Create date: <04-17-2013>  
-- Description: <Created the Get ReferrerAuthorisations by ReferrerID>  
-- =============================================  
-- =============================================          
-- Author:  <Mahinder Singh>          
-- Create date: <10-Oct-2018>          
-- Description: <User Permission>          
-- ============================================= 
--- [referrer].[Get_ReferrerAuthorisationsByReferrerID] 566,539,0,5  
CREATE PROCEDURE [referrer].[Get_ReferrerAuthorisationsByReferrerID]   
(  
@ReferrerID INT,
@UserID INT,
@Skip INT,
@Take INT 
)  
as 
BEGIN 
 DECLARE @UserRole VARCHAR(50)

	SET @UserRole = (SELECT ReferrerTypes  FROM [global].[Users]  where UserID = @UserID)
 
 IF((@UserRole = 'Referrer Admin') OR (@UserRole = 'Referrer Project Admin'))
 BEGIN  
        WITH Authorisations AS
		(
			SELECT ROW_NUMBER() Over (Order By CaseID) As ROW, CaseID
				From referrer.[ReferrerAuthorisations] where ReferrerID = @ReferrerID and WorkflowID in (90,92,150,152,180,182)
		)
		SELECT     r.CaseReferrerDueDate, r.FirstName, r.LastName, r.CaseReferrerReferenceNumber, r.CaseNumber, r.TreatmentTypeName, r.WorkflowID, r.ReferrerID, r.PatientID, 
							  r.SupplierID, r.CaseID, a.ROW, isnull(global.Cases.IsCustom,0) as IsCustom,  global.Cases.ReferrerProjectTreatmentID, isnull(global.CaseAssessments.AssessmentServiceID,1) as AssessmentServiceID
		FROM         referrer.ReferrerAuthorisations AS r INNER JOIN
							  Authorisations AS a ON a.CaseID = r.CaseID INNER JOIN
							  global.Cases ON r.CaseID = global.Cases.CaseID LEFT OUTER JOIN
							  global.CaseAssessments ON global.Cases.CaseID = global.CaseAssessments.CaseID
	    WHERE  a.ROW BETWEEN @Skip + 1 AND @Skip + @Take 
 END
 ELSE IF(@UserRole = 'Referrer Project User')
 BEGIN 
  --      WITH Authorisations AS
		--(
		--	SELECT ROW_NUMBER() Over (Order By CaseID) As ROW, CaseID
		--		From referrer.[ReferrerAuthorisations] where ReferrerID = @ReferrerID and WorkflowID in (90,92,150,152,180,182)
		--)
		--SELECT     r.CaseReferrerDueDate, r.FirstName, r.LastName, r.CaseReferrerReferenceNumber, r.CaseNumber, r.TreatmentTypeName, r.WorkflowID, r.ReferrerID, r.PatientID, 
		--					  r.SupplierID, r.CaseID, a.ROW, isnull(global.Cases.IsCustom,0) as IsCustom,  global.Cases.ReferrerProjectTreatmentID, isnull(global.CaseAssessments.AssessmentServiceID,1) as AssessmentServiceID
		--FROM         referrer.ReferrerAuthorisations AS r INNER JOIN
		--					  Authorisations AS a ON a.CaseID = r.CaseID INNER JOIN
		--					  global.Cases ON r.CaseID = global.Cases.CaseID LEFT OUTER JOIN
		--					  global.CaseAssessments ON global.Cases.CaseID = global.CaseAssessments.CaseID INNER JOIN
		--					  global.CaseReferrerAssignedUsers CAU ON global.Cases.CaseID = CAU.CaseID
		--WHERE CAU.UserID = @UserID and  a.ROW BETWEEN @Skip + 1 AND @Skip + @Take


		WITH Authorisations AS
		(
			SELECT ROW_NUMBER() Over (Order By r.CaseID) As ROW, r.CaseReferrerDueDate, r.FirstName, r.LastName, r.CaseReferrerReferenceNumber, r.CaseNumber, r.TreatmentTypeName, r.WorkflowID, r.ReferrerID, r.PatientID, 
							  r.SupplierID, r.CaseID, isnull(global.Cases.IsCustom,0) as IsCustom,  global.Cases.ReferrerProjectTreatmentID, isnull(global.CaseAssessments.AssessmentServiceID,1) as AssessmentServiceID
		FROM         referrer.ReferrerAuthorisations AS r INNER JOIN
							  global.Cases ON r.CaseID = global.Cases.CaseID LEFT OUTER JOIN
							  global.CaseAssessments ON global.Cases.CaseID = global.CaseAssessments.CaseID INNER JOIN
							  global.CaseReferrerAssignedUsers CAU ON global.Cases.CaseID = CAU.CaseID
		WHERE CAU.UserID = @UserID and r.ReferrerID = @ReferrerID and r.WorkflowID in (90,92,150,152,180,182)
		)
		SELECT * FROM Authorisations  a WHERE  a.ROW BETWEEN @Skip + 1 AND @Skip + @Take
 END

END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerCaseAssessmentModificationsbyCaseID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  <PKaur>  
-- Create date: <01-08-2018>  
-- Description: <Get ReferrerCaseAssessmentModifications by CaseID >  
-- =============================================  
CREATE PROCEDURE [referrer].[Get_ReferrerCaseAssessmentModificationsbyCaseID]  
(  
@CaseID INT

)  
AS  
SELECT TOP 1 RC.CaseID,RC.TreatmentSession,RC.ReferrerCaseAssessmentModificationID,RC.AssessmentServiceID,Assessment.AssessmentServiceName FROM  [referrer].[ReferrerCaseAssessmentModifications] AS RC INNER JOIN  [lookup].[AssessmentServices] AS Assessment ON RC.AssessmentServiceID=Assessment.AssessmentServiceID
WHERE RC.CaseID=@CaseID ORDER BY RC.ReferrerCaseAssessmentModificationID DESC









GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerCompleteProjectsByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ftan
-- Create date: 04-26-2013
-- Description:	get completed projects by for a referrer by passing referrerid
-- =============================================
-- Author:		Vishal sen
-- Create date: 06-24-2013
-- Description:	get completed projects by for a referrer by passing referrerid
-- =============================================
-- Author:		Param Kaur
-- Create date: 04-30-2019
-- Description:	IsActive filed added
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerCompleteProjectsByReferrerID]  
	@ReferrerID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *
	FROM [referrer].[ReferrerProjects] 
	WHERE ([ReferrerID] = @ReferrerID AND StatusID = 1 AND IsActive=1)
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerDocumentsByCaseId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rohit Kumar
-- Create date: 16/12/2014
-- Description:	Get Referrer Documents By CaseId
-- Version: 1.0

-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerDocumentsByCaseId] 
	-- Add the parameters for the stored procedure here
		   (@CaseID int
		   ,@DocumentTypeID int
           )
AS
BEGIN	
	DECLARE @ReferrerID AS INT
	DECLARE @ReferrerProjectTreatmentID AS INT
	SELECT  @ReferrerID=ReferrerID , @ReferrerProjectTreatmentID=ReferrerProjectTreatmentID FROM GLOBAL.cases WHERE caseId= @CaseId
	 
	SELECT * FROM Referrer.ReferrerDocuments WHERE referrerid  = @ReferrerID and ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID and 
	DocumentTypeID= @DocumentTypeID
  
END





GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerDocumentsByReferrerIDAndDocumentTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 05/07/2013
-- Description:	Get ReferrerDocuments By ReferrerID AndD ocumentTypeID
-- Version: 1.0

-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerDocumentsByReferrerIDAndDocumentTypeID] 
	-- Add the parameters for the stored procedure here
		   (@ReferrerID INT
           ,@DocumentTypeID INT
           )
AS
BEGIN	
SELECT *
  FROM [referrer].[ReferrerDocuments]
  WHERE [ReferrerDocuments].ReferrerID = @ReferrerID AND [ReferrerDocuments].DocumentTypeID = @DocumentTypeID
END




GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 16/12/2014
-- Description:	Get Referrer Documents By ReferrerID , DocumentTypeID And ReferrerProjectTreatmentID
-- Version: 1.0

-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID] 
	-- Add the parameters for the stored procedure here
		   (@ReferrerID INT
           ,@DocumentTypeID INT
           ,@ReferrerProjectTreatmentID int
           )
AS
BEGIN	
SELECT *
  FROM [referrer].[ReferrerDocuments]
  WHERE [ReferrerDocuments].ReferrerID = @ReferrerID AND [ReferrerDocuments].DocumentTypeID = @DocumentTypeID and ReferrerProjectTreatmentID =@ReferrerProjectTreatmentID
END




GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerDocumentType]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================    
-- Latest Version: 1.0
    
-- Author:  TGosain   
-- Create date: 05-25-2018
-- Description: Get Refrerrer Document Type 
-- =============================================    
CREATE PROCEDURE [referrer].[Get_ReferrerDocumentType]
 AS 
 begin
 
select * from lookup.ReferrerDocumentType
where ReferrerDocumentTypeID <> 3

end




GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerEnabledProjectTreatmentNamesByReferrerProjectID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [referrer].[Get_ReferrerEnabledProjectTreatmentNamesByReferrerProjectID]
	@ReferrerProjectID int
AS
	select ReferrerProjectTreatmentID,TreatmentCategoryName from [referrer].[ReferrerProjectTreatments] rp inner join	
			lookup.TreatmentCategories tc
	on rp.TreatmentCategoryID = tc.TreatmentCategoryID
	where ReferrerProjectID = @ReferrerProjectID AND rp.Enabled =1

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerExistsByName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Latest Version : 1.1
-- Author:		Robin Singh
-- Create date: 06/06/2013
-- Description:	Procedure to check referrername exists 
-- Version: 1.0
-- Updated By:		Robin Singh
-- Create date: 06/10/2013
-- Description:	Rename Procedure Name Is_ReferrerNameExists by  Get_ReferrerExistsByName
-- Version: 1.1
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerExistsByName] 
(
@ReferrerName VARCHAR(50)
)
AS
SELECT CAST( 
   CASE WHEN EXISTS(SELECT ReferrerName FROM referrer.Referrers WHERE ReferrerName=@ReferrerName) THEN 1  
   ELSE 0  
   END  
AS BIT)






GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerGroupUsersCasesByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		jasingh
-- Create date: 17-01-2020
-- Description:	Get user cases according to the ReferrerID
-- [referrer].[Get_ReferrerGroupUsersCasesByReferrerID] '565623564', '566',0,50
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerGroupUsersCasesByReferrerID]   
	@Name varchar(50),
	@ReferrerID int,
	@Skip INT,
	@Take INT
AS
BEGIN
	WITH Result AS
	(
	Select  DISTINCT ROW_NUMBER() OVER(ORDER BY RSC.CaseID DESC) AS RowNumber ,(u.FirstName + ' ' + u.LastName) as UserFullName,
	     RSC.PatientID,RSC.FirstName,RSC.LastName,RSC.CaseSubmittedDate,RSC.PostCode,RSC.CaseID,RSC.CaseNumber,RSC.WorkflowID           
		,RSC.CaseReferrerReferenceNumber,RSC.HomePhone,RSC.WorkPhone,RSC.MobilePhone,RSC.ReferrerID,RSC.SupplierID,
		RSC.InitialAssessmentDate,RSC.FinalAssessmentDate,RSC.InitialCaseAssessmentDetailID,RSC.FinalCaseAssessmentDetailID
		,RSC.InitialAssessmentServiceID,RSC.FinalAssessmentServiceID , RSC.Status
	
	 from [referrer].[ReferrerGroups] RG
	INNER JOIN [global].[Users] u on u.UserID = RG.UserID
	INNER JOIN [global].[ReferrerSupplierCases] RSC on RSC.ReferrerAssignedUser = u.UserID	
	  where RG.ReferrerID = @ReferrerID And RG.GroupName LIKE  @Name + '%' AND RSC.Status = 1)

	   SELECT * FROM Result 
		   WHERE Result.RowNumber BETWEEN @Skip + 1 AND @Skip + @Take 
END

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerGroupUsersCasesByReferrerIDCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh
-- Create date: 17-01-2020
-- Description:	Get User Caseas Counts BY referrer ID
-- [referrer].[Get_ReferrerGroupUsersCasesByReferrerIDCount] '565623564', '566'
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerGroupUsersCasesByReferrerIDCount]  
	@Name varchar(50),
	@ReferrerID int
AS
BEGIN
WITH Result AS
	(
	Select  DISTINCT ROW_NUMBER() OVER(ORDER BY RSC.CaseID DESC) AS RowNumber ,(u.FirstName + ' ' + u.LastName) as UserFullName,
	     RSC.PatientID,RSC.FirstName,RSC.LastName,RSC.CaseSubmittedDate,RSC.PostCode,RSC.CaseID,RSC.CaseNumber,RSC.WorkflowID           
		,RSC.CaseReferrerReferenceNumber,RSC.HomePhone,RSC.WorkPhone,RSC.MobilePhone,RSC.ReferrerID,RSC.SupplierID,
		RSC.InitialAssessmentDate,RSC.FinalAssessmentDate,RSC.InitialCaseAssessmentDetailID,RSC.FinalCaseAssessmentDetailID
		,RSC.InitialAssessmentServiceID,RSC.FinalAssessmentServiceID  from [referrer].[ReferrerGroups] RG

	INNER JOIN [global].[Users] u on u.UserID = RG.UserID
	INNER JOIN [global].[ReferrerSupplierCases] RSC on RSC.ReferrerAssignedUser = u.UserID
		  where RG.ReferrerID = @ReferrerID And RG.GroupName LIKE  @Name + '%')

	    SELECT COUNT(*) AS TotalCount FROM Result 
END

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerIdAgtReferrerProjectTreatmentId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rohit Kumar
-- Create date: 04/02/2015
-- Description:	Get ReferrerId Agt ReferrerProjectTreatmentId
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerIdAgtReferrerProjectTreatmentId] 
	-- Add the parameters for the stored procedure here
		@referrerProjectTreatmentID int
AS
BEGIN	
	SELECT      referrer.ReferrerProjects.ReferrerID
	FROM         referrer.ReferrerProjects INNER JOIN
						  referrer.ReferrerProjectTreatments ON referrer.ReferrerProjects.ReferrerProjectID = referrer.ReferrerProjectTreatments.ReferrerProjectID
	 WHERE referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID = @referrerProjectTreatmentID
END




GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerIDbyReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		GJain 
-- Create date: 12/12/2014
-- Description:	Stored procedure to get ReferrerID by ReferrerProjectTreatmentID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerIDbyReferrerProjectTreatmentID] 
	 @ReferrerProjectTreatmentID int
AS
	SELECT ReferrerID
  FROM  [referrer].[ReferrerProjects]
where [ReferrerProjectID]=(select ReferrerProjectID from [referrer].ReferrerProjectTreatments where [ReferrerProjectTreatmentID]= @ReferrerProjectTreatmentID)

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerInfoByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ftan
-- Create date: 10/26/2012
-- Description:	get referrer information
-- Version: 1.0
-- =============================================
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 02/27/2013
-- Description:	added the [ReferrerMainContactFax]  and [ReferrerMainContactPhone] columns
-- Version: 1.1
-- =============================================
-- Author:		Vishal Sen
-- Create date: 06/13/2013
-- Description:	Remove two parameter from Sp ReferrerCentralEmail,EmailSendingOptionID
-- Version: 1.3
-- =============================================
-- =============================================
-- Author:		Rohit Kumar
-- Create date: 21/09/2018
-- Description:	#3384 - Internal Portal - Referrer Setup - New Section - Referral Setup
-- Version: 1.4
-- =============================================

-- =============================================
-- Author:		Rohit Kumar
-- Create date: 08/04/2019
-- Description:	#3553 - Internal Portal -Referrer Setup - New Sections
-- Version: 1.5
-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerInfoByReferrerID] 
	-- Add the parameters for the stored procedure here
	@ReferrerID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [ReferrerID]
      ,[ReferrerName]
      ,[ReferrerContactFirstName]
      ,[ReferrerContactLastName]     
      ,[ReferrerMainContactEmail]     
      ,[ReferrerMainContactFax] 
      ,[ReferrerMainContactPhone] 
      ,[DateAdded]
	  --,isnull(IsPolicyDetail,0) as IsPolicyDetail
	  , IsPolicyDetail
	  , isnull(IsEmploymentDetail,0) as IsEmploymentDetail
	  , isnull(IsEmploeeDetail,0) as IsEmploeeDetail
	  ,isnull(IsDrugandAlcoholTest, 0) as IsDrugandAlcoholTest
	  ,isnull(IsRepresentation , 0) as IsRepresentation	  
	  ,  isnull(IsAdditionalQuestion , 0) as IsAdditionalQuestion 
	  ,  isnull(IsJobDemand , 0) as IsJobDemand
	  ,isnull(IsPolicyDetailOpenOrDropdowns, 0) as  IsPolicyDetailOpenOrDropdowns
	  ,isnull(IsNewPolicyTypes,'') as IsNewPolicyTypes
  FROM [referrer].[Referrers]
  WHERE [referrer].Referrers.ReferrerID = @ReferrerID
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerLocationReferrerLikeReferrerName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Satya>
-- Create date: <11-08-2012>
-- Description:	<This Procedure Used For paged  Referrername >
-- Version	:	1.0	
-- =============================================

CREATE PROCEDURE  [referrer].[Get_ReferrerLocationReferrerLikeReferrerName]	 --'AB', 2,10

@ReferrerName NVARCHAR(100),
@Skip INT,    
 @Take INT 
AS 
    BEGIN
    
SET NOCOUNT ON;
WITH ReferrersMatched AS
(
SELECT ROW_NUMBER() Over (Order By [referrer].[Referrers].ReferrerID) As ROW,referrer.Referrers.ReferrerID, referrer.Referrers.ReferrerName, referrer.Referrers.ReferrerMainContactPhone, referrer.ReferrerLocations.City, 
                      referrer.ReferrerLocations.Name
 FROM         referrer.Referrers INNER JOIN
                      referrer.ReferrerLocations ON referrer.Referrers.ReferrerID = referrer.ReferrerLocations.ReferrerID
WHERE     (referrer.ReferrerLocations.IsMainOffice = 'true') AND [referrer].[Referrers].[ReferrerName] LIKE (@ReferrerName + '%')
 )
select * from ReferrersMatched prp  
   where prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take

 END
 
--SELECT     referrer.Referrers.ReferrerID, referrer.Referrers.ReferrerName, referrer.Referrers.ReferrerMainContactPhone, referrer.ReferrerLocations.City, 
--                      referrer.ReferrerLocations.Name
--FROM         referrer.Referrers INNER JOIN
--                      referrer.ReferrerLocations ON referrer.Referrers.ReferrerID = referrer.ReferrerLocations.ReferrerID
--WHERE     (referrer.ReferrerLocations.IsMainOffice = 'true') AND [referrer].[Referrers].[ReferrerName] LIKE (@ReferrerName + '%')


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerLocationReferrerLikeReferrerNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Satya>
-- Create date: <24-07-2013>
-- Description:	<This Procedure Used for Count Get_ReferrerLocationReferrer Like ReferrerName>
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [referrer].[Get_ReferrerLocationReferrerLikeReferrerNameCount] 

@ReferrerName NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  FROM         referrer.Referrers INNER JOIN
                      referrer.ReferrerLocations ON referrer.Referrers.ReferrerID = referrer.ReferrerLocations.ReferrerID
WHERE     (referrer.ReferrerLocations.IsMainOffice = 'true') AND [referrer].[Referrers].[ReferrerName] LIKE (@ReferrerName + '%')
 
 End

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerLocationsByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vishal
-- Create date: 10/30/2012
-- Description:	Create stored procedure to get referrerlocations by referrerid
-- Version: 1.0
-- =============================================
-- Author:		Manjit Singh
-- Create date: 03/05/2013
-- Description:	Added condition for IsActive Field
-- Version: 1.1
-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerLocationsByReferrerID] 
	-- Add the parameters for the stored procedure here
	   @ReferrerID int

AS
BEGIN	

SELECT * FROM
	 [referrer].[ReferrerLocations] 
	  Where ReferrerID=@ReferrerID and IsActive=1 ORDER BY Name ASC
END

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerMainLocationByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ftan
-- Create date: 11/14/2012
-- Description:	Get referrer main loaction by passing referrerid
-- =============================================
-- Author:		Manjit Singh
-- Create date: 03/05/2013
-- Description:	Added IsActive Field
-- Version: 1.1
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerMainLocationByReferrerID]
	-- Add the parameters for the stored procedure here
	@ReferrerID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [ReferrerLocationID]
      ,[Name]
      ,[Address]
      ,[City]
      ,[Region]
      ,[PostCode]      
      ,[IsMainOffice]
      ,[ReferrerID]
      ,[IsActive]
    FROM  [referrer].[ReferrerLocations]
	WHERE ReferrerID=@ReferrerID AND IsMainOffice = 1
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectAssignedToUser]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 06-08-2018
-- Description:	Get get referrer project which are not assigned to user
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerProjectAssignedToUser](@referrerID int, @userID int)	
AS
BEGIN	
	SET NOCOUNT ON;
		Select * from referrer.ReferrerProjects rp 
		left join global.UserProject up on up.ReferrerProjectID = rp.ReferrerProjectID
		where ReferrerID = @referrerID and isnull(up.UserID,0) = @userID  
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectByProjectID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 12/03/2012
-- Description:	select referrer projects by project id
-- =============================================
 
CREATE PROCEDURE [referrer].[Get_ReferrerProjectByProjectID] 
	-- Add the parameters for the stored procedure here
	@ProjectID int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	

	SELECT *
	FROM [referrer].[ReferrerProjects] 
	WHERE ReferrerProjectID = @ProjectID
END

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectEmailByTreatmentId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 11/14/2012
-- Description:	Get Referrer by Treatment ID
-- Version: 1.0
-- =============================================
-- Author:		Vishal Sen
-- Create date: 11/21/2012
-- Description:	Modify Name [GetReferrerProjectEmailByTreatmentId] to [Get_ReferrerProjectEmailByTreatmentId] 
-- Version: 1.0
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerProjectEmailByTreatmentId] 
	-- Add the parameters for the stored procedure here
	@teamtmentId int
AS
BEGIN
	SELECT * from referrer.ReferrerProjectTreatmentEmails where ReferrerProjectTreatmentID=@teamtmentId
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectNotAssignedToUser]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		TGosain
-- Create date: 06-08-2018
-- Description:	Get get referrer project which are not assigned to user
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerProjectNotAssignedToUser](@referrerID int, @userID int)	
AS
BEGIN	
	SET NOCOUNT ON;
		Select * from referrer.ReferrerProjects rp 
		where ReferrerID = @referrerID and rp.ReferrerProjectID not in(select ReferrerProjectID from global.UserProject where isnull(UserID,0) = @userID )
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectsByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  ftan  
-- Create date: 11/16/2012  
-- Description: select referrer projects by referrer id  
-- =============================================  
CREATE PROCEDURE [referrer].[Get_ReferrerProjectsByReferrerID]  
 -- Add the parameters for the stored procedure here  
 @ReferrerID int  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
 SELECT *
 FROM [referrer].[ReferrerProjects]   
 WHERE ([ReferrerID] = @ReferrerID) 
END  

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectsLikeProjectName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Vishal Sen>
-- Create date: <11-09-2012>
-- Description:	<This Procedure Used Search ReferrerProject Like by  ProjectName Task NO: 130>
-- Version	:	1.0	
-- =============================================


-- Author:		<Vishal Sen>
-- Create date: <11-12-2012>
-- Description:	<update referrer project autocomplete to search by project name and referrerid>
-- Version	:	1.1	
-- =============================================



CREATE PROCEDURE [referrer].[Get_ReferrerProjectsLikeProjectName]  

/*Here @ReferrerProjectname  ,@ReferrerID Add ParameterHere For AutoComplete */
 @ProjectName NVARCHAR(100)
 ,@ReferrerID int
AS 
    BEGIN

SELECT * FROM [referrer].[ReferrerProjects] WHERE ([ProjectName] LIKE (@ProjectName + '%') and ReferrerID = @ReferrerID)

 END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 11/10/2012
-- Description:	Get Referrer ProjectTreatment Assessments by ReferrerProjectTreatmentID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID] 
	-- Add the parameters for the stored procedure here
		@ReferrerProjectTreatmentID int
AS
BEGIN	

SELECT [ReferrerProjectTreatmentAssessmentID]
      ,[AssessmentServiceID]
      ,[AssessmentTypeID]
      ,[ReferrerProjectTreatmentID]
  FROM [referrer].[ReferrerProjectTreatmentAssessments]
 WHERE [ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID
	  
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================    
-- Latest Version 1.1    
    
    
-- Author:  Satya    
-- Create date: 11/10/2012    
-- Description: GET ReferrerProjectTreatmentAuthorisation by ReferrerProjectTreatmentID    
-- Version: 1.0    
    
-- Author:  Anuj Batra    
-- Create date: 12/06/2012    
-- Description: Update the StoredProcedure.    
-- Version: 1.1    
-- =============================================    
    
CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID]     
 -- Add the parameters for the stored procedure here    
  @ReferrerProjectTreatmentID int    
AS    
BEGIN     
    
SELECT [ReferrerProjectTreatmentAuthorisationID]    
      ,[TreatmentCategoryID]    
      ,[DelegatedAuthorisationTypeID]    
      ,[Amount]    
      ,[ReferrerProjectTreatmentID]
      ,[Enabled]
      ,[Quantity]
  FROM [referrer].[ReferrerProjectTreatmentAuthorisations]    
 WHERE [ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID    
       
END 

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Satya
-- Create date: 12/03/2012
-- Description:	Get ReferrerProjectTreatment By ReferrerProjectTreatmentID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentByReferrerProjectTreatmentID] 
	-- Add the parameters for the stored procedure here
		@ReferrerProjectTreatmentID int
AS
BEGIN	

	 SELECT [ReferrerProjectTreatmentID]
      ,[ReferrerProjectID]
      ,[referrer].[ReferrerProjectTreatments].[TreatmentCategoryID]
      ,[AccountReceivableChasingPoint]
      ,[AccountReceivableCollection]
      ,[Enabled]
      ,[TreatmentCategoryName]
  FROM [referrer].[ReferrerProjectTreatments]
  INNER JOIN [lookup].[TreatmentCategories] ON [referrer].[ReferrerProjectTreatments].TreatmentCategoryID = [lookup].TreatmentCategories.TreatmentCategoryID

 WHERE [ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID

	  
END




GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentByTreatmentId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Rohit Kumar
-- Create date: 27-01-2015
-- Description:	 Get Referrer Project Treatment By TreatmentId
-- Version: 1.0
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentByTreatmentId] 
	-- Add the parameters for the stored procedure here
	@ReferrerProjectTreatmentID int
AS
BEGIN
	SELECT     *
	FROM         referrer.ReferrerProjectTreatments WHERE     (ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID)
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/06/2012
-- Description:	Add [Get_ReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID]
-- Version: 1.0
--

-- =============================================
 
CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID] --9982
	-- Add the parameters for the stored procedure here
(	

@ReferrerProjectTreatmentID int
)
      
AS
BEGIN	

declare @DocumentSetupTypeID as int =0
 set @DocumentSetupTypeID = (SELECT     top 1 DocumentSetupTypeID FROM         referrer.ReferrerProjectTreatmentDocumentSetup where ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID)

if(@DocumentSetupTypeID=1)
	begin
		select setup.*,lookup.AssessmentServices.AssessmentServiceName,lookup.DocumentSetupTypes.DocumentSetupTypeName 
		, null as UploadedFileName
		from referrer.ReferrerProjectTreatmentDocumentSetup as setup 
		
		inner join lookup.AssessmentServices on lookup.AssessmentServices.AssessmentServiceID=setup.AssessmentServiceID
		inner join  lookup.DocumentSetupTypes on lookup.DocumentSetupTypes.DocumentSetupTypeID=setup.DocumentSetupTypeID
		 where  ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID 
	end
else
	begin


			Select * from(

			Select ROW_NUMBER()  OVER  (partition by setup.AssessmentServiceID order by setup.AssessmentServiceID) AS Row,  setup.*,lookup.AssessmentServices.AssessmentServiceName,
			lookup.DocumentSetupTypes.DocumentSetupTypeName   ,referrer.ReferrerDocuments.UploadPath as UploadedFileName
			From referrer.ReferrerProjectTreatmentDocumentSetup as setup 
			inner join lookup.AssessmentServices on lookup.AssessmentServices.AssessmentServiceID=setup.AssessmentServiceID
			inner join  lookup.DocumentSetupTypes on lookup.DocumentSetupTypes.DocumentSetupTypeID=setup.DocumentSetupTypeID 
			inner join  referrer.ReferrerDocuments on referrer.ReferrerDocuments.ReferrerProjectTreatmentID=setup.ReferrerProjectTreatmentID 
			 where  setup.ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID ) a
			 where Row=AssessmentServiceID

	end

--select setup.*,lookup.AssessmentServices.AssessmentServiceName,lookup.DocumentSetupTypes.DocumentSetupTypeName from referrer.ReferrerProjectTreatmentDocumentSetup as setup 
--inner join lookup.AssessmentServices on lookup.AssessmentServices.AssessmentServiceID=setup.AssessmentServiceID
--inner join  lookup.DocumentSetupTypes on lookup.DocumentSetupTypes.DocumentSetupTypeID=setup.DocumentSetupTypeID
-- where  ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID 
 
 
 --8361

	  
	 
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================  
-- Latest Version : 1.0
-- Author:  Pardeep Kumar
-- Create date: 07/26/2013
-- Description: Get ReferrerProjectTreatmentEmailsTypeName By ReferrerProjectTreatmentID  
-- Version: 1.0  
-- =============================================  

CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID]
(
@ReferrerProjectTreatmentID int
)
as

SELECT     referrer.ReferrerProjectTreatmentEmails.*,  
                      lookup.EmailTypes.EmailTypeName,lookup.EmailTypes.UserTypeID
FROM         referrer.ReferrerProjectTreatmentEmails INNER JOIN
                      lookup.EmailTypes ON referrer.ReferrerProjectTreatmentEmails.EmailTypeID = lookup.EmailTypes.EmailTypeID
WHERE     (referrer.ReferrerProjectTreatmentEmails.ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID)

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Satya 
-- Create date: 11-22-2012
-- Description:	Select stored proc for Get_ReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID
-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID]
	-- Add the parameters for the stored procedure here

			@ReferrerProjectTreatmentID INT
AS
BEGIN

SELECT [ReferrerProjectTreatmentInvoiceID]
      ,[InvoicePrice]
      ,[ManagementPrice]
      ,[ManagementFeeEnabled]
      ,[InvoiceMethodID]
      ,[ReferrerProjectTreatmentID]
  FROM [referrer].[ReferrerProjectTreatmentInvoice]
 WHERE [ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID
 
END



GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentNamesByReferrerProjectID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentNamesByReferrerProjectID]
	@ReferrerProjectID int
AS
	select ReferrerProjectTreatmentID,TreatmentCategoryName from [referrer].[ReferrerProjectTreatments] rp inner join			lookup.TreatmentCategories tc
	on rp.TreatmentCategoryID = tc.TreatmentCategoryID
	where ReferrerProjectID = @ReferrerProjectID


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vishal 
-- Create date: 11-14-2012
-- Description:	Create A Sp For [Get_ReferrerProjectTreatmentPricingByReferrerID]
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID]
	-- Add the parameters for the stored procedure here
	@ReferrerProjectTreatmentID int
AS
BEGIN
select * From 
[referrer].[ReferrerProjectTreatmentPricing] 
where ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID

END



GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================   
-- Author:          Vishal   
-- Create date:  15-10-2013   
-- Description:     retrieve all pricing by treatmentcategory with 
--referrer pricing data by passing ReferrerProjectTreatmentID and PricingTypeID    
-- =============================================   
CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID]   
     @ReferrerProjectTreatmentID INT,   
     @PricingTypeID INT   
AS   
BEGIN   
   
    SELECT     *
FROM         referrer.ReferrerProjectTreatmentPricing
   
 WHERE
      PricingTypeID = @PricingTypeID AND   
       [ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID   
END   

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ============================================= 
-- Author:          Satya 
-- Create date:		07-12-2013 
-- Description:     retrieve all pricing by treatmentcategory with referrer pricing data by passing ReferrerProjectTreatmentID and treatmentcategoryid  
-- ============================================= 
CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID] 
     @ReferrerProjectTreatmentID INT, 
     @TreatmentCategoryID INT 
AS 
BEGIN 
     -- SET NOCOUNT ON added to prevent extra result sets from 
     -- interfering with SELECT statements. 
     SET NOCOUNT ON; 
 
     SELECT p.Price, p.PricingID, p.ReferrerProjectTreatmentID, t.TreatmentCategoryID, t.TreatmentCategoryName, t.PricingTypeName, t.PricingTypeID FROM ( 
      SELECT [referrer].[ReferrerProjectTreatmentPricing].Price 
      ,[referrer].[ReferrerProjectTreatmentPricing].PricingID 
      ,[referrer].[ReferrerProjectTreatmentPricing].PricingTypeID 
      ,[referrer].[ReferrerProjectTreatmentPricing].ReferrerProjectTreatmentID 
      ,[referrer].[ReferrerProjectTreatments].TreatmentCategoryID 
        FROM [referrer].[ReferrerProjectTreatmentPricing]--, lookup.PricingTypes.* 
      INNER JOIN referrer.ReferrerProjectTreatments ON referrer.ReferrerProjectTreatmentPricing.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatments.ReferrerProjectTreatmentID 
      WHERE referrer.ReferrerProjectTreatmentPricing.[ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID) p 
      RIGHT JOIN [lookup].[TreatmentCategoriesPricingTypes] t ON p.TreatmentCategoryID = t.TreatmentCategoryID 
      AND p.PricingTypeID = t.PricingTypeID 
      WHERE t.TreatmentCategoryID = @TreatmentCategoryID 
END 


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentsByReferrerProjectID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Satya
-- Create date: 12/03/2012
-- Description:	Get Referrer ProjectTreatments By ReferrerProjectID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentsByReferrerProjectID] 
	-- Add the parameters for the stored procedure here
		@ReferrerProjectID int
AS
BEGIN	

	 SELECT [ReferrerProjectTreatmentID]
      ,[ReferrerProjectID]
      ,[referrer].[ReferrerProjectTreatments].[TreatmentCategoryID]
      ,[AccountReceivableChasingPoint]
      ,[AccountReceivableCollection]
      ,[Enabled]
      ,[TreatmentCategoryName]
  FROM [referrer].[ReferrerProjectTreatments]
  INNER JOIN [lookup].[TreatmentCategories] ON [referrer].[ReferrerProjectTreatments].TreatmentCategoryID = [lookup].TreatmentCategories.TreatmentCategoryID

 WHERE [ReferrerProjectID] = @ReferrerProjectID

	  
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [referrer].[Get_ReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID] 
	@ReferrerProjectTreatmentID int
AS
BEGIN
	SET NOCOUNT ON;

    select TreatmentTypeID,TreatmentTypeName,ReferrerProjectTreatmentID from referrer.ReferrerProjectTreatmentTreatmentType where  ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID
END


GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrersGroupsByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh
-- Create date: 22-11-2019
-- Description:Get referrer groups By ReferrerID 566
-- ===================================================
-- [referrer].[Get_ReferrersGroupsByReferrerID] 566
CREATE PROCEDURE [referrer].[Get_ReferrersGroupsByReferrerID] 
	@ReferrerID int
AS
BEGIN
	Select  Distinct GroupName ,referrerid from [referrer].[ReferrerGroups]  where ReferrerID = @ReferrerID
END

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrersLikeReferrerName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Vishal Sen>
-- Create date: <11-08-2012>
-- Description:	<This Procedure Used For Autocomplete Referrername Task NO: 125>
-- Version	:	1.0	
-- =============================================


CREATE PROCEDURE  [referrer].[Get_ReferrersLikeReferrerName]	

/*Here @ReferrerName Add ParameterHere For AutoComplete*/

 @ReferrerName NVARCHAR(100)

AS 
    BEGIN
	SELECT * 
	FROM [referrer].[Referrers]
	WHERE [ReferrerName] LIKE (@ReferrerName + '%')

 END



GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrersRecentlyAdded]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Vishal  
-- Create date: 07/09/2013  
-- Description:  Get_ReferrersRecentlyAdded 
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [referrer].[Get_ReferrersRecentlyAdded]  
 -- Add the parameters for the stored procedure here  
AS  
BEGIN   
   
    Select TOP 10 * From referrer.Referrers
    ORDER BY referrer.Referrers.DateAdded DESC  
     
    END  
   

GO
/****** Object:  StoredProcedure [referrer].[Get_ReferrerUploadedDocumentByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		jasingh	
-- Create date: 25-05-2018
-- Description:	Used For Getting Uplaoded Document BY ReferrerID
-- [referrer].[Get_ReferrerUploadedDocumentByReferrerID] 566
-- =============================================
CREATE PROCEDURE [referrer].[Get_ReferrerUploadedDocumentByReferrerID] 
	 @ReferrerID int 
AS
BEGIN
	Select ReferrerDocumentID,UploadPath,UploadDate from [referrer].[ReferrerDocuments] where ReferrerID = @ReferrerID
END


GO
/****** Object:  StoredProcedure [referrer].[Update_ProjectTreatmentSLAsByProjectTreatmentSLAID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vishal 
-- Create date: 11-14-2012
-- Description:	Create A Sp For [Update_ProjectTreatmentSLAsByProjectTreatmentSLAID]
-- =============================================

CREATE PROCEDURE [referrer].[Update_ProjectTreatmentSLAsByProjectTreatmentSLAID]
	-- Add the parameters for the stored procedure here
	@ProjectTreatmentSLAID int,
	@ReferrerProjectTreatmentID int,
	@ServiceLevelAgreementID int,
	@NumberOfDays int,
	@Enabled bit
AS
BEGIN
update
referrer.ProjectTreatmentSLAs
set

	ReferrerProjectTreatmentID =@ReferrerProjectTreatmentID,
	ServiceLevelAgreementID=@ServiceLevelAgreementID,
	NumberOfDays=@NumberOfDays,
	[Enabled]=@Enabled
where 
ProjectTreatmentSLAID=@ProjectTreatmentSLAID

END

GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerDocument]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		GJain
-- Create date: 12/15/2014
-- Description:	Update ReferrerDocument
-- Version: 1.0

-- =============================================

CREATE PROCEDURE [referrer].[Update_ReferrerDocument] 
	-- Add the parameters for the stored procedure here
		   (@ReferrerID INT
           ,@DocumentTypeID INT
           ,@UploadDate DATETIME
           ,@UserID INT
           ,@UploadPath VARCHAR(200)
           ,@ReferrerProjectTreatmentID int=null)
AS
BEGIN	
Update [referrer].[ReferrerDocuments]
set
           [ReferrerID]=@ReferrerID
           ,[DocumentTypeID]=@DocumentTypeID
           ,[UploadDate]=@UploadDate
           ,[UserID]=@UserID
           ,[UploadPath]=@UploadPath
            ,[ReferrerProjectTreatmentID]=@ReferrerProjectTreatmentID
where [ReferrerID]=@ReferrerID and [DocumentTypeID]=@DocumentTypeID and [ReferrerProjectTreatmentID]=@ReferrerProjectTreatmentID

	
END






GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerGroupNameBynameAndID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Jasingh
-- Create date: 26-11-2019
-- Description:	Update Group Name
-- =============================================
CREATE PROCEDURE [referrer].[Update_ReferrerGroupNameBynameAndID]
	@NewGroupName varchar(50),
	@GroupName Varchar(50),
	@ReferrerID int,
	@UserID varchar(max)
AS
BEGIN

Delete from [referrer].[ReferrerGroups] where GroupName = @GroupName and ReferrerID=@ReferrerID


if @NewGroupName != @GroupName
	begin
		INSERT INTO referrer.ReferrerGroups (GroupName, ReferrerID, UserID )
		SELECT @NewGroupName,@ReferrerID,Item  FROM SplitString (@UserID, ',') 

	End
else
	begin
	 INSERT INTO referrer.ReferrerGroups (GroupName, ReferrerID, UserID )
	 SELECT @GroupName,@ReferrerID,Item  FROM SplitString (@UserID, ',') 

	End 

 SELECT SCOPE_IDENTITY()


END

GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerInfoByReferrerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Vishal,Vijay
-- Create date: 10/27/2012
-- Description:	Update referrer information
-- Version: 1.0
--
-- Author:		ftan
-- Version: 1.1
-- Description:	updated fields
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 02/27/2013
-- Description:	added the [ReferrerMainContactFax]  and [ReferrerMainContactPhone] columns
-- Version: 1.1
-- =============================================
-- Author:		Vishal Sen
-- Create date: 06/13/2013
-- Description:	Remove two parameter from Sp ReferrerCentralEmail,EmailSendingOptionID
-- Version: 1.3
-- =============================================
-- =============================================
-- Author:		Rohit Kumar
-- Create date: 21/09/2018
-- Description:	#3384 - Internal Portal - Referrer Setup - New Section - Referral Setup
-- Version: 1.4
-- =============================================
-- =============================================
-- Author:		Rohit Kumar
-- Create date: 08/04/2019
-- Description:	#3553 - Internal Portal -Referrer Setup - New Sections
-- Version: 1.5
-- =============================================

CREATE PROCEDURE [referrer].[Update_ReferrerInfoByReferrerID] 
	-- Add the parameters for the stored procedure here
	   @ReferrerID int
	  ,@ReferrerName NVARCHAR(100)
      ,@ReferrerContactFirstName NVARCHAR(100)
      ,@ReferrerContactLastName NVARCHAR(100)
      ,@ReferrerMainContactEmail NVARCHAR(100)
      ,@ReferrerMainContactFax NVARCHAR(100)
      ,@ReferrerMainContactPhone NVARCHAR(100)
	  ,@IsPolicyDetail bit
	  ,@IsEmploymentDetail bit
	  ,@IsEmploeeDetail bit
	  ,@IsDrugandAlcoholTest bit
	  ,@IsRepresentation bit
	  ,@IsAdditionalQuestion bit
	  ,@IsJobDemand bit
	  ,@IsPolicyDetailOpenOrDropdowns VARCHAR(10)
	  ,@IsNewPolicyTypes VARCHAR(10)
AS
BEGIN	

	   Update [referrer].[Referrers] SET 
	   [ReferrerName] = @ReferrerName
      ,[ReferrerContactFirstName] = @ReferrerContactFirstName
      ,[ReferrerContactLastName] = @ReferrerContactLastName
	  ,[ReferrerMainContactEmail] = @ReferrerMainContactEmail	  
	  ,[ReferrerMainContactFax] = @ReferrerMainContactFax
	  ,[ReferrerMainContactPhone] = @ReferrerMainContactPhone
	  ,[IsPolicyDetail] = @IsPolicyDetail 
	  ,[IsEmploymentDetail] = @IsEmploymentDetail 
	  ,[IsEmploeeDetail] = @IsEmploeeDetail 
	  ,[IsDrugandAlcoholTest] = @IsDrugandAlcoholTest
	  ,[IsRepresentation] = @IsRepresentation
	  ,[IsAdditionalQuestion] = @IsAdditionalQuestion
	  ,[IsJobDemand] =@IsJobDemand
	  ,[IsPolicyDetailOpenOrDropdowns]=@IsPolicyDetailOpenOrDropdowns
	  ,[IsNewPolicyTypes] = @IsNewPolicyTypes
	  Where ReferrerID=@ReferrerID
END


GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerLocationByReferrerLocationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Anuj Batra
-- Create date: 10/30/2012
-- Description:	Stored procedure to update referrer location by referrerlocationID
-- Version: 1.0
-- =============================================
-- Author:		ftan
-- Create date: 11/7/2012
-- Description:	added more fields
-- Version: 1.1
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 02/27/2013
-- Description:	Delete the Phone and Fax columns
-- Version: 1.2
-- =============================================
-- Author:		Manjit Singh
-- Create date: 03/05/2013
-- Description:	Added IsActive Field
-- Version: 1.3
-- =============================================
CREATE PROCEDURE [referrer].[Update_ReferrerLocationByReferrerLocationID] 
	-- Parameters for the stored procedure --
	   @ReferrerLocationID int
	  ,@LocationName NVARCHAR(100)
      ,@LocationAddress NVARCHAR(200)
      ,@LocationCity NVARCHAR(100)
      ,@LocationRegion NVARCHAR(100)
      ,@LocationPostCode NVARCHAR(12)
      --,@LocationPhone NVARCHAR(100)
      --,@LocationFax NVARCHAR(100)
      ,@IsActive BIT
	 
AS
	BEGIN	

		Update  
		 [referrer].[ReferrerLocations] SET 
		  [Name]=@LocationName, 
		  [Address]=@LocationAddress,
		  [PostCode]=@LocationPostCode,
		  --[Phone]=@LocationPhone,
		  --[Fax]=@LocationFax,
		  [City]=@LocationCity,
		  [Region]=@LocationRegion,
		  [IsActive]=@IsActive
		  Where ReferrerLocationID=@ReferrerLocationID
	END


GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerLocationMainOffice]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Pardeep Kumar 
-- Create date: 11-28-2012
-- Description:	Storeprocedure to update IsMainOffice in table ReferrerLocations by referrerofficelocationid
-- =============================================



CREATE PROCEDURE [referrer].[Update_ReferrerLocationMainOffice]
(
@referrerID int,
@referrerofficelocationid int
)
as
update referrer.ReferrerLocations set IsMainOffice = 0 where ReferrerID = @referrerID

update referrer.ReferrerLocations set IsMainOffice = 1 where ReferrerLocationID = @referrerofficelocationid

GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectByReferrerProjectID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Latest Version : 1.1
--
-- Author:  <Vishal Sen>  
-- Create date: <11-09-2012>  
-- Description: <This Procedure Used Update ReferrerProject Task NO: 130>  
-- Version : 1.0   
-- =============================================  
  
-- Modified By :  Pardeep Kumar   
-- Date        :  06-13-2013
-- Description :  Modified to Edit EmailSendingOptionID and CentralEmail
-- Version     :  1.1

-- =============================================  
  
-- Modified By :  Vishal sen   
-- Date        :  06-24-2013
-- Description :  Modified Add Istriage
-- Version     :  1.2
  
CREATE PROCEDURE [referrer].[Update_ReferrerProjectByReferrerProjectID]   
  -- Add the parameters for the stored procedure here  
       @ReferrerProjectID int  
	  ,@ProjectName NVARCHAR(100)  
      ,@ReferrerID int  
      ,@StatusID int  
      ,@FirstAppointmentOffered bit  
      ,@Enabled bit     
      ,@EmailSendingOptionID int
      ,@CentralEmail NVARCHAR(100) 
      ,@IsTriage bit
	  ,@IsActive bit
AS  
BEGIN   
  
    Update    
  [referrer].[ReferrerProjects] SET   
   
 [ProjectName]=@ProjectName,  
 [ReferrerID]=@ReferrerID,  
 [StatusID]=@StatusID,  
 [FirstAppointmentOffered]=@FirstAppointmentOffered,  
 [Enabled]=@Enabled ,
 [EmailSendingOptionID] = @EmailSendingOptionID ,
 [CentralEmail] =@CentralEmail ,
[IsTriage]=@IsTriage,
[IsActive] = @IsActive
 
   Where [ReferrerProjectID]=@ReferrerProjectID  
END  

GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectStatusByReferrerProjectID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Harpreet Singh  
-- Create date: 24/04/2013  
-- Description: Update referrer project status by referrer project id    
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [referrer].[Update_ReferrerProjectStatusByReferrerProjectID]   
 -- Add the parameters for the stored procedure here  
   
   @ReferrerProjectID INT,
   @StatusID INT  
AS  
BEGIN   
     Update    
  [referrer].[ReferrerProjects]
  SET  
    [StatusID]=@StatusID
   Where ReferrerProjectID=@ReferrerProjectID  
  
END  

GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectTreatment]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Satya  
-- Create date: 11/09/2012  
-- Description: Update referrer project treatments    
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [referrer].[Update_ReferrerProjectTreatment]   
 -- Add the parameters for the stored procedure here  
    @ReferrerProjectTreatmentID INT  
   ,@ReferrerProjectID INT  
      ,@TreatmentCategoryID INT  
      ,@AccountReceivableChasingPoint INT  
      ,@AccountReceivableCollection INT  
      ,@Enabled BIT  
AS  
BEGIN   
     Update    
  [referrer].[ReferrerProjectTreatments]   
  SET  
    [ReferrerProjectID]=@ReferrerProjectID  
      ,[TreatmentCategoryID]=@TreatmentCategoryID  
      ,[AccountReceivableChasingPoint]=@AccountReceivableChasingPoint  
      ,[AccountReceivableCollection]=@AccountReceivableCollection   
   ,[Enabled] = @Enabled  
   Where ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID  
  
END  

GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentAssessmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 11/10/2012
-- Description:	Update Referrer ProjectTreatment Assessments by ReferrerProjectTreatmentAssessmentID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [referrer].[Update_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentAssessmentID] 
	-- Add the parameters for the stored procedure here
	   @ReferrerProjectTreatmentAssessmentID int
	  ,@AssessmentServiceID int
      ,@AssessmentTypeID int
      ,@ReferrerProjectTreatmentID int
      
AS
BEGIN	
	  
	  UPDATE [referrer].[ReferrerProjectTreatmentAssessments]
   SET [AssessmentServiceID] = @AssessmentServiceID 
      ,[AssessmentTypeID] = @AssessmentTypeID 
      ,[ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID 
 WHERE [ReferrerProjectTreatmentAssessmentID] = @ReferrerProjectTreatmentAssessmentID
	  
END


GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentAuthorisationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--sp_helptext [referrer.Update_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentAuthorisationID]
-- =============================================    
-- Latest Version 1.1    
    
-- Author:  Satya    
-- Create date: 11/10/2012    
-- Description: Update ReferrerProject Treatment Authorisation by ReferrerProjectTreatmentAuthorisationID    
-- Version: 1.0    
    
-- Author:  Anuj Batra    
-- Create date: 12/06/2012    
-- Description: Update the StoredProcedure.    
-- Version: 1.1    
-- =============================================    
    
CREATE PROCEDURE [referrer].[Update_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentAuthorisationID]
 -- Add the parameters for the stored procedure here    
     @ReferrerProjectTreatmentAuthorisationID INT    
     ,@TreatmentCategoryID INT    
  ,@DelegatedAuthorisationTypeID INT    
  ,@Amount MONEY    
  ,@ReferrerProjectTreatmentID INT   
  ,@Enabled BIT 
  ,@Quantity INT  
    
AS    
BEGIN     
       
 UPDATE [referrer].[ReferrerProjectTreatmentAuthorisations]    
   SET [TreatmentCategoryID] = @TreatmentCategoryID    
      ,[DelegatedAuthorisationTypeID] = @DelegatedAuthorisationTypeID    
      ,[Amount] = @Amount     
      ,[ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID    
       ,[Enabled] = @Enabled   
        ,[Quantity] = @Quantity   
 WHERE [ReferrerProjectTreatmentAuthorisationID] = @ReferrerProjectTreatmentAuthorisationID    
       
END 

GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectTreatmentDocumentSetup]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/06/2012
-- Description:	Add Update_ReferrerProjectTreatmentDocumentSetup
-- Version: 1.0
--

-- =============================================

CREATE PROCEDURE [referrer].[Update_ReferrerProjectTreatmentDocumentSetup] 
	-- Add the parameters for the stored procedure here
(	
@ReferrerProjectTreatmentDocumentSetupID int,   
@AssessmentServiceID int,
@DocumentSetupTypeID int,
@ReferrerProjectTreatmentID int
)
      
AS
BEGIN	

 update referrer.ReferrerProjectTreatmentDocumentSetup
	set 
	AssessmentServiceID=@AssessmentServiceID,
	DocumentSetupTypeID=@DocumentSetupTypeID,
    ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID
      
 where ReferrerProjectTreatmentDocumentSetupID=@ReferrerProjectTreatmentDocumentSetupID
	  
	 
END


GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectTreatmentEmail]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 11/14/2012
-- Description:	UpdateReferrerProjectTreatmentEmail
-- Version: 1.0
-- =============================================
-- Author:		Vishal
-- Create date: 11/21/2012
-- Description:	Modify Name [Update_ReferrerProjectTreatmentEmail] to [UpdateReferrerProjectTreatmentEmail] 
-- Version: 1.0
-- =============================================
CREATE PROCEDURE [referrer].[Update_ReferrerProjectTreatmentEmail] 
	-- Add the parameters for the stored procedure here
	@ReferrerProjectTreatmentEmailID int,
	@ReferrerProjectTreatmentID int,
	@EmailTypeID int,
	@EmailTypeValueID int
AS
BEGIN
	update referrer.ReferrerProjectTreatmentEmails set 
	@ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID ,
	EmailTypeID=@EmailTypeID ,
	EmailTypeValueID=@EmailTypeValueID  where ReferrerProjectTreatmentEmailID=@ReferrerProjectTreatmentEmailID
	
END


GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentInvoiceID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Satya 
-- Create date: 11-22-2012
-- Description:	Create Update stored proc for Update_ReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentInvoiceID
-- =============================================

CREATE PROCEDURE [referrer].[Update_ReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentInvoiceID]
	-- Add the parameters for the stored procedure here
			(@ReferrerProjectTreatmentInvoiceID INT
			,@InvoicePrice MONEY
			,@ManagementPrice MONEY
			,@ManagementFeeEnabled BIT
			,@InvoiceMethodID INT
			,@ReferrerProjectTreatmentID INT)
AS
BEGIN

UPDATE [referrer].[ReferrerProjectTreatmentInvoice]
   SET [InvoicePrice] = @InvoicePrice
      ,[ManagementPrice] = @ManagementPrice
      ,[ManagementFeeEnabled] = @ManagementFeeEnabled
      ,[InvoiceMethodID] = @InvoiceMethodID
      ,[ReferrerProjectTreatmentID] = @ReferrerProjectTreatmentID
 WHERE [ReferrerProjectTreatmentInvoiceID] = @ReferrerProjectTreatmentInvoiceID
 
END



GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectTreatmentPricingByPricingID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vishal 
-- Create date: 11-14-2012
-- Description:	Create A Sp For [Update_ReferrerProjectTreatmentPricingByPricingID]
-- =============================================
CREATE PROCEDURE [referrer].[Update_ReferrerProjectTreatmentPricingByPricingID]
	-- Add the parameters for the stored procedure here
	@PricingID int,
	@PricingTypeID int,
	@Price money,
	@ReferrerProjectTreatmentID int
AS
BEGIN
update
[referrer].[ReferrerProjectTreatmentPricing] 
set
PricingTypeID=@PricingTypeID,
Price=@Price,
ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID
where 
PricingID=@PricingID

END



GO
/****** Object:  StoredProcedure [referrer].[Update_ReferrerProjectTreatments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author:  Harpreet Singh  
-- Create date: 26/03/2013  
-- Description: Update referrer project treatments    
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [referrer].[Update_ReferrerProjectTreatments]   
 -- Add the parameters for the stored procedure here  
    @ReferrerProjectTreatmentID INT  
   ,@ReferrerProjectID INT  
      ,@TreatmentCategoryID INT  
     
      ,@Enabled BIT  
AS  
BEGIN   
     Update    
  [referrer].[ReferrerProjectTreatments]   
  SET  
    [ReferrerProjectID]=@ReferrerProjectID  
   ,[TreatmentCategoryID]=@TreatmentCategoryID  
   ,[Enabled] = @Enabled  
   Where ReferrerProjectTreatmentID=@ReferrerProjectTreatmentID  
  
END  

GO
/****** Object:  StoredProcedure [supplier].[Add_Supplier]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 11/17/2012
-- Description:	Add Supplier information
-- Version: 1.0
-- =============================================
-- =============================================
-- Author:		Harpreet Singh
-- Create date: 29/12/2012
-- Description:	Add New Field Status
-- Version: 1.1
-- =============================================
-- =============================================
-- Author:		Vikas Mahant
-- Create date: 06/18/2013
-- Description:	Add New Field IsTriage
-- Version: 1.2
-- =============================================

CREATE PROCEDURE [supplier].[Add_Supplier] 
	-- Add the parameters for the stored procedure here
	 	
	@SupplierName NVARCHAR(100),
	@Address NVARCHAR(200),
	@City NVARCHAR(100),
	@Region NVARCHAR(100),
	@PostCode NVARCHAR(12),
	@Phone NVARCHAR(16),
	@Fax NVARCHAR(16),
	@Website NVARCHAR(50),
	@Ranking int,
	@Notes NVARCHAR(MAX),
	@IsWheelChairAccessibility bit ,
	@IsWeekends bit,
	@IsEvenings bit ,
	@IsParking bit,
	@IsHomeVisit bit,
	@Email varchar(50),
	@IsTriage bit
	--@Status varchar(10)
AS
BEGIN	
    INSERT 
	INTO supplier.Suppliers
	( 	 	
	SupplierName,
	[Address],
	City,
	Region,
	PostCode,
	Phone,
	Fax,
	Website,
	Ranking,
	Notes,
	IsWheelChairAccessibility,
	IsWeekends,
	IsEvenings,
	IsParking,
	IsHomeVisit,
	Email,
	IsTriage
	--Status
      )
	  VALUES
	  (
	 	 	
	@SupplierName,
	@Address,
	@City,
	@Region,
	@PostCode,
	@Phone,
	@Fax,
	@Website,
	@Ranking,
	@Notes,
	@IsWheelChairAccessibility,
	@IsWeekends,
	@IsEvenings,
	@IsParking,
	@IsHomeVisit,
	@Email,
	@IsTriage
	--,@Status
	  )
	  
	  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierClinicalAudit]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


    
    
-- =============================================    
-- Latest Version : 1.2 
-- Author:  Vishal    
-- Create date: 12/29/2012    
-- Description: Add SupplierClinicalAudit information    
-- Version: 1.0    
  
-- Modified by:  Pardeep Kumar    
-- Date       : 12/29/2012    
-- Description: Updated the data type of SupplierClinicalAuditStatus from varchar to Boolean  
-- Version    : 1.1    
  
-- Modified by:  Pardeep Kumar    
-- Date       : 02/11/2013    
-- Description: Updated the Procedure as ReferrerID is removed from the table SupplierClinicalAudit
-- Version    : 1.2    
-- =============================================    
    
CREATE PROCEDURE [supplier].[Add_SupplierClinicalAudit]    
 -- Add the parameters for the stored procedure here      
     
 @SupplierID INT,       
 @AuditPass bit,    
 @UserID INT,    
 @AuditDate DATETIME,    
 @CaseID INT,    
 @SupplierDocumentID INT    
    
AS    
BEGIN     
     
 INSERT INTO [supplier].[SupplierClinicalAudit]    
    (    
         
 [SupplierID],       
 [AuditPass],    
 [UserID],    
 [AuditDate],    
 [CaseID],    
 [SupplierDocumentID]    
     
 )    
 VALUES    
 (    
 @SupplierID,       
 @AuditPass,    
 @UserID,    
 @AuditDate,    
 @CaseID,    
 @SupplierDocumentID    
 )    
  END    
    SELECT SCOPE_IDENTITY()

GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierComplaint]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Harpreet Singh>
-- Create date: <12-15-2012>
-- Description:	<Create the procedure to add the supplier complaint,>
-- =============================================
CREATE PROCEDURE [supplier].[Add_SupplierComplaint]


@ComplaintTypeID int,
@ComplaintStatusID int,
@ComplaintDescription varchar(MAX),
@ComplaintDate datetime,
@SupplierID int
AS

INSERT INTO  [supplier].[SupplierComplaints]
           ([ComplaintTypeID]
           ,[ComplaintStatusID]
           ,[ComplaintDescription]
           ,[ComplaintDate]
           ,[SupplierID])
   
 VALUES
     (      
            @ComplaintTypeID,
            @ComplaintStatusID ,
            @ComplaintDescription ,
            @ComplaintDate,
            @SupplierID )
   select SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierDocumentCustom]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Rohit Kumar
-- Create date: 12/16/2014
-- Description:	to Add Supplier Document Custom
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Add_SupplierDocumentCustom] --14,617,429,'1/1/12','InitialAssessmentFinalCustom.doc','InitialAssessmentFinalCustom.doc',9982,725
	-- Add the parameters for the stored procedure here
	 	  (@DocumentTypeID int,
           @SupplierID int,
           @UserID int,
           @UploadDate datetime,
           @DocumentName varchar(100),
           @UploadPath varchar(150),
           @ReferrerProjectTreatmentID int,
           @CaseId int  
           )
AS
BEGIN	

	
	--if exists(SELECT    *  FROM         supplier.SupplierDocuments where DocumentTypeID=@DocumentTypeID and  SupplierID=@SupplierID and  CaseId= @CaseId)
	--begin
	--	UPDATE		Supplier.SupplierDocuments
	--	SET         UploadDate = @UploadDate, DocumentName = @DocumentName, 
 --                   UploadPath = @UploadPath
	--	where		CaseId = @CaseId and DocumentTypeID = @DocumentTypeID and ReferrerProjectTreatmentID = @ReferrerProjectTreatmentID
	--	 -- means update successfully.
	--end
	--else
	--begin
	

	INSERT INTO [supplier].[SupplierDocuments]
			   ([DocumentTypeID]
			   ,[SupplierID]
			   ,[UserID]
			   ,[UploadDate]
			   ,[DocumentName]
			   ,[UploadPath]
			   ,[ReferrerProjectTreatmentID]
			   ,[CaseId])
		 VALUES
			   (@DocumentTypeID,
			   @SupplierID,
			   @UserID,
			   @UploadDate,
			   @DocumentName,
			   @UploadPath,
			   @ReferrerProjectTreatmentID,
			   @CaseId
			   )
		  SELECT SCOPE_IDENTITY()
		  
		  declare @AssessmentServiceID as int 
			IF  CHARINDEX('initial', lower(@DocumentName) ) > 0
				begin
				
				set @AssessmentServiceID = 1
				if not exists (select * from global.CaseAssessments where CaseID = @CaseId )
				begin
					INSERT INTO global.CaseAssessments
										  (CaseID, AssessmentServiceID, HasPatientConsentForm, IncidentAndDiagnosisDescription, NeuralSymptomDescription, PreExistingConditionDescription, 
										  IsPatientUndergoingTreatment, IsPatientTakingMedication, PatientRequiresFurtherInvestigation, FactorsAffectingTreatmentDescription, PatientOccupation, 
										  PatientRoleID, WasPatientWorkingAtTheTimeOfTheAccident, IsPatientSufferingFinancialLoss, AnticipatedDateOfDischarge, HasPatientHomeExerciseProgramme, 
										  HasPatientPastSymptoms, AssessmentAuthorisationID, AuthorisationDetail, IsAccepted, IsPatientDischarge, DeniedMessage, HasYellowFlags, HasRedFlags, UserID)
					VALUES     (@CaseId,@AssessmentServiceID,0,'IncidentAndDiagnosisDescriptionCustom',NULL,NULL,0,0,0,NULL,'PatientOccupationCustom',1,0,0,getdate(),0,0,1,NULL,0,0,NULL,0,0,@UserID)
					INSERT INTO global.CaseAssessmentDetail
										  (AssessmentServiceID, CaseID, HasThePatientHadTimeOff, AbsentDetail, AbsentPeriod, AbsentPeriodDurationID, 
										  HasThePatientReturnedToWork, PatientImpactOnWorkID, PatientWorkstatusID, PatientRecommendedTreatmentSessions, 
										  PatientRecommendedTreatmentSessionsDetail, PatientTreatmentPeriod, PatientTreatmentPeriodDetail, PatientTreatmentPeriodDurationID, 
										  IsFurtherTreatmentRecommended, PatientLevelOfRecoveryID, SessionsPatientAttended, DatesOfSessionAttended, SessionsPatientFailedToAttend, 
										  FollowingTreatmentPatientLevelOfRecoveryID, AdditionalInformation, HasCompliedHomeExerciseProgramme, AssessmentDate, PractitionerID)
					VALUES     (@AssessmentServiceID,@CaseId,NULL,NULL,1,1,
								  1,1,1,0,
								  0,1,NULL,2,
								  0,1,0,0,0,
								  1,NULL,NULL,getdate(),NULL)
					  end            
					if not exists(SELECT    *  FROM    global.CaseAssessmentRatings where   CaseId= @CaseId and  AssessmentServiceID = @AssessmentServiceID )	              
				begin
				
					INSERT INTO global.CaseAssessmentRatings
								  (CaseID, AssessmentServiceID, Rating, RatingDate)
					VALUES     (@CaseId,@AssessmentServiceID,0,getdate())
				
				
					INSERT INTO global.CaseAssessmentCustoms
								  (CaseID, [Message], IsFurtherTreatment, isAccepted, AssessmentAuthorisationID, ReviewAssessmentMessage, FinalAssessmentMessage)
					VALUES     (@CaseId,NULL,1,0,NULL,NULL,NULL)
				end  
				  
				end
			ELSE IF  CHARINDEX('review', lower(@DocumentName)) > 0
				begin
					set @AssessmentServiceID = 2
					 UPDATE    global.CaseAssessments SET              AssessmentServiceID = @AssessmentServiceID WHERE     (CaseID = @CaseId)
					 INSERT INTO global.CaseAssessmentDetail
										  (AssessmentServiceID, CaseID, HasThePatientHadTimeOff, AbsentDetail, AbsentPeriod, AbsentPeriodDurationID, 
										  HasThePatientReturnedToWork, PatientImpactOnWorkID, PatientWorkstatusID, PatientRecommendedTreatmentSessions, 
										  PatientRecommendedTreatmentSessionsDetail, PatientTreatmentPeriod, PatientTreatmentPeriodDetail, PatientTreatmentPeriodDurationID, 
										  IsFurtherTreatmentRecommended, PatientLevelOfRecoveryID, SessionsPatientAttended, DatesOfSessionAttended, SessionsPatientFailedToAttend, 
										  FollowingTreatmentPatientLevelOfRecoveryID, AdditionalInformation, HasCompliedHomeExerciseProgramme, AssessmentDate, PractitionerID)
					VALUES     (@AssessmentServiceID,@CaseId,NULL,NULL,1,1,
								  1,1,1,0,
								  0,1,NULL,2,
								  0,1,0,0,0,
								  1,NULL,NULL,getdate(),NULL)
					 
				end
			ELSE IF  CHARINDEX('final', lower(@DocumentName)) > 0
				begin
				set @AssessmentServiceID = 3
				UPDATE    global.CaseAssessments SET              AssessmentServiceID = @AssessmentServiceID WHERE     (CaseID = @CaseId)
				 INSERT INTO global.CaseAssessmentDetail
										  (AssessmentServiceID, CaseID, HasThePatientHadTimeOff, AbsentDetail, AbsentPeriod, AbsentPeriodDurationID, 
										  HasThePatientReturnedToWork, PatientImpactOnWorkID, PatientWorkstatusID, PatientRecommendedTreatmentSessions, 
										  PatientRecommendedTreatmentSessionsDetail, PatientTreatmentPeriod, PatientTreatmentPeriodDetail, PatientTreatmentPeriodDurationID, 
										  IsFurtherTreatmentRecommended, PatientLevelOfRecoveryID, SessionsPatientAttended, DatesOfSessionAttended, SessionsPatientFailedToAttend, 
										  FollowingTreatmentPatientLevelOfRecoveryID, AdditionalInformation, HasCompliedHomeExerciseProgramme, AssessmentDate, PractitionerID)
					VALUES     (@AssessmentServiceID,@CaseId,NULL,NULL,1,1,
								  1,1,1,0,
								  0,1,NULL,2,
								  0,1,0,0,0,
								  1,NULL,NULL,getdate(),NULL)
				end
		  
	  --end
 
end	
 



GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierDocuments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Manjit Singh
-- Create date: 12/15/2012
-- Description:	to Add Supplier Documents
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Add_SupplierDocuments]
	-- Add the parameters for the stored procedure here
	 	  (@DocumentTypeID int,
           @SupplierID int,
           @UserID int,
           @UploadDate datetime,
           @DocumentName varchar(100),
           @UploadPath varchar(150)
           )
AS
BEGIN	
INSERT INTO [supplier].[SupplierDocuments]
           ([DocumentTypeID]
           ,[SupplierID]
           ,[UserID]
           ,[UploadDate]
           ,[DocumentName]
           ,[UploadPath])
     VALUES
           (@DocumentTypeID,
           @SupplierID,
           @UserID,
           @UploadDate,
           @DocumentName,
           @UploadPath
           )
	  SELECT SCOPE_IDENTITY()
END




GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierInsurance]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


/*

Latest Version : 1.0

Author  : Pardeep Kumar
Date    : 24-Dec-2012
Version : 1.0
Purpose : Created proc to insert new record in table [supplier].[SupplierInsurance]

*/



CREATE PROCEDURE [supplier].[Add_SupplierInsurance]
(
@LevelOfCover VARCHAR(150),
@RenewalDate DATETIME,
@SupplierDocumentID INT,
@SupplierID INT
)
as
INSERT INTO [supplier].[SupplierInsurance]
           (LevelOfCover
           ,RenewalDate
           ,SupplierDocumentID
           ,SupplierID)
VALUES(@LevelOfCover,@RenewalDate,@SupplierDocumentID,@SupplierID)

SELECT SCOPE_IDENTITY() 

GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierPractitionerRegistration]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierPractitioner]    Script Date: 03/15/2013 14:54:36 ******/
  
-- ============================================= 
-- Latest Version: 1.0
-- Author:  Satya 
-- Create date: 15/03/2013  
-- Description: SP to Add the upplierPractitionerRegistration   
-- Version: 1.0  
-- =============================================  

CREATE PROCEDURE [supplier].[Add_SupplierPractitionerRegistration]  
 -- Add the parameters for the stored procedure here  
 @SupplierID int, 
 @PractitionerRegistrationID int  
   
AS  
BEGIN   
    INSERT   
 INTO [supplier].[SupplierPractitioners]  
 (      
 SupplierID , 
 PractitionerRegistrationID  
    )  
 VALUES  
 (       
 @SupplierID , 
 @PractitionerRegistrationID  
 )  
     
   SELECT SCOPE_IDENTITY()  
END  

GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierSiteAudit]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/24/2012
-- Description:	Add SupplierSiteAudit information
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Add_SupplierSiteAudit]
	-- Add the parameters for the stored procedure here	
	
	@AuditNotes VARCHAR(max),
	@AuditDate DATETIME,
	@AuditPass BIT,
	@UserID INT,
	@SupplierDocumentID INT,
	@SupplierID INT 

AS
BEGIN	
	
 INSERT INTO supplier.SupplierSiteAudit
    (	
		AuditNotes,
		AuditDate,
		AuditPass,
		UserID,
		SupplierDocumentID,
		SupplierID)
	VALUES
	(
		@AuditNotes ,
		@AuditDate,
		@AuditPass,
		@UserID,
		@SupplierDocumentID,
		@SupplierID
	)
	 END
    SELECT SCOPE_IDENTITY()

GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierTreatment]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Satya
-- Create date: 11/18/2012
-- Description:	Add SupplierTreatment information
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Add_SupplierTreatment] 
	-- Add the parameters for the stored procedure here
	 	
	@TreatmentCategoryID INT,
	@SupplierID INT,
	@Enabled BIT
AS
BEGIN	
    INSERT 
	INTO [supplier].[SupplierTreatments]
	( 	 	
		[TreatmentCategoryID],
		[SupplierID],
		[Enabled]
      )
	  VALUES
	  (	
		@TreatmentCategoryID,
		@SupplierID,
		@Enabled 
	  )
	  
	  SELECT SCOPE_IDENTITY()
END


GO
/****** Object:  StoredProcedure [supplier].[Add_SupplierTreatmentPricing]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Satya>
-- Create date: <12-21-2012>
-- Description:	<Create the procedure to add the Supplier Treatment Pricing>
-- =============================================
CREATE PROCEDURE [supplier].[Add_SupplierTreatmentPricing]

	@PricingTypeID INT
   ,@Price MONEY
   ,@SupplierTreatmentID INT
AS

INSERT INTO [supplier].[SupplierTreatmentPricing]
           ([PricingTypeID]
           ,[Price]
           ,[SupplierTreatmentID])
     VALUES
     (      
			@PricingTypeID 
		   ,@Price 
		   ,@SupplierTreatmentID 
    )
   
   select SCOPE_IDENTITY()


GO
/****** Object:  StoredProcedure [supplier].[Delete_SupplierClinicalAuditBySupplierClinicalAuditID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vishal
-- Create date: 12/31/2012
-- Description:	Stored procedure to Delete Supplier Clinical Audit by SupplierClinicalAuditID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Delete_SupplierClinicalAuditBySupplierClinicalAuditID] 
	 @SupplierClinicalAuditID INT
AS
	DELETE FROM supplier.SupplierClinicalAudit WHERE SupplierClinicalAuditID=@SupplierClinicalAuditID

GO
/****** Object:  StoredProcedure [supplier].[Delete_SupplierComplaintBySupplierComplaintID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 -- =============================================
-- Author:		Vishal
-- Create date: 12/21/2012
-- Description:	Stored procedure to delete SupplierComplaint by SupplierComplaintID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Delete_SupplierComplaintBySupplierComplaintID] 

	 @SupplierComplaintID INT
AS
	DELETE FROM  supplier.SupplierComplaints
	WHERE  SupplierComplaintID = @SupplierComplaintID

GO
/****** Object:  StoredProcedure [supplier].[Delete_SupplierDocumentBySupplierDocumentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Anuj Batra
-- Create date: 12/31/2012
-- Description:	Stored procedure to Delete SupplierDocuments by SupplierDocumentID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Delete_SupplierDocumentBySupplierDocumentID] 
	 @SupplierDocumentID INT
AS
	Delete from  supplier.SupplierDocuments where SupplierDocumentID=@SupplierDocumentID

GO
/****** Object:  StoredProcedure [supplier].[Delete_SupplierInsuranceBySupplierInsuredID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vishal
-- Create date: 12/31/2012
-- Description:	Stored procedure to Delete Supplier Insurance by SupplierInsuredID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Delete_SupplierInsuranceBySupplierInsuredID] 
	 @SupplierInsuredID INT
AS
	DELETE FROM  supplier.SupplierInsurance WHERE SupplierInsuredID=@SupplierInsuredID

GO
/****** Object:  StoredProcedure [supplier].[Delete_SupplierPractitionerByPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vijay Kumar
-- Create date: 01/02/2013
-- Description:	Stored procedure to Delete Supplier Practitioner By PractitionerID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Delete_SupplierPractitionerByPractitionerID]
	 @PractitionerID INT
AS
	DELETE FROM supplier.Practitioners WHERE PractitionerID=@PractitionerID

GO
/****** Object:  StoredProcedure [supplier].[Delete_SupplierPractitionerBySupplierPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  
-- =============================================  
-- Created  By : <Pardeep Kumar>  
-- Create date : <31-Jan-2013>  
-- Description : Created procedure to Delete Supplier Practitioner By SupplierPractitionerID  
-- Version: 1.0
-- =============================================  
  
CREATE PROCEDURE [supplier].[Delete_SupplierPractitionerBySupplierPractitionerID]  
  @SupplierPractitionerID INT  
AS  
 DELETE FROM supplier.SupplierPractitioners WHERE SupplierPractitionerID=@SupplierPractitionerID

GO
/****** Object:  StoredProcedure [supplier].[Delete_SupplierSiteAuditBySupplierSiteAuditID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/24/2012
-- Description:	Delete SupplierSiteAudit information by SupplierSiteAuditId
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Delete_SupplierSiteAuditBySupplierSiteAuditID] 
	-- Add the parameters for the stored procedure here	
	@SupplierSiteAuditID INT
AS
BEGIN	
	
    DELETE FROM supplier.SupplierSiteAudit
    WHERE SupplierSiteAuditID=@SupplierSiteAuditID
	 END
 

GO
/****** Object:  StoredProcedure [supplier].[Get_AllSuppliers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/* ===========================================================
   <Latest Version : 1.0 >
   <Author>      : Pardeep Kumar
   <Date>        : 27-Sep-2013
   <Description> : Get All Suppliers
   <Version>     : 1.0
   ===========================================================
*/


CREATE PROCEDURE [supplier].[Get_AllSuppliers]
as

select SupplierID,SupplierName from supplier.Suppliers order by SupplierID asc


GO
/****** Object:  StoredProcedure [supplier].[Get_AllSupplierUserBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
   
-- =============================================   
-- Author:  <Rohit Kumar>   
-- Create date: <05-23-2018>   
-- Description: <Create the procedure to add global Case,>   
  
-- =============================================   
-- [supplier].[Get_AllSupplierUserBySupplierID]  617

CREATE PROCEDURE [supplier].[Get_AllSupplierUserBySupplierID]   (@SupplierID int)
AS   
BEGIN 
	SELECT global.Users.* FROM  global.Users where SupplierID = @SupplierID and UserTypeID = 3 and IsLocked = 0
end
   


GO
/****** Object:  StoredProcedure [supplier].[Get_AllSupplierWithinArea]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [supplier].[Get_AllSupplierWithinArea] --0.997424862453462,-0.0365934108553541,1,1
	-- Add the parameters for the stored procedure here
	@RadiansLatitude FLOAT,
	@RadiansLongitude FLOAT,
	@DistanceKM INT,
	@TreatmentCategoryID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  
      s.[SupplierID]
      ,s.SupplierName
      --,(6371 * acos( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) ) ) AS Distance
      ,(6371 * acos( CASE WHEN ABS( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude )) > 1 THEN SIGN( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) )*1 ELSE  cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) END)) AS Distance
  FROM  [lookup].[UKPostCodes] p
  INNER JOIN supplier.Suppliers s ON s.PostCode = p.PostCode
  INNER JOIN supplier.SupplierTreatments st ON s.[SupplierID] = st.SupplierID
  --WHERE (6371 * acos( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) ) ) < @DistanceKM
  WHERE (6371 * acos( CASE WHEN ABS( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude )) > 1 THEN SIGN( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) )*1 ELSE  cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) END)) < @DistanceKM
  AND s.IsTriage = 0 AND st.Enabled = 1 AND st.TreatmentCategoryID = @TreatmentCategoryID AND s.StatusID = 1
  ORDER BY [SupplierName] ASC
END


GO
/****** Object:  StoredProcedure [supplier].[Get_AssessmentRatingTotalCountAndRatingBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ftan
-- Create date: 04/19/2013
-- Description:	Get assessment total and rating for a supplier by passing supplierid 
-- =============================================
CREATE PROCEDURE [supplier].[Get_AssessmentRatingTotalCountAndRatingBySupplierID]
	-- Add the parameters for the stored procedure here
	@SupplierID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT COUNT(r.[CaseAssessmentRatingID]) AS AssessmentTotal, ISNULL(SUM(r.[Rating]), 0) AS RatingTotal
    FROM [global].[CaseAssessmentRatings] r
    INNER JOIN [global].[Cases] c ON c.CaseID = r.CaseID
    WHERE SupplierID = @SupplierID
END


GO
/****** Object:  StoredProcedure [supplier].[Get_ClinicalAuditTotalCountAndPassAuditsBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ftan
-- Create date: 04/18/2013
-- Description:	Get total clinical audits and total audits that have auditpass = 1
-- =============================================
CREATE PROCEDURE [supplier].[Get_ClinicalAuditTotalCountAndPassAuditsBySupplierID]
	-- Add the parameters for the stored procedure here
	@SupplierID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT [SupplierID], COUNT(CASE WHEN [AuditPass] = 1 THEN [AuditPass] ELSE NULL END) AS AuditPassCount, COUNT([SupplierClinicalAuditID]) AS SupplierClinicalAuditCount
  FROM  [supplier].[SupplierClinicalAudit]
  WHERE [SupplierID] = @SupplierID
  GROUP BY [SupplierID]
END


GO
/****** Object:  StoredProcedure [supplier].[Get_PractitionerTreatmentRegistrationsLikePractitionerNameForSupplier]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
      
-- =============================================        
-- Latest Version: 1.0
-- Author:  satya singh       
-- Create date: 13-Mar-2013      
-- Description: [Get_PractitionerTreatmentRegistrationsLikePractitionerNameForSupplier]        
-- Version : 1.0         
-- =============================================     
    
CREATE PROCEDURE [supplier].[Get_PractitionerTreatmentRegistrationsLikePractitionerNameForSupplier]
       
 @PractitionerName VARCHAR(50)        
        
AS         
 BEGIN        
        
SELECT     *  
FROM         [lookup].[PractitionerTreatmentRegistrations]
                      
                      WHERE     (( lookup.PractitionerTreatmentRegistrations.PractitionerFirstName LIKE  @PractitionerName + '%') 
                      or (lookup.PractitionerTreatmentRegistrations.PractitionerLastName LIKE  @PractitionerName + '%')
                      or (lookup.PractitionerTreatmentRegistrations.PractitionerFirstName + ' '+ lookup.PractitionerTreatmentRegistrations.PractitionerLastName LIKE  @PractitionerName + '%')
                       )              
        
 END 

GO
/****** Object:  StoredProcedure [supplier].[Get_ReferrerProjectTreatmentDocumentSetup]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================     
-- Latest Version : 1.0   
-- Author:  Rohit Kumar
-- Create date: 12-12-2014
-- Description: Get Referrer Project Treatment Document Setup
-- Version : 1.0       
-- =============================================    
CREATE PROCEDURE [supplier].[Get_ReferrerProjectTreatmentDocumentSetup]       
 -- Add the parameters for the stored procedure here      
    @CaseID INT 
    ,@AssessmentServiceID INT      
     
AS      
BEGIN       
      
      
	SELECT     referrer.ReferrerProjectTreatmentDocumentSetup.DocumentSetupTypeID
	FROM         global.Cases INNER JOIN
                      referrer.ReferrerProjectTreatmentDocumentSetup ON 
                      global.Cases.ReferrerProjectTreatmentID = referrer.ReferrerProjectTreatmentDocumentSetup.ReferrerProjectTreatmentID
	WHERE     (global.Cases.CaseID = @CaseID) AND (referrer.ReferrerProjectTreatmentDocumentSetup.AssessmentServiceID =@AssessmentServiceID)
	
END




GO
/****** Object:  StoredProcedure [supplier].[Get_SiteAuditTotalCountAndAuditPassBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ftan
-- Create date: 04/18/2013
-- Description:	Get total side audits and total audits that have auditpass = 1
-- =============================================
CREATE PROCEDURE [supplier].[Get_SiteAuditTotalCountAndAuditPassBySupplierID]
	-- Add the parameters for the stored procedure here
	@SupplierID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [SupplierID], COUNT(CASE WHEN [AuditPass] = 1 THEN [AuditPass] ELSE NULL END) AS AuditPassCount, COUNT([SupplierSiteAuditID]) AS SiteAuditCount
	FROM  [supplier].[SupplierSiteAudit] 
	WHERE [SupplierID] = @SupplierID
	GROUP BY [SupplierID]
END


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 11/17/2012
-- Description:	Get_SupplierBySupplierID Supplier information
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierBySupplierID]
	-- Add the parameters for the stored procedure here
	@SupplierID int		
AS
BEGIN	
	
    Select * From supplier.Suppliers where SupplierID=@SupplierID
   
    END
 


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierCasesAndPatientByWorkflowID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [supplier].[Get_SupplierCasesAndPatientByWorkflowID]
	@SupplierID int,
	@WorkflowID int
AS

	SELECT     global.Cases.CaseID, global.Patients.FirstName, global.Patients.LastName, global.Cases.CaseNumber, global.Cases.WorkflowID, 
						  lookup.Workflows.Definition AS WorkflowName, 
						  isnull((SELECT  top 1      AssessmentDate 
	FROM            global.CaseAssessmentDetail where  CaseID = global.Cases.CaseID and AssessmentServiceID=1),getdate()) as InitialAssessmentDate
	FROM         global.Cases INNER JOIN
						  global.Patients ON global.Cases.PatientID = global.Patients.PatientID INNER JOIN
						  lookup.Workflows ON global.Cases.WorkflowID = lookup.Workflows.WorkflowID

	WHERE		  global.Cases.SupplierID = @SupplierID AND global.Cases.WorkflowID = @WorkflowID
	




GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierClinicalAuditBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		Vishal
-- Create date: 12/29/2012
-- Description:	Get SupplierClinicalAudit information By SupplierID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierClinicalAuditBySupplierID]
	-- Add the parameters for the stored procedure here
	@SupplierID INT		
AS
BEGIN	
	
    SELECT * 
		FROM supplier.SupplierClinicalAudit 
    WHERE
		SupplierID=@SupplierID
   
    END
 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierClinicalAuditByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/29/2012
-- Description:	Get SupplierClinicalAudit information By UserID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierClinicalAuditByUserID] 
	-- Add the parameters for the stored procedure here
	@UserID INT		
AS
BEGIN	

    SELECT * 
		FROM  supplier.SupplierClinicalAudit
    WHERE
		UserID=@UserID
   
    END
 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierClinicalAuditSupplierDocumentBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- [supplier].[Get_SupplierClinicalAuditSupplierDocumentBySupplierID] 642
CREATE PROCEDURE [supplier].[Get_SupplierClinicalAuditSupplierDocumentBySupplierID]
	@SupplierID int
AS
BEGIN


SELECT        supplier.SupplierClinicalAudit.SupplierClinicalAuditID, supplier.SupplierClinicalAudit.AuditDate, supplier.SupplierClinicalAudit.AuditPass, global.Cases.CaseNumber, global.Patients.FirstName AS PatientFirstName, 
                         global.Patients.LastName AS PatientLastName, supplier.SupplierDocuments.DocumentTypeID, supplier.SupplierDocuments.UploadPath, supplier.SupplierDocuments.DocumentName, supplier.SupplierClinicalAudit.SupplierID, 
                         supplier.SupplierClinicalAudit.UserID, supplier.SupplierDocuments.UploadDate, global.Cases.PatientID, supplier.SupplierClinicalAudit.CaseID, supplier.SupplierDocuments.SupplierDocumentID, global.Users.Username
FROM            global.Users INNER JOIN
                         supplier.SupplierClinicalAudit INNER JOIN
                         supplier.SupplierDocuments ON supplier.SupplierClinicalAudit.SupplierDocumentID = supplier.SupplierDocuments.SupplierDocumentID AND 
                         supplier.SupplierClinicalAudit.SupplierDocumentID = supplier.SupplierDocuments.SupplierDocumentID ON global.Users.UserID = supplier.SupplierClinicalAudit.UserID AND 
                         global.Users.UserID = supplier.SupplierClinicalAudit.UserID AND global.Users.UserID = supplier.SupplierClinicalAudit.UserID LEFT OUTER JOIN
                         global.Patients INNER JOIN
                         global.Cases ON global.Patients.PatientID = global.Cases.PatientID AND global.Patients.PatientID = global.Cases.PatientID ON supplier.SupplierClinicalAudit.CaseID = global.Cases.CaseID
WHERE        (supplier.SupplierClinicalAudit.SupplierID = @SupplierID) AND (supplier.SupplierDocuments.DocumentTypeID = 4)


------------------------------------------------------------------------------------------------------------------------------------------------------------
-- COMMENTED AS THERE WAS NOT RELATED WITH CASEID AS 0 ID, STARE IN CASEID FIELD IN supplier.SupplierClinicalAudit TABLES


	--	SELECT     supplier.SupplierClinicalAudit.SupplierClinicalAuditID, supplier.SupplierClinicalAudit.AuditDate, supplier.SupplierClinicalAudit.AuditPass, global.Cases.CaseNumber, 
	--                      global.Patients.FirstName as [PatientFirstName] , global.Patients.LastName as [PatientLastName], supplier.SupplierDocuments.DocumentTypeID, supplier.SupplierDocuments.UploadPath, 
	--                      supplier.SupplierDocuments.DocumentName, supplier.SupplierClinicalAudit.SupplierID, supplier.SupplierClinicalAudit.UserID, 
	--                      supplier.SupplierDocuments.UploadDate, global.Cases.PatientID, supplier.SupplierClinicalAudit.CaseID, supplier.SupplierDocuments.SupplierDocumentID, 
	--                      global.Users.Username
	--FROM         supplier.SupplierClinicalAudit INNER JOIN
	--                      global.Cases ON supplier.SupplierClinicalAudit.CaseID = global.Cases.CaseID INNER JOIN
	--                      supplier.SupplierDocuments ON supplier.SupplierClinicalAudit.SupplierDocumentID = supplier.SupplierDocuments.SupplierDocumentID AND 
	--                      supplier.SupplierClinicalAudit.SupplierDocumentID = supplier.SupplierDocuments.SupplierDocumentID INNER JOIN
	--                      global.Patients ON global.Cases.PatientID = global.Patients.PatientID AND global.Cases.PatientID = global.Patients.PatientID INNER JOIN
	--                      global.Users ON supplier.SupplierClinicalAudit.UserID = global.Users.UserID AND supplier.SupplierClinicalAudit.UserID = global.Users.UserID AND 
	--                      supplier.SupplierClinicalAudit.UserID = global.Users.UserID 
	--	WHERE  (supplier.SupplierClinicalAudit.SupplierID = @SupplierID) AND (supplier.SupplierDocuments.DocumentTypeID = 4)
END



GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierComplaintAndStatusAndTypesBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Harpreet Singh>
-- Create date: <12-15-2012>
-- Description:	<Create the procedure to get the supplier complaint by supplier id,>
-- =============================================
CREATE PROCEDURE [supplier].[Get_SupplierComplaintAndStatusAndTypesBySupplierID]

@SupplierID int
AS
SELECT     supplier.SupplierComplaints.*, lookup.ComplaintTypes.ComplaintTypeName, lookup.ComplaintStatus.ComplaintStatusName
FROM         supplier.SupplierComplaints INNER JOIN
                      lookup.ComplaintStatus ON supplier.SupplierComplaints.ComplaintStatusID = lookup.ComplaintStatus.ComplaintStatusID INNER JOIN
                      lookup.ComplaintTypes ON supplier.SupplierComplaints.ComplaintTypeID = lookup.ComplaintTypes.ComplaintTypeID
                       where [SupplierID]=@SupplierID


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierComplaintBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Harpreet Singh>
-- Create date: <12-15-2012>
-- Description:	<Create the procedure to get the supplier complaint by supplier id,>
-- =============================================
CREATE PROCEDURE [supplier].[Get_SupplierComplaintBySupplierID]

@SupplierID int
AS
SELECT *
  FROM [supplier].[SupplierComplaints] where [SupplierID]=@SupplierID


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierDocumentByCaseId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  GJain
-- Create date: 12/19/2014
-- Description: to Get Supplier Document By CaseId
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [supplier].[Get_SupplierDocumentByCaseId]  
 -- Add the parameters for the stored procedure here  
     (@CaseId int  
    
     )  
AS  
BEGIN   
	
	SELECT     supplier.SupplierDocuments.SupplierDocumentID, supplier.SupplierDocuments.DocumentTypeID, supplier.SupplierDocuments.SupplierID, 
                      supplier.SupplierDocuments.UserID, supplier.SupplierDocuments.UploadDate, supplier.SupplierDocuments.DocumentName, supplier.SupplierDocuments.UploadPath, 
                      supplier.SupplierDocuments.ReferrerProjectTreatmentID, supplier.SupplierDocuments.CaseId, global.Users.FirstName + ' ' + global.Users.LastName AS username, 
                      global.Users.FirstName + '_' + global.Users.LastName + '_' + supplier.SupplierDocuments.DocumentName AS Documentfullname
FROM         supplier.SupplierDocuments INNER JOIN
                      global.Users ON global.Users.UserID = supplier.SupplierDocuments.UserID
WHERE     (supplier.SupplierDocuments.CaseId = @CaseId)
ORDER BY supplier.SupplierDocuments.UploadDate
	
END  
  
  

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierDocumentByCaseIdAndDocumentTypeId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Rohit Kumar
-- Create date: 12/17/2014
-- Description: to Get Supplier Document By CaseId And DocumentTypeId
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [supplier].[Get_SupplierDocumentByCaseIdAndDocumentTypeId]  
 -- Add the parameters for the stored procedure here  
     (@CaseId int  
     ,@DocumentTypeID int
     )  
AS  
BEGIN   
	
	
	SELECT    top 1 * FROM         supplier.SupplierDocuments where CaseId = @CaseId
	and DocumentTypeID =@DocumentTypeID order by SupplierDocumentID desc
  
END  
  
  

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierDocumentBySupplierIDAndDocumentTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Manjit Singh  
-- Create date: 12/15/2012  
-- Description: to Get Supplier Documents By SupplierID and DocumentTypeID  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [supplier].[Get_SupplierDocumentBySupplierIDAndDocumentTypeID]  
 -- Add the parameters for the stored procedure here  
     (@DocumentTypeID int,  
      @SupplierID int  
     )  
AS  
BEGIN   
SELECT * FROM [supplier].[SupplierDocumentsUsers] 
WHERE	SupplierID = @SupplierID 
AND DocumentTypeID = @DocumentTypeID  
  
END  
  
  

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierExistsByEmail]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [supplier].[Get_SupplierExistsByEmail]   
(  
@Email VARCHAR(100)  
)  
AS  
SELECT CAST(   
   CASE WHEN EXISTS(SELECT Email FROM supplier.Suppliers WHERE Email=@Email) THEN 1    
   ELSE 0    
   END    
AS BIT)  


  
  
  
  

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierExistsByName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Latest Version : 1.1
-- Author:		Robin Singh
-- Create date: 06/06/2013
-- Description:	Procedure to check SupplierNameExists  
-- Version: 1.0
-- Updated By:  Robin Singh
-- Create date: 06/10/2013
-- Description:	Rename Procedure Name Is_SupplierNameExists by  Get_SupplierExistsByName
-- Version: 1.1
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierExistsByName] 
(
@SupplierName VARCHAR(100)
)
AS
SELECT CAST( 
   CASE WHEN EXISTS(SELECT SupplierName FROM supplier.Suppliers WHERE SupplierName=@SupplierName) THEN 1  
   ELSE 0  
   END  
AS BIT)






GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierInsuranceBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




/*

Latest Version : 1.0

Author  : Pardeep Kumar
Date    : 24-Dec-2012
Version : 1.0
Purpose : Created proc to GET record FROM table [supplier].[SupplierInsurance] by SupplierID

*/

CREATE PROCEDURE [supplier].[Get_SupplierInsuranceBySupplierID]
(
@SupplierID INT
)
as

SELECT * 
       FROM [supplier].[SupplierInsurance]
       WHERE 
           SupplierID = @SupplierID

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierInsuranceSupplierDocumentBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [supplier].[Get_SupplierInsuranceSupplierDocumentBySupplierID]--477
	@SupplierID int
AS
BEGIN
SELECT     supplier.SupplierDocuments.DocumentTypeID, supplier.SupplierDocuments.UploadDate, supplier.SupplierDocuments.DocumentName, 
                      supplier.SupplierDocuments.UploadPath, global.Users.Username, supplier.SupplierInsurance.*, supplier.SupplierDocuments.UserID
FROM         supplier.SupplierDocuments INNER JOIN
                      supplier.SupplierInsurance ON supplier.SupplierDocuments.SupplierDocumentID = supplier.SupplierInsurance.SupplierDocumentID INNER JOIN
                      global.Users ON supplier.SupplierDocuments.UserID = global.Users.UserID AND supplier.SupplierDocuments.UserID = global.Users.UserID AND 
                      supplier.SupplierDocuments.UserID = global.Users.UserID
                    
	WHERE 
		supplier.SupplierInsurance.SupplierID = @SupplierID AND supplier.SupplierDocuments.DocumentTypeID = 2
END


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierLikePostCode]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Harpreet Singh>
-- Create date: <12-28-2012>
-- Description:	<This Procedure Used Search Supplier Like by  PostCode >
-- Version	:	1.0	
-- ====================================================
 -- Updated By: Anuj Batra  
-- Create date: 06/14/2013  
-- Description: Added parameter Skip and Take of pagging.
-- Version: 1.1  
-- ======================================================

CREATE PROCEDURE [supplier].[Get_SupplierLikePostCode]  --'AB', 2,10

 @PostCode NVARCHAR(100),
   @Skip INT,    
 @Take INT 
AS 
    BEGIN
    
    set nocount on;
WITH SuppliersMatched AS
(
SELECT ROW_NUMBER() Over (Order By [supplier].[SupplierSearch].[SupplierID]) As ROW,*
  From [supplier].[SupplierSearch]   where [supplier].[SupplierSearch].PostCode LIKE (@PostCode + '%')
  
      )
select * from SuppliersMatched prp  
   where prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take

 END
 
 



GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierLikePostCodeCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vikas Mahant>
-- Create date: <18-06-2013>
-- Description:	<This Procedure Used for Count Supplier Like by  PostCode >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [supplier].[Get_SupplierLikePostCodeCount]  

 @PostCode NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  From [supplier].[SupplierSearch]   where [supplier].[SupplierSearch].PostCode LIKE (@PostCode + '%')
 
 End

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierLikeTreatmentCategoryType]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vikas Mahant>
-- Create date: <18-06-2013>
-- Description:	<This Procedure Used for Count Supplier Like by  TreatmentCategoryType >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [supplier].[Get_SupplierLikeTreatmentCategoryType] 

 @TreatmentCategoryType NVARCHAR(100),
   @Skip INT,    
 @Take INT 
AS 
    BEGIN
    
    set nocount on;
WITH SuppliersMatched AS
(
SELECT ROW_NUMBER() Over (Order By [supplier].[SupplierSearch].[SupplierID]) As ROW,*
  From [supplier].[SupplierSearch]   where [supplier].[SupplierSearch].TreatmentCategoryName LIKE (@TreatmentCategoryType + '%')
  
      )
select * from SuppliersMatched prp  
   where prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take

 END
 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierLikeTreatmentCategoryTypeCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vikas Mahant>
-- Create date: <18-06-2013>
-- Description:	<This Procedure Used for Count Supplier Like by  TreatmentCategoryType >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [supplier].[Get_SupplierLikeTreatmentCategoryTypeCount] 

  @TreatmentCategoryType NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  From [supplier].[SupplierSearch]   where [supplier].[SupplierSearch].TreatmentCategoryName LIKE (@TreatmentCategoryType + '%')
 
 End

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierPractitionerByPractitionerRegistrationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================    
-- Author:  <Satya>    
-- Create date: <03-25-2013>    
-- Description: <Create the procedure to Get Supplier Practitioner By PractitionerRegistrationID>    
-- =============================================    
  
CREATE PROCEDURE [supplier].[Get_SupplierPractitionerByPractitionerRegistrationID]    
@PractitionerRegistrationID int    
AS    
SELECT   * from [supplier].[SupplierPractitioners] 
where [PractitionerRegistrationID]=@PractitionerRegistrationID

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierPractitionerBySupplierPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
    
-- =============================================    
-- Created By : <Pardeep Kumar>    
-- Create date : <31-Jan-2013>    
-- Description : <Create the procedure to Get Supplier Practitioner By SupplierPractitionerID>   
-- =============================================    



CREATE PROCEDURE [supplier].[Get_SupplierPractitionerBySupplierPractitionerID]    
@SupplierPractitionerID int    
AS    
SELECT   * from [supplier].[SupplierPractitioners] where [SupplierPractitionerID]= @SupplierPractitionerID 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROCEDURE [supplier].[Get_SupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID]
@SupplierID INT,  
 @PractitionerRegistrationID INT = NULL   
AS      
BEGIN      
 -- SET NOCOUNT ON added to prevent extra result sets from      
 -- interfering with SELECT statements.      
 SET NOCOUNT ON;      
      
    -- Insert statements for procedure here      
 SELECT * FROM supplier.SupplierPractitioners     
      WHERE SupplierID = @SupplierID 
      AND PractitionerRegistrationID = @PractitionerRegistrationID  
END 



GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierPractitionerSupplierByPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
        
  
  
  
-- Get_SupplierPractitionerSupplierByPractitionerID  
  
-- =============================================        
-- Created By : <SATYA>        
-- Create date : <26-Jun-2013>        
-- Description : <Create the procedure to Get SupplierPractitioner By PractitionerID>       
-- =============================================        
    
    
  
  
CREATE PROCEDURE [supplier].[Get_SupplierPractitionerSupplierByPractitionerID]        
@PractitionerID int        
AS        
SELECT     lookup.RegistrationTypes.RegistrationTypeName, supplier.SupplierPractitioners.PractitionerRegistrationID, supplier.SupplierPractitioners.SupplierID,   
                      supplier.SupplierPractitioners.SupplierPractitionerID, global.PractitionerRegistrations.RegistrationNumber, supplier.Suppliers.SupplierName,   
                      global.PractitionerRegistrations.PractitionerID  
FROM         supplier.SupplierPractitioners INNER JOIN  
                      global.PractitionerRegistrations ON supplier.SupplierPractitioners.PractitionerRegistrationID = global.PractitionerRegistrations.PractitionerRegistrationID LEFT JOIN  
                      lookup.RegistrationTypes ON global.PractitionerRegistrations.RegistrationTypeID = lookup.RegistrationTypes.RegistrationTypeID INNER JOIN  
                      supplier.Suppliers ON supplier.SupplierPractitioners.SupplierID = supplier.Suppliers.SupplierID  
WHERE     (global.PractitionerRegistrations.PractitionerID = @PractitionerID)

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierPractitionerTreatmentRegistrationsBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

    
-- =============================================    
-- Latest Version: 1.0  
-- Author:  <Satya>    
-- Create date: <15-03-2013>    
-- Description: <Create the Get PractitionerTreatmentRegistrations By SupplierID >  

-- =============================================  
CREATE PROCEDURE [supplier].[Get_SupplierPractitionerTreatmentRegistrationsBySupplierID]
@SupplierID int    
AS    

SELECT     [lookup].[PractitionerTreatmentRegistrations].*,supplier.SupplierPractitioners.SupplierPractitionerID
	      

FROM         [lookup].[PractitionerTreatmentRegistrations] INNER JOIN supplier.SupplierPractitioners ON 
			  lookup.PractitionerTreatmentRegistrations.PractitionerRegistrationID = supplier.SupplierPractitioners.PractitionerRegistrationID AND 
     --         lookup.PractitionerTreatmentRegistrations.PractitionerID = supplier.SupplierPractitioners.PractitionerID AND 
              supplier.SupplierPractitioners.SupplierID = @SupplierID 
                      

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierPriceAverage]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		ftan
-- Create date: 04-16-2013

-- =============================================
CREATE PROCEDURE [supplier].[Get_SupplierPriceAverage]--320,1
	-- Add the parameters for the stored procedure here
	@SupplierID INT,
	@TreatmentCategoryID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

   
SELECT ST1.Price,ST1.PricingTypeID From supplier.SupplierTreatmentPricing  ST1   
INNER JOIN supplier.SupplierTreatments ON supplier.SupplierTreatments.SupplierTreatmentID = ST1.SupplierTreatmentID
WHERE  ST1.PricingTypeID IN(1,2,3,4) AND supplier.SupplierTreatments.SupplierID = @SupplierID AND supplier.SupplierTreatments.TreatmentCategoryID=@TreatmentCategoryID
END


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierRegistrationSupplierDocumentBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [supplier].[Get_SupplierRegistrationSupplierDocumentBySupplierID] 
	@SupplierID int
AS
BEGIN
SELECT     supplier.SupplierDocuments.DocumentTypeID, supplier.SupplierDocuments.UploadDate, supplier.SupplierDocuments.DocumentName, 
                      supplier.SupplierDocuments.UploadPath, global.Users.Username, supplier.SupplierDocuments.UserID, supplier.SupplierDocuments.SupplierID,
                      supplier.SupplierDocuments.SupplierDocumentID
FROM         supplier.SupplierDocuments INNER JOIN
                      global.Users ON supplier.SupplierDocuments.UserID = global.Users.UserID AND supplier.SupplierDocuments.UserID = global.Users.UserID AND 
                      supplier.SupplierDocuments.UserID = global.Users.UserID
WHERE     (supplier.SupplierDocuments.DocumentTypeID = 1) AND 
		  supplier.SupplierDocuments.SupplierID = @SupplierID 
END


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierSiteAuditBySupplierDocumentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/24/2012
-- Description:	Get SupplierSiteAudit information By SupplierDocumentID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierSiteAuditBySupplierDocumentID]
	-- Add the parameters for the stored procedure here
	@SupplierDocumentID INT		
AS
BEGIN	
	
    SELECT * 
		FROM  supplier.SupplierSiteAudit
    WHERE
		SupplierDocumentID=@SupplierDocumentID
   
    END
 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierSiteAuditBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/24/2012
-- Description:	Get SupplierSiteAudit information By SupplierID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierSiteAuditBySupplierID]
	-- Add the parameters for the stored procedure here
	@SupplierID INT		
AS
BEGIN	
	
    SELECT * 
		FROM  supplier.SupplierSiteAudit
    WHERE
		SupplierID=@SupplierID
   
    END
 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierSiteAuditBySupplierSiteAuditID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/24/2012
-- Description:	Get SupplierSiteAudit information By SupplierSiteAuditID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierSiteAuditBySupplierSiteAuditID]
	-- Add the parameters for the stored procedure here
	@SupplierSiteAuditID INT		
AS
BEGIN	
	
    SELECT * 
		FROM  supplier.SupplierSiteAudit
    WHERE
		SupplierSiteAuditID=@SupplierSiteAuditID
   
    END
 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierSiteAuditByUserID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/24/2012
-- Description:	Get SupplierSiteAudit information By UserID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierSiteAuditByUserID]
	-- Add the parameters for the stored procedure here
	@UserID INT		
AS
BEGIN	
	
    SELECT * 
		FROM  supplier.SupplierSiteAudit
    WHERE
		UserID=@UserID
   
    END
 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierSiteAuditSupplierDocumentBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [supplier].[Get_SupplierSiteAuditSupplierDocumentBySupplierID]
	@SupplierID int
AS
BEGIN
SELECT     global.Users.Username, supplier.SupplierSiteAudit.*, supplier.SupplierDocuments.DocumentTypeID, supplier.SupplierDocuments.UploadDate, 
                      supplier.SupplierDocuments.DocumentName, supplier.SupplierDocuments.UploadPath
FROM         supplier.SupplierSiteAudit INNER JOIN
                      supplier.SupplierDocuments ON supplier.SupplierSiteAudit.SupplierDocumentID = supplier.SupplierDocuments.SupplierDocumentID AND 
                      supplier.SupplierSiteAudit.SupplierDocumentID = supplier.SupplierDocuments.SupplierDocumentID INNER JOIN
                      global.Users ON supplier.SupplierSiteAudit.UserID = global.Users.UserID AND supplier.SupplierSiteAudit.UserID = global.Users.UserID
                    
	WHERE 
		supplier.SupplierSiteAudit.SupplierID = @SupplierID AND supplier.SupplierDocuments.DocumentTypeID = 3
END


GO
/****** Object:  StoredProcedure [supplier].[Get_SuppliersLikeSupplierName]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  Harpreet Singh  
-- Create date: 12/28/2012  
-- Description: Get_SuppliersLikeSupplierName Supplier information  
-- Version: 1.0  
-- =============================================  
 -- Updated By: Anuj Batra  
-- Create date: 06/14/2013  
-- Description: Added parameter Skip and Take of pagging.
-- Version: 1.1  
-- =============================================  
     
CREATE PROCEDURE [supplier].[Get_SuppliersLikeSupplierName]  --'32',3,10 
 -- Add the parameters for the stored procedure here  
 @SupplierName varchar(100),
  @Skip INT,    
 @Take INT 
AS  
BEGIN    

set nocount on;
WITH SuppliersMatched AS
(
SELECT ROW_NUMBER() Over (Order By [supplier].[SupplierSearch].[SupplierID]) As ROW,*
  From [supplier].[SupplierSearch]   where [supplier].[SupplierSearch].SupplierName Like (@SupplierName + '%')
  
      )
 select * from SuppliersMatched prp  
   where prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take
END

GO
/****** Object:  StoredProcedure [supplier].[Get_SuppliersLikeSupplierNameCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Vikas Mahant>
-- Create date: <18-06-2013>
-- Description:	<This Procedure Used for Count Supplier Like by  SupplierName >
-- Version	:	1.0	
-- ====================================================
 

CREATE PROCEDURE [supplier].[Get_SuppliersLikeSupplierNameCount] 

  @SupplierName NVARCHAR(100)

AS 
    BEGIN
    
SELECT COUNT(*)'Count'
  From [supplier].[SupplierSearch]   where [supplier].[SupplierSearch].SupplierName LIKE (@SupplierName + '%')
 
 End

GO
/****** Object:  StoredProcedure [supplier].[Get_SuppliersRecentlyAdded]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 06/10/2013
-- Description:	Get_SuppliersRecentlyAdded
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SuppliersRecentlyAdded]
	-- Add the parameters for the stored procedure here
AS
BEGIN	
	
    Select TOP 10 * From supplier.Suppliers 
    ORDER BY supplier.Suppliers.DateAdded DESC
   
    END
 


GO
/****** Object:  StoredProcedure [supplier].[Get_SuppliersTreamentPricingByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author:  SATYA  
-- Create date: 06/24/2013  
-- Description: Get SuppliersTreamentPricing By TreatmentCategoryID  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [supplier].[Get_SuppliersTreamentPricingByTreatmentCategoryID]
 -- Add the parameters for the stored procedure here  
 @TreatmentCategoryID INT  
AS  
BEGIN   
   
  SELECT  supplier.Suppliers.*,ST2.SupplierTreatmentID, SUBSTRING(    
            ((Select + ','+ CAST(ST1.Price AS VARCHAR(400))   
            From supplier.SupplierTreatmentPricing  ST1    
            Where ST1.SupplierTreatmentID = ST2.SupplierTreatmentID   AND ST1.PricingTypeID IN(1,2,3,4)  
            For XML PATH (''))),2,100)AS [Price]   
            FROM         supplier.SupplierTreatments INNER JOIN  
                      supplier.Suppliers ON supplier.SupplierTreatments.SupplierID = supplier.Suppliers.SupplierID INNER JOIN  
                      supplier.SupplierTreatmentPricing ST2 ON supplier.SupplierTreatments.SupplierTreatmentID = ST2.SupplierTreatmentID  
WHERE     supplier.SupplierTreatments.Enabled = 'true' AND supplier.Suppliers.IsTriage = 'false'  AND  
   supplier.SupplierTreatments.TreatmentCategoryID = @TreatmentCategoryID  and ST2.PricingTypeID IN(1,2,3,4) and supplier.Suppliers.StatusID=1
   GROUP BY [suppliers].[SupplierID]
      ,[suppliers].[SupplierName],[suppliers].[Address],[suppliers].[City],[suppliers].[Region],[suppliers].[PostCode] ,[suppliers].[Phone] ,[suppliers].[Fax],
      [suppliers].[Website],[suppliers].[Ranking]
      ,[suppliers].[Notes],[suppliers].[IsWheelChairAccessibility]
      ,[suppliers].[IsWeekends],[suppliers].[IsEvenings],[suppliers].[IsParking],[suppliers].[IsHomeVisit],[suppliers].[StatusID],[suppliers].[DateAdded],
      [suppliers].[Email],[suppliers].[IsTriage], ST2.SupplierTreatmentID
   ORDER BY supplier.Suppliers.SupplierName
     
END

GO
/****** Object:  StoredProcedure [supplier].[Get_SuppliersTriageTreamentPricingByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Author:  SATYA    
-- Create date: 06/24/2013    
-- Description: Get SuppliersTriageTreamentPricing By TreatmentCategoryID    
-- Version: 1.0    
-- =============================================    
    
CREATE PROCEDURE [supplier].[Get_SuppliersTriageTreamentPricingByTreatmentCategoryID]  
 -- Add the parameters for the stored procedure here    
 @TreatmentCategoryID INT    
AS    
BEGIN     
     
SELECT     supplier.Suppliers.*,    
                      supplier.SupplierTreatmentPricing.Price    
FROM         supplier.SupplierTreatments INNER JOIN    
                      supplier.Suppliers ON supplier.SupplierTreatments.SupplierID = supplier.Suppliers.SupplierID INNER JOIN    
                      supplier.SupplierTreatmentPricing ON supplier.SupplierTreatments.SupplierTreatmentID = supplier.SupplierTreatmentPricing.SupplierTreatmentID    
WHERE     supplier.SupplierTreatments.Enabled = 'true' AND supplier.Suppliers.IsTriage = 'true'  AND    
   supplier.SupplierTreatments.TreatmentCategoryID = @TreatmentCategoryID  and supplier.SupplierTreatmentPricing.PricingTypeID=15 and supplier.Suppliers.StatusID=1  
       
END

GO
/****** Object:  StoredProcedure [supplier].[Get_SuppliersWithinArea]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [supplier].[Get_SuppliersWithinArea] --0.997424862453462,-0.0365934108553541,1,1
	-- Add the parameters for the stored procedure here
	@RadiansLatitude FLOAT,
	@RadiansLongitude FLOAT,
	@DistanceKM INT,
	@TreatmentCategoryID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 10 p.[PostCode]
      ,s.[SupplierID]
      ,s.[Address]
      ,s.[Phone]
      ,s.SupplierName
      --,(6371 * acos( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) ) ) AS Distance
      ,(6371 * acos( CASE WHEN ABS( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude )) > 1 THEN SIGN( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) )*1 ELSE  cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) END)) AS Distance
  FROM  [lookup].[UKPostCodes] p
  INNER JOIN supplier.Suppliers s ON s.PostCode = p.PostCode
  INNER JOIN supplier.SupplierTreatments st ON s.[SupplierID] = st.SupplierID
  --WHERE (6371 * acos( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) ) ) < @DistanceKM
  WHERE (6371 * acos( CASE WHEN ABS( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude )) > 1 THEN SIGN( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) )*1 ELSE  cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) END)) < @DistanceKM
  AND s.IsTriage = 0 AND st.Enabled = 1 AND st.TreatmentCategoryID = @TreatmentCategoryID AND s.StatusID = 1
  ORDER BY [SupplierName] ASC
END


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierTreatmentBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Satya
-- Create date: 11/18/2012
-- Description:	Get_SupplierTreatmentBySupplierID information
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierTreatmentBySupplierID]
	-- Add the parameters for the stored procedure here
	@SupplierID INT		
AS
BEGIN	
	
    SELECT * FROM [supplier].SupplierTreatments 
    WHERE SupplierID = @SupplierID
   
END
 


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierTreatmentExistsBySupplierIDAndTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [supplier].[Get_SupplierTreatmentExistsBySupplierIDAndTreatmentCategoryID]-- 240,2551
@SupplierID INT,
 @TreatmentCategoryID INT  
AS    
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here    
 SELECT * FROM supplier.SupplierTreatments   
      WHERE SupplierID = @SupplierID AND TreatmentCategoryID = @TreatmentCategoryID 
END 

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierTreatmentPricingBySupplierTreatmentId]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 12/21/2012
-- Description:	Get SupplierTreatmentPricing By SupplierTreatmentId
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierTreatmentPricingBySupplierTreatmentId]
	-- Add the parameters for the stored procedure here
	@SupplierTreatmentId INT		
AS
BEGIN	
	
    SELECT * FROM [supplier].[SupplierTreatmentPricing]
    WHERE [SupplierTreatmentId] = @SupplierTreatmentId
   
    END
 


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- ============================================= 
-- Author:          ftan 
-- Create date: 06-25-2013 
-- Description:     retrieve all pricing by treatmentcategory with supplier pricing data by passing suppliertreatmentid and treatmentcategoryid  
-- [supplier].[Get_SupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID] 1816, 1
-- ============================================= 
CREATE PROCEDURE [supplier].[Get_SupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID] 
     @SupplierTreatmentID INT, 
     @TreatmentCategoryID INT 
AS 
BEGIN 
     -- SET NOCOUNT ON added to prevent extra result sets from 
     -- interfering with SELECT statements. 
     SET NOCOUNT ON; 
 
     SELECT p.Price, p.PricingID, p.SupplierTreatmentID, t.TreatmentCategoryID, t.TreatmentCategoryName, t.PricingTypeName, t.PricingTypeID FROM ( 
      SELECT [supplier].[SupplierTreatmentPricing].Price 
      ,[supplier].[SupplierTreatmentPricing].PricingID 
      ,[supplier].[SupplierTreatmentPricing].PricingTypeID 
      ,[supplier].[SupplierTreatmentPricing].SupplierTreatmentID 
      ,[supplier].[SupplierTreatments].TreatmentCategoryID 
        FROM [supplier].[SupplierTreatmentPricing]--, lookup.PricingTypes.* 
      INNER JOIN supplier.SupplierTreatments ON supplier.SupplierTreatmentPricing.SupplierTreatmentID = supplier.SupplierTreatments.SupplierTreatmentID 
      WHERE supplier.SupplierTreatmentPricing.[SupplierTreatmentId] = @SupplierTreatmentID ) p 
      RIGHT JOIN [lookup].[TreatmentCategoriesPricingTypes] t ON p.TreatmentCategoryID = t.TreatmentCategoryID 
      AND p.PricingTypeID = t.PricingTypeID 
      WHERE t.TreatmentCategoryID = @TreatmentCategoryID 
END 


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		SATYA
-- Create date: 06/24/2013
-- Description:	Get SupplierTreatmentPricing By TreatmentCategoryID And SupplierID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Get_SupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID]
	-- Add the parameters for the stored procedure here
	@TreatmentCategoryID INT,
    @SupplierID INT
AS
BEGIN	
	
SELECT     supplier.SupplierTreatmentPricing.PricingID, supplier.SupplierTreatmentPricing.PricingTypeID, supplier.SupplierTreatmentPricing.Price, 
                      supplier.SupplierTreatmentPricing.SupplierTreatmentID
FROM         supplier.SupplierTreatmentPricing INNER JOIN
                      supplier.SupplierTreatments ON supplier.SupplierTreatmentPricing.SupplierTreatmentID = supplier.SupplierTreatments.SupplierTreatmentID
WHERE     (supplier.SupplierTreatments.TreatmentCategoryID = @TreatmentCategoryID) AND (supplier.SupplierTreatments.SupplierID = @SupplierID)
   
END
 


GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- ============================================= 
-- Latest Version : Version: 1.0   
-- Author:  Pardeep Kumar  
-- Create date: 21/Aug/2013  
-- Description: alter PROCEDURE to Get SupplierTreatmentPricing By TreatmentCategoryID And SupplierID AndPricingTypeID
-- Version: 1.0  
-- ============================================= 


CREATE PROCEDURE [supplier].[Get_SupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID]
(
@SupplierID int ,
@TreatmentCategoryID int,
@PricingTypeID int
)
as


SELECT     supplier.SupplierTreatmentPricing.PricingID, supplier.SupplierTreatmentPricing.PricingTypeID, supplier.SupplierTreatmentPricing.Price, 
                      supplier.SupplierTreatmentPricing.SupplierTreatmentID, supplier.SupplierTreatments.TreatmentCategoryID, supplier.SupplierTreatments.SupplierID
FROM         supplier.SupplierTreatmentPricing INNER JOIN
                      supplier.SupplierTreatments ON supplier.SupplierTreatmentPricing.SupplierTreatmentID = supplier.SupplierTreatments.SupplierTreatmentID
WHERE     (supplier.SupplierTreatments.SupplierID = @SupplierID) AND 
(supplier.SupplierTreatments.TreatmentCategoryID = @TreatmentCategoryID) 
AND (supplier.SupplierTreatmentPricing.PricingTypeID = @PricingTypeID)

GO
/****** Object:  StoredProcedure [supplier].[Get_SupplierWithinAreaBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [supplier].[Get_SupplierWithinAreaBySupplierID] --0.997424862453462,-0.0365934108553541,1,1
	-- Add the parameters for the stored procedure here
	@RadiansLatitude FLOAT,
	@RadiansLongitude FLOAT,
	@DistanceKM INT,
	@TreatmentCategoryID INT,
	@SupplierID INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 10 p.[PostCode]
      ,s.[SupplierID]
      ,s.[Address]
      ,s.[Phone]
      ,s.SupplierName
      --,(6371 * acos( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) ) ) AS Distance
      ,(6371 * acos( CASE WHEN ABS( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude )) > 1 THEN SIGN( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) )*1 ELSE  cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) END)) AS Distance
  FROM  [lookup].[UKPostCodes] p
  INNER JOIN supplier.Suppliers s ON s.PostCode = p.PostCode
  INNER JOIN supplier.SupplierTreatments st ON s.[SupplierID] = st.SupplierID
  --WHERE (6371 * acos( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) ) ) < @DistanceKM
  WHERE (6371 * acos( CASE WHEN ABS( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude )) > 1 THEN SIGN( cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) )*1 ELSE  cos( @RadiansLatitude ) * cos( p.RadiansLatitude ) * cos( p.RadiansLongitude - (@RadiansLongitude) ) + sin( @RadiansLatitude ) * sin( p.RadiansLatitude ) END)) < @DistanceKM
  AND s.IsTriage = 0 AND st.Enabled = 1 AND st.TreatmentCategoryID = @TreatmentCategoryID AND s.StatusID = 1
  AND s.SupplierID=@SupplierID
END


GO
/****** Object:  StoredProcedure [supplier].[Get_TriageSuppliers]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================  
-- Author: Anuj Batra  
-- Create date: 06/17/2013  
-- Description: Created Sp to Get_TriageSuppliers with pagging parameteres.
-- Version: 1.0  
-- =============================================  
     
CREATE PROCEDURE [supplier].[Get_TriageSuppliers]  --10,10 
 -- Add the parameters for the stored procedure here  
   @Skip INT,    
 @Take INT 
AS  
BEGIN    

set nocount on;
WITH SuppliersMatched AS
(
SELECT ROW_NUMBER() Over (Order By [supplier].[Suppliers].[SupplierID]) As ROW,*
  From [supplier].[Suppliers]   where [supplier].[Suppliers].IsTriage = 'true'
  
      )
 select * from SuppliersMatched prp  
   where prp.ROW BETWEEN @Skip + 1 AND @Skip + @Take
END

GO
/****** Object:  StoredProcedure [supplier].[Get_TriageSuppliersCount]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
    
-- =============================================    
-- Author:  <Pardeep Kumar>    
-- Create date: <06-17-2013>    
-- Description: Get TriageSuppliers Counts>    
-- =============================================    
CREATE PROCEDURE [supplier].[Get_TriageSuppliersCount]     
    
    
AS    
    
 BEGIN    
     
 SELECT COUNT(*)'Count'      
  From [supplier].[Suppliers]   where [supplier].[Suppliers].IsTriage = 1
     
  END    

GO
/****** Object:  StoredProcedure [supplier].[Get_TriageSuppliersTreamentPricingByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  SATYA  
-- Create date: 06/24/2013  
-- Description: Get SuppliersTriageTreamentPricing By TreatmentCategoryID  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [supplier].[Get_TriageSuppliersTreamentPricingByTreatmentCategoryID]
 -- Add the parameters for the stored procedure here  
 @TreatmentCategoryID INT  
AS  
BEGIN   
   
SELECT     supplier.Suppliers.*,  
                      supplier.SupplierTreatmentPricing.Price  
FROM         supplier.SupplierTreatments INNER JOIN  
                      supplier.Suppliers ON supplier.SupplierTreatments.SupplierID = supplier.Suppliers.SupplierID INNER JOIN  
                      supplier.SupplierTreatmentPricing ON supplier.SupplierTreatments.SupplierTreatmentID = supplier.SupplierTreatmentPricing.SupplierTreatmentID  
WHERE     supplier.SupplierTreatments.Enabled = 'true' AND supplier.Suppliers.IsTriage = 'true'  AND  
   supplier.SupplierTreatments.TreatmentCategoryID = @TreatmentCategoryID  and supplier.SupplierTreatmentPricing.PricingTypeID=15 and supplier.Suppliers.StatusID=1
     
END

GO
/****** Object:  StoredProcedure [supplier].[Get_TriageTopSuppliersTreamentPricingByTreatmentCategoryID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  SATYA  
-- Create date: 07/04/2013  
-- Description: Get TriageTopSuppliersTreamentPricingByTreatmentCategoryID 
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [supplier].[Get_TriageTopSuppliersTreamentPricingByTreatmentCategoryID]
 -- Add the parameters for the stored procedure here  
 @TreatmentCategoryID INT  
AS  
BEGIN   
   
SELECT    TOP 10 supplier.Suppliers.*,  
                      supplier.SupplierTreatmentPricing.Price  
FROM         supplier.SupplierTreatments INNER JOIN  
                      supplier.Suppliers ON supplier.SupplierTreatments.SupplierID = supplier.Suppliers.SupplierID INNER JOIN  
                      supplier.SupplierTreatmentPricing ON supplier.SupplierTreatments.SupplierTreatmentID = supplier.SupplierTreatmentPricing.SupplierTreatmentID  
WHERE     supplier.SupplierTreatments.Enabled = 'true' AND supplier.Suppliers.IsTriage = 'true'  AND  
   supplier.SupplierTreatments.TreatmentCategoryID = @TreatmentCategoryID  and supplier.SupplierTreatmentPricing.PricingTypeID=15 and supplier.Suppliers.StatusID=1
     ORDER BY Price 
END

GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 11/17/2012
-- Description:	Update Supplier information
-- Version: 1.0
-- =============================================
-- =============================================
-- Author:		Vikas Mahant
-- Create date: 18/06/2013
-- Description:	Add new field IsTriage
-- Version: 1.1
-- =============================================


CREATE PROCEDURE [supplier].[Update_SupplierBySupplierID]
	-- Add the parameters for the stored procedure here
	@SupplierID int,	
	@SupplierName NVARCHAR(100),
	@Address NVARCHAR(200),
	@City NVARCHAR(100),
	@Region NVARCHAR(100),
	@PostCode NVARCHAR(12),
	@Phone NVARCHAR(16),
	@Fax NVARCHAR(16),
	@Website NVARCHAR(50),
	@Ranking int,
	@Notes NVARCHAR(MAX),
	@IsWheelChairAccessibility bit ,
	@IsWeekends bit,
	@IsEvenings bit ,
	@IsParking bit,
	@IsHomeVisit bit,
	@Email VARCHAR(50),
	@IsTriage bit
	--@Status varchar(10)
AS
BEGIN	
	
    update supplier.Suppliers
    set 	 	 	
	SupplierName=@SupplierName,
	[Address]=@Address,
	City=@City,
	Region=@Region,
	PostCode=@PostCode,
	Phone=@Phone,
	Fax=@Fax,
	Website=@Website,
	Ranking=@Ranking,
	Notes=@Notes,
	IsWheelChairAccessibility=@IsWheelChairAccessibility,
	IsWeekends=@IsWeekends,
	IsEvenings=@IsEvenings,
	IsParking=@IsParking,
	IsHomeVisit=@IsHomeVisit,
	Email =@Email,
	IsTriage=@IsTriage
	--Status=@Status
	where 
SupplierID=@SupplierID
    END


GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierClinicalAuditBySupplierClinicalAuditID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
    
-- =============================================    
-- Latest version :1.2 
-- Author:  Vishal    
-- Create date: 12/29/2012    
-- Description: Update SupplierClinicalAudit information By SupplierClinicalAuditID    
-- Version: 1.0    
  
-- Author:  Pardeep Kumar    
-- Create date: 25-Jan-2013  
-- Description: Updated the data type of SupplierClinicalAuditStatus from String to Boolean  
-- Version: 1.1 

-- Modified by:  Pardeep Kumar    
-- Date       : 02/11/2013    
-- Description: Updated the Procedure as ReferrerID is removed from the table SupplierClinicalAudit
-- Version    : 1.2       
-- =============================================    
    
CREATE PROCEDURE [supplier].[Update_SupplierClinicalAuditBySupplierClinicalAuditID]    
 -- Add the parameters for the stored procedure here     
      
 @SupplierClinicalAuditID INT,    
 @SupplierID INT,       
 @AuditPass bit,    
 @UserID INT,    
 @AuditDate DATETIME,    
 @CaseID INT,    
 @SupplierDocumentID INT    
    
AS    
BEGIN     
     
    UPDATE supplier.SupplierClinicalAudit    
 SET       
 SupplierID =@SupplierID,    
 AuditPass =@AuditPass,    
 UserID =@UserID,    
 AuditDate = @AuditDate,    
 CaseID =@CaseID,    
 SupplierDocumentID =@SupplierDocumentID    
    
    WHERE    
  SupplierClinicalAuditID=@SupplierClinicalAuditID    
 END 

GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierComplaint]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Harpreet Singh>
-- Create date: <12-15-2012>
-- Description:	<Create the procedure to update the supplier complaint,>
-- =============================================
CREATE PROCEDURE [supplier].[Update_SupplierComplaint]

@SupplierComplaintID int,
@ComplaintTypeID int,
@ComplaintStatusID int,
@ComplaintDescription varchar(MAX),
@ComplaintDate datetime,
@SupplierID int
AS

UPDATE [supplier].[SupplierComplaints]
   SET [ComplaintTypeID] = @ComplaintTypeID
      ,[ComplaintStatusID] = @ComplaintStatusID
      ,[ComplaintDescription] = @ComplaintDescription
      ,[ComplaintDate] = @ComplaintDate
      ,[SupplierID] = @SupplierID
 WHERE SupplierComplaintID=@SupplierComplaintID


GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierDocumentNameBySupplierDocumentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Anuj Batra
-- Create date: 02/26/2013
-- Description:	to Update Supplier DocumentName By SupplierDocumentID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Update_SupplierDocumentNameBySupplierDocumentID]
	-- Add the parameters for the stored procedure here
	 	  (
	 	  @SupplierDocumentID int,
	 	  @DocumentName varchar(100)
           )
AS
BEGIN	
UPDATE [supplier].[SupplierDocuments]
	SET 
           [DocumentName]=@DocumentName    
     WHERE
           SupplierDocumentID=@SupplierDocumentID           
END




GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierDocuments]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Manjit Singh
-- Create date: 12/15/2012
-- Description:	to Update Supplier Documents
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Update_SupplierDocuments]
	-- Add the parameters for the stored procedure here
	 	  (@SupplierDocumentID int,
	 	   @DocumentTypeID int,
           @SupplierID int,
           @UserID int,
           @UploadDate datetime,
           @DocumentName varchar(100),
           @UploadPath varchar(150)
           )
AS
BEGIN	
UPDATE [supplier].[SupplierDocuments]
	SET
           [DocumentTypeID]=@DocumentTypeID
           ,[SupplierID]=@SupplierID
           ,[UserID]=@UserID
           ,[UploadDate]=@UploadDate
           ,[DocumentName]=@DocumentName
           ,[UploadPath]=@UploadPath
     WHERE
           SupplierDocumentID=@SupplierDocumentID           
END




GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierInsuranceBySupplierInsuredID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/*

Latest Version : 1.0

Author  : Pardeep Kumar
Date    : 24-Dec-2012
Version : 1.0
Purpose : Created proc to UPDATE record in table [supplier].[SupplierInsurance] by SupplierInsuredID

*/

CREATE PROCEDURE [supplier].[Update_SupplierInsuranceBySupplierInsuredID]
(
@SupplierInsuredID INT,
@LevelOfCover VARCHAR(150),
@RenewalDate DATETIME,
@SupplierDocumentID INT,
@SupplierID INT
)
as

UPDATE [supplier].[SupplierInsurance]
       SET LevelOfCover = @LevelOfCover
           ,RenewalDate=@RenewalDate
           ,SupplierDocumentID=@SupplierDocumentID
           ,SupplierID=@SupplierID
       WHERE 
           SupplierInsuredID = @SupplierInsuredID


GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierPractitionerBySupplierPractitionerID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================     
-- Latest Version: 1.0     
-- Author:  Vijay Kumar      
-- Create date: 02/01/2012      
-- Description: SP to Update the SupplierPractitioner By PractitionerID       
-- Version: 1.0      
-- =============================================     
     
CREATE PROCEDURE [supplier].[Update_SupplierPractitionerBySupplierPractitionerID]       
 -- Add the parameters for the stored procedure here
 @SupplierPractitionerID INT ,        
 @SupplierID INT,    
 @PractitionerRegistrationID   INT     
       
       
AS      
BEGIN       
    UPDATE [supplier].[SupplierPractitioners]      
 SET       
 SupplierID = @SupplierID,    
 PractitionerRegistrationID = @PractitionerRegistrationID  
         
 WHERE      
        SupplierPractitionerID=@SupplierPractitionerID               
 END

GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierSiteAuditBySupplierSiteAuditID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Vishal
-- Create date: 12/24/2012
-- Description:	Update SupplierSiteAudit information By SupplierSiteAuditID
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Update_SupplierSiteAuditBySupplierSiteAuditID]
	-- Add the parameters for the stored procedure here	
		
	@SupplierSiteAuditID INT,
	@AuditNotes VARCHAR(max),
	@AuditDate DATETIME,
	@AuditPass BIT,
	@UserID INT,
	@SupplierDocumentID INT,
	@SupplierID INT 

AS
BEGIN	
	
    UPDATE supplier.SupplierSiteAudit
	SET
	
	AuditNotes=@AuditNotes,
	AuditDate=@AuditDate,
	AuditPass=@AuditPass,
	UserID=@UserID,
	SupplierDocumentID=@SupplierDocumentID,
	SupplierID =@SupplierID
	
    WHERE
		SupplierSiteAuditID=@SupplierSiteAuditID   
 END
 

GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierStatusBySupplierID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/*
Latest Version : 1.0

Author  : Harpreet Singh
Date    : 25-April-2013
Version : 1.0
Purpose : Created the procedure Update_SupplierStatusBySupplierID

*/

CREATE PROCEDURE [supplier].[Update_SupplierStatusBySupplierID] 
(
@StatusID INT,
@SupplierID INT
)
as

UPDATE [supplier].[Suppliers] SET StatusID = @StatusID WHERE  SupplierID = @SupplierID


GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierTreatmentBySupplierTreatmentID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Satya
-- Create date: 12/18/2012
-- Description:	Update SupplierTreatment information
-- Version: 1.0
-- =============================================

CREATE PROCEDURE [supplier].[Update_SupplierTreatmentBySupplierTreatmentID] 
	-- Add the parameters for the stored procedure here
		@SupplierTreatmentID INT,
		@TreatmentCategoryID INT,
		@SupplierID INT,
		@Enabled BIT
AS
BEGIN	

    Update [supplier].[SupplierTreatments] SET 
	
	  [TreatmentCategoryID]=@TreatmentCategoryID
      ,[SupplierID]=@SupplierID
      ,[Enabled]=@Enabled

	  Where [SupplierTreatmentID] = @SupplierTreatmentID
END


GO
/****** Object:  StoredProcedure [supplier].[Update_SupplierTreatmentPricingByPricingID]    Script Date: 21-02-2020 10:30:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
-- =============================================  
-- Author:  SATYA  
-- Create date: 12/21/2012  
-- Description: to Update Supplier Documents  
-- Version: 1.0  
-- =============================================  
  
CREATE PROCEDURE [supplier].[Update_SupplierTreatmentPricingByPricingID]  
 -- Add the parameters for the stored procedure here  
     (  
    @PricingTypeID INT  
      ,@Price MONEY  
      ,@PricingID INT  
           )  
AS  
BEGIN   
UPDATE [supplier].[SupplierTreatmentPricing]  
   SET [PricingTypeID] = @PricingTypeID  
      ,[Price] = @Price   
     WHERE  
           [PricingID] = @PricingID             
END  
  
  

GO
EXEC [ITS].sys.sp_addextendedproperty @name=N'SQLSourceControl Scripts Location', @value=N'<?xml version="1.0" encoding="utf-16" standalone="yes"?>
<ISOCCompareLocation version="1" type="TfsLocation">
  <ServerUrl>http://hcrgtfs01:8080/tfs/hcrg</ServerUrl>
  <SourceControlFolder>$/Prototype/ITSDB</SourceControlFolder>
</ISOCCompareLocation>' 
GO
EXEC [ITS].sys.sp_addextendedproperty @name=N'SQLSourceControl Migration Scripts Location', @value=N'<?xml version="1.0" encoding="utf-16" standalone="yes"?>
<ISOCCompareLocation version="1" type="TfsLocation">
  <ServerUrl>http://hcrgtfs01:8080/tfs/hcrg</ServerUrl>
  <SourceControlFolder>$/Prototype/ITSDBMigrations</SourceControlFolder>
</ISOCCompareLocation>' 
GO
EXEC [ITS].sys.sp_addextendedproperty @name=N'SQLSourceControl Database Revision', @value=5100 
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[61] 4[3] 2[17] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "CaseDocuments (global)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 135
               Right = 220
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Users (global)"
            Begin Extent = 
               Top = 144
               Left = 520
               Bottom = 273
               Right = 735
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "DocumentTypes (lookup)"
            Begin Extent = 
               Top = 41
               Left = 1010
               Bottom = 136
               Right = 1213
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SupplierDocuments (supplier)"
            Begin Extent = 
               Top = 249
               Left = 1112
               Bottom = 378
               Right = 1345
            End
            DisplayFlags = 280
            TopColumn = 5
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CaseUploads'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'CaseUploads'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[56] 4[5] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cases (global)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patients (global)"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Referrers (referrer)"
            Begin Extent = 
               Top = 126
               Left = 236
               Bottom = 245
               Right = 456
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "Invoices (global)"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 199
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or =' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CaseInvoicePatientReferrer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CaseInvoicePatientReferrer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CaseInvoicePatientReferrer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[3] 2[55] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ReferrerProjectTreatments (referrer)"
            Begin Extent = 
               Top = 6
               Left = 762
               Bottom = 125
               Right = 1004
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "Cases (global)"
            Begin Extent = 
               Top = 47
               Left = 483
               Bottom = 295
               Right = 724
            End
            DisplayFlags = 280
            TopColumn = 7
         End
         Begin Table = "Patients (global)"
            Begin Extent = 
               Top = 12
               Left = 250
               Bottom = 333
               Right = 481
            End
            DisplayFlags = 280
            TopColumn = 5
         End
         Begin Table = "TreatmentCategories (lookup)"
            Begin Extent = 
               Top = 6
               Left = 1042
               Bottom = 95
               Right = 1253
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentTypes (lookup)"
            Begin Extent = 
               Top = 135
               Left = 764
               Bottom = 295
               Right = 954
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Genders (lookup)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 101
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin C' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'olumnWidths = 30
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3330
         Alias = 900
         Table = 3420
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatient'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cases (global)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Suppliers (supplier)"
            Begin Extent = 
               Top = 122
               Left = 456
               Bottom = 241
               Right = 726
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Referrers (referrer)"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 365
               Right = 258
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patients (global)"
            Begin Extent = 
               Top = 41
               Left = 731
               Bottom = 160
               Right = 891
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentTypes (lookup)"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 455
               Right = 228
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 22
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
 ' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientReferrerSupplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientReferrerSupplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientReferrerSupplier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -288
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Practitioners (global)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "PractitionerRegistrations (global)"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 233
               Right = 251
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "SupplierPractitioners (supplier)"
            Begin Extent = 
               Top = 67
               Left = 962
               Bottom = 171
               Right = 1175
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Cases (global)"
            Begin Extent = 
               Top = 342
               Left = 38
               Bottom = 461
               Right = 279
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patients (global)"
            Begin Extent = 
               Top = 19
               Left = 692
               Bottom = 138
               Right = 852
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Suppliers (supplier)"
            Begin Extent = 
               Top = 462
               Left = 38
               Bottom = 581
               Right = 248
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
    ' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientSupplierPractitioner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'  Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientSupplierPractitioner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientSupplierPractitioner'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[64] 4[3] 2[15] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "ReferrerProjectTreatments (referrer)"
            Begin Extent = 
               Top = 0
               Left = 832
               Bottom = 297
               Right = 1074
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Cases (global)"
            Begin Extent = 
               Top = 22
               Left = 0
               Bottom = 101
               Right = 245
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patients (global)"
            Begin Extent = 
               Top = 70
               Left = 539
               Bottom = 189
               Right = 699
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategories (lookup)"
            Begin Extent = 
               Top = 179
               Left = 0
               Bottom = 268
               Right = 211
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentTypes (lookup)"
            Begin Extent = 
               Top = 261
               Left = 369
               Bottom = 350
               Right = 559
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Workflows (lookup)"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 455
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReferrerProjects (referrer)"
            Begin Extent = 
               Top = 390
               Left ' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientTreatmentWorkflows'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'= 973
               Bottom = 609
               Right = 1182
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "Referrers (referrer)"
            Begin Extent = 
               Top = 358
               Left = 666
               Bottom = 477
               Right = 886
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 14
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientTreatmentWorkflows'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CasePatientTreatmentWorkflows'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[21] 4[23] 2[47] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -480
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 2025
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 1305
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CaseWorkflowCounts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'CaseWorkflowCounts'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[3] 4[3] 2[89] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -96
         Left = -2914
      End
      Begin Tables = 
         Begin Table = "ReferrerProjectTreatments (referrer)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 299
            End
            DisplayFlags = 280
            TopColumn = 2
         End
         Begin Table = "Cases (global)"
            Begin Extent = 
               Top = 138
               Left = 38
               Bottom = 268
               Right = 295
            End
            DisplayFlags = 280
            TopColumn = 23
         End
         Begin Table = "Patients (global)"
            Begin Extent = 
               Top = 270
               Left = 38
               Bottom = 400
               Right = 268
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Genders (lookup)"
            Begin Extent = 
               Top = 294
               Left = 306
               Bottom = 389
               Right = 476
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategories (lookup)"
            Begin Extent = 
               Top = 498
               Left = 38
               Bottom = 594
               Right = 262
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentTypes (lookup)"
            Begin Extent = 
               Top = 402
               Left = 246
               Bottom = 498
               Right = 448
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CaseReferrerAssignedUsers (global)"
            Begin Extent = 
               Top = 294
       ' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'ReferrerSupplierCases'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'        Left = 514
               Bottom = 407
               Right = 751
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2970
         Alias = 900
         Table = 4485
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'ReferrerSupplierCases'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'global', @level1type=N'VIEW',@level1name=N'ReferrerSupplierCases'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[13] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PractitionerRegistrations (global)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 289
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Practitioners (global)"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 230
               Right = 230
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategories (lookup)"
            Begin Extent = 
               Top = 234
               Left = 38
               Bottom = 323
               Right = 249
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "RegistrationTypes (lookup)"
            Begin Extent = 
               Top = 126
               Left = 268
               Bottom = 215
               Right = 466
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 2040
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filte' , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'PractitionerTreatmentRegistrations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'r = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'PractitionerTreatmentRegistrations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'PractitionerTreatmentRegistrations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[26] 4[6] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AreasofExpertise (lookup)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 131
               Right = 237
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategories (lookup)"
            Begin Extent = 
               Top = 6
               Left = 275
               Bottom = 141
               Right = 486
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategoryAreasofExpetises (lookup)"
            Begin Extent = 
               Top = 6
               Left = 524
               Bottom = 179
               Right = 802
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 3360
         Width = 3705
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesAreasofExpertises'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesAreasofExpertises'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -45
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TreatmentCategoryBespokeServices (lookup)"
            Begin Extent = 
               Top = 241
               Left = 270
               Bottom = 354
               Right = 634
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategories (lookup)"
            Begin Extent = 
               Top = 65
               Left = 147
               Bottom = 161
               Right = 371
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BespokeServices (lookup)"
            Begin Extent = 
               Top = 106
               Left = 831
               Bottom = 195
               Right = 1022
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 2400
         Width = 3375
         Width = 3045
         Width = 3180
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 6570
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesBespokeServices'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesBespokeServices'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[19] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "PricingTypes (lookup)"
            Begin Extent = 
               Top = 199
               Left = 722
               Bottom = 288
               Right = 893
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategoryPricingTypes (lookup)"
            Begin Extent = 
               Top = 80
               Left = 256
               Bottom = 184
               Right = 506
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategories (lookup)"
            Begin Extent = 
               Top = 19
               Left = 712
               Bottom = 108
               Right = 923
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 2250
         Width = 2205
         Width = 2010
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2025
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesPricingTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesPricingTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "RegistrationTypes (lookup)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 95
               Right = 236
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategoryRegistrationTypes (lookup)"
            Begin Extent = 
               Top = 6
               Left = 274
               Bottom = 110
               Right = 551
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentCategories (lookup)"
            Begin Extent = 
               Top = 6
               Left = 589
               Bottom = 95
               Right = 800
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesRegistrationTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesRegistrationTypes'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TreatmentCategoryTreatmentTypes (lookup)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 110
               Right = 307
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentTypes (lookup)"
            Begin Extent = 
               Top = 6
               Left = 345
               Bottom = 95
               Right = 535
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 3345
         Alias = 900
         Table = 5475
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesTreatmentTypes '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'lookup', @level1type=N'VIEW',@level1name=N'TreatmentCategoriesTreatmentTypes '
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Cases (global)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 283
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Patients (global)"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "TreatmentTypes (lookup)"
            Begin Extent = 
               Top = 126
               Left = 236
               Bottom = 215
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'referrer', @level1type=N'VIEW',@level1name=N'ReferrerAuthorisations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'referrer', @level1type=N'VIEW',@level1name=N'ReferrerAuthorisations'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "TreatmentCategoriesTreatmentTypes  (lookup)"
            Begin Extent = 
               Top = 68
               Left = 390
               Bottom = 198
               Right = 674
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ReferrerProjectTreatments (referrer)"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 299
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'referrer', @level1type=N'VIEW',@level1name=N'ReferrerProjectTreatmentTreatmentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'referrer', @level1type=N'VIEW',@level1name=N'ReferrerProjectTreatmentTreatmentType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2055
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 2145
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'supplier', @level1type=N'VIEW',@level1name=N'SupplierSearch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'supplier', @level1type=N'VIEW',@level1name=N'SupplierSearch'
GO
USE [master]
GO
ALTER DATABASE [ITS] SET  READ_WRITE 
GO
