using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  ReferrerProjectTreatmentAuthorisationRepository.cs                      
 Latest Version:  1.1                                             
 Purpose: create ReferrerProjectTreatmentAuthorisation model  inside itscore project                                                         
 Revision History:                                        
                                                           
   1.0 – 11/10/2012 Satya 
 * 
 * 
 * 
 *   *Revision History
 Version : 1.1 ,Vijay, 11-16-2012 
 Description: Implement Interface  Method for ReferrerProjectTreatmentAuthorisation
 * 1)AddReferrerProjectTreatmentAuthorisation
 * 2)UpdateReferrerProjectTreatmentAuthorisation

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentAuthorisationRepository : BaseRepository<ReferrerProjectTreatmentAuthorisation, ITSDBContext>, IReferrerProjectTreatmentAuthorisationRepository
    {
        public ReferrerProjectTreatmentAuthorisationRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


        public int AddReferrerProjectTreatmentAuthorisation(ReferrerProjectTreatmentAuthorisation referrerProjectTreatmentAuthorisation)
        {

            SqlParameter TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", referrerProjectTreatmentAuthorisation.TreatmentCategoryID);
            SqlParameter DelegatedAuthorisationTypeID = new SqlParameter("@DelegatedAuthorisationTypeID", referrerProjectTreatmentAuthorisation.DelegatedAuthorisationTypeID);
            SqlParameter Amount = new SqlParameter("@Amount", (object)referrerProjectTreatmentAuthorisation.Amount ?? DBNull.Value);
           SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentAuthorisation.ReferrerProjectTreatmentID);
           SqlParameter Enabled = new SqlParameter("@Enabled", (object)referrerProjectTreatmentAuthorisation.Enabled );
           SqlParameter Quantity = new SqlParameter("@Quantity", (object)referrerProjectTreatmentAuthorisation.Quantity ?? DBNull.Value);
           return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerProjectTreatmentAuthorisationRepositoryProcedure.AddReferrerProjectTreatmentAuthorisation, TreatmentCategoryID, DelegatedAuthorisationTypeID, Amount, ReferrerProjectTreatmentID, Enabled, Quantity).SingleOrDefault();
        }

        public int UpdateReferrerProjectTreatmentAuthorisation(ReferrerProjectTreatmentAuthorisation referrerProjectTreatmentAuthorisation)

        {

            SqlParameter ReferrerProjectTreatmentAuthorisationID = new SqlParameter("@ReferrerProjectTreatmentAuthorisationID ", referrerProjectTreatmentAuthorisation.ReferrerProjectTreatmentAuthorisationID);

            SqlParameter TreatmentCategoryID = new SqlParameter("@TreatmentCategoryID ", referrerProjectTreatmentAuthorisation.TreatmentCategoryID);
            SqlParameter DelegatedAuthorisationTypeID = new SqlParameter("@DelegatedAuthorisationTypeID", referrerProjectTreatmentAuthorisation.DelegatedAuthorisationTypeID);
            SqlParameter Amount = new SqlParameter("@Amount", (object)referrerProjectTreatmentAuthorisation.Amount ?? DBNull.Value);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentAuthorisation.ReferrerProjectTreatmentID);
            SqlParameter Enabled = new SqlParameter("@Enabled", (object)referrerProjectTreatmentAuthorisation.Enabled);
            SqlParameter Quantity = new SqlParameter("@Quantity", (object)referrerProjectTreatmentAuthorisation.Quantity ?? DBNull.Value);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentAuthorisationRepositoryProcedure.UpdateReferrerProjectTreatmentAuthorisation, ReferrerProjectTreatmentAuthorisationID, TreatmentCategoryID, DelegatedAuthorisationTypeID, Amount, ReferrerProjectTreatmentID, Enabled, Quantity);

        }


        public int DeleteReferrerProjectTreatmentAuthorisation(int referrerProjectTreatmentAuthorisationID)
        {
            SqlParameter ReferrerProjectTreatmentAuthorisationId = new SqlParameter("@ReferrerProjectTreatmentAuthorisationID ", referrerProjectTreatmentAuthorisationID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentAuthorisationRepositoryProcedure.DeleteReferrerProjectTreatmentAuthorisation, ReferrerProjectTreatmentAuthorisationId);


        }


        public IEnumerable<ReferrerProjectTreatmentAuthorisation> GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentAuthorisation>(Global.StoredProcedureConst.ReferrerProjectTreatmentAuthorisationRepositoryProcedure.GetReferrerProjectTreatmentAuthorisationByReferrerProjectTreatmentID, ReferrerProjectTreatmentID);
        }
    }
}
