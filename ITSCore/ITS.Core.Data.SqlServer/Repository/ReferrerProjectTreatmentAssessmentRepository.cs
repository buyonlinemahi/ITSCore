using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  ReferrerProjectTreatmentAssessmentRepository.cs                      
 Latest Version:  1.1                                              
  Purpose: create ReferrerProjectTreatmentAssessment model  inside itscore project                                                         
  Revision History:                                    
                                                           
   1.0 – 11/10/2012 Satya 
 
 *Revision History
 Version : 1.1 ,Vijay, 11-16-2012 
 Description: Implement Interface Method for ReferrerProjectTreatmentAssessment
 * 1) AddReferrerProjectTreatmentAssignment
 * 2) UpdateReferrerProjectTreatmentAssignment

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerProjectTreatmentAssessmentRepository : BaseRepository<ReferrerProjectTreatmentAssessment, ITSDBContext>, IReferrerProjectTreatmentAssessmentRepository
    {
        public ReferrerProjectTreatmentAssessmentRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }
        public int AddReferrerProjectTreatmentAssignment(ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment)
        {
            SqlParameter AsssessmentServiceID = new SqlParameter("@AssessmentServiceID", referrerProjectTreatmentAssignment.AssessmentServiceID);
            SqlParameter AssessmentTypeID = new SqlParameter("@AssessmentTypeID", referrerProjectTreatmentAssignment.AssessmentTypeID);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentAssignment.ReferrerProjectTreatmentID);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerProjectTreatmentAssessmentRepositoryProcedure.AddReferrerProjectTreatmentAssignment, AsssessmentServiceID, AssessmentTypeID, ReferrerProjectTreatmentID).SingleOrDefault();
        }

        public int UpdateReferrerProjectTreatmentAssignment(ReferrerProjectTreatmentAssessment referrerProjectTreatmentAssignment)
        {
            SqlParameter ReferrerProjectTreatmentAssessmentID = new SqlParameter("@ReferrerProjectTreatmentAssessmentID", referrerProjectTreatmentAssignment.ReferrerProjectTreatmentAssessmentID);
            SqlParameter AsssessmentServiceID = new SqlParameter("@AssessmentServiceID", referrerProjectTreatmentAssignment.AssessmentServiceID);
            SqlParameter AssessmentTypeID = new SqlParameter("@AssessmentTypeID", referrerProjectTreatmentAssignment.AssessmentTypeID);
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentAssignment.ReferrerProjectTreatmentID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentAssessmentRepositoryProcedure.UpdateReferrerProjectTreatmentAssignment, ReferrerProjectTreatmentAssessmentID, AsssessmentServiceID, AssessmentTypeID, ReferrerProjectTreatmentID);

        }

        public IEnumerable<ReferrerProjectTreatmentAssessment> GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter ReferrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return Context.Database.SqlQuery<ReferrerProjectTreatmentAssessment>(Global.StoredProcedureConst.ReferrerProjectTreatmentAssessmentRepositoryProcedure.GetReferrerProjectTreatmentAssessmentByReferrerProjectTreatmentID, ReferrerProjectTreatmentID);

        }

        public int DeleteReferrerProjectTreatmentAssignment(int referrerProjectTreatmentAssessmentID)
        {
            SqlParameter ReferrerProjectTreatmentAssessmentId = new SqlParameter("@ReferrerProjectTreatmentAssessmentID", referrerProjectTreatmentAssessmentID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerProjectTreatmentAssessmentRepositoryProcedure.DeleteReferrerProjectTreatmentAssignment, ReferrerProjectTreatmentAssessmentId);
        }
    }
}
