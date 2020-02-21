using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


namespace CoreTest
{

    [TestClass]
    public class ComplaintStatusTest
    {

        IComplaintStatusRepository _ComplaintStatusRepository;
        public ComplaintStatusTest()
        {
        }

        [TestInitialize()]
        public void ComplaintStatusRepositoryTestInit()
        {
            _ComplaintStatusRepository = new ComplaintStatusRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllComplaintStatus()
        {
            IComplaintStatus complaintStatusService = new ComplaintStatusImpl(_ComplaintStatusRepository);
            IEnumerable<ComplaintStatus> ComplaintStatusService = complaintStatusService.GetAllComplaintStatus();
            Assert.IsTrue(ComplaintStatusService.Any());

        }


      
    }

}