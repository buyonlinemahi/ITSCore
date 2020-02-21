using ITS.Core.Data.Model;
namespace ITS.Core.BL.Implementation.Base
{
    public abstract class Workflow
    {
        internal Case CurrentCase { get; set; }
        internal CaseAssessment CaseAssessment { get; set; }
        internal int UserID { get; set; }
        public abstract CaseHistory History { get; }
        public abstract int Run();
    }
}
