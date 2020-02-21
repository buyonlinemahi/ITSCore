using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
 Page Name:  ReferrerProjectTreatmentImpl.cs          
                                                           
    1.0 – 11/07/2012 Satya   
 * Created class TreatmentCategoryImpl with a method to GetAll
 * 
 */
namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentImpl : IReferrerProjectTreatment
    {
        private readonly IReferrerProjectTreatmentRepository _referrerProjectTreatmentRepository;
        
        
        private readonly IAssessmentServiceRepository _assessmentServiceRepository;
        private readonly IAssessmentTypeRepository _assessmentTypeRepository;

        private readonly IReferrerProjectTreatmentAuthorisationRepository _referrerProjectTreatmentAuthorisationRepository;
        private readonly IDelegatedAuthorisationRepository _delegatedAuthorisationRepository;

        private readonly IReferrerProjectTreatmentEmailRepostory _referrerProjectTreatmentEmailRepostory;
        private readonly IEmailTypeRepository _emailTypeRepository;

        private readonly IReferrerProjectTreatmentAssessmentRepository _referrerProjectTreatmentAssessmentRepository;

        private readonly IReferrerProjectTreatmentInvoiceRepository _referrerProjectTreatmentInvoiceRepository;
        private readonly IReferrerProjectTreatmentDocumentSetupRepository _referrerProjectTreatmentDocumentSetupRepository;

        private readonly IServiceLevelAgreementRepository _serviceLevelAgreementRepository;
        private readonly IProjectTreatmentSLARepository _projectTreatmentSLARepository;

        private readonly IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;

        public ReferrerProjectTreatmentImpl(IReferrerProjectTreatmentRepository referrerProjectTreatmentRepository, IReferrerProjectTreatmentAssessmentRepository referrerProjectTreatmentAssessmentRepository,
            IAssessmentServiceRepository assessmentServiceRepository, IAssessmentTypeRepository assessmentTypeRepository, IReferrerProjectTreatmentAuthorisationRepository referrerProjectTreatmentAuthorisationRepository, IReferrerProjectTreatmentEmailRepostory referrerProjectTreatmentEmailRepostory, IDelegatedAuthorisationRepository delegatedAuthorisationRepository, IEmailTypeRepository emailTypeRepository, IReferrerProjectTreatmentInvoiceRepository referrerProjectTreatmentInvoiceRepository, IReferrerProjectTreatmentDocumentSetupRepository referrerProjectTreatmentDocumentSetupRepository, IServiceLevelAgreementRepository serviceLevelAgreementRepository, IProjectTreatmentSLARepository projectTreatmentSLARepository, IReferrerProjectTreatmentPricingRepository referrerProjectTreatmentPricingRepository)
        {
            _referrerProjectTreatmentRepository = referrerProjectTreatmentRepository;
            _referrerProjectTreatmentAssessmentRepository = referrerProjectTreatmentAssessmentRepository;
            _assessmentServiceRepository = assessmentServiceRepository;
            _assessmentTypeRepository = assessmentTypeRepository;
            _referrerProjectTreatmentAuthorisationRepository = referrerProjectTreatmentAuthorisationRepository;
            _referrerProjectTreatmentEmailRepostory = referrerProjectTreatmentEmailRepostory;
            _delegatedAuthorisationRepository = delegatedAuthorisationRepository;
            _emailTypeRepository = emailTypeRepository;
            _referrerProjectTreatmentInvoiceRepository = referrerProjectTreatmentInvoiceRepository;
            _referrerProjectTreatmentDocumentSetupRepository = referrerProjectTreatmentDocumentSetupRepository;
            _serviceLevelAgreementRepository = serviceLevelAgreementRepository;
            _projectTreatmentSLARepository = projectTreatmentSLARepository;
            _referrerProjectTreatmentPricingRepository = referrerProjectTreatmentPricingRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// referrerprojectauthorisation, referrerprojectassessment, "referrerprojectdocumentsetup", referrerprojectemailsetup 
        /// </summary>
        /// <param name="referrerProjectTreatment"></param>
        /// <returns></returns>
        public int AddReferrerProjectTreatment(ReferrerProjectTreatment referrerProjectTreatment)
        {
            referrerProjectTreatment.Enabled = true;
            int referrerProjectTreatmentID = _referrerProjectTreatmentRepository.GetReferrerProjectTreatmentExistsByReferrerProjectIDAndTreatmentCategoryID(referrerProjectTreatment) != null ? -1 : _referrerProjectTreatmentRepository.AddReferrerProjectTreatment(referrerProjectTreatment);

            if (referrerProjectTreatmentID == -1)
            {
                return referrerProjectTreatmentID;
            }
            //add default referrerproject treatment assessment
            
            int defaultAssessmentType = 1;//_assessmentTypeRepository.GetAll(type => type.AssessmentTypeName.Equals("Default", StringComparison.CurrentCultureIgnoreCase)).SingleOrDefault().AssessmentTypeID;
            foreach (var assessmentService in _assessmentServiceRepository.GetAll())
            {
                _referrerProjectTreatmentAssessmentRepository.AddReferrerProjectTreatmentAssignment(new ReferrerProjectTreatmentAssessment { AssessmentServiceID = assessmentService.AssessmentServiceID, AssessmentTypeID = defaultAssessmentType, ReferrerProjectTreatmentID = referrerProjectTreatmentID });

            }

            //look at adding treatmentassessment for default values.


            //default delegated authorisation type for the selected treatmentcategory id is 2(for cost) and default Amount value is 0
  
            _referrerProjectTreatmentAuthorisationRepository.AddReferrerProjectTreatmentAuthorisation(new ReferrerProjectTreatmentAuthorisation { Amount = 0, DelegatedAuthorisationTypeID = Global.GlobalConst.DelegatedAuthorisationType.Cost, ReferrerProjectTreatmentID = referrerProjectTreatmentID, TreatmentCategoryID = referrerProjectTreatment.TreatmentCategoryID, Enabled = true, Quantity = null });


            _referrerProjectTreatmentAuthorisationRepository.AddReferrerProjectTreatmentAuthorisation(new ReferrerProjectTreatmentAuthorisation { Amount = null, DelegatedAuthorisationTypeID = Global.GlobalConst.DelegatedAuthorisationType.Session, ReferrerProjectTreatmentID = referrerProjectTreatmentID, TreatmentCategoryID = referrerProjectTreatment.TreatmentCategoryID, Quantity = 0, Enabled = false });


            
            //add default invoice method  - default invoice method is 1 = Standard
            int defaultInvoiceMethodID = 1;
            _referrerProjectTreatmentInvoiceRepository.AddReferrerProjectTreatmentInvoice(new ReferrerProjectTreatmentInvoice { ReferrerProjectTreatmentID = referrerProjectTreatmentID, InvoiceMethodID = defaultInvoiceMethodID });


            //loop thru each emailtypes and add default email type value. the default emailtype value will be 1 which is 'Default' 
            int defaultEmailTypeValueID = 1;
            foreach (var emailTypeService in _emailTypeRepository.GetAll())
            {
                _referrerProjectTreatmentEmailRepostory.AddReferrerProjectTreatmentEmail(new ReferrerProjectTreatmentEmail { EmailTypeID = emailTypeService.EmailTypeID, EmailTypeValueID = defaultEmailTypeValueID, ReferrerProjectTreatmentID = referrerProjectTreatmentID });

            } 

            //default document setup is 1 or default

            int defaultDocumentSetupTypeID = 1;
            foreach (var assessmentService in _assessmentServiceRepository.GetAll())
            {
                _referrerProjectTreatmentDocumentSetupRepository.AddReferrerProjectTreatmentDocumentSetup(new ReferrerProjectTreatmentDocumentSetup { AssessmentServiceID = assessmentService.AssessmentServiceID, DocumentSetupTypeID = defaultDocumentSetupTypeID, ReferrerProjectTreatmentID = referrerProjectTreatmentID });

            }
            
            //loop thru each service level agreements table/repository and insert each servicelevel agreements into ProjectTreatmentSLAs with their corresponding default values.
         
            int defaultNumberOfDays;
            foreach (var serviceLevelAgreementService in _serviceLevelAgreementRepository.GetAll())
            {
                //Default values: All of them should be enabled by default.
                //ServiceLevelAgreementID 1: default numberofdays is 1 
                //ServiceLevelAgreementID 2: default numberofdays is 5
                //ServiceLevelAgreementID 3: default numberofdays is 1
                //ServiceLevelAgreementID 4: default numberofdays is 5
                defaultNumberOfDays = (serviceLevelAgreementService.ServiceLevelAgreementID == 1 || serviceLevelAgreementService.ServiceLevelAgreementID == 3) ? 1 : 5 ;

                _projectTreatmentSLARepository.AddProjectTreatmentSLAs(new ProjectTreatmentSLA { ServiceLevelAgreementID = serviceLevelAgreementService.ServiceLevelAgreementID, ReferrerProjectTreatmentID = referrerProjectTreatmentID, NumberOfDays = defaultNumberOfDays, Enabled = true });

            } 

            return referrerProjectTreatmentID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="referrerProjectTreatment"></param>
        /// <returns></returns>
        public int UpdateReferrerProjectTreatment(ReferrerProjectTreatment referrerProjectTreatment)
        {
            //bool enable = _referrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentID(referrerProjectTreatment.ReferrerProjectTreatmentID).Any(o => o.Price.Value == 0.0m);
            //referrerProjectTreatment.Enabled = !enable;
            return _referrerProjectTreatmentRepository.UpdateReferrerProjectTreatment(referrerProjectTreatment);
        }

        public IEnumerable<ReferrerProjectTreatmentTreatmentCategory> GetReferrerProjectTreatmentsByReferrerProjectID(int referrerProjectID)
        {
            return _referrerProjectTreatmentRepository.GetReferrerProjectTreatmentsByReferrerProjectID(referrerProjectID);
        }

        public IEnumerable<ReferrerProjectTreatment> GetAllReferrerProjectTreatment()
        {
            return _referrerProjectTreatmentRepository.GetAll();
        }


        public int UpdateReferrerProjectTreatments(ReferrerProjectTreatment referrerProjectTreatment)
        {
            return _referrerProjectTreatmentRepository.UpdateReferrerProjectTreatments(referrerProjectTreatment);
        }


        public ReferrerProjectTreatmentTreatmentCategory GetReferrerProjectTreatmentByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            return _referrerProjectTreatmentRepository.GetReferrerProjectTreatmentByReferrerProjectTreatmentID(referrerProjectTreatmentID);
        }

        public int GetReferrerIdAgtReferrerProjectTreatmentId(int referrerProjectTreatmentID)
        {
            return _referrerProjectTreatmentRepository.GetReferrerIdAgtReferrerProjectTreatmentId(referrerProjectTreatmentID);
        }
    }

}