using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CoreTest
{
    /*************************************************************************/
    /*Might need to use sqllite or other in memory sql later for unit testing*/
    /*************************************************************************/
    [TestClass]
    public class PatientRepositoryTest
    {
        IPatientRepository _patientRepository;

        IPatient _BL;
        [TestInitialize]
        public void PatientRepositoryInit()
        {
            _patientRepository = new PatientRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _BL =new PatientImpl(_patientRepository);
        }

        [TestMethod]
        public void AddPatient()
        {
            Patient patient = new Patient();
            patient.Title = "Mr";
            patient.FirstName = "Abc";
            patient.LastName = "Singh";
            patient.Address = "2424 sdsafd";
            patient.City = "title";
            patient.Region = "Chandigarh";
            patient.PostCode = "16001";
            patient.InjuryDate = DateTime.Now;
            //patient.BirthDate = DateTime.Now;
            patient.HomePhone = "7307194482";
            patient.WorkPhone = "7307194482";
            patient.MobilePhone = "7307194482";
            patient.GenderID = 1;
            patient.Email = "eamil@example.com";
            patient.HasLegalRep = false;
            patient.SolicitorID = 1;
            patient.PrimaryConditionID = 1;
            int _patient = _patientRepository.AddPatient(patient);
            Assert.IsTrue(_patient != 0, "Error in inserting Patient !!!");
        }


        [TestMethod]
        public void GetPatientByPatientID()
        {

            Patient _patient = _patientRepository.GetPatientByPatientID(1);
            Assert.IsTrue(_patient != null, "Error in inserting Patient !!!");
        }

        [TestMethod]
        public void UpdatePatientByPatientID()
        {
            Patient patient = new Patient();
            patient.PatientID = 82;
            patient.Title = "Mr";
            patient.FirstName = "Abc";
            patient.LastName = "Singh";
            patient.Address = "2424 sdsafd";
            patient.City = "title";
            patient.Region = "Chandigarh";
            patient.PostCode = "16001";
            patient.InjuryDate = DateTime.Now;
            //patient.BirthDate = DateTime.Now;
            patient.HomePhone = "7307194482";
            patient.WorkPhone = "7307194482";
            patient.MobilePhone = "7307194482";
            patient.GenderID = 1;
            patient.Email = "eamil@example.com";
            patient.HasLegalRep = false;
            patient.SolicitorID = 1;
            patient.PrimaryConditionID = 1;
            int _patient = _patientRepository.UpdatePatientByPatientID(patient);
            Assert.IsTrue(_patient != 0, "Error in inserting Patient !!!");
        }

       
      
    }
}
