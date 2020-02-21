/*
 Page Name:  Table.cs
 Latest Version:  1.20

 Purpose: Changed the Schema for Practitioner and Practitioner expertise table.

 Revision History:
 ======================================================================================================================
   1.0 – 10/26/2012 Satya
   1.1 – 11/07/2012 Satya
   Purpose: create treatment categories on lookup schema constants

 * Edited By :vishal Sen
 * Version : 1.2
 * Description : Create Pricing types on Look up Schema constants
 * Date : 11/07/2012
 *
   1.3 – 11/09/2012 Satya
   Purpose: create ReferrerProjects,ReferrerProjectTreatments,ReferrerProjectTreatmentPricing,ProjectTreatmentSLA on referrer and ServiceLevelAgreement on lookup schema constants
 *
 * 1.4 – 11/16/2012 Vijay Kumar
 *
 * correct  ReferrerProjectTreatmentAuthorisations,ReferrerProjectTreatmentAssessments  on referrer schema constants
 =========================================================================================================================
 Ediited By: Vishal
 Date :  11/17/2012
Description : Create a Public Struct Supplier and Add Table Supplier
 Version : 1.5

 *    1.6 – 11/07/2012 Satya
   Purpose: create InvoiceMethod on lookup schema constants
 *
 *  *    1.7– 12/06/2012 Vijay Kumar
   Purpose: 1)create DelegatedAuthorisationType on lookup schema constants.
 *          2)create DocumentSetupType on lookup schema constants.
 * ===================================================================================================================
/*
Latest Version:1.8
 *
 * Modified by: Vishal
 * Date : 12/15/2012
 * Task : #279
 * Description : Add Table For Solicitor
 * =============================================================
 * Version     : 1.9
 * Modified By : Manjit Singh
 * Date        : 12/15/2012
 * Task        : #321
 * Description : Added const For SupplierDocument
 =============================================================
 * Version     : 1.10
 * Modified By : Vishal
 * Date        : 12/15/2012
 * Task        : #340
 * Description : Added const For RegistrationType
 =============================================================
 *
 * Version     : 1.11
 * Modified By : Pardeep Kumar
 * Date        : 24-Dec-2012
 * Description : Added const For SupplierInsurance
 =============================================================
 *
 * Version     : 1.12
 * Modified By : Vishal
 * Date        : 24-Dec-2012
 * Description : Added const For SupplierSiteAudit
 =============================================================
  *
 * Version     : 1.13
 * Modified By : Vishal
 * Date        : 29-Dec-2012
 * Description : Added const For SupplierClinicalAudit
 =============================================================
 *
 * Version     : 1.14
 * Modified By : Robin Singh
 * Date        : Jan-01-2013
 * Description : Added const For TreatmentType

 =============================================================
 *
 * Version     : 1.15
 * Modified By : Vishal
 * Date        : Jan-01-2013
 * Description : Added const For AreasofExpertise
 *
 * Version     : 1.16
 * Modified By : Robin, pardeep, vijay
 * Date        : Jan-30-2013
 * Description : Added const For TreatmentCategoryRegistrationTypes and TreatmentCategoryAreasofExpetises

 * Version     : 1.17
 * Modified By : Anuj
 * Date        : Jan-31-2013
 * Description : Changed the Schema for the Practitioner and PractitionerExpertise table to Global and delete the Practitioner Schema.
 *
   Version     : 1.18
 * Modified By : Robin
 * Date        : April-30-2013
 * Description : Added const For CaseAssessmentRatings.

   Version     : 1.19
 * Modified By : Manjit Singh
 * Date        : April-30-2013
 * Description : Added const For CaseAssessment and CaseAssessmentHistory
 *
 =============================================================
 *
 * Version     : 1.20
 * Modified By : Pardeep
 * Date        : 15-June-2013
 * Description : Added const For CaseDocument
 =============================================================
*/

namespace ITS.Core.Data.SqlServer.Global
{
    public class Table
    {
        public struct global
        {
            public const string User = "Users";
            public const string Patient = "Patients";
            public const string Solicitor = "Solicitors";
            public const string Case = "Cases";
            public const string Practitioner = "Practitioners";
            public const string PractitionerExpertise = "PractitionerExpertise";
            public const string PractitionerRegistration = "PractitionerRegistrations";
            public static string CaseHistory = "CaseHistory";
            public static string CaseContact = "CaseContact";
            public static string CaseAppointmentDate = "CaseAppointmentDates";
            public const string CasePatientContactAttempt = "CasePatientContactAttempts";
            public const string CaseAssessmentRating = "CaseAssessmentRatings";
            public const string CaseAssessment = "CaseAssessments";
            public const string CaseAssessmentCustom = "CaseAssessmentCustoms";
            public const string CaseAssessmentHistory = "CaseAssessmentHistory";
            public const string CaseAssessmentPatientImpact = "CaseAssessmentPatientImpacts";
            public const string CaseAssessmentPatientImpactHistory = "CaseAssessmentPatientImpactHistory";
            public const string CaseAssessmentPatientInjuryHistory = "CaseAssessmentPatientInjuryHistory";
            public const string CaseAssessmentPatientInjury = "CaseAssessmentPatientInjuries";
            public const string CaseTreatmentPricing = "CaseTreatmentPricing";
            public const string CaseBespokeServicePricing = "CaseBespokeServicePricing";
            public const string CaseDocuments = "CaseDocuments";
            public const string CaseAssessmentDetail = "CaseAssessmentDetail";
            public const string CaseAssessmentDetailHistory = "CaseAssessmentDetailHistory";
            public const string CaseNote = "CaseNotes";
            public const string CaseCommunicationHistory = "CaseCommunicationHistory";
            public const string CaseVAT = "CaseVAT";
            public const string CaseAssessmentProposedTreatmentMethodHistory = "CaseAssessmentProposedTreatmentMethodHistory";
            public const string CaseAssessmentProposedTreatmentMethod = "CaseAssessmentProposedTreatmentMethods";
            public const string InvoiceCollectionAction = "InvoiceCollectionAction";
            public const string Invoice = "Invoices";
            public const string InvoicePayment = "InvoicePayment";
            public const string InjuredPartyRepresentative = "InjuredPartyRepresentatives";
            public const string Policie = "Policies";
            public const string Employment = "Employments";
            public const string EmployeeDetail = "EmployeeDetails";
            public const string PasswordHistory = "PasswordHistory";
            public const string DrugTest = "DrugTests";
            public const string JobDemand = "JobDemands";
            public const string CaseReferrerAssignedUser = "CaseReferrerAssignedUsers";
            public const string PolicyOpenDetail = "PolicyOpenDetails";

        }

        public struct lookup
        {
            public const string TreatmentCategory = "TreatmentCategories";
            public const string PricingTypes = "PricingTypes";
            public const string ServiceLevelAgreement = "ServiceLevelAgreements";
            public const string AssessmentService = "AssessmentServices";
            public const string AssessmentType = "AssessmentTypes";
            public const string DelegatedAuthorisation = "DelegatedAuthorisation";
            public const string TreatmentCategoryPricingType = "TreatmentCategoryPricingTypes";
            public const string InvoiceMethod = "InvoiceMethods";
            public const string EmailSendingOption = "EmailSendingOptions";
            public const string DelegatedAuthorisationType = "DelegatedAuthorisationTypes";
            public const string DocumentSetupType = "DocumentSetupTypes";
            public const string EmailType = "EmailTypes";
            public const string ComplaintStatus = "ComplaintStatus";
            public const string ComplaintType = "ComplaintTypes";
            public const string RegistrationType = "RegistrationTypes";
            public const string TreatmentType = "TreatmentTypes";
            public const string AreasofExpertise = "AreasofExpertise";
            public const string TreatmentCategoryTreatmentType = "TreatmentCategoryTreatmentTypes";
            public const string TreatmentCategoryRegistrationType = "TreatmentCategoryRegistrationTypes";
            public const string TreatmentCategoryAreasofExpetise = "TreatmentCategoryAreasofExpetises";
            public const string BankHoliday = "BankHolidays";
            public const string UKPostCode = "UKPostCodes";
            public const string PatientImpactValue = "PatientImpactValues";
            public const string PsychologicalFactor = "PsychologicalFactors";
            public const string PatientWorkstatus = "PatientWorkstatus";
            public const string PatientImpact = "PatientImpacts";
            public const string PatientImpactOnWork = "PatientImpactOnWork";
            public const string ProposedTreatmentMethod = "ProposedTreatmentMethods";
            public const string PatientLevelOfRecovery = "PatientLevelOfRecoveries";
            public const string TreatmentCategoryBespokeService = "TreatmentCategoryBespokeServices";

