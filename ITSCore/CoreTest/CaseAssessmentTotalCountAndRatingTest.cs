using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CoreTest
{
    [TestClass]
    public class CaseAssessmentTotalCountAndRatingTest
    {
        ICaseAssessmentTotalCountAndRatingRepository _caseAssessmentTotalCountAndRatingRepository;

        [TestInitialize()]
        public void ClinicalAuditTotalCountAndPassAuditRepositoryInit()
        {
            _caseAssessmentTotalCountAndRatingRepository = new CaseAssessmentTotalCountAndRatingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void get_assessment_rating_total_count_and_rating_by_supplierID()
        {
            CaseAssessmentTotalCountAndRating c = _caseAssessmentTotalCountAndRatingRepository.GetCaseAssessmentTotalCountAndRatingBySupplierID(1);
            Assert.IsNotNull(c, "repository procedure is returning a null object!");
        }
    }
}
