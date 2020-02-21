using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
    public class UKPostCodeImpl : IUKPostCode
    {
        private readonly IUKPostCodeRepository _postCodeRepository;

        public UKPostCodeImpl(IUKPostCodeRepository postCodeRepository)
        {
            _postCodeRepository = postCodeRepository;
        }

        public UKPostCode GetPostCodeInfo(string postCode)
        {
            return _postCodeRepository.GetPostCodeInfo(postCode);
        }
    }
}
