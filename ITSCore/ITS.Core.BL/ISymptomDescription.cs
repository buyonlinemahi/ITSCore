using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface ISymptomDescription
    {
        IEnumerable<SymptomDescription> GetAllSymptomDescription();
        string GetSymptomDescriptionDesciptionByID(int _symptomDescriptionID);
    }
}
