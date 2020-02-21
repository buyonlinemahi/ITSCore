using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
/*
 * Page Name:  CaseAssessmentTest.cs                      
 * Latest Version:  1.1
  
 * Author         : Manjit Singh   
 * Date           : April 30, 2013
 * Latest version : 1.0
 * Desvription    : test mothod to add CaseAssessment
 *
 * Modified By    : Robin Singh   
 * Date           : May 23, 2013
 * Latest version : 1.1
 * Desvription    : Added new coloumn in test mothod to add CaseAssessment
===================================================================================

*/
namespace CoreTest
{

    using ITS.Core.BL;
    using ITS.Core.BL.Implementation;
    using ITS.Core.Data;
    using ITS.Core.Data.Model;
    using ITS.Core.Data.SqlServer.Repository;

    [TestClass]
    public class CaseAssessmentTest
    {
        private ICaseAssessmentRepository repo;
        private ICaseAssessmentHistoryRepository repoHistory;
        private ICaseAssessmentPatientImpactRepository _caseAssessmentPatientImpactRepository;
        private ICaseAssessmentPatientInjuryRepository _caseAssessmentPatientInjuryRepository;
        private ICaseAssessmentRatingRepository _caseAssessmentRatingRepository;
        private ICaseAssessmentPatientInjuryHistoryRepository _caseAssessmentPatientInjuryHistoryRepository;
        private ICaseAssessmentPatientImpactHistoryRepository _caseAssessmentPatientImpactHistoryRepository;
        private ICaseAssessment service;


        private ICaseAssessmentDetailRepository _caseAssessmentDetailRepository;
        
        private ICaseAssessmentDetailHistoryRepository _caseAssessmentDetailHistoryRepository;

        private ICaseAssessmentProposedTreatmentMethodHistoryRepository _caseAssessmentProposedTreatmentMethodHistoryRepository;

        private ICaseAssessmentProposedTreatmentMethodRepository _caseAssessmentProposedTreatmentMethodRepository;

        private ICasePatientRepository _CasePatientRepository;
        private ICaseAssessmentPatientInjury _caseAssessmentPatientInjury;
        private ITS.Core.BL.IAffectedArea _affectedArea;
        private IAffectedAreaRepository _AffectedAreaRepository;
        private ITS.Core.BL.IRestrictionRange _restrictionRange;
        private IRestrictionRangeRepository _RestrictionRangeRepositor;
        private ITS.Core.BL.IStrengthTesting _strengthTesting;
        private IStrengthTestingRepository _StrengthTestingRepository;
        private ITS.Core.BL.ISymptomDescription _symptomDescription;
        private ISymptomDescriptionRepository _SymptomDescriptionRepository;
        private ICaseAssessmentPatientInjury Service;



        [TestInitialize()]
        public void CaseAssessmentInit()
        {
            repo = new CaseAssessmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            repoHistory = new CaseAssessmentHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseAssessmentPatientImpactRepository = new CaseAssessmentPatientImpactRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseAssessmentPatientInjuryRepository = new CaseAssessmentPatientInjuryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseAssessmentRatingRepository = new CaseAssessmentRatingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseAssessmentPatientInjuryHistoryRepository = new CaseAssessmentPatientInjuryHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseAssessmentPatientImpactHistoryRepository = new CaseAssessmentPatientImpactHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            _caseAssessmentDetailRepository = new CaseAssessmentDetailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseAssessmentDetailHistoryRepository = new CaseAssessmentDetailHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseAssessmentProposedTreatmentMethodHistoryRepository = new CaseAssessmentProposedTreatmentMethodHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _caseAssessmentProposedTreatmentMethodRepository = new CaseAssessmentProposedTreatmentMethodRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _CasePatientRepository = new CasePatientRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _AffectedAreaRepository = new AffectedAreaRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _affectedArea = new AffectedAreaImpl(_AffectedAreaRepository);
            _RestrictionRangeRepositor = new RestrictionRangeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _restrictionRange = new RestrictionRangeImpl(_RestrictionRangeRepositor);
            _StrengthTestingRepository = new StrengthTestingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _strengthTesting = new StrengthTestingImpl(_StrengthTestingRepository);
            _SymptomDescriptionRepository = new SymptomDescriptionRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _symptomDescription = new SymptomDescriptionImpl(_SymptomDescriptionRepository);
            _caseAssessmentPatientInjury = new CaseAssessmentPatientInjuryImpl(_caseAssessmentPatientInjuryRepository, _affectedArea, _restrictionRange, _strengthTesting, _symptomDescription);

            service = new CaseAssessmentImpl(repo, repoHistory, _caseAssessmentPatientImpactRepository, _caseAssessmentPatientInjuryRepository, _caseAssessmentRatingRepository, _caseAssessmentPatientImpactHistoryRepository, _caseAssessmentPatientInjuryHistoryRepository, _caseAssessmentDetailRepository, _CasePatientRepository, _caseAssessmentDetailHistoryRepository, _caseAssessmentProposedTreatmentMethodRepository, _caseAssessmentProposedTreatmentMethodHistoryRepository,
                _caseAssessmentPatientInjury);
        }

        [TestMethod]
        public void Add_CaseAssessment()
        {

            var casePatientImpacts = new List<ITS.Core.BL.Model.CaseAssessmentPatientImpact>(new ITS.Core.BL.Model.CaseAssessmentPatientImpact[] { new ITS.Core.BL.Model.CaseAssessmentPatientImpact { CaseAssessmentDetailID = 1593, Comment = "dasda", PatientImpactID = 1, PatientImpactValueID = 1 }, new ITS.Core.BL.Model.CaseAssessmentPatientImpact { CaseAssessmentDetailID = 1592, Comment = "dasda2", PatientImpactID = 2, PatientImpactValueID = 1 } });

            var casePatientInjuries = new List<ITS.Core.BL.Model.CaseAssessmentPatientInjury>(new ITS.Core.BL.Model.CaseAssessmentPatientInjury[] { new ITS.Core.BL.Model.CaseAssessmentPatientInjury { CaseAssessmentDetailID = 1593, Score = "8", AffectedArea = "", Restriction = "", SymptomDescriptionID = 5, AffectedAreaID = 1, StrengthTestingID = 5, RestrictionRangeID = 5, OtherSymptomDesciption = "dfsdfsdfsdfsdfsdf" } });

            var caseProposed = new List<ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod>(new ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod[] { new ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod {  CaseID = 1136, ProposedTreatmentMethodID = 6 }, 
                new ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod { CaseID = 1136, ProposedTreatmentMethodID = 5 } });

            var caseAssessmentDetail = new ITS.Core.BL.Model.CaseAssessmentDetail()
            {

                AssessmentServiceID = 1,
                CaseID = 1136,
                HasThePatientHadTimeOff = true,
                AbsentDetail = "New",
                HasThePatientReturnedToWork = true,
                PatientImpactOnWorkID = 1,
                PatientWorkstatusID = 1,
                PatientRecommendedTreatmentSessions = 1,
                PatientRecommendedTreatmentSessionsDetail = "New",
                PatientTreatmentPeriod = 1,
                IsFurtherTreatmentRecommended = null,
                PatientLevelOfRecoveryID = 1,
                SessionsPatientAttended = 1,
                DatesOfSessionAttended = "Dates",
                SessionsPatientFailedToAttend = 1,
                FollowingTreatmentPatientLevelOfRecoveryID = 1,
                AdditionalInformation = "test",
                HasCompliedHomeExerciseProgramme = true,
                AbsentPeriod=1,AbsentPeriodDurationID=1,PatientTreatmentPeriodDetail="This",PatientTreatmentPeriodDurationID=1,
                PractitionerID=157,
                EvidenceOfClinicalReasoning="asdf",
                IsFurtherInvestigationOrOnwardReferralRequired=false,
                FurtherInvestigationOrOnwardReferral="asdfsda",
                EvidenceOfTreatmentRecommendations="sadfdsaf"

            };

            var result = service.AddCaseAssessment(new ITS.Core.BL.Model.CaseAssessment
            {

                CaseID = 1136,
                AssessmentServiceID = 1,
                HasPatientConsentForm = true,
                IncidentAndDiagnosisDescription = "this",
                NeuralSymptomDescription = "This",
                PreExistingConditionDescription = "This",
                IsPatientUndergoingTreatment = true,
                IsPatientTakingMedication = true,
                PatientRequiresFurtherInvestigation = true,
                FactorsAffectingTreatmentDescription = "This",
                PatientOccupation = "This",
                PatientRoleID = 1,
                WasPatientWorkingAtTheTimeOfTheAccident = true,
                AnticipatedDateOfDischarge = DateTime.Now.AddDays(-10),
                HasPatientHomeExerciseProgramme = true,              
                AssessmentDate = DateTime.Today.AddDays(-10),
                IsPatientSufferingFinancialLoss = true,
                HasPatientPastSymptoms = true,
                AssessmentAuthorisationID = 1,
                AuthorisationDetail = "This",
                IsAccepted = true,
                IsPatientDischarge = null,
                DeniedMessage = "This",
                UserID = 463,
                HasYellowFlags = true,
                HasRedFlags = true,
                IsSaved = true,
                RelevantTestUndertaken = "sfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdfsdf",
                 CaseAssessmentProposedTreatmentMethods = caseProposed,
                CaseAssessmentPatientImpacts = casePatientImpacts,
                CaseAssessmentPatientInjuries = casePatientInjuries,
                CaseAssessmentRating = null,
                CaseAssessmentDetail = caseAssessmentDetail
            });

            Assert.IsTrue(result > 0);
        }



     

        [TestMethod]
        public void Add_CaseAssessment_FinalAssessmentIsNull()
        {
            //var result = service.AddCaseAssessment(new ITS.Core.BL.Model.CaseAssessment
            //{
            //    CaseID = 44,
            //    AssessmentServiceID = 1,
            //    HasPatientConsentForm = true,
            //    IncidentAndDiagnosisDescription = "test2",
            //    NeuralSymptomDescription = "test2",
            //    PreExistingConditionDescription = "testpre",
            //    PsychologicalFactorID = 1,
            //    IsPatientUndergoingTreatment = true,
            //    IsPatientTakingMedication = true,
            //    PatientRequiresFurtherInvestigation = true,
            //    FactorsAffectingTreatmentDescription = "test2",
            //    PatientOccupation = "testt",
            //    PatientRole = "testt",
            //    WasPatientWorkingAtTheTimeOfTheAccident = true,
            //    HasThePatientHadTimeOff = true,
            //    HasThePatientReturnedToWork = false,
            //    AbsentDetail = "testt",
            //    IsPatientSufferingFinancialLoss = true,
            //    PatientWorkstatusID = 1,
            //    PatientImpactOnWorkID = 1,
            //    PatientRecommendedTreatmentSessions = 1,
            //    PatientTreatmentPeriod = "test2",
            //    AnticipatedDateOfDischarge = DateTime.Now,
            //    PatientLevelOfRecoveryID = 1,
            //    HasPatientHomeExerciseProgramme = true,
            //    AdditionalInformation = "abcdef",
            //    AssessmentDate = DateTime.Now,
            //    FinalAssessmentDate = DateTime.Now,
            //    HasPatientPastSymptoms = true,
            //    PatientRecoveryPercentage = 1,
            //    AssessmentAuthorisationID = 3,
            //    AuthorisationDetail = "test1",
            //    IsAccepted = true,
            //    IsPatientDischarge = true,
            //    DeniedMessage = "na",
            //    UserID = 254,
            //    CaseAssessmentPatientImpacts = null,
            //    CaseAssessmentPatientInjuries = null,
            //    CaseAssessmentRating = null
            //});
            //Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void Update_CaseAssessmentAuthorisationToModifiedByCaseID()
        {
            string authorisationDetail = "text authorisationDetail";
            int caseID = 178;

            int _CaseResult = service.UpdateCaseAssessmentAuthorisationToModifiedByCaseID(caseID, authorisationDetail);

            Assert.IsTrue(_CaseResult != 0, "Error in Updating Update CaseAssessmentAuthorisationToModified By CaseID !!!");
        }

        [TestMethod]
        public void Update_CaseAssessmentAuthorisationToApprovedByCaseID()
        {
            int caseID = 12;

            int _CaseResult = service.UpdateCaseAssessmentAuthorisationToApprovedByCaseID(caseID);

            Assert.IsTrue(_CaseResult != 0, "Error in Updating Update CaseAssessmentAuthorisationToApproved By CaseID !!!");
        }


        [TestMethod]
        public void Update_CaseAssessmentAuthorisationToDeniedByCaseID()
        {
            int caseID = 111;

            int _CaseResult = service.UpdateCaseAssessmentAuthorisationToDeniedByCaseID(caseID,"Invalid");

            Assert.IsTrue(_CaseResult != 0, "Error in Updating Update CaseAssessmentAuthorisationToDenied By CaseID !!!");
        }

        [TestMethod]
        public void get_case_assessment_by_case_id()
        {
            //CaseAssessment assessment = null;
            //if (repo.GetAll().FirstOrDefault() != null)
            //{
            //    assessment = repo.GetCaseAssessmentByCaseID(repo.GetAll().FirstOrDefault().CaseID);
            //}

            ITS.Core.BL.Model.CaseAssessment caseAssessment = service.GetCaseAssessment(2299);
            caseAssessment.IsSaved = true;
            //var result = service.UpdateCaseAssessmentByCaseID(caseAssessment);

            Assert.IsTrue(caseAssessment != null && caseAssessment.CaseID != 0, "No assessment found");

        }

        [TestMethod]
        public void get_case_assessment_HasPatientConsentForm_by_case_id()
        {
            
            ITS.Core.BL.Model.CaseAssessment caseAssessment = service.GetCaseAssessment(312);
            var result = service.UpdateCaseAssessmentHasPatientConsentFormByCaseId(550, true);
            Assert.IsTrue(caseAssessment != null && caseAssessment.CaseID != 0, "No assessment found");

        }


        [TestMethod]
        public void get_caseAssessment()
        {
            ITS.Core.BL.Model.CaseAssessment assessment = null;
            if (repo.GetAll().FirstOrDefault() != null)
            {
                assessment = service.GetCaseAssessment(repo.GetAll().FirstOrDefault().CaseID);

            }
            Assert.IsTrue(assessment != null && assessment.CaseID != 0, "No assessment found");
        }

        [TestMethod]
        public void Get_CaseAssessmentExistByCaseID()
        {
            Assert.IsTrue(repo.GetCaseAssessmentExistsByCaseID(2541), "No CaseAssessment Exists");
        }

        [TestMethod]
        public void get_caseAssessment_getNull()
        {
            var assessment = service.GetCaseAssessment(1041);
            Assert.IsNull(assessment);
        }

        [TestMethod]
        public void Update_CaseAssessment()
        {
            //var casePatientImpacts = new List<ITS.Core.BL.Model.CaseAssessmentPatientImpact>(new ITS.Core.BL.Model.CaseAssessmentPatientImpact[] { new ITS.Core.BL.Model.CaseAssessmentPatientImpact { CaseAssessmentDetailID = 435, Comment = "dasda", PatientImpactID = 1, PatientImpactValueID = 1 }, new ITS.Core.BL.Model.CaseAssessmentPatientImpact { CaseAssessmentDetailID = 435, Comment = "dasda2", PatientImpactID = 2, PatientImpactValueID = 1 } });
           // var casePatientInjuries = new List<ITS.Core.BL.Model.CaseAssessmentPatientInjury>(new ITS.Core.BL.Model.CaseAssessmentPatientInjury[] { new ITS.Core.BL.Model.CaseAssessmentPatientInjury { CaseAssessmentDetailID = 435, Score = 1, AffectedArea = "dasd", Restriction = "50" }, new ITS.Core.BL.Model.CaseAssessmentPatientInjury { CaseAssessmentDetailID = 435, Score = 1, AffectedArea = "dasd3231", Restriction = "50" } });
            var assess = service.GetCaseAssessment(306);
            assess.CaseAssessmentPatientInjuries.Add(new ITS.Core.BL.Model.CaseAssessmentPatientInjury { CaseAssessmentDetailID = 435, Score = "1", AffectedArea = "dasd", Restriction = "50" });
            var caseProposed = new List<ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod>(new ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod[] { new ITS.Core.BL.Model.CaseAssessmentProposedTreatmentMethod {  CaseID = 306, ProposedTreatmentMethodID = 4 }});
            assess.CaseAssessmentProposedTreatmentMethods = caseProposed;
            service.UpdateCaseAssessmentByCaseID(assess);

            //var result = service.UpdateCaseAssessmentByCaseID(new ITS.Core.BL.Model.CaseAssessment
            //{
            //    CaseID = 106,
            //    AssessmentServiceID = 1,
            //    HasPatientConsentForm = true,
            //    IncidentAndDiagnosisDescription = "test2dd",
            //    NeuralSymptomDescription = "testdd2",
            //    PreExistingConditionDescription = "testpredd",
            //    IsPatientUndergoingTreatment = true,
            //    IsPatientTakingMedication = true,
            //    PatientRequiresFurtherInvestigation = true,
            //    FactorsAffectingTreatmentDescription = "test2dd",
            //    PatientOccupation = "testtdd",
            //    PatientRoleID = 1,
            //    WasPatientWorkingAtTheTimeOfTheAccident = false,

            //    IsPatientSufferingFinancialLoss = true,

            //    AnticipatedDateOfDischarge = DateTime.Now,

            //    HasPatientHomeExerciseProgramme = true,
          //    AssessmentDate = DateTime.Now,

            //    HasPatientPastSymptoms = true,

            //    AssessmentAuthorisationID = 3,
            //    AuthorisationDetail = "test1dddd",
            //    IsAccepted = true,
            //    IsPatientDischarge = true,
            //    DeniedMessage = "nadd",
            //    UserID = 254,
            //    HasYellowFlags = false,
            //    HasRedFlags = false,
            //    CaseAssessmentPatientImpacts = casePatientImpacts,
            //    CaseAssessmentPatientInjuries = casePatientInjuries,
            //    CaseAssessmentRating = null
            //});

          //  Assert.IsTrue(result > 0);
        }


                
        [TestMethod]
        public void UpdateAssessmentServiceIDByCaseID()
        {
            var result = repo.UpdateAssessmentServiceIDByCaseID(209, 3);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void UpdateIsPatientDischargeByCaseID()
        {
            var result = repo.UpdateIsPatientDischargeByCaseID(120, false);
            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void _GetAllDataReportGenerated()
        {
            var result = service.GetAllDataReportGenerated(288,"QA",500,1);
            Assert.IsTrue(result != null,"Data Not Found");
        }

        [TestMethod]
        public void AddReferrerCaseAssessmentModification()
        {
            ReferrerCaseAssessmentModification referrerCaseAssessmentModification = new ReferrerCaseAssessmentModification();
            referrerCaseAssessmentModification.CaseID = 178;
            referrerCaseAssessmentModification.TreatmentSession = 1;
            referrerCaseAssessmentModification.AssessmentServiceID = 3;

            int _CaseResult = service.AddReferrerCaseAssessmentModification(referrerCaseAssessmentModification);
            Assert.IsTrue(_CaseResult != 0, "Error!!!");
        }
        
        [TestMethod]
        public void GetCaseTreatmentPricingByCaseID()
        {
            IEnumerable<ReferrerCaseAssessmentModificationAuthority> objdata = service.GetCaseTreatmentPricingByCaseID(1046);
            Assert.IsTrue(objdata.Any());          
        }

        [TestMethod]
        public void GetReferrerCaseAssessmentModificationsbyCaseID()
        {
            IEnumerable<ReferrerCaseAssessmentModification> objdata = service.GetReferrerCaseAssessmentModificationsbyCaseID(1013);
            Assert.IsTrue(objdata.Any());
        }
    }



}
