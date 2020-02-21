using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;


namespace ITS.Core.BL.Implementation
{

    public class CaseStopReasonImpl : ICaseStopReason
    {
        private readonly ICaseStopReasonRepository _caseStopReasonRepository;

        public CaseStopReasonImpl(ICaseStopReasonRepository caseStopReasonRepository)
        {
            _caseStopReasonRepository = caseStopReasonRepository;
        }




        public IEnumerable<CaseStopReason> GetAllCaseStopReason()
        {
            return _caseStopReasonRepository.GetAll();
        }
    }
}
