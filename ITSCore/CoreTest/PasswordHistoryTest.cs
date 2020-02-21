using ITS.Core.Data;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class PasswordHistoryTest
    {
        IPasswordHistoryRepository _IPasswordHistoryRepository;

        public PasswordHistoryTest()
        {
        }

        [TestInitialize()]
        public void PasswordHistoryRepositoryInit()
        {
            _IPasswordHistoryRepository = new PasswordHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }


        
    }
}
