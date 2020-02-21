using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class CaseNoteTest
    {

        private ICaseNoteRepository DL;
        protected ICaseNote BL;

        [TestInitialize()]
        public void CaseNoteInit()
        {
            DL = new CaseNoteRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            BL = new CaseNoteImpl(DL);

        }

        [TestMethod]
        public void AddCaseNote()
        {
            CaseNote _CaseNoteObj = new CaseNote();
            _CaseNoteObj.Note = "Thius";
            _CaseNoteObj.CaseID = 124;
            _CaseNoteObj.UserID = 348;
            int result = BL.AddCaseNote(_CaseNoteObj);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetCaseNotesByCaseID()
        {
            var result = BL.GetCaseNotesByCaseID(124);
            Assert.IsTrue(result != null, "Unable to Get");
        }

        [TestMethod]
        public void GetCaseNoteByCaseIDAndWorkflowID()
        {
            var result = BL.GetCaseNoteByCaseIDAndWorkflowID(2301,20);
            Assert.IsTrue(result != null, "Unable to Get");
        }
    }
}