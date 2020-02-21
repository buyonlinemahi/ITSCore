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
    public class ReferrerProjectTreatmentNameTest
    {


        [TestMethod]
        public void GetReferrerProjectByReferrerProjectID_RepoTest()
        {
            IReferrerProjectTreatmentNameRepository _referrerProjectTreatmentNameRepository =
                new ReferrerProjectTreatmentNameRepository(
                    new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            var referrerProjectID = 1;

            IEnumerable<ReferrerProjectTreatmentName> referrerProjectTreatmentNames =
                _referrerProjectTreatmentNameRepository.GetReferrerProjectTreatmentNamesByReferrerProjectID(referrerProjectID);

            Assert.IsTrue(referrerProjectTreatmentNames.Any());
        }

        [TestMethod]
        public void GetReferrerProjectByReferrerProjectID_BLTest()
        {
            IReferrerProjectTreatmentName service =
                new ReferrerProjectTreatmentNameImpl(new ReferrerProjectTreatmentNameRepository(
                                                         new Core.Base.Data.SqlServer.Factory.BaseContextFactory
                                                             <ITS.Core.Data.SqlServer.ITSDBContext>()));
            var referrerProjectID = 1;
            IEnumerable<ReferrerProjectTreatmentName> referrerProjectTreatmentNames =
                service.GetReferrerProjectTreatmentNamesByReferrerProjectID(referrerProjectID);

            Assert.IsTrue(referrerProjectTreatmentNames.Any());
        }

        [TestMethod]
        public void GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID_BLTest()
        {
            IReferrerProjectTreatmentName service =
                new ReferrerProjectTreatmentNameImpl(new ReferrerProjectTreatmentNameRepository(
                                                         new Core.Base.Data.SqlServer.Factory.BaseContextFactory
                                                             <ITS.Core.Data.SqlServer.ITSDBContext>()));
            var referrerProjectID = 2578;
            IEnumerable<ReferrerProjectTreatmentName> referrerProjectTreatmentNames =
                service.GetReferrerEnabledProjectTreatmentNamesByReferrerProjectID(referrerProjectID);

            Assert.IsTrue(referrerProjectTreatmentNames.Any());
        }

    }





}
