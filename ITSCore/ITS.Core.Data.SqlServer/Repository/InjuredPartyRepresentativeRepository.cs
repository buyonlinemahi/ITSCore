using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class InjuredPartyRepresentativeRepository : BaseRepository<InjuredPartyRepresentative, ITSDBContext>, IInjuredPartyRepresentativeRepository
    {
        public InjuredPartyRepresentativeRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public int AdditionInjuredPartyRepresentative(InjuredPartyRepresentative objInjuredPartyRepresentative)
        {            
           
            SqlParameter _FirstName = new SqlParameter("@FirstName", !string.IsNullOrEmpty(objInjuredPartyRepresentative.FirstName) ? (object)objInjuredPartyRepresentative.FirstName : System.DBNull.Value);
            SqlParameter _LastName = new SqlParameter("@LastName", !string.IsNullOrEmpty(objInjuredPartyRepresentative.LastName) ? (object)objInjuredPartyRepresentative.LastName : System.DBNull.Value);
            SqlParameter _ReferralID = new SqlParameter("@ReferralID", objInjuredPartyRepresentative.ReferralID);
            SqlParameter _Tel1 = new SqlParameter("@Tel1", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Tel1) ? (object)objInjuredPartyRepresentative.Tel1 : System.DBNull.Value);
            SqlParameter _Tel2 = new SqlParameter("@Tel2", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Tel2) ? (object)objInjuredPartyRepresentative.Tel2 : System.DBNull.Value);
            SqlParameter _Address = new SqlParameter("@Address", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Address) ? (object)objInjuredPartyRepresentative.Address : System.DBNull.Value);
            SqlParameter _PostCode = new SqlParameter("@PostCode", !string.IsNullOrEmpty(objInjuredPartyRepresentative.PostCode) ? (object)objInjuredPartyRepresentative.PostCode : System.DBNull.Value);
            SqlParameter _Email = new SqlParameter("@Email", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Email) ? (object)objInjuredPartyRepresentative.Email : System.DBNull.Value);
            SqlParameter _Relationship = new SqlParameter("@Relationship", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Relationship) ? (object)objInjuredPartyRepresentative.Relationship : System.DBNull.Value);

            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.InjuredPartyRepresentativeRepository.AddInjuredPartyRepresentatives, _FirstName, _LastName, _ReferralID, _Tel1, _Tel2, _Address, _PostCode, _Email, _Relationship).SingleOrDefault();
        }

        public int UpdationInjuredPartyRepresentative(InjuredPartyRepresentative objInjuredPartyRepresentative)
        {
            SqlParameter _InjuredID = new SqlParameter("@InjuredID", objInjuredPartyRepresentative.InjuredID);
            SqlParameter _FirstName = new SqlParameter("@FirstName", !string.IsNullOrEmpty(objInjuredPartyRepresentative.FirstName) ? (object)objInjuredPartyRepresentative.FirstName : System.DBNull.Value);
            SqlParameter _LastName = new SqlParameter("@LastName", !string.IsNullOrEmpty(objInjuredPartyRepresentative.LastName) ? (object)objInjuredPartyRepresentative.LastName : System.DBNull.Value);
            SqlParameter _ReferralID = new SqlParameter("@ReferralID", objInjuredPartyRepresentative.ReferralID);
            SqlParameter _Tel1 = new SqlParameter("@Tel1", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Tel1) ? (object)objInjuredPartyRepresentative.Tel1 : System.DBNull.Value);
            SqlParameter _Tel2 = new SqlParameter("@Tel2", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Tel2) ? (object)objInjuredPartyRepresentative.Tel2 : System.DBNull.Value);
            SqlParameter _Address = new SqlParameter("@Address", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Address) ? (object)objInjuredPartyRepresentative.Address : System.DBNull.Value);
            SqlParameter _PostCode = new SqlParameter("@PostCode", !string.IsNullOrEmpty(objInjuredPartyRepresentative.PostCode) ? (object)objInjuredPartyRepresentative.PostCode : System.DBNull.Value);
            SqlParameter _Email = new SqlParameter("@Email", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Email) ? (object)objInjuredPartyRepresentative.Email : System.DBNull.Value);
            SqlParameter _Relationship = new SqlParameter("@Relationship", !string.IsNullOrEmpty(objInjuredPartyRepresentative.Relationship) ? (object)objInjuredPartyRepresentative.Relationship : System.DBNull.Value);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.InjuredPartyRepresentativeRepository.UpdateInjuredPartyRepresentatives, _InjuredID, _FirstName, _LastName, _ReferralID, _Tel1, _Tel2, _Address, _PostCode, _Email, _Relationship);
        }

        public InjuredPartyRepresentative GetInjuredPartyRepresentativesByReferralID(int ReferralID)
        {
            SqlParameter _ReferralID = new SqlParameter("@ReferralID", ReferralID);
            return Context.Database.SqlQuery<InjuredPartyRepresentative>(Global.StoredProcedureConst.InjuredPartyRepresentativeRepository.GetInjuredPartyRepresentativesByReferralID, _ReferralID).SingleOrDefault<InjuredPartyRepresentative>();
        }

        public InjuredPartyRepresentative GetInjuredPartyRepresentativesByID(int injuredID)
        {
            SqlParameter _injuredID = new SqlParameter("@InjuredID", injuredID);
            return Context.Database.SqlQuery<InjuredPartyRepresentative>(Global.StoredProcedureConst.InjuredPartyRepresentativeRepository.GetInjuredPartyRepresentativesByID, _injuredID).SingleOrDefault<InjuredPartyRepresentative>();
        }


    }
}
