using ITS.Core.Data.Model;
using System.Collections.Generic;
using System.Linq;
using BLModel = ITS.Core.BL.Model;
namespace ITS.Core.BL.Implementation.ExtensionMethods
{
    public static class CaseAssessmentExtension
    {
        public static ITS.Core.BL.Model.CaseAssessment ToCaseAsssessmentBL(this CaseAssessment value, IEnumerable<CaseAssessmentPatientImpact> impacts, IEnumerable<BLModel.CaseAssessmentPatientInjuryBL> injuries, CaseAssessmentRating rating, CaseAssessmentDetail caseAssessmentDetail, IEnumerable<CaseAssessmentProposedTreatmentMethod> caseAssessmentProposedTreatmentMethods)
        {

            ITS.Core.BL.Model.CaseAssessmentRating ratingBL = rating != null ? new ITS.Core.BL.Model.CaseAssessmentRating { AssessmentServiceID = rating.AssessmentServiceID, CaseAssessmentRatingID = rating.CaseAssessmentRatingID, CaseID = rating.CaseID, Rating = rating.Rating, RatingDate = rating.RatingDate } : null;

                     IList<ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod> caseAssessmentProposedTreatmentMethodsBL = caseAssessmentProposedTreatmentMethods != null ? caseAssessmentProposedTreatmentMethods.Select(caseAssessmentProposedTreatmentMethod =>
                new ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod {  CaseID = caseAssessmentProposedTreatmentMethod.CaseID,  ProposedTreatmentMethodID = caseAssessmentProposedTreatmentMethod.ProposedTreatmentMethodID }
                ).ToList() : null;
            

            ITS.Core.BL.Model.CaseAssessmentDetail caseAssessmentDetailBL = caseAssessmentDetail != null ? new ITS.Core.BL.Model.CaseAssessmentDetail
            {
                CaseAssessmentDetailID = caseAssessmentDetail.CaseAssessmentDetailID,
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
                PatientTreatmentPeriodDetail = caseAssessmentDetail.PatientTreatmentPeriodDetail,
                AssessmentDate = caseAssessmentDetail.AssessmentDate,
                PractitionerID=caseAssessmentDetail.PractitionerID,
                EvidenceOfClinicalReasoning=caseAssessmentDetail.EvidenceOfClinicalReasoning,
                IsFurtherInvestigationOrOnwardReferralRequired = caseAssessmentDetail.IsFurtherInvestigationOrOnwardReferralRequired,
                FurtherInvestigationOrOnwardReferral = caseAssessmentDetail.FurtherInvestigationOrOnwardReferral,
                EvidenceOfTreatmentRecommendations = caseAssessmentDetail.EvidenceOfTreatmentRecommendations,
                TreatmentPeriodTypeID = caseAssessmentDetail.TreatmentPeriodTypeID,
                PatientDateOfReturn = caseAssessmentDetail.PatientDateOfReturn,
                PatientRecommendationReturn = caseAssessmentDetail.PatientRecommendationReturn,
                IsPatientReturnToPreInjuryDuties = caseAssessmentDetail.IsPatientReturnToPreInjuryDuties,
                PatientPreInjuryDutiesDate = caseAssessmentDetail.PatientPreInjuryDutiesDate,
                MainFactors = caseAssessmentDetail.MainFactors
            } : null;


            IList<ITS.Core.BL.Model.CaseAssessmentPatientInjuryBL> injuriesBL = injuries != null ? injuries.Select(injury =>
                new ITS.Core.BL.Model.CaseAssessmentPatientInjuryBL { AffectedArea = injury.AffectedArea, CaseAssessmentPatientInjuryID = injury.CaseAssessmentPatientInjuryID, CaseAssessmentDetailID = injury.CaseAssessmentDetailID, Score = injury.Score, Restriction = injury.Restriction, AffectedAreaID = injury.AffectedAreaID,
                RestrictionRangeID = injury.RestrictionRangeID, StrengthTestingID = injury.StrengthTestingID, SymptomDescriptionID = injury.SymptomDescriptionID,AffectedAreaDescription = injury.AffectedAreaDescription,RestrictionRangeDescription = injury.RestrictionRangeDescription,
                StrengthTestingDescription = injury.StrengthTestingDescription, SymptomDescriptionName = injury.SymptomDescriptionName, OtherSymptomDesciption = injury.OtherSymptomDesciption}
              ).ToList() : null;

            IList<ITS.Core.BL.Model.CaseAssessmentPatientImpact> impactsBL = impacts != null ? impacts.Select(impact =>
                new ITS.Core.BL.Model.CaseAssessmentPatientImpact { CaseAssessmentPatientImpactID = impact.CaseAssessmentPatientImpactID, CaseAssessmentDetailID = impact.CaseAssessmentDetailID, Comment = impact.Comment, PatientImpactID = impact.PatientImpactID, PatientImpactValueID = impact.PatientImpactValueID }
                ).ToList() : null;

            return new ITS.Core.BL.Model.CaseAssessment
            {

                CaseID = value.CaseID,
                AssessmentServiceID = value.AssessmentServiceID,
                HasPatientConsentForm = value.HasPatientConsentForm,
                IncidentAndDiagnosisDescription = value.IncidentAndDiagnosisDescription,
                NeuralSymptomDescription = value.NeuralSymptomDescription,
                PreExistingConditionDescription = value.PreExistingConditionDescription,
                IsPatientUndergoingTreatment = value.IsPatientUndergoingTreatment,
                IsPatientTakingMedication = value.IsPatientTakingMedication,
                PatientRequiresFurtherInvestigation = value.PatientRequiresFurtherInvestigation,
                FactorsAffectingTreatmentDescription = value.FactorsAffectingTreatmentDescription,
                PatientOccupation = value.PatientOccupation,
                PatientRoleID = value.PatientRoleID,
                WasPatientWorkingAtTheTimeOfTheAccident = value.WasPatientWorkingAtTheTimeOfTheAccident,
                AnticipatedDateOfDischarge = value.AnticipatedDateOfDischarge,
                HasPatientHomeExerciseProgramme = value.HasPatientHomeExerciseProgramme,              
                CaseAssessmentProposedTreatmentMethods = caseAssessmentProposedTreatmentMethodsBL,
                IsPatientSufferingFinancialLoss = value.IsPatientSufferingFinancialLoss,
                HasPatientPastSymptoms = value.HasPatientPastSymptoms,
                AssessmentAuthorisationID = value.AssessmentAuthorisationID,
                AuthorisationDetail = value.AuthorisationDetail,
                IsAccepted = value.IsAccepted,
                IsPatientDischarge = value.IsPatientDischarge,
                DeniedMessage = value.DeniedMessage,
                UserID = value.UserID,
                HasYellowFlags = value.HasYellowFlags,
                HasRedFlags = value.HasRedFlags,
                IsSaved = value.IsSaved,
                RelevantTestUndertaken = value.RelevantTestUndertaken,
                CaseAssessmentPatientImpacts = impactsBL,
                CaseAssessmentPatientInjuriesBL = injuriesBL,
                CaseAssessmentDetail = caseAssessmentDetailBL,
                CaseAssessmentRating = ratingBL

            };
        }

