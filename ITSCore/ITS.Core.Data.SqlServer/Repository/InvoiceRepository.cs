using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;


namespace ITS.Core.Data.SqlServer.Repository
{
    public class InvoiceRepository : BaseRepository<Invoice, ITSDBContext>, IInvoiceRepository
    {
        public InvoiceRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public Invoice GetInvoiceByInvoiceID(int invoiceID)
        {
            SqlParameter _InvoiceID = new SqlParameter("@InvoiceID", invoiceID);
            return Context.Database.SqlQuery<Invoice>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoiceByInvoiceID, _InvoiceID).SingleOrDefault<Invoice>();
        }

        public InvoiceCollectionAction GetInvoiceCollectionActionByInvoiceCollectionActionID(int invoiceCollectionActionID)
        {
            SqlParameter _InvoiceCollectionActionID = new SqlParameter("@InvoiceCollectionActionID", invoiceCollectionActionID);
            return Context.Database.SqlQuery<InvoiceCollectionAction>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoiceCollectionActionByInvoiceCollectionActionID, _InvoiceCollectionActionID).SingleOrDefault<InvoiceCollectionAction>();
        }

        public InvoicePayment GetInvoicePaymentByInvoicePaymentID(int invoicePaymentID)
        {
            SqlParameter _InvoicePaymentID = new SqlParameter("@InvoicePaymentID", invoicePaymentID);
            return Context.Database.SqlQuery<InvoicePayment>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoicePaymentByInvoicePaymentID, _InvoicePaymentID).SingleOrDefault<InvoicePayment>();
        }

        public IEnumerable<InvoiceCollectionActionUserName> GetInvoiceCollectionActionByInvoiceID(int invoiceID)
        {
            SqlParameter _InvoiceID = new SqlParameter("@InvoiceID", invoiceID);
            return Context.Database.SqlQuery<InvoiceCollectionActionUserName>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoiceCollectionActionByInvoiceID, _InvoiceID);
        }

        public IEnumerable<InvoiceCollectionAction> GetInvoiceCollectionActionByUserID(int userID)
        {
            SqlParameter _UserID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<InvoiceCollectionAction>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoiceCollectionActionByUserID, _UserID);
        }

        public IEnumerable<InvoicePaymentUserName> GetInvoicePaymentByInvoiceID(int invoiceID)
        {
            SqlParameter _InvoiceID = new SqlParameter("@InvoiceID", invoiceID);
            return Context.Database.SqlQuery<InvoicePaymentUserName>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoicePaymentByInvoiceID, _InvoiceID);
        }

        public IEnumerable<InvoicePayment> GetInvoicePaymentByUserID(int userID)
        {

            SqlParameter _UserID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<InvoicePayment>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoicePaymentByUserID, _UserID);
        }

        public IEnumerable<Invoice> GetInvoicesByCaseId(int caseId)
        {
            SqlParameter _CaseId = new SqlParameter("@CaseId", caseId);
            return Context.Database.SqlQuery<Invoice>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoicesByCaseId, _CaseId);
        }

        public IEnumerable<Invoice> GetInvoicesByUserID(int userID)
        {
            SqlParameter _UserID = new SqlParameter("@UserID", userID);
            return Context.Database.SqlQuery<Invoice>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetInvoicesByUserID, _UserID);
        }

        public int AddInvoice(Invoice invoice)
        {
            var _InvoiceNumber = new SqlParameter("@InvoiceNumber", invoice.InvoiceNumber);
            var _Amount = new SqlParameter("@Amount", invoice.Amount);
            var _CaseID = new SqlParameter("@CaseID", invoice.CaseID);
            var _UserID = new SqlParameter("@UserID", invoice.UserID);
            var _InvoiceDate = new SqlParameter("@InvoiceDate", invoice.InvoiceDate);
            var _IsComplete = new SqlParameter("@IsComplete", invoice.IsComplete);


            return (int)Context.Database.SqlQuery<decimal>(
                Global.StoredProcedureConst.InvoiceRepositoryProcedure.AddInvoice,
                _InvoiceNumber,
                _Amount,
                _CaseID,
                _UserID,
                _InvoiceDate,
                _IsComplete).SingleOrDefault();
        }

        public int AddInvoiceCollectionAction(InvoiceCollectionAction invoiceCollectionAction)
        {
            var _InvoiceID = new SqlParameter("@InvoiceID", invoiceCollectionAction.InvoiceID);
            var _Action = new SqlParameter("@Action", !string.IsNullOrEmpty(invoiceCollectionAction.Action) ? (object)invoiceCollectionAction.Action : System.DBNull.Value);
            var _FollowUpDate = new SqlParameter("@FollowUpDate", invoiceCollectionAction.FollowUpDate);
            var _UserID = new SqlParameter("@UserID", invoiceCollectionAction.UserID);
            var _DateofAction = new SqlParameter("@DateofAction", invoiceCollectionAction.DateofAction);

            return (int)Context.Database.SqlQuery<decimal>(
                Global.StoredProcedureConst.InvoiceRepositoryProcedure.AddInvoiceCollectionAction,
                _InvoiceID,
                _Action,
                _FollowUpDate,
                _UserID,
                _DateofAction).SingleOrDefault();
        }

        public int AddInvoicePayment(InvoicePayment invoicePayment)
        {
            var _InvoiceID = new SqlParameter("@InvoiceID", invoicePayment.InvoiceID);
            var _Payment = new SqlParameter("@Payment", invoicePayment.Payment);
            var _AdjustedPayment = new SqlParameter("@AdjustedPayment", invoicePayment.AdjustedPayment);
            var _CheckNumber = new SqlParameter("@CheckNumber",!string.IsNullOrEmpty(invoicePayment.CheckNumber) ? (object)invoicePayment.CheckNumber : System.DBNull.Value );
            var _BACS = new SqlParameter("@BACS", !string.IsNullOrEmpty(invoicePayment.BACS) ? (object)invoicePayment.BACS : System.DBNull.Value);
            var _UserID = new SqlParameter("@UserID", invoicePayment.UserID);
            var _InvoicePaymentDate = new SqlParameter("@InvoicePaymentDate", invoicePayment.InvoicePaymentDate);

            return (int)Context.Database.SqlQuery<decimal>(
                Global.StoredProcedureConst.InvoiceRepositoryProcedure.AddInvoicePayment,
                _InvoiceID,
                _Payment,
                _AdjustedPayment,
                _CheckNumber,
                _BACS,
                _UserID,
                _InvoicePaymentDate
                ).SingleOrDefault();
        }


        public int UpdateInvoiceIsCompleteByInvoiceID(bool isComplete, int invoiceID)
        {
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.InvoiceRepositoryProcedure.UpdateInvoiceIsCompleteByInvoiceID, new SqlParameter("@IsComplete", isComplete)
        , new SqlParameter("@InvoiceID", invoiceID));
        }


        public IEnumerable<CaseInvoicePatientReferrer> GetOutstandingInvoicesCasePatientReferrer(int skip, int take)
        {
            SqlParameter _Skip = new SqlParameter("@Skip", skip);
            SqlParameter _Take = new SqlParameter("@Take", take);
            return Context.Database.SqlQuery<CaseInvoicePatientReferrer>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetOutstandingInvoicesCasePatientReferrer, _Skip, _Take);
        }

        public int GetCaseInvoicePatientReferrerCount()
        {
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetCaseInvoicePatientReferrerCount).SingleOrDefault();
        }


        public IEnumerable<CaseInvoicePatientReferrer> GetOutstandingInvoicesCasePatientReferrerByInvoiceID(int invoiceID)
        {
            SqlParameter _InvoiceID = new SqlParameter("@InvoiceID", invoiceID);
            return Context.Database.SqlQuery<CaseInvoicePatientReferrer>(Global.StoredProcedureConst.InvoiceRepositoryProcedure.GetOutstandingInvoicesCasePatientReferrerByInvoiceID, _InvoiceID);
        }
    }
}
