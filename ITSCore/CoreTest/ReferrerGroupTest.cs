using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using BLModel = ITS.Core.BL.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreTest
{
    [TestClass]
    public class ReferrerGroupTest
    {
        private IReferrerGroupRepository _referrerGroupRepository;

        public ReferrerGroupTest()
        {
        }

        [TestInitialize()]
        public void ReferrerGroupTestTestInit()
        {
            _referrerGroupRepository = new ReferrerGroupRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void AddReferrerGroup()
        {           
            UpdateReferrerGroup _obj = new UpdateReferrerGroup();
            _obj.GroupName = "CoreTest";
            _obj.UserID = "1,2,3";
            _obj.ReferrerID = 498;
            int _Result = _referrerGroupRepository.AddReferrerGroup(_obj);
            Assert.IsTrue(_Result != 0, "Error in inserting Records !!!");
        }

        

        [TestMethod]
        public void GetGroupUserByRefID()
        {
            IEnumerable<ReferrerGroup> _Result = _referrerGroupRepository.GetReferrerGroupUsersByreferrerID(566);
            Assert.IsTrue(_Result.Any(), "Error in Getting result !!!");
        }

        [TestMethod]

        public void Delete_GroupByID()
        {
            int _Result = _referrerGroupRepository.DeleteGroupByID(5);
            Assert.IsTrue(_Result != 0, "Error in Deleting _Case !!!");

        }

        [TestMethod]
        public void GetGroupUserByname()
        {
            IEnumerable<ReferrerUserDetail> _Result = _referrerGroupRepository.GetGroupUsersByReferrerIDAndName("565623564", 566);
            Assert.IsTrue(_Result.Any(), "Error in Getting result !!!");
        }


        [TestMethod]
        public void GetGroupUserByReferrerID()
        {
            IEnumerable<ReferrerSupplierCases> _Result = _referrerGroupRepository.Get_ReferrerGroupUsersCasesByReferrerID("565623564", 566, 0, 50);
            Assert.IsTrue(_Result.Any(), "Error in Getting result !!!");
        }

        [TestMethod]
        public void GetGroupUserBynameAndCount()
        {
            int _Result = _referrerGroupRepository.GetReferrerGroupUsersCasesByReferrerIDCount("565623564", 566);
            Assert.IsTrue(_Result != null, "Error in Getting result !!!");
        }


        [TestMethod]
        public void UpdateGroupName()
        {
            UpdateReferrerGroup _obj = new UpdateReferrerGroup();
            _obj.NewName = "CoreTest";
            _obj.GroupName = "Coredemo200000000000";
            _obj.ReferrerID = 593;
            _obj.UserID = "596,593,560";
            int _Result = _referrerGroupRepository.UpdateReferrerGroup(_obj);
            Assert.IsTrue(_Result != 0, "Error in inserting Records !!!");
        }

    }
}
