using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace CoreTest
{
    [TestClass]
    public class EmployeeDetailTest
    {
        IEmployeeDetailRepository _employeeDetailRepository;
        IEmployeeDetail _EmployeeDetail;

        private ITS.Core.Data.Model.EmployeeDetail DLModel = new ITS.Core.Data.Model.EmployeeDetail();
        
        [TestInitialize()]
        public void EmployeeDetailInit()
        {
            _employeeDetailRepository = new EmployeeDetailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _EmployeeDetail = new EmployeeDetailImpl(_employeeDetailRepository);

           
        }

        [TestMethod]
        public void AddEmployeeDetail()
        {
            DLModel.AgileWorkerID = 1;
            DLModel.CurrentHours = "sdfsd";
            DLModel.CurrentlyAbsentFromWorkID = 2;
            DLModel.CurrentRoleTypeID = 1;
            DLModel.DateofFirstAbsence = DateTime.Now;
            DLModel.EAP = "sdfsd";
            DLModel.IllnessEmpAbilityToPerform = "sdfsd";
            DLModel.MedicationOrTreatment = "sdf";
            DLModel.OfficeBasedID = 1;
            DLModel.OfficeLocation = "sdf";
            DLModel.PreRelatedAbsence = "sdfs";
            DLModel.TypeofIllness = "sdfsf";
            DLModel.UsualHours = "sdfsd";
            DLModel.UsualJobRoleTypeID = 1;
            DLModel.AdditionalQuestion1 = "Testing1";
            DLModel.AdditionalQuestion2 = "Testing2";
            DLModel.FurtherQuestion1 = "Testing1";
            DLModel.FurtherQuestion2 = "Testing2";
            DLModel.jobTitle = "jobTitle";
            DLModel.NationalINSNumber = "NationalINSNumber";
            int result = _EmployeeDetail.AddEmployeeDetail(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

        [TestMethod]
        public void UpdateEmployeeDetail()
        {
            DLModel.EmployeeDetailID = 2;
            DLModel.AgileWorkerID = 1;
            DLModel.CurrentHours = "test";
            DLModel.CurrentlyAbsentFromWorkID = 2;
            DLModel.CurrentRoleTypeID = 1;
            DLModel.DateofFirstAbsence = DateTime.Now;
            DLModel.EAP = "test";
            DLModel.IllnessEmpAbilityToPerform = "test";
            DLModel.MedicationOrTreatment = "test";
            DLModel.OfficeBasedID = 1;
            DLModel.OfficeLocation = "test";
            DLModel.PreRelatedAbsence = "test";
            DLModel.TypeofIllness = "test";
            DLModel.UsualHours = "test";
            DLModel.UsualJobRoleTypeID = 1;
            DLModel.AdditionalQuestion1 = "AdditionalQuestion1Testing1";
            DLModel.AdditionalQuestion2 = "AdditionalQuestion2Testing2";
            DLModel.FurtherQuestion1 = "FurtherQuestion1Testing1";
            DLModel.FurtherQuestion2 = "FurtherQuestion2Testing2";
            DLModel.jobTitle = "jobTitle1";
            DLModel.NationalINSNumber = "NationalINSNumber1";
            int result = _EmployeeDetail.UpdateEmployeeDetail(DLModel);
            Assert.IsTrue(result > 0, "Unable to Add");
        }

       

    }
}

