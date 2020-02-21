using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{

    using ITS.Core.BL;
    using ITS.Core.BL.Implementation;
    using ITS.Core.Data;
    using ITS.Core.Data.SqlServer.Repository;
     [TestClass]
    public class CaseAssessmentCustomTest
    {
         private ICaseAssessmentCustomRepository repo;
         private ICaseAssessmentCustom service;

         [TestInitialize()]
         public void CaseAssessmentCustomInit()
         {
             repo = new CaseAssessmentCustomRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            
             service = new CaseAssessmentCustomImpl(repo);
         }

         [TestMethod]
         public void Add_CaseAssessmentCustom()
         {
             var result = service.AddCaseAssessmentCustom(new ITS.Core.Data.Model.CaseAssessmentCustom
             {

                 CaseID = 306,
                 isAccepted = true,
                 IsFurtherTreatment=true,
                 Message = "nothing to do"
             });

           //  Assert.IsTrue(result > 0);
         }

         [TestMethod]
         public void Get_CaseAssessmentCustomByCaseID()
         {
             var result = service.GetCaseAssessmentCustomByCaseID(306);
             //  Assert.IsTrue(result > 0);
         }
         [TestMethod]
         public void Update_CaseRiewAssessmentMessageCustom()
         {
             var result = service.UpdateCaseRiewAssessmentMessageCustom(new ITS.Core.Data.Model.CaseAssessmentCustom
             {

                 CaseID = 306,
                 ReviewAssessmentMessage = "nothing to do"
             });
         }
         [TestMethod]
         public void Update_CaseInitialAssessmentMessageCustom()
         {
             var result = service.UpdateCaseInitialAssessmentMessageCustom(new ITS.Core.Data.Model.CaseAssessmentCustom
             {

                 CaseID = 306,
                 Message = "nothing to do"
             });
         }
         [TestMethod]
         public void Update_CaseFinalAssessmentMessageCustom()
         {
             var result = service.UpdateCaseFinalAssessmentMessageCustom(new ITS.Core.Data.Model.CaseAssessmentCustom
             {

                 CaseID = 641,
                 FinalAssessmentMessage = "nothing to do"
             });
         }
    }

}
