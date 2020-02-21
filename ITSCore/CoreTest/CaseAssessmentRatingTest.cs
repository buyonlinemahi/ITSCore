using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

/*
   Latest Version: 1.0
   Author: Robin Singh Chauhan
   Reason :- Created Test for CaseAssessmentRating 
 * ======================================================================
  */

namespace CoreTest
{


    [TestClass]
    public class CaseAssessmentRatingTest
    {

        ICaseAssessmentRatingRepository _caseAssessmentRatingRepository;
        public CaseAssessmentRatingTest()
        {
        }

        [TestInitialize()]
        public void CaseAssessmentRatingInit()
        {
            _caseAssessmentRatingRepository = new CaseAssessmentRatingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Add_CaseAssessmentRating()
        {
            ICaseAssessmentRating caseAssessmentRatingobj = new CaseAssessmentRatingImpl(_caseAssessmentRatingRepository);
            CaseAssessmentRating _caseAssessmentRatingObj = new CaseAssessmentRating();
            _caseAssessmentRatingObj.CaseID = 12;
            _caseAssessmentRatingObj.AssessmentServiceID = 2;
            _caseAssessmentRatingObj.Rating = 4;
            _caseAssessmentRatingObj.RatingDate =DateTime.Now;

            int _CaseAssessmentRatingResult = caseAssessmentRatingobj.AddCaseAssessmentRating(_caseAssessmentRatingObj);
            Assert.IsTrue(_CaseAssessmentRatingResult != 0, "Error in inserting Case Assessment Rating!!!");
        }

        [TestMethod]
        public void Update_CaseAssessmentRatingByCaseIDAndAssessmentTypeID()
        {
            ICaseAssessmentRating caseAssessmentRatingobj = new CaseAssessmentRatingImpl(_caseAssessmentRatingRepository);
            CaseAssessmentRating _caseAssessmentRatingObj = new CaseAssessmentRating();
            _caseAssessmentRatingObj.CaseID = 12;
            _caseAssessmentRatingObj.AssessmentServiceID = 2;
            _caseAssessmentRatingObj.Rating = 5.0m;

            int _CaseAssessmentRatingResult = caseAssessmentRatingobj.UpdateCaseAssessmentRatingByCaseIDAndAssessmentServiceID(_caseAssessmentRatingObj.CaseID, _caseAssessmentRatingObj.AssessmentServiceID, _caseAssessmentRatingObj.Rating);
            Assert.IsTrue(_CaseAssessmentRatingResult != 0, "Error in Updating Case Assessment Rating!!!");
        }

        [TestMethod]
        public void Get_CaseAssessmentRatingByCaseIDAndAssessmentTypeID()
        {
            ICaseAssessmentRating caseAssessmentRatingobj = new CaseAssessmentRatingImpl(_caseAssessmentRatingRepository);
            CaseAssessmentRating _caseAssessmentRatingObj = new CaseAssessmentRating();
            CaseAssessmentRating _caseAssessmentRatingresult = caseAssessmentRatingobj.GetCaseAssessmentRatingByCaseIDAndAssessmentServiceID(12, 1);
            Assert.IsTrue(_caseAssessmentRatingresult != null, "unable to get CaseAssessmentRating");
        }

    }
}
