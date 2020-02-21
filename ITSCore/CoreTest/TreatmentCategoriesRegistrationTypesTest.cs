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
* Description : Add Test Method GetTreatmentCategoriesRegistrationTypeByTreatmentCategoryID and GetTreatmentCategoriesRegistrationTypeByRegistrationTypeID to get GetTreatmentCategoriesRegistrationType
==================================================================================
*/


namespace CoreTest
{
    [TestClass]
    public class TreatmentCategoriesRegistrationTypesTest
    {
        ITreatmentCategoriesRegistrationTypeRepository _treatmentCategoriesRegistrationTypeRepository;
        public TreatmentCategoriesRegistrationTypesTest()
        {
        }

        [TestInitialize()]
        public void TreatmentCategoriesTreatmentTypeRepositoryTestInit()
        {
            _treatmentCategoriesRegistrationTypeRepository = new TreatmentCategoriesRegistrationTypeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetTreatmentCategoriesRegistrationTypeByTreatmentCategoryID()
        {

            ITreatmentCategoriesRegistrationType _treatmentCategoriesRegistrationType = new TreatmentCategoriesRegistrationTypeImpl(_treatmentCategoriesRegistrationTypeRepository);
            IEnumerable<TreatmentCategoriesRegistrationType> TreatmentCategoriesRegistrationTypeResult = _treatmentCategoriesRegistrationTypeRepository.GetTreatmentCategoriesRegistrationTypeByTreatmentCategoryID(1);
            Assert.IsTrue(TreatmentCategoriesRegistrationTypeResult.Any());


        }
        [TestMethod]
        public void GetTreatmentCategoriesRegistrationTypeByRegistrationTypeID()
        {

            ITreatmentCategoriesRegistrationType _treatmentCategoriesRegistrationType = new TreatmentCategoriesRegistrationTypeImpl(_treatmentCategoriesRegistrationTypeRepository);
            IEnumerable<TreatmentCategoriesRegistrationType> TreatmentCategoriesRegistrationTypeResult = _treatmentCategoriesRegistrationTypeRepository.GetTreatmentCategoriesRegistrationTypeByRegistrationTypeID(1);
            Assert.IsTrue(TreatmentCategoriesRegistrationTypeResult.Any());

        }
    }
}
