using ITS.Core.BL.Implementation.ExtensionMethods;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using objmodel = ITS.Core.Data.Model.Reports;

namespace ITS.Core.BL.Implementation
{
    public class CaseAssessmentImpl : ICaseAssessment
    {
        private readonly ICaseAssessmentRepository _caseAssessmentRepository;
        private readonly ICaseAssessmentHistoryRepository _caseAssessmentHistoryRepository;
        private readonly ICaseAssessmentPatientImpactRepository _caseAssessmentPatientImpactRepository;
        private readonly ICaseAssessmentPatientInjuryRepository _caseAssessmentPatientInjuryRepository;
        private readonly ICaseAssessmentRatingRepository _caseAssessmentRatingRepository;
        private readonly ICaseAssessmentDetailRepository _caseAssessmentDetailRepository;

        private readonly ICaseAssessmentPatientInjuryHistoryRepository _caseAssessmentPatientInjuryHistoryRepository;
        private readonly ICaseAssessmentPatientImpactHistoryRepository _caseAssessmentPatientImpactHistoryRepository;

        private readonly ICaseAssessmentDetailHistoryRepository _caseAssessmentDetailHistoryRepository;

        private readonly ICaseAssessmentProposedTreatmentMethodRepository _caseAssessmentProposedTreatmentMethodRepository;
        private readonly ICaseAssessmentProposedTreatmentMethodHistoryRepository _caseAssessmentProposedTreatmentMethodHistoryRepository;
        private readonly ICasePatientRepository _casePatientRepository;
        private readonly ICaseAssessmentPatientInjury _caseAssessmentPatientInjury;




        public CaseAssessmentImpl(ICaseAssessmentRepository caseAssessmentRepository, ICaseAssessmentHistoryRepository caseAssessmentHistoryRepository, ICaseAssessmentPatientImpactRepository caseAssessmentPatientImpactRepository,
            ICaseAssessmentPatientInjuryRepository caseAssessmentPatientInjuryRepository, ICaseAssessmentRatingRepository caseAssessmentRatingRepository, ICaseAssessmentPatientImpactHistoryRepository caseAssessmentPatientImpactHistoryRepository,
            ICaseAssessmentPatientInjuryHistoryRepository caseAssessmentPatientInjuryRepositoryHistory, ICaseAssessmentDetailRepository caseAssessmentDetailRepository,ICasePatientRepository casePatientRepository,
            ICaseAssessmentDetailHistoryRepository caseAssessmentDetailHistoryRepository, ICaseAssessmentProposedTreatmentMethodRepository caseAssessmentProposedTreatmentMethodRepository, ICaseAssessmentProposedTreatmentMethodHistoryRepository caseAssessmentProposedTreatmentMethodHistoryRepository
            , ICaseAssessmentPatientInjury caseAssessmentPatientInjury)
        {
            _caseAssessmentRepository = caseAssessmentRepository;
            _caseAssessmentHistoryRepository = caseAssessmentHistoryRepository;
            _caseAssessmentPatientImpactRepository = caseAssessmentPatientImpactRepository;
            _caseAssessmentPatientInjuryRepository = caseAssessmentPatientInjuryRepository;
            _caseAssessmentRatingRepository = caseAssessmentRatingRepository;
            _caseAssessmentPatientImpactHistoryRepository = caseAssessmentPatientImpactHistoryRepository;
            _caseAssessmentPatientInjuryHistoryRepository = caseAssessmentPatientInjuryRepositoryHistory;
            _caseAssessmentDetailRepository = caseAssessmentDetailRepository;
            _caseAssessmentDetailHistoryRepository = caseAssessmentDetailHistoryRepository;
            _caseAssessmentProposedTreatmentMethodRepository = caseAssessmentProposedTreatmentMethodRepository;
            _caseAssessmentProposedTreatmentMethodHistoryRepository = caseAssessmentProposedTreatmentMethodHistoryRepository;
            _casePatientRepository = casePatientRepository;
            _caseAssessmentPatientInjury = caseAssessmentPatientInjury;
        }

