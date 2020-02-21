using ITS.Core.Data;
using ITS.Core.Data.Model;

/*
Latest Version:1.0
 * Author : Vishal
 * Date : 12/15/2012
 * Task : #279
 * Description : Add solicitor Implementation
 * Description : Add Insert Method AddSolicitor

 */

namespace ITS.Core.BL.Implementation
{
    public class SolicitorImpl : ISolicitor
    {
        private readonly ISolicitorRepository _solicitorRepository;

        public SolicitorImpl(ISolicitorRepository supplierRepository)
        {
            _solicitorRepository = supplierRepository;
        }

        public int AddSolicitor(Solicitor solicitor)
        {
            return _solicitorRepository.AddSolicitor(solicitor);
        }

        public int UpdateSolicitorBySolicitorID(Solicitor solicitor)
        {
            return _solicitorRepository.UpdateSolicitorBySolicitorID(solicitor);
        }

        public Solicitor GetSolicitorBySolicitorID(int solicitorID)
        {
            return _solicitorRepository.GetSolicitorBySolicitorID(solicitorID);
        }

        public Solicitor GetSolicitorByPatientID(int patientID)
        {
            return _solicitorRepository.GetSolicitorByPatientID(patientID);
        }
    }
}