using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

/*
 Page Name:  ReferrerLocationRepository.cs                     
 Latest Version:  1.7                                             
  Purpose:  Parameter added for IsActive field in AddReferrerLocation and UpdateReferrerLocation                                                     
  Revision History:                                        
                                                           
   1.0 – 10/26/2012 Satya 
 * 
 * version :  1.1
 * Edited By: Anuj Batra
 * Reason :   Created method to update the ReferrerLocation Information.
 * 
 * Edited By :   Robin Singh
 * Date:         10/30/2012
   Version  :    1.2
   Description : Created method to Delete the ReferrerLocation Information.

  *Edited By :   Vishal
  Version  :    1.3
  Description : Added a method to get referrerlocations by referrerid name GetReferrerLocationsByReferrerID
  ModifiedDate: 10/30/2012 
 * 
  *Edited By :   Satya
  Version  :    1.4
  Description : Added a method to add referrerlocation
  ModifiedDate: 10/30/2012 
 * 
  Edited By :   Vishal
  Version  :    1.5
  Description : Modify Add  method to add Scope Identy
  ModifiedDate: 11/19/2012 
 * 
 *   Edited By :   Vijay Kumar
  Version  :    1.6
  Description : Modify Add  method to update ReferrerLocationMainOffice
  ModifiedDate: 11/19/2012 
 
  Edited By :   Manjit Singh
  Version  :    1.7
  Description : Parameter added for IsActive field in AddReferrerLocation and UpdateReferrerLocation
  ModifiedDate: March 5, 2013 
 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerLocationRepository : BaseRepository<ReferrerLocation, ITSDBContext>, IReferrerLocationRepository
    {
        public ReferrerLocationRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AddReferrerLocation(ReferrerLocation referrerLocation)
        {
            SqlParameter locationName = new SqlParameter("@LocationName", referrerLocation.Name);
            SqlParameter locationAddress = new SqlParameter("@LocationAddress", referrerLocation.Address);
            SqlParameter locationCity = new SqlParameter("@LocationCity",!string.IsNullOrEmpty(referrerLocation.City) ? (object)referrerLocation.City : System.DBNull.Value);
            SqlParameter locationRegion = new SqlParameter("@LocationRegion", !string.IsNullOrEmpty(referrerLocation.Region) ? (object)referrerLocation.Region : System.DBNull.Value);
            SqlParameter locationPostCode = new SqlParameter("@LocationPostCode", referrerLocation.PostCode);
            SqlParameter locationIsMainOffice = new SqlParameter("@IsMainOffice", referrerLocation.IsMainOffice);
            SqlParameter referrerID = new SqlParameter("@ReferrerID", referrerLocation.ReferrerID);
            SqlParameter isActiverID = new SqlParameter("@IsActive", referrerLocation.IsActive);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.ReferrerLocationRepositoryProcedures.AddReferrerLocation, locationName, locationAddress, locationCity, locationRegion, locationPostCode, locationIsMainOffice, referrerID, isActiverID).SingleOrDefault();


        }

        /// <summary>
        /// Method to update the Referrer location by LocationId.
        /// </summary>
        /// <param name="referrerLocation"></param>
        /// <returns></returns>
        public int UpdateReferrerLocation(ReferrerLocation referrerlocation)
        {
            SqlParameter referrerLocationID = new SqlParameter("@ReferrerLocationID", referrerlocation.ReferrerLocationID);
            SqlParameter locationName = new SqlParameter("@LocationName", referrerlocation.Name);
            SqlParameter locationAddress = new SqlParameter("@LocationAddress", referrerlocation.Address);
            SqlParameter locationCity = new SqlParameter("@LocationCity", !string.IsNullOrEmpty(referrerlocation.City) ? (object)referrerlocation.City : System.DBNull.Value);
            SqlParameter locationRegion = new SqlParameter("@LocationRegion", !string.IsNullOrEmpty(referrerlocation.Region) ? (object)referrerlocation.Region : System.DBNull.Value);
            SqlParameter locationPostCode = new SqlParameter("@LocationPostCode", referrerlocation.PostCode);
            SqlParameter isActiverID = new SqlParameter("@IsActive", referrerlocation.IsActive);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerLocationRepositoryProcedures.UpdateReferrerLocationInfo, referrerLocationID, locationName, locationAddress, locationCity, locationRegion, locationPostCode, isActiverID);
        }

        public int DeleteByReferrerLocationID(int referrerLocationbyID)
        {
            SqlParameter referrerLocationId = new SqlParameter("@ReferrerLocationID", referrerLocationbyID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerLocationRepositoryProcedures.DeleteReferrerLocationInfo, referrerLocationId);
        }

        public IEnumerable<ReferrerLocation> GetReferrerLocationsByReferrerID(int referrerID)
        {
            SqlParameter referrerId = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<ReferrerLocation>(Global.StoredProcedureConst.ReferrerLocationRepositoryProcedures.GetReferrerLocationsByReferrerID, referrerId);
        }

        public ReferrerLocation GetMainReferrerLocationByReferrerID(int referrerID)
        {
            SqlParameter referrerId = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<ReferrerLocation>(Global.StoredProcedureConst.ReferrerLocationRepositoryProcedures.GetReferrerMainLocationByReferrerID, referrerId).SingleOrDefault();
        }

        public int UpdateReferrerLocationMainOffice(int referrerID, int referrerOfficeLocationID)
        {
            SqlParameter referrerId = new SqlParameter("@referrerID", referrerID);
            SqlParameter referrerOfficeLocationId = new SqlParameter("@referrerofficelocationid", referrerOfficeLocationID);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerLocationRepositoryProcedures.UpdateReferrerLocationMainOffice, referrerId, referrerOfficeLocationId);

        }
    }
}
