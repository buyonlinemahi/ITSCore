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
    [TestClass]
    public class PractitionerTreatmentRegistrationsTest
    {


        IPractitionerTreatmentRegistrationRepository _practitionerTreatmentRegistrationRepository;

        public PractitionerTreatmentRegistrationsTest()
        {

        }
        [TestInitialize()]
        public void PractitionerTreatmentRegistrationsTestRepositoryInit()
        {
            _practitionerTreatmentRegistrationRepository = new PractitionerTreatmentRegistrationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }

        [TestMethod]
        public void GetSupplierPractitionerTreatmentRegistrationsBySupplierID()
        {

            //this Test for BL Layer
            IPractitionerTreatmentRegistration practitionerTreatmentRegistrationBL = new PractitionerTreatmentRegistrationImpl(_practitionerTreatmentRegistrationRepository);
            IEnumerable<SupplierPractitionerTreatmentRegistration> _practitionerTreatmentRegistration = practitionerTreatmentRegistrationBL.GetSupplierPractitionerTreatmentRegistrationsBySupplierID(360);
            Assert.IsTrue(_practitionerTreatmentRegistration.Any());

        }


        [TestMethod]
        public void GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryName_Test()
        {
            IPractitionerTreatmentRegistration practitionerTreatmentRegistrationBL = new PractitionerTreatmentRegistrationImpl(_practitionerTreatmentRegistrationRepository);
            IEnumerable<PractitionerTreatmentRegistration> _practitionerTreatmentRegistration = practitionerTreatmentRegistrationBL.GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryName("psy", 0, 5);
            Assert.IsTrue(_practitionerTreatmentRegistration != null, "Error can't find the records");
        }


        [TestMethod]
        public void GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount_Test()
        {
            IPractitionerTreatmentRegistration practitionerTreatmentRegistrationBL = new PractitionerTreatmentRegistrationImpl(_practitionerTreatmentRegistrationRepository);
            var count = practitionerTreatmentRegistrationBL.GetPractitionerTreatmentRegistrationsLikeTreatmentCategoryNameCount("psy");
            Assert.IsTrue(count != 0, "Error result not found");
        }

        [TestMethod]
        public void Get_PractitionerTreatmentRegistrationsLikePractitionerNameForSupplier()
        {
            IPractitionerTreatmentRegistration practitionerTreatmentRegistrationBL = new PractitionerTreatmentRegistrationImpl(_practitionerTreatmentRegistrationRepository);
            var result = practitionerTreatmentRegistrationBL.GetPractitionerTreatmentRegistrationsLikePractitionerNameForSupplier("har");
            Assert.IsTrue(result != null, "Error result not found");
        }


        [TestMethod]
        public void Get_PractitionerTreatmentRegistrationsLikePractitionerNameCount()
        {
            IPractitionerTreatmentRegistration practitionerTreatmentRegistrationBL = new PractitionerTreatmentRegistrationImpl(_practitionerTreatmentRegistrationRepository);
            var count = practitionerTreatmentRegistrationBL.GetPractitionerTreatmentRegistrationsLikePractitionerNameCount("har");
            Assert.IsTrue(count != 0, "Error result not found");
        }

        [TestMethod]
        public void Get_PractitionerTreatmentRegistrationsLikePractitionerName()
        {
            IPractitionerTreatmentRegistration practitionerTreatmentRegistrationBL = new PractitionerTreatmentRegistrationImpl(_practitionerTreatmentRegistrationRepository);
            var result = practitionerTreatmentRegistrationBL.GetPractitionerTreatmentRegistrationsLikePractitionerName("har",0,5);
            Assert.IsTrue(result != null, "Error result not found");
        }


    }
}
