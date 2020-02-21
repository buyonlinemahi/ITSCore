using ITS.Core.Data.Model;
using System.Collections.Generic;



/*
 * Author : Vijay Kumar
    * Latest Version : 1.2       
    * Created on 01-02-2013 
    * Reason :- Created Interface ISupplierPractitioners having following method
 
    AddSupplierPractitioner
    UpdateSupplierPractitioner
    GetSupplierPractitionerByPractitionerID
    GetSupplierPractitionerBySupplierID
    DeleteSupplierPractitionerByPractitionerID
 =====================================================
 version: 1.1
 Date:    01/31/2013
 Modified By:  Anuj Batra
 Desc:    Update the BL because of changes in table design.

 =====================================================
 version: 1.2
 Date:    20/feb/2013
 Modified By:  vijay kumar
 Desc:    added the new method to get the practitioner's by treatment category name
 */
namespace ITS.Core.BL
{
    public interface ISupplierPractitioners
    {
        int AddSupplierPractitionerRegistration(SupplierPractitioners supplierPractitioners);
        int UpdateSupplierPractitioner(SupplierPractitioners supplierPractitioners);
        int DeleteSupplierPractitionerBySupplierPractitionerID(int supplierPractitionerID);
        IEnumerable<SupplierPractitioners> GetSupplierPractitionerByPractitionerRegistrationID(int practitionerRegistrationID);
        SupplierPractitioners GetSupplierPractitionerBySupplierPractitionerID(int supplierPractitionerID);
        IEnumerable<SupplierPractitionerSupplier> GetSupplierPractitionerSupplierByPractitionerID(int practitionerID);
    }
}
