using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
/*
  Page Name:  IReferrerProjectTreatmentInvoiceRepository.cs                      
  Latest Version:  1.0                                            
  Purpose: Create Referrer Project Treatment Invoice interface                                                      
  Revision History:                                        
                                                           
 * 1.0 – 11/22/2012 Satya 
 * ==============================================================================================
  Description : Add interface For GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
  Description : Add interface For AddReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice)
  Description : Add interface For UpdateReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentInvoiceID(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice)
     * 
 ==============================================================================================
 */
namespace ITS.Core.Data
{
    public interface IReferrerProjectTreatmentInvoiceRepository : IBaseRepository<ReferrerProjectTreatmentInvoice>
    {
        int AddReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice);
        IEnumerable<ReferrerProjectTreatmentInvoice> GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        int UpdateReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice);

    }
}
