using ITS.Core.Data.Model;
using System.Collections.Generic;
#region Comment
/*
 Page Name:  ISupplierDocument.cs                      
 Latest Version:  1.1                                                      
 

 * ============================================================================================================================================================ 
  Author  : Manjit Singh
  Date    : 15-Dec-2012
  Version : 1.0
  Purpose : Added an interface for SupplierDocument to add,update and get
  ============================================================================================================================================================
 
 * * Edited By : Anuj Batra
 * Date : 28-Dec-2012
 * Version : 1.1
 * Description : Added a interface Method(DeleteSupplierDocumentBySupplierDocumentID) to delete the SupplierDocument.
 */
#endregion
namespace ITS.Core.BL
{
    public interface ISupplierDocument
    {
        int AddSupplierDocument(SupplierDocument supplierDocument);
        int UpdateSupplierDocument(SupplierDocument supplierDocument);
        IEnumerable<SupplierDocumentUser> GetSupplierDocumentBySupplierIDAndDocumentTypeID(int supplierID, int documentTypeID);
        int DeleteSupplierDocumentBySupplierDocumentID(int supplierDocumentID);
        int AddSupplierDocumentCustom(SupplierDocument supplierdocument);
        IEnumerable<SupplierDocument> GetSupplierDocumentByCaseIdAndDocumentTypeId(int caseId, int documentTypeID);
        IEnumerable<SupplierDocumentCustomReport> GetSupplierDocumentByCaseId(int caseId);
    }
}
