using ITS.Core.Data;
using System.Collections.Generic;

namespace ITS.Core.BL.Implementation
{
    public class AdmittedImpl : IAdmitted
    {
        private readonly IAdmittedRepository _IAdmittedRepository;

        public AdmittedImpl(IAdmittedRepository IAdmittedRepository)
        {
            _IAdmittedRepository = IAdmittedRepository;
        }

        public IEnumerable<Data.Model.Admitted> GetAllAdmitted()
        {
            return _IAdmittedRepository.GetAll();
        }
    }
}
