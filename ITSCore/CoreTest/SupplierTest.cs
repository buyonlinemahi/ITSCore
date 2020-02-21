
using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


#region Comment
/*
 Page Name:  ISupplierRepository.cs                      
 Latest Version:  1.1
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 11-17-2012
  Version : 1.0
  Description : Add TEST For Get_SupplierBySupplierID
  Description : Add TEST For Get_SuppliersLikeSupplierName
  Description : Add TEST For Add_Supplier
  Description : Add TEST For Update_SupplierBySupplierID
===================================================================================

 Updated By: Anuj Batra
 Version:    1.1
 Date:       12-18-2012
 Description : Add TEST For Get_SuppliersLikePostCode
*/
#endregion


namespace CoreTest
{


    [TestClass]
    public class SupplierTest
    {

        ISupplierRepository _supplierRepository;
        ISupplierTreatmentRepository _supplierTreatmentRepository;

        ISupplierTreatmentPricingRepository _supplierTreatmentPricingRepository;
        ICaseRepository _caseRepository;
        ICaseAssessmentTotalCountAndRatingRepository _caseAssessmentRatingRepository;
        IClinicalAuditTotalCountAndPassAuditRepository _clinicalAuditRatingRepository;
        ISiteAuditTotalCountAndAuditPassRepository _siteAuditRatingRepository;
        IUKPostCodeRepository _postCodeRepository;
        ISupplier supplierService;
        ISupplierDistanceRankingRepository _supplierDistanceRankRepository;
        public SupplierTest()
        {
        }

        [TestInitialize()]
        public void SupplierInit()
        {
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();
            _supplierRepository = new SupplierRepository(baseContextFactory);
            _supplierTreatmentRepository = new SupplierTreatmentRepository(baseContextFactory);
            _caseRepository = new CaseRepository(baseContextFactory);
            _caseAssessmentRatingRepository = new CaseAssessmentTotalCountAndRatingRepository(baseContextFactory);
            _clinicalAuditRatingRepository = new ClinicalAuditTotalCountAndPassAuditRepository(baseContextFactory);
            _siteAuditRatingRepository = new SiteAuditTotalCountAndAuditPassRepository(baseContextFactory);
            _postCodeRepository = new UKPostCodeRepository(baseContextFactory);
            _supplierDistanceRankRepository = new SupplierDistanceRankingRepository(baseContextFactory);
            _supplierTreatmentPricingRepository = new SupplierTreatmentPricingRepository(baseContextFactory);
            supplierService = new SupplierImpl(_supplierRepository, _supplierTreatmentRepository, _caseRepository, _clinicalAuditRatingRepository, _siteAuditRatingRepository, _caseAssessmentRatingRepository, _postCodeRepository, _supplierDistanceRankRepository, _supplierTreatmentPricingRepository);
        }


        [TestMethod]
        public void Add_Supplier()
        {
            Supplier _SupplierObj = new Supplier();
            _SupplierObj.SupplierName = "ssss";
            _SupplierObj.Address = "ssss";
            _SupplierObj.City = "sssss";
            _SupplierObj.Region = "sssss";
            _SupplierObj.PostCode = "sssss";
            _SupplierObj.Phone = "sssss";
            _SupplierObj.Fax = "sssss";
            _SupplierObj.Website = "sssss";
            _SupplierObj.Ranking = 5;
            _SupplierObj.Notes = "sssss";
            _SupplierObj.IsWheelChairAccessibility = true;
            _SupplierObj.IsWeekends = true;
            _SupplierObj.IsEvenings = true;
            _SupplierObj.IsParking = true;
            _SupplierObj.IsHomeVisit = true;
            _SupplierObj.Email = "3791133test@mail.com";
            _SupplierObj.IsTriage = false;

            int _SupplierResult = _supplierRepository.AddSupplier(_SupplierObj);

            Assert.IsTrue(_SupplierResult != 0, "Error in inserting _Supplier !!!");
        }

