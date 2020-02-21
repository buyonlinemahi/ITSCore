using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BLModel = ITS.Core.BL.Model;
namespace ITS.Core.Data.SqlServer.Repository
{
    public class ReferrerGroupRepository : BaseRepository<ReferrerGroup, ITSDBContext>, IReferrerGroupRepository
    {
        public ReferrerGroupRepository(IContextFactory<ITSDBContext> contextFactory)
            : base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {

        }

        public int AddReferrerGroup(UpdateReferrerGroup _referrerGroup)
        {
            SqlParameter _name = new SqlParameter("@GroupName", _referrerGroup.GroupName);
            SqlParameter _userID = new SqlParameter("@UserID", _referrerGroup.UserID);
            SqlParameter _referrerID = new SqlParameter("@ReferrerID", _referrerGroup.ReferrerID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerGroupProcedure.AddReferrerGroup, _name, _userID, _referrerID);
        }
       

        public IEnumerable<ReferrerGroup> GetReferrerGroupUsersByreferrerID(int _referrerID)
        {
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", _referrerID);
            return Context.Database.SqlQuery<ReferrerGroup>(Global.StoredProcedureConst.ReferrerGroupProcedure.GetReferrersGroupsByReferrerID, _ReferrerID);
        }

        public int DeleteGroupByID(int groupID)
        {
            SqlParameter _groupID = new SqlParameter("@GroupID", groupID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerGroupProcedure.DeleteGroupByID, _groupID);
        }

        public IEnumerable<ReferrerUserDetail> GetGroupUsersByReferrerIDAndName(string _name, int _referrerID)
        {
            SqlParameter _Name = new SqlParameter("@Name", _name);
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", _referrerID);           
            return Context.Database.SqlQuery<ReferrerUserDetail>(Global.StoredProcedureConst.ReferrerGroupProcedure.GetGroupUsersByReferrerIDAndName, _Name, _ReferrerID);
        }

        public IEnumerable<ReferrerSupplierCases> Get_ReferrerGroupUsersCasesByReferrerID(string _name, int _referrerID, int _skip, int _take)
        {
            SqlParameter _Name = new SqlParameter("@Name", _name);
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", _referrerID);
            SqlParameter _Skip = new SqlParameter("@Skip", _skip);
            SqlParameter _Take = new SqlParameter("@Take", _take);
            return Context.Database.SqlQuery<ReferrerSupplierCases>(Global.StoredProcedureConst.ReferrerGroupProcedure.GetReferrerGroupUsersCasesByReferrerID, _Name, _ReferrerID, _Skip, _Take);
        }
        public int GetReferrerGroupUsersCasesByReferrerIDCount(string _name, int _referrerID)
        {
            SqlParameter _Name = new SqlParameter("@Name", _name);
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", _referrerID); 
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.ReferrerGroupProcedure.GetReferrerGroupUsersCasesByReferrerIDCount, _Name, _ReferrerID).SingleOrDefault();
        }

        public int UpdateReferrerGroup(UpdateReferrerGroup _group)
        {
            SqlParameter _Newname = new SqlParameter("@NewGroupName", _group.NewName);
            SqlParameter _name = new SqlParameter("@GroupName", _group.GroupName);
            SqlParameter _referrerID = new SqlParameter("@ReferrerID", _group.ReferrerID);
            SqlParameter _userID = new SqlParameter("@UserID", _group.UserID);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.ReferrerGroupProcedure.UpdateReferrerGroupNameBynameAndID, _Newname, _name, _referrerID, _userID);
        }

    }
}
