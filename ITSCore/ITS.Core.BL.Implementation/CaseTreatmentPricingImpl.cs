using ITS.Core.Data;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Core.BL.Implementation
{
    public class CaseTreatmentPricingImpl : ICaseTreatmentPricing
    {
        private readonly ICaseTreatmentPricingRepository _caseTreatmentPricingRepository;

        private readonly ISupplierTreatmentPricingRepository _supplierTreatmentPricingRepository;
        private readonly ISupplierTreatmentRepository _supplierTreatmentRepository;
        private readonly IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;
        private readonly IReferrerProjectTreatmentRepository _referrerProjectTreatmentRepository;

        public CaseTreatmentPricingImpl(ICaseTreatmentPricingRepository caseTreatmentPricingRepository, ISupplierTreatmentPricingRepository supplierTreatmentPricingRepository, ISupplierTreatmentRepository supplierTreatmentRepository, IReferrerProjectTreatmentPricingRepository referrerProjectTreatmentPricingRepository, IReferrerProjectTreatmentRepository referrerProjectTreatmentRepository)
        {
            _caseTreatmentPricingRepository = caseTreatmentPricingRepository;

            _supplierTreatmentPricingRepository = supplierTreatmentPricingRepository;
            _supplierTreatmentRepository = supplierTreatmentRepository;
            _referrerProjectTreatmentPricingRepository = referrerProjectTreatmentPricingRepository;
            _referrerProjectTreatmentRepository = referrerProjectTreatmentRepository;
        }


        public int AddCaseTreatmentPricing(IEnumerable<CaseTreatmentPricing> caseTreatmentPricings)
        {
            int id = 0;

            foreach (CaseTreatmentPricing caseTreatmentPricing in caseTreatmentPricings)
            {
                id = _caseTreatmentPricingRepository.AddCaseTreatmentPricing(caseTreatmentPricing);
            }

            return id;
        }

        public int AddCaseTreatmentPricingCaseSearch(CaseTreatmentPricing caseTreatmentPricings)
        {
            int id = 0;

            id = _caseTreatmentPricingRepository.AddCaseTreatmentPricing(caseTreatmentPricings);
            

            return id;
        }

        public int UpdateCaseTreatmentPricing(IEnumerable<CaseTreatmentPricing> caseTreatmentPricings)
        {
            int id = 0;
            foreach (CaseTreatmentPricing caseTreatmentPricing in caseTreatmentPricings)
            {
                if (caseTreatmentPricing.CaseTreatmentPricingID == 0)
                    id = _caseTreatmentPricingRepository.AddCaseTreatmentPricing(caseTreatmentPricing);
                else
                    if (caseTreatmentPricing.IsChanged == 1)
                        id = _caseTreatmentPricingRepository.UpdateCaseTreatmentPricing(caseTreatmentPricing);
            }
            return id;
        }
        public IEnumerable<CaseTreatmentPricing> GetCaseTreatmentPricingByCaseID(int caseID)
        {
            return _caseTreatmentPricingRepository.GetCaseTreatmentPricingByCaseID(caseID);
        }

        public int GetCheckCaseTreatmentPricingByCaseID(int caseID, int AssessmentServiceID)
        {
            return _caseTreatmentPricingRepository.GetCheckCaseTreatmentPricingByCaseID(caseID, AssessmentServiceID);
        }

        public IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDAndComplete(int caseID)
        {
            return _caseTreatmentPricingRepository.GetCaseTreatmentPricingByCaseIDAndIsComplete(caseID, true);
        }

        public IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDCaseSearch(int caseID)
        {
            return _caseTreatmentPricingRepository.GetCaseTreatmentPricingByCaseIDCaseSearch(caseID);
        }

        public IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingsForInvoice(int caseID)
        {
            return _caseTreatmentPricingRepository.GetCaseTreatmentPricingByCaseIDAndIsComplete(caseID, true).Where(caseTreatmentPricing => (!caseTreatmentPricing.WasAbandoned ?? true));
        }

        public IEnumerable<CaseTreatmentPricingType> GetCaseTreatmentPricingByCaseIDAndInComplete(int caseID)
        {
            return _caseTreatmentPricingRepository.GetCaseTreatmentPricingByCaseIDAndIsComplete(caseID, false);
        }


        public int UpdateCaseTreatmentPricingByCaseTreatmentPricingID(CaseTreatmentPricing caseTreatmentPricing)
        {
            var patientDidnotShow = caseTreatmentPricing.PatientDidNotAttend.HasValue ? caseTreatmentPricing.PatientDidNotAttend.Value : false;

            if (patientDidnotShow)
            {
                // ---- NEED TO OPTIMIZE --//
                var supplierTreatmentPricing = _supplierTreatmentPricingRepository.GetById(caseTreatmentPricing.SupplierPriceID);
                var supplierTreatmentPricingID = supplierTreatmentPricing.SupplierTreatmentID;
                var supplierID = _supplierTreatmentRepository.GetById(supplierTreatmentPricingID).SupplierID;
                var referrerProjectTreatment = _referrerProjectTreatmentPricingRepository.GetById(caseTreatmentPricing.ReferrerPricingID);
                var referrerProjectTreatmentID = referrerProjectTreatment.ReferrerProjectTreatmentID;
                var treatmentCategoryID = _referrerProjectTreatmentRepository.GetById(referrerProjectTreatmentID).TreatmentCategoryID;
                // ---- NEED TO OPTIMIZE --//

                var pricingTypeID = Global.GlobalConst.PricingType.DIDNOTSHOW;

                var caseTreatmentPricePricings = _caseTreatmentPricingRepository.GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentIDAndPricingTypeID(supplierID, referrerProjectTreatmentID, treatmentCategoryID, pricingTypeID);

                caseTreatmentPricing.ReferrerPrice = caseTreatmentPricePricings.ReferrerPrice;
                caseTreatmentPricing.ReferrerPricingID = caseTreatmentPricePricings.ReferrerPricingID;
                caseTreatmentPricing.SupplierPriceID = caseTreatmentPricePricings.SupplierPriceID;
                caseTreatmentPricing.SupplierPrice = caseTreatmentPricePricings.SupplierPrice;

                return _caseTreatmentPricingRepository.UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID(caseTreatmentPricing);
            }

            return _caseTreatmentPricingRepository.UpdateCaseTreatmentPricingByCaseTreatmentPricingID(caseTreatmentPricing);
        }

        public IEnumerable<TreatmentReferrerSupplierPricing> GetTreatmentReferrerSupplierPricing(int supplierID, int referrerProjectTreatmentID, int treatmentCategoryID)
        {
            return _caseTreatmentPricingRepository.GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID(supplierID, referrerProjectTreatmentID, treatmentCategoryID);
        }

        public IEnumerable<TreatmentReferrerSupplierPricing> GetTreatmentReferrerSupplierPricingQA(int supplierID, int referrerProjectTreatmentID, int treatmentCategoryID)
        {
            return _caseTreatmentPricingRepository.GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID(supplierID, referrerProjectTreatmentID, treatmentCategoryID);
                //.Where(pricing => pricing.PricingTypeID == Global.GlobalConst.PricingType.INITIALASSESSMENT || pricing.PricingTypeID == Global.GlobalConst.PricingType.REVIEWASSESSMENT ||
                //       pricing.PricingTypeID == Global.GlobalConst.PricingType.FINALASSESSMENT || pricing.PricingTypeID == Global.GlobalConst.PricingType.TREATMENTSESSION);
        }

        public int UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID(CaseTreatmentPricing caseTreatmentPricing)
        {
            return _caseTreatmentPricingRepository.UpdateCaseTreatmentPricingPriceByCaseTreatmentPricingID(caseTreatmentPricing);
        }
        public int UpdateCaseTreatmentPricingPriceByReferrerPricingID(CaseTreatmentPricingCaseSearch caseTreatmentPricing)
        {
            return _caseTreatmentPricingRepository.UpdateCaseTreatmentPricingPriceByReferrerPricingID(caseTreatmentPricing);
        }
        

        public int DeleteCaseTreatmentPricingByCaseTreatmentPricingID(int caseTreatmentPricingID)
        {
            return _caseTreatmentPricingRepository.DeleteCaseTreatmentPricingByCaseTreatmentPricingID(caseTreatmentPricingID);
        }

        public int DeleteCaseTreatmentPricingByCaseIDCaseStopped(int caseID)
        {
            return _caseTreatmentPricingRepository.DeleteCaseTreatmentPricingByCaseIDCaseStopped(caseID);
        }

        public int UpdateCaseTreatmentPricingAuthorisationStatusByCaseID(int caseID)
        {
            return _caseTreatmentPricingRepository.UpdateCaseTreatmentPricingAuthorisationStatusByCaseID(caseID);
        }


        public int UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID(int caseTreatmentPricingID, decimal referrerPrice, int referrerPricingID, DateTime dateOfService)
        {
            return _caseTreatmentPricingRepository.UpdateCaseTreatmentReferrerPriceByCaseTreatmentPricingID(caseTreatmentPricingID, referrerPrice,referrerPricingID,dateOfService);
        }
        public EPNATreatmentSession GetEPNATreatmentSessionDetail(int caseID)
        {
            return _caseTreatmentPricingRepository.GetEPNATreatmentSessionDetail(caseID);
        }
        public TreatmentSessionByCaseID GetTreatmentSessionByCaseID(int caseID)
        {
            return _caseTreatmentPricingRepository.GetTreatmentSessionByCaseID(caseID);
        }
    }
}
