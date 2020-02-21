using System.Collections.Generic;
using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface ICaseCommunicationHistory
    {
        int AddCaseCommunicationHistory(CaseCommunicationHistory caseCommunicationHistory);

        IEnumerable<CaseCommunicationHistoryUser> GetCaseCommunicationHistoriesByCaseID(int caseID);
    }
}