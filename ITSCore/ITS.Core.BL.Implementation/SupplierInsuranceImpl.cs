using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


#region Comments

/*
 * Latest Version : 1.0
 * 
 * Author      : Pardeep Kumar
 * Date        : 24-Dec-2012
 * Version     : 1.0
 * Description : Added methods AddSupplierInsurance,UpdateSupplierInsurance and GetSupplierInsuranceBySupplierID
 * 
 */

#endregion

namespace ITS.Core.BL.Implementation
{
    public class SupplierInsuranceImpl : ISupplierInsurance
    {
        private readonly ISupplierInsuranceRepository _supplierInsuranceRepository;
        private readonly ISupplierDocumentRepository _supplierDocumentRepository;


        public SupplierInsuranceImpl(ISupplierInsuranceRepository supplierInsuranceRepository, ISupplierDocumentRepository supplierDocumentRepository)
        {
            _supplierInsuranceRepository = supplierInsuranceRepository;
            _supplierDocumentRepository = supplierDocumentRepository;
        }

        public int AddSupplierInsurance(SupplierInsurance supplierInsurance)
        {
            return _supplierInsuranceRepository.AddSupplierInsurance(supplierInsurance); 
        }

        public int AddSupplierInsuranceAndDocument(SupplierInsurance supplierInsurance, SupplierDocument supplierDocument)
        {
            int supplierDocumentID = _supplierDocumentRepository.AddSupplierDocument(supplierDocument);
            supplierInsurance.SupplierDocumentID = supplierDocumentID;
            return _supplierInsuranceRepository.AddSupplierInsurance(supplierInsurance);
        }

        public int UpdateSupplierInsurance(SupplierInsurance supplierInsurance)
        {
            return _supplierInsuranceRepository.UpdateSupplierInsurance(supplierInsurance);
        }

        public IEnumerable<SupplierInsurance> GetSupplierInsuranceBySupplierID(int supplierID)
        {
            return _supplierInsuranceRepository.GetSupplierInsuranceBySupplierID(supplierID);
        }


        public int DeleteSupplierInsuranceBySupplierInsuredID(int supplierInsuredID)
        {
            return _supplierInsuranceRepository.DeleteSupplierInsuranceBySupplierInsuredID(supplierInsuredID);
        }
    }
}
