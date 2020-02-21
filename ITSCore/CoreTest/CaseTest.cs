using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.BL.Implementation.Global;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

#region Comment
/*
 Page Name:  ICaseRepository.cs                      
 Latest Version:  1.0
 Author : Satya, Robin Singh
 
*/
#endregion


namespace CoreTest
{


    [TestClass]
    public class CaseTest
    {

        ICaseRepository _caseRepository;
        IEmployeeDetailRepository _employeRepository;
        IDrugTestRepository _drugTestRepository;
        IJobDemandRepository _jobDemandRepository;
        ICase caseService;
        IEmployeeDetail _emp;
        

        public CaseTest()
        {
        }

        [TestInitialize()]
        public void CaseInit()
        {
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();
            _caseRepository = new CaseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _employeRepository = new EmployeeDetailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _emp = new EmployeeDetailImpl(_employeRepository);

            _employeRepository = new EmployeeDetailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            _emp = new EmployeeDetailImpl(_employeRepository);

            caseService = new CaseImpl(_caseRepository,
                new PatientRepository(baseContextFactory),
                new ReferrerProjectTreatmentAuthorisationRepository(baseContextFactory),
                new SolicitorRepository(baseContextFactory),
                new CaseHistoryRepository(baseContextFactory),
                new CaseTreatmentPricingRepository(baseContextFactory),
                new CaseAppointmentDateRepository(baseContextFactory),
                new CasePatientContactAttemptRepository(baseContextFactory),
                new CaseAssessmentRepository(baseContextFactory),
                new InjuredPartyRepresentativeRepository(baseContextFactory),
                new PolicieRepository(baseContextFactory),
                new EmploymentRepository(baseContextFactory),
                _emp,
                new DrugTestImpl(_drugTestRepository),
                new JobDemandImpl(_jobDemandRepository),
                new PolicyOpenDetailRepository(baseContextFactory),
                new GipRepository(baseContextFactory),
                new ElRehabRepository(baseContextFactory),
                new TpdRepository(baseContextFactory),
                 new IipRepository(baseContextFactory)
                );   
        }

        [TestMethod]
        public void GetDrugTestByCaseID()
        {
            var res = caseService.GetDrugTestByCaseID(51);
            Assert.IsTrue(res != null, "Error ");
        }

        [TestMethod]
        public void GetPolicyOpenDetailID()
        {
            var res = caseService.GetPolicyOpenDetailByID(22);
            Assert.IsTrue(res != null, "Error");
        }


        [TestMethod]
        public void UpdateCaseIsTreatmentRequired_Test()
        {
            //  ICase caseService = new CaseImpl(_caseRepository);
            var r = caseService.UpdateCaseIsTreatmentRequired(4629, false);
            Assert.IsTrue(caseService.UpdateCaseIsTreatmentRequired(4567, false) != 0, "Error in updating the CaseIsTreatmentRequiredTest");
        }

        [TestMethod]
        public void GetReferrerAndSupplierPricing()
        {
            var resultCount = caseService.GetReferrerAndSupplierPricing(163).Count();
            Assert.IsTrue(resultCount != 0, "Error in updating the GetReferrerAndSupplierPricing");
        }

        [TestMethod]
        public void Add_Case()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            Case _CaseObj = new Case();
            _CaseObj.PatientID = 314;
            _CaseObj.ReferrerID = 474;
            _CaseObj.ReferrerProjectTreatmentID = 9906;
            _CaseObj.TreatmentTypeID = 1;
            _CaseObj.CaseReferrerReferenceNumber = "Test case";
            _CaseObj.CaseSpecialInstruction = "Test Case";
            _CaseObj.CaseReferrerDueDate = DateTime.Now;
            _CaseObj.IsTriage = true;
            _CaseObj.WorkflowID = GlobalConst.WorkFlow.ReferralSubmitted;
            _CaseObj.InjuryType = "Leg";
            _CaseObj.ReferrerAssignedUser = 498;
            _CaseObj.SupplierAssignedUser = 12;
            _CaseObj.InnovateNote = null;
            _CaseObj.SendInvoiceTo = "sdfsdf";
            _CaseObj.SendInvoiceName = "test";
            _CaseObj.SendInvoiceEmail = "t@t.com";
            _CaseObj.OfficeLocationID = 1;
            _CaseObj.EmployeeDetailID = 2;
            _CaseObj.IsNewPolicyTypeID = 1;
            _CaseObj.NewPolicyReferenceNumber = "abcrdjkjh";
  

            int _CaseResult = caseService.AddCase(_CaseObj);
            Assert.IsTrue(_CaseResult != 0, "Error in inserting _Case !!!");
        }

        [TestMethod]
        public void UpdateCaseWorkflowByCaseID()
        {
            ICase caseService = new CaseImpl(_caseRepository);

            int workflowID = GlobalConst.WorkFlow.ReferredtoSupplier;
            int caseID = 9;

            int _CaseResult = caseService.UpdateCaseWorkflowByCaseID(caseID, workflowID);

            Assert.IsTrue(_CaseResult != 0, "Error in Updating _Case !!!");
        }

        [TestMethod]
        public void GetReferrerProjectTreatmentDocumentSetup()
        {
            ICase caseService = new CaseImpl(_caseRepository);

            int AssessmentServiceID = GlobalConst.AssessmentService.InitialAssessment;
            int caseID = 616;

            int _CaseResult = caseService.GetReferrerProjectTreatmentDocumentSetup(caseID, AssessmentServiceID);

            Assert.IsTrue(_CaseResult != 0, "Error in Updating _Case !!!");
        }

        [TestMethod]
        public void GetCaseAssessmentCustomsByCaseID()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            int caseID = 616;
            int _CaseAssessmentResult = caseService.GetCaseAssessmentCustomsByCaseID(caseID);
            Assert.IsTrue(_CaseAssessmentResult != 0, "Error in Updating _Case !!!");
        }

        [TestMethod]
        public void GetIntialAssessmentReportDetailsByCaseID()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            int caseID = 616;
            IntialAssessmentReportDetail _CaseIntialResult = caseService.GetIntialAssessmentReportDetailsByCaseID(caseID);
            Assert.IsTrue(_CaseIntialResult != null, "Error while getting record!!!");
        }

        [TestMethod]
        public void GetInitialReviewAssessmentByCaseID()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            int caseID = 616;
            IntialAssessmentReportDetail _CaseIntialResult = caseService.GetInitialReviewAssessmentByCaseID(caseID);
            Assert.IsTrue(_CaseIntialResult != null, "Error while getting record!!!");
        }
        [TestMethod]
        public void GetEvaluateDelegatedAuthorisationCost()
        {
            var _r = caseService.GetEvaluateDelegatedAuthorisationCost(1027, 1);
            Assert.IsTrue(_r != null, "Error while getting record!!!");
        }

        [TestMethod]
        public void UpdateCaseWorkflowCustomByCaseID()
        {
            ICase caseService = new CaseImpl(_caseRepository);

            int workflowID = GlobalConst.WorkFlow.InitialAssessmentSupplierCustom;
            int caseID = 4502;
            int userID = 497;
            bool _CaseResult = caseService.UpdateCaseWorkflowCustomByCaseID(caseID, userID, workflowID);

            Assert.IsTrue(_CaseResult == false, "Error in Updating _Case !!!");
        }


        [TestMethod]
        public void UpdateCaseWorkFlow()
        {
            int userID = 497;
            int caseID = 4374;

            bool _CaseResult = caseService.UpdateCaseWorkFlow(caseID, userID);

            Assert.IsTrue(_CaseResult == false, "Error in Updating _Case !!!");
        }

        [TestMethod]
        public void Update_CaseByCaseID()
        {
            //ICase caseService = new CaseImpl(_caseRepository);
            //Case _CaseObj = new Case();
            //_CaseObj.PatientID = 2;
            //_CaseObj.ReferrerID = 5;
            //_CaseObj.CaseNumber = Guid.NewGuid();
            //_CaseObj.CaseDateOfInquiry = DateTime.Now;
            //_CaseObj.ReferrerProjectTreatmentID = 1;
            //_CaseObj.TreatmentTypeID = 1;
            //_CaseObj.CaseReferrerReferenceNumber = "123456";
            //_CaseObj.CaseSpecialInstruction = "updated case instruction";
            //_CaseObj.CaseReferrerDueDate = DateTime.Now;
            //_CaseObj.WorkflowID = 1;
            //_CaseObj.SupplierID = 240;

            //int _CaseResult = caseService.UpdateCaseByCaseID(_CaseObj);

            //Assert.IsTrue(_CaseResult != 0, "Error in Updating _Case !!!");

        }

        [TestMethod]
        public void GetCaseByCaseID()
        {
            ICase caseService = new CaseImpl(_caseRepository);

            Case _CaseResult = caseService.GetCaseByCaseID(1003);

            Assert.IsTrue(_CaseResult != null, "Error in Get _Case_ByCaseID !!!"); ;
        }

        [TestMethod]
        public void GetCaseByCaseNumber()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            IEnumerable<Case> _CaseResult = caseService.GetCaseByLikeCaseNumber("4");
            Assert.IsTrue(_CaseResult.Any());
        }

        [TestMethod]

        public void Delete_CaseByCaseID()
        {
            ICase caseService = new CaseImpl(_caseRepository);

            int _CaseResult = caseService.DeleteCaseByCaseID(3);

            Assert.IsTrue(_CaseResult != 0, "Error in Deleting _Case !!!");

        }

        [TestMethod]
        public void GetReferrerCasesByWorkflowID()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            IEnumerable<Case> _CaseResult = caseService.GetReferrerCasesByWorkflowID(GlobalConst.WorkFlow.AuthorisationSenttoInnovate, 3);
            Assert.IsTrue(_CaseResult.Any());
        }

        [TestMethod]
        public void GetCasesByWorkFlowID()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            IEnumerable<Case> _CaseResult = caseService.GetCasesByWorkFlowID(GlobalConst.WorkFlow.AuthorisationSenttoInnovate);
            Assert.IsTrue(_CaseResult.Any());
        }

        [TestMethod]
        public void GetCasesByWorkflowIDAndTreatmentCategoryID()
        {
            //ICase caseService = new CaseImpl(_caseRepository);
            //IEnumerable<CaseWorkflowPatientReferrerProject> _CaseResult = caseService.GetCaseWorkflowPatientReferrerProjectByWorkflowIDAndTreatmentCategoryID(10, 4);
            //Assert.IsTrue(_CaseResult.Any());
        }


        [TestMethod]
        public void AddNewReferral_Test()
        {
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();

            const int userID = 16;

            var @case = new Case()
            {
                //CaseNumber = Guid.NewGuid(),
                ReferrerProjectTreatmentID = 8361,
                TreatmentTypeID = 4,
                CaseReferrerReferenceNumber = "1234",
                CaseSpecialInstruction = null,
                CaseReferrerDueDate = DateTime.UtcNow,
                CaseSubmittedDate = DateTime.UtcNow,
                SupplierID = 1, //????
                ReferrerID = 3,
                SendInvoiceEmail = "r@r.com",
                SendInvoiceName = "sdfsd",
                SendInvoiceTo = "j@J.com",
                ReferrerAssignedUser = 467,
                SupplierAssignedUser = 450,
                InnovateNote = "sdfsdfssdfsd"
            };

            var patient = new Patient()
            {
                Title = "MR.",
                FirstName = "rAJESH",
                LastName = "Lastname Test",
                Address = "my address",
                City = "my city",
                Region = "my region",
                PostCode = "11234",
                InjuryDate = DateTime.UtcNow,
                HasLegalRep = true,
                GenderID = 1,
                HasInjuredPartyRepresentative = 3,
                SpecialInstructionNotes = ""
            };

            var solicitor = new Solicitor()
            {
                CompanyName = "Company Test4",
                Address = "address test",
                Phone = "12345",
                Email = "test@test.com",
                Fax = "123456",
                FirstName = "firstname test",
                LastName = "lastname test",
                PostCode = "11234",
                ReferenceNumber = "12345",
                City = "city test",
                Region = "R test",
                IsReferralUnderJointInstruction = true


            };
            var injuredPartyRepresentative = new InjuredPartyRepresentative()
            {
                Address = "Address 1",
                Email = "r@r.com",
                FirstName = "Rohit",
                LastName = "Kumar",
                ReferralID = 566,
                Tel1 = "9999999999",
                Tel2 = "9879879875",
                PostCode = "1114444"
            };

            var objpolicies = new Policie()
            {  
                PolicyCriteriaId = 4,
                PolicyTypeId =4,
                TypeCoverId = 4,
                RehabProportionateBenefit = true,
                AdmittedId=4,
                FitForWorkId =4,
                ReInsuredId = true,
                BenefitDate = DateTime.UtcNow,
                MonthlyValue = 4,
                EndBenefitDate = DateTime.UtcNow,
                NameOfReinsurerID = 3,
                ReferenceNo = "test",
                PolicyWording = "This is to state that what  it int o"
            };
           
            var objEmployment = new Employment()
            {

                EmploymentTypeId = 1,
                CompanyName = "dfgdfg",
                JobRole = "dfgdfg",
                Address = "dfgdfg",
                ContactName = "dfgdfgd",
                PrimaryPhone = "dfgdfgd",
                Email = ""
                
            };
            var objDetail = new EmployeeDetail()
            {
            AgileWorkerID = 1,
            CurrentHours = "sdfsd",
            CurrentlyAbsentFromWorkID = 2,
            CurrentRoleTypeID = 1,
            DateofFirstAbsence = DateTime.Now,
            EAP = "sdfsd",
            IllnessEmpAbilityToPerform = "sdfsd",
            MedicationOrTreatment = "sdf",
            OfficeBasedID = 1,
            OfficeLocation = "sdf",
            PreRelatedAbsence = "sdfs",
            TypeofIllness = "sdfsf",
            UsualHours = "sdfsd",
            UsualJobRoleTypeID = 1,
            AdditionalQuestion1 = "Testing1",
            AdditionalQuestion2 = "Testing2",
            FurtherQuestion1 = "Testing1",
            FurtherQuestion2 = "Testing2"
            };

            //var policyOpenDetail = new PolicyOpenDetail()
            //{
            //    PolicyType = "sdfs",
            //    TypeCover = "sdfs",
            //    PolicyCriteria = "sdf",
            //    RehabORProportionate = "sdf",
            //    FitforWork = "sdf",
            //    ReInsured = "sdf",
            //    ReferenceNo = "12",
            //    Admitted = 12,
            //    BenefitDate = DateTime.UtcNow,
            //    MonthlyValue = 45,
            //    EndBenefitDate = DateTime.UtcNow,
            //    NameofReinsurer = "sdf",
            //    PolicyWording = "dfdsfs"
            //};
            var caseID = caseService.AddNewReferral(@case, patient, userID, solicitor, injuredPartyRepresentative, objEmployment, objpolicies, objDetail);
            Assert.IsTrue(caseID > 0);

        }

        [TestMethod]
        public void UpdateNewReferral_Test()
        {
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();

            const int userID = 16;

            var @case = new Case()
            {
                CaseID = 6004,
                CaseNumber = "20019-ITS-CHI",
                ReferrerProjectTreatmentID = 10023,
                TreatmentTypeID = 4,
                CaseReferrerReferenceNumber = "9872189391",
                CaseSpecialInstruction = null,
                CaseReferrerDueDate = DateTime.UtcNow,
                CaseSubmittedDate = DateTime.UtcNow,
                SupplierID = 1, //????
                ReferrerID = 566,
                SendInvoiceEmail = "r@r.com",
                SendInvoiceName = "sdfsd",
                SendInvoiceTo = "j@J.com",
                ReferrerAssignedUser = 467,
                SupplierAssignedUser = 450,
                InnovateNote = "sdfsdfssdfsd",
                ReferrerProjectID = 3143
            };

            var patient = new Patient()
            {
                PatientID = 4580,
                Title = "MR.",
                FirstName = "rAJESH",
                LastName = "Lastname Test",
                Address = "my address",
                City = "my city",
                Region = "my region",
                PostCode = "11234",
                InjuryDate = DateTime.UtcNow,
                HasLegalRep = true,
                GenderID = 1,
                HasInjuredPartyRepresentative = 3,
                SpecialInstructionNotes = null
            };

            var solicitor = new Solicitor()
            {
                SolicitorID = 1210,
                CompanyName = "Company Test4",
                Address = "address test",
                Phone = "12345",
                Email = "test@test.com",
                Fax = "123456",
                FirstName = "firstname test",
                LastName = "lastname test",
                PostCode = "11234",
                ReferenceNumber = "12345",
                City = "city test",
                Region = "R test",
                IsReferralUnderJointInstruction = true


            };
            var injuredPartyRepresentative = new InjuredPartyRepresentative()
            {
                InjuredID = 2139,
                Address = "Address 1",
                Email = "r@r.com",
                FirstName = "Rohit",
                LastName = "Kumar",
                ReferralID = 566,
                Tel1 = "9999999999",
                Tel2 = "9879879875",
                PostCode = "1114444"
            };

            var objpolicies = new Policie()
            {
                PolicyID = 187,
                PolicyCriteriaId = 4,
                PolicyTypeId = 4,
                TypeCoverId = 4,
                RehabProportionateBenefit = true,
                AdmittedId = 4,
                FitForWorkId = 4,
                ReInsuredId = true,
                BenefitDate = DateTime.UtcNow,
                MonthlyValue = 4,
                EndBenefitDate = DateTime.UtcNow,
                NameOfReinsurerID = 3,
                ReferenceNo = "test",
                PolicyWording = "This is to state that what  it int o"
            };

            var objEmployment = new Employment()
            {
                EmploymentId = 209,
                EmploymentTypeId = 1,
                CompanyName = "dfgdfg",
                JobRole = "dfgdfg",
                Address = "dfgdfg",
                ContactName = "dfgdfgd",
                PrimaryPhone = "dfgdfgd",
                Email = ""

            };
            var objDetail = new EmployeeDetail()
            {
                EmployeeDetailID = 3,
                AgileWorkerID = 1,
                CurrentHours = "test",
                CurrentlyAbsentFromWorkID = 2,
                CurrentRoleTypeID = 1,
                DateofFirstAbsence = DateTime.Now,
                EAP = "test",
                IllnessEmpAbilityToPerform = "test",
                MedicationOrTreatment = "sdf",
                OfficeBasedID = 1,
                OfficeLocation = "test",
                PreRelatedAbsence = "test",
                TypeofIllness = "test",
                UsualHours = "sdfssetetd",
                UsualJobRoleTypeID = 1,
                AdditionalQuestion1 = "Testing1",
                AdditionalQuestion2 = "Testing2",
                FurtherQuestion1 = "Testing1",
                FurtherQuestion2 = "Testing2"
            };


            var caseID = caseService.UpdateReferral(@case, patient, userID, solicitor, injuredPartyRepresentative, objEmployment, objpolicies);

            Assert.IsTrue(caseID > 0);

        }

        [TestMethod]
        public void UpdateCaseSupplier_Test()
        {
            ICase caseService = new CaseImpl(_caseRepository);

            int SupplierID = 241;
            int CaseID = 12;
            int _CaseResult = caseService.UpdateCaseSupplier(CaseID, SupplierID);
            Assert.IsTrue(_CaseResult != 0, "Error in Updating _Case !!!");

        }



        [TestMethod]
        public void GetSupplierCasesAndPatientByWorkflowID_DL_Test()
        {
            //arrange
            const int supplierID = 21;
            const int workflowIDRefferedToSupplier = GlobalConst.WorkFlow.ReferredtoSupplier;

            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();
            ICaseRepository caseRepository = new CaseRepository(baseContextFactory);

            //act
            IEnumerable<SupplierCasePatient> supplierCasePatients = caseRepository.GetSupplierCasesAndPatientByWorkflowID(supplierID, workflowIDRefferedToSupplier).ToList();

            //assert
            SupplierCasePatient supplierCasePatient = supplierCasePatients.First();
            Assert.IsTrue(supplierCasePatients.Any());
            Assert.IsTrue(supplierCasePatient.CaseID != 0);
            Assert.IsTrue(!string.IsNullOrEmpty(supplierCasePatient.FirstName));
            Assert.IsTrue(!string.IsNullOrEmpty(supplierCasePatient.LastName));
            Assert.IsTrue(supplierCasePatient.WorkflowID == workflowIDRefferedToSupplier);
        }

        //[TestMethod]
        //public void UpdateCaseWorkflowToInitialAssessmentAttended_Success_BL_Test()
        //{
        //    ICase caseService = new CaseImpl(_caseRepository);
        //    const int caseID = 22;
        //    int response = caseService.UpdateCaseWorkflowToInitialAssessmentAttended(caseID);
        //    Assert.IsTrue(response > 0);

        //    Case caseObj = _caseRepository.GetCaseByCaseID(caseID);
        //    Assert.IsTrue(caseObj.WorkflowID == ITS.Core.BL.Implementation.Global.GlobalConst.WorkFlow.InitialAssessmentAttended);
        //}


        //[TestMethod]
        //public void UpdateCaseWorkflowToInitialAssessmentAttended_Error_BL_Test()
        //{
        //    try
        //    {
        //        ICase caseService = new CaseImpl(_caseRepository);
        //        int caseID = 20;
        //        int response = caseService.UpdateCaseWorkflowToInitialAssessmentAttended(caseID);
        //    }
        //    catch (Exception ex)
        //    {
        //        Assert.IsTrue(ex.Message == "CaseID is not allowed to be updated to Initial Assessment Attended");
        //    }
        //}

        [TestMethod]
        public void AddBookIA_Test()
        {
            const int caseID = 2327;
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();

            var caseAppointmentDate = new CaseAppointmentDate()
            {
                CaseID = caseID,
                AppointmentDateTime = DateTime.UtcNow,
                FirstAppointmentOfferedDate = DateTime.UtcNow,

            };

            string InnovateNote = null; // "Testin Innovate Note";
            var updateBookIAResponse = caseService.AddBookIA(caseID, DateTime.Now, 0, caseAppointmentDate, InnovateNote);
            Assert.IsTrue(updateBookIAResponse > 0);
        }

        [TestMethod]
        public void AddBookIA_NoCasePatientContactAttempt_Test()
        {
            const int caseID = 43;
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();

            var caseAppointmentDate = new CaseAppointmentDate()
            {
                CaseID = caseID,
                AppointmentDateTime = DateTime.UtcNow,
                FirstAppointmentOfferedDate = DateTime.UtcNow,

            };
            //var patientContactAttempts = new List<CasePatientContactAttempt>();
            string InnovateNote = "Test InnovateNote";
            var updateBookIAResponse = caseService.AddBookIA(caseID, DateTime.Now, 0, caseAppointmentDate, InnovateNote);

            Assert.IsTrue(updateBookIAResponse > 0);
        }

        [TestMethod]
        public void AddBookIA_NoFirstAppointmentOfferedDate_Test()
        {
            const int caseID = 43;
            var baseContextFactory = new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>();

            var caseAppointmentDate = new CaseAppointmentDate()
            {
                CaseID = caseID,
                AppointmentDateTime = DateTime.UtcNow,
                FirstAppointmentOfferedDate = null,

            };
            // var patientContactAttempts = new List<CasePatientContactAttempt>();
            string InnovateNote = "Test InnovateNote";
            var updateBookIAResponse = caseService.AddBookIA(caseID, DateTime.Now, 0, caseAppointmentDate, InnovateNote);

            Assert.IsTrue(updateBookIAResponse > 0);
        }

        [TestMethod]
        public void UpdateCaseInvoiceDate_Test()
        {
            ICase caseService = new CaseImpl(_caseRepository);

            DateTime invoiceDate = DateTime.Now;
            int CaseID = 51;
            int _CaseResult = caseService.UpdateCaseInvoiceDate(invoiceDate, CaseID);
            Assert.IsTrue(_CaseResult != 0, "Error in Updating _Case !!!");

        }


        [TestMethod]
        public void GetUnsuccessfulContactDate()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            IEnumerable<CasePatientContactAttempt> _CaseResult = caseService.GetUnsuccessfulContactDate(2227);
            Assert.IsTrue(_CaseResult.Any());
        }

        [TestMethod]
        public void GetPatientContactDate()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            IEnumerable<CasePatientContactAttempt> _CaseResult = caseService.GetPatientContactDate(165);
            Assert.IsTrue(_CaseResult.Any());
        }


        [TestMethod]
        public void GetNotificationBubbleCountBySupplierID()
        {
            ICase caseService = new CaseImpl(_caseRepository);
            NotificationBubble _CaseResult = caseService.GetNotificationBubbleCountBySupplierID(634);
            Assert.IsTrue(_CaseResult != null, "Error in Updating _Case !!!");

        }
            
        [TestMethod]
        public void Update_CaseWorkFlowStoppedCase()
        {
            var _CaseResult = caseService.UpdateCaseWorkFlowStoppedCase(1024, 497);
            Assert.IsTrue(_CaseResult != null, "Error in Updating _Case !!!");
        }

        [TestMethod]
        public void AddCaseReferrerAssignedUser()
        {
            CaseReferrerAssignedUser user = new CaseReferrerAssignedUser();
            user.UserID = 523;
            user.CaseID = 4886;
            var res = caseService.AddCaseReferrerAssignedUser(user);
            Assert.IsTrue(res > 0, "Error");
        }

        [TestMethod]
        public void DeleteCaseReferrerAssignedUserByID()
        {
            var res = caseService.DeleteCaseReferrerAssignedUserByID(11);
            Assert.IsTrue(res > 0, "Error");
        }

        [TestMethod]
        public void GetCaseReferrerAssignedUsersByCaseID()
        {
            var res = caseService.GetCaseReferrerAssignedUsersByCaseID(4886);
            Assert.IsTrue(res != null, "Error");    
        }
        [TestMethod]
        public void Get_Gips()
        {
            var res = caseService.GetAllGips();
            Assert.IsTrue(res != null, "Error"); 
        }
        [TestMethod]
        public void Get_Iips()
        {
            var res = caseService.GetAllIips();
            Assert.IsTrue(res != null, "Error");
        }
        [TestMethod]
        public void Get_Tpds()
        {
            var res = caseService.GetAllTpds();
            Assert.IsTrue(res != null, "Error");
        }
        [TestMethod]
        public void Get_ElRehab()
        {
            var res = caseService.GetAllElRehabs();
            Assert.IsTrue(res != null, "Error");
        }
    }
}
