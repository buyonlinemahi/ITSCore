using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
/*
 Page Name:  ReferrerProjectTreatmentRepository.cs                      
 Latest Version:  1.1                                             
  Purpose: create Referrer ProjectTreatment Repository  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 11/09/2012 Satya 
 * 
 1.1 – 11/09/2012 Satya 
 Description: Add/Update Referrer ProjectTreatment method toRepository       

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentRepository : BaseRepository<ReferrerProjectTreatment, ITSDBContext>, IReferrerProjectTreatmentRepository
    {
        public ReferrerProjectTreatmentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        /// <summary>
        /// Method to Add the Referrer Project Treatment.
        /// </summary>
        /// <param name="referrerLocation"></param>
        /// <returns></returns>
        public int AddReferrerProjectTreatment(ReferrerProjectTreatment referrerProjectTreatment)
        {
            SqlParameter ReferrerProjectID = new SqlParameter("@ReferrerProjectID", referrerProjectTreatment.ReferrerProjectID);
            SqlParameter TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", referrerProjectTreatment.TreatmentCategoryID);
            SqlParameter AccountReceivableChasingPoint = new SqlParameter("@AccountReceivableChasingPoint", referrerProjectTreatment.AccountReceivableChasingPoint.HasValue ? (object)referrerProjectTreatment.AccountReceivableChasingPoint.Value : System.DBNull.Value);
            SqlParameter AccountReceivableCollection = new SqlParameter("@AccountReceivableCollection", referrerProjectTreatment.AccountReceivableCollection.HasValue ? (object)referrerProjectTreatment.AccountReceivableCollection.Value : System.DBNull.Value);
            //SqlParameter Enabled = new SqlParameter("@Enabled", referrerProjectTreatment.Enabled.HasValue ? (object)referrerProjectTreatment.Enabled.Value : System.DBNull.Value);
            SqlParameter Enabled = new SqlParameter("@Enabled", referrerProjectTreatment.Enabled);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerProjectTreatmentRepositoryProcedures.AddReferrerProjectTreatment, ReferrerProjectID, TreatmentCategoryID, AccountReceivableChasingPoint, AccountReceivableCollection, Enabled).SingleOrDefault();

        }

        /// <summary>
        /// Method to update Referrer Project Treatment by ReferrerProjectTreatmentID.
        /// </summary>
        /// <param name="referrerLocation"></param>
        /// <returns></returns>
        public int UpdateReferrerProjectTreatment(ReferrerProjectTreatment referrerProjectTreatment)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatment.ReferrerProjectTreatmentID);
            SqlParameter ReferrerProjectID = new SqlParameter("@ReferrerProjectID", referrerProjectTreatment.ReferrerProjectID);
            SqlParameter TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", referrerProjectTreatment.TreatmentCategoryID);
            SqlParameter AccountReceivableChasingPoint = new SqlParameter("@AccountReceivableChasingPoint", referrerProjectTreatment.AccountReceivableChasingPoint.HasValue ? (object)referrerProjectTreatment.AccountReceivableChasingPoint.Value : System.DBNull.Value);
            SqlParameter AccountReceivableCollection = new SqlParameter("@AccountReceivableCollection", referrerProjectTreatment.AccountReceivableCollection.HasValue ? (object)referrerProjectTreatment.AccountReceivableCollection.Value : System.DBNull.Value);
            //  SqlParameter Enabled = new SqlParameter("@Enabled", referrerProjectTreatment.Enabled.HasValue ? (object)referrerProjectTreatment.Enabled.Value : System.DBNull.Value);

            SqlParameter Enabled = new SqlParameter("@Enabled", referrerProjectTreatment.Enabled);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentRepositoryProcedures.UpdateReferrerProjectTreatment, ReferrerProjectTreatmentID, ReferrerProjectID, TreatmentCategoryID, AccountReceivableChasingPoint, AccountReceivableCollection, Enabled);
        }

        public IEnumerable<ReferrerProjectTreatmentTreatmentCategory> GetReferrerProjectTreatmentsByReferrerProjectID(int referrerProjectID)
        {
            SqlParameter ReferrerProjectID = new SqlParameter("@ReferrerProjectID", referrerProjectID);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentTreatmentCategory>(Global.StoredProcedureConst.ReferrerProjectTreatmentRepositoryProcedures.GetReferrerProjectTreatmentsByReferrerProjectID, ReferrerProjectID);

        }


        public ReferrerProjectTreatmentTreatmentCategory GetReferrerProjectTreatmentByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentTreatmentCategory>(Global.StoredProcedureConst.ReferrerProjectTreatmentRepositoryProcedures.GetReferrerProjectTreatmentByReferrerProjectTreatmentID, ReferrerProjectTreatmentID).SingleOrDefault<ReferrerProjectTreatmentTreatmentCategory>();

        }
        /// <summary>
        /// Method to get the Referrer Project Treatment.
        /// </summary>
        /// <param name="referrerLocation"></param>
        /// <returns></returns>
        public int GetReferrerIdAgtReferrerProjectTreatmentId(int referrerProjectTreatmentID)
        {
            SqlParameter ReferrerProjectID = new SqlParameter("@referrerProjectTreatmentID", referrerProjectTreatmentID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.ReferrerProjectTreatmentRepositoryProcedures.GetReferrerIdAgtReferrerProjectTreatmentId, referrerProjectTreatmentID).SingleOrDefault();

        }


        public int UpdateReferrerProjectTreatments(ReferrerProjectTreatment referrerProjectTreatment)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatment.ReferrerProjectTreatmentID);
            SqlParameter ReferrerProjectID = new SqlParameter("@ReferrerProjectID", referrerProjectTreatment.ReferrerProjectID);
            SqlParameter TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID", referrerProjectTreatment.TreatmentCategoryID);
            // SqlParameter AccountReceivableChasingPoint = new SqlParameter("@AccountReceivableChasingPoint", referrerProjectTreatment.AccountReceivableChasingPoint.HasValue ? (object)referrerProjectTreatment.AccountReceivableChasingPoint.Value : System.DBNull.Value);
            // SqlParameter AccountReceivableCollection = new SqlParameter("@AccountReceivableCollection", referrerProjectTreatment.AccountReceivableCollection.HasValue ? (object)referrerProjectTreatment.AccountReceivableCollection.Value : System.DBNull.Value);
            //  SqlParameter Enabled = new SqlParameter("@Enabled", referrerProjectTreatment.Enabled.HasValue ? (object)referrerProjectTreatment.Enabled.Value : System.DBNull.Value);

            SqlParameter Enabled = new SqlParameter("@Enabled", referrerProjectTreatment.Enabled);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentRepositoryProcedures.Update_ReferrerProjectTreatments, ReferrerProjectTreatmentID, ReferrerProjectID, TreatmentCategoryID, Enabled);
        }


        public ReferrerProjectTreatment GetReferrerProjectTreatmentExistsByReferrerProjectIDAndTreatmentCategoryID(ReferrerProjectTreatment referrerProjectTreatment)
        {
            return dbset.Where(o => (o.ReferrerProjectID == referrerProjectTreatment.ReferrerProjectID && o.TreatmentCategoryID == referrerProjectTreatment.TreatmentCategoryID)).SingleOrDefault();
        }

        
    }
}
