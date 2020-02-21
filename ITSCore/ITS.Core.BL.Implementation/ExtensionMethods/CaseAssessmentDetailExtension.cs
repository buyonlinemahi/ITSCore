using ITS.Core.Data.Model;

namespace ITS.Core.BL.Implementation.ExtensionMethods
{
    public static class CaseAssessmentDetailExtension
    {

        public static CaseAssessmentDetail ToCaseAssessmentDetailDL(this ITS.Core.BL.Model.CaseAssessmentDetail caseAssessmentDetail)
        {
            CaseAssessmentDetail caseAssessmentDetailDL = caseAssessmentDetail != null ? new CaseAssessmentDetail
            {

                AssessmentServiceID = caseAssessmentDetail.AssessmentServiceID,
                CaseID = caseAssessmentDetail.CaseID,
                HasThePatientHadTimeOff = caseAssessmentDetail.HasThePatientHadTimeOff,
                AbsentDetail = caseAssessmentDetail.AbsentDetail,
                AbsentPeriod = caseAssessmentDetail.AbsentPeriod,
                AbsentPeriodDurationID = caseAssessmentDetail.AbsentPeriodDurationID,
                HasThePatientReturnedToWork = caseAssessmentDetail.HasThePatientReturnedToWork,
                PatientImpactOnWorkID = caseAssessmentDetail.PatientImpactOnWorkID,
                PatientWorkstatusID = caseAssessmentDetail.PatientWorkstatusID,
                PatientRecommendedTreatmentSessions = caseAssessmentDetail.PatientRecommendedTreatmentSessions,
                PatientRecommendedTreatmentSessionsDetail = caseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail,
                PatientTreatmentPeriod = caseAssessmentDetail.PatientTreatmentPeriod,
                PatientTreatmentPeriodDurationID = caseAssessmentDetail.PatientTreatmentPeriodDurationID,
                IsFurtherTreatmentRecommended = caseAssessmentDetail.IsFurtherTreatmentRecommended,
                PatientLevelOfRecoveryID = caseAssessmentDetail.PatientLevelOfRecoveryID,
                SessionsPatientAttended = caseAssessmentDetail.SessionsPatientAttended,
                DatesOfSessionAttended = caseAssessmentDetail.DatesOfSessionAttended,
                SessionsPatientFailedToAttend = caseAssessmentDetail.SessionsPatientFailedToAttend,
                FollowingTreatmentPatientLevelOfRecoveryID = caseAssessmentDetail.FollowingTreatmentPatientLevelOfRecoveryID,
                AdditionalInformation = caseAssessmentDetail.AdditionalInformation,
                HasCompliedHomeExerciseProgramme = caseAssessmentDetail.HasCompliedHomeExerciseProgramme,
                CaseAssessmentDetailID = caseAssessmentDetail.CaseAssessmentDetailID,
                PatientTreatmentPeriodDetail = caseAssessmentDetail.PatientTreatmentPeriodDetail,
                AssessmentDate = caseAssessmentDetail.AssessmentDate,
                PractitionerID = caseAssessmentDetail.PractitionerID,
                EvidenceOfClinicalReasoning = caseAssessmentDetail.EvidenceOfClinicalReasoning,
                IsFurtherInvestigationOrOnwardReferralRequired = caseAssessmentDetail.IsFurtherInvestigationOrOnwardReferralRequired,
                FurtherInvestigationOrOnwardReferral = caseAssessmentDetail.FurtherInvestigationOrOnwardReferral,
                EvidenceOfTreatmentRecommendations = caseAssessmentDetail.EvidenceOfTreatmentRecommendations,
                TreatmentPeriodTypeID = caseAssessmentDetail.TreatmentPeriodTypeID,
                PatientDateOfReturn = caseAssessmentDetail.PatientDateOfReturn,
                PatientRecommendationReturn = caseAssessmentDetail.PatientRecommendationReturn,
                IsPatientReturnToPreInjuryDuties = caseAssessmentDetail.IsPatientReturnToPreInjuryDuties,
                PatientPreInjuryDutiesDate = caseAssessmentDetail.PatientPreInjuryDutiesDate,
                MainFactors = caseAssessmentDetail.MainFactors
            }
: null;
            return caseAssessmentDetailDL;
        }

        public static CaseAssessmentDetailHistory ToCaseAssessmentDetaiHistorylDL(this ITS.Core.BL.Model.CaseAssessmentDetail caseAssessmentDetail)
        {
            CaseAssessmentDetailHistory caseAssessmentDetailHistoryDL = caseAssessmentDetail != null ? new CaseAssessmentDetailHistory
            {
                AssessmentServiceID = caseAssessmentDetail.AssessmentServiceID,
                CaseID = caseAssessmentDetail.CaseID,
                HasThePatientHadTimeOff = caseAssessmentDetail.HasThePatientHadTimeOff,
                AbsentDetail = caseAssessmentDetail.AbsentDetail,
                AbsentPeriod = caseAssessmentDetail.AbsentPeriod,
                AbsentPeriodDurationID = caseAssessmentDetail.AbsentPeriodDurationID,
                HasThePatientReturnedToWork = caseAssessmentDetail.HasThePatientReturnedToWork,
                PatientImpactOnWorkID = caseAssessmentDetail.PatientImpactOnWorkID,
                PatientWorkstatusID = caseAssessmentDetail.PatientWorkstatusID,
                PatientRecommendedTreatmentSessions = caseAssessmentDetail.PatientRecommendedTreatmentSessions,
                PatientRecommendedTreatmentSessionsDetail = caseAssessmentDetail.PatientRecommendedTreatmentSessionsDetail,
                PatientTreatmentPeriod = caseAssessmentDetail.PatientTreatmentPeriod,
                PatientTreatmentPeriodDurationID = caseAssessmentDetail.PatientTreatmentPeriodDurationID,
                IsFurtherTreatmentRecommended = caseAssessmentDetail.IsFurtherTreatmentRecommended,
                PatientLevelOfRecoveryID = caseAssessmentDetail.PatientLevelOfRecoveryID,
                SessionsPatientAttended = caseAssessmentDetail.SessionsPatientAttended,
                DatesOfSessionAttended = caseAssessmentDetail.DatesOfSessionAttended,
                SessionsPatientFailedToAttend = caseAssessmentDetail.SessionsPatientFailedToAttend,
                FollowingTreatmentPatientLevelOfRecoveryID = caseAssessmentDetail.FollowingTreatmentPatientLevelOfRecoveryID,
                AdditionalInformation = caseAssessmentDetail.AdditionalInformation,
                HasCompliedHomeExerciseProgramme = caseAssessmentDetail.HasCompliedHomeExerciseProgramme,
                CaseAssessmentDetailID = caseAssessmentDetail.CaseAssessmentDetailID,
                PatientTreatmentPeriodDetail = caseAssessmentDetail.PatientTreatmentPeriodDetail,
                AssessmentDate = caseAssessmentDetail.AssessmentDate,
                PractitionerID=caseAssessmentDetail.PractitionerID

            }
: null;
            return caseAssessmentDetailHistoryDL;
        }
    }


}
