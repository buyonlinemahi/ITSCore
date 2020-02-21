﻿using ITS.Core.BL;
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
    public class DurationTest
    {

        IDurationRepository _Duration;
        public DurationTest()
        {
        }

        [TestInitialize()]
        public void DurationRepositoryTestInit()
        {
            _Duration = new DurationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void Get_AllPatientRole()
        {
            IDuration service = new DurationImpl(_Duration);
            IEnumerable<Duration> DurationRepository = service.GetAllDuration();
            Assert.IsTrue(DurationRepository.Any());
        }


      
    }

}