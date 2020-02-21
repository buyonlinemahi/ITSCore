using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using BLModel = ITS.Core.BL.Model;

namespace ITS.Core.Data
{
    public interface IReferrerGroupRepository : IBaseRepository<ReferrerGroup>
    {

        int AddReferrerGroup(UpdateReferrerGroup _referrerGroup);      
        IEnumerable<ReferrerGroup> GetReferrerGroupUsersByreferrerID(int _referrerID);        
        int DeleteGroupByID(int groupID);
        IEnumerable<ReferrerUserDetail> GetGroupUsersByReferrerIDAndName(string _name, int _referrerID);
        IEnumerable<ReferrerSupplierCases> Get_ReferrerGroupUsersCasesByReferrerID(string _name, int _referrerID, int _skip, int _take);
        int GetReferrerGroupUsersCasesByReferrerIDCount(string _name, int _referrerID);
        int UpdateReferrerGroup(UpdateReferrerGroup _group);
    }
}