        public int AddCaseAssessment(ITS.Core.BL.Model.CaseAssessment caseAssessment)
        {
            int caseID = 0;
            int caseAssessmentDetailHistoryID = 0;
            int caseAssessmentHistoryID = 0;

            caseAssessment.AssessmentAuthorisationID = Global.GlobalConst.CaseAssessment.AssessmentAuthorisationID;

            if (!_caseAssessmentRepository.GetCaseAssessmentExistsByCaseID(caseAssessment.CaseID))
            {
                caseAssessment.AssessmentServiceID = Global.GlobalConst.AssessmentService.InitialAssessment;
                caseID = _caseAssessmentRepository.AddCaseAssessment(caseAssessment.ToCaseAsssessmentDL());
                 caseAssessmentHistoryID = _caseAssessmentHistoryRepository.AddCaseAssessmentHistory(caseAssessment.ToCaseAsssessmentDL());
               
                caseAssessment.CaseAssessmentDetail.AssessmentServiceID = Global.GlobalConst.AssessmentService.InitialAssessment;
                caseAssessment.CaseAssessmentDetail.CaseAssessmentDetailID = _caseAssessmentDetailRepository.AddCaseAssessmentDetail(caseAssessment.CaseAssessmentDetail.ToCaseAssessmentDetailDL());
                caseAssessmentDetailHistoryID = _caseAssessmentDetailHistoryRepository.AddCaseAssessmentDetailHistory(caseAssessment.CaseAssessmentDetail.ToCaseAssessmentDetailDL());

                foreach (CaseAssessmentProposedTreatmentMethod proposed in caseAssessment.CaseAssessmentProposedTreatmentMethods.ToCaseAssessmentProposedTreatmentMethodsDL())
                    _caseAssessmentProposedTreatmentMethodRepository.AddCaseAssessmentProposedTreatmentMethod(proposed.CaseID, proposed.ProposedTreatmentMethodID);

                foreach (CaseAssessmentProposedTreatmentMethodHistory history in caseAssessment.CaseAssessmentProposedTreatmentMethods.ToCaseAssessmentProposedTreatmentMethodsHistoryDL(caseAssessmentHistoryID))
                    _caseAssessmentProposedTreatmentMethodHistoryRepository.AddCaseAssessmentProposedTreatmentMethodHistory(history);

            }
            else
            {                
                _caseAssessmentRepository.UpdateCaseAssessmentByCaseID(caseAssessment.ToCaseAsssessmentDL());// to update caseAssessment for IsSaved

                //_caseAssessmentRepository.UpdateIsPatientDischargeByCaseID(caseAssessment.CaseID, caseAssessment.IsPatientDischarge ?? false);
                if (caseAssessment.IsPatientDischarge ?? false)
                {
                    caseAssessment.AssessmentServiceID = Global.GlobalConst.AssessmentService.FinalAssessment;
                    caseAssessment.CaseAssessmentDetail.AssessmentServiceID = Global.GlobalConst.AssessmentService.FinalAssessment;
                }
                else
                {
                    caseAssessment.AssessmentServiceID = Global.GlobalConst.AssessmentService.ReviewAssessment;
                    caseAssessment.CaseAssessmentDetail.AssessmentServiceID = Global.GlobalConst.AssessmentService.ReviewAssessment;
                }

                _caseAssessmentRepository.UpdateAssessmentServiceIDByCaseID(caseAssessment.CaseID, caseAssessment.AssessmentServiceID);
                caseAssessment.CaseAssessmentDetail.CaseAssessmentDetailID = _caseAssessmentDetailRepository.AddCaseAssessmentDetail(caseAssessment.CaseAssessmentDetail.ToCaseAssessmentDetailDL());
                caseAssessmentDetailHistoryID = _caseAssessmentDetailHistoryRepository.AddCaseAssessmentDetailHistory(caseAssessment.CaseAssessmentDetail.ToCaseAssessmentDetailDL());
            }

            foreach (CaseAssessmentPatientInjury injury in caseAssessment.CaseAssessmentPatientInjuries.ToCaseAssessmentPatientInjuriesDL(caseAssessment.CaseAssessmentDetail.CaseAssessmentDetailID))
            {
                if (injury.OtherSymptomDesciption == null)
                    injury.OtherSymptomDesciption = DBNull.Value.ToString();
                _caseAssessmentPatientInjuryRepository.AddCaseAssessmentPatientInjury(injury);
            }

            foreach (CaseAssessmentPatientImpact impact in caseAssessment.CaseAssessmentPatientImpacts.ToCaseAssessmentPatientImpactsDL(caseAssessment.CaseAssessmentDetail.CaseAssessmentDetailID))
                _caseAssessmentPatientImpactRepository.AddCaseAssessmentPatientImpact(impact);


            foreach (CaseAssessmentPatientInjuryHistory history in caseAssessment.CaseAssessmentPatientInjuries.ToCaseAssessmentPatientInjuriesHistoryDL(caseAssessmentDetailHistoryID))
            {
                if (history.OtherSymptomDesciption == null)
                    history.OtherSymptomDesciption = DBNull.Value.ToString();
                _caseAssessmentPatientInjuryHistoryRepository.AddCaseAssessmentPatientInjuryHistory(history);
            }

            foreach (CaseAssessmentPatientImpactHistory history in caseAssessment.CaseAssessmentPatientImpacts.ToCaseAssessmentPatientImpactsHistoryDL(caseAssessmentDetailHistoryID))
                _caseAssessmentPatientImpactHistoryRepository.AddCaseAssessmentPatientImpactHistory(history);

            return caseID;
        }

