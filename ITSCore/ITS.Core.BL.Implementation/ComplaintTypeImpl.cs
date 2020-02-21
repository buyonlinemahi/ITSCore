using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{

    public class ComplaintTypeImpl : IComplaintType
    {
       
        private readonly IComplaintTypeRepository _complaintTypeRepository;

        public ComplaintTypeImpl(IComplaintTypeRepository complaintTypeRepository)
        {
            _complaintTypeRepository = complaintTypeRepository;
        }


        public IEnumerable<ComplaintType> GetAllComplaintType()
        {
            return _complaintTypeRepository.GetAll();
        }

    }
}