        [TestMethod]
        public void Add_SupplierAndTreatmentTypes()
        {

            ISupplier supplierService = new SupplierImpl(_supplierRepository, _supplierTreatmentRepository);
            ISupplierTreatment supplierTreatmentService = new SupplierTreatmentImpl(_supplierTreatmentRepository);

            Supplier _SupplierObj = new Supplier();
            _SupplierObj.SupplierName = "ssss";
            _SupplierObj.Address = "ssss";
            _SupplierObj.City = "sssss";
            _SupplierObj.Region = "sssss";
            _SupplierObj.PostCode = "sssss";
            _SupplierObj.Phone = "sssss";
            _SupplierObj.Fax = "sssss";
            _SupplierObj.Website = "sssss";
            _SupplierObj.Ranking = 5;
            _SupplierObj.Notes = "sssss";
            _SupplierObj.IsWheelChairAccessibility = true;
            _SupplierObj.IsWeekends = true;
            _SupplierObj.IsEvenings = true;
            _SupplierObj.IsParking = true;
            _SupplierObj.IsHomeVisit = true;
            _SupplierObj.Email = "3791144test@mail.com";
            _SupplierObj.IsTriage = true;
            //_SupplierObj.Status = "InComplete";

            int _SupplierResult = supplierService.AddSupplierAndTreatmentTypes(_SupplierObj, supplierTreatmentService.GetSupplierTreatmentBySupplierID(41));
            Assert.IsTrue(_SupplierResult != 0, "Error in inserting Add SupplierAndTreatmentTypes !!!");
        }

        [TestMethod]
        public void Update_SupplierBySupplierID()
        {
            Supplier _SupplierObj = new Supplier();
            _SupplierObj.SupplierID = 528;
            _SupplierObj.SupplierName = "aaaaaa2";
            _SupplierObj.Address = "asdf";
            _SupplierObj.City = "asdf";
            _SupplierObj.Region = "jasifdg";
            _SupplierObj.PostCode = "juhsadfuhsadf";
            _SupplierObj.Phone = "aaaa";
            _SupplierObj.Fax = "aaaaa";
            _SupplierObj.Website = "aaaa";
            _SupplierObj.Ranking = 1;
            _SupplierObj.Notes = "aaaaaaa";
            _SupplierObj.IsWheelChairAccessibility = true;
            _SupplierObj.IsWeekends = true;
            _SupplierObj.IsEvenings = true;
            _SupplierObj.IsParking = true;
            _SupplierObj.IsHomeVisit = true;
            _SupplierObj.Email = "3791144344test@mail.com";
            _SupplierObj.IsTriage = true;
            // _SupplierObj.Status = "Complete";
            int _SupplierResult = _supplierRepository.UpdateSupplierBySupplierID(_SupplierObj);
            Assert.IsTrue(_SupplierResult != 0, "Error in Updating the _Supplier !!!");
        }

        [TestMethod]
        public void Get_SupplierBySupplierID()
        {
            ISupplier supplierService = new SupplierImpl(_supplierRepository, _supplierTreatmentRepository);
            Supplier _SupplierResult = supplierService.GetSupplierBySupplierID(240);
            Assert.IsTrue(_SupplierResult != null, "unable get Supplier By SupplierID");
        }

        [TestMethod]
        public void Get_SuppliersRecentlyAdded()
        {
            ISupplier supplierService = new SupplierImpl(_supplierRepository, _supplierTreatmentRepository);
            IEnumerable<Supplier> _SupplierResult = supplierService.GetSuppliersRecentlyAdded();
            Assert.IsTrue(_SupplierResult.Any(), "Unable to get SuppliersRecentlyAdded");
        }


        [TestMethod]
        public void UpdateSupplierStatusBySupplierID()
        {
            // SupplierImpl _obj = new SupplierImpl(_supplierRepository, _supplierTreatmentRepository);

            int result = supplierService.UpdateSupplierStatus(401,true);
            Assert.IsTrue(result > 0, "unable update Supplier status By SupplierID");
        }

        [TestMethod]
        public void GetSupplierNewPatientCases_BL_Test()
        {
            const int supplierID = 617;
            IEnumerable<SupplierCasePatient> supplierCasePatients = supplierService.GetSupplierNewPatientCases(supplierID);

            foreach (var casePatient in supplierCasePatients)
            {
                if (ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReferredtoSupplier != casePatient.WorkflowID &&
                    ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.ReferreredtoTriageSupplier != casePatient.WorkflowID &&
                    ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentSupplierCustom != casePatient.WorkflowID)
                {
                    Assert.Fail("Wrong workflow id");
                }

                if (casePatient.CaseID == 0)
                {
                    Assert.Fail("Wrong patient id");
                }

                //if (string.IsNullOrEmpty(casePatient.FirstName) && string.IsNullOrEmpty(casePatient.LastName))
                //{
                //    Assert.Fail("Wrong fullname is wrong");
                //}
            }
        }

