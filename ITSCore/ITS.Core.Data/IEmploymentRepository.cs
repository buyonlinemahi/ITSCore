using Core.Base.Data;
using ITS.Core.Data.Model;


namespace ITS.Core.Data
{
    public interface IEmploymentRepository : IBaseRepository<Employment>
    {
        Employment GetEmploymentByEmploymentID(int _employmentID);
        int AddEmployment(Employment employment);
        int UpdateEmployment(Employment employment);
    }
}
