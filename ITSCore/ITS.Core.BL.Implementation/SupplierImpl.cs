using ITS.Core.BL.Model;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

#region Comment
/*
 Page Name:  SupplierImpl.cs                      
 Latest Version:  1.2
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 11-17-2012
  Version : 1.0
  Description : Add method For Get_SupplierBySupplierID
  Description : Add method For Get_SuppliersLikeSupplierName
  Description : Add method For Add_Supplier
  Description : Add method For Update_SupplierBySupplierID
 * ===================================================================================
  Edited By : Satya
  Date : 12-18-2012
  Version : 1.1
  Description : Add method For AddSupplierandTreatmentTypes
===================================================================================
  Edited By : Anuj Batra
  Date : 12-18-2012
  Version : 1.2
  Description : Add method For GetSuppliersLikePostCode
===================================================================================
*/
#endregion
namespace ITS.Core.BL.Implementation
{
    public class SupplierImpl : ISupplier
    {

        private readonly ISupplierRepository _supplierRepository;
        private readonly ISupplierTreatmentRepository _supplierTreatmentRepository;
        private readonly ICaseRepository _caseRepository;
        private readonly IClinicalAuditTotalCountAndPassAuditRepository _clinicalAuditTotalCountRepository;
        private readonly ISiteAuditTotalCountAndAuditPassRepository _siteAuditTotalCountRepository;
        private readonly ICaseAssessmentTotalCountAndRatingRepository _caseAssessmentTotalCountRepository;
        private readonly IUKPostCodeRepository _postCodeRepository;
        private readonly ISupplierDistanceRankingRepository _supplierDistanceRepository;
        private readonly ISupplierTreatmentPricingRepository _supplierTreatmentPricingRepository;


        public SupplierImpl(ISupplierRepository supplierRepository, ISupplierTreatmentRepository supplierTreatmentRepository)
        {
            _supplierRepository = supplierRepository;
            _supplierTreatmentRepository = supplierTreatmentRepository;
        }

        public SupplierImpl(ISupplierRepository supplierRepository, ISupplierTreatmentRepository supplierTreatmentRepository, ICaseRepository caseRepository,
            IClinicalAuditTotalCountAndPassAuditRepository clinicalAuditTotalCountRepository, ISiteAuditTotalCountAndAuditPassRepository siteAuditTotalCountRepository,
            ICaseAssessmentTotalCountAndRatingRepository caseAssessmentTotalCountRepository, IUKPostCodeRepository postCodeRepository, ISupplierDistanceRankingRepository supplierDistanceRepository, ISupplierTreatmentPricingRepository supplierTreatmentPricingRepository)
        {
            _supplierRepository = supplierRepository;
            _supplierTreatmentRepository = supplierTreatmentRepository;
            _caseRepository = caseRepository;
            _clinicalAuditTotalCountRepository = clinicalAuditTotalCountRepository;
            _siteAuditTotalCountRepository = siteAuditTotalCountRepository;
            _caseAssessmentTotalCountRepository = caseAssessmentTotalCountRepository;
            _postCodeRepository = postCodeRepository;
            _supplierDistanceRepository = supplierDistanceRepository;
            _supplierTreatmentPricingRepository = supplierTreatmentPricingRepository;
        }

        public Supplier GetSupplierBySupplierID(int supplierID)
        {
            return _supplierRepository.GetSupplierBySupplierID(supplierID);
        }


        public int AddSupplier(Supplier supplier)
        {
            return _supplierRepository.AddSupplier(supplier);
        }

        public int UpdateSupplierBySupplierID(Supplier supplier)
        {
            return _supplierRepository.UpdateSupplierBySupplierID(supplier);
        }

        public IEnumerable<Supplier> GetAllSupplier()
        {
            return _supplierRepository.GetAll();

        }

