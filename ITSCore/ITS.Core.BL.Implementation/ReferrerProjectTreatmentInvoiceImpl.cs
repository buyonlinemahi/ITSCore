using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

#region Comment

/*
  Page Name:  ReferrerProjectTreatmentInvoiceImpl.cs                      
  Version:  1.0                                              
  Purpose: Add CURD opertion on ReferrerProjectTreatmentInvoice Impl.                                                 
  Revision History:                               
  1.0 – 11/22/2012 Satya
  
 */


#endregion

namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentInvoiceImpl : IReferrerProjectTreatmentInvoice
    {
        private readonly IReferrerProjectTreatmentInvoiceRepository _referrerProjectTreatmentInvoiceRepository;

        private readonly IInvoiceMethodRepository _invoiceMethodRepository;

        public ReferrerProjectTreatmentInvoiceImpl(IReferrerProjectTreatmentInvoiceRepository referrerProjectTreatmentInvoiceRepository, IInvoiceMethodRepository invoiceMethodRepository)
        {
            _referrerProjectTreatmentInvoiceRepository = referrerProjectTreatmentInvoiceRepository;
            _invoiceMethodRepository = invoiceMethodRepository;
        }

        public int AddReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice)
        {
            return _referrerProjectTreatmentInvoiceRepository.AddReferrerProjectTreatmentInvoice(referrerProjectTreatmentInvoice);
        }

        public IEnumerable<ReferrerProjectTreatmentInvoice> GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            return _referrerProjectTreatmentInvoiceRepository.GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID(referrerProjectTreatmentID);
        }


        public ReferrerProjectTreatmentInvoiceMethod GetReferrerProjectTreatmentInvoiceMethodByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            ReferrerProjectTreatmentInvoiceMethod referrerProjectTreatmentInvoiceMethod = new ReferrerProjectTreatmentInvoiceMethod();
            var refrrerInvoiceMethod = _referrerProjectTreatmentInvoiceRepository.GetReferrerProjectTreatmentInvoiceByReferrerProjectTreatmentID(referrerProjectTreatmentID).SingleOrDefault();
            var InvoiceMethods = _invoiceMethodRepository.GetAll();

            referrerProjectTreatmentInvoiceMethod.ReferrerProjectTreatmentInvoiceID = refrrerInvoiceMethod.ReferrerProjectTreatmentInvoiceID;
            referrerProjectTreatmentInvoiceMethod.InvoicePrice = refrrerInvoiceMethod.InvoicePrice;
            referrerProjectTreatmentInvoiceMethod.ManagementPrice = refrrerInvoiceMethod.ManagementPrice;
            referrerProjectTreatmentInvoiceMethod.ManagementFeeEnabled = refrrerInvoiceMethod.ManagementFeeEnabled;
            referrerProjectTreatmentInvoiceMethod.InvoiceMethodID = refrrerInvoiceMethod.InvoiceMethodID;
            referrerProjectTreatmentInvoiceMethod.ReferrerProjectTreatmentID = refrrerInvoiceMethod.ReferrerProjectTreatmentID;
            referrerProjectTreatmentInvoiceMethod.ReferrerInvoiceMethods = InvoiceMethods;

            return referrerProjectTreatmentInvoiceMethod;

        }

        public int UpdateReferrerProjectTreatmentInvoice(ReferrerProjectTreatmentInvoice referrerProjectTreatmentInvoice)
        {
            return _referrerProjectTreatmentInvoiceRepository.UpdateReferrerProjectTreatmentInvoice(referrerProjectTreatmentInvoice);
        }
    }
}
