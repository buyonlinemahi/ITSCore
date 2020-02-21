using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{

    using ITS.Core.BL;
    using ITS.Core.BL.Implementation;
    using ITS.Core.Data;
    using ITS.Core.Data.Model;
    using ITS.Core.Data.SqlServer.Repository;

    [TestClass]
    public class CaseHistoryTest
    {
        private ICaseHistoryRepository repo;

        [TestInitialize()]
        public void CaseInit()
        {
            repo = new CaseHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }

        [TestMethod]
        public void Add_CaseHistory()
        {
            ICaseHistory service = new CaseHistoryImpl(repo);
            var result = service.AddCaseHistory(new CaseHistory
                                               {
                                                   CaseID = 7,
                                                   EventDate = DateTime.Now,
                                                   UserID = 1,
                                                   EventDescription = "testDesc",
                                                   EventTypeID = 1
                                               });
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Get_CaseHistories()
        {
            ICaseHistory service = new CaseHistoryImpl(repo);
            List<CaseHistory> result = service.GetCaseHistories().ToList();
            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void GetCaseHistoriesByCaseID()
        {
            ICaseHistory service = new CaseHistoryImpl(repo);
            IEnumerable<CaseHistoryUser> result = service.GetCaseHistoriesByCaseID(124);
            Assert.IsTrue(result.Any());
        }

    }
    

    

    
}
