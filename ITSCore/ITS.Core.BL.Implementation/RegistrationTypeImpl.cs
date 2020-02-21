using System.Collections.Generic;
using ITS.Core.Data;
using ITS.Core.Data.Model;

#region Comment
/*
    * Page Name: RegistrationType.cs
    * Author : Vishal
    * Latest Version : 1.0
    * Reason :- Implement interface Registration Type
    * Created on 12-21-2012     
*/
#endregion

namespace ITS.Core.BL.Implementation
{
    public class RegistrationTypeImpl : IRegistrationType
    {
        private readonly IRegistrationTypeRepository _registrationTypeRepository;

        public RegistrationTypeImpl(IRegistrationTypeRepository registrationTypeRepository)
        {
            _registrationTypeRepository = registrationTypeRepository;
        }
        public IEnumerable<RegistrationType> GetAllRegistrationType()
        {
            return _registrationTypeRepository.GetAll();
        }
    }
}
