using ITS.Core.Data.Model;
using System.Collections.Generic;



namespace ITS.Core.BL
{
    public interface IProposedTreatmentMethod
    {
        IEnumerable<ProposedTreatmentMethod> GetAllProposedTreatmentMethod();
    }
}
