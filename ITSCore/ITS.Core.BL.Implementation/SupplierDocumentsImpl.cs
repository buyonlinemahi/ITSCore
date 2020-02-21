using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
 Page Name:  SupplierDocumentImpl.cs                      
 Latest Version:  1.2                                                      
 

 * ============================================================================================================================================================ 
  Author  : Manjit Singh
  Date    : 15-Dec-2012
  Version : 1.0
  Purpose : Added Methods for SupplierDocument to add,update and getBySupplierIDAndDocumentTypeID
  ============================================================================================================================================================
 * Edited By : Anuj Batra
 * Date : 28-Dec-2012
 * Version : 1.1
 * Description : Added a Method(DeleteSupplierDocumentBySupplierDocumentID) to delete the SupplierDocument.
  ============================================================================================================================================================
  Edited By: Anuj Batra
  Date    : 26-Feb-2013
  Version : 1.2
  Purpose : Updated a method UpdateSupplierDocument.
 */
namespace ITS.Core.BL.Implementation
{
    public class SupplierDocumentImpl : ISupplierDocument
    {
        private readonly ISupplierDocumentRepository _supplierDocumentRepository;
        public SupplierDocumentImpl(ISupplierDocumentRepository supplierDocumentRepository)
        {
            _supplierDocumentRepository = supplierDocumentRepository;
        }
        public int AddSupplierDocument(SupplierDocument supplierDocument)
        {
            return _supplierDocumentRepository.AddSupplierDocument(supplierDocument);
        }

        public int UpdateSupplierDocument(SupplierDocument supplierDocument)
        {
            if (supplierDocument.UploadPath == null)
                return _supplierDocumentRepository.UpdateSupplierDocumentNameBySupplierDocumentID(supplierDocument.SupplierDocumentID,supplierDocument.DocumentName);

            else
                return _supplierDocumentRepository.UpdateSupplierDocument(supplierDocument);
        }
        public IEnumerable<SupplierDocumentUser> GetSupplierDocumentBySupplierIDAndDocumentTypeID(int supplierID, int documentTypeID)
        {
            return _supplierDocumentRepository.GetSupplierDocumentBySupplierIDAndDocumentTypeID(supplierID, documentTypeID);
        }

        public IEnumerable<SupplierDocument> GetSupplierDocumentByCaseIdAndDocumentTypeId(int caseId, int documentTypeID)
        {
            return _supplierDocumentRepository.GetSupplierDocumentByCaseIdAndDocumentTypeId(caseId, documentTypeID);
        }
        


        public int DeleteSupplierDocumentBySupplierDocumentID(int supplierDocumentID)
        {
            return _supplierDocumentRepository.DeleteSupplierDocumentBySupplierDocumentID(supplierDocumentID);
        }

        public int AddSupplierDocumentCustom(SupplierDocument supplierdocument)
        {
            return _supplierDocumentRepository.AddSupplierDocumentCustom(supplierdocument);
        }

        public IEnumerable<SupplierDocumentCustomReport> GetSupplierDocumentByCaseId(int caseId)
        {
            return _supplierDocumentRepository.GetSupplierDocumentByCaseId(caseId);
        }
    }
}
