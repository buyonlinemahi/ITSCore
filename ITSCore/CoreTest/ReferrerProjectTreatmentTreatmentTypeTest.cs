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
    public class ReferrerProjectTreatmentTreatmentTypeTest
    {
        [TestMethod]
        public void ReferrerProjectTreatmentTreatmentType_BL()
        {
            IReferrerProjectTreatmentTreatmentTypeRepository repo = new ReferrerProjectTreatmentTreatmentTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            IReferrerProjectTreatmentTreatmentType service = new ReferrerProjectTreatmentTreatmentTypeImpl(repo);
            const int referrerProjectTreatmentID = 9;
            IEnumerable<ReferrerProjectTreatmentTreatmentType> expected  = service.GetReferrerProjectTreatmentTreatmentTypeByReferrerProjectTreatmentTypeID(referrerProjectTreatmentID);

            Assert.IsTrue(expected.Any());

        }
    }
}