        public int UpdateCaseAssessmentAuthorisationToModifiedByCaseID(int caseID, string authorisationDetail)
        {
            return _caseAssessmentRepository.UpdateCaseAssessmentAuthorisationByCaseID(caseID, Global.GlobalConst.AssessmentAuthorisation.MODIFIED, authorisationDetail);
        }

        public int UpdateCaseAssessmentAuthorisationToApprovedByCaseID(int caseID)
        {
            return _caseAssessmentRepository.UpdateCaseAssessmentAuthorisationByCaseID(caseID, Global.GlobalConst.AssessmentAuthorisation.APPROVED, null);
        }

        public int UpdateCaseAssessmentAuthorisationToDeniedByCaseID(int caseID, string deniedAuthorisation)
        {
            return _caseAssessmentRepository.UpdateCaseAssessmentAuthorisationByCaseID(caseID, Global.GlobalConst.AssessmentAuthorisation.DENIED, deniedAuthorisation);
        }

        public ITS.Core.BL.Model.CaseAssessment GetCaseAssessment(int caseID)
        {
            CaseAssessment caseAssessment = _caseAssessmentRepository.GetCaseAssessmentByCaseID(caseID);

            if (caseAssessment == null)
            {
                return null;
            }

            CaseAssessmentDetail caseAssessmentDetail = new CaseAssessmentDetail();
            //only return detail if caseassessment is rejected and not in review assessment
            if ((caseAssessment.AssessmentServiceID == Global.GlobalConst.AssessmentService.InitialAssessment ||
                caseAssessment.AssessmentServiceID == Global.GlobalConst.AssessmentService.ReviewAssessment ||
                caseAssessment.AssessmentServiceID == Global.GlobalConst.AssessmentService.FinalAssessment) && ((!caseAssessment.IsAccepted) || ((caseAssessment.IsSaved != null) ? caseAssessment.IsSaved.Value : false)))
            {
                var caseAssessmentDetails = _caseAssessmentDetailRepository.GetCaseAssessmentDetailByCaseIDAndAssessmentServiceID(caseAssessment.CaseID, caseAssessment.AssessmentServiceID);
                //for now get the latest detail using id value if there are multiple details for a given caseid and assessmentserviceID, this scenario could happen if there are multiple review assessment for a case.
                caseAssessmentDetail = caseAssessmentDetails.OrderByDescending(detail => detail.CaseAssessmentDetailID).First();
            }
            var caseAssessmentProposedTreatmentMethods = _caseAssessmentProposedTreatmentMethodRepository.GetCaseAssessmentProposedTreatmentMethodsByCaseID(caseID);
            var impacts = _caseAssessmentPatientImpactRepository.GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(caseAssessmentDetail.CaseAssessmentDetailID);
            var injuries = _caseAssessmentPatientInjury.GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(caseAssessmentDetail.CaseAssessmentDetailID);
            var rating = _caseAssessmentRatingRepository.GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(caseID, caseAssessment.AssessmentServiceID);
            return caseAssessment.ToCaseAsssessmentBL(impacts, injuries, rating, caseAssessmentDetail, caseAssessmentProposedTreatmentMethods);
        }
                 
