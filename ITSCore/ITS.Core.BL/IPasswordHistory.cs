using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL
{
    public interface IPasswordHistory
    {
        int AddPasswordHistory(PasswordHistory historyObj);
        IEnumerable<PasswordHistory> GetPasswordHistoryByUserID(int userID);
    }
}
