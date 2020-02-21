using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Summary description for DelegatedAuthorisationTypesTest
/// </summary>
/// 
/*
 * 
 * Latest Version :1.0
=========================================================================================
* Created By : Vijay Kumar
* Date : 06-Dec-2012
* Version : 1.0
* Description : Add Test Method For DelegatedAuthorisationTypesTest to get  GetAllDelegatedAuthorisationTypes
==================================================================================
*/



namespace CoreTest
{
    [TestClass]
    public class DelegatedAuthorisationTypesTest
    {
        IDelegatedAuthorisationTypesRepository _delegatedAuthorisationTypesRepository;
        public DelegatedAuthorisationTypesTest()
        {

        }

        [TestInitialize()]
        public void DelegatedAuthorisationTypesRepositoryInit()
        {
            _delegatedAuthorisationTypesRepository = new DelegatedAuthorisationTypesRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllDelegatedAuthorisationTypes()
        {
            IEnumerable<DelegatedAuthorisationTypes> delegatedAuthorisationTypes = _delegatedAuthorisationTypesRepository.GetAll();
            Assert.IsTrue(delegatedAuthorisationTypes.Any());
        }
    }
}