        [TestMethod]
        public void GetSupplierExistingPatientsInitialAssessments_BL_Test()
        {
            const int supplierID = 617;

            IEnumerable<SupplierCasePatient> supplierCasePatients = supplierService.GetSupplierExistingPatientsInitialAssessments(supplierID);

            var casePatients = supplierCasePatients.ToList();

            Assert.IsTrue(casePatients.Any());


            foreach (var casePatient in casePatients)
            {
                if (ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentBooked !=
                    casePatient.WorkflowID &&
                    ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentAttended !=
                    casePatient.WorkflowID)
                {
                    Assert.Fail("Wrong workflow id");
                }

                if (casePatient.CaseID == 0)
                {
                    Assert.Fail("Wrong patient id");
                }

                //if (string.IsNullOrEmpty(casePatient.FirstName) || string.IsNullOrEmpty(casePatient.LastName))
                //{
                //    Assert.Fail("Wrong fullname is wrong");
                //}
            }
        }

        [TestMethod]
        public void GetSupplierExistingPatientsNextAssessments_BL_Test()
        {
            const int supplierID = 617;

            IEnumerable<SupplierCasePatient> supplierCasePatients = supplierService.GetSupplierExistingPatientsNextAssessments(supplierID);

            var casePatients = supplierCasePatients.ToList();

            Assert.IsTrue(casePatients.Any());

            foreach (var casePatient in casePatients)
            {
                if (ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment !=
                    casePatient.WorkflowID)
                {
                    Assert.Fail("Wrong workflow id");
                }

                if (casePatient.CaseID == 0)
                {
                    Assert.Fail("Wrong patient id");
                }

                //if (string.IsNullOrEmpty(casePatient.FirstName) && string.IsNullOrEmpty(casePatient.LastName))
                //{
                //    Assert.Fail("Wrong fullname is wrong");
                //}
            }
        }

        [TestMethod]
        public void GetSupplierAuthorisations_BL_Test()
        {
            const int supplierID = 617;

            IEnumerable<SupplierCasePatient> supplierCasePatients = supplierService.GetSupplierAuthorisations(supplierID).ToList();

            var casePatients = supplierCasePatients.ToList();

            Assert.IsTrue(casePatients.Any());

           /* foreach (var casePatient in casePatients)
            {
                if (ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.AuthorisationSenttoSupplierOrPatientinTreatment != casePatient.WorkflowID)
                {
                    Assert.Fail("Wrong workflow id");
                }

                if (casePatient.CaseID == 0)
                {
                    Assert.Fail("Wrong patient id");
                }

                //if (string.IsNullOrEmpty(casePatient.FirstName) && string.IsNullOrEmpty(casePatient.LastName))
                //{
                //    Assert.Fail("Wrong fullname is wrong");
                //}
            }*/
        }

        [TestMethod]
        public void Get_SupplierExistsByName_BL_Test()
        {
            string supplierName = "Harpreet";
            bool isSupplierNameExists = supplierService.GetSupplierExistsByName(supplierName);
            Assert.IsTrue(isSupplierNameExists, "False!!!");
        }

            [TestMethod]
        public void Get_SupplierExistsByEmail()
        {
            string supplierEmail = "w@r.ciom";
            bool isSupplierEmailExists = supplierService.GetSupplierExistsByEmail(supplierEmail);
            Assert.IsTrue(isSupplierEmailExists, "False!!!");
        }

            [TestMethod]
            public void Get_SelectedSupplierDistanceRankPrice()
            {
           
                var SelectedSupplierDistanceRankPrice = supplierService.GetSelectedSupplierDistanceRankPrice(373, 1,"AB10 1AA");
                Assert.IsTrue(SelectedSupplierDistanceRankPrice!=null, "False!!!");
            }


        



    }

}

