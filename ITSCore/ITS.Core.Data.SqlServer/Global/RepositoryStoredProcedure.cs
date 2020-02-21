#region Comment

/*
  Page Name      :  RepositoryStoredProcedure.cs
  Latest Version :  1.42

  Revision History:

    1.0 – 10/26/2012 Satya
 * ============================================================================================================================================================
  1.1 - 10/26/2012 Manjit Singh
  added struct ReferrerRepositoryProcedures to get referrer Detail
  ============================================================================================================================================================
  Edited By : Anuj Batra
  Date : 26-Oct-2012
  Version : 1.2
  Description : Add constant UpdateUserLock for executing sproc Update_UserLock
  ============================================================================================================================================================
  Edited By : Pardeep
  Date : 27-Oct-2012
  Version : 1.3
  Description : Add constant UserInfoByUserID for executing sproc Get_UserInfoByUserID
  ============================================================================================================================================================
  Edited By : Vishal
  Date : 27-Oct-2012
  Version : 1.4
  Description : Add constant AddReferrerInfo for Add Reffer amd Excecuting sproc Add_Referrer
  Description : Add constant UpdateReferrerInfo for Update Reffer amd Excecuting sproc Update_Referrer
  ============================================================================================================================================================
  Edited By :   Anuj Batra
  Date:         10/30/2012
  Version  :    1.5
  Description : Add constant UpdateReferrerLocationInfo for Update the ReferrerLocation by executing sproc Update_ReferrerLocationByReferrerLocationID
  ============================================================================================================================================================
  Edited By :   Robin Singh
  Date:         10/30/2012
  Version  :    1.6
  Description : Add constant DeleteReferrerLocationInfo for Delete the ReferrerLocation by executing sproc Delete_ReferrerLocationByReferrerLocationID
 ============================================================================================================================================================
 Edited By :   Vishal
 Version  :    1.7
 Description : Add constant GetLoacationById for get referrerlocations by GetReferrerLocationsByReferrerID
 ModifiedDate: 10/30/2012
 ============================================================================================================================================================
 Edited By :   Satya
 Version  :    1.8
 Description : Add constant to add referrer location constant for stor proc "AddReferrerLocation"
 ModifiedDate: 10/30/2012
 ============================================================================================================================================================
 Edited By :   Manjit Singh
 Version  :    1.9
 Description : Add constant to add user constant for stor proc "AddUser"
 ModifiedDate: 11/02/2012
 ============================================================================================================================================================
 Edited By :   Vishal
 Version  :    1.10
 Description : Add constant procedure for to get referrername for auto complete
 ModifiedDate: 11/08/2012
 ============================================================================================================================================================
 Edited By :   Vishal
 Version  :    1.11
 Description : Add constant procedure for Add_ReferrerProject
 Description : Add constant procedure for Update_ReferrerProjectByReferrerProjectID
 Description : Add constant procedure for Get_ReferrerProjectsLikeProjectName
 ModifiedDate: 11/09/2012

 ============================================================================================================================================================

 * Edited By : Vishal
 * Date : 12-Nov-2012
 * Version : 1.12
 * Description : Modify  String AutoComplete Add new parameter referrerId to it
 ==============================================================================================

 * Edited By : Vishal
 * Date : 14-Nov-2012
 * Version : 1.13
  Description : Add constant procedure for Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID()
  Description : Add constant procedure for Add_ReferrerProjectTreatmentPricing()
  Description : Add constant procedure for Update_ReferrerProjectTreatmentPricingByPricingID()
     *
 ==============================================================================================
  * Edited By : Vishal
 * Date : 14-Nov-2012
 * Version : 1.14
  Description : Add constant procedure for Get_ProjectTreatmentSLAsByProjectTreatmentSLAID
  Description : Add constant procedure for Add_ProjectTreatmentSLAs
  Description : Add constant procedure for Update_ProjectTreatmentSLAsByProjectTreatmentSLAID
     *
 ==============================================================================================
  Edited By : Vishal
 * Date : 15-Nov-2012
 * Version : 1.15
  Description : Add constant procedure for GetReferrerProjectEmailByTreatmentId
  Description : Add constant procedure for AddReferrerProjectTreatmentEmail
  Description : Add constant procedure for UpdateReferrerProjectTreatmentEmail
  Description : Add constant procedure for DeleteReferrerProjectTreatmentEmailById
     *
 ==============================================================================================
   Edited By : Vishal
 * Date : 17-Nov-2012
 * Version : 1.16
 Description : Add Public Constr SupplierRepositoryProcedure
 Description :  Add constant procedure for  Get_SupplierBySupplierID
  Description : Add constant procedure for  Get_SuppliersLikeSupplierName
  Description : Add constant procedure for  Update_SupplierBySupplierID
  Description : Add constant procedure for  Add_Supplier
     *
 ==============================================================================================

  Edited By : Vijay Kumar
 * Date : 19-Nov-2012
 * Version : 1.17
 Description : Add Public Constr ReferrerProjectTreatmentAssignment
 Description :  Add constant procedure for  AddReferrerProjectTreatmentAssignment
  Description : Add constant procedure for  UpdateReferrerProjectTreatmentAssignment
  Description : Add constant procedure for  DeleteReferrerProjectTreatmentAssignment
==============================================================================================
 *
 * Edited By : Vijay Kumar
 * Date : 19-Nov-2012
 * Version : 1.18
 Description : Add Public Constr ReferrerProjectTreatmentAuthorisation
 Description :  Add constant procedure for  AddReferrerProjectTreatmentAuthorisation
  Description : Add constant procedure for  UpdateReferrerProjectTreatmentAuthorisation
  Description : Add constant procedure for  DeleteReferrerProjectTreatmentAuthorisation
 ==============================================================================================
 *
 * Edited By : Vishal
 * Date : 21-Nov-2012
 * Version : 1.19
 Description : Modify sp Names Get_ReferrerProjectEmailByTreatmentId
 Description : Modify sp Names Add_ReferrerProjectTreatmentEmail
 Description : Modify sp Names Update_ReferrerProjectTreatmentEmail
 Description : Modify sp Names Delete_ReferrerProjectTreatmentEmailById

==============================================================================================
 *
 * Edited By : Satya
 * Date : 22-Nov-2012
 * Version : 1.20
 Description : Add CURD operation for ReferrerProjectTreatmentInvoiceRepositoryProcedure
 =============================================================
 * /*
 * Version : 1.21
 * Author : Vishal
 * Date : 12/15/2012
 * Task : #279
 * Description : Add Procedure For Solicitor
 * * Description : Add  Constant Procedure For Add Solicitor
 =============================================================
 * /*
 * Version : 1.22
 * Author : Harpreet Singh
 * Date : 12/15/2012
 * Task : #317
 * Description : Add Procedure For SupplierCompaint
 =============================================================
 * Version : 1.23
 * Author : Manjit Singh
 * Date : 12/15/2012
 * Task : #321
 * Description : Add Procedure For SupplierDocument
 =============================================================
  * Version : 1.24
 * Author : Anuj Batra
 * Date : 12/18/2012
 * Task : #327
 * Description : Add Procedure For Get_SuppliersLikePostCode
 =============================================================
 *
  Version : 1.25
 * Modified By : vishal
 * Date : 12/21/2012
 * Task : #333
 * Description : Add Procedure For Delete_SupplierComplaintBySupplierComplaintID
 =============================================================
  Version : 1.26
 * Modified By : Pardeep
 * Date : 24-Dec-2012
 * Description : Add proc Const GetSupplierInsuranceBySupplierID to GET SupplierInsurance by  SupplierID
 *             : Add proc Const UpdateSupplierInsurance to UPDATE SupplierInsurance by  SupplierInsuredID
 *             : Add proc Const AddSupplierInsurance to INSERT SupplierInsurance
 *
 =============================================================
  Version : 1.27
 * Modified By : Vishal
 * Date : 12/24/2012
 * Description : Add Public struct for SupplierSiteAuditRepositoryProcedure
 *             : Add proc Const GetSupplierSiteAuditBySupplierDocumentID,GetSupplierSiteAuditBySupplierID,GetSupplierSiteAuditByUserID,GetSupplierSiteAuditBySupplierSiteAuditID for get information.
               : Add Public struct for UpdateSupplierSiteAuditBySupplierSiteAuditID for Update by SupplierSiteAuditID
               : Add Public struct for AddSupplierSiteAudit for Add Supplier Site Audit
               : Add Public struct for DeleteSupplierSiteAuditBySupplierSiteAuditID for Delete Supplier Site Audit by SupplierSiteAuditID
  =============================================================
  Version : 1.28
 * Modified By : Vishal
 * Date : 12/29/2012
 * Description : Add Public struct for  GetSupplierClinicalAuditBySupplierID,
               :   GetSupplierClinicalAuditByUserID,
               :   UpdateSupplierClinicalAuditBySupplierClinicalAuditID ,
               :   AddSupplierClinicalAudit,
  =============================================================
 *
 *
 *
 * Revised Version : 1.29
 * Modified By : Vijay Kumar
 * Date : 01/02/2013
 * Description : Add Public struct for  SupplierPractitionersRepositoryProcedure
               : AddSupplierPractitioner
               : UpdateSupplierPractitioner
               : GetSupplierPractitionerByPractitionerID
               : GetSupplierPractitionerBySupplierID
               : DeleteSupplierPractitionerByPractitionerID
  =============================================================

 *
 *
 *
 * Revised Version : 1.30
 * Modified By : Vishal
 * Date : 01/03/2013
 * Description : Add Public struct for  PractitionerRepositoryProcedures & PractitionerExpertiseRepositoryProcedures

                :GetPractitionerExpertiseByPractitionerExpertiseID
                :GetPractitionerExpertiseByPractitionerID
                :GetPractitionerExpertiseByAreaofExpertiseID
                :DeletePractitionerExpertiseByPractitionerExpertiseID
                :UpdatePractitionerExpertiseByPractitionerExpertiseID
                :UpdatePractitionerByPractitionerID
                :GetPractitionerByPractitionerID

  =============================================================
  Version : 1.31
 * Author : Anuj Batra
 * Date : 01/31/2013
 * Description : Changed the Schema for PractitionerRepositoryProcedures & PractitionerExpertiseRepositoryProcedures
                 Changed the const in SupplierPractitionersRepositoryProcedure structure because of changes in design and name of the table.

  =============================================================
 *
 * Version : 1.32
 * Modified By : Pardeep
 * Date : 11-Feb-2013
 * Description : Updated the parameters of procedure Add_SupplierClinicalAudit as ReferrerID is removed from the table SupplierClinicalAudit
 *             : Updated the parameters of procedure Update_SupplierClinicalAuditBySupplierClinicalAuditID as ReferrerID is removed from the table SupplierClinicalAudit
 *

 =============================================================
 *
 * Version : 1.33
 * Modified By : Vijay Kumar
 * Date : 20-Feb-2013
 * Description : added the new procedure to get the practitioner's by treatment category name

  =============================================================
 *
 * Version : 1.34
 * Modified By : Manjit Singh
 * Date : 05-March-2013
 * Description : added parameter (@IsActive) in UpdateReferrerLocationInfo and AddReferrerLocation

  =============================================================
 *
 * Version : 1.35
 * Modified By : Anuj Batra
 * Date : 08-March-2013
 * Description : Updated PractitionerRepositoryProcedures structure.
  =============================================================
 * Version : 1.36
 * Modified By : Manjit Singh
 * Date : 08-March-2013
 * Description : Updated PractitionerExpertiseRepositoryProcedures structure.
 *
 * Version : 1.37
 * Modified By : Robin Singh
 * Date : 30-April-2013
 * Description : Added CaseAssessmentRatingsRepositoryProcedure structure.
 *
 * Version : 1.38
 * Modified By : Manjit Singh
 * Date : 30-April-2013
 * Description : Added CaseAssessmentRepositoryProcedure and CaseAssessmentHistoryRepositoryProcedure
 *
 *============================================================================================================================================================
  Edited By   : Pardeep
  Date        : 13-Jun-2013
  Version     : 1.39
  Description : Updated ReferrerProjectRepositoryProcedures structure to add new paramerter in Add_ReferrerProject and Update_ReferrerProjectByReferrerProjectID,
              : as new field EmailSendingOptionID is added in the table
  ============================================================================================================================================================
 *
  =============================================================
 *
 * Version     : 1.40
 * Modified By : Pardeep
 * Date        : 15-June-2013
 * Description : Added new struct CaseDocumentRepositoryProcedures
 =============================================================
 *
 ====================================================================
 *
 * Version     : 1.41
 * Modified By : Pardeep
 * Date        : 29-June-2013
 * Description : Added new struct UpdateCaseIsTreatmentRequired under CaseRepositoryProcedure
 =====================================================================
 *
  ====================================================================
 *
 * Version     : 1.42
 * Modified By : Pardeep
 * Date        : 29-June-2013
 * Description : Added new struct PractitionerSearchRepositoryProcedures
 =====================================================================
 *
 ====================================================================
 *
 * Version     : 1.43
 * Modified By : Tarun Gosain
 * Date        : 19-Jan-2015
 * Description : Added new Parameter in 'UpdateCaseAssessmentDetailByCaseAssessmentDetailID'
 =====================================================================
 */

#endregion Comment

namespace ITS.Core.Data.SqlServer.Global
{
    public class StoredProcedureConst
    {
        private const string SQLExec = "EXEC ";

        public struct CaseDocumentRepositoryProcedures
        {
            public const string AddCaseDocument = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseDocument @CaseID,@DocumentTypeID,@UploadDate,@DocumentName,@UploadPath,@UserID";
            public const string GetCaseDocumentByCaseIDAndDocumentTypeID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseDocumentByCaseIDAndDocumentTypeID @CaseID,@DocumentTypeID";
            public const string UpdateCaseDocumentByCaseIDAndDocumentTypeID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseDocumentByCaseIDAndDocumentTypeID @CaseID,@DocumentTypeID,@UploadDate,@DocumentName,@UploadPath,@UserID";
            public const string GetCaseDocumentUserByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseDocumentUserByCaseID @CaseID";
            public const string GetCaseDocumentForSupplierUserByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseDocumentForSupplierUserByCaseID @CaseID";
            public const string GetCaseDocumentForReferrerUserByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseDocumentForReferrerUserByCaseID @CaseID";
            public const string UpdateCaseAndReferrerDocumentByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAndReferrerDocumentByCaseID @CaseDocumentID,@ReferrerDocumentID,@ReferrerCheck,@SupplierCheck";
        }

        public struct CasePatientReferrerSupplierRepositoryProcedures
        {
            public const string GetCasePatientReferrerSupplierByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientReferrerSupplierByCaseID @CaseID";
        }

        public struct ReferrerAuthorisationsRepository
        {
            public const string GetReferrerAuthorisationsByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerAuthorisationsByReferrerID @ReferrerID,@UserID,@Skip,@Take";
            public const string GetReferrerAuthorisationCountByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerAuthorisationCountByReferrerID @ReferrerID,@UserID";
        }

        public struct CasePatientContactAttemptRepositoryProcedures
        {
            public const string AddPatientContactAttempt = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_PatientContactAttempt @PatientID,@CaseID,@ContactAttemptDate";
            public const string GetPatientContactAttemptsByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PatientContactAttemptsByCaseID @CaseID";
            public const string DeletePatientContactAttemptByID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CasePatientContactAttemptByID @CasePatientContactAttemptID";

        }

        public struct CaseAssessmentPatientImpactHistoryProcedures
        {
            public const string AddCaseAssessmentPatientImpactHistory = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentPatientImpactHistory @PatientImpactID,@PatientImpactValueID,@CaseAssessmentDetailHistoryID,@Comment";
        }

        public struct UserRepositoryProcedures
        {
            public const string GetByFirstName = SQLExec + "Get_UserByFirstName @FirstName";
            public const string GetByID = SQLExec + "Get_UserByID @UserID";
            public const string GetUserbyUserName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserByUsername @UserName";
            public const string UpdateUserLock = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_UserLock @UserID,@IsLocked";
            public const string GetUsersLikeUsername = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UsersLikeUsername @UserName";
            public const string UserInfoByUserID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserInfoByUserID @UserID";
            public const string AddUser = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_User @UserName, @Password, @FirstName, @LastName, @UserTypeID, @IsLocked,@SupplierTypes, @SupplierID,@ReferrerTypes, @ReferrerID, @ReferrerLocationID, @Email, @Fax, @Telephone";
            public const string UpdateUser = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_UserByUserID @UserID, @UserName, @Password, @FirstName, @LastName, @UserTypeID, @SupplierTypes,@SupplierID,@ReferrerTypes, @ReferrerID, @ReferrerLocationID, @Email, @Fax, @Telephone";
            public const string GetUserByUserTypeID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserByUserTypeID @UserTypeID";
            public const string GetReferrerUsersByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerUsersByCaseID @CaseID";

            public const string GetReferrerUsersByID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerUsersByID @ReferrerID";

            public const string GetUserEmailsByCaseContactByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserEmailsByCaseContactByCaseID @CaseID";

            public const string UpdateUserFailedAttemptCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_UserFailedAttemptCount @UserID,@NumberOfFailedLoginAttempts";
            public const string UpdateUserFailedAttemptCountAndLastLoginDate = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_UserFailedAttemptCountAndLastLoginDate @UserID, @FailedAttemptCount, @LoginDate";
            public const string GetUsersRecentlyAdded = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UsersRecentlyAdded";

            public const string GetUserTypeUsersLikeUsername = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeUsername @UserName, @Skip, @Take";
            public const string GetUserTypeUsersLikeUsernameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeUsernameCount @UserName";

            public const string GetUserTypeUsersLikeUserType = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeUserType @UserType, @Skip, @Take";
            public const string GetUserTypeUsersLikeUserTypeCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeUserTypeCount @UserType";

            public const string GetUserTypeUsersLikeName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeName @Name, @Skip, @Take";
            public const string GetUserTypeUsersLikeNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeNameCount @Name";

            public const string GetUserTypeUsersLikeReferrerName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeReferrerName @ReferrerName, @Skip, @Take";
            public const string GetUserTypeUsersLikeReferrerNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeReferrerNameCount @ReferrerName";

            public const string GetUserTypeUsersLikeSupplierName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeSupplierName @SupplierName, @Skip, @Take";
            public const string GetUserTypeUsersLikeSupplierNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserTypeUsersLikeSupplierNameCount @SupplierName";
            public const string GetUserExistsByName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserExistsByName @UserName";

            public static string ResetUserPassword = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Reset_UserPassword @UserId,@UserPasssword";
            public static string GetUserRecordByEmailID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserRecordByEmailID @EmailID";
            public static string GetUserRecordByEmailAndUserName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UserRecordByEmailAndUserName @EmailID,@Username";

            public static string GetAllSupplierUserBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_AllSupplierUserBySupplierID @SupplierID";
            public static string AddUserProject = SQLExec + Global.GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_UserProject @ReferrerProjectID, @UserID";

            public static string DeleteUserProject = SQLExec + Global.GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_UserProject @referrerProjectID, @userID";

            public static string UpdateUserSessionIDByUserID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_UserSessionIDByUserID @UserID,@UserSessionID";

            public static string ResetUserSessionID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Reset_UserSessionID @UserID";

            public static string UpdatePasswordOTPByID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_PasswordOTPByID @UserID,@PasswordOTP";
        }

        public struct PatientRepositoryProcedures
        {
            public const string AddPatient = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_Patient @Title, @FirstName, @LastName, @Address, @City, @Region, @PostCode, @InjuryDate, @BirthDate, @HomePhone, @WorkPhone, @MobilePhone, @GenderID, @Email, @HasLegalRep, @SolicitorID,@HasInjuredPartyRepresentative,@InjuredID,@PolicyID,@EmploymentID,@PrimaryConditionID,@PolicyOpenDetailID";
            public const string UpdatePatientByPatientID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_PatientByPatientID @PatientID, @Title, @FirstName, @LastName, @Address, @City, @Region, @PostCode, @InjuryDate, @BirthDate, @HomePhone, @WorkPhone, @MobilePhone, @GenderID, @Email, @HasLegalRep, @SolicitorID, @HasInjuredPartyRepresentative, @InjuredID, @SpecialInstructionNotes, @PolicyID, @EmploymentID,@PrimaryConditionID,@PolicyOpenDetailID";
            public const string GetPatientByPatientID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PatientByPatientID @PatientID";

        }

        public struct InjuredPartyRepresentativeRepository
        {
            public const string AddInjuredPartyRepresentatives = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_InjuredPartyRepresentatives @FirstName,@LastName,@ReferralID,@Tel1,@Tel2,@Address,@PostCode,@Email,@Relationship";
            public const string UpdateInjuredPartyRepresentatives = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_InjuredPartyRepresentatives @InjuredID,@FirstName,@LastName,@ReferralID,@Tel1,@Tel2,@Address,@PostCode,@Email,@Relationship";
            public const string GetInjuredPartyRepresentativesByReferralID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InjuredPartyRepresentativesByReferralID @ReferralID";
            public const string GetInjuredPartyRepresentativesByID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InjuredPartyRepresentativesByID @InjuredID";
        }

        public struct PractitionerRepositoryProcedures
        {
            public const string AddPractitioner = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_Practitioner @PractitionerFirstName,@PractitionerLastName";

            public const string GetPractitionerLikePractitionerName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerLikePractitionerName @PractitionerFirstName";
            public const string UpdatePractitionerByPractitionerID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_PractitionerByPractitionerID @PractitionerID,@PractitionerFirstName,@PractitionerLastName";
            public const string GetPractitionerByPractitionerID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerByPractitionerID @PractitionerID";
            public const string DeletePractitionerByPractitionerID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_PractitionerByPractitionerID @PractitionerID";
            public const string GetPractitionersRecentlyAdded = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionersRecentlyAdded";
        }

        public struct PractitionerExpertiseRepositoryProcedures
        {
            public const string AddPractitionerExpertise = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_PractitionerExpertise @PractitionerID, @AreaofExpertiseID";
            public const string GetPractitionerExpertiseByPractitionerExpertiseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerExpertiseByPractitionerExpertiseID @PractitionerExpertiseID";
            public const string GetPractitionerExpertiseByPractitionerID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerExpertiseByPractitionerID @PractitionerID";
            public const string GetPractitionerExpertiseByAreaofExpertiseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerExpertiseByAreaofExpertiseID @AreaofExpertiseID";
            public const string DeletePractitionerExpertiseByPractitionerExpertiseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_PractitionerExpertiseByPractitionerExpertiseID @PractitionerExpertiseID ";
            public const string DeletePractitionerExpertiseByPractitionerID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_PractitionerExpertiseByPractitionerID @PractitionerID ";
            public const string UpdatePractitionerExpertiseByPractitionerExpertiseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_PractitionerExpertiseByPractitionerExpertiseID  @PractitionerExpertiseID,@PractitionerID,@AreaofExpertiseID";
        }

        public struct ReferrerRepositoryProcedures
        {
            public const string GetReferrersRecentlyAdded = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrersRecentlyAdded";
            public const string GetReferrerInfoByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerInfoByReferrerID @ReferrerID";
            public const string AddReferrerInfo = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_Referrer @ReferrerName,@ReferrerContactFirstName,@ReferrerContactLastName,@ReferrerMainContactEmail,@ReferrerMainContactFax,@ReferrerMainContactPhone,@IsPolicyDetail,@IsEmploymentDetail,@IsEmploeeDetail,@IsDrugandAlcoholTest,@IsRepresentation,@IsAdditionalQuestion,@IsJobDemand,@IsPolicyDetailOpenOrDropdowns,@IsNewPolicyTypes";
            public const string UpdateReferrerInfo = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerInfoByReferrerID @ReferrerID,@ReferrerName,@ReferrerContactFirstName,@ReferrerContactLastName,@ReferrerMainContactEmail,@ReferrerMainContactFax,@ReferrerMainContactPhone,@IsPolicyDetail,@IsEmploymentDetail, @IsEmploeeDetail,@IsDrugandAlcoholTest,@IsRepresentation,@IsAdditionalQuestion,@IsJobDemand,@IsPolicyDetailOpenOrDropdowns,@IsNewPolicyTypes";
            public const string Get_ReferrersLikeReferrerName = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrersLikeReferrerName @ReferrerName";
            public const string GetReferrerExistsByName = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerExistsByName @ReferrerName";
            public const string GetReferrerLocationReferrerLikeReferrerNameCount = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerLocationReferrerLikeReferrerNameCount @ReferrerName";
            public const string GetReferrerLocationReferrerLikeReferrerName = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerLocationReferrerLikeReferrerName @ReferrerName ,@Skip, @Take";
            public const string GetReferrerIDbyReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerIDbyReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
            public const string GetAllReferrers = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_AllReferrers";
        }

        public struct ReferrerDocumentRepositoryProcedures
        {
            public const string GetReferrerDocumentsByReferrerIDAndDocumentTypeID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerDocumentsByReferrerIDAndDocumentTypeID @ReferrerID, @DocumentTypeID";
            public const string AddReferrerDocument = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerDocumentNew @ReferrerID, @DocumentTypeID, @UploadDate, @UserID, @UploadPath, @ReferrerDocumentTypeID, @CaseID, @DocumentDate, @DocumentName,@SupplierCheck,@ReferrerCheck";
            public const string AddReferrerDocumentCustom = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerDocument @ReferrerID, @DocumentTypeID, @UploadDate, @UserID, @UploadPath,@ReferrerProjectTreatmentID";
            public const string UpdateReferrerDocument = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerDocument @ReferrerID, @DocumentTypeID, @UploadDate, @UserID, @UploadPath,@ReferrerProjectTreatmentID";
            public const string GetReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerDocumentsByReferrerIDDocumentTypeIDAndReferrerProjectTreatmentID @ReferrerID, @DocumentTypeID,@ReferrerProjectTreatmentID";
            public const string GetReferrerDocumentsByCaseId = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerDocumentsByCaseId @CaseID, @DocumentTypeID";
            public const string GetReferrerDocumentType = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerDocumentType";
        }

        public struct ReferrerLocationRepositoryProcedures
        {
            public const string UpdateReferrerLocationInfo = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerLocationByReferrerLocationID @ReferrerLocationID,@LocationName, @LocationAddress, @LocationCity, @LocationRegion, @LocationPostCode, @IsActive";
            public const string DeleteReferrerLocationInfo = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Delete_ReferrerLocationByReferrerLocationID @ReferrerLocationID";
            public const string GetReferrerLocationsByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerLocationsByReferrerID @ReferrerID";
            public const string GetReferrerMainLocationByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerMainLocationByReferrerID @ReferrerID";
            public const string AddReferrerLocation = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerLocation @LocationName, @LocationAddress, @LocationCity, @LocationRegion, @LocationPostCode, @IsMainOffice, @ReferrerID, @IsActive";
            public const string UpdateReferrerLocationMainOffice = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerLocationMainOffice @referrerID, @referrerofficelocationid";
        }

        public struct ReferrerProjectRepositoryProcedures
        {
            public const string Add_ReferrerProject = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerProject  @ProjectName,@ReferrerID,@StatusID,@FirstAppointmentOffered,@Enabled,@IsTriage,@CentralEmail,@EmailSendingOptionID,@IsActive";
            public const string Update_ReferrerProjectByReferrerProjectID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectByReferrerProjectID  @ReferrerProjectID,@ProjectName,@ReferrerID,@StatusID,@FirstAppointmentOffered,@Enabled,@EmailSendingOptionID,@CentralEmail,@IsTriage,@IsActive";
            public const string Get_ReferrerProjectsLikeProjectName = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectsLikeProjectName  @ProjectName,@ReferrerID";
            public const string GetReferrerProjectsByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectsByReferrerID @ReferrerID";
            public const string GetReferrerAssignedUserByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerAssignedUserByReferrerID @ReferrerID";
            public const string GetReferrerCompleteProjectsByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerCompleteProjectsByReferrerID @ReferrerID";
            public const string GetReferrerProjectByProjectID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectByProjectID @ProjectID";
            public const string Update_ReferrerProjectStatusByReferrerProjectID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectStatusByReferrerProjectID @ReferrerProjectID,@StatusID";
            public const string GetReferrerProjectNotAssignedToUser = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectNotAssignedToUser @referrerID, @userID";
            public const string GetReferrerProjectAssignedToUser = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectAssignedToUser @referrerID, @userID";
        }

        public struct ReferrerProjectTreatmentRepositoryProcedures
        {
            public const string AddReferrerProjectTreatment = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerProjectTreatment  @ReferrerProjectID, @TreatmentCategoryID, @AccountReceivableChasingPoint, @AccountReceivableCollection, @Enabled";
            public const string UpdateReferrerProjectTreatment = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectTreatment @ReferrerProjectTreatmentID, @ReferrerProjectID, @TreatmentCategoryID, @AccountReceivableChasingPoint, @AccountReceivableCollection, @Enabled";
            public const string Update_ReferrerProjectTreatments = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectTreatments @ReferrerProjectTreatmentID, @ReferrerProjectID, @TreatmentCategoryID, @Enabled";
            public const string GetReferrerProjectTreatmentsByReferrerProjectID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentsByReferrerProjectID @ReferrerProjectID";
            public const string GetReferrerProjectTreatmentByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
            public const string GetReferrerIdAgtReferrerProjectTreatmentId = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerIdAgtReferrerProjectTreatmentId @referrerProjectTreatmentID";

        }

        public struct ReferrerProjectTreatmentEmailRepositoryProcedure
        {
            public const string GetReferrerProjectEmailByTreatmentId = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectEmailByTreatmentId @teamtmentId";
            public const string AddReferrerProjectTreatmentEmail = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerProjectTreatmentEmail  @ReferrerProjectTreatmentID, @EmailTypeID,@EmailTypeValueID";
            public const string UpdateReferrerProjectTreatmentEmail = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectTreatmentEmail @ReferrerProjectTreatmentEmailID , @ReferrerProjectTreatmentID ,@EmailTypeID ,@EmailTypeValueID";
            public const string DeleteReferrerProjectTreatmentEmailById = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Delete_ReferrerProjectTreatmentEmailById @treatmentEmailId";
            public const string GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
            public const string GetReferrerProjectTreatmentByTreatmentId = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentByTreatmentId @teamtmentId";
        }

        public struct ReferrerProjectTreatmentPricingRepositoryProcedure
        {
            public const string Add_ReferrerProjectTreatmentPricing = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerProjectTreatmentPricing @PricingTypeID,@Price,@ReferrerProjectTreatmentID";
            public const string Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
            public const string Update_ReferrerProjectTreatmentPricingByPricingID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectTreatmentPricingByPricingID @PricingID,@PricingTypeID,@Price,@ReferrerProjectTreatmentID";
            public const string GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndTreatmentCategoryID @ReferrerProjectTreatmentID, @TreatmentCategoryID";

            public const string GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentPricingByReferrerProjectTreatmentIDAndPricingTypeID @ReferrerProjectTreatmentID, @PricingTypeID";
        }

        public struct ProjectTreatmentSLARepositoryProcedure
        {
            public const string Get_ProjectTreatmentSLAsByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ProjectTreatmentSLAsByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
            public const string GetProjectTreatmentSLAsNameByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ProjectTreatmentSLAsNameByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
            public const string Add_ProjectTreatmentSLAs = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ProjectTreatmentSLAs @ReferrerProjectTreatmentID,@ServiceLevelAgreementID,@NumberOfDays,@Enabled";
            public const string Update_ProjectTreatmentSLAsByProjectTreatmentSLAID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ProjectTreatmentSLAsByProjectTreatmentSLAID @ProjectTreatmentSLAID,@ReferrerProjectTreatmentID,@ServiceLevelAgreementID,@NumberOfDays,@Enabled";
        }

        public struct ReferrerProjectTreatmentInvoiceRepositoryProcedure
        {
            public const string GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
            public const string AddReferrerProjectTreatmentInvoice = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerProjectTreatmentInvoice @InvoicePrice, @ManagementPrice, @ManagementFeeEnabled, @InvoiceMethodID, @ReferrerProjectTreatmentID";
            public const string UpdateReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentInvoiceID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentInvoiceID @ReferrerProjectTreatmentInvoiceID, @InvoicePrice, @ManagementPrice, @ManagementFeeEnabled, @InvoiceMethodID, @ReferrerProjectTreatmentID";
        }

        public struct ReferrerProjectTreatmentDocumentSetupRepositoryProcedure
        {
            public const string AddReferrerProjectTreatmentDocumentSetup = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerProjectTreatmentDocumentSetup @AssessmentServiceID,@DocumentSetupTypeID,@ReferrerProjectTreatmentID";
            public const string UpdateReferrerProjectTreatmentDocumentSetup = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectTreatmentDocumentSetup @ReferrerProjectTreatmentDocumentSetupID,@AssessmentServiceID,@DocumentSetupTypeID,@ReferrerProjectTreatmentID";

            public const string GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
        }

        public struct ReferrerProjectTreatmentAssessmentRepositoryProcedure
        {
            public const string AddReferrerProjectTreatmentAssignment = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerProjectTreatmentAssessment @AssessmentServiceID,@AssessmentTypeID,@ReferrerProjectTreatmentID";
            public const string UpdateReferrerProjectTreatmentAssignment = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentAssessmentID @ReferrerProjectTreatmentAssessmentID,@AssessmentServiceID,@AssessmentTypeID,@ReferrerProjectTreatmentID";
            public const string DeleteReferrerProjectTreatmentAssignment = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Delete_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentAssessmentID @ReferrerProjectTreatmentAssessmentID";
            public const string GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
        }

        public struct ReferrerProjectTreatmentAuthorisationRepositoryProcedure
        {
            public const string AddReferrerProjectTreatmentAuthorisation = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerProjectTreatmentAuthorisation @TreatmentCategoryID,@DelegatedAuthorisationTypeID,@Amount,@ReferrerProjectTreatmentID,@Enabled,@Quantity";
            public const string UpdateReferrerProjectTreatmentAuthorisation = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentAuthorisationID @ReferrerProjectTreatmentAuthorisationID,@TreatmentCategoryID,@DelegatedAuthorisationTypeID,@Amount,@ReferrerProjectTreatmentID,@Enabled,@Quantity";
            public const string DeleteReferrerProjectTreatmentAuthorisation = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Delete_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentAuthorisationID @ReferrerProjectTreatmentAuthorisationID";

            public const string GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID @ReferrerProjectTreatmentID";
        }

        public struct SupplierRepositoryProcedure
        {
            public const string Get_SupplierBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierBySupplierID @SupplierID";

            public const string Update_SupplierBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierBySupplierID @SupplierID,@SupplierName,@Address,@City,@Region,@PostCode,@Phone,@Fax,@Website,@Ranking,@Notes,@IsWheelChairAccessibility,@IsWeekends,@IsEvenings,@IsParking,@IsHomeVisit,@Email,@IsTriage";
            public const string Add_Supplier = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_Supplier @SupplierName,@Address,@City,@Region,@PostCode,@Phone,@Fax,@Website,@Ranking,@Notes,@IsWheelChairAccessibility,@IsWeekends,@IsEvenings,@IsParking,@IsHomeVisit,@Email,@IsTriage";
            public const string Update_SupplierStatusBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierStatusBySupplierID @StatusID,@SupplierID";
            public const string GetSupplierExistsByName = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierExistsByName @SupplierName";
            public const string GetSuppliersRecentlyAdded = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SuppliersRecentlyAdded";
            public const string GetAllSuppliers = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_AllSuppliers";
            public const string GetSupplierExistsByEmail = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierExistsByEmail @Email";
        }

        public struct SupplierSearchRepositoryProcedure
        {
            public const string Get_SuppliersLikeSupplierName = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SuppliersLikeSupplierName @SupplierName,@Skip,@Take";
            public const string Get_SuppliersLikePostCode = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierLikePostCode @PostCode,@Skip,@Take";
            public const string Get_SupplierLikeTreatmentCategoryType = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierLikeTreatmentCategoryType @TreatmentCategoryType, @Skip,@Take";
            public const string GetSuppliersLikePostCodeCount = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierLikePostCodeCount @PostCode";
            public const string GetSuppliersLikeSupplierNameCount = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SuppliersLikeSupplierNameCount @SupplierName";
            public const string GetSupplierLikeTreatmentCategoryTypeCount = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierLikeTreatmentCategoryTypeCount @TreatmentCategoryType";
        }

        public struct SolicitorRepositoryProcedure
        {
            public const string Add_Solicitor = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_Solicitor  @CompanyName,@Address,@Phone,@Email,@FirstName,@LastName,@PostCode,@Fax,@ReferenceNumber,@City,@Region,@IsReferralUnderJointInstruction";
            public const string UpdateSolicitorBySolicitorID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_SolicitorBySolicitorID @SolicitorID,@CompanyName,@Address,@Phone,@Email,@FirstName,@LastName,@PostCode,@Fax,@ReferenceNumber,@City,@Region,@IsReferralUnderJointInstruction";
            public const string GetSolicitorBySolicitorID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_SolicitorBySolicitorID @SolicitorID";
            public const string GetSolicitorByPatientID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_SolicitorByPatientID @PatientID";



        }

        public struct SupplierComplaintRepositoryProcedure
        {
            public const string Add_SupplierComplaint = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierComplaint  @ComplaintTypeID, @ComplaintStatusID,@ComplaintDescription ,  @ComplaintDate, @SupplierID";
            public const string Update_SupplierComplaint = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierComplaint  @SupplierComplaintID,@ComplaintTypeID, @ComplaintStatusID,@ComplaintDescription ,  @ComplaintDate, @SupplierID";
            public const string Get_SupplierComplaintBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierComplaintBySupplierID  @SupplierID";
            public const string Get_SupplierComplaintAndStatusAndTypesBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierComplaintAndStatusAndTypesBySupplierID  @SupplierID";
            public const string Delete_SupplierComplaintBySupplierComplaintID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Delete_SupplierComplaintBySupplierComplaintID  @SupplierComplaintID";
        }

        public struct SupplierDocumentRepositoryProcedure
        {
            public const string AddSupplierDocument = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierDocuments @DocumentTypeID,@SupplierID,@UserID,@UploadDate, @DocumentName, @UploadPath";
            public const string UpdateSupplierDocument = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierDocuments @SupplierDocumentID,@DocumentTypeID,@SupplierID,@UserID,@UploadDate, @DocumentName, @UploadPath";
            public const string GetSupplierDocumentBySupplierIDAndDocumentTypeID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierDocumentBySupplierIDAndDocumentTypeID @DocumentTypeID,@SupplierID";
            public const string DeleteSupplierDocumentBySupplierDocumentID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Delete_SupplierDocumentBySupplierDocumentID @SupplierDocumentID";
            public const string UpdateSupplierDocumentNameBySupplierDocumentID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierDocumentNameBySupplierDocumentID @SupplierDocumentID,@DocumentName";
            public const string AddSupplierDocumentCustom = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierDocumentCustom @DocumentTypeID,@SupplierID,@UserID,@UploadDate, @DocumentName, @UploadPath,@ReferrerProjectTreatmentID,@CaseId";
            public const string GetSupplierDocumentByCaseIdAndDocumentTypeId = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierDocumentByCaseIdAndDocumentTypeId @CaseId,@DocumentTypeID";
            public const string GetSupplierDocumentByCaseId = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierDocumentByCaseId @CaseId";
        }

        public struct CaseRepositoryProcedure
        {
            public const string Add_Case = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_Case @PatientID, @ReferrerID,@ReferrerProjectID, @ReferrerProjectTreatmentID , @TreatmentTypeID , @CaseReferrerReferenceNumber, @CaseSpecialInstruction , @CaseReferrerDueDate, @WorkflowID, @IsTriage, @InjuryType, @SendInvoiceTo, @SendInvoiceName, @SendInvoiceEmail,@ReferrerAssignedUser, @SupplierAssignedUser, @InnovateNote,@OfficeLocationID,@EmployeeDetailID, @DrugTestID,@JobDemandID,@IsNewPolicyTypeID,@NewPolicyReferenceNumber";
            public const string GetReferralDetailByCaseId = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferralDetailByCaseId @CaseId";
            public const string Update_CaseByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseByCaseID @CaseID, @PatientID, @ReferrerID, @ReferrerProjectID, @ReferrerProjectTreatmentID , @TreatmentTypeID , @CaseReferrerReferenceNumber, @CaseSpecialInstruction , @CaseReferrerDueDate, @WorkflowID, @IsTriage, @InjuryType, @SendInvoiceTo, @SendInvoiceName, @SendInvoiceEmail,@ReferrerAssignedUser, @SupplierAssignedUser, @InnovateNote,@OfficeLocationID,@EmployeeDetailID, @DrugTestID,@JobDemandID,@IsNewPolicyTypeID,@NewPolicyReferenceNumber";
            public const string Delete_CaseByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CaseByCaseID @CaseID";
            public const string Get_CaseByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseByCaseID @CaseID";
            public const string Get_CaseByPatientID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseByPatientID @PatientID";
            public const string Get_CaseByLikeCaseNumber = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseByLikeCaseNumber @CaseNumber";
            public const string UpdateCaseWorkflowByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseWorkflowByCaseID @CaseID, @WorkflowID";
            public const string UpdateCaseWorkflowCustomByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseWorkflowCustomByCaseID @CaseID,@UserID, @WorkflowID";
            public const string UpdateCaseWorkflowByCaseIDStoppedCase = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseWorkflowByCaseID_StoppedCase @CaseID";
            public const string GetReferrerCasesByWorkflowID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerCasesByWorkflowID @WorkflowID,@ReferrerID";
            public const string GetCasesByWorkFlowID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasesByWorkFlowID @WorkflowID";
            public const string UpdateCaseSupplier = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseSupplier @CaseID, @SupplierID";
            public const string GetSupplierCasesAndPatientByWorkflowID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierCasesAndPatientByWorkflowID @SupplierID,@WorkflowID";
            public const string GetCaseAssessmentCustomsByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentCustomsByCaseID @CaseID";
            public const string UpdateCasePatientContactDateByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CasePatientContactDateByCaseID @CaseID,@PatientContactDate,@SupplierAssignedUser, @InnovateNote";
            public const string UpdateCaseIsTreatmentRequired = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseIsTreatmentRequired @IsTreatmentRequired,@CaseID";
            public const string UpdateCaseInvoiceDate = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseInvoiceDateByCaseID @InvoiceDate, @CaseID";
            public const string GetReferrerProjectTreatmentDocumentSetup = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentDocumentSetup @CaseID,@AssessmentServiceID";
            public const string GetIntialAssessmentReportDetailsByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_IntialAssessmentReportDetailsByCaseID @CaseID";
            public const string GetEvaluateDelegatedAuthorisationCost = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_EvaluateDelegatedAuthorisationCost @CaseID,@AssessmentTypeID";
            public const string GetInitialReviewAssessmentByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InitialReviewAssessmentByCaseID @CaseID";
            public const string GetFinalUploadByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_FinalUploadByCaseID @CaseID, @DocumentTypeID";
            public const string GetUnsuccessfulContactDate = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_UnsuccessfulContactDate @CaseID";
            public const string GetPatientContactDate = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PatientContactDate @CaseID";
            public const string GetCaseReferrerAssignedUsersByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseReferrerAssignedUsersByCaseID @CaseID";
            public const string AddCaseReferrerAssignedUser = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseReferrerAssignedUser @UserID, @CaseID";
            public const string DeleteCaseReferrerAssignedUserByID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CaseReferrerAssignedUserByID @CaseReferrerAssignedUserID";
        }

        public struct CasePatientSupplierPractitionerRepositoryProcedure
        {
            public const string GetCasePatientSupplierPractitionerByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientSupplierPractitionerByCaseID @CaseID";
        }

        public struct CaseWorkflowPatientReferrerPrrojectProcedure
        {
            public const string GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID @WorkflowID, @TreatmentCategoryID, @Skip, @Take";

            public const string GetCaseWorkflowPatientReferrerProjectByWorkflowID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseWorkflowPatientReferrerProjectsByWorkflowID @WorkflowID, @Skip, @Take";

            public const string GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryID @TreatmentCategoryID, @Skip, @Take";
            public const string GetCaseReferralWorkflowPatientReferrerProjects = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseReferralWorkflowPatientReferrerProjects @Skip, @Take";

            public const string GetCaseReferralWorkflowPatientReferrerProjectsCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseReferralWorkflowPatientReferrerProjectsCount";
            public const string GetCaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseReferralWorkflowPatientReferrerProjectsByTreatmentCategoryIDCounts @TreatmentCategoryID";

            public const string GetCaseWorkflowPatientReferrerProjectsByWorkflowIDCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseWorkflowPatientReferrerProjectsByWorkflowIDCounts @WorkflowID";
            public const string GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryIDCounts @WorkflowID,@TreatmentCategoryID";
        }

        public struct CaseHistoryRepositoryProcedure
        {
            public static string Add_CaseHistory = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseHistory @CaseID, @EventDate, @UserID, @EventDescription, @EventTypeID ";

            public static string Update_CaseHistory = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseHistory @CaseID, @EventDate, @UserID, @EventDescription, @EventTypeID, @CaseHistoryID";

            public static string Get_CaseHistories = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseHistories";

            public static string GetCaseHistoriesByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseHistoriesByCaseID @CaseID";
        }

        public struct SupplierTreatmentRepositoryProcedure
        {
            public const string GetSupplierTreatmentBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierTreatmentBySupplierID @SupplierId";
            public const string GetSupplierPriceAverage = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierPriceAverage @SupplierId,@TreatmentCategoryID";

            public const string AddSupplierTreatment = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierTreatment @TreatmentCategoryID, @SupplierID, @Enabled";
            public const string UpdateSupplierTreatmentBySupplierTreatmentID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierTreatmentBySupplierTreatmentID @SupplierTreatmentID, @TreatmentCategoryID, @SupplierID, @Enabled";
            public const string GetSupplierTreatmentExistsBySupplierIDAndTreatmentCategoryID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierTreatmentExistsBySupplierIDAndTreatmentCategoryID @SupplierId,@TreatmentCategoryID";
        }

        public struct SupplierTreatmentPricingRepositoryProcedure
        {
            public const string GetSupplierTreatmentPricingBySupplierTreatmentId = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierTreatmentPricingBySupplierTreatmentId @SupplierTreatmentID";
            public const string AddSupplierTreatmentPricing = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierTreatmentPricing @PricingTypeID, @Price, @SupplierTreatmentId";
            public const string UpdateSupplierTreatmentPricingByPricingID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierTreatmentPricingByPricingID @PricingTypeID, @Price, @PricingID";
            public const string GetTriageSuppliersTreamentPricingByTreatmentCategoryID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_TriageSuppliersTreamentPricingByTreatmentCategoryID @TreatmentCategoryID";
            public const string GetSuppliersTreamentPricingByTreatmentCategoryID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SuppliersTreamentPricingByTreatmentCategoryID @TreatmentCategoryID";
            public const string GetTriageTopSuppliersTreamentPricingByTreatmentCategoryID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_TriageTopSuppliersTreamentPricingByTreatmentCategoryID @TreatmentCategoryID";
            public const string GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierTreatmentPricingByTreatmentCategoryIDAndSupplierID @TreatmentCategoryID, @SupplierID";
            public const string GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID @SupplierTreatmentID,@TreatmentCategoryID";
            public const string GetSupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierTreatmentPricingByTreatmentCategoryIDAndSupplierIDAndPricingTypeID @SupplierID,@TreatmentCategoryID,@PricingTypeID";
        }

        public struct SupplierInsuranceRepositoryProcedure
        {
            public const string GetSupplierInsuranceBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierInsuranceBySupplierID @SupplierID";
            public const string UpdateSupplierInsurance = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierInsuranceBySupplierInsuredID @SupplierInsuredID,@LevelOfCover,@RenewalDate,@SupplierDocumentID,@SupplierID";
            public const string AddSupplierInsurance = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierInsurance @LevelOfCover,@RenewalDate,@SupplierDocumentID,@SupplierID";
            public const string DeleteSupplierInsuranceBySupplierInsuredID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Delete_SupplierInsuranceBySupplierInsuredID @SupplierInsuredID";
        }

        public struct SupplierSiteAuditRepositoryProcedure
        {
            public const string GetSupplierSiteAuditBySupplierDocumentID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierSiteAuditBySupplierDocumentID @SupplierDocumentID";
            public const string GetSupplierSiteAuditBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierSiteAuditBySupplierID @SupplierID";
            public const string GetSupplierSiteAuditByUserID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierSiteAuditByUserID @UserID";
            public const string GetSupplierSiteAuditBySupplierSiteAuditID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierSiteAuditBySupplierSiteAuditID @SupplierSiteAuditID";
            public const string UpdateSupplierSiteAuditBySupplierSiteAuditID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierSiteAuditBySupplierSiteAuditID @SupplierSiteAuditID,@AuditNotes,@AuditDate,@AuditPass,@UserID,@SupplierDocumentID,@SupplierID";
            public const string AddSupplierSiteAudit = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierSiteAudit @AuditNotes,@AuditDate,@AuditPass,@UserID,@SupplierDocumentID,@SupplierID";
            public const string DeleteSupplierSiteAuditBySupplierSiteAuditID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Delete_SupplierSiteAuditBySupplierSiteAuditID @SupplierSiteAuditID";
        }

        public struct SupplierClinicalAuditRepositoryProcedure
        {
            public const string GetSupplierClinicalAuditBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierClinicalAuditBySupplierID @SupplierID";
            public const string GetSupplierClinicalAuditByUserID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierClinicalAuditByUserID @UserID";
            public const string UpdateSupplierClinicalAuditBySupplierClinicalAuditID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierClinicalAuditBySupplierClinicalAuditID  @SupplierClinicalAuditID,@SupplierID,@AuditPass,@UserID,@AuditDate,@CaseID,@SupplierDocumentID";
            public const string AddSupplierClinicalAudit = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierClinicalAudit @SupplierID,@AuditPass,@UserID,@AuditDate,@CaseID,@SupplierDocumentID";
            public const string DeleteSupplierClinicalAuditBySupplierClinicalAuditID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Delete_SupplierClinicalAuditBySupplierClinicalAuditID @SupplierClinicalAuditID";
            public const string GetSupplierClinicalAuditBySupplierClinicalAuditID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierClinicalAuditBySupplierClinicalAuditID @SupplierClinicalAuditID";
        }

        public struct SupplierPractitionersRepositoryProcedure
        {
            public const string GetSupplierPractitionerBySupplierPractitionerID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierPractitionerBySupplierPractitionerID @SupplierPractitionerID";
            public const string GetSupplierPractitionerByPractitionerRegistrationID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierPractitionerByPractitionerRegistrationID @PractitionerRegistrationID";
            public const string AddSupplierPractitionerRegistration = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Add_SupplierPractitionerRegistration @SupplierID,@PractitionerRegistrationID";
            public const string UpdateSupplierPractitionerBySupplierPractitionerID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Update_SupplierPractitionerBySupplierPractitionerID @SupplierPractitionerID, @SupplierID, @PractitionerRegistrationID";

            public const string DeleteSupplierPractitionerBySupplierPractitionerID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Delete_SupplierPractitionerBySupplierPractitionerID @SupplierPractitionerID";
            public const string GetSupplierPractitionerSupplierByPractitionerID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierPractitionerSupplierByPractitionerID @PractitionerID";
            public const string GetSupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID @SupplierID, @PractitionerRegistrationID";
        }

        public struct PractitionerTreatmentRegistrationRepositoryProcedure
        {
            public const string GetPractitionerTreatmentRegistrationsLikePractitionerNameForSupplier = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_PractitionerTreatmentRegistrationsLikePractitionerNameForSupplier @PractitionerName";

            public const string GettSupplierPractitionerTreatmenRegistrationsBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierPractitionerTreatmentRegistrationsBySupplierID @SupplierID";

            public const string GetPractitionerTreatmentRegistrationsLikePractitionerNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerTreatmentRegistrationsLikePractitionerNameCount @PractitionerName";
            public const string GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount @TreatmentCategoryName";

            public const string GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerTreatmentRegistrationsLikeTreatmentCategoryName @TreatmentCategoryName,@Skip,@Take";
            public const string GetPractitionerTreatmentRegistrationsLikePractitionerName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerTreatmentRegistrationsLikePractitionerName @PractitionerName,@Skip,@Take";
        }

        public struct PractitionerRegistrationRepositoryProcedures
        {
            public const string AddPractitionerRegistration = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_PractitionerRegistration @PractitionerID,@TreatmentCategoryID,@RegistrationTypeID,@RegistrationNumber,@Qualification,@QualificationDate,@ExpiryDate,@YearsQualified";

            public const string DeletePractitionerRegistrationByPractitionerRegistrationID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_PractitionerRegistrationByPractitionerRegistrationID @PractitionerRegistrationID";

            public const string GetPractitionerRegistrationByPractitionerRegistrationID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerRegistrationByPractitionerRegistrationID @PractitionerRegistrationID";

            public const string GetPractitionerRegistrationsByPractitionerID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerRegistrationsByPractitionerID @PractitionerID";

            public const string GetPractitionerRegistrationsByTreatmentCategoryID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerRegistrationsByTreatmentCategoryID @TreatmentCategoryID";

            public const string UpdatePractitionerRegistrationByPractitionerRegistrationID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_PractitionerRegistrationByPractitionerRegistrationID @PractitionerID,@TreatmentCategoryID,@RegistrationTypeID,@RegistrationNumber,@Qualification,@QualificationDate,@ExpiryDate,@YearsQualified,@PractitionerRegistrationID";

            public const string GetPractitionerRegistrationsByRegistrationTypeID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerRegistrationsByRegistrationTypeID @RegistrationTypeID";

            public const string GetPractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PractitionerRegistrationExistsByPractitionerTreatmentCategoryIDAndRegistrationTypeID @PractitionerID,@TreatmentCategoryID,@RegistrationTypeID";
        }

        public struct ReferrerProjectTreatmentNameRepositoryProcedure
        {
            public const string GetReferrerProjectTreatmentNamesByReferrerProjectID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentNamesByReferrerProjectID @ReferrerProjectID";
            public const string GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerEnabledProjectTreatmentNamesByReferrerProjectID @ReferrerProjectID";
        }

        public struct CaseContactRepositoryProcedures
        {
            public const string AddCaseContact =
                SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseContact @CaseID,@UserID";

            public const string GetCaseContactsByCaseID =
                SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseContactsByCaseID @CaseID";
            public const string UpdateCaseContactByCaseID =
                SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseContact @CaseID,@UserID";
            public const string DeleteCaseContactByID =
                SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CaseContactByID  @CaseContactID";

        }

        public struct CaseCountRepositoryProcedures
        {
            public const string GetCaseCounts =
                SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseCounts";

            public const string GetCaseCountByTreatmentCategoryID =
             SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseCountByTreatmentCategoryID @TreatmentCategoryID";
        }

        public struct CaseAppointmentDateRepositoryProcedures
        {
            public const string AddCaseAppointmentDate =
                SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAppointmentDate @CaseID,@AppointmentDateTime,@FirstAppointmentOfferedDate";

            public const string UpdateCaseAppointmentDate =
                SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAppointmentDate @CaseID,@AppointmentDateTime,@FirstAppointmentOfferedDate";

            public const string GetCaseAppointmentDateByCaseID =
                SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAppointmentDateByCaseID @CaseID";
        }

        public struct SiteAuditTotalCountAndAuditPassRepositoryProcedure
        {
            public const string GetSiteAuditTotalCountAndAuditPassBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SiteAuditTotalCountAndAuditPassBySupplierID @SupplierID";
        }

        public struct ClinicalAuditTotalCountAndPassAuditRepositoryProcedure
        {
            public const string GetClinicalAuditTotalCountAndPassAuditsBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_ClinicalAuditTotalCountAndPassAuditsBySupplierID @SupplierID";
        }

        public struct AssessmentRatingTotalCountAndRatingRepositoryProcedure
        {
            public const string GetAssessmentRatingTotalCountAndRatingBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_AssessmentRatingTotalCountAndRatingBySupplierID @SupplierID";
        }

        public struct SupplierDistanceRankingRepositoryProcedure
        {
            public const string GetSuppliersWithinArea = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SuppliersWithinArea @RadiansLatitude, @RadiansLongitude, @DistanceKM, @TreatmentCategoryID";
            public const string GetSupplierWithinAreaBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierWithinAreaBySupplierID @RadiansLatitude, @RadiansLongitude, @DistanceKM, @TreatmentCategoryID,@SupplierID";

            public const string GetAllSupplierWithinArea = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_AllSupplierWithinArea @RadiansLatitude, @RadiansLongitude, @DistanceKM, @TreatmentCategoryID";

            public const string GetSupplierSupplierTreatmentsAndSupplierTreatmenPricingWithinArea = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierSupplierTreatmentsAndSupplierTreatmenPricingWithinArea @RadiansLatitude, @RadiansLongitude, @DistanceKM, @TreatmentCategoryID";

        }

        public struct ReferrerProjectTreatmentTreatmentTypeRepositoryProcedures
        {
            public const string GetReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID @ReferrerProjectTreatmentTypeID";
        }

        public struct CaseAssessmentPatientInjuryRepositoryProcedures
        {
            public const string AddCaseAssessmentPatientInjury = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentPatientInjury @CaseAssessmentDetailID,@AffectedArea,@Score,@Restriction,@SymptomDescriptionID,@StrengthTestingID,@AffectedAreaID,@RestrictionRangeID,@OtherSymptomDesciption";
            public const string UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID @CaseAssessmentPatientInjuryID, @CaseAssessmentDetailID,@AffectedArea,@Score,@Restriction,@SymptomDescriptionID,@StrengthTestingID,@AffectedAreaID,@RestrictionRangeID,@OtherSymptomDesciption";
            public const string GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentPatientInjuriesByCaseAssessmentDetailID @CaseAssessmentDetailID";
            public const string GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailIDReports = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentPatientInjuriesByCaseAssessmentDetailID @CaseAssessmentDetailID";
            public const string DeleteCaseAssessmentPatientInjuryByCaseAssessmentDetailID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CaseAssessmentPatientInjuryByCaseAssessmentDetailID @CaseAssessmentDetailID";
        }

