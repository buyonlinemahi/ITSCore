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
* Date : 01/30/2013
* Version : 1.0
* Description : Add Test Method GetTreatmentCategoriesAreasofExpertiseByTreatmentCategoryID and GetTreatmentCategoriesAreasofExpertiseByAreasofExpertiseID to get  GetTreatmentCategoriesAreasofExpertise 
==================================================================================
*/


namespace CoreTest
{
    [TestClass]
    public class TreatmentCategoriesAreasofExpertiseTest
    {
        ITreatmentCategoriesAreasofExpertiseRepository _treatmentCategoriesAreasofExpertiseRepository;
        public TreatmentCategoriesAreasofExpertiseTest()
        {
        }

        [TestInitialize()]
        public void TreatmentCategoriesAreasofExpertiseRepositoryTestInit()
        {
            _treatmentCategoriesAreasofExpertiseRepository = new TreatmentCategoriesAreasofExpertisesRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetTreatmentCategoriesAreasofExpertiseByTreatmentCategoryID()
        {

            ITreatmentCategoriesAreasofExpertise _treatmentCategoriesAreasofExpertise = new TreatmentCategoriesAreasofExpertiseImpl(_treatmentCategoriesAreasofExpertiseRepository);
            IEnumerable<TreatmentCategoriesAreasofExpertise> TreatmentCategoriesAreasofExpertiseResult = _treatmentCategoriesAreasofExpertiseRepository.GetTreatmentCategoriesAreasofExpertiseByTreatmentCategoryID(1);
            Assert.IsTrue(TreatmentCategoriesAreasofExpertiseResult.Any());


        }
        [TestMethod]
        public void GetTreatmentCategoriesAreasofExpertiseByAreasofExpertiseID()
        {

            ITreatmentCategoriesAreasofExpertise _treatmentCategoriesAreasofExpertise = new TreatmentCategoriesAreasofExpertiseImpl(_treatmentCategoriesAreasofExpertiseRepository);
            IEnumerable<TreatmentCategoriesAreasofExpertise> TreatmentCategoriesAreasofExpertiseResult = _treatmentCategoriesAreasofExpertiseRepository.GetTreatmentCategoriesAreasofExpertiseByAreasofExpertiseID(1);
            Assert.IsTrue(TreatmentCategoriesAreasofExpertiseResult.Any());

        }
    }
}
