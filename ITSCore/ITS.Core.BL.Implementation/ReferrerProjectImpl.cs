using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

#region Comment

/*
 Page Name:  ReferrerProjectImpl.cs
 Latest Version:  1.1
 Author : Vishal

 * Revision History:
 ===================================================================================
  Edited By : Vishal
  Date : 11-09-2012
  Version : 1.0
  Description : Add Implementation For GetReferrerByProjectNameAutoComplete for AutoComplete
  Description : Add Implementation For AddReferrerProject for Add ReferrerProject
  Description : Add Implementation For UpdateReferrerProject for ReferrerProject
===================================================================================
 * Edited By : Vishal
 * Date : 12-Nov-2012
 * Version : 1.1
 * Description : Modify  Method AutoComplete Add new parameter referrerId to it
 ==============================================================================================
*/

#endregion Comment

namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectImpl : IReferrerProject
    {
        private readonly IReferrerProjectRepository _referrerProjectRepository;
        private readonly IReferrerProjectTreatmentRepository _referrerProjectTreatmentRepository;
        private readonly IReferrerProjectTreatmentPricingRepository _referrerProjectTreatmentPricingRepository;

        public ReferrerProjectImpl(IReferrerProjectRepository referrerProjectRepository, IReferrerProjectTreatmentRepository referrerProjectTreatmentRepository, IReferrerProjectTreatmentPricingRepository referrerProjectTreatmentPricingRepository)
        {
            _referrerProjectRepository = referrerProjectRepository;
            _referrerProjectTreatmentRepository = referrerProjectTreatmentRepository;
            _referrerProjectTreatmentPricingRepository = referrerProjectTreatmentPricingRepository;
        }

        public int AddReferrerProject(ReferrerProject referrerProject)
        {
            return _referrerProjectRepository.AddReferrerProject(referrerProject);
        }

        public int UpdateReferrerProject(ReferrerProject referrerProject)
        {
            return _referrerProjectRepository.UpdateReferrerProject(referrerProject);
        }

        public IEnumerable<ReferrerProject> GetReferrerProjectNameAutoComplete(string projectNameLike, int referrerID)
        {
            return _referrerProjectRepository.GetReferrerProjectNameAutoComplete(projectNameLike, referrerID);
        }

        public IEnumerable<ReferrerProject> GetReferrerProjectByReferrerID(int referrerID)
        {
            return _referrerProjectRepository.GetReferrerProjectsByReferrerID(referrerID);
        }

        public IEnumerable<ReferrerAssignedUser> GetReferrerAssignedUserByReferrerID(int referrerID)
        {
            return _referrerProjectRepository.GetReferrerAssignedUserByReferrerID(referrerID);
        }
        public ReferrerProject GetReferrerProjectByProjectID(int projectID)
        {
            return _referrerProjectRepository.GetReferrerProjectByProjectID(projectID);
        }

        public int UpdateProjectStatus(int referrerProjectId, bool isTriage)
        {
            bool result = false;

            IEnumerable<ReferrerProjectTreatmentTreatmentCategory> refrerrerProjectTreatments = _referrerProjectTreatmentRepository.GetReferrerProjectTreatmentsByReferrerProjectID(referrerProjectId).Where(referrerProjectTreatment => referrerProjectTreatment.Enabled == true);

            foreach (ReferrerProjectTreatmentTreatmentCategory refrerrerTreatment in refrerrerProjectTreatments)
            {
                List<ReferrerProjectTreatmentPricing> _referrerProjectPricing = _referrerProjectTreatmentPricingRepository.GetReferrerProjectTreatmentPricingByReferrerProjectTreatmentID(refrerrerTreatment.ReferrerProjectTreatmentID).ToList();
                // int count = _referrerProjectPricing.Count();
                if (_referrerProjectPricing.Count() == 0)
                {
                    _referrerProjectRepository.UpdateReferrerProjectStatusByReferrerProjectID(referrerProjectId, Global.GlobalConst.Status.Pending);
                    return Global.GlobalConst.Status.Pending;
                }

                result = isTriage ? _referrerProjectPricing.Any(referrerProjectPrice => (referrerProjectPrice.Price == 0) && referrerProjectPrice.PricingTypeID != Global.GlobalConst.PricingType.VAT && referrerProjectPrice.PricingTypeID != Global.GlobalConst.PricingType.TRIAGEASSESSMENT) : _referrerProjectPricing.Any(referrerProjectPrice => referrerProjectPrice.Price == 0
                            && referrerProjectPrice.PricingTypeID != Global.GlobalConst.PricingType.VAT);

                if (result)
                {
                    _referrerProjectRepository.UpdateReferrerProjectStatusByReferrerProjectID(referrerProjectId, Global.GlobalConst.Status.Pending);
                    return Global.GlobalConst.Status.Pending;
                }
            }
            _referrerProjectRepository.UpdateReferrerProjectStatusByReferrerProjectID(referrerProjectId, Global.GlobalConst.Status.Complete);
            return Global.GlobalConst.Status.Complete;
        }

        public IEnumerable<ReferrerProject> GetCompleteReferrerProjectsByReferrerID(int referrerID)
        {
            return _referrerProjectRepository.GetCompleteReferrerProjectsByReferrerID(referrerID);
        }

        public bool GetReferrerProjectFirstAppointmentOfferedByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            int referrerProjectID = (_referrerProjectTreatmentRepository.GetReferrerProjectTreatmentByReferrerProjectTreatmentID(referrerProjectTreatmentID)).ReferrerProjectID;
            return (_referrerProjectRepository.GetReferrerProjectByProjectID(referrerProjectID)).FirstAppointmentOffered;
        }

        public IEnumerable<ReferrerProject> GetReferrerProjectAssignedToUser(int referrerID, int userID)
        {
            return _referrerProjectRepository.GetReferrerProjectAssignedToUser(referrerID, userID);
        }

        public IEnumerable<ReferrerProject> GetReferrerProjectNotAssignedToUser(int referrerID, int userID)
        {
            return _referrerProjectRepository.GetReferrerProjectNotAssignedToUser(referrerID, userID);
        }
    }
}