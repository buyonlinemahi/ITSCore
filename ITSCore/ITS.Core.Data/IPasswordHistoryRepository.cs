using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface IPasswordHistoryRepository : IBaseRepository<PasswordHistory>
    {
        IEnumerable<PasswordHistory> GetPasswordHistoryByUserID(int UserID);
    }
}
