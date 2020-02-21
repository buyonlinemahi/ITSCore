using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface IEmployeeDetail
    {
        int AddEmployeeDetail(EmployeeDetail objDetail);
        int UpdateEmployeeDetail(EmployeeDetail objDetail);
        void DeleteEmployeeDetailByID(int employeeDetailID);
        EmployeeDetail GetEmployeeDetailByID(int employeeDetailID);
    }
}