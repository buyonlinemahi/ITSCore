using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ITS.Core.Data;
using ITS.Core.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using ITS.Core.BL;
using ITS.Core.BL.Implementation;

namespace CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // UpdateCaseWorkFlow - Test

            //ISolicitorRepository _solicitorRepository = new SolicitorRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            //ICaseHistoryRepository _caseHistoryRepository = new CaseHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            //IPatientRepository _patientRepository = new PatientRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            //ICaseRepository _caseRepository = new CaseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            //ICase caseService = new CaseImpl(_caseRepository, _patientRepository, _solicitorRepository, _caseHistoryRepository);
            //caseService.UpdateCaseWorkFlow(13, 254);

            IUserRepository _userRepository = new UserRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            IUser userService = new UserImpl(_userRepository);
            ITreatmentCategoriesPricingTypesRepository _userRepository1 = new TreatmentCategoriesPricingTypesRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            ITreatmentCategoriesPricingTypes userService1 = new TreatmentCategoriesPricingTypesImpl(_userRepository1);
            var test = userService1.GetPricingTypesByTreatmentCategoryID(3);
            IReferrerProjectRepository _referrerProject = new ReferrerProjectRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            ISupplierTreatmentPricingRepository _suppliertreatmentpricingrepo = new SupplierTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            ReferrerProject _project = _referrerProject.GetReferrerProjectByProjectID(472);

            IReferrerProjectTreatmentRepository _referrerprojecttreatment = new ReferrerProjectTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            ICaseTreatmentPricingRepository caseTreatmentPricing = new CaseTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            ICaseTreatmentPricing caseTreatmentPricingBL = new CaseTreatmentPricingImpl(caseTreatmentPricing, _suppliertreatmentpricingrepo, new SupplierTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>())
            , new ReferrerProjectTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()), new ReferrerProjectTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()));

            ISupplier _supplier = new SupplierImpl(new SupplierRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
                new SupplierTreatmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
                new CaseRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
                new ClinicalAuditTotalCountAndPassAuditRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
                new SiteAuditTotalCountAndAuditPassRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
                new CaseAssessmentTotalCountAndRatingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
                new UKPostCodeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
                new SupplierDistanceRankingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
                 new SupplierTreatmentPricingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>())
                );

            //ICaseAssessment caseAssessment = new CaseAssessmentImpl(
            //    new CaseAssessmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
            //    new CaseAssessmentHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()), 
            //    new CaseAssessmentPatientImpactRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
            //    new CaseAssessmentPatientInjuryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()), 
            //    new CaseAssessmentRatingRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
            //    new CaseAssessmentPatientImpactHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()), 
            //    new CaseAssessmentPatientInjuryHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
            //    new CaseAssessmentDetailRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
            //    new CasePatientRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()), 
            //    new CaseAssessmentDetailHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
            //    new CaseAssessmentProposedTreatmentMethodRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
            //    new CaseAssessmentProposedTreatmentMethodHistoryRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()),
            //   // new CaseAssessmentPatientInjury(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>())
            //    );
            //var testz = _supplier.GetSupplierRankingBySupplierID(21);
            //var texx = _supplier.GetSupplierRankingBySupplierID(20);
            var ggg = _suppliertreatmentpricingrepo.GetSupplierTreatmentPricingBySupplierTreatmentIDAndTreatmentCategoryID(81, 1);
            var gg = _supplier.GetSupplierWithinPostCode("AB10 1AA", 100, 1);
            var gy = _supplier.GetSupplierWithinPostCode("AB10 1AA", 10,1);
            var gyg = _supplier.GetSupplierWithinPostCode("test", 10,1);
            var dsads = _referrerprojecttreatment.GetReferrerProjectTreatmentsByReferrerProjectID(1);
            var zzz = _supplier.UpdateSupplierStatus(40, true);
            var z = caseTreatmentPricing.GetReferrerAndSupplierTreatmentPricingBySupplierIDAndTreatmentCategoryIDAndReferrerTreatmentID(35, 88, 1);
            var zz = caseTreatmentPricingBL.GetTreatmentReferrerSupplierPricingQA(35, 88, 1);
            //var caseassessment1 = caseAssessment.GetCaseAssessment(125, 0);
            // IReferrerRepository _ReferrerRepository = new ReferrerRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            //IReferrerLocationRepository _referrerlocationRepository = new ReferrerLocationRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            //IReferrer referrer = new ReferrerImpl(_ReferrerRepository, _referrerlocationRepository);
            //var rrq = referrer.GetReferrerDetails(9);
            //Referrer refOBJ = new Referrer();

            //var newRef = new Referrer { ReferrerMainContactEmail = "new", ReferrerName = "new", ReferrerCentralEmail = "new", ReferrerContactFirstName = "new", ReferrerContactLastName = "newtoday" };
            //var loc = new ReferrerLocation { Name = "newloc", Address = "newadd", City = "newcity", Fax = "newfax", Phone = "newphone", PostCode = "12345", IsMainOffice = true, Region = "newregioon" };
            //referrer.AddReferrerAndMainLocation(newRef, loc);


            //// for testing by Pardeep
            //ITreatmentCategoriesPricingTypesRepository _ITreatmentCategoryRepository = new TreatmentCategoriesPricingTypesRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            //ITreatmentCategoryPricingTypes t = new TreatmentCategoryPricingTypesImpl(_ITreatmentCategoryRepository);
            //_ITreatmentCategoryRepository.GetAll(1);
            //t.GetPricingTypesByTreatmentCategoryID(1);
            IReferrerProjectTreatmentAssessmentRepository _tRepository = new ReferrerProjectTreatmentAssessmentRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());

            //  IReferrerProjectTreatmentAssessment sp = new ReferrerProjectTreatmentAssessmentImpl(_tRepository);
            //var list1 = sp.GetAll();

            // var shau=   referrer.AddReferrer(refOBJ);

            //   var list = _userRepository.GetAll();
            //   foreach (var item in list)
            //   {
            //       Console.WriteLine(item.UserID + " : " + item.FirstName  + " : " + item.LastName + " : " + item.IsLocked);
            //   }
            //  // User obj=  _userRepository.GetById(6);

            //   Console.WriteLine();
            //   Console.WriteLine();

            //  // userService.UpdateUserLock(9, m);
            //   User user = _userRepository.GetAll().Last();
            //   _userRepository.UpdateUserLock(user.UserID, true);

            //   User user1 = _userRepository.GetAll().Last();
            //var list1 = _userRepository.GetAll();
            //foreach (var item in list1)
            //{
            //    Console.WriteLine(item.UserID + " : " + item.FirstName + " : " + item.LastName + " : " + item.IsLocked);
            //}
            //Console.ReadLine();



            //This is test For Referrer
            //refOBJ.ReferrerID = 9;
            //refOBJ.ReferrerContactFirstName = "Ab";
            //refOBJ.ReferrerContactLastName = "Raj";
            //refOBJ.ReferrerContactPhone = "Raj";
            //refOBJ.ReferrerCentralEmail = "ASRamsd";
            //refOBJ.ReferrerName = "hasgsadfmsaf";
            //var result = referrer.UpdateReferrer(refOBJ);
            //var rr = referrer.GetReferrerDetails(9);



        }
    }
}
