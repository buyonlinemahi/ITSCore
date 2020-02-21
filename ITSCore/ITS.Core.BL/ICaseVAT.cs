using ITS.Core.Data.Model;

namespace ITS.Core.BL
{
    public interface ICaseVAT
    {
        int AddCaseVAT(CaseVAT caseVAT);

        decimal GetCaseVATByCaseID(int caseID);
    }
}