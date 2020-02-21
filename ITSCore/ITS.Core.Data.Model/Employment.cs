
namespace ITS.Core.Data.Model
{
    public class Employment
    {
        public int EmploymentId { get; set; }
        public int? EmploymentTypeId { get; set; }
        public string CompanyName { get; set; }
        public string JobRole { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public string PrimaryPhone { get; set; }
        public string Email { get; set; }

    }
}