        public struct CaseAssessmentRatingsRepositoryProcedures
        {
            public const string GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentRatingByCaseIDAndAssessmentServiceID @CaseID , @AssessmentServiceID";
            public const string AddCaseAssessmentRating = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentRating @CaseID,@AssessmentServiceID,@Rating,@RatingDate";
            public const string UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentRatingByCaseIDAndAssessmentServiceID @CaseID, @AssessmentServiceID, @Rating";
        }

        public struct CaseAssessmentRepositoryProcedure
        {
            public const string AddCaseAssessment = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessment @CaseID  ,@AssessmentServiceID  ,@HasPatientConsentForm  ,@IncidentAndDiagnosisDescription,@NeuralSymptomDescription  ,@PreExistingConditionDescription  ,@IsPatientUndergoingTreatment  ,@IsPatientTakingMedication  ,@PatientRequiresFurtherInvestigation  ,@FactorsAffectingTreatmentDescription ,@PatientOccupation ,@PatientRoleID  ,@WasPatientWorkingAtTheTimeOfTheAccident  ,@IsPatientSufferingFinancialLoss  ,@AnticipatedDateOfDischarge  ,@HasPatientHomeExerciseProgramme  ,@HasPatientPastSymptoms  ,@AssessmentAuthorisationID  ,@AuthorisationDetail  ,@IsAccepted  ,@IsPatientDischarge  ,@DeniedMessage  ,@HasYellowFlags  ,@HasRedFlags  ,@UserID, @IsSaved,@RelevantTestUndertaken";

            public const string UpdateCaseAssessmentAuthorisationByCasetID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentAuthorisationByCaseID @CaseID, @AssessmentAuthorisationID, @AuthorisationDetail";
            public const string UpdateCaseAssessmentDeniedAuthorisationByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentDeniedAuthorisationByCaseID @CaseID, @AssessmentAuthorisationID, @DeniedAuthorisation";

            public const string GetCaseAssessmentByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentByCaseID @CaseID";
            public const string GetCaseAssessmentAndValuesByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentAndValuesByCaseID @CaseID";


            public const string UpdateCaseAssessmentByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + @"Update_CaseAssessmentByCaseID @CaseID,@AssessmentServiceID,@HasPatientConsentForm,@IncidentAndDiagnosisDescription,@NeuralSymptomDescription,@PreExistingConditionDescription,@IsPatientUndergoingTreatment,@IsPatientTakingMedication,@PatientRequiresFurtherInvestigation,@FactorsAffectingTreatmentDescription,@PatientOccupation,@PatientRoleID,@WasPatientWorkingAtTheTimeOfTheAccident,@IsPatientSufferingFinancialLoss,@AnticipatedDateOfDischarge,@HasPatientHomeExerciseProgramme,@HasPatientPastSymptoms,@AssessmentAuthorisationID,@AuthorisationDetail,@IsAccepted,@IsPatientDischarge,@DeniedMessage,@HasYellowFlags,@HasRedFlags,@UserID, @IsSaved, @RelevantTestUndertaken";


            public const string UpdateCaseAssessmentHasPatientConsentFormByCaseId = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + @"Update_CaseAssessment_HasPatientConsentForm_ByCaseID @CaseID,@HasPatientConsentForm ";
            //
            public const string UpdateAssessmentServiceIDByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_AssessmentServiceIDByCaseID @CaseID,@AssessmentServiceID";
            public const string UpdateIsPatientDischargeByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_IsPatientDischargeByCaseID @CaseID,@IsPatientDischarge";
            public const string GetCaseAssessmentExistsByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentExistsByCaseID @CaseID";
            public const string UpdateCaseAssessmentIsSavedByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentISavedByCaseID @CaseID";
        }

        public struct CaseAssessmentCustomRepositoryProcedure
        {
            public const string AddCaseAssessmentCustom = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentCustom @CaseID,@Message,@IsFurtherTreatment,@isAccepted";
            public const string GetCaseAssessmentCustom = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentCustom @CaseID";
            public const string UpdateCaseAssessmentCustom = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentCustom @CaseID,@IsFurtherTreatment";
            public const string UpdateCaseRiewAssessmentMessageCustom = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseRiewAssessmentMessageCustom @CaseID,@ReviewAssessmentMessage";
            public const string UpdateCaseInitialAssessmentMessageCustom = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseInitialAssessmentMessageCustom @CaseID,@Message";
            public const string UpdateCaseFinalAssessmentMessageCustom = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseFinalAssessmentMessageCustom @CaseID,@FinalAssessmentMessage";

        }
        public struct CaseAssessmentHistoryRepositoryProcedure
        {
            public const string AddCaseAssessmentHistory = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentHistory   @CaseID ,@AssessmentServiceID  ,@HasPatientConsentForm  ,@IncidentAndDiagnosisDescription  ,@NeuralSymptomDescription  ,@PreExistingConditionDescription  ,@IsPatientUndergoingTreatment  ,@IsPatientTakingMedication  ,@PatientRequiresFurtherInvestigation  ,@FactorsAffectingTreatmentDescription  ,@PatientOccupation  ,@WasPatientWorkingAtTheTimeOfTheAccident  ,@IsPatientSufferingFinancialLoss  ,@AnticipatedDateOfDischarge  ,@HasPatientHomeExerciseProgramme  ,@HasPatientPastSymptoms  ,@AssessmentAuthorisationID  ,@AuthorisationDetail  ,@IsAccepted  ,@IsPatientDischarge  ,@DeniedMessage  ,@UserID  ,@HasYellowFlags  ,@HasRedFlags  ,@PatientRoleID,@RelevantTestUndertaken";
        }

        public struct CasePatientRepositoryProcedure
        {
            public const string GetCasePatientByCaseIDAndWorkflowID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientByCaseIDAndWorkflowID @CaseID,@WorkflowID";
            public const string GetPatientAndCaseByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PatientAndCaseByCaseID @CaseID";
            public const string GetCaseSearchLikePatientName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseSearchLikePatientName @PatientName";
            public const string GetCaseSearchLikeReferrerReferenceNumber = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseSearchLikeReferrerReferenceNumber @ReferrerReferenceNumber";
            public const string GetCasePatientLikeCaseNumber = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientLikeCaseNumber @CaseNumber";
            public const string GetCasePatientReferrerByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientReferrerByCaseID @CaseID";

            public const string GetPatientAndCaseByCaseIDReports = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PatientAndCaseByCaseID @CaseID";
            //CaseSearch

            public const string GetReferrerSupplierCaseLikePatientNameAndReferrerID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerSupplierCaseLikePatientNameAndReferrerID @AdditionalParam,@PatientName,@ReferrerID,@UserID,@Skip,@Take";
            public const string GetReferrerSupplierCaseLikePatientNameAndSupplierID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerSupplierCaseLikePatientNameAndSupplierID @PatientName,@SupplierID,@UserID,@Skip,@Take";
            public const string GetReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerSupplierCaseLikePatientNameAndSupplierIDNumberCount @PatientName,@SupplierID,@UserID";
            public const string GetReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerSupplierCaseLikePatientNameAndReferrerIDNumberCount @AdditionalParam, @PatientName,@ReferrerID,@UserID";
            public const string GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerID @AdditionalParam, @ReferrerReferenceNumber,@ReferrerID,@UserID,@Skip,@Take";
            public const string GetReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerSupplierCaseLikeReferrerReferenceNumberAndReferrerIDNumberCount @AdditionalParam,@ReferrerReferenceNumber,@ReferrerID,@UserID";
            public const string GetReferrerSupplierCaseLikeCaseNumberAndSupplierID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerSupplierCaseLikeCaseNumberAndSupplierID @CaseNumber,@SupplierID,@UserID,@Skip,@Take";
            public const string GetReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerSupplierCaseLikeCaseNumberAndSupplierIDNumberCount @CaseNumber,@SupplierID,@UserID";
        }

        public struct CaseReferrerRepositoryProcedure
        {
            public const string GetCaseReferrerProjectByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseReferrerProjectByCaseID @CaseID";
        }

        public struct CaseAssessmentPatientImpactRepositoryProcedure
        {
            public const string AddCaseAssessmentPatientImpact = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentPatientImpact @PatientImpactID,@PatientImpactValueID,@Comment,@CaseAssessmentDetailID";
            public const string UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentPatientImpactByCaseAssessmentPatientImpactID @CaseAssessmentPatientImpactID,@PatientImpactID,@PatientImpactValueID,@Comment,@CaseAssessmentDetailID";
            public const string GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentPatientImpactsByCaseAssessmentDetailID @CaseAssessmentDetailID";
            public const string GetCaseAssessmentPatientImpactsByPatientImpactID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentPatientImpactsByPatientImpactID @PatientImpactID";
            public const string GetCaseAssessmentPatientImpactsByPatientImpactValueID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentPatientImpactsByPatientImpactValueID @PatientImpactValueID";
            public const string GetCaseAssessmentPatientImpactsAndValuesByCaseAssessmentDetailID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentPatientImpactsAndValuesByCaseAssessmentDetailID @CaseAssessmentDetailID";
        }

        public struct CaseAssessmentPatientInjuryHistoryRepositoryProcedure
        {
            public const string AddCaseAssessmentPatientInjuryHistory = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentPatientInjuryHistory @CaseAssessmentDetailHistoryID,@AffectedArea,@Score,@Restriction,@SymptomDescriptionID,@StrengthTestingID,@AffectedAreaID,@RestrictionRangeID,@OtherSymptomDesciption";
        }

        public struct PracitionerSupplierTreatmentCategoryRepositoryProcedure
        {
            public const string GetPracitionersByTreatmentCategoryIDAndSupplierID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PracitionersByTreatmentCategoryIDAndSupplierID @SupplierID, @TreatmentCategoryID";
        }

        public struct CaseTreatmentPricingRepositoryProcedure
        {
            public const string GetCaseTreatmentPricingByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseTreatmentPricingByCaseID @CaseID";
            public const string GetCheckCaseTreatmentPricingByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CheckCaseTreatmentPricingByCaseID @CaseID,@AssessmentServiceID";
            public const string GetCaseTreatmentPricingByCaseIDAndIsComplete = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseTreatmentPricingByCaseIDAndIsComplete @CaseID, @IsComplete";
            public const string GetCaseTreatmentPricingByCaseIDCaseSearch = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseTreatmentPricingByCaseIDCaseSearch @CaseID";
            public const string AddCaseTreatmentPricing = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseTreatmentPricing @CaseID,@ReferrerPricingID, @ReferrerPrice,@DateOfService,@PatientDidNotAttend,@WasAbandoned, @SupplierPrice, @Quantity , @SupplierPriceID ,@AuthorizationStatus,@PatientDidNotAttendDate";
            public const string UpdateCaseTreatmentPricingByCaseTreatmentPricingID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseTreatmentPricingByCaseTreatmentPricingID @CaseTreatmentPricingID,@WasAbandoned,@PatientDidNotAttend,@DateOfService";
            public const string UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseTreatmentPricingPriceByCaseTreatmentPricingID @CaseTreatmentPricingID,@WasAbandoned,@PatientDidNotAttend,@DateOfService,@ReferrerPricingID,@ReferrerPrice ,@SupplierPrice ,@SupplierPriceID ,@AuthorizationStatus,@PatientDidNotAttendDate";
            public const string GetReferrerAndSupplierPricingBySupplierIDAndTreatmentCategoryIDAndReferrerProjectTreatmentID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID @ReferrerProjectTreatmentID,@SupplierID,@TreatmentCategoryID";
            public const string GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID @ReferrerProjectTreatmentID,@SupplierID,@TreatmentCategoryID, @PricingTypeID";
            public const string DeleteCaseTreatmentPricingByCaseTreatmentPricingID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CaseTreatmentPricingByCaseTreatmentPricingID @CaseTreatmentPricingID";
            public const string UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseTreatmentReferrerPriceByCaseTreatmentPricingID @CaseTreatmentPricingID,@ReferrerPrice,@ReferrerPricingID,@DateOfService";
            public const string GetReferrerReferrerAndSupplierTreatmentPricingByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_ReferrerReferrerAndSupplierTreatmentPricingByCaseID @CaseID,@PricingTypeID";
            public static string UpdateCaseTreatmentPricing = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseTreatmentPricing @CaseTreatmentPricingID,@CaseID,@ReferrerPricingID, @ReferrerPrice,@DateOfService,@PatientDidNotAttend,@WasAbandoned, @SupplierPrice, @Quantity, @SupplierPriceID,@PatientDidNotAttendDate";
            public static string UpdateCaseTreatmentPricingPriceByReferrerPricingID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseTreatmentPricingPriceByReferrerPricingID @CaseTreatmentPricingID,@PricingTypeId";
            public const string DeleteCaseTreatmentPricingByCaseIDCaseStopped = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CaseTreatmentPricingByCaseIDCaseStopped @CaseID";
            public const string UpdateCaseTreatmentPricingAuthorisationStatusByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseTreatmentPricingAuthorisationStatusByCaseID @CaseID";
            public static string GetEPNATreatmentSessionDetail = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_EPNATreatmentSessionDetail @CaseID";
            public static string GetTreatmentSessionByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_TreatmentSessionByCaseID @CaseID";
        }

        public struct CaseBespokeServicePricingRepositoryProcedure
        {
            public const string GetCaseBespokeServicePricingByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseBespokeServicePricingByCaseID @CaseID";
            public const string GetCaseBespokeServicePricingByCaseIDAndIsComplete = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseBespokeServicePricingByCaseIDAndIsComplete @CaseID, @IsComplete";
            public const string AddCaseBespokeServicePricing = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseBespokeServicePricing @CaseID, @TreatmentCategoryBespokeServiceID, @ReferrerPrice, @SupplierPrice, @DateOfService,@PatientDidNotAttend ,@WasAbandoned";
            public const string UpdateCaseBespokeServicePricingByCaseBespokeServiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseBespokeServicePricingByCaseBespokeServiceID @CaseBespokeServiceID,@WasAbandoned,@PatientDidNotAttend,@DateOfService";
            public const string DeleteCaseBespokeServiceByCaseBespokeServiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CaseBespokeServiceByCaseBespokeServiceID @CaseBespokeServiceID";
            public const string UpdateCaseBespokeReferrerPriceByCaseBespokeServiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseBespokeReferrerPriceByCaseBespokeServiceID @CaseBespokeServiceID,@ReferrerPrice";
        }

        public struct SupplierClinicalAuditSupplierDocumentRepositoryProcedure
        {
            public const string GetSupplierClinicalAuditSupplierDocumentBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierClinicalAuditSupplierDocumentBySupplierID @SupplierID";
        }

        public struct SupplierSiteAuditSupplierDocumentRepositoryProcedure
        {
            public const string GetSupplierSiteAuditSupplierDocumentBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierSiteAuditSupplierDocumentBySupplierID @SupplierID";
        }

        public struct SupplierInsuranceSupplierDocumentRepositoryProcedure
        {
            public const string GetSupplierInsuranceSupplierDocumentBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierInsuranceSupplierDocumentBySupplierID @SupplierID";
        }

        public struct SupplierRegistrationSupplierDocumentRepositoryProcedure
        {
            public const string GetSupplierRegistrationSupplierDocumentBySupplierID = SQLExec + GlobalConst.Schema.SUPPLIER + GlobalConst.Schema.DOT + "Get_SupplierRegistrationSupplierDocumentBySupplierID @SupplierID";
        }

        public struct CaseAssessmentDetailRepositoryProcedure
        {
            public const string AddCaseAssessmentDetail = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentDetail @AssessmentServiceID, @CaseID, @HasThePatientHadTimeOff, @AbsentDetail, @HasThePatientReturnedToWork, @PatientImpactOnWorkID, @PatientWorkstatusID, @PatientRecommendedTreatmentSessions, @PatientRecommendedTreatmentSessionsDetail, @PatientTreatmentPeriod, @IsFurtherTreatmentRecommended, @PatientLevelOfRecoveryID, @SessionsPatientAttended, @DatesOfSessionAttended, @SessionsPatientFailedToAttend, @FollowingTreatmentPatientLevelOfRecoveryID, @AdditionalInformation, @HasCompliedHomeExerciseProgramme, @AbsentPeriod, @AbsentPeriodDurationID, @PatientTreatmentPeriodDetail, @PatientTreatmentPeriodDurationID, @PractitionerID, @EvidenceOfClinicalReasoning, @IsFurtherInvestigationOrOnwardReferralRequired, @FurtherInvestigationOrOnwardReferral, @EvidenceOfTreatmentRecommendations, @TreatmentPeriodTypeID, @PatientDateOfReturn, @PatientRecommendationReturn, @IsPatientReturnToPreInjuryDuties, @PatientPreInjuryDutiesDate, @MainFactors";
            public const string UpdateCaseAssessmentDetailByCaseAssessmentDetailID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentDetailByCaseAssessmentDetailID  @CaseAssessmentDetailID, @AssessmentServiceID , @CaseID , @HasThePatientHadTimeOff, @AbsentDetail, @AbsentPeriod , @AbsentPeriodDurationID , @HasThePatientReturnedToWork , @PatientImpactOnWorkID, @PatientWorkstatusID, @PatientRecommendedTreatmentSessions , @PatientRecommendedTreatmentSessionsDetail , @PatientTreatmentPeriod , @PatientTreatmentPeriodDetail, @PatientTreatmentPeriodDurationID , @IsFurtherTreatmentRecommended, @PatientLevelOfRecoveryID, @SessionsPatientAttended , @DatesOfSessionAttended, @SessionsPatientFailedToAttend , @FollowingTreatmentPatientLevelOfRecoveryID , @AdditionalInformation , @HasCompliedHomeExerciseProgramme,@PractitionerID, @EvidenceOfClinicalReasoning,@IsFurtherInvestigationOrOnwardReferralRequired, @FurtherInvestigationOrOnwardReferral, @EvidenceOfTreatmentRecommendations, @TreatmentPeriodTypeID, @PatientDateOfReturn, @PatientRecommendationReturn, @IsPatientReturnToPreInjuryDuties, @PatientPreInjuryDutiesDate, @MainFactors";
            public const string GetCaseAssessmentDetailByCaseIDAndAssessmentServiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentDetailByCaseIDAndAssessmentServiceID  @CaseID,@AssessmentServiceID";
            public const string GetCaseAssessmentDetailsByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentDetailByCaseID @CaseID";
            public const string GetCaseAssessmentDetailByCaseAssessmentDetailID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentDetailByCaseAssessmentDetailID  @CaseAssessmentDetailID";
            public const string GetCaseAssessmentDetailAndValuesByCaseIDAndAssessmentServiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentDetailAndValuesByCaseIDAndAssessmentServiceID  @CaseID,@AssessmentServiceID";
        }

        public struct CaseAssessmentDetailHistoryRepositoryProcedure
        {
            public const string AddCaseAssessmentDetailHistory = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentDetailHistory  @AssessmentServiceID, @CaseID , @HasThePatientHadTimeOff , @AbsentDetail , @HasThePatientReturnedToWork , @PatientImpactOnWorkID , @PatientWorkstatusID , @PatientRecommendedTreatmentSessions , @PatientRecommendedTreatmentSessionsDetail  , @PatientTreatmentPeriod , @IsFurtherTreatmentRecommended  , @PatientLevelOfRecoveryID , @SessionsPatientAttended , @DatesOfSessionAttended , @SessionsPatientFailedToAttend , @FollowingTreatmentPatientLevelOfRecoveryID , @AdditionalInformation , @HasCompliedHomeExerciseProgramme , @CaseAssessmentDetailID, @AbsentPeriod , @AbsentPeriodDurationID , @PatientTreatmentPeriodDetail, @PatientTreatmentPeriodDurationID,@PractitionerID,@IsFurtherInvestigationOrOnwardReferralRequired, @FurtherInvestigationOrOnwardReferral, @EvidenceOfTreatmentRecommendations,@TreatmentPeriodTypeID, @PatientDateOfReturn, @PatientRecommendationReturn, @IsPatientReturnToPreInjuryDuties, @PatientPreInjuryDutiesDate, @MainFactors";
        }

        public struct CaseNoteRepositoryProcedure
        {
            public const string AddCaseNote = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseNote @Note,@CaseID,@UserID,@WorkflowID";
            public const string GetCaseNotesByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseNotesByCaseID @CaseID";
            public const string GetCaseNoteByCaseIDAndWorkflowID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseNoteByCaseIDAndWorkflowID @caseID , @workflowID";
        }

        public struct CasePatientTreatmentWorkflowProcedure
        {
            public const string GetCasePatientTreatmentWorkflowLikePatientName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikePatientName @AdditionalParam, @PatientName, @Skip, @Take";
            public const string GetCasePatientTreatmentWorkflowLikePatientNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikePatientNameCount @AdditionalParam, @PatientName";
            public const string GetCasePatientTreatmentWorkflowLikeReferrerName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeReferrerName @AdditionalParam, @ReferrerName, @Skip, @Take";
            public const string GetCasePatientTreatmentWorkflowLikeReferrerNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeReferrerNameCount @AdditionalParam,@ReferrerName";
            public const string GetCasePatientTreatmentWorkflowLikeCaseNumber = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeCaseNumber @AdditionalParam,@CaseNumber, @Skip, @Take";
            public const string GetCasePatientTreatmentWorkflowLikeCaseNumberCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeCaseNumberCount @AdditionalParam,@CaseNumber";
            public const string GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumber @AdditionalParam, @CaseReferrerReferenceNumber, @Skip, @Take";
            public const string GetCasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeCaseReferrerReferenceNumberCount @AdditionalParam, @CaseReferrerReferenceNumber";
            public const string GetCasePatientTreatmentWorkflowLikeTreatmentCategoryName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeTreatmentCategoryName @AdditionalParam, @TreatmentCategoryName,@Skip, @Take";


            public const string GetCasePatientTreatmentWorkflowLikeTreatmentCategoryNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatment WorkflowLikeTreatmentCategoryNameCount @AdditionalParam, @TreatmentCategoryName";
            public const string GetCasePatientTreatmentWorkflowLikeTreatmentTypeName = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeTreatmentTypeName @AdditionalParam, @TreatmentTypeName, @Skip, @Take";
            public const string GetCasePatientTreatmentWorkflowLikeTreatmentTypeNameCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikeTreatmentTypeNameCount @AdditionalParam, @TreatmentTypeName";
            public const string GetCasePatientTreatmentWorkflowLikePostCode = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikePostCode @AdditionalParam,@PostCode,@Skip, @Take";
            public const string GetCasePatientTreatmentWorkflowLikePostCodeCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowLikePostCodeCount @AdditionalParam, @PostCode";

            public const string GetCasePatientReferrerSupplierWorkflowByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientReferrerSupplierWorkflowByCaseID @CaseID";

            //public static string GetCasePatientTreatmentWorkflowAllCases = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowAllCases @SearchText,@Skip, @Take";
            //public static string GetCasePatientTreatmentWorkflowAllCasesCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowAllCasesCount @SearchText";

            //public static string GetCasePatientTreatmentWorkflowAllCasesActive = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowAllCasesActive @SearchText, @Skip, @Take";

