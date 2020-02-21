using ITS.Core.Data;
using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation
{
    public class CaseVATImpl : ICaseVAT
    {
        private readonly ICaseVATRepository _caseVAT;

        public CaseVATImpl(ICaseVATRepository caseVAT)
        {
            _caseVAT = caseVAT;
        }

        public int AddCaseVAT(CaseVAT caseVAT)
        {
            return _caseVAT.AddCaseVAT(caseVAT);
        }

        public decimal GetCaseVATByCaseID(int caseID)
        {
            var result = _caseVAT.GetCaseVATByCaseID(caseID);

            if (result != null)
            {
                return result.VAT;
            }
            return 0;

        }
    }
}