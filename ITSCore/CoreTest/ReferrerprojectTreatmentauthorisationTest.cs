using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;




/// <summary>
/// 
/// 
/// Summary description for ReferrerProjectAuthorisationTest
/// </summary>
/// 


/* Author: Vijay Kumar
 * Latest Version : 1.1
 * Description : Add Test Method For ReferrerProjectTreatmentAuthorisationTest
 ===============================================================================================  
 * 
 * /* Revised History:
 * Edited By : Vijay Kumar.
 * Latest Version : 1.0
 * Description : Add Test Method For ReferrerProjectTreatmentAuthorisationTest
 * 
 *  * /* Revised History:
 * Edited By : Vijay Kumar.
 * Latest Version : 1.1
 * Description : Add Delete Test Method For ReferrerProjectTreatmentAuthorisationTest
 */

namespace CoreTest
{
    [TestClass]
    public class ReferrerprojectTreatmentauthorisationTest
    {
       
        public  ReferrerprojectTreatmentauthorisationTest()
        {
         
        }
        IReferrerProjectTreatmentAuthorisationRepository _referrerProjectTreatmentAuthorisationRepository;
        

        [TestInitialize()]
        public void ReferrerprojectTreatmentauthorisationTestInit()
        {
            _referrerProjectTreatmentAuthorisationRepository = new ReferrerProjectTreatmentAuthorisationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }



        [TestMethod]
        public void GetAll_ReferrerProjectTreatmentAuthorisation()
        {
            IEnumerable<ReferrerProjectTreatmentAuthorisation> _referrerProjectTreatmentAuthorisationOBJ = _referrerProjectTreatmentAuthorisationRepository.GetAll();
            Assert.IsTrue(_referrerProjectTreatmentAuthorisationOBJ.Any());
        }


   

        [TestMethod]
        public void AddReferrerProjectTreatmentAuthorisation()
        {
            ReferrerProjectTreatmentAuthorisation _referrerProjectTreatmentAuthorisationOBJ = new ReferrerProjectTreatmentAuthorisation();
            _referrerProjectTreatmentAuthorisationOBJ.TreatmentCategoryID = 2;
            _referrerProjectTreatmentAuthorisationOBJ.DelegatedAuthorisationTypeID = 1;
            _referrerProjectTreatmentAuthorisationOBJ.Amount=12102;
            _referrerProjectTreatmentAuthorisationOBJ.ReferrerProjectTreatmentID = 1995;
            int rv = _referrerProjectTreatmentAuthorisationRepository.AddReferrerProjectTreatmentAuthorisation(_referrerProjectTreatmentAuthorisationOBJ);
            Assert.AreNotEqual(0, rv, "Successfully inserted");
        }

        [TestMethod]
        public void UpdateReferrerProjectTreatmentAuthorisation()
        {
            ReferrerProjectTreatmentAuthorisation _referrerProjectTreatmentAuthorisationOBJ = new ReferrerProjectTreatmentAuthorisation();
            _referrerProjectTreatmentAuthorisationOBJ.TreatmentCategoryID = 1;
            _referrerProjectTreatmentAuthorisationOBJ.DelegatedAuthorisationTypeID = 2;
            _referrerProjectTreatmentAuthorisationOBJ.Amount = 1211;        
            _referrerProjectTreatmentAuthorisationOBJ.ReferrerProjectTreatmentAuthorisationID = 92;
            _referrerProjectTreatmentAuthorisationOBJ.ReferrerProjectTreatmentID = 1995;
     
            int rv = _referrerProjectTreatmentAuthorisationRepository.UpdateReferrerProjectTreatmentAuthorisation(_referrerProjectTreatmentAuthorisationOBJ);
            Assert.AreEqual(1, rv, "Successfully Update");
        }

        [TestMethod]
        public void Delete_ReferrerProjectAuthorisation()
        {

            int deleted = _referrerProjectTreatmentAuthorisationRepository.DeleteReferrerProjectTreatmentAuthorisation(82);
            Assert.AreEqual(1, deleted, "Success to Delete");
            
        }


        [TestMethod]
        public void Get_ReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID()
        {
            IEnumerable<ReferrerProjectTreatmentAuthorisation> _referrerProjectTreatmentAuthorisationTest = _referrerProjectTreatmentAuthorisationRepository.GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID(10067);

            Assert.IsTrue(_referrerProjectTreatmentAuthorisationTest.Any());

        }

    }
}
