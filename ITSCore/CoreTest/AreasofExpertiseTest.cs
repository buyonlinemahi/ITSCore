using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

#region Comments

/*
 * Latest Version : 1.1
 * 
 * Author         : Vishal
 * Date           : 01-Jan-2013
 * Version        : 1.0
 * Description    : Added GetAll Mehtod for AreasofExpertiseTest
 * 
 * Author         : harpreet Singh
 * Date           : 07-Jan-2013
 * Version        : 1.1
 * Description    : Added GetAllAreasofExpertiseByTreatmentCategoryID Mehtod for AreasofExpertiseTest
 */

#endregion

namespace CoreTest
{
    [TestClass]
    public class AreasofExpertiseTest
    {
        IAreasofExpertiseRepository _areasofExpertiseRepository;

        public AreasofExpertiseTest()
        {

        }

        [TestInitialize()]
        public void AreasofExpertiseRepositoryInit()
        {
            _areasofExpertiseRepository = new AreasofExpertiseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }

        [TestMethod]
        public void GetAllAreasofExpertise()
        {
            IEnumerable<AreasofExpertise> areasofExpertise = _areasofExpertiseRepository.GetAll();

            Assert.IsTrue(areasofExpertise.Any());
        }

        

    }
}