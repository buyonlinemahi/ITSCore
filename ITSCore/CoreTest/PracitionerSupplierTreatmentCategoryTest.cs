using ITS.Core.BL;
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
    public class PracitionerSupplierTreatmentCategoryTest
    {


        IPracitionerSupplierTreatmentCategoryRepository _pracitionerSupplierTreatmentCategoryRepository;

        public PracitionerSupplierTreatmentCategoryTest()
        {

        }
        [TestInitialize()]
        public void PracitionerSupplierTreatmentCategoryTestRepositoryInit()
        {
            _pracitionerSupplierTreatmentCategoryRepository = new PracitionerSupplierTreatmentCategoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }

        [TestMethod]
        public void GetSupplierPractitionerTreatmentRegistrationsBySupplierID()
        {

            //this Test for BL Layer
            IPracitionerSupplierTreatmentCategory pracitionerSupplierTreatmentCategoryBL = new PracitionerSupplierTreatmentCategoryImpl(_pracitionerSupplierTreatmentCategoryRepository);
            IEnumerable<PracitionerSupplierTreatmentCategory> pracitionerSupplierTreatmentCategory = pracitionerSupplierTreatmentCategoryBL.GetPracitionersByTreatmentCategoryIDAndSupplierID(360, 1);
            Assert.IsTrue(pracitionerSupplierTreatmentCategory.Any());

        }


    }
}
