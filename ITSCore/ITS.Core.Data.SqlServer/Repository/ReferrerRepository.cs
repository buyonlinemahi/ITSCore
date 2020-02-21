using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

#region Comment
/*
 Page Name:  ReferrerRepository.cs                      
 Latest Version:  1.3                                              
 Purpose: create referrer model and configure it inside itscore project                                                         
 Revision History:                                        
                                                           
  1.0 – 10/26/2012 Satya 
  1.1 - 10/26/2012 Manjit Singh
  added getReferrerDetail method to get referrer Detail
=====================================================================================================
 Edited By : Vishal
 Date : 27-Oct-2012
 Version : 1.2
 Description : Add Method For adding Referrer AddReferrer and Passing Paramenter to sp
 Description : Add Method For Updating Referrer Update and Passing Paramenter to sp
======================================================================================================
 Edited By : Vishal
 Date : 11-08-2012
 Version : 1.3
 Description : Add Method For Autocomplete ReferrerName Get_ReferrersLikeReferrerName
 =====================================================================================================
  */
#endregion

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerRepository : BaseRepository<Referrer, ITSDBContext>, IReferrerRepository
    {
        public ReferrerRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }
        public Referrer GetReferrerDetails(int referrerID)
        {
            SqlParameter ReferrerID = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<Referrer>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.GetReferrerInfoByReferrerID, ReferrerID).SingleOrDefault<Referrer>();

        }


        public int AddReferrer(Referrer referrer)
        {


            SqlParameter _ReferrerName = new SqlParameter("@ReferrerName", referrer.ReferrerName);
            SqlParameter _ReferrerContactFirstName = new SqlParameter("@ReferrerContactFirstName", referrer.ReferrerContactFirstName);
            SqlParameter _ReferrerContactLastName = new SqlParameter("@ReferrerContactLastName", referrer.ReferrerContactLastName);
            SqlParameter _ReferrerMainContactEmail = new SqlParameter("@ReferrerMainContactEmail", !string.IsNullOrEmpty(referrer.ReferrerMainContactEmail) ? (object)referrer.ReferrerMainContactEmail : System.DBNull.Value);
            SqlParameter _ReferrerMainContactFax = new SqlParameter("@ReferrerMainContactFax", !string.IsNullOrEmpty(referrer.ReferrerMainContactFax) ? (object)referrer.ReferrerMainContactFax : System.DBNull.Value);
            SqlParameter _ReferrerMainContactPhone = new SqlParameter("@ReferrerMainContactPhone", referrer.ReferrerMainContactPhone);
            SqlParameter _IsPolicyDetail = new SqlParameter("@IsPolicyDetail", referrer.IsPolicyDetail == null ? System.DBNull.Value : (object)referrer.IsPolicyDetail);
            SqlParameter _IsEmploymentDetail = new SqlParameter("@IsEmploymentDetail", referrer.IsEmploymentDetail);
            SqlParameter _IsEmploeeDetail = new SqlParameter("@IsEmploeeDetail", referrer.IsEmploeeDetail);
            SqlParameter _IsDrugandAlcoholTest = new SqlParameter("@IsDrugandAlcoholTest", referrer.IsDrugandAlcoholTest);
            SqlParameter _IsRepresentation = new SqlParameter("@IsRepresentation", referrer.IsRepresentation);
            SqlParameter _IsAdditionalQuestion = new SqlParameter("@IsAdditionalQuestion", referrer.IsAdditionalQuestion);
            SqlParameter _IsJobDemand = new SqlParameter("@IsJobDemand", referrer.IsJobDemand);
            SqlParameter _IsPolicyDetailOpenOrDropdowns = new SqlParameter("@IsPolicyDetailOpenOrDropdowns", referrer.IsPolicyDetailOpenOrDropdowns);
            SqlParameter _IsNewPolicyTypes = new SqlParameter("@IsNewPolicyTypes", referrer.IsNewPolicyTypes);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.AddReferrerInfo, _ReferrerName, _ReferrerContactFirstName, _ReferrerContactLastName, _ReferrerMainContactEmail, _ReferrerMainContactFax, _ReferrerMainContactPhone, _IsPolicyDetail, _IsEmploymentDetail, _IsEmploeeDetail, _IsDrugandAlcoholTest, _IsRepresentation, _IsAdditionalQuestion, _IsJobDemand, _IsPolicyDetailOpenOrDropdowns, _IsNewPolicyTypes).SingleOrDefault();

        }

        public int UpdateReferrer(Referrer referrer)
        {
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", referrer.ReferrerID);
            SqlParameter _ReferrerName = new SqlParameter("@ReferrerName", referrer.ReferrerName);
            SqlParameter _ReferrerContactFirstName = new SqlParameter("@ReferrerContactFirstName", referrer.ReferrerContactFirstName);
            SqlParameter _ReferrerContactLastName = new SqlParameter("@ReferrerContactLastName", referrer.ReferrerContactLastName);
            SqlParameter _ReferrerMainContactEmail = new SqlParameter("@ReferrerMainContactEmail", !string.IsNullOrEmpty(referrer.ReferrerMainContactEmail) ? (object)referrer.ReferrerMainContactEmail : System.DBNull.Value);
            SqlParameter _ReferrerMainContactFax = new SqlParameter("@ReferrerMainContactFax", !string.IsNullOrEmpty(referrer.ReferrerMainContactFax) ? (object)referrer.ReferrerMainContactFax : System.DBNull.Value);
            SqlParameter _ReferrerMainContactPhone = new SqlParameter("@ReferrerMainContactPhone", referrer.ReferrerMainContactPhone);
            SqlParameter _IsPolicyDetail = new SqlParameter("@IsPolicyDetail", referrer.IsPolicyDetail == null ? System.DBNull.Value : (object)referrer.IsPolicyDetail);
            SqlParameter _IsEmploymentDetail = new SqlParameter("@IsEmploymentDetail", referrer.IsEmploymentDetail);
            SqlParameter _IsEmploeeDetail = new SqlParameter("@IsEmploeeDetail", referrer.IsEmploeeDetail);
            SqlParameter _IsDrugandAlcoholTest = new SqlParameter("@IsDrugandAlcoholTest", referrer.IsDrugandAlcoholTest);
            SqlParameter _IsRepresentation = new SqlParameter("@IsRepresentation", referrer.IsRepresentation);
            SqlParameter _IsAdditionalQuestion = new SqlParameter("@IsAdditionalQuestion", referrer.IsAdditionalQuestion);
            SqlParameter _IsJobDemand = new SqlParameter("@IsJobDemand", referrer.IsJobDemand);
            SqlParameter _IsPolicyDetailOpenOrDropdowns = new SqlParameter("@IsPolicyDetailOpenOrDropdowns", referrer.IsPolicyDetailOpenOrDropdowns);
            SqlParameter _IsNewPolicyTypes = new SqlParameter("@IsNewPolicyTypes", referrer.IsNewPolicyTypes);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerRepositoryProcedures.UpdateReferrerInfo, _ReferrerID, _ReferrerName, _ReferrerContactFirstName, _ReferrerContactLastName, _ReferrerMainContactEmail, _ReferrerMainContactFax, _ReferrerMainContactPhone, _IsPolicyDetail, _IsEmploymentDetail, _IsEmploeeDetail, _IsDrugandAlcoholTest, _IsRepresentation, _IsAdditionalQuestion, _IsJobDemand, _IsPolicyDetailOpenOrDropdowns, _IsNewPolicyTypes);

        }

        public IEnumerable<Referrer> GetReferrersLikeReferrerName(string referrerNameLike)
        {
            SqlParameter referrerName = new SqlParameter("@ReferrerName", referrerNameLike);
            return Context.Database.SqlQuery<Referrer>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.Get_ReferrersLikeReferrerName, referrerName);
        }

        public IEnumerable<ReferrerLocationReferrer> GetReferrerLocationReferrerLikeReferrerName(string referrerName, int skip, int take)
        {
            SqlParameter _referrerName = new SqlParameter("@ReferrerName", referrerName);
            SqlParameter _skip = new SqlParameter("@Skip ", skip);
            SqlParameter _take = new SqlParameter("@Take ", take);
            return Context.Database.SqlQuery<ReferrerLocationReferrer>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.GetReferrerLocationReferrerLikeReferrerName, _referrerName, _skip, _take);

        }

        public int GetReferrerLocationReferrerLikeReferrerNameCount(string referrerName)
        {
            SqlParameter _referrerName = new SqlParameter("@ReferrerName", referrerName);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.GetReferrerLocationReferrerLikeReferrerNameCount, _referrerName).SingleOrDefault();
        }


        public bool GetReferrerExistsByName(string referrerName)
        {
            SqlParameter _referrerName = new SqlParameter("@ReferrerName", referrerName);
            return Context.Database.SqlQuery<bool>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.GetReferrerExistsByName, _referrerName).SingleOrDefault();
        }


        public IEnumerable<Referrer> GetReferrersRecentlyAdded()
        {
            return Context.Database.SqlQuery<Referrer>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.GetReferrersRecentlyAdded);
        }


        public IEnumerable<ReferrersName> GetAllReferrers()
        {
            return Context.Database.SqlQuery<ReferrersName>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.GetAllReferrers);
        }

        public int GetReferrerIDbyReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            SqlParameter _referrerProjectTreatmentID = new SqlParameter("@ReferrerProjectTreatmentID", referrerProjectTreatmentID);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.ReferrerRepositoryProcedures.GetReferrerIDbyReferrerProjectTreatmentID, _referrerProjectTreatmentID).SingleOrDefault();

        }
    }
}
