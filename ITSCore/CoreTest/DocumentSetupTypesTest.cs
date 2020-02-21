using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;



/// <summary>
/// Summary description for DocumentSetupTypesTest
/// </summary>
/// 
/*
 * 
 * Latest Version :1.0
=========================================================================================
* Created By : Vijay Kumar
* Date : 06-Dec-2012
* Version : 1.0
* Description : Add Test Method For DocumentSetupTypesTest to get  GetAllDocumentSetupTypes
==================================================================================
*/

namespace CoreTest
{
 
    [TestClass]
    public class DocumentSetupTypesTest
    {
        IDocumentSetupTypesRepository _documentSetupTypesRepository;
        public DocumentSetupTypesTest()
        {

        }

        [TestInitialize()]
        public void DocumentSetupTypesRepositoryInit()
        {
            _documentSetupTypesRepository = new DocumentSetupTypesRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        [TestMethod]
        public void GetAllDocumentSetupTypes()
        {
            IEnumerable<DocumentSetupTypes> documentSetupTypes = _documentSetupTypesRepository.GetAll();
            Assert.IsTrue(documentSetupTypes.Any());
        }


    }
}
