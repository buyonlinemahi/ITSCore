using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class EmailTypeImpl : IEmailType
    {

        private readonly IEmailTypeRepository _EmailTypeRepository;

        public EmailTypeImpl(IEmailTypeRepository EmailTypeRepository)
        {
            _EmailTypeRepository = EmailTypeRepository;
        }




        public IEnumerable<EmailType> GetAllEmailType()
        {
            return _EmailTypeRepository.GetAll();
        }
    }
}
