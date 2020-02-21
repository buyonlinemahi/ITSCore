using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL.Implementation
{

    public class ComplaintStatusImpl : IComplaintStatus
    {
       
        private readonly IComplaintStatusRepository _complaintStatusRepository;

        public ComplaintStatusImpl(IComplaintStatusRepository complaintStatusRepository)
        {
            _complaintStatusRepository = complaintStatusRepository;
        }


        public IEnumerable<ComplaintStatus> GetAllComplaintStatus()
        {
            return _complaintStatusRepository.GetAll();
        }

    }
}
