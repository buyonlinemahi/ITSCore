using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
  public class PasswordHistoryImpl:IPasswordHistory
    {
      private readonly IPasswordHistoryRepository _IPasswordHistoryRepository;

      public PasswordHistoryImpl(IPasswordHistoryRepository IPasswordHistoryRepository)
        {
            _IPasswordHistoryRepository = IPasswordHistoryRepository;
        }

      public int AddPasswordHistory(PasswordHistory historyObj)
      {
          return _IPasswordHistoryRepository.Add(historyObj).PasswordHistoryID;
      }

      public IEnumerable<PasswordHistory> GetPasswordHistoryByUserID(int userID)
      {
          return _IPasswordHistoryRepository.GetPasswordHistoryByUserID(userID);
      }
    }
}
