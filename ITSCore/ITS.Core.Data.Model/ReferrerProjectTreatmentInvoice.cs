
namespace ITS.Core.Data.Model
{
    /*
    Page Name:  ReferrerProjectTreatmentInvoice.cs                      
    Version:  1.0                                              
    Purpose: create ReferrerProjectTreatmentInvoice model class                                                      
    Revision History:                                        
                                                           
      1.0 – 11/22/2012 Satya

   */
    public class ReferrerProjectTreatmentInvoice
    {
        public int ReferrerProjectTreatmentInvoiceID { get; set; }
        public decimal? InvoicePrice { get; set; }
        public decimal? ManagementPrice { get; set; }
        public bool? ManagementFeeEnabled { get; set; }
        public int InvoiceMethodID { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }

    }
}
