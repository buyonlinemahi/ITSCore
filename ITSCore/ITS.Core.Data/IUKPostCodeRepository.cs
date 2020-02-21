using Core.Base.Data;
using ITS.Core.Data.Model;
namespace ITS.Core.Data
{
	public interface IUKPostCodeRepository : IBaseRepository<UKPostCode>
	{
        UKPostCode GetPostCodeInfo(string postCode);
	}
}
