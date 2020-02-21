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
   public class ProposedTreatmentMethodTest
    {

        IProposedTreatmentMethodRepository _proposedTreatmentMethodyRepository;
         public ProposedTreatmentMethodTest()
        {
        }

        [TestInitialize()]
         public void ProposedTreatmentMethodTestInit()
        {
            _proposedTreatmentMethodyRepository = new ProposedTreatmentMethodRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Get_AllProposedTreatmentMethod()
        {
            IProposedTreatmentMethod _proposedTreatmentMethodService = new ProposedTreatmentMethodImpl(_proposedTreatmentMethodyRepository);
            IEnumerable<ProposedTreatmentMethod> proposedTreatmentMethodService = _proposedTreatmentMethodService.GetAllProposedTreatmentMethod();
            Assert.IsTrue(proposedTreatmentMethodService.Any());
        }
    }
}
