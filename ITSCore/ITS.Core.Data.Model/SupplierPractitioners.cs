
#region Comment
/*
 Latest Version : 1.1
 
 Page Name:  Cretaed SupplierPractitioners.cs    
 Description :Cretaed Model for SupplierPractitioners
 Latest Version:  1.0
 Author : Vijay Kumar
 Created on 01-02-2013 
====================================================
 version: 1.1
 Date:    01/31/2013
 Modified By:  Anuj Batra
 Desc:    Modified the structure because of changes in table design.

*/
#endregion
namespace ITS.Core.Data.Model
{
    public class SupplierPractitioners
    {
        public int SupplierPractitionerID { get; set; }
        public int SupplierID { get; set; }
        public int PractitionerRegistrationID { get; set; }

    }
}
