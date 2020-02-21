using ITS.Core.Data;
using ITS.Core.Data.Model;
namespace ITS.Core.BL.Implementation
{
    public class JobDemandImpl : IJobDemand
    {
        private readonly IJobDemandRepository _jobdemandRepository;

        public JobDemandImpl(IJobDemandRepository jobdemandRepository)
        {
            _jobdemandRepository = jobdemandRepository;
        }
        public  int UpdateJobDemand(JobDemand objJobDemand)
        {
            return _jobdemandRepository.UpdateJobDemand(objJobDemand);
        }

        public int AddJobDemand(JobDemand objJobDemand)
        {
            return _jobdemandRepository.AddJobDemand(objJobDemand);
        }
        public JobDemand GetJobDemandByCaseID(int _caseID)
        {
            return _jobdemandRepository.GetJobDemandByCaseID(_caseID);
        }
    }
}




     