
namespace ITS.Core.Data.Model
{
   public class PatientPrimaryLink
    {
       public int PatientPrimaryID { get; set; } 
       public int PatientID { get; set; }
       public int PrimaryConditionID { get; set; }
    }
}
