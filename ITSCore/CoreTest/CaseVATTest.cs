using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class CaseVATTest
    {
        private ICaseVATRepository DL;
        protected ICaseVAT BL;

        [TestInitialize()]
        public void CaseVATInit()
        {
            DL = new CaseVATRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            BL = new CaseVATImpl(DL);
        }

        [TestMethod]
        public void GetCaseVATByCaseID()
        {
            var caseVATObj = BL.GetCaseVATByCaseID(300);
            Assert.IsTrue(caseVATObj != null, "Unable to find");
        }

        [TestMethod]
        public void AddCaseVAT()
        {
            CaseVAT _CaseVATObj = new CaseVAT();
            _CaseVATObj.CaseID = 300;
            _CaseVATObj.VAT = 2.5M;

            int result = BL.AddCaseVAT(_CaseVATObj);
            Assert.IsTrue(result > 0);
        }
    }
}