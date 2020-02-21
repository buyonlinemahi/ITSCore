
using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

#region Comment
/*
 Page Name:  CaseAssessmentPatientInjuryTest.cs                      
 Latest Version:  1.0
 Author : Harpreet Singh
 Create date: 24/05/2013  
 Description : Created and added method in test cases file for CaseAssessmentPatientInjuryTest
*/
#endregion


namespace CoreTest
{


    [TestClass]
    public class CaseAssessmentPatientInjuryTest
    {

        private ITS.Core.Data.ICaseAssessmentPatientInjuryRepository _caseAssessmentPatientInjuryRepository;
        private ITS.Core.Data.ICaseAssessmentPatientInjuryHistoryRepository _caseAssessmentPatientInjuryHistoryRepository;
        private ITS.Core.BL.IAffectedArea _affectedArea;
        private IAffectedAreaRepository _AffectedAreaRepository;
        private ITS.Core.BL.IRestrictionRange _restrictionRange;
        private IRestrictionRangeRepository _RestrictionRangeRepositor;
        private ITS.Core.BL.IStrengthTesting _strengthTesting;
        private IStrengthTestingRepository _StrengthTestingRepository;        
        private ITS.Core.BL.ISymptomDescription _symptomDescription;
        private ISymptomDescriptionRepository _SymptomDescriptionRepository;
        private ICaseAssessmentPatientInjury Service;


        public CaseAssessmentPatientInjuryTest()
        {
        }

        [TestInitialize()]
        public void CaseAssessmentPatientInjuryInit()
        {
            _caseAssessmentPatientInjuryRepository = new CaseAssessmentPatientInjuryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            // To Test CaseAssessmentPatientInjuryHistory
            _caseAssessmentPatientInjuryHistoryRepository = new CaseAssessmentPatientInjuryHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _AffectedAreaRepository = new AffectedAreaRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _affectedArea = new AffectedAreaImpl(_AffectedAreaRepository);
            _RestrictionRangeRepositor = new RestrictionRangeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _restrictionRange = new RestrictionRangeImpl(_RestrictionRangeRepositor);
            _StrengthTestingRepository = new StrengthTestingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _strengthTesting = new StrengthTestingImpl(_StrengthTestingRepository);            
            _SymptomDescriptionRepository = new SymptomDescriptionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _symptomDescription = new SymptomDescriptionImpl(_SymptomDescriptionRepository);
            Service = new CaseAssessmentPatientInjuryImpl(_caseAssessmentPatientInjuryRepository, _affectedArea, _restrictionRange, _strengthTesting, _symptomDescription);

        }

        [TestMethod]
        public void AddCaseAssessmentPatientInjuryHistory()
        {
            CaseAssessmentPatientInjuryHistory injuryHistory = new CaseAssessmentPatientInjuryHistory();
            injuryHistory.AffectedArea = "";
            injuryHistory.Restriction = "" ;
            injuryHistory.CaseAssessmentDetailHistoryID = 1127;
            injuryHistory.Score = "9";
            injuryHistory.StrengthTestingID = 3;
            injuryHistory.SymptomDescriptionID = 3;
            injuryHistory.RestrictionRangeID = 3;
            injuryHistory.AffectedAreaID = 3;
            injuryHistory.OtherSymptomDesciption = null;
            Assert.IsTrue(_caseAssessmentPatientInjuryHistoryRepository.AddCaseAssessmentPatientInjuryHistory(injuryHistory) != 0, "Error in inserting parient injury history");
        }



        [TestMethod]
        public void Add_CaseAssessmentPatientInjury()
        {
            CaseAssessmentPatientInjury injury = new CaseAssessmentPatientInjury();
            injury.CaseAssessmentDetailID = 1596;
            injury.Score = "6";
            injury.Restriction = "";
            injury.AffectedArea = "";
            injury.StrengthTestingID = 4;
            injury.SymptomDescriptionID = 2;
            injury.AffectedAreaID = 4;
            injury.RestrictionRangeID = 4;
            injury.OtherSymptomDesciption = "sdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsfsdfsfdsfdfsdfsdfsd";
            int _CaseResult = _caseAssessmentPatientInjuryRepository.AddCaseAssessmentPatientInjury(injury);
            Assert.IsTrue(_CaseResult != 0, "Error in inserting patient injury !!!");
        }

        [TestMethod]
        public void Update_CaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID()
        {
            CaseAssessmentPatientInjury injury = new CaseAssessmentPatientInjury();
            injury.CaseAssessmentPatientInjuryID = 1672;
            injury.CaseAssessmentDetailID = 1596;
            injury.Score = "8";
            injury.Restriction = "";
            injury.AffectedArea = "";
            injury.StrengthTestingID = 3;
            injury.SymptomDescriptionID = 3;
            injury.AffectedAreaID= 3;
            injury.RestrictionRangeID = 3;
            injury.OtherSymptomDesciption = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";
            int _CaseResult = _caseAssessmentPatientInjuryRepository.UpdateCaseAssessmentPatientInjuryByCaseAssessmentPatientInjuryID(injury);
            Assert.IsTrue(_CaseResult != 0, "Error in updating patient injury !!!");
        }

        [TestMethod]
        public void Get_CaseAssessmentPatientInjuriesByCaseAssessmentDetailID()
        {
            var _CaseResult = Service.GetCaseAssessmentPatientInjuriesByCaseAssessmentDetailID(1596);
            Assert.IsTrue(_CaseResult != null, "Error in retriving patient injury !!!");
        }
    }
}
