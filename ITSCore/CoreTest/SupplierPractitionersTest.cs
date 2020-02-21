using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;


#region Comments

/*
 * Latest Version : 1.1
 * 
 * Author         : Vijay Kumar
 * Date           : 3-Jan-2013
 * Version        : 1.0
 * Description    : Added methods to Test
 
AddSupplierPractitioner
UpdateSupplierPractitioner
GetSupplierPractitionerByPractitionerID
GetSupplierPractitionerBySupplierID
DeleteSupplierPractitionerByPractitionerID
==============================================
 version: 1.1
 Date:    01/31/2013
 Modified By:  Anuj Batra
 Desc:    Update the Test Methods because of changes in table design.
 
 * 
 */

#endregion

namespace CoreTest
{
    [TestClass]
    public class SupplierPractitionersTest
    {


        ISupplierPractitionersRepository _supplierPractitionersRepository;

        public SupplierPractitionersTest()
        {

        }
        [TestInitialize()]
        public void SupplierPractitionersRepositoryInit()
        {
            _supplierPractitionersRepository = new SupplierPractitionersRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

        }

        [TestMethod]
        public void AddSupplierPractitioner()
        {
            ISupplierPractitioners supplierPractitioners = new SupplierPractitionersImpl(_supplierPractitionersRepository);
            SupplierPractitioners SupplierPractitionersObj = new SupplierPractitioners();
            SupplierPractitionersObj.SupplierID = 240;
            SupplierPractitionersObj.PractitionerRegistrationID = 255;

            int TestResult = supplierPractitioners.AddSupplierPractitionerRegistration(SupplierPractitionersObj);
            Assert.IsTrue(TestResult > 0, "Unable Inserted New Supplier Practitioner");
        }
        [TestMethod]
        public void UpdateSupplierPractitioner()
        {
            ISupplierPractitioners supplierPractitioners = new SupplierPractitionersImpl(_supplierPractitionersRepository);
            SupplierPractitioners SupplierPractitionersObj = new SupplierPractitioners();

            SupplierPractitionersObj.SupplierPractitionerID = 205;
            SupplierPractitionersObj.SupplierID = 240;
            SupplierPractitionersObj.PractitionerRegistrationID = 258;
            int TestResult = supplierPractitioners.UpdateSupplierPractitioner(SupplierPractitionersObj);
            Assert.IsTrue(TestResult > 0, "Unable Update Supplier Practitioner");
        }
        [TestMethod]
        public void GetSupplierPractitionerByPractitionerRegistrationID()
        {

            //this Test for BL Layer
            ISupplierPractitioners supplierPractitionersBL = new SupplierPractitionersImpl(_supplierPractitionersRepository);
           IEnumerable< SupplierPractitioners> _supplierPractitioners = supplierPractitionersBL.GetSupplierPractitionerByPractitionerRegistrationID(153);
           Assert.IsTrue(_supplierPractitioners.Any());

        }

        [TestMethod]
        public void Get_SupplierPractitionerSupplierByPractitionerID()
        {

            //this Test for BL Layer
            ISupplierPractitioners supplierPractitionersBL = new SupplierPractitionersImpl(_supplierPractitionersRepository);
            IEnumerable<SupplierPractitionerSupplier> _supplierPractitioners = supplierPractitionersBL.GetSupplierPractitionerSupplierByPractitionerID(178);
            Assert.IsTrue(_supplierPractitioners.Any());

        }


        [TestMethod]
        public void DeleteSupplierPractitionerByPractitionerID()
        {
            //this Test for BL Layer
            ISupplierPractitioners supplierPractitionersBL = new SupplierPractitionersImpl(_supplierPractitionersRepository);
            int result = supplierPractitionersBL.DeleteSupplierPractitionerBySupplierPractitionerID(119);
            Assert.IsTrue(result != 0, " unable to Delete  supplier Practitioners");

        }
        [TestMethod]
        public void GetSupplierPractitionerBySupplierPractitionerID()
        {

            //this Test for BL Layer
            ISupplierPractitioners supplierPractitionersBL = new SupplierPractitionersImpl(_supplierPractitionersRepository);
            SupplierPractitioners _supplierPractitioners = supplierPractitionersBL.GetSupplierPractitionerBySupplierPractitionerID(117);
            Assert.IsTrue(_supplierPractitioners != null, " unable to get supplier Practitioners");

        }




    }
}
