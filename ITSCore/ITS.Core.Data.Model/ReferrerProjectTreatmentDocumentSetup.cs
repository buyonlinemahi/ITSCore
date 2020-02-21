namespace ITS.Core.Data.Model
{

    /// <summary>
    /// 
    /// </summary>
    public class ReferrerProjectTreatmentDocumentSetup
    {
        public int ReferrerProjectTreatmentDocumentSetupID { get; set; }
        public int AssessmentServiceID { get; set; }
        public int DocumentSetupTypeID { get; set; }
        public int ReferrerProjectTreatmentID { get; set; }
        public string AssessmentServiceName { get; set; }
        public string DocumentSetupTypeName { get; set; }
        public string UploadedFileName { get; set; }

    }
}
