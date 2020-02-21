using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface ICaseCommunicationHistoryRepository : IBaseRepository<CaseCommunicationHistory>
    {

        int AddCaseCommunicationHistory(CaseCommunicationHistory caseCommunicationHistory);
        IEnumerable<CaseCommunicationHistoryUser> GetCaseCommunicationHistoriesByCaseID(int caseID);
    }
}