        public static CaseAssessment ToCaseAsssessmentDL(this ITS.Core.BL.Model.CaseAssessment value)
        {
            return new CaseAssessment
            {
                CaseID = value.CaseID,
                AssessmentServiceID = value.AssessmentServiceID,
                HasPatientConsentForm = value.HasPatientConsentForm,
                IncidentAndDiagnosisDescription = value.IncidentAndDiagnosisDescription,
                NeuralSymptomDescription = value.NeuralSymptomDescription,
                PreExistingConditionDescription = value.PreExistingConditionDescription,
                IsPatientUndergoingTreatment = value.IsPatientUndergoingTreatment,
                IsPatientTakingMedication = value.IsPatientTakingMedication,
                PatientRequiresFurtherInvestigation = value.PatientRequiresFurtherInvestigation,
                FactorsAffectingTreatmentDescription = value.FactorsAffectingTreatmentDescription,
                PatientOccupation = value.PatientOccupation,
                PatientRoleID = value.PatientRoleID,
                WasPatientWorkingAtTheTimeOfTheAccident = value.WasPatientWorkingAtTheTimeOfTheAccident,
                AnticipatedDateOfDischarge = value.AnticipatedDateOfDischarge,
                HasPatientHomeExerciseProgramme = value.HasPatientHomeExerciseProgramme,                
                IsPatientSufferingFinancialLoss = value.IsPatientSufferingFinancialLoss,
                HasPatientPastSymptoms = value.HasPatientPastSymptoms,
                AssessmentAuthorisationID = value.AssessmentAuthorisationID,
                AuthorisationDetail = value.AuthorisationDetail,
                IsAccepted = value.IsAccepted,
                IsPatientDischarge = value.IsPatientDischarge,
                DeniedMessage = value.DeniedMessage,
                UserID = value.UserID,
                HasYellowFlags = value.HasYellowFlags,
                HasRedFlags = value.HasRedFlags,
                IsSaved = value.IsSaved,
                RelevantTestUndertaken = value.RelevantTestUndertaken
            };
        }





        //public static CaseAssessmentPatientImpact ToCaseAssessmentPatientImpactDL(this ITS.Core.BL.Model.CaseAssessment value)
        //{
        //    return new CaseAssessmentPatientImpact
        //    {

        //        CaseAssessmentPatientImpactID = value.CaseAssessmentPatientImpacts.SingleOrDefault().CaseAssessmentPatientImpactID,
        //        CaseID = value.CaseAssessmentPatientImpacts.SingleOrDefault().CaseID,
        //        PatientImpactID = value.CaseAssessmentPatientImpacts.SingleOrDefault().PatientImpactID,
        //        PatientImpactValueID = value.CaseAssessmentPatientImpacts.SingleOrDefault().PatientImpactValueID,
        //        Comment = value.CaseAssessmentPatientImpacts.SingleOrDefault().Comment



        //    };
        //}

        //public static CaseAssessmentPatientImpactHistory ToCaseAssessmentPatientImpactHistoryDL(this ITS.Core.BL.Model.CaseAssessment value)
        //{
        //    return new CaseAssessmentPatientImpactHistory
        //    {
        //        //CaseAssessmentPatientImpactHistoryID  
        //        // PatientImpactID = value.CaseAssessmentPatientImpacts.SingleOrDefault().PatientImpactID,
        //        //PatientImpactValueID = value.CaseAssessmentPatientImpacts.SingleOrDefault().PatientImpactValueID,                                
        //        //CaseAssessmentHistoryID  
        //    };
        //}
    }
}
