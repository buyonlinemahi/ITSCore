using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{


    [TestClass]
    public class ReferrerProjectTreatmentDocumentSetupTest
    {
        IReferrerProjectTreatmentDocumentSetupRepository _referrerProjectTreatmentDocumentSetupRepository;


        [TestInitialize()]
        public void ReferrerProjectTreatmentDocumentSetupTestInit()
        {
            _referrerProjectTreatmentDocumentSetupRepository = new ReferrerProjectTreatmentDocumentSetupRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID()
        {
            IEnumerable<ReferrerProjectTreatmentDocumentSetup> referrerProjectTreatmentDocumentSetup = _referrerProjectTreatmentDocumentSetupRepository.GetReferrerProjectTreatmentDocumentSetupByReferrerProjectTreatmentID(9982).ToList();
            Assert.IsTrue(referrerProjectTreatmentDocumentSetup.Any());
        }

        [TestMethod]
        public void Add_ReferrerProjectTreatmentDocumentSetup()
        {
            ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentDocumentSetup = new ReferrerProjectTreatmentDocumentSetup();
            referrerProjectTreatmentDocumentSetup.DocumentSetupTypeID = 1;
            referrerProjectTreatmentDocumentSetup.AssessmentServiceID = 1;
            referrerProjectTreatmentDocumentSetup.ReferrerProjectTreatmentID = 2581;
            int rv = _referrerProjectTreatmentDocumentSetupRepository.AddReferrerProjectTreatmentDocumentSetup(referrerProjectTreatmentDocumentSetup);
            Assert.IsTrue(rv != 0, "Unable to insert");
        }

        [TestMethod]
        public void Update_ReferrerProjectTreatmentDocumentSetup()
        {
            ReferrerProjectTreatmentDocumentSetup referrerProjectTreatmentDocumentSetup = new ReferrerProjectTreatmentDocumentSetup();
            referrerProjectTreatmentDocumentSetup.ReferrerProjectTreatmentDocumentSetupID = 6;
            referrerProjectTreatmentDocumentSetup.DocumentSetupTypeID = 2;
            referrerProjectTreatmentDocumentSetup.AssessmentServiceID = 1;
            referrerProjectTreatmentDocumentSetup.ReferrerProjectTreatmentID = 2580;

            int returnValue = _referrerProjectTreatmentDocumentSetupRepository.UpdateReferrerProjectTreatmentDocumentSetup(referrerProjectTreatmentDocumentSetup);
            Assert.IsTrue(returnValue != 0, "Unable to update");
        }


    }



}
