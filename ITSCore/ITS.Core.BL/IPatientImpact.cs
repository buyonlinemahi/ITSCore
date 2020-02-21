using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IPatientImpact
    {
        IEnumerable<PatientImpact> GetAllPatientImpacts();
    }
}