            //public static string GetCasePatientTreatmentWorkflowAllCasesActiveCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowAllCasesActiveCount @SearchText";

            //public static string GetCasePatientTreatmentWorkflowAllCasesInActive = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowAllCasesInActive @SearchText,@Skip, @Take";

            //public static string GetCasePatientTreatmentWorkflowAllCasesInActiveCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CasePatientTreatmentWorkflowAllCasesInActiveCount @SearchText";
        }

        public struct CaseCommunicationHistoryRepositoryProcedure
        {
            public const string AddCaseCommunicationHistory = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseCommunicationHistory @CaseID,@SentTo,@SentCC,@Subject,@Message,@UserID,@UploadPath";
            public const string GetCaseCommunicationHistoriesByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseCommunicationHistoriesByCaseID @CaseID";
        }

        public struct CaseVATRepositoryProcedure
        {
            public const string AddCaseVAT = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseVAT @CaseID,@VAT";
            public const string GetCaseVATByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseVATByCaseID @CaseID";
        }

        public struct CaseAssessmentProposedTreatmentMethodHistoryRepositoryProcedure
        {
            public const string AddCaseAssessmentProposedTreatmentMethodHistory = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentProposedTreatmentMethodHistory  @CaseAssessmentHistoryID,@CaseID,@ProposedTreatmentMethodID";
        }

        public struct CaseAssessmentProposedTreatmentMethodRepositoryProcedure
        {
            public const string AddCaseAssessmentProposedTreatmentMethod = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_CaseAssessmentProposedTreatmentMethod  @CaseID,@ProposedTreatmentMethodID";

            public const string GetCaseAssessmentProposedTreatmentMethodsByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentProposedTreatmentMethodsByCaseID  @CaseID";

            public const string DeleteCaseAssessmentProposedTreatmentMethodByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Delete_CaseAssessmentProposedTreatmentMethodByCaseID  @CaseID";

            public const string UpdateCaseAssessmentDateByCaseIDandAssessmentServiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_CaseAssessmentDateByCaseIDandAssessmentServiceID  @CaseID,@AssessmentServiceID,@AssessmentDate";

            public const string GetCaseAssessmentProposedTreatmentMethodsAndValuesByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseAssessmentProposedTreatmentMethodsAndValuesByCaseID  @CaseID,@ReportType";
        }


        public struct TreatmentCategoryPricingTypesRepositoryProcedure
        {
            public const string GetPricingTypesByTreatmentCategoryID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PricingTypesByTreatmentCategoryID @TreatmentCategoryID";
        }

        public struct TreatmentCategoriesPricingTypesRepositoryProcedure
        {
            public const string GetTreatmentCategoriesPricingTypesByTreatmentCategoryID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_TreatmentCategoriesPricingTypesByTreatmentCategoryID @TreatmentCategoryID";
        }

        public struct InvoiceRepositoryProcedure
        {
            public const string GetInvoiceByInvoiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoiceByInvoiceID @InvoiceID";
            public const string GetInvoiceCollectionActionByInvoiceCollectionActionID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoiceCollectionActionByInvoiceCollectionActionID @InvoiceCollectionActionID";
            public const string GetInvoiceCollectionActionByInvoiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoiceCollectionActionByInvoiceID @InvoiceID";
            public const string GetInvoiceCollectionActionByUserID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoiceCollectionActionByUserID @UserID";
            public const string GetInvoicePaymentByInvoiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoicePaymentByInvoiceID @InvoiceID";
            public const string GetInvoicePaymentByInvoicePaymentID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoicePaymentByInvoicePaymentID @InvoicePaymentID";
            public const string GetInvoicePaymentByUserID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoicePaymentByUserID @UserID";
            public const string GetInvoicesByCaseId = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoicesByCaseId @CaseId";
            public const string GetInvoicesByUserID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_InvoicesByUserID @UserID";
            public const string UpdateInvoiceIsCompleteByInvoiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_InvoiceIsCompleteByInvoiceID @IsComplete,@InvoiceID";
            public const string AddInvoice = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_Invoice @InvoiceNumber,@Amount,@CaseId,@UserId,@InvoiceDate,@IsComplete";
            public const string AddInvoiceCollectionAction = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_InvoiceCollectionAction @InvoiceID,@Action,@UserId,@FollowUpDate,@DateofAction";
            public const string AddInvoicePayment = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_InvoicePayment @InvoiceID,@Payment,@AdjustedPayment,@CheckNumber,@BACS,@UserId,@InvoicePaymentDate";
            public const string GetOutstandingInvoicesCasePatientReferrer = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseInvoicePatientReferrer @Skip,@Take";
            public const string GetOutstandingInvoicesCasePatientReferrerByInvoiceID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseInvoicePatientReferrerByInvoiceID @InvoiceID";
            public const string GetCaseInvoicePatientReferrerCount = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_CaseInvoicePatientReferrerCount";
        }

        public struct ReferrerCaseAssessmentModificationProcedure
        {
            public const string AddReferrerCaseAssessmentModification = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerCaseAssessmentModifications @CaseID,@TreatmentSession,@AssessmentServiceID";
            public const string GetReferrerCaseAssessmentModificationsbyCaseID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerCaseAssessmentModificationsbyCaseID @CaseID";
            public const string GetCaseTreatmentPricingByCaseID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_CaseTreatmentPricingByCaseID @CaseID";

        }

        public struct PolicieRepositoryProcedure
        {
            public const string GetPolicyByPolicyId = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PolicyByPolicyId @PolicyID";
            public const string AddPolicie = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_Policie @PolicyTypeId,@TypeCoverId,@PolicyCriteriaId,@RehabProportionateBenefit,@FitForWorkId,@ReInsuredId,@ReferenceNo,@AdmittedId,@BenefitDate,@MonthlyValue,@WeeklyValue,@EndBenefitDate,@NameOfReinsurerID,@PolicyWording";
            public const string UpdatePolicie = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_Policie @PolicyTypeId,@TypeCoverId,@PolicyCriteriaId,@RehabProportionateBenefit,@FitForWorkId,@ReInsuredId,@ReferenceNo,@AdmittedId,@BenefitDate,@MonthlyValue,@WeeklyValue,@EndBenefitDate,@NameOfReinsurerID,@PolicyWording,@PolicyID";
        }

        public struct EmploymentRepositoryProcedure
        {
            public const string GetEmploymentByEmploymentID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_EmploymentByEmploymentID @EmploymentID";
            public const string AddEmployment = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_Employment @EmploymentTypeId,@CompanyName,@JobRole,@Address,@ContactName,@PrimaryPhone,@Email";
            public const string UpdateEmployment = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_EmploymentByEmploymentId @EmploymentTypeId,@CompanyName,@JobRole,@Address,@ContactName,@PrimaryPhone,@Email,@EmploymentId";
        }

        public struct PasswordHistoryRepositoryProcedure
        {
            public const string GetPasswordHistoryByUserID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PasswordHistoryByUserID @UserID";
        }

        public struct DrugTestRepositoryProcedure
        {
            public const string GetDrugTestByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_DrugTestByCaseID @CaseID";
            public const string AddDrugTest = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_DrugTest @IsDrugAndAlcohalTest,@NetworkRailStandardApplicableID,@ReasonForReferralID,@IsSentinalUpdating,@SentinalNumber,@AdditionalTestID,@AdditionalTestOther";
            public const string UpdateDrugTest = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_DrugTestByID @DrugTestID,@IsDrugAndAlcohalTest,@NetworkRailStandardApplicableID,@ReasonForReferralID,@IsSentinalUpdating,@SentinalNumber,@AdditionalTestID,@AdditionalTestOther";
        }

        public struct JobDemandRepositoryProcedure
        {
            public const string GetJobDemandByCaseID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_JobDemandByCaseID @CaseID";
            public const string AddJobDemand = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_JobDemands @IsJobDemand, @IsStanding,@IsWalking,@IsWorkATHeightOrClimb,@IsExtendedOrProlonged,@IsVocationalDriving,@IsDrivingLGVOrPCVs,@IsDrivingForkliftTrucks,@IsWorkWithChemials,@IsWorkBiologicalOrChemical,@IsWorkWithSkinIrritants,@IsWorkWithDengerousMachinery,@IsNightWork,@IsShiftWork,@IsWorkInConfinedSpaces,@IsWorkWithDustOrFumes,@IsLiftOrCarryHeavyItems,@IsWorkWithComputerOrScreens,@IsWorkTowardsTagetOrPressuredsituation,@IsWorkWithAdultOrChildren,@IsHealthCareWorker,@IsOccasionalOverseasTravel,@IsOutsideWork,@IsNoisedHarzardArea,@IsHandlingFood,@FreeText";
            public const string Update_JobDemandByID = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_JobDemandByID @JobDemandID,@IsJobDemand,@IsStanding,@IsWalking,@IsWorkATHeightOrClimb,@IsExtendedOrProlonged,@IsVocationalDriving,@IsDrivingLGVOrPCVs,@IsDrivingForkliftTrucks,@IsWorkWithChemials,@IsWorkBiologicalOrChemical,@IsWorkWithSkinIrritants,@IsWorkWithDengerousMachinery,@IsNightWork,@IsShiftWork,@IsWorkInConfinedSpaces,@IsWorkWithDustOrFumes,@IsLiftOrCarryHeavyItems,@IsWorkWithComputerOrScreens,@IsWorkTowardsTagetOrPressuredsituation,@IsWorkWithAdultOrChildren,@IsHealthCareWorker,@IsOccasionalOverseasTravel,@IsOutsideWork,@IsNoisedHarzardArea,@IsHandlingFood,@FreeText";
        }

        public struct PolicyOpenDetailProcrdure
        {
            public const string AddPolicyOpenDetail = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Add_PolicyOpenDetail @PolicyType,@TypeCover,@PolicyCriteria,@RehabORProportionate,@FitforWork,@ReInsured,@ReferenceNo,@Admitted,@OpenBenefitDate,@OpenMonthlyValue,@OpenEndBenefitDate,@NameofReinsurer,@OpenPolicyWording";
            public const string UpdatePolicyOpenDetail = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Update_PolicyOpenDetail @PolicyOpenDetailID,@PolicyType,@TypeCover,@PolicyCriteria,@RehabORProportionate,@FitforWork,@ReInsured,@ReferenceNo,@Admitted,@OpenBenefitDate,@OpenMonthlyValue,@OpenEndBenefitDate,@NameofReinsurer,@OpenPolicyWording";
            public const string GetPolicyOpenDetailById = SQLExec + GlobalConst.Schema.GLOBAL + GlobalConst.Schema.DOT + "Get_PolicyOpenDetailById @PolicyOpenDetailID";
        }

        public struct ReferrerGroupProcedure
        {
            public const string AddReferrerGroup = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Add_ReferrerGroup @GroupName,@UserID,@ReferrerID";
            public const string UpdateReferrerGroupByID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerGroupByID @GroupID,@Name,@UserID,@ReferrerID";
            public const string GetReferrersGroupsByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrersGroupsByReferrerID @ReferrerID";
            public const string GetGroupUsersByReferrerIDAndName = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_GroupUsersByReferrerIDAndName @Name,@ReferrerID";
            public const string GetReferrerGroupUsersCasesByReferrerID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerGroupUsersCasesByReferrerID @Name,@ReferrerID,@Skip,@Take";
            public const string GetReferrerGroupUsersCasesByReferrerIDCount = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Get_ReferrerGroupUsersCasesByReferrerIDCount @Name,@ReferrerID";
            public const string DeleteGroupByID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Delete_GroupByID @GroupID";
            public const string UpdateReferrerGroupNameBynameAndID = SQLExec + GlobalConst.Schema.REFERRER + GlobalConst.Schema.DOT + "Update_ReferrerGroupNameBynameAndID @NewGroupName,@GroupName,@ReferrerID,@UserID";
        }
    }
}