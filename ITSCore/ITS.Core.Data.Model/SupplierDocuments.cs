using System;
/*
Page Name:  SupplierDocument.cs                      
Version:  1.0  
 
 
 * ============================================================================================================================================================ 
  Author  : Manjit Singh
  Date    : 15-Dec-2012
  Version : 1.0
  Purpose : to create SupplierDocument model class 
  ============================================================================================================================================================
 */
/// <summary>
/// 
/// </summary>
namespace ITS.Core.Data.Model
{
    public class SupplierDocument
    {
        public int SupplierDocumentID { get; set; }
        public int DocumentTypeID { get; set; }
        public int SupplierID { get; set; }
        public int UserID { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentName { get; set; }
        public string UploadPath { get; set; }
        public int? ReferrerProjectTreatmentID { get; set; }
        public int? CaseId { get; set; }
    }
}
