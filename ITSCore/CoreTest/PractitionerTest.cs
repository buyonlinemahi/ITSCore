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
  Page Name:      PractitionerTest.cs                    
  Version:  1.0                                              
   Revision History:                               
  1.0– 1/03/2013 Vishal
 * Description : add test method for PractitionerTest
 * 
  UpdatePractitionerByPractitionerID
 GetPractitionerByPractitionerID
 */
#endregion

namespace CoreTest
{


    [TestClass]
    public class PractitionerTest
    {

        IPractitionerRepository _practitionerRepository;


        public PractitionerTest()
        {
        }

        [TestInitialize()]
        public void PractitionerInit()
        {
            _practitionerRepository = new PractitionerRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }


        [TestMethod]
        public void Add_Practitioner()
        {
            IPractitioner practitionerService = new PractitionerImpl(_practitionerRepository);
            Practitioner __practitionerObj = new Practitioner();
            __practitionerObj.PractitionerFirstName = "PractitionerName";
            __practitionerObj.PractitionerLastName = "PractitionerLastName";
           int _practitionerResult = practitionerService.AddPractitioner(__practitionerObj);
            Assert.IsTrue(_practitionerResult != 0, "Error in inserting Practitioner !!!");
        }




        [TestMethod]
        public void Get_PractitionerLikePractitionerName()
        {
            IPractitioner practitionerService = new PractitionerImpl(_practitionerRepository);
            IEnumerable<Practitioner> _practitionerResult = practitionerService.GetPractitionerLikePractitionerName("2");
            Assert.IsTrue(_practitionerResult.Any());
        }



        [TestMethod]
        public void UpdatePractitionerByPractitionerID()
        {
            IPractitioner practitionerService = new PractitionerImpl(_practitionerRepository);
            Practitioner __practitionerObj = new Practitioner();
            __practitionerObj.PractitionerID = 61;
            __practitionerObj.PractitionerFirstName = "PractitionerFirstName UpdatedName";
            __practitionerObj.PractitionerLastName = "PractitionerLastName UpdatedName";
              int _practitionerResult = practitionerService.UpdatePractitionerByPractitionerID(__practitionerObj);
            Assert.IsTrue(_practitionerResult != 0, "Error in Updating Practitioner !!!");
        }

        [TestMethod]
        public void GetPractitionerByPractitionerID()
        {
            IPractitioner practitionerService = new PractitionerImpl(_practitionerRepository);
            Practitioner _practitionerResult = practitionerService.GetPractitionerByPractitionerID(61);
            Assert.IsTrue(_practitionerResult != null, "Get Practitioner By PractitionerID");
        }

        [TestMethod]
        public void DeletePractitionerByPractitionerID()
        {
            IPractitioner practitionerService = new PractitionerImpl(_practitionerRepository);
          
           int _practitionerResult = practitionerService.DeletePractitionerByPractitionerID(61);
            Assert.IsTrue(_practitionerResult != 0, "Error while delete Practitioner !!!");
        }

        [TestMethod]
        public void Get_PractitionersRecentlyAdded()
        {
            IPractitioner practitionerService = new PractitionerImpl(_practitionerRepository);
            IEnumerable<Practitioner> _PractitionerResult = practitionerService.GetPractitionersRecentlyAdded();
            Assert.IsTrue(_PractitionerResult.Any(), "Unable to Get PractitionersRecentlyAdded");
        }


    }
}
