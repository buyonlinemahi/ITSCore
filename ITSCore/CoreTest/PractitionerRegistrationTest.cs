using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CoreTest
{


    [TestClass]
    public class PractitionerRegistrationTest
    {

        IPractitionerRegistrationRepository _practitionerRegistrationRepository;


        public PractitionerRegistrationTest()
        {

        }

        [TestInitialize()]
        public void PractitionerRegistrationInit()
        {
            _practitionerRegistrationRepository = new PractitionerRegistrationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }


        [TestMethod]
        public void Add_PractitionerRegistration()
        {
            IPractitionerRegistration practitionerRegistrationService = new PractitionerRegistrationImpl(_practitionerRegistrationRepository);
            PractitionerRegistration __practitionerRegistrationObj = new PractitionerRegistration();

            __practitionerRegistrationObj.PractitionerID = 237;
            __practitionerRegistrationObj.TreatmentCategoryID = 4;
            __practitionerRegistrationObj.RegistrationTypeID = 8;
            __practitionerRegistrationObj.RegistrationNumber = "RegistrationNumber";
            __practitionerRegistrationObj.Qualification ="Qualification";
            __practitionerRegistrationObj.QualificationDate = DateTime.Today;
            __practitionerRegistrationObj.ExpiryDate = DateTime.Today;
            __practitionerRegistrationObj.YearsQualified = 1;

            int _practitionerRegistrationResult = practitionerRegistrationService.AddPractitionerRegistration(__practitionerRegistrationObj);
            Assert.IsTrue(_practitionerRegistrationResult != 0, "Error in inserting Practitioner Registration !!!");
        }

        [TestMethod]
        public void Update_PractitionerRegistrationByPractitionerRegistrationID()
        {
            IPractitionerRegistration practitionerRegistrationService = new PractitionerRegistrationImpl(_practitionerRegistrationRepository);
            PractitionerRegistration __practitionerRegistrationObj = new PractitionerRegistration();

            __practitionerRegistrationObj.PractitionerID = 239;
            __practitionerRegistrationObj.TreatmentCategoryID = 2;
            __practitionerRegistrationObj.RegistrationTypeID = 4;
            __practitionerRegistrationObj.RegistrationNumber = "RegistrationNumber";
            __practitionerRegistrationObj.Qualification = "Qualification";
            __practitionerRegistrationObj.QualificationDate = DateTime.Today;
            __practitionerRegistrationObj.ExpiryDate = DateTime.Today;
            __practitionerRegistrationObj.YearsQualified = 1;
            __practitionerRegistrationObj.PractitionerRegistrationID = 258;

            int _practitionerRegistrationResult = practitionerRegistrationService.UpdatePractitionerRegistrationByPractitionerRegistrationID(__practitionerRegistrationObj);
            Assert.IsTrue(_practitionerRegistrationResult != 0, "Error in updating Practitioner Registration !!!");
        }



        [TestMethod]
        public void Get_PractitionerByPractitionerRegistrationID()
        {
            IPractitionerRegistration practitionerRegistrationService = new PractitionerRegistrationImpl(_practitionerRegistrationRepository);
            PractitionerRegistration __practitionerRegistrationObj = new PractitionerRegistration();
            PractitionerRegistration _practitionerRegistrationResult = practitionerRegistrationService.GetPractitionerRegistrationByPractitionerRegistrationID(1);
            Assert.IsTrue(_practitionerRegistrationResult != null, "Get Practitioner By PractitionerRegistrationID");
        }

        [TestMethod]
        public void Get_PractitionerRegistrationsByPractitionerID()
        {
            IPractitionerRegistration practitionerRegistrationService = new PractitionerRegistrationImpl(_practitionerRegistrationRepository);
            PractitionerRegistration __practitionerRegistrationObj = new PractitionerRegistration();
            IEnumerable<PractitionerRegistration> _practitionerRegistrationResult = practitionerRegistrationService.GetPractitionerRegistrationsByPractitionerID(157);
            Assert.IsTrue(_practitionerRegistrationResult.Any());
        }

        [TestMethod]
        public void Get_PractitionerRegistrationsByRegistrationTypeID()
        {
            IPractitionerRegistration practitionerRegistrationService = new PractitionerRegistrationImpl(_practitionerRegistrationRepository);
            PractitionerRegistration __practitionerRegistrationObj = new PractitionerRegistration();
            IEnumerable<PractitionerRegistration> _practitionerRegistrationResult = practitionerRegistrationService.GetPractitionerRegistrationsByRegistrationTypeID(1);
            Assert.IsTrue(_practitionerRegistrationResult.Any());
        }

        [TestMethod]
        public void Get_PractitionerRegistrationsByTreatmentCategoryID()
        {
            IPractitionerRegistration practitionerRegistrationService = new PractitionerRegistrationImpl(_practitionerRegistrationRepository);
            PractitionerRegistration __practitionerRegistrationObj = new PractitionerRegistration();
            IEnumerable<PractitionerRegistration> _practitionerRegistrationResult = practitionerRegistrationService.GetPractitionerRegistrationsByTreatmentCategoryID(2);
            Assert.IsTrue(_practitionerRegistrationResult.Any());
        }

        [TestMethod]
        public void Delete_PractitionerRegistrationByPractitionerRegistrationID()
        {
            IPractitionerRegistration practitionerRegistrationService = new PractitionerRegistrationImpl(_practitionerRegistrationRepository);
            PractitionerRegistration __practitionerRegistrationObj = new PractitionerRegistration();
            int _practitionerRegistrationResult = practitionerRegistrationService.DeletePractitionerRegistrationByPractitionerRegistrationID(2);
            Assert.IsTrue(_practitionerRegistrationResult != 0, "Error while Delete PractitionerRegistration By PractitionerRegistrationID !!!");
        }


    }
}
