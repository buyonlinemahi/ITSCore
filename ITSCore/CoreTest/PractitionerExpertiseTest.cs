using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

#region Comment

/*
  Page Name:      PractitionerExpertiseTest.cs                    
  Version:  1.0                                              
   Revision History:                               
  1.0– 1/03/2013 Vishal
 * Description : add test methods for PractitionerExpertiseTest
 * 
GetPractitionerExpertiseByPractitionerExpertiseID
GetPractitionerExpertiseByPractitionerID
GetPractitionerExpertiseByAreaofExpertiseID
DeletePractitionerExpertiseByPractitionerExpertiseID
UpdatePractitionerExpertiseByPractitionerExpertiseID
 =============================================================
 * Version : 1.1
 * Modified By : Manjit Singh
 * Date : 08-March-2013
 * Description : Removed TreatmentCategoryID Field 
 */
#endregion

namespace CoreTest
{


    [TestClass]
    public class PractitionerExpertiseTest
    {

        IPractitionerExpertiseRepository _practitionerExpertiseRepository;


        public PractitionerExpertiseTest()
        {
        }

        [TestInitialize()]
        public void PractitionerExpertiseInit()
        {
            _practitionerExpertiseRepository = new PractitionerExpertiseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }


        [TestMethod]
        public void Add_PractitionerExpertise()
        {
            IPractitionerExpertise practitionerExpertiseService = new PractitionerExpertiseImpl(_practitionerExpertiseRepository);
            PractitionerExpertise __practitionerExpertiseObj = new PractitionerExpertise();
            __practitionerExpertiseObj.PractitionerID = 1;
            __practitionerExpertiseObj.AreaofExpertiseID = 1;
            //  __practitionerExpertiseObj.TreatmentCategoryID = 1;
            int _practitionerExpertiseResult = practitionerExpertiseService.AddPractitionerExpertise(__practitionerExpertiseObj);
            Assert.IsTrue(_practitionerExpertiseResult != 0, "Error in inserting Practitioner Expertise!!!");
        }


        [TestMethod]
        public void GetPractitionerExpertiseByPractitionerExpertiseID()
        {
            IPractitionerExpertise practitionerExpertiseService = new PractitionerExpertiseImpl(_practitionerExpertiseRepository);
            PractitionerExpertise _practitionerExpertiseResult = practitionerExpertiseService.GetPractitionerExpertiseByPractitionerExpertiseID(2);
            Assert.IsTrue(_practitionerExpertiseResult != null, "Error in Get Practitioner Expertise!!!");
        }

        [TestMethod]
        public void GetPractitionerExpertiseByPractitionerID()
        {
            IPractitionerExpertise practitionerExpertiseService = new PractitionerExpertiseImpl(_practitionerExpertiseRepository);

            IEnumerable<PractitionerExpertise> _practitionerExpertiseResult = practitionerExpertiseService.GetPractitionerExpertiseByPractitionerID(157);
            Assert.IsTrue(_practitionerExpertiseResult.Any());
        }

        [TestMethod]
        public void GetPractitionerExpertiseByAreaofExpertiseID()
        {
            IPractitionerExpertise practitionerExpertiseService = new PractitionerExpertiseImpl(_practitionerExpertiseRepository);

            IEnumerable<PractitionerExpertise> _practitionerExpertiseResult = practitionerExpertiseService.GetPractitionerExpertiseByAreaofExpertiseID(1);
            Assert.IsTrue(_practitionerExpertiseResult.Any());
        }

        [TestMethod]
        public void DeletePractitionerExpertiseByPractitionerExpertiseID()
        {
            IPractitionerExpertise practitionerExpertiseService = new PractitionerExpertiseImpl(_practitionerExpertiseRepository);
            int _practitionerExpertiseResult = practitionerExpertiseService.DeletePractitionerExpertiseByPractitionerExpertiseID(2);
            Assert.IsTrue(_practitionerExpertiseResult != 0, "Error in delete Practitioner Expertise!!!");
        }

        [TestMethod]
        public void DeletePractitionerExpertiseByPractitionerID()
        {
            IPractitionerExpertise practitionerExpertiseService = new PractitionerExpertiseImpl(_practitionerExpertiseRepository);
            int _practitionerExpertiseResult = practitionerExpertiseService.DeletePractitionerExpertiseByPractitionerID(159);
            Assert.IsTrue(_practitionerExpertiseResult != 0, "Error in delete Practitioner Expertise!!!");
        }


        [TestMethod]
        public void UpdatePractitionerExpertiseByPractitionerExpertiseID()
        {
            IPractitionerExpertise practitionerExpertiseService = new PractitionerExpertiseImpl(_practitionerExpertiseRepository);
            IEnumerable<PractitionerExpertise> _practitionerExpertiseResult = practitionerExpertiseService.GetPractitionerExpertiseByPractitionerID(163);
            practitionerExpertiseService.UpdatePractitionerExpertise(_practitionerExpertiseResult.ToList());
            _practitionerExpertiseResult = practitionerExpertiseService.GetPractitionerExpertiseByPractitionerID(163);
            Assert.IsTrue(_practitionerExpertiseResult.First().AreaofExpertiseID == 1, "Error in Updating Practitioner Expertise!!!");
        }




    }
}
