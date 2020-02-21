using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
  Page Name:  ISupplierPractitionersRepository.cs      
 * Author: Vijay Kumar
  Latest Version:  1.2   
 * Created on 01-02-2013 
 * 
 * 
Purpose: Create methods  for supplier practitioner
AddSupplierPractitioner
UpdateSupplierPractitioner
GetSupplierPractitionerByPractitionerID
GetSupplierPractitionerBySupplierID
DeleteSupplierPractitionerByPractitionerID
 ====================================================
 version: 1.1
 Date:    01/31/2013
 Modified By:  Anuj Batra
 Desc:    Update the interface because of changes in table design.
 * 
  version: 1.2
 Date:    02/20/2013
 Modified By:  Vijay kumar
 Desc:    added the new method for getting the practitioner's by treatment category

 */
namespace ITS.Core.Data
{
    public interface ISupplierPractitionersRepository : IBaseRepository<SupplierPractitioners>
    {
        int AddSupplierPractitionerRegistration(SupplierPractitioners supplierPractitioners);
        int UpdateSupplierPractitioner(SupplierPractitioners supplierPractitioners);
        int DeleteSupplierPractitionerBySupplierPractitionerID(int supplierPractitionerID);
        IEnumerable<SupplierPractitioners> GetSupplierPractitionerByPractitionerRegistrationID(int practitionerID);
        IEnumerable<SupplierPractitionerSupplier> GetSupplierPractitionerSupplierByPractitionerID(int practitionerID);
        SupplierPractitioners GetSupplierPractitionerBySupplierPractitionerID(int supplierPractitionerID);
        SupplierPractitioners GetSupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID(SupplierPractitioners SupplierPractitioner);

    }
}
