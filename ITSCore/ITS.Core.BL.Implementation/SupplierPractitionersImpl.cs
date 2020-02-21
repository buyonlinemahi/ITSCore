using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;




#region Comment
/*
 Page Name:  SupplierPractitionersImpl.cs                      
 Latest Version:  1.1
 Author : Vijay Kumar
 Created on 01-02-2013 

  Description : Add Implementation For AddSupplierPractitioner 
  Description : Add Implementation For UpdateSupplierPractitioner 
  Description : Add Implementation For DeleteSupplierPractitionerByPractitionerID
  Description : Add Implementation For GetSupplierPractitionerByPractitionerID
  Description : Add Implementation For GetSupplierPractitionerBySupplierID
===================================================================================
 version: 1.1
 Date:    01/31/2013
 Modified By:  Anuj Batra
 Desc:    Update the BL implementation because of changes in table design.

===================================================================================
 version: 1.1
 Date:   20/feb/2013
 Modified By:  Vijay Kumar
 Desc:   added the new method to get the practitioner's by treatment category name
*/
#endregion
namespace ITS.Core.BL.Implementation
{
    public class SupplierPractitionersImpl : ISupplierPractitioners
    {
        private readonly ISupplierPractitionersRepository _supplierPractitionersRepository;

        public SupplierPractitionersImpl(ISupplierPractitionersRepository supplierPractitionersRepository)
        {
            _supplierPractitionersRepository = supplierPractitionersRepository;
        }

        public int AddSupplierPractitionerRegistration(SupplierPractitioners supplierPractitioners)
        {
            return _supplierPractitionersRepository.GetSupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID(supplierPractitioners) != null ? -1 : _supplierPractitionersRepository.AddSupplierPractitionerRegistration(supplierPractitioners);

        }

        public int UpdateSupplierPractitioner(SupplierPractitioners supplierPractitioners)
        {
             var result = _supplierPractitionersRepository.GetSupplierPractitionersExistsBySupplierIDAndPractitionerRegistrationID(supplierPractitioners);
            if (result != null)
            {
                if (result.SupplierPractitionerID == supplierPractitioners.SupplierPractitionerID)
                {
                    return _supplierPractitionersRepository.UpdateSupplierPractitioner(supplierPractitioners);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return _supplierPractitionersRepository.UpdateSupplierPractitioner(supplierPractitioners);
            }
        }

        public int DeleteSupplierPractitionerBySupplierPractitionerID(int supplierPractitionerID)
        {
            return _supplierPractitionersRepository.DeleteSupplierPractitionerBySupplierPractitionerID(supplierPractitionerID);
        }

        public IEnumerable<SupplierPractitioners> GetSupplierPractitionerByPractitionerRegistrationID(int practitionerRegistrationID)
        {
            return _supplierPractitionersRepository.GetSupplierPractitionerByPractitionerRegistrationID(practitionerRegistrationID);
        }

        public SupplierPractitioners GetSupplierPractitionerBySupplierPractitionerID(int supplierPractitionerID)
        {
            return _supplierPractitionersRepository.GetSupplierPractitionerBySupplierPractitionerID(supplierPractitionerID);
        }


        public IEnumerable<SupplierPractitionerSupplier> GetSupplierPractitionerSupplierByPractitionerID(int practitionerID)
        {
            return _supplierPractitionersRepository.GetSupplierPractitionerSupplierByPractitionerID(practitionerID);
        }
    }
}
