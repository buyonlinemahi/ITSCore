using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/*
 * Latest Version : 1.1
 * 
 * Author  : Pardeep Kumar
 * Date    : 15-Nov-2012
 
 * Version :  1.1
 * UpdatedBy:  Anuj Batra
 * Description: Modified the file as wrong repository object was exicted. 
 * 
 */


namespace CoreTest
{
    [TestClass]
    public class TreatmentCategoryPricingTypesTest
    {
        ITreatmentCategoryPricingTypesRepository _treatmentCategoryPricingTypes;

        public TreatmentCategoryPricingTypesTest()
        {
            _treatmentCategoryPricingTypes = new TreatmentCategoryPricingTypesRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }


        [TestMethod]
        public void GetPricingTypesByTreatmentCategoryID()
        {
            ITS.Core.BL.ITreatmentCategoryPricingTypes treatmentCategoryPricingTypes = new ITS.Core.BL.Implementation.TreatmentCategoryPricingTypesImpl(_treatmentCategoryPricingTypes);
            IEnumerable<TreatmentCategoryPricingTypes> _treatmentCategoryPricingTypesObj = treatmentCategoryPricingTypes.GetPricingTypesByTreatmentCategoryID(1);
            Assert.IsTrue(_treatmentCategoryPricingTypesObj.Any());
        }
    }
}
