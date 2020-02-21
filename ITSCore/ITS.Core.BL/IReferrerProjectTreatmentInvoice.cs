using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    /*
  Page Name:  IReferrerProjectTreatmentInvoice.cs                      
  Version:  1.0                                              
  Purpose: Create CURD operation for IReferrerProjectTreatmentInvoice contract.                                          
  Revision History:                                       
                                                           
    1.0 – 11/22/2012 Satya 
     */
    public interface IReferrerProjectTreatmentInvoice
    {
        int AddReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice);
        IEnumerable<ReferrerProjectTreatmentInvoice> GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
        int UpdateReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice);
        ReferrerProjectTreatmentInvoiceMethod GetReferrerProjectTreatmentInvoiceMethodByReferrerProjectTreatmentID(int referrerProjectTreatmentID);
    }
}
