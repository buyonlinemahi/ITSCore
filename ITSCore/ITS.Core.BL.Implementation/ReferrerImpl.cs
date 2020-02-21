using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

#region Comment
/*
 Page Name:  ReferrerImpl.cs          
 Latest Version : 1.4                                                          
 
 History Revision
 * 1.0 – 10/26/2012 Manjit Singh   
 Created class ReferrerImpl with a method to GetReferrerDetails
=================================================================
  Edited By : Vishal
  Date : 27-Oct-2012
  Version : 1.1
  Description : Add Method For Add_Reffer
  Description : Add Method For Update_Reffer
=====================================================================
  Edited By : Vishal
  Date : 11-08-2012
  Version : 1.2
  Description : Add Method For Get_ReferrersLikeReferrerName for AutoComplete
===================================================================================
 * * 
  Edited By : Robin Singh
  Date :      11-09-2012
  Version : 1.3
  Description : Add Method For UpdateReferrerAndMainLocation
 * 
 ===================================================================================
 * * 
  Edited By : Pardeep Kumar
  Date :      23-Aug-2013
  Version : 1.4
  Description : Fixed "location.IsActive = true" in AddReferrerAndMainLocation Method
 */

#endregion
namespace ITS.Core.BL.Implementation
{
    public class ReferrerImpl : IReferrer
    {
        private readonly IReferrerRepository _referrerRepository;
        private readonly IReferrerLocationRepository _referrerLocationRepository;
        public ReferrerImpl(IReferrerRepository referrerRepository, IReferrerLocationRepository referrerLocationRepository)
        {
            _referrerRepository = referrerRepository;
            _referrerLocationRepository = referrerLocationRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Referrer GetReferrerDetails(int referrerID)
        {
            return _referrerRepository.GetReferrerDetails(referrerID);
        }

        public int AddReferrer(Referrer referrer)
        {
            return _referrerRepository.AddReferrer(referrer);
        }

        public int UpdateReferrer(Referrer referrer)
        {
            return _referrerRepository.UpdateReferrer(referrer);
        }

        public int AddReferrerAndMainLocation(Referrer referrer, ReferrerLocation location)
        {
            location.ReferrerID = _referrerRepository.AddReferrer(referrer);
            location.IsMainOffice = true;
            location.IsActive = true;
            _referrerLocationRepository.AddReferrerLocation(location);
            return location.ReferrerID;
        }



        public int UpdateReferrerAndMainLocation(Referrer referrer, ReferrerLocation location)
        {
            _referrerRepository.UpdateReferrer(referrer);
            return _referrerLocationRepository.UpdateReferrerLocation(location);
        }

        public IEnumerable<Referrer> GetAllReferrer()
        {
            return _referrerRepository.GetAll();
        }


        public IEnumerable<Referrer> GetReferrersLikeReferrerName(string referrerNameLike)
        {
            return _referrerRepository.GetReferrersLikeReferrerName(referrerNameLike);
        }


        public bool GetReferrerExistsByName(string referrerName)
        {
            return _referrerRepository.GetReferrerExistsByName(referrerName);
        }


        public IEnumerable<Referrer> GetReferrersRecentlyAdded()
        {
            return _referrerRepository.GetReferrersRecentlyAdded();
        }


        public int GetReferrerLocationReferrerLikeReferrerNameCount(string referrerName)
        {
             return  _referrerRepository.GetReferrerLocationReferrerLikeReferrerNameCount(referrerName);
        }

        public IEnumerable<ReferrerLocationReferrer> GetReferrerLocationReferrerLikeReferrerName(string referrerName, int skip, int take)
        {
            return _referrerRepository.GetReferrerLocationReferrerLikeReferrerName(referrerName, skip, take);
        }


        public IEnumerable<ReferrersName> GetAllReferrers()
        {
            return _referrerRepository.GetAllReferrers();
        }

      public int GetReferrerIDbyReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            return _referrerRepository.GetReferrerIDbyReferrerProjectTreatmentID(referrerProjectTreatmentID);
        }
    }

}

