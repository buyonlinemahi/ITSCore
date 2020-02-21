using System;


#region Comment
/*
 Page Name:  SupplierComplaint.cs                      
 Latest Version:  1.0
 Author : Harpreet Singh
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Harpreet Singh
  Date : 12-15-2012
  Version : 1.0
  Description : Add Model For SupplierComplaint
 
===================================================================================

*/
#endregion
namespace ITS.Core.Data.Model
{
    public class SupplierComplaint
    {
        public int SupplierComplaintID { get; set; }
        public int ComplaintTypeID { get; set; }
        public int ComplaintStatusID { get; set; }
        public string ComplaintDescription { get; set; }
        public DateTime ComplaintDate { get; set; }
        public int SupplierID { get; set; }

    }
}
