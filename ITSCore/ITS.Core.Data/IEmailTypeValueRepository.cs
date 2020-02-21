using Core.Base.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.Data
{
    public interface IEmailTypeValueRepository : IBaseRepository<EmailTypeValue>
    {
        IEnumerable<EmailTypeValue> GetAllEmailTypeValue();
    }
}
