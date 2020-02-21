using System;


#region comments

/*

Latest Version : 1.0

Author  : Pardeep Kumar
Date    : 24-Dec-2012
Version : 1.0
Purpose : Created Model of  SupplierInsurance

*/


#endregion

namespace ITS.Core.Data.Model
{
    public class SupplierInsurance
    {

        public int SupplierInsuredID { get; set; }
        public string LevelOfCover { get; set; }
        public DateTime RenewalDate { get; set; }
        public int SupplierDocumentID { get; set; }
        public int SupplierID { get; set; }
    }
}
