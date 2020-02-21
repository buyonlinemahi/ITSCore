using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface IUKPostCode
    {
        UKPostCode GetPostCodeInfo(string postCode);
    }
}
