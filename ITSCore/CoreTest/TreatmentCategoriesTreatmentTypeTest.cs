using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/*

* Latest Version :1.0
=========================================================================================
* Created By : Robin Singh
* Date : 01/25/2013
* Version : 1.0
* Description : Add Test Method For GetTreatmentCategoriesTreatmentType to get  GetTreatmentCategoriesTreatmentTypeByTreatmentCategoryID and GetTreatmentCategoriesTreatmentTypeByTreatmentTypeID
==================================================================================
*/


namespace CoreTest
{
    [TestClass]
    public class TreatmentCategoriesTreatmentTypeTest
    {
        ITreatmentCategoriesTreatmentTypeRepository _treatmentCategoriesTreatmentTypeRepository;
        public TreatmentCategoriesTreatmentTypeTest()
        {
        }

        [TestInitialize()]
        public void TreatmentCategoriesTreatmentTypeRepositoryTestInit()
        {
            _treatmentCategoriesTreatmentTypeRepository = new TreatmentCategoriesTreatmentTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetTreatmentCategoriesTreatmentTypeByTreatmentCategoryID()
        {

            ITreatmentCategoriesTreatmentType _treatmentCategoriesTreatmentType = new TreatmentCategoriesTreatmentTypeImpl(_treatmentCategoriesTreatmentTypeRepository);
            IEnumerable<TreatmentCategoriesTreatmentType> TreatmentCategoriesTreatmentTypeResult = _treatmentCategoriesTreatmentType.GetTreatmentCategoriesTreatmentTypeByTreatmentCategoryID(1);
            Assert.IsTrue(TreatmentCategoriesTreatmentTypeResult.Any());

        }
        [TestMethod]
        public void GetTreatmentCategoriesTreatmentTypeByTreatmentTypeID()
        {

            ITreatmentCategoriesTreatmentType _treatmentCategoriesTreatmentType = new TreatmentCategoriesTreatmentTypeImpl(_treatmentCategoriesTreatmentTypeRepository);
            IEnumerable<TreatmentCategoriesTreatmentType> TreatmentCategoriesTreatmentTypeResult = _treatmentCategoriesTreatmentType.GetTreatmentCategoriesTreatmentTypeByTreatmentTypeID(1);
            Assert.IsTrue(TreatmentCategoriesTreatmentTypeResult.Any());

        }
    }
}
