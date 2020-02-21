using System;

#region Comment
/*
 Page Name:  Supplier.cs                      
 Latest Version:  1.0
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 11-17-2012
  Version : 1.0
  Description : Create Model For Supplier

===================================================================================

*/
#endregion
namespace ITS.Core.Data.Model
{
    public class Supplier
    {
        
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public int? Ranking { get; set; }
        public string Notes { get; set; }
        public bool IsWheelChairAccessibility { get; set; }
        public bool IsWeekends { get; set; }
        public bool IsEvenings { get; set; }
        public bool IsParking { get; set; }
        public bool IsHomeVisit { get; set; }
        public DateTime DateAdded { get; set; }
        public string Email { get; set; }
        public bool IsTriage { get; set; }
        public int StatusID { get; set; }

        //public string Status { get; set; }
    }
}
