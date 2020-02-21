using ITS.Core.Data.Model;
namespace ITS.Core.BL
{
    public interface IJobDemand
    {
        JobDemand GetJobDemandByCaseID(int _caseID);
        int UpdateJobDemand(JobDemand objJobDemand);
        int AddJobDemand(JobDemand objJobDemand);
    }
}
