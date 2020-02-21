

#region Comment
/*
 Page Name:  SupplierTreatment.cs                      
 Latest Version:  1.0
 Author : Satya Singh
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Satya Singh
  Date : 12-18-2012
  Version : 1.0
  Description : Add Model For SupplierTreatment
 
===================================================================================

*/
#endregion
namespace ITS.Core.Data.Model
{
    public class SupplierTreatment
    {
        public int SupplierTreatmentID { get; set; }
        public int TreatmentCategoryID { get; set; }
        public int SupplierID { get; set; }
        public bool Enabled { get; set; }


    }
}
