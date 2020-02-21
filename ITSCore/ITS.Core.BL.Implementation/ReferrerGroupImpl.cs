using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;
using BLModel = ITS.Core.BL.Model;
using DLModel = ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
    public class ReferrerGroupImpl :IReferrerGroup
    {
        private readonly IReferrerGroupRepository _iReferrerGroupRepository;
        public ReferrerGroupImpl(IReferrerGroupRepository iReferrerGroupRepository)
        {
            _iReferrerGroupRepository = iReferrerGroupRepository;
        }


        public int AddReferrerGroup(BLModel.UpdateReferrerGroup _referrerGroup)
        {
            DLModel.UpdateReferrerGroup _objDL = new DLModel.UpdateReferrerGroup();
            _objDL.GroupName = _referrerGroup.GroupName;
            _objDL.ReferrerID = _referrerGroup.ReferrerID;
            _objDL.UserID = _referrerGroup.UserID;
            return _iReferrerGroupRepository.AddReferrerGroup(_objDL);
        }


        public IEnumerable<ReferrerGroup> GetReferrerGroupUsersByreferrerID(int _referrerID)
        {
            return _iReferrerGroupRepository.GetReferrerGroupUsersByreferrerID(_referrerID);
        }

        public int DeleteGroupByID(int groupID)
        {
            return _iReferrerGroupRepository.DeleteGroupByID(groupID);
        }

        public IEnumerable<BLModel.ReferrerUserDetail> GetGroupUsersByReferrerIDAndName(string _name, int _referrerID)
        {
            var result = _iReferrerGroupRepository.GetGroupUsersByReferrerIDAndName(_name, _referrerID).ToList();
            List<ITS.Core.BL.Model.ReferrerUserDetail> _referrerUserDetail = new List<Model.ReferrerUserDetail>();
            foreach (var item in result)
            {
                _referrerUserDetail.Add(new Model.ReferrerUserDetail()
                {
                    GroupID = item.GroupID,
                    UserName = item.UserName,
                    UserID = item.UserID,
                    GroupName = item.GroupName,
                    ReferrerID = item.ReferrerID
                });
            }
            return _referrerUserDetail.AsEnumerable();
        }

       
        public IEnumerable<ReferrerSupplierCases> Get_ReferrerGroupUsersCasesByReferrerID(string _name, int _referrerID, int _skip, int _take)
        {
            return _iReferrerGroupRepository.Get_ReferrerGroupUsersCasesByReferrerID(_name, _referrerID, _skip, _take);
        }

        public int GetReferrerGroupUsersCasesByReferrerIDCount(string _name, int _referrerID)
        {
            return _iReferrerGroupRepository.GetReferrerGroupUsersCasesByReferrerIDCount(_name, _referrerID);            
        }

        public int UpdateReferrerGroup(BLModel.UpdateReferrerGroup _updateRefGroup)
        {           
            DLModel.UpdateReferrerGroup _objDL = new DLModel.UpdateReferrerGroup();
            _objDL.GroupName = _updateRefGroup.GroupName;
            _objDL.NewName = _updateRefGroup.NewName;
            _objDL.ReferrerID = _updateRefGroup.ReferrerID;
            _objDL.UserID = _updateRefGroup.UserID;
            return _iReferrerGroupRepository.UpdateReferrerGroup(_objDL);
        }
      

    }
}
