using Core.Base.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.Data
{
    public interface IJobDemandRepository : IBaseRepository<JobDemand>
    {
        JobDemand GetJobDemandByCaseID(int _caseID);
        int UpdateJobDemand(JobDemand objJobDemand);
        int AddJobDemand(JobDemand objJobDemand);
    }
}