        public ITS.Core.BL.Model.CaseAssessment GetCaseAssessmentQA(int caseID)
        {
            CaseAssessment caseAssessment = _caseAssessmentRepository.GetCaseAssessmentByCaseID(caseID);

            if (caseAssessment == null)
            {
                return null;
            }

            var caseAssessmentDetails = _caseAssessmentDetailRepository.GetCaseAssessmentDetailByCaseIDAndAssessmentServiceID(caseAssessment.CaseID, caseAssessment.AssessmentServiceID);
            //for now get the latest detail using id value if there are multiple details for a given caseid and assessmentserviceID, this scenario could happen if there are multiple review assessment for a case.
            var caseAssessmentDetail = caseAssessmentDetails.OrderByDescending(detail => detail.CaseAssessmentDetailID).First();
            var caseAssessmentProposedTreatmentMethods = _caseAssessmentProposedTreatmentMethodRepository.GetCaseAssessmentProposedTreatmentMethodsByCaseID(caseID);
            var impacts = _caseAssessmentPatientImpactRepository.GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(caseAssessmentDetail.CaseAssessmentDetailID);
            var injuries = _caseAssessmentPatientInjury.GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(caseAssessmentDetail.CaseAssessmentDetailID);
            var rating = _caseAssessmentRatingRepository.GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(caseID, caseAssessment.AssessmentServiceID);
            return caseAssessment.ToCaseAsssessmentBL(impacts, injuries, rating, caseAssessmentDetail, caseAssessmentProposedTreatmentMethods);
        }
        public int UpdateCaseAssessmentProposedTreatmentMethod(int caseID, int proposedTreatmentMethodID)
        {
            _caseAssessmentProposedTreatmentMethodRepository.DeleteCaseAssessmentProposedTreatmentMethodByCaseID(caseID);

            return _caseAssessmentProposedTreatmentMethodRepository.AddCaseAssessmentProposedTreatmentMethod(caseID, proposedTreatmentMethodID);
        }

        public int UpdateCaseAssessmentIsSavedByCaseID(int CaseID)
        {
            return _caseAssessmentRepository.UpdateCaseAssessmentIsSavedByCaseID(CaseID);
        }

        public int UpdateCaseAssessmentByCaseID(ITS.Core.BL.Model.CaseAssessment caseAssessment)
        {
            //TODO: this is need to be verify
            //NO MORE HISTORY DURING UPDATE
            int caseID = _caseAssessmentRepository.UpdateCaseAssessmentByCaseID(caseAssessment.ToCaseAsssessmentDL());

            
            if (caseAssessment.AssessmentServiceID == Global.GlobalConst.AssessmentService.InitialAssessment)
            {
                // Asper the task 2163.. need to update the Initial accessment date as user updated in stead of case book date.
                if (caseAssessment.CaseAssessmentDetail.AssessmentDate.ToString().Trim() != "")
                    _caseAssessmentProposedTreatmentMethodRepository.UpdateCaseAssessmentDateByCaseIDandAssessmentServiceID(caseAssessment.CaseID, caseAssessment.AssessmentServiceID, caseAssessment.CaseAssessmentDetail.AssessmentDate);

                _caseAssessmentProposedTreatmentMethodRepository.DeleteCaseAssessmentProposedTreatmentMethodByCaseID(caseAssessment.CaseID);
                foreach (CaseAssessmentProposedTreatmentMethod proposed in caseAssessment.CaseAssessmentProposedTreatmentMethods.ToCaseAssessmentProposedTreatmentMethodsDL())
                    _caseAssessmentProposedTreatmentMethodRepository.AddCaseAssessmentProposedTreatmentMethod(proposed.CaseID, proposed.ProposedTreatmentMethodID);
            }

            CaseAssessmentDetail caseAssessmentDetail = caseAssessment.CaseAssessmentDetail.ToCaseAssessmentDetailDL();

            if (caseAssessmentDetail != null && caseAssessmentDetail.CaseAssessmentDetailID == 0)
                return 0; // return 0 case detail should not be 0

            _caseAssessmentDetailRepository.UpdateCaseAssessmentDetailByCaseAssessmentDetailID(caseAssessment.CaseAssessmentDetail.ToCaseAssessmentDetailDL());

            int Count = 0;
            foreach (CaseAssessmentPatientInjury injury in caseAssessment.CaseAssessmentPatientInjuries.ToCaseAssessmentPatientInjuriesDL(caseAssessment.CaseAssessmentDetail.CaseAssessmentDetailID))
            {
                if (Count == 0)
                {
                    _caseAssessmentPatientInjuryRepository.DeleteCaseAssessmentPatientInjuryByCaseAssessmentDetailID(injury.CaseAssessmentDetailID);
                    Count++;
                }
                _caseAssessmentPatientInjuryRepository.AddCaseAssessmentPatientInjury(injury);

                //if (injury.CaseAssessmentPatientInjuryID == 0)
                //    _caseAssessmentPatientInjuryRepository.AddCaseAssessmentPatientInjury(injury);
                //else
                //    _caseAssessmentPatientInjuryRepository.UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID(injury);
            }

            foreach (CaseAssessmentPatientImpact impact in caseAssessment.CaseAssessmentPatientImpacts.ToCaseAssessmentPatientImpactsDL(caseAssessment.CaseAssessmentDetail.CaseAssessmentDetailID))
                _caseAssessmentPatientImpactRepository.UpdateCaseAssessmentPatientImpactByCaseAssessmentPatientImpactID(impact);

            CaseAssessmentRating caseAssessmentRating = caseAssessment.CaseAssessmentRating.ToCaseAsssessmentRatingDL();
            if (caseAssessmentRating != null && caseAssessmentRating.CaseAssessmentRatingID == 0)
                _caseAssessmentRatingRepository.AddCaseAssessmentRating(caseAssessmentRating);
            else if (caseAssessmentRating != null && caseAssessmentRating.CaseAssessmentRatingID != 0)
                _caseAssessmentRatingRepository.UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID(caseAssessmentRating.CaseID, caseAssessmentRating.AssessmentServiceID, caseAssessmentRating.Rating);

            return caseID;
        }
        public int UpdateCaseAssessmentHasPatientConsentFormByCaseId(int caseID, bool HasPatientConsentForm)
        {
            //TODO: this is need to be verify
            //NO MORE HISTORY DURING UPDATE
            int caseid = _caseAssessmentRepository.UpdateCaseAssessmentHasPatientConsentFormByCaseId(caseID, HasPatientConsentForm);

            
            return caseid;
        }
        //
        // TODO: need to be Implement
        public Model.CaseAssessment GetCaseAssessment(int caseID, int caseAssessmentDetailID)
        {
            CaseAssessment caseAssessment = _caseAssessmentRepository.GetCaseAssessmentByCaseID(caseID);

            if (caseAssessment == null)
            {
                return null;
            }

            CaseAssessmentDetail caseAssessmentDetail = new CaseAssessmentDetail();
            caseAssessmentDetail = _caseAssessmentDetailRepository.GetCaseAssessmentDetailByCaseAssessmentDetailID(caseAssessmentDetailID);
            if (caseAssessmentDetail == null)
            {
                return caseAssessment.ToCaseAsssessmentBL(null, null, null, null,null);
            }
            var caseAssessmentProposedTreatmentMethods = _caseAssessmentProposedTreatmentMethodRepository.GetCaseAssessmentProposedTreatmentMethodsByCaseID(caseID);
            var impacts = _caseAssessmentPatientImpactRepository.GetCaseAssessmentPatientImpactsByCaseAssessmentDetailID(caseAssessmentDetail.CaseAssessmentDetailID);
            var injuries = _caseAssessmentPatientInjury.GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(caseAssessmentDetail.CaseAssessmentDetailID);
            var rating = _caseAssessmentRatingRepository.GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(caseID, caseAssessment.AssessmentServiceID);
            return caseAssessment.ToCaseAsssessmentBL(impacts, injuries, rating, caseAssessmentDetail, caseAssessmentProposedTreatmentMethods);
        }

        public ReportsGenerateModels GetAllDataReportGenerated(int CaseID, string ReportType, int CaseAssessmentDetailID,int AssessmentServiceID)
        {
            ReportsGenerateModels objReportsGenerateModels = new ReportsGenerateModels();
           
            objReportsGenerateModels.CaseAssessmentProposedTreatmentMethodsAndValuesDetails = _caseAssessmentProposedTreatmentMethodRepository.GetCaseAssessmentProposedTreatmentMethodsAndValuesByCaseID(CaseID, ReportType).Select(proposedTreatment => new objmodel.CaseAssessmentProposedTreatmentMethodsAndValues().InjectFrom(proposedTreatment)).Cast<ITS.Core.Data.Model.Reports.CaseAssessmentProposedTreatmentMethodsAndValues>().ToList();
            objReportsGenerateModels.CaseAssessmentPatientImpactAndCaseAssessmentDetails = _caseAssessmentPatientImpactRepository.GetCaseAssessmentPatientImpactsAndValuesByCaseAssessmentDetailID(CaseAssessmentDetailID).Select(patientImpact => new objmodel.CaseAssessmentPatientImpactAndCaseAssessment().InjectFrom(patientImpact)).Cast<ITS.Core.Data.Model.Reports.CaseAssessmentPatientImpactAndCaseAssessment>().ToList();
            objReportsGenerateModels.CaseAssessmentPatientInjuryAndCaseAssessmentDetails = _caseAssessmentPatientInjuryRepository.GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailIDReports(CaseAssessmentDetailID).Select(patientInjuries => new objmodel.CaseAssessmentPatientInjuryAndCaseAssessment().InjectFrom(patientInjuries)).Cast<ITS.Core.Data.Model.Reports.CaseAssessmentPatientInjuryAndCaseAssessment>().ToList();
            objReportsGenerateModels.CaseAssessmentsDetails = _caseAssessmentRepository.GetCaseAssessmentAndValuesByCaseID(CaseID);
            objReportsGenerateModels.CaseAssessmentsDetailsModel=_caseAssessmentDetailRepository.GetCaseAssessmentDetailAndValuesByCaseIDAndAssessmentServiceID(CaseID,AssessmentServiceID);
            objReportsGenerateModels.PatientAndCaseDetails = _casePatientRepository.GetPatientAndCaseByCaseIDReports(CaseID);

            return objReportsGenerateModels;
        }

        public int AddReferrerCaseAssessmentModification(ReferrerCaseAssessmentModification referrerCaseAssessmentModification)
        {
            return _caseAssessmentRepository.AddReferrerCaseAssessmentModification(referrerCaseAssessmentModification);
        }


        public IEnumerable<ReferrerCaseAssessmentModificationAuthority> GetCaseTreatmentPricingByCaseID(int CaseID)
        {
          
            return _caseAssessmentRepository.GetCaseTreatmentPricingByCaseID(CaseID);
        }

        public IEnumerable<ReferrerCaseAssessmentModification> GetReferrerCaseAssessmentModificationsbyCaseID(int CaseID)
        {

            return _caseAssessmentRepository.GetReferrerCaseAssessmentModificationsbyCaseID(CaseID);
        }
    }
}