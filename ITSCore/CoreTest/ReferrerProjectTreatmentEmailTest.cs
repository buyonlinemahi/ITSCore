using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

#region Comment

/*
  Page Name:      public class ReferrerProjectTreatmentEmailTest                      
  Version:  1.2                                              
  Purpose: Added,Update,Delete,GetReferrerProjectTreatmentId, GetReferrerProjectTreatmentEmailById,DeleteReferrerProjectTreatmentEmailById added methods                                                 
  Revision History:                               
  1.0 – 11/14/2012 Harpreet Singh  
 ==================================================================
 *Edited By : Vishal Sen
 *Dated : 11/15/2012
 *Description : modify Method GetAll_ReferrerProjectTreatmentEmailById
 *Description : modify Method AddReferrerProjectTreatmentEmailTest
 *Description : modify Method UpdateReferrerProjectTreatmentEmailTest
 *Description : modify Method DeleteReferrerTreatmentEmailByIdTest
 ======================================================================
 * 
   Revision History:                               
  1.1– 11/21/2012 Satya
 * Description : add test method for GetReferrerProjectTreatmentEmailByReferrerProjectTreatmentId
 * 
 * 
 * Edited By   : Pardeep Kumar
 * Dated       : 07/26/2013
 * Description : Added Test method GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID
 * Version     : 1.2
 * 
 
 */


#endregion


namespace CoreTest
{
    [TestClass]
    public class ReferrerProjectTreatmentEmailTest
    {

        IReferrerProjectTreatmentEmailRepostory _referrerProjectTreatmentEmailRepostory;

        IEmailTypeValueRepository _emailTypeValueRepository;

        //ITS.Core.BL.IEmailTypeValue _emailTypeValue;

        ITS.Core.BL.IReferrerProjectTreatmentEmail _referrerProjectTreatment;

        public ReferrerProjectTreatmentEmailTest()
        {
        }

        [TestInitialize()]
        public void ReferrerProjectTreatmentEmailTestInit()
        {
            _referrerProjectTreatmentEmailRepostory = new ReferrerProjectTreatmentEmailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _emailTypeValueRepository = new EmailTypeValueRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _referrerProjectTreatment = new ITS.Core.BL.Implementation.ReferrerProjectTreatmentEmailImpl(_referrerProjectTreatmentEmailRepostory, _emailTypeValueRepository);
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentEmailById()
        {
            ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail = _referrerProjectTreatmentEmailRepostory.GetById(13809);
            Assert.IsTrue(referrerProjectTreatmentEmail != null, "unable to get  Referrer Project Treatment Email");
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentEmailByReferrerProjectTreatmentId()
        {
            IEnumerable<ReferrerProjectTreatmentEmail> referrerProjectTreatmentEmail = _referrerProjectTreatmentEmailRepostory.GetByReferrerProjectTreatmentId(9982).ToList();
            Assert.IsTrue(referrerProjectTreatmentEmail.Any());
        }
        [TestMethod]
        public void GetReferrerProjectTreatmentByReferrerProjectTreatmentId()
        {
            IEnumerable<ReferrerProjectTreatment> referrerProjectTreatmentEmail = _referrerProjectTreatmentEmailRepostory.GetReferrerProjectTreatmentByTreatmentId(9982).ToList();
            Assert.IsTrue(referrerProjectTreatmentEmail.Any());
        }
        [TestMethod]
        public void GetReferrerIdAgtReferrerProjectTreatmentId()
        {
            int result = _referrerProjectTreatmentEmailRepostory.GetReferrerIdAgtReferrerProjectTreatmentId(9982);
        }

        [TestMethod]
        public void AddReferrerProjectTreatmentEmailTest()
        {
            ReferrerProjectTreatmentEmail _referrerProjectTreatmentEmailObj = new ReferrerProjectTreatmentEmail();
            _referrerProjectTreatmentEmailObj.ReferrerProjectTreatmentID = 4;
            _referrerProjectTreatmentEmailObj.EmailTypeID = 3;
            _referrerProjectTreatmentEmailObj.EmailTypeValueID = 2;
            int _ReferrerProjectTreatmentEmailResult = _referrerProjectTreatmentEmailRepostory.AddReferrerProjectTreatmentEmail(_referrerProjectTreatmentEmailObj);

            Assert.IsTrue(_ReferrerProjectTreatmentEmailResult != 0, "Error in inserting ReferrerProjectTreatmentEmail !!!");
        }

        [TestMethod]
        public void UpdateReferrerProjectTreatmentEmailTest()
        {
            ReferrerProjectTreatmentEmail _referrerProjectTreatmentEmailObj = new ReferrerProjectTreatmentEmail();
            _referrerProjectTreatmentEmailObj.ReferrerProjectTreatmentEmailID = 2;
            _referrerProjectTreatmentEmailObj.ReferrerProjectTreatmentID = 44;
            _referrerProjectTreatmentEmailObj.EmailTypeID = 34;
            _referrerProjectTreatmentEmailObj.EmailTypeValueID = 24;
            int _ReferrerProjectTreatmentEmailResult = _referrerProjectTreatmentEmailRepostory.UpdateReferrerProjectTreatmentEmail(_referrerProjectTreatmentEmailObj);

            Assert.IsTrue(_ReferrerProjectTreatmentEmailResult != 1, "Error in updating ReferrerProjectTreatmentEmail !!!");
        }

        [TestMethod]
        public void DeleteReferrerTreatmentEmailByIdTest()
        {
            int _ReferrerProjectTreatmentEmailResult = _referrerProjectTreatmentEmailRepostory.DeleteReferrerProjectTreatmentEmailById(1);
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID()
        {
            int referrerProjectTreatmentID = 8361;
            var result = _referrerProjectTreatment.GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID(referrerProjectTreatmentID).ToList();

           // result = _referrerProjectTreatmentEmailRepostory.GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID(referrerProjectTreatmentID);
            Assert.IsTrue(result.Any() != false, "Error in getting Records");
        }
    }
}