        public int AddSupplierAndTreatmentTypes(Supplier supplier, IEnumerable<SupplierTreatment> supplierTreatments)
        {
            int supplierID = _supplierRepository.AddSupplier(supplier);

            foreach (SupplierTreatment supplierTreatment in supplierTreatments)
            {
                supplierTreatment.SupplierID = supplierID;
                _supplierTreatmentRepository.AddSupplierTreatment(supplierTreatment);
            }

            return supplierID;
        }

        public IEnumerable<SupplierCasePatient> GetSupplierNewPatientCases(int supplierID)
        {
            const int workflowIDReferredToSupplier = Global.GlobalConst.WorkFlow.ReferredtoSupplier;
            const int workflowIDReferredToTriageAssessment = Global.GlobalConst.WorkFlow.ReferreredtoTriageSupplier;
            const int workflowIDInitialAssessmentCustom = Global.GlobalConst.WorkFlow.InitialAssessmentSupplierCustom;
            
            return _caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDReferredToSupplier).Union(_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDReferredToTriageAssessment)).Union
                (_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDInitialAssessmentCustom));
        }

        public IEnumerable<SupplierCasePatient> GetSupplierExistingPatientsInitialAssessments(int supplierID)
        {
            const int workflowIDInitialAssessmentBooked = Global.GlobalConst.WorkFlow.InitialAssessmentBooked;
            const int workflowIDInitialAssessmentAttended = Global.GlobalConst.WorkFlow.InitialAssessmentAttended;
            const int workflowIDReportNotAccepted = Global.GlobalConst.WorkFlow.ReportNotAccepted;
            const int workflowIDReportNotAcceptedCustom = Global.GlobalConst.WorkFlow.ReportNotAcceptedCustom;
            return _caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDInitialAssessmentBooked)
                                  .Union(_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDInitialAssessmentAttended)).Union(_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDReportNotAccepted)).Union(_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDReportNotAcceptedCustom));
        }

        public IEnumerable<SupplierCasePatient> GetSupplierExistingPatientsNextAssessments(int supplierID)
        {
            const int workflowIDReviewAssessmentReportNotAccepted = Global.GlobalConst.WorkFlow.ReviewAssessmentReportNotAccepted;
            const int workflowIDFinalAssessmentReportNotAccepted = Global.GlobalConst.WorkFlow.FinalAssessmentReportNotAccepted;
         
            return _caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment).Union(_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatmentCustom)).Union(_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDReviewAssessmentReportNotAccepted)).Union(_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDFinalAssessmentReportNotAccepted));
        }

        public IEnumerable<SupplierCasePatient> GetSupplierAuthorisations(int supplierID)
        {

            return _caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, Global.GlobalConst.WorkFlow.PatientInTreatment).Union(_caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, Global.GlobalConst.WorkFlow.PatientInTreatmentCustom));
        }

        public IEnumerable<SupplierCasePatient> GetSupplierStoppedCases(int supplierID)
        {
            return _caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, Global.GlobalConst.WorkFlow.CaseStoppedSenttoSupplier);
        }

        public double GetSupplierRankingBySupplierID(int supplierID)
        {
            ClinicalAuditTotalCountAndPassAudit totalClinicalAuditCount = _clinicalAuditTotalCountRepository.GetClinicalAuditTotalCountAndPassAuditsBySupplierID(supplierID);
            SiteAuditTotalCountAndAuditPass totalSiteAuditCount = _siteAuditTotalCountRepository.GetSiteAuditTotalCountAndAuditPassBySupplierID(supplierID);
            CaseAssessmentTotalCountAndRating totalCaseAssessmentCount = _caseAssessmentTotalCountRepository.GetCaseAssessmentTotalCountAndRatingBySupplierID(supplierID);

            int totalAssessmentCountValue = totalCaseAssessmentCount == null ? 0 : totalCaseAssessmentCount.AssessmentTotal * 10;
            double assessmentRatingValue = totalCaseAssessmentCount == null ? 0 : Convert.ToDouble(totalCaseAssessmentCount.RatingTotal);

            double clinicalAuditRatingValue = totalClinicalAuditCount == null ? double.NaN : totalClinicalAuditCount.AuditPassCount;
            double clinicalAuditCount = totalClinicalAuditCount == null ? 0 : totalClinicalAuditCount.SupplierClinicalAuditCount;

            double siteAuditRatingValue = totalSiteAuditCount == null ? double.NaN : totalSiteAuditCount.AuditPassCount;
            double siteAuditCount = totalSiteAuditCount == null ? 0 : totalSiteAuditCount.SiteAuditCount;

            bool isAssessmentRatingValueNaN = double.IsNaN(assessmentRatingValue);
            bool isClinicalAuditRatingValueNaN = double.IsNaN(clinicalAuditRatingValue);
            bool isSiteAuditRatingValueNaN = double.IsNaN(siteAuditRatingValue);

            if (isAssessmentRatingValueNaN && isClinicalAuditRatingValueNaN && isSiteAuditRatingValueNaN)
                return double.NaN;
            else
            {
                assessmentRatingValue = isAssessmentRatingValueNaN ? 0 : assessmentRatingValue;
                clinicalAuditRatingValue = isClinicalAuditRatingValueNaN ? 0 : clinicalAuditRatingValue;
                siteAuditRatingValue = isSiteAuditRatingValueNaN ? 0 : siteAuditRatingValue;
            }

            double totalRatingValue = ((assessmentRatingValue + siteAuditRatingValue + clinicalAuditRatingValue) / (totalAssessmentCountValue + siteAuditCount + clinicalAuditCount)) * 100;
            return totalRatingValue;
        }


        public IEnumerable<ITS.Core.BL.Model.PriceAverage> GetSupplierPriceAverage(int supplierID, int treatmentCategoryID)
        {
            var result = _supplierTreatmentRepository.GetSupplierPriceAverage(supplierID, treatmentCategoryID).ToList();
            List<ITS.Core.BL.Model.PriceAverage> PriceAverages = new List<Model.PriceAverage>();
            foreach (var item in result)
            {
                PriceAverages.Add(new Model.PriceAverage() { Price = item.Price, PricingTypeID = item.PricingTypeID });
            }
            return PriceAverages.AsEnumerable();
        }

        public IEnumerable<SupplierDistanceRankPrice> GetSupplierWithinPostCode(string postCode, int distanceKM, int treatmentCategoryID)
        {

            UKPostCode postCodeInfo = _postCodeRepository.GetPostCodeInfo(postCode);
            if (postCodeInfo == null)
                return null;

            IEnumerable<SupplierDistanceRanking> suppliers = _supplierDistanceRepository.GetSupplierWithinArea(postCodeInfo.RadiansLatitude, postCodeInfo.RadiansLongitude, distanceKM, treatmentCategoryID);
            IList<SupplierDistanceRankPrice> supplierRanks = new List<SupplierDistanceRankPrice>();

            foreach (SupplierDistanceRanking supplier in suppliers)
            {
                supplierRanks.Add(new SupplierDistanceRankPrice
                {
                    Address = supplier.Address,
                    Distance = supplier.Distance,
                    Phone = supplier.Phone,
                    PostCode = supplier.PostCode,
                    SupplierName = supplier.SupplierName,
                    SupplierID = supplier.SupplierID,
                    Ranking = GetSupplierRankingBySupplierID(supplier.SupplierID),
                    PriceAverages = GetSupplierPriceAverage(supplier.SupplierID, treatmentCategoryID)
                });
            }

            return supplierRanks;
        }

        public IEnumerable<SuppliersName> GetAllSupplierWithinPostCode(string postCode, int distanceKM, int treatmentCategoryID)
        {

            UKPostCode postCodeInfo = _postCodeRepository.GetPostCodeInfo(postCode);
            if (postCodeInfo == null)
                return null;
            IEnumerable<SuppliersName> suppliers = _supplierDistanceRepository.GetAllSupplierWithinArea(postCodeInfo.RadiansLatitude, postCodeInfo.RadiansLongitude, distanceKM, treatmentCategoryID);
            return suppliers;
        }

        public SupplierDistanceRankPrice GetSelectedSupplierDistanceRankPrice(int supplierID, int treatmentCategoryID, string postCode)
        {
            UKPostCode postCodeInfo = _postCodeRepository.GetPostCodeInfo(postCode);
            if (postCodeInfo == null)
                return null;

            SupplierDistanceRanking supplier = _supplierDistanceRepository.GetSupplierWithinAreaBySupplierID(postCodeInfo.RadiansLatitude, postCodeInfo.RadiansLongitude, 10000, treatmentCategoryID, supplierID).FirstOrDefault();

            if (supplier == null)
                return null;


            SupplierDistanceRankPrice supplierRank = new SupplierDistanceRankPrice()
                 {
                     Address = supplier.Address,
                     Distance = supplier.Distance,
                     Phone = supplier.Phone,
                     PostCode = supplier.PostCode,
                     SupplierName = supplier.SupplierName,
                     SupplierID = supplier.SupplierID,
                     Ranking = GetSupplierRankingBySupplierID(supplier.SupplierID),
                     PriceAverages = GetSupplierPriceAverage(supplier.SupplierID, treatmentCategoryID)
                 };


            return supplierRank;
        }






        public int UpdateSupplierStatus(int supplierID, bool isTriage)
        {
            IEnumerable<SupplierTreatment> supplierTreatments = _supplierTreatmentRepository.GetSupplierTreatmentBySupplierID(supplierID).Where(suppliertreatment => suppliertreatment.Enabled == true).ToList();

            if (supplierTreatments.Count() == 0)
            {
                _supplierRepository.UpdateSupplierStatusBySupplierID(supplierID, 2);
                return 2;
            }

            foreach (SupplierTreatment supplierTreatment in supplierTreatments)
            {
                //IEnumerable<SupplierTreatmentPricing> _supplierPricings = _supplierTreatmentPricingRepository.GetSupplierTreatmentPricingBySupplierTreatmentId(supplierTreatment.SupplierTreatmentID).ToList();
                IEnumerable<SupplierPricingValue> _supplierPricings = _supplierTreatmentPricingRepository.GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID(supplierTreatment.SupplierTreatmentID, supplierTreatment.TreatmentCategoryID).ToList();

                if (_supplierPricings.Count() == 0)
                {
                    _supplierRepository.UpdateSupplierStatusBySupplierID(supplierID, 2);
                    return 2;
                }

                if (isTriage)
                {
                    if (_supplierPricings.Any(supplierPrice => (!supplierPrice.Price.HasValue || supplierPrice.Price == 0) && supplierPrice.PricingTypeID == Global.GlobalConst.PricingType.TRIAGEASSESSMENT && supplierPrice.PricingID == Global.GlobalConst.PricingType.VAT))
                    {
                        _supplierRepository.UpdateSupplierStatusBySupplierID(supplierID, 2);
                        return 2;
                    }
                }
                else
                {
                    if (_supplierPricings.Any(supplierPrice => (!supplierPrice.Price.HasValue || supplierPrice.Price == 0) && supplierPrice.PricingTypeID != Global.GlobalConst.PricingType.TRIAGEASSESSMENT && supplierPrice.PricingID != Global.GlobalConst.PricingType.VAT))
                    {
                        _supplierRepository.UpdateSupplierStatusBySupplierID(supplierID, 2);
                        return 2;
                    }
                }
            }

            _supplierRepository.UpdateSupplierStatusBySupplierID(supplierID, 1);
            return 1;

        }

        public bool GetSupplierExistsByName(string supplierName)
        {
            return _supplierRepository.GetSupplierExistsByName(supplierName);
        }


        public IEnumerable<Supplier> GetSuppliersRecentlyAdded()
        {
            return _supplierRepository.GetSuppliersRecentlyAdded();
        }



        public IEnumerable<SuppliersName> GetAllSuppliers()
        {
            return _supplierRepository.GetAllSuppliers();
        }


        public bool GetSupplierExistsByEmail(string email)
        {
            return _supplierRepository.GetSupplierExistsByEmail(email);
        }
    }
}
