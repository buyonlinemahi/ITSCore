using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;

#region Comment

/*
  Page Name:  IReferrerProjectTreatmentEmail.cs                      
  Version:  1.1                                              
  Purpose: Added,Update,Delete,GetReferrerProjectTreatmentId, GetReferrerProjectTreatmentEmailById,DeleteReferrerProjectTreatmentEmailById added methods                                                 
  Revision History:                               
  1.0 – 11/14/2012 Harpreet Singh 
 * 
 * Edited By   : Pardeep Kumar
 * Dated       : 07/26/2013
 * Description : Implemented interface's New method GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID
 * Version     : 1.1
  
 */


#endregion

namespace ITS.Core.BL.Implementation
{
    public class ReferrerProjectTreatmentEmailImpl : IReferrerProjectTreatmentEmail
    {
        private readonly IReferrerProjectTreatmentEmailRepostory _referrerProjectTreatmentEmailRepostory;

        //private readonly IEmailTypeValue _emailTypeValue;

        private readonly IEmailTypeValueRepository _emailTypeValueRepository;

        public ReferrerProjectTreatmentEmailImpl(IReferrerProjectTreatmentEmailRepostory referrerProjectTreatmentEmailRepostory,IEmailTypeValueRepository emailTypeValueRepository)
        {
            _referrerProjectTreatmentEmailRepostory = referrerProjectTreatmentEmailRepostory;
            _emailTypeValueRepository = emailTypeValueRepository;
        }


        public IEnumerable<ReferrerProjectTreatmentEmail> GetByReferrerProjectTreatmentId(int referrerProjectTreatmentId)
        {
            return _referrerProjectTreatmentEmailRepostory.GetByReferrerProjectTreatmentId(referrerProjectTreatmentId);
        }
        public IEnumerable<ReferrerProjectTreatment> GetReferrerProjectTreatmentByTreatmentId(int referrerProjectTreatmentId)
        {
            return _referrerProjectTreatmentEmailRepostory.GetReferrerProjectTreatmentByTreatmentId(referrerProjectTreatmentId);
        }
        

        public int AddReferrerProjectTreatmentEmail(ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail)
        {
            return _referrerProjectTreatmentEmailRepostory.AddReferrerProjectTreatmentEmail(referrerProjectTreatmentEmail);
        }

        public int UpdateReferrerProjectTreatmentEmail(ReferrerProjectTreatmentEmail referrerProjectTreatmentEmail)
        {
            return _referrerProjectTreatmentEmailRepostory.UpdateReferrerProjectTreatmentEmail(referrerProjectTreatmentEmail);
        }

        public int DeleteReferrerProjectTreatmentEmailById(int referrerProjectTreatmentEmailId)
        {
            return _referrerProjectTreatmentEmailRepostory.DeleteReferrerProjectTreatmentEmailById(referrerProjectTreatmentEmailId);

        }

        public ReferrerProjectTreatmentEmail GetReferrerProjectTreatmentEmailByEmailId(int id)
        {
            return _referrerProjectTreatmentEmailRepostory.GetById(id);
        }

        public IEnumerable<ReferrerProjectTreatmentEmailTypeName> GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID(int referrerProjectTreatmentID)
        {
            var emailTypeValue = _emailTypeValueRepository.GetAllEmailTypeValue().ToList();
            var referrerProjectTreatmentEmailTypeNames = _referrerProjectTreatmentEmailRepostory.GetReferrerProjectTreatmentEmailsTypeNameByReferrerProjectTreatmentID(referrerProjectTreatmentID).ToList();

            referrerProjectTreatmentEmailTypeNames.ForEach(o => o.EmailTypeValues = emailTypeValue);

            return referrerProjectTreatmentEmailTypeNames.AsEnumerable();
        }
    }
}
