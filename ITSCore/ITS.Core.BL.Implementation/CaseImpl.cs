using ITS.Core.Data;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

#region Comment
/*
 Page Name:  caseImpl.cs                      
 Latest Version:  1.1
 Author : Robin Singh, Satya
 
 * Revision History:                                                   
===================================================================================
 * 
    * Modified By : Pardeep Kumar
    * Description : Implemented interface Method UpdateCaseIsTreatmentRequired
    * Date        : 29-06-2013 
    * Version     : 1.1 
*/
#endregion
namespace ITS.Core.BL.Implementation
{

    public class CaseImpl : ICase
    {

        private readonly ICaseRepository _caseRepository;
        private readonly ISolicitorRepository _solicitorRepository;
        private readonly ICaseHistoryRepository _caseHistoryRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly ICaseAppointmentDateRepository _caseAppointmentDateRepository;
        private readonly ICasePatientContactAttemptRepository _casePatientContactAttemptRepository;
        private readonly ICaseAssessmentRepository _caseAssessmentRepository;
        private readonly IReferrerProjectTreatmentAuthorisationRepository _referrerProjectTreatmentAuthorisationRepository;
        private readonly ICaseTreatmentPricingRepository _caseTreatmentPricingRepository;

        private readonly ISupplierTreatmentPricingRepository _supplierTreatmentPricingRepository;
        private readonly IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;
        private readonly IInjuredPartyRepresentativeRepository _iInjuredPartyRepresentativeRepository;
        private readonly IEmploymentRepository _IEmploymentRepository;
        private readonly IEmployeeDetail _employeeDetail;
        private readonly IPolicieRepository _IPolicieRepository;
        private readonly IDrugTest _drugTest;
        private readonly IJobDemand _jobDemand;
        private readonly IPolicyOpenDetailRepository _policyOpenDetailRepository;
        private readonly IGipRepository _gipRepository;
        private readonly IElRehabRepository _elRehabRepository;
        private readonly ITpdRepository _tpdRepository;
        private readonly IIipRepository _iipRepository;

        public CaseImpl(ICaseRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        public CaseImpl(ICaseRepository caseRepository, IPatientRepository patientRepository, IReferrerProjectTreatmentAuthorisationRepository referrerProjectTreatmentAuthorisationRepository,
            ISolicitorRepository solicitorRepository, ICaseHistoryRepository caseHistoryRepository, ICaseTreatmentPricingRepository caseTreatmentPricingRepository,
            ICaseAppointmentDateRepository caseAppointmentDateRepository, ICasePatientContactAttemptRepository casePatientContactAttemptRepository, ICaseAssessmentRepository caseAssessmentRepository,
            IInjuredPartyRepresentativeRepository iInjuredPartyRepresentativeRepository, IPolicieRepository IPolicieRepository, IEmploymentRepository IEmploymentRepository, IEmployeeDetail employeeDetail, IDrugTest drugTest, IJobDemand jobDemand
            , IPolicyOpenDetailRepository policyOpenDetailRepository, IGipRepository gipRepository, IElRehabRepository elRehabRepository, ITpdRepository tpdRepository, IIipRepository iipRepository)
        {
            _caseRepository = caseRepository;
            _patientRepository = patientRepository;
            _solicitorRepository = solicitorRepository;
            _caseHistoryRepository = caseHistoryRepository;
            _caseAppointmentDateRepository = caseAppointmentDateRepository;
            _casePatientContactAttemptRepository = casePatientContactAttemptRepository;
            _caseAssessmentRepository = caseAssessmentRepository;
            _referrerProjectTreatmentAuthorisationRepository = referrerProjectTreatmentAuthorisationRepository;
            _caseTreatmentPricingRepository = caseTreatmentPricingRepository;
            _iInjuredPartyRepresentativeRepository = iInjuredPartyRepresentativeRepository;
            _IPolicieRepository = IPolicieRepository;
            _IEmploymentRepository = IEmploymentRepository;
            _employeeDetail = employeeDetail;
            _drugTest = drugTest;
            _jobDemand = jobDemand;
            _policyOpenDetailRepository = policyOpenDetailRepository;
            _gipRepository = gipRepository;
            _elRehabRepository = elRehabRepository;
            _tpdRepository = tpdRepository;
            _iipRepository = iipRepository;
        }

        public Employment GetEmploymentByEmploymentID(int EmploymentID)
        {
            return _IEmploymentRepository.GetEmploymentByEmploymentID(EmploymentID);
        }

        public Policie GetPolicyByPolicyID(int _policyID)
        {
            return _IPolicieRepository.GetPolicyByPolicyID(_policyID);
        }

        public PolicyOpenDetail GetPolicyOpenDetailByID(int _ID)
        {
            return _policyOpenDetailRepository.GetPolicyOpenDetailById(_ID);
        }
        public int AddNewReferral(Case caseObj, Patient patient, int userID, Solicitor solicitor = null, InjuredPartyRepresentative objInjuredPartyRepresentative = null, Employment objEmployment = null, Policie objPolicie = null, EmployeeDetail objDetail = null, PolicyOpenDetail policyOpenDetail =  null, DrugTest objDrugTest = null, JobDemand objJobDemand = null)
        {
            //caseObj.CaseNumber = Guid.NewGuid();
            caseObj.CaseReferrerDueDate = DateTime.Now;

            if (patient.HasLegalRep)
            {
                var solicitorID = _solicitorRepository.AddSolicitor(solicitor);
                patient.SolicitorID = solicitorID;
            }

            if (patient.HasInjuredPartyRepresentative > 1)
            {
                var injuredID = _iInjuredPartyRepresentativeRepository.AdditionInjuredPartyRepresentative(objInjuredPartyRepresentative);
                patient.InjuredID = injuredID;
            }
            var employmentID = _IEmploymentRepository.AddEmployment(objEmployment);
            var policieyID = _IPolicieRepository.AddPolicie(objPolicie);
            if (policyOpenDetail != null)
            {
                var policyOpenDetailID = _policyOpenDetailRepository.AddPolicieOpenDetail(policyOpenDetail);
                patient.PolicyOpenDetailID = policyOpenDetailID;
            }           
            var EmpDetailID = _employeeDetail.AddEmployeeDetail(objDetail);
            if (objDrugTest != null)
            {
                var DrugTestID = _drugTest.AddDrugTest(objDrugTest);
                caseObj.DrugTestID = DrugTestID;
            }
            if (objJobDemand != null)
            {
                var jobDemandID = _jobDemand.AddJobDemand(objJobDemand);
                caseObj.JobDemandID = jobDemandID;
            }
            caseObj.EmployeeDetailID = EmpDetailID;
            patient.EmploymentID = employmentID;
            patient.PolicyID = policieyID;            
            var patientID = _patientRepository.AddPatient(patient);

            caseObj.PatientID = patientID;
            caseObj.WorkflowID = Global.GlobalConst.WorkFlow.ReferralSubmitted;

            var caseID = _caseRepository.AddCase(caseObj);
            //caseObj.CaseID = _caseRepository.AddCase(caseObj);

            if (caseObj.IsTriage)
                UpdateCaseIsTreatmentRequired(caseID, false);

            _caseHistoryRepository.AddCaseHistory(new CaseHistory()
                {
                    CaseID = caseID,
                    EventDate = DateTime.Now,
                    EventTypeID = Global.GlobalConst.EventType.WORKFLOW,
                    UserID = userID,
                    EventDescription = string.Format("Added new case id:{0}", caseID)
                });

            return caseID;
        }

        public DrugTest GetDrugTestByCaseID(int caseID)
        {
            return _drugTest.GetDrugTestByCaseID(caseID);
        }

        public int UpdateReferral(Case caseObj, Patient patient, int userID, Solicitor solicitor = null, InjuredPartyRepresentative objInjuredPartyRepresentative = null, Employment objEmployment = null, Policie objPolicie = null, EmployeeDetail objDetail = null, PolicyOpenDetail policyOpenDetail = null, DrugTest objDrugTest = null, JobDemand objJobDemand = null)
        {
            if (patient.HasLegalRep)
            {
                if (solicitor.SolicitorID == 0)
                {
                    var solicitorID = _solicitorRepository.AddSolicitor(solicitor);
                    patient.SolicitorID = solicitorID;
                }
                else
                {
                    var solicitorID = _solicitorRepository.UpdateSolicitorBySolicitorID(solicitor);
                    patient.SolicitorID = solicitor.SolicitorID;
                }
            }
            if (patient.HasInjuredPartyRepresentative > 1)
            {
                if (objInjuredPartyRepresentative.InjuredID == 0)
                {
                    var injuredID = _iInjuredPartyRepresentativeRepository.AdditionInjuredPartyRepresentative(objInjuredPartyRepresentative);
                    patient.InjuredID = injuredID;
                }
                else
                {
                    var injuredID = _iInjuredPartyRepresentativeRepository.UpdationInjuredPartyRepresentative(objInjuredPartyRepresentative);
                    patient.InjuredID = objInjuredPartyRepresentative.InjuredID;
                }
            }

            if (objEmployment.EmploymentId == 0)
            {
                var employmentID = _IEmploymentRepository.AddEmployment(objEmployment);
                patient.EmploymentID = employmentID;
            }
            else
            {
                var employmentID = _IEmploymentRepository.UpdateEmployment(objEmployment);
                patient.EmploymentID = objEmployment.EmploymentId;
            }
            if (objDetail.EmployeeDetailID == 0)
            {
                var empID = _employeeDetail.AddEmployeeDetail(objDetail);
                caseObj.EmployeeDetailID = empID;
            }
            else
            {
                var emplID = _employeeDetail.UpdateEmployeeDetail(objDetail);
                caseObj.EmployeeDetailID = emplID;
            }

            if (objDrugTest.DrugTestID == 0)
            {
                var drugTestID = _drugTest.AddDrugTest(objDrugTest);
                caseObj.DrugTestID = drugTestID;
            }
            else
            {
                _drugTest.UpdateDrugTest(objDrugTest);
                caseObj.DrugTestID = objDrugTest.DrugTestID;
            }

            if (objJobDemand.JobDemandID == 0)
            {
                var jobDemandID = _jobDemand.AddJobDemand(objJobDemand);
                caseObj.JobDemandID = jobDemandID;
            }
            else
            {
                _jobDemand.UpdateJobDemand(objJobDemand);
                caseObj.JobDemandID = objJobDemand.JobDemandID;
            }

            if (objPolicie.PolicyID == 0)
            {
                var policieyID = _IPolicieRepository.AddPolicie(objPolicie);
                patient.PolicyID = policieyID;
            }
            else
            {
                _IPolicieRepository.UpdatePolicie(objPolicie);
                patient.PolicyID = objPolicie.PolicyID;
            }

            if (policyOpenDetail.PolicyOpenDetailID == 0)
            {
                var policyOpenDetailID = _policyOpenDetailRepository.AddPolicieOpenDetail(policyOpenDetail);
                patient.PolicyOpenDetailID = policyOpenDetailID;
            }
            else
            {
                _policyOpenDetailRepository.UpdatePolicieOpenDetail(policyOpenDetail);
                patient.PolicyOpenDetailID = policyOpenDetail.PolicyOpenDetailID; 
            }

            var PatientID = _patientRepository.UpdatePatientByPatientID(patient);
            caseObj.PatientID = patient.PatientID;

            caseObj.WorkflowID = Global.GlobalConst.WorkFlow.ReferralSubmitted;

            var caseID = _caseRepository.UpdateCaseByCaseID(caseObj);

            if (caseObj.IsTriage)
                UpdateCaseIsTreatmentRequired(caseObj.CaseID, false);

            //_caseHistoryRepository.UpdateCaseHistory(new CaseHistory()
            //{
            //    CaseID = caseID,
            //    EventDate = DateTime.Now,
            //    EventTypeID = Global.GlobalConst.EventType.WORKFLOW,
            //    UserID = userID,
            //    EventDescription = string.Format("Added new case id:{0}", caseID),
            //    //CaseHistoryID = case
            //});

            return caseID;
        }

        public int AddCase(Case caseObj)
        {
            return _caseRepository.AddCase(caseObj);
        }

        public int UpdateCaseByCaseID(Case caseObj)
        {
            return _caseRepository.UpdateCaseByCaseID(caseObj);
        }

        public int DeleteCaseByCaseID(int caseID)
        {
            return _caseRepository.DeleteCaseByCaseID(caseID);
        }

        public Case GetCaseByCaseID(int caseID)
        {
            return _caseRepository.GetCaseByCaseID(caseID);
        }
        public Case GetCaseByPatientID(int PatientID)
        {
            return _caseRepository.GetCaseByPatientID(PatientID);
        }

        public IEnumerable<Case> GetCaseByLikeCaseNumber(string caseNumber)
        {
            return _caseRepository.GetCaseByLikeCaseNumber(caseNumber);
        }

        public int UpdateCaseWorkflowByCaseID(int caseID, int workflowID)
        {
            return _caseRepository.UpdateCaseWorkflowByCaseID(caseID, workflowID);
        }

        public int UpdateCaseWorkflowByCaseIDStoppedCase(int caseID)
        {
            return _caseRepository.UpdateCaseWorkflowByCaseIDStoppedCase(caseID);
        }

        public IEnumerable<Case> GetReferrerCasesByWorkflowID(int workflowID, int referrerID)
        {
            return _caseRepository.GetReferrerCasesByWorkflowID(workflowID, referrerID);
        }


        public IEnumerable<Case> GetCasesByWorkFlowID(int workflowID)
        {
            return _caseRepository.GetCasesByWorkFlowID(workflowID);
        }

        //public IEnumerable<CaseWorkflowPatientReferrerProject> GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(int workflowID, int treatmentCategoryID)
        //{
        //    return _caseRepository.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(workflowID, treatmentCategoryID);
        //}lf

        public bool UpdateCaseWorkFlow(int caseID, int userID)
        {
            return Init.Engine.RunWorkFlowUpdate(caseID, userID, _caseRepository, _caseHistoryRepository, _caseAssessmentRepository, _referrerProjectTreatmentAuthorisationRepository, _caseTreatmentPricingRepository);
        }


        public int GetReferrerProjectTreatmentDocumentSetup(int caseID, int AssessmentServiceID)
        {
            return _caseRepository.GetReferrerProjectTreatmentDocumentSetup(caseID, AssessmentServiceID);
        }

        public int GetCaseAssessmentCustomsByCaseID(int caseID)
        {
            return _caseRepository.GetCaseAssessmentCustomsByCaseID(caseID);
        }

        public IntialAssessmentReportDetail GetIntialAssessmentReportDetailsByCaseID(int caseID)
        {
            return _caseRepository.GetIntialAssessmentReportDetailsByCaseID(caseID);
        }
        public IntialAssessmentReportDetail GetInitialReviewAssessmentByCaseID(int caseID)
        {
            return _caseRepository.GetInitialReviewAssessmentByCaseID(caseID);
        }

        public EvaluateDelegatedAuthorisationCost GetEvaluateDelegatedAuthorisationCost(int caseID, int assessmentTypeID)
        {
            return _caseRepository.GetEvaluateDelegatedAuthorisationCost(caseID, assessmentTypeID);
        }

        public bool UpdateCaseWorkflowCustomByCaseID(int caseID, int userID, int workflowID)
        {
            return Init.Engine.UpdateCaseWorkflowCustomByCaseID(caseID, userID, workflowID, _caseRepository);
        }

        public bool UpdateCaseWorkFlowStoppedCase(int caseID, int userID)
        {
            return Init.Engine.RunWorkFlowUpdateStoppedCase(caseID, userID, _caseRepository, _caseHistoryRepository, _caseAssessmentRepository, _referrerProjectTreatmentAuthorisationRepository, _caseTreatmentPricingRepository);
        }

        public int DeletePatientContactAttemptByID(int CasePatientContactAttemptID)
        {
            return _casePatientContactAttemptRepository.DeletePatientContactAttemptByID(CasePatientContactAttemptID);
        }
        public int AddBookIA(int caseID, DateTime patientContactDate, int? supplierAssignedUser, CaseAppointmentDate caseAppointmentDate, string InnovateNote)
        {
            _caseRepository.UpdateCasePatientContactDateByCaseID(caseID, patientContactDate, supplierAssignedUser.Value, InnovateNote);
            _caseAppointmentDateRepository.AddCaseAppointmentDate(caseAppointmentDate);
            const int successResp = 1;
            return successResp;
        }


        public int UpdateCaseSupplier(int caseID, int supplierID)
        {
            return _caseRepository.UpdateCaseSupplier(caseID, supplierID);
        }


        public int UpdateCaseIsTreatmentRequired(int caseID, bool isTreatmentRequired)
        {
            // If isTreatmentRequired is true it will right aways update UpdateCaseIsTreatmentRequired
            if (isTreatmentRequired)
            {
                return _caseRepository.UpdateCaseIsTreatmentRequired(caseID, isTreatmentRequired);
            }
            else
            {
                // If isTreatmentRequired is false we get referrer And SupplierPricing for TriageAssessment

                var referrerAndSupplierPricingTriageAssessment = GetReferrerAndSupplierPricingTriageAssessment(caseID);

                // if SupplierPricing of referrerAndSupplierPricingTriageAssessment is null then update UpdateCaseIsTreatmentRequired.
                if (!referrerAndSupplierPricingTriageAssessment.SupplierID.HasValue) _caseRepository.UpdateCaseIsTreatmentRequired(caseID, isTreatmentRequired);

                // if SupplierPricing of referrerAndSupplierPricingTriageAssessment is not null (then AddCaseTreatmentPricing using referrerAndSupplierPricingTriageAssessment value and update UpdateCaseIsTreatmentRequired) else return zero( for invalid data) .
                if (referrerAndSupplierPricingTriageAssessment.ReferrerPricingID.HasValue && referrerAndSupplierPricingTriageAssessment.SupplierPriceID.HasValue)
                {
                    _caseTreatmentPricingRepository.AddCaseTreatmentPricing(new CaseTreatmentPricing() { CaseID = caseID, ReferrerPrice = referrerAndSupplierPricingTriageAssessment.ReferrerPrice.Value, ReferrerPricingID = referrerAndSupplierPricingTriageAssessment.ReferrerPricingID.Value, SupplierPrice = referrerAndSupplierPricingTriageAssessment.SupplierPrice.Value, SupplierPriceID = referrerAndSupplierPricingTriageAssessment.SupplierPriceID.Value, Quantity = 0 });

                    return _caseRepository.UpdateCaseIsTreatmentRequired(caseID, isTreatmentRequired);

                }
                else
                {
                    return 0;
                }
            }

        }
        public int UpdateCaseInvoiceDate(DateTime invoiceDate, int caseID)
        {
            return _caseRepository.UpdateCaseInvoiceDate(invoiceDate, caseID);
        }


        public ReferrerAndSupplierPricing GetReferrerAndSupplierPricingVat(int caseID)
        {
            return _caseTreatmentPricingRepository.GetReferrerReferrerAndSupplierTreatmentPricingByCaseID(caseID, Global.GlobalConst.PricingType.VAT).SingleOrDefault();
        }

        public ReferrerAndSupplierPricing GetReferrerAndSupplierPricingTriageAssessment(int caseID)
        {
            return _caseTreatmentPricingRepository.GetReferrerReferrerAndSupplierTreatmentPricingByCaseID(caseID, Global.GlobalConst.PricingType.TRIAGEASSESSMENT).SingleOrDefault();
        }


        public IEnumerable<ReferrerAndSupplierPricing> GetReferrerAndSupplierPricing(int caseID)
        {
            return _caseTreatmentPricingRepository.GetReferrerReferrerAndSupplierTreatmentPricingByCaseID(caseID, null);
        }

        public IEnumerable<CasePatientContactAttempt> GetUnsuccessfulContactDate(int caseID)
        {
            return _caseRepository.GetUnsuccessfulContactDate(caseID);
        }

        public IEnumerable<CasePatientContactAttempt> GetPatientContactDate(int caseID)
        {
            return _caseRepository.GetPatientContactDate(caseID);

        }

        public NotificationBubble GetNotificationBubbleCountBySupplierID(int _supplierID)
        {
            NotificationBubble _notificationBubble = new NotificationBubble();

            int _supplierAuthorisations = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, Global.GlobalConst.WorkFlow.PatientInTreatment).Count();
            int _supplierAuthorisationsCustom = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, Global.GlobalConst.WorkFlow.PatientInTreatmentCustom).Count();
            _supplierAuthorisations += _supplierAuthorisationsCustom;


            const int workflowIDReferredToSupplier = Global.GlobalConst.WorkFlow.ReferredtoSupplier;
            const int workflowIDReferredToTriageAssessment = Global.GlobalConst.WorkFlow.ReferreredtoTriageSupplier;
            const int workflowIDInitialAssessmentCustom = Global.GlobalConst.WorkFlow.InitialAssessmentSupplierCustom;

            int _supplierNewPatientCases = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDReferredToSupplier).Count();
            int _supplierNewPatientCases1 = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDReferredToTriageAssessment).Count();
            int _supplierNewPatientCases2 = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDInitialAssessmentCustom).Count();


            _supplierNewPatientCases = _supplierNewPatientCases + _supplierNewPatientCases1 + _supplierNewPatientCases2;

            const int workflowIDInitialAssessmentBooked = Global.GlobalConst.WorkFlow.InitialAssessmentBooked;
            const int workflowIDInitialAssessmentAttended = Global.GlobalConst.WorkFlow.InitialAssessmentAttended;
            const int workflowIDReportNotAccepted = Global.GlobalConst.WorkFlow.ReportNotAccepted;
            const int workflowIDReportNotAcceptedCustom = Global.GlobalConst.WorkFlow.ReportNotAcceptedCustom;

            int _supplierExistingPatientsInitialAssessments = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDInitialAssessmentBooked).Count();
            int _supplierExistingPatientsInitialAssessments2 = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDInitialAssessmentAttended).Count();
            int _supplierExistingPatientsInitialAssessments3 = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDReportNotAccepted).Count();
            int _supplierExistingPatientsInitialAssessments4 = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDReportNotAcceptedCustom).Count();

            _supplierExistingPatientsInitialAssessments = _supplierExistingPatientsInitialAssessments + _supplierExistingPatientsInitialAssessments2 + _supplierExistingPatientsInitialAssessments3 + _supplierExistingPatientsInitialAssessments4;

            const int workflowIDReviewAssessmentReportNotAccepted = Global.GlobalConst.WorkFlow.ReviewAssessmentReportNotAccepted;
            const int workflowIDFinalAssessmentReportNotAccepted = Global.GlobalConst.WorkFlow.FinalAssessmentReportNotAccepted;

            int _supplierExistingPatientsNextAssessments = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment).Count();
            int _supplierExistingPatientsNextAssessments2 = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatmentCustom).Count();
            int _supplierExistingPatientsNextAssessments3 = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDReviewAssessmentReportNotAccepted).Count();
            int _supplierExistingPatientsNextAssessments4 = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, workflowIDFinalAssessmentReportNotAccepted).Count();

            _supplierExistingPatientsNextAssessments = _supplierExistingPatientsNextAssessments + _supplierExistingPatientsNextAssessments2 + _supplierExistingPatientsNextAssessments3 + _supplierExistingPatientsNextAssessments4;



            int _supplierStoppedCases = _caseRepository.GetSupplierCasesAndPatientByWorkflowID(_supplierID, Global.GlobalConst.WorkFlow.CaseStoppedSenttoSupplier).Count();



            _notificationBubble.AuthorisationCount = _supplierAuthorisations;
            _notificationBubble.NewPatientCount = _supplierNewPatientCases;
            _notificationBubble.ExistingPatientsInitialAssessmentCount = _supplierExistingPatientsInitialAssessments;
            _notificationBubble.ExistingPatientsNextAssessmentCount = _supplierExistingPatientsNextAssessments;
            _notificationBubble.StoppedCaseCount = _supplierStoppedCases;

            return _notificationBubble;
        }

        public IEnumerable<BLCaseReferrerAssignedUser> GetCaseReferrerAssignedUsersByCaseID(int CaseID)
        {
            return _caseRepository.GetCaseReferrerAssignedUsersByCaseID(CaseID);
        }

        public int AddCaseReferrerAssignedUser(CaseReferrerAssignedUser _CaseReferrerAssignedUser)
        {
            return _caseRepository.AddCaseReferrerAssignedUser(_CaseReferrerAssignedUser);
        }

        public int DeleteCaseReferrerAssignedUserByID(int id)
        {
            return _caseRepository.DeleteCaseReferrerAssignedUserByID(id);
        }

        public IEnumerable<Gip> GetAllGips()
        {
            return _gipRepository.GetAll();
        }

        public IEnumerable<Iip> GetAllIips()
        {
            return _iipRepository.GetAll();
        }

        public IEnumerable<Tpd> GetAllTpds()
        {
            return _tpdRepository.GetAll();
        }

        public IEnumerable<ElRehab> GetAllElRehabs()
        {
            return _elRehabRepository.GetAll();
        }
    }
}
