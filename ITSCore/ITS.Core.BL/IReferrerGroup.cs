using ITS.Core.Data.Model;
using System.Collections.Generic;
using BLModel = ITS.Core.BL.Model;

namespace ITS.Core.BL
{
    public interface IReferrerGroup
    {
        int AddReferrerGroup(BLModel.UpdateReferrerGroup _referrerGroup);       
        IEnumerable<ReferrerGroup> GetReferrerGroupUsersByreferrerID(int _referrerID);       
        int DeleteGroupByID(int groupID);
        IEnumerable<BLModel.ReferrerUserDetail> GetGroupUsersByReferrerIDAndName(string _name, int _referrerID);
        IEnumerable<ReferrerSupplierCases> Get_ReferrerGroupUsersCasesByReferrerID(string _name, int _referrerID, int _skip, int _take);
        int GetReferrerGroupUsersCasesByReferrerIDCount(string _name, int _referrerID);
        int UpdateReferrerGroup(BLModel.UpdateReferrerGroup _updateRefGroup);       
    }
}
