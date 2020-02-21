using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class CaseCommunicationHistoryImpl : ICaseCommunicationHistory
    {
        private readonly ICaseCommunicationHistoryRepository _caseCommunicationHistory;

        public CaseCommunicationHistoryImpl(ICaseCommunicationHistoryRepository caseCommunicationHistory)
        {
            _caseCommunicationHistory = caseCommunicationHistory;
        }

        public int AddCaseCommunicationHistory(CaseCommunicationHistory caseCommunicationHistory)
        {
            return _caseCommunicationHistory.AddCaseCommunicationHistory(caseCommunicationHistory);
        }

        public IEnumerable<CaseCommunicationHistoryUser> GetCaseCommunicationHistoriesByCaseID(int caseID)
        {
            return _caseCommunicationHistory.GetCaseCommunicationHistoriesByCaseID(caseID);
        }
    }
}