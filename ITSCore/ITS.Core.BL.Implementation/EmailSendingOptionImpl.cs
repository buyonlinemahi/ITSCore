using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class EmailSendingOptionImpl : IEmailSendingOption
    {

        private readonly IEmailSendingOptionRepository _EmailSendingOptionRepository;

        public EmailSendingOptionImpl(IEmailSendingOptionRepository EmailSendingOptionRepository)
        {
            _EmailSendingOptionRepository = EmailSendingOptionRepository;
        }
        

   

        public IEnumerable<EmailSendingOption> GetAllEmailSendingOption()
        {
            return _EmailSendingOptionRepository.GetAll();
        }
    }
}
