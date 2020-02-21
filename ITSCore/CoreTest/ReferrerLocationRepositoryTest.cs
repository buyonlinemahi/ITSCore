using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
/*
  Page Name:  ReferrerLocationRepositoryTest.cs                      
  Version:   1.4  
  Description : Added a test method for Delete method of ReferrerlocationRepository
                                                       
 
 Revision History:                                            
                                                           
  1.0 – 10/30/2012  Anuj Batra
  Purpose:  Create a test file for ReferrerLocationRepository test and added a test method for Update method of ReferrerlocationRepository.

 * Edited By :   Robin Singh
 * Date:         10/30/2012
   Version  :    1.1
   Description : Added a test method for Delete method of ReferrerlocationRepository

  * *Edited By :   Vishal
  Version  :    1.2
  Description : Added a test method for for get referrerlocations by GetReferrerLocationsByReferrerID
 * 
  ModifiedDate: 10/30/2012  
 *Edited By :   Satya
  Version  :    1.3
  Description : Added a test method  to add referrerlocations
  ModifiedDate: 10/30/2012  
 * 
 *   ModifiedDate: 11/28/2012  
 *Edited By :   Vijay Kumar
  Version  :    1.4
  Description : Added a test method  to update LocationMainOffice
  
 * 
 */

namespace CoreTest
{
    [TestClass]
    public class ReferrerLocationRepositoryTest
    {
        IReferrerLocationRepository _referrerLocationRepository;

        [TestInitialize()]
        public void ReferrerRepositoryInit()
        {
            _referrerLocationRepository = new ReferrerLocationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void AddReferrerLocation()
        {
            ReferrerLocation referrerLocation = new ReferrerLocation();
            referrerLocation.Address = "Address ";
            referrerLocation.Name = "Name";
            referrerLocation.PostCode = "PostCode";
            //referrerLocation.City = "City";
           // referrerLocation.Region = "Region";
            referrerLocation.ReferrerID = 411;
            referrerLocation.IsActive = true;
            referrerLocation.IsMainOffice = true;


            int referrer = _referrerLocationRepository.AddReferrerLocation(referrerLocation);
            Assert.IsTrue(referrer != 0, "Unable to insert");
        }

        [TestMethod]
        public void CanUpdateReferrerLocation()
        {
            IReferrerLocation ob = new ReferrerLocationImpl(_referrerLocationRepository);
            ReferrerLocation referrerObj = _referrerLocationRepository.GetAll().Last();
            referrerObj.Name = "Testing";
            referrerObj.Region = "test";
            referrerObj.IsMainOffice = true;
            int returnValue = ob.UpdateReferrerLocation(referrerObj);
            referrerObj = _referrerLocationRepository.GetAll().Last();
            Assert.AreEqual("Testing", referrerObj.Name);
        }
        [TestMethod]
        public void can_delete_referrer_location()
        {
            int result = _referrerLocationRepository.DeleteByReferrerLocationID(_referrerLocationRepository.GetAll().Last().ReferrerLocationID);
            Assert.IsTrue(result == 1, "Deleted");
        }

        [TestMethod]
        public void GetReferrerLocationsByReferrerID()
        {
            IEnumerable<ReferrerLocation> ReferrerLocation = _referrerLocationRepository.GetReferrerLocationsByReferrerID(388);
            Assert.IsTrue(ReferrerLocation.Any());
        }

        [TestMethod]
        public void get_referrer_main_location()
        {
            ReferrerLocation location = _referrerLocationRepository.GetMainReferrerLocationByReferrerID(359);
            Assert.IsTrue(location != null && location.IsMainOffice, "unable to get referrer main location");
        }

        [TestMethod]
        public void Update_Referrer_Location_MainOffice()
        {
            int location = _referrerLocationRepository.UpdateReferrerLocationMainOffice(388, 308);
            Assert.IsTrue(location != 1, "unable to update main location");
        }



    }
}
