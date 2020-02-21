using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*

* Latest Version :1.0
=========================================================================================
* Created By : Robin Singh
* Date : 01/01/2013
* Version : 1.0
* Description : Add Test Method For TreatmentType to get  AllTreatmentTypes and TreatmentTypeByTreatmentCategoryID
==================================================================================
*/


namespace CoreTest
{
    [TestClass]
    public class TreatmentTypeTest
    {
        ITreatmentTypeRepository _treatmentTypeRepository;
        public TreatmentTypeTest()
        {
        }

        [TestInitialize()]
        public void TreatmentTypeRepositoryTestInit()
        {
            _treatmentTypeRepository = new TreatmentTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void GetAllTreatmentType()
        {

            ITreatmentType _treatmentType = new TreatmentTypeImpl(_treatmentTypeRepository);
            IEnumerable<TreatmentType> TreatmentTypeResult = _treatmentType.GetAllTreatmentType();
            Assert.IsTrue(TreatmentTypeResult.Any());

        }
        
    }
}
