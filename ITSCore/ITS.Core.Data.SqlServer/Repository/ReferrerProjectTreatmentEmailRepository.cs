using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Create by : harpreet
 Latest Version : 1.3
 
 history Revision:
 * ================================
  Edited By :   Vishal
  Version  :    1.2
  Description : Modify Add  method to add Scope Identy
  ModifiedDate: 11/19/2012 
 
 * Edited By   : Pardeep Kumar
 * Dated       : 07/26/2013
 * Description : Implemented interface's New method GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID
 * Version     : 1.3
 
 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentEmailRepository : BaseRepository<ReferrerProjectTreatmentEmail, ITSDBContext>, IReferrerProjectTreatmentEmailRepostory
    {
        public ReferrerProjectTreatmentEmailRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<ReferrerProjectTreatmentEmailTypeName> GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentEmailTypeName>(Global.StoredProcedureConst.ReferrerProjectTreatmentEmailRepositoryProcedure.GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID, ReferrerProjectTreatmentID);
        }


        public IEnumerable<ReferrerProjectTreatmentEmail> GetByReferrerProjectTreatmentId(int referrerProjectTreatmentId)
        {
            SqlParameter TreatmentEmailId = new SqlParameter("@teamtmentId", referrerProjectTreatmentId);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentEmail>(Global.StoredProcedureConst.ReferrerProjectTreatmentEmailRepositoryProcedure.GetReferrerProjectEmailByTreatmentId, TreatmentEmailId);
        }
        public IEnumerable<ReferrerProjectTreatment> GetReferrerProjectTreatmentByTreatmentId(int referrerProjectTreatmentId)
        {
            SqlParameter TreatmentEmailId = new SqlParameter("@teamtmentId", referrerProjectTreatmentId);
            return Context.Database.SqlQuery<ReferrerProjectTreatment>(Global.StoredProcedureConst.ReferrerProjectTreatmentEmailRepositoryProcedure.GetReferrerProjectTreatmentByTreatmentId, TreatmentEmailId);
        }
        

        public int AddReferrerProjectTreatmentEmail(ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentEmail.ReferrerProjectTreatmentID);
            SqlParameter EmailTypeID = new SqlParameter("@EmailTypeID", referrerProjectTreatmentEmail.EmailTypeID);
            SqlParameter EmailTypeValueID = new SqlParameter("@EmailTypeValueID", referrerProjectTreatmentEmail.EmailTypeValueID);


            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerProjectTreatmentEmailRepositoryProcedure.AddReferrerProjectTreatmentEmail, ReferrerProjectTreatmentID, EmailTypeID, EmailTypeValueID).SingleOrDefault();
        }

        public int UpdateReferrerProjectTreatmentEmail(ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail)
        {
            SqlParameter ReferrerProjectTreatmentEmailID = new SqlParameter("@ReferrerProjectTreatmentEmailID", referrerProjectTreatmentEmail.ReferrerProjectTreatmentEmailID);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentEmail.ReferrerProjectTreatmentID);
            SqlParameter EmailTypeID = new SqlParameter("@EmailTypeID", referrerProjectTreatmentEmail.EmailTypeID);
            SqlParameter EmailTypeValueID = new SqlParameter("@EmailTypeValueID", referrerProjectTreatmentEmail.EmailTypeValueID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentEmailRepositoryProcedure.UpdateReferrerProjectTreatmentEmail, ReferrerProjectTreatmentEmailID, ReferrerProjectTreatmentID, EmailTypeID, EmailTypeValueID);
        }

        public int DeleteReferrerProjectTreatmentEmailById(int referrerProjectTreatmentEmailId)
        {
            SqlParameter ReferrerProjectTreatmentEmailID = new SqlParameter("@treatmentEmailId", referrerProjectTreatmentEmailId);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentEmailRepositoryProcedure.DeleteReferrerProjectTreatmentEmailById, ReferrerProjectTreatmentEmailID);
        }

        /// <summary>
        /// Method to get the Referrer Project Treatment.
        /// </summary>
        /// <param name="referrerLocation"></param>
        /// <returns></returns>
        public int GetReferrerIdAgtReferrerProjectTreatmentId(int referrerProjectTreatmentID)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@referrerProjectTreatmentID", referrerProjectTreatmentID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.ReferrerProjectTreatmentRepositoryProcedures.GetReferrerIdAgtReferrerProjectTreatmentId, ReferrerProjectTreatmentID).SingleOrDefault();

        }


    }
}


