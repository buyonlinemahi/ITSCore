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
    public class ComplaintTypeTest
    {

        IComplaintTypeRepository _ComplaintTypeRepository;
        public ComplaintTypeTest()
        {
        }

        [TestInitialize()]
        public void ComplaintTypeRepositoryTestInit()
        {
            _ComplaintTypeRepository = new ComplaintTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllCComplaintType()
        {
            IComplaintType complaintTypeService = new ComplaintTypeImpl(_ComplaintTypeRepository);
            IEnumerable<ComplaintType> ComplaintTypeService = complaintTypeService.GetAllComplaintType();
            Assert.IsTrue(ComplaintTypeService.Any());

        }


      
    }

}