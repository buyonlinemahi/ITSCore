using ITS.Core.BL.Model;
using ITS.Core.Data.Model;
using System.Collections.Generic;
#region Comment
/*
 Page Name:  ISupplier.cs                      
 Latest Version:  1.2
 Author : Vishal
 
 * Revision History:                                                   
 ===================================================================================
  Edited By : Vishal
  Date : 11-17-2012
  Version : 1.0
  Description : Add Interface For Get_SupplierBySupplierID
  Description : Add Interface For Get_SuppliersLikeSupplierName
  Description : Add Interface For Add_Supplier
  Description : Add Interface For Update_SupplierBySupplierID
===================================================================================
  Edited By : Satya
  Date : 12-18-2012
  Version : 1.1
  Description : Add Interface For AddSupplierandTreatmentTypes
===================================================================================
  Edited By : Anuj Batra
  Date : 12-18-2012
  Version : 1.2
  Description : Add Interface For GetSuppliersLikePostCode
===================================================================================
*/
#endregion

namespace ITS.Core.BL
{
    public interface ISupplier
    {
        Supplier GetSupplierBySupplierID(int supplierID);
        int AddSupplier(Supplier supplier);
        int UpdateSupplierBySupplierID(Supplier supplier);
        IEnumerable<Supplier> GetAllSupplier();
        int AddSupplierAndTreatmentTypes(Supplier supplier, IEnumerable<SupplierTreatment> supplierTreatment);
        IEnumerable<SupplierCasePatient> GetSupplierNewPatientCases(int supplierID);
        IEnumerable<SupplierCasePatient> GetSupplierExistingPatientsInitialAssessments(int supplierID);
        IEnumerable<SupplierCasePatient> GetSupplierExistingPatientsNextAssessments(int supplierID);
        IEnumerable<SupplierCasePatient> GetSupplierAuthorisations(int supplierID);
        IEnumerable<SupplierCasePatient> GetSupplierStoppedCases(int supplierID);
        IEnumerable<SupplierDistanceRankPrice> GetSupplierWithinPostCode(string postCode, int distanceKM, int treatmentCategoryID);
        double GetSupplierRankingBySupplierID(int supplierID);
        int UpdateSupplierStatus(int supplierID, bool isTriage);
        bool GetSupplierExistsByName(string supplierName);
        IEnumerable<Supplier> GetSuppliersRecentlyAdded();
        bool GetSupplierExistsByEmail(string email);
        IEnumerable<SuppliersName> GetAllSupplierWithinPostCode(string postCode, int distanceKM, int treatmentCategoryID);
        IEnumerable<SuppliersName> GetAllSuppliers();
        SupplierDistanceRankPrice GetSelectedSupplierDistanceRankPrice(int supplierID, int treatmentCategoryID, string postCode);

    
    }
}