            public const string EmailTypeValue = "EmailTypeValues";
            public const string Duration = "Durations";
            public const string TreatmentPeriodType = "TreatmentPeriodType";
            public const string PatientRole = "PatientRoles";
            public const string CaseStopReason = "CaseStopReasons";
            public const string InjuredRepresentativeOption = "InjuredRepresentativeOptions";
            public const string AffectedArea = "AffectedAreas";
            public const string StrengthTesting = "StrengthTestings";
            public const string SymptomDescription = "SymptomDescriptions";
            public const string RestrictionRange = "RestrictionRanges";
            public const string Admitted = "Admitteds";
            public const string PolicyType = "PolicyTypes";
            public const string PolicyCriteria = "PolicyCriterias";
            public const string FitForWork = "FitForWorks";
            public const string EmploymentType = "EmploymentTypes";
            public const string TypeCover = "TypeCovers";
            public const string WorkType = "WorkTypes";
            public const string RoleType = "RoleTypes";
            public const string Reinsurer = "Reinsurers";
            public const string PrimaryCondition = "PrimaryConditions";
            public const string Gender = "Genders";
            public const string AdditionalTest = "AdditionalTests";
            public const string NetworkRailStandardApplicable = "NetworkRailStandardApplicable";
            public const string ReasonForReferral = "ReasonForReferral";
            public const string Iip = "Iips";
            public const string Tpd = "Tpds";
            public const string Gip = "Gips";
            public const string ElRehab = "ElRehabs";
           
        }

        public struct referrer
        {
            public const string Referrer = "Referrers";
            public const string ReferrerLocation = "ReferrerLocations";
            public const string ReferrerProject = "ReferrerProjects";
            public const string ReferrerProjectTreatment = "ReferrerProjectTreatments";
            public const string ReferrerProjectTreatmentPricing = "ReferrerProjectTreatmentPricing";
            public const string ProjectTreatmentSLA = "ProjectTreatmentSLAs";
            public const string ReferrerProjectTreatmentAssessment = "ReferrerProjectTreatmentAssessments";
            public const string ReferrerProjectTreatmentAuthorisation = "ReferrerProjectTreatmentAuthorisations";
            public const string ReferrerProjectTreatmentEmails = "ReferrerProjectTreatmentEmails";
            public const string ReferrerProjectTreatmentInvoice = "ReferrerProjectTreatmentInvoice";
            public const string ReferrerProjectTreatmentDocumentSetup = "ReferrerProjectTreatmentDocumentSetup";
            public const string ReferrerDocument = "ReferrerDocuments";
            public const string ReferrerCaseAssessmentModification = "ReferrerCaseAssessmentModifications";
            public const string ReferrerGroup = "ReferrerGroups";
        }

        public struct supplier
        {
            public const string Suppliers = "Suppliers";
            public const string SupplierComplaints = "SupplierComplaints";
            public const string SupplierDocument = "SupplierDocuments";
            public const string SupplierTreatment = "SupplierTreatments";
            public const string SupplierTreatmentPricing = "SupplierTreatmentPricing";
            public const string SupplierInsurance = "SupplierInsurance";
            public const string SupplierSiteAudit = "SupplierSiteAudit";
            public const string SupplierClinicalAudit = "SupplierClinicalAudit";
            public const string SupplierPractitioner = "SupplierPractitioners";
        }
    }
}