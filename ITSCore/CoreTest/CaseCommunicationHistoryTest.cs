using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class CaseCommunicationHistoryTest
    {
        private ICaseCommunicationHistoryRepository DL;
        protected ICaseCommunicationHistory BL;

        [TestInitialize()]
        public void CaseCommunicationHistoryInit()
        {
            DL = new CaseCommunicationHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            BL = new CaseCommunicationHistoryImpl(DL);
        }

        [TestMethod]
        public void AddCaseCommunicationHistory()
        {
            CaseCommunicationHistory _CaseCommunicationHistoryObj = new CaseCommunicationHistory();

            _CaseCommunicationHistoryObj.CaseID = 341;
            _CaseCommunicationHistoryObj.SentTo = "3333";
            _CaseCommunicationHistoryObj.SentCC = "3333";
            _CaseCommunicationHistoryObj.Subject = "3333";
            _CaseCommunicationHistoryObj.Message = "Mss333sssssse";
            _CaseCommunicationHistoryObj.UserID = 254;
            _CaseCommunicationHistoryObj.UploadPath = @"SFASFDG.txt";
            int result = BL.AddCaseCommunicationHistory(_CaseCommunicationHistoryObj);
            Assert.IsTrue(result > 0,"Not Added");
        }

        [TestMethod]
        public void GetCaseCommunicationHistoriesByCaseID()
        {
            var result = BL.GetCaseCommunicationHistoriesByCaseID(312);
            Assert.IsTrue(result != null, "Unable to Find");
        }
    }
}