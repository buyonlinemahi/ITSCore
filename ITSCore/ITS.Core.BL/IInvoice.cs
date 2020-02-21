using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IInvoice
    {
        Invoice GetInvoiceByInvoiceID(int invoiceID);
        InvoiceCollectionAction GetInvoiceCollectionActionByInvoiceCollectionActionID(int invoiceCollectionActionID);
        InvoicePayment GetInvoicePaymentByInvoicePaymentID(int invoicePaymentID);
        IEnumerable<InvoiceCollectionActionUserName> GetInvoiceCollectionActionByInvoiceID(int invoiceID);
        IEnumerable<InvoiceCollectionAction> GetInvoiceCollectionActionByUserID(int userID);
        IEnumerable<InvoicePaymentUserName> GetInvoicePaymentByInvoiceID(int invoiceID);
        IEnumerable<InvoicePayment> GetInvoicePaymentByUserID(int userID);
        IEnumerable<Invoice> GetInvoicesByCaseId(int caseId);
        IEnumerable<Invoice> GetInvoicesByUserID(int userID);
        int AddInvoice(Invoice invoice);
        int AddInvoiceCollectionAction(InvoiceCollectionAction invoiceCollectionAction);
        int AddInvoicePayment(InvoicePayment invoicePayment);
        int UpdateInvoiceIsCompleteByInvoiceID(bool isComplete, int invoiceID);
        IEnumerable<CaseInvoicePatientReferrer> GetOutstandingInvoicesCasePatientReferrer(int skip, int take);
        CaseInvoicePatientReferrer GetOutstandingInvoicesCasePatientReferrerByInvoiceID(int invoiceID);
        int GetCaseInvoicePatientReferrerCount();
    }
}
