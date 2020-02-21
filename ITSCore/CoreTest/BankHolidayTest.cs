using ITS.Core.Data;
using ITS.Core.Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;


namespace CoreTest
{
    using ITS.Core.Data.SqlServer.Repository;
    using System;
    using System.Linq;

    [TestClass]
    public class BankHolidayTest
    {
        [TestMethod]
        public void GetAllBankHolidays()
        {
            IBankHolidayRepository bankHolidayRepository = new BankHolidayRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            IEnumerable<BankHoliday> holidays = bankHolidayRepository.GetAll();
            Assert.IsTrue(holidays.Any());
        }

        [TestMethod]
        public void GetAllBankHolidaysByDateRange()
        {
            IBankHolidayRepository bankHolidayRepository = new BankHolidayRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            DateTime from = DateTime.Now;
            DateTime end = DateTime.Now.AddMonths(1);

            IEnumerable<BankHoliday> holidays = bankHolidayRepository.GetAll(x => x.BankHolidayDate >= from && x.BankHolidayDate <= end);
            Assert.IsTrue(holidays.Any());
            
        }
    }

    
}
