using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace ITS.Core.BL.Implementation
{

    public class InvoiceImpl : IInvoice
    {

        private readonly IInvoiceRepository _invoiceRepository;

        public InvoiceImpl(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }


        public Invoice GetInvoiceByInvoiceID(int invoiceID)
        {
            return _invoiceRepository.GetInvoiceByInvoiceID(invoiceID);
        }

        public InvoiceCollectionAction GetInvoiceCollectionActionByInvoiceCollectionActionID(int invoiceCollectionActionID)
        {
            return _invoiceRepository.GetInvoiceCollectionActionByInvoiceCollectionActionID(invoiceCollectionActionID);
        }

        public InvoicePayment GetInvoicePaymentByInvoicePaymentID(int invoicePaymentID)
        {
            return _invoiceRepository.GetInvoicePaymentByInvoicePaymentID(invoicePaymentID);
        }

        public IEnumerable<InvoiceCollectionActionUserName> GetInvoiceCollectionActionByInvoiceID(int invoiceID)
        {
            return _invoiceRepository.GetInvoiceCollectionActionByInvoiceID(invoiceID);
        }

        public IEnumerable<InvoiceCollectionAction> GetInvoiceCollectionActionByUserID(int userID)
        {
            return _invoiceRepository.GetInvoiceCollectionActionByUserID(userID);
        }

        public IEnumerable<InvoicePaymentUserName> GetInvoicePaymentByInvoiceID(int invoiceID)
        {
            return _invoiceRepository.GetInvoicePaymentByInvoiceID(invoiceID);
        }

        public IEnumerable<InvoicePayment> GetInvoicePaymentByUserID(int userID)
        {
            return _invoiceRepository.GetInvoicePaymentByUserID(userID);
        }

        public IEnumerable<Invoice> GetInvoicesByCaseId(int caseId)
        {
            return _invoiceRepository.GetInvoicesByCaseId(caseId);
        }

        public IEnumerable<Invoice> GetInvoicesByUserID(int userID)
        {
            return _invoiceRepository.GetInvoicesByUserID(userID);
        }

        public int AddInvoice(Invoice invoice)
        {
            var resultInvoice = _invoiceRepository.GetInvoicesByCaseId(invoice.CaseID).FirstOrDefault();

            if (resultInvoice != null)
            {
                return -1;
            }
            else
            {
                return _invoiceRepository.AddInvoice(invoice);
            }
            
           
        }

        public int AddInvoiceCollectionAction(InvoiceCollectionAction invoiceCollectionAction)
        {
            return _invoiceRepository.AddInvoiceCollectionAction(invoiceCollectionAction);
        }

        public int AddInvoicePayment(InvoicePayment invoicePayment)
        {
            var resultInvoice = _invoiceRepository.GetInvoiceByInvoiceID(invoicePayment.InvoiceID);
            var resultInvoicePaymentByInvoiceID = _invoiceRepository.GetInvoicePaymentByInvoiceID(invoicePayment.InvoiceID).ToList();

            decimal? totalRecieved = 0.00m;

            if (resultInvoicePaymentByInvoiceID != null && resultInvoicePaymentByInvoiceID.Count() > 0)
            {

             totalRecieved =  resultInvoicePaymentByInvoiceID.Sum( o => o.Payment + o.AdjustedPayment);
             totalRecieved = totalRecieved.HasValue ? totalRecieved : 0.00m;

            }

            var outstanding = resultInvoice.Amount - totalRecieved;
            var validPayment = outstanding - (invoicePayment.Payment + invoicePayment.AdjustedPayment);

            if ((!resultInvoice.IsComplete) && ((int)resultInvoice.Amount > 0.00) && ((int)validPayment >= 0.00))
            {
                if ((int)validPayment <= 0.00)
                {
                    _invoiceRepository.UpdateInvoiceIsCompleteByInvoiceID(true, invoicePayment.InvoiceID);
                }

                return _invoiceRepository.AddInvoicePayment(invoicePayment);


            }
            else
            {
                return -1;
            }
            
        }

        public int UpdateInvoiceIsCompleteByInvoiceID(bool isComplete, int invoiceID)
        {
            return _invoiceRepository.UpdateInvoiceIsCompleteByInvoiceID(isComplete, invoiceID);
        }

        public IEnumerable<CaseInvoicePatientReferrer> GetOutstandingInvoicesCasePatientReferrer(int skip, int take)
        {
            return _invoiceRepository.GetOutstandingInvoicesCasePatientReferrer(skip, take);
        }

        public int GetCaseInvoicePatientReferrerCount()
        {
            return _invoiceRepository.GetCaseInvoicePatientReferrerCount();
        }


        public CaseInvoicePatientReferrer GetOutstandingInvoicesCasePatientReferrerByInvoiceID(int invoiceID)
        {
            var resultInovice = _invoiceRepository.GetOutstandingInvoicesCasePatientReferrerByInvoiceID(invoiceID).FirstOrDefault();

            if (resultInovice != null)
            {
                return resultInovice;
            }
            else
            {
                return null;
            }
        }
    }
}
