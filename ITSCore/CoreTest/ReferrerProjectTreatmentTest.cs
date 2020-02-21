using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{
    /// <summary>
    /// 
    /// 
    /// Summary description for ReferrerProjectTreatmentTest
    /// </summary>
    /// 
    /*
     * 
  Latest Version : 1.1
 ===============================================================================================
 * Edited By : Satya
 * Date : 09-Nov-2012
 * Version : 1.0
 * Description : Add Test Method For ReferrerProjectTreatmentTest
   ==============================================================================================
 * Edited By : Vishal
 * Date : 10-Nov-2012
 * Version : 1.1
 * Description : Change Method Name Getall to GetAll_ReferrerProjectTreatment
 Description : Change Method Name Getall to Add_ReferrerProjectTreatment
     Description : Change Method Name Getall to Update_ReferrerProjectTreatment
 ==============================================================================================
 */
    [TestClass]
    public class ReferrerProjectTreatmentTest
    {

        private IReferrerProjectTreatmentRepository _referrerProjectTreatmentRepository;


        private IAssessmentServiceRepository _assessmentServiceRepository;
        private IAssessmentTypeRepository _assessmentTypeRepository;

        private IReferrerProjectTreatmentAuthorisationRepository _referrerProjectTreatmentAuthorisationRepository;
        private IReferrerProjectTreatmentAssessmentRepository _referrerProjectTreatmentAssessmentRepository;
        private IReferrerProjectTreatmentEmailRepostory _referrerProjectTreatmentEmailRepostory;
        private IDelegatedAuthorisationRepository _delegatedAuthorisationRepository;

        private IEmailTypeRepository _emailTypeRepository;

        private IReferrerProjectTreatmentInvoiceRepository _iReferrerProjectTreatmentInvoiceRepository;
        private IReferrerProjectTreatmentDocumentSetupRepository _iReferrerProjectTreatmentDocumentSetupRepository;

        private IServiceLevelAgreementRepository _serviceLevelAgreementRepository;
        private IProjectTreatmentSLARepository _projectTreatmentSLARepository;
        private IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;

        public ReferrerProjectTreatmentTest()
        {
        }

        [TestInitialize()]
        public void ReferrerProjectTreatmentTestInit()
        {
            _referrerProjectTreatmentRepository = new ReferrerProjectTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            _referrerProjectTreatmentAssessmentRepository = new ReferrerProjectTreatmentAssessmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _assessmentServiceRepository = new AssessmentServiceRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _assessmentTypeRepository = new AssessmentTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectTreatmentAuthorisationRepository = new ReferrerProjectTreatmentAuthorisationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectTreatmentEmailRepostory = new ReferrerProjectTreatmentEmailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _emailTypeRepository = new EmailTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _delegatedAuthorisationRepository = new DelegatedAuthorisationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectTreatmentEmailRepostory = new ReferrerProjectTreatmentEmailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _iReferrerProjectTreatmentInvoiceRepository = new ReferrerProjectTreatmentInvoiceRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _iReferrerProjectTreatmentDocumentSetupRepository = new ReferrerProjectTreatmentDocumentSetupRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _serviceLevelAgreementRepository = new ServiceLevelAgreementRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _projectTreatmentSLARepository = new ProjectTreatmentSLARepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectTreatmentPricingRepository = new ReferrerProjectTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAll_ReferrerProjectTreatment()
        {
            IEnumerable<ReferrerProjectTreatment> referrerProjectTreatmentRepository = _referrerProjectTreatmentRepository.GetAll();
            Assert.IsTrue(referrerProjectTreatmentRepository.Any());
        }


        [TestMethod]
        public void GetAll_ReferrerProjectTreatmentByReferrerProjectID()
        {
            IEnumerable<ReferrerProjectTreatmentTreatmentCategory> referrerProjectTreatmentRepository = _referrerProjectTreatmentRepository.GetReferrerProjectTreatmentsByReferrerProjectID(2578);
            Assert.IsTrue(referrerProjectTreatmentRepository.Any());
        }

        [TestMethod]
        public void Get_ReferrerProjectTreatmentByReferrerProjectTreatmentID()
        {
            ReferrerProjectTreatmentTreatmentCategory referrerProjectTreatmentRepository = _referrerProjectTreatmentRepository.GetReferrerProjectTreatmentByReferrerProjectTreatmentID(8361);
            Assert.IsTrue(referrerProjectTreatmentRepository != null);
        }

        [TestMethod]
        public void GetReferrerIdAgtReferrerProjectTreatmentId()
        {
            int result = _referrerProjectTreatmentEmailRepostory.GetReferrerIdAgtReferrerProjectTreatmentId(9982);
        }




        [TestMethod]
        public void Add_ReferrerProjectTreatment()
        {
            ReferrerProjectTreatment referrerProjectTreatment = new ReferrerProjectTreatment();
            IReferrerProjectTreatment referrerProjectTreatmentService = new ReferrerProjectTreatmentImpl(_referrerProjectTreatmentRepository, _referrerProjectTreatmentAssessmentRepository, _assessmentServiceRepository, _assessmentTypeRepository, _referrerProjectTreatmentAuthorisationRepository, _referrerProjectTreatmentEmailRepostory, _delegatedAuthorisationRepository, _emailTypeRepository, _iReferrerProjectTreatmentInvoiceRepository, _iReferrerProjectTreatmentDocumentSetupRepository, _serviceLevelAgreementRepository, _projectTreatmentSLARepository, _referrerProjectTreatmentPricingRepository);

            referrerProjectTreatment.ReferrerProjectID = 3055;
            referrerProjectTreatment.TreatmentCategoryID = 2;
            referrerProjectTreatment.Enabled = true;
            referrerProjectTreatment.AccountReceivableCollection = 2000;
            referrerProjectTreatment.AccountReceivableChasingPoint = 3000;
            int referrerProjectTreatmentID = referrerProjectTreatmentService.AddReferrerProjectTreatment(referrerProjectTreatment);
            Assert.IsTrue(referrerProjectTreatmentID != 0, "Unable to insert");
        }

        [TestMethod]
        public void Update_ReferrerProjectTreatment()
        {
            ReferrerProjectTreatment referrerProjectTreatment = new ReferrerProjectTreatment();
            IReferrerProjectTreatment referrerProjectTreatmentService = new ReferrerProjectTreatmentImpl(_referrerProjectTreatmentRepository, _referrerProjectTreatmentAssessmentRepository, _assessmentServiceRepository, _assessmentTypeRepository, _referrerProjectTreatmentAuthorisationRepository, _referrerProjectTreatmentEmailRepostory, _delegatedAuthorisationRepository, _emailTypeRepository, _iReferrerProjectTreatmentInvoiceRepository, _iReferrerProjectTreatmentDocumentSetupRepository, _serviceLevelAgreementRepository, _projectTreatmentSLARepository, _referrerProjectTreatmentPricingRepository);
            referrerProjectTreatment.ReferrerProjectID = 1;
            referrerProjectTreatment.TreatmentCategoryID = 3;
            referrerProjectTreatment.Enabled = false;
            referrerProjectTreatment.AccountReceivableCollection = 1000;
            referrerProjectTreatment.AccountReceivableChasingPoint = 2000;
            referrerProjectTreatment.ReferrerProjectTreatmentID = 8361;

            int returnValue = referrerProjectTreatmentService.UpdateReferrerProjectTreatment(referrerProjectTreatment);

            Assert.IsTrue(returnValue != 0, "Unable to update");
        }

        [TestMethod]
        public void Update_ReferrerProjectTreatments()
        {
            ReferrerProjectTreatment referrerProjectTreatment = new ReferrerProjectTreatment();
            IReferrerProjectTreatment referrerProjectTreatmentService = new ReferrerProjectTreatmentImpl(_referrerProjectTreatmentRepository, _referrerProjectTreatmentAssessmentRepository, _assessmentServiceRepository, _assessmentTypeRepository, _referrerProjectTreatmentAuthorisationRepository, _referrerProjectTreatmentEmailRepostory, _delegatedAuthorisationRepository, _emailTypeRepository, _iReferrerProjectTreatmentInvoiceRepository, _iReferrerProjectTreatmentDocumentSetupRepository, _serviceLevelAgreementRepository, _projectTreatmentSLARepository, _referrerProjectTreatmentPricingRepository);
            referrerProjectTreatment.ReferrerProjectID = 2578;
            referrerProjectTreatment.TreatmentCategoryID = 1;
            referrerProjectTreatment.Enabled = true;
            referrerProjectTreatment.ReferrerProjectTreatmentID = 8361;

            int returnValue = referrerProjectTreatmentService.UpdateReferrerProjectTreatments(referrerProjectTreatment);

            Assert.IsTrue(returnValue != 0, "Unable to update");
        }

    }
}
