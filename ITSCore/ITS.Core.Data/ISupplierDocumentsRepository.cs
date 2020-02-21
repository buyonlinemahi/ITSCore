using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
#region Comment
/*
    *Page Name:  ISupplierDocumentRepository.cs  
    * Latest Version : 1.2    

  ============================================================================================================================================================ 
  Author  : Manjit Singh
  Date    : 15-Dec-2012
  Version : 1.0 
  Purpose : Interface and Added Methods For SupplierDocument 
  ============================================================================================================================================================
 
 * Edited By : Anuj Batra
 * Date : 28-Dec-2012
 * Version : 1.1
 * Description : Added a interface Method(DeleteSupplierDocumentBySupplierDocumentID) to delete the SupplierDocument.
 
  
 * Edited By : Anuj Batra
 * Date : 26-Feb-2012
 * Version : 1.2
 * Description : Added a interface Method(UpdateSupplierDocumentNameBySupplierDocumentID) to update the DocumentName.
 */
#endregion
namespace ITS.Core.Data
{
    public interface ISupplierDocumentRepository : IBaseRepository<SupplierDocument>
    {
        int AddSupplierDocument(SupplierDocument supplierDocument);
        int UpdateSupplierDocument(SupplierDocument supplierDocument);
        IEnumerable<SupplierDocumentUser> GetSupplierDocumentBySupplierIDAndDocumentTypeID(int supplierID, int documentTypeID);
        int DeleteSupplierDocumentBySupplierDocumentID(int supplierDocumentID);
        int UpdateSupplierDocumentNameBySupplierDocumentID(int supplierDocumentID, string documentName);
        int AddSupplierDocumentCustom(SupplierDocument supplierdocument);
        IEnumerable<SupplierDocument> GetSupplierDocumentByCaseIdAndDocumentTypeId(int CaseId, int documentTypeID);
        IEnumerable<SupplierDocumentCustomReport> GetSupplierDocumentByCaseId(int CaseId);
    }
}
