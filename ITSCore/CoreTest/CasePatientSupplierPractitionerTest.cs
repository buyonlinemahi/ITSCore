
using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;


#region Comment
/*
 Page Name:  CaseWorkflowPatientReferrerProjectTest.cs                   
 Latest Version:  1.0
 Author : Robin Singh
 
*/
#endregion


namespace CoreTest
{


    [TestClass]
    public class CasePatientSupplierPractitionerTest
    {

        ICasePatientSupplierPractitionerRepository _casePatientSupplierPractitionerTestRepository;

        public CasePatientSupplierPractitionerTest()
        {
        }

        [TestInitialize()]
        public void CaseWorkflowPatientReferrerProjectInit()
        {
            _casePatientSupplierPractitionerTestRepository = new CasePatientSupplierPractitionerRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }
        [TestMethod]

        public void GetInitialAssessmentCasePatientSupplierPractitionerByCaseID()
        {
            ICasePatientSupplierPractitioner casePatientSupplierPractitionerTestRepository = new CasePatientSupplierPractitionerImpl(_casePatientSupplierPractitionerTestRepository);
            CasePatientSupplierPractitioner _casePatientSupplierPractitioner = casePatientSupplierPractitionerTestRepository.GetInitialAssessmentCasePatientSupplierPractitionerByCaseID(20);
            Assert.IsTrue(_casePatientSupplierPractitioner != null);
        }



        
    }
}
