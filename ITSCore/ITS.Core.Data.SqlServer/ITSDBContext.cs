using ITS.Core.Data.SqlServer.Configuration;
using System.Data.Entity;

/*
Page Name:  ITSDBContext.cs
 Version:  1.18
 Purpose: Integrate referrer to model
 Revision History:

   1.0 – 10/26/2012 Satya
=======================================================================================================================================================
  * Edited By : Satya
  * Date : 10/30/2012
  * Version : 1.1
 * Description : Add referrer location to modelbuilder
=======================================================================================================================================================
  * Edited By : Satya
  * Date : 11/07/2012
  * Version : 1.1
 * Description : Add treatment category model to modelbuilder
 =======================================================================================================================================================
* Edited by : Vishal Sen
 * Date : 11/07/2012
 * Version : 1.2
 * Description : Add Pricing Type To moldel Builder
=======================================================================================================================================================
 * Edited By : Satya
  * Date : 11/09/2012
  * Version : 1.3
 * Description : Add ProjectTreatmentSLAConfiguration,ReferrerProjectConfiguration, ReferrerProjectTreatmentConfiguration,ReferrerProjectTreatmentPricingConfiguration,
 * ServiceLevelAgreementConfiguration   to modelbuilder
=======================================================================================================================================================
 * Edited By : Satya
  * Date : 11/10/2012
  * Version : 1.4
 * Description : Add AssessmentServiceConfiguration,AssessmentTypeConfiguration, DelegatedAuthorisationConfiguration,ReferrerProjectTreatmentAssessmentConfiguration,
 * ReferrerProjectTreatmentAuthorisationConfiguration   to modelbuilder
=======================================================================================================================================================
 * Edited by : Vishal Sen
 * Date : 11/15/2012
 * Version : 1.5
 * Description : Add Pricing Type To moldel Builder ReferrerProjectTreatmentEmailConfiguration
=======================================================================================================================================================
 * Edited by : Vishal Sen
 * Date : 11/15/2012
 * Version : 1.6
 * Description : Add Pricing Type To moldel Builder TreatmentCategoryPricingTypesConfiguration

=======================================================================================================================================================
 * Edited by : Vishal Sen
 * Date : 11/17/2012
 * Version : 1.7
 * Description : Add Supplier To moldel Builder SupplierConfiguration
 =======================================================================================================================================================
 *  * Edited by : Vijay kumar
 * Date : 12/06/2012
 * Version : 1.8
 * Description : Add  moldel Builder DelegatedAuthorisationTypesConfiguration,DelegatedAuthorisationTypesConfiguration
 =======================================================================================================================================================
 * Edited by : Vishal
 * Date : 12/15/2012
 * Version : 1.9
 * Description : Add  moldel Builder Solicitor
  =======================================================================================================================================================
 * Edited by : Manjit Singh
 * Date : 12/15/2012
 * Version : 1.10
 * Description : Added  moldel Builder SupplierDocument
 =======================================================================================================================================================
 * Edited by : Vishal
 * Date : 12/21/2012
 * Version : 1.11
 * Description : Added  moldel Builder RegistrationTypeConfiguration
 =======================================================================================================================================================
 *
 * Modified by : Pardeep Kumar
 * Date        : 24-Dec-2012
 * Version     : 1.12
 * Description : Added  moldel Builder SupplierInsuranceConfiguration
 =======================================================================================================================================================
 * Modified by : Vishal
 * Date        : 12/24/2012
 * Version     : 1.13
 * Description : Added  moldel Builder for SupplierSiteAuditConfiguration
 =======================================================================================================================================================
  * Modified by : Vishal
 * Date        : 12/29/2012
 * Version     : 1.14
 * Description : Added  moldel Builder for SupplierClinicalAuditConfiguration
 =======================================================================================================================================================
 * Modified by : Robin Singh
 * Date        : 01/01/2013
 * Version     : 1.15
 * Description : Added  moldel Builder for TreatmentTypeConfiguration
 =======================================================================================================================================================
 * Modified by : Vishal
 * Date        : 01/01/2013
 * Version     : 1.16
 * Description : Added  moldel Builder for Areas of Expertise
 *
 * Modified by : Robin Singh, Satya
 * Date        : 01/03/2013
 * Version     : 1.17
 * Description : Added  moldel Builder for Case
 *
 * Modified by : Robin Singh
 * Date        : 01/31/2013
 * Version     : 1.18
 * Description : Added  moldel Builder for TreatmentCategoryAreasofExpetiseConfiguration , TreatmentCategoriesAreasofExpertiseConfiguration and TreatmentCategoriesRegistrationTypeConfiguration

 */

namespace ITS.Core.Data.SqlServer
{
    public class ITSDBContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new ReferrerConfiguration());
            modelBuilder.Configurations.Add(new ReferrerLocationConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoryConfiguration());
            modelBuilder.Configurations.Add(new PricingTypesConfiguration());
            modelBuilder.Configurations.Add(new ProjectTreatmentSLAConfiguration());
            modelBuilder.Configurations.Add(new ReferrerProjectConfiguration());
            modelBuilder.Configurations.Add(new ReferrerProjectTreatmentConfiguration());
            modelBuilder.Configurations.Add(new ReferrerProjectTreatmentPricingConfiguration());
            modelBuilder.Configurations.Add(new ServiceLevelAgreementConfiguration());
            modelBuilder.Configurations.Add(new AssessmentServiceConfiguration());
            modelBuilder.Configurations.Add(new AssessmentTypeConfiguration());
            modelBuilder.Configurations.Add(new DelegatedAuthorisationConfiguration());
            modelBuilder.Configurations.Add(new ReferrerProjectTreatmentAssessmentConfiguration());
            modelBuilder.Configurations.Add(new ReferrerProjectTreatmentAuthorisationConfiguration());
            modelBuilder.Configurations.Add(new ReferrerProjectTreatmentEmailConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoryPricingTypesConfiguration());
            modelBuilder.Configurations.Add(new SupplierConfiguration());
            modelBuilder.Configurations.Add(new ReferrerProjectTreatmentInvoiceConfiguration());
            modelBuilder.Configurations.Add(new InvoiceMethodConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoriesPricingTypesConfiguration());
            modelBuilder.Configurations.Add(new EmailSendingOptionConfiguration());
            modelBuilder.Configurations.Add(new PatientConfiguration());
            modelBuilder.Configurations.Add(new DelegatedAuthorisationTypesConfiguration());
            modelBuilder.Configurations.Add(new DocumentSetupTypesConfiguration());
            modelBuilder.Configurations.Add(new EmailTypeConfiguration());
            modelBuilder.Configurations.Add(new ReferrerProjectTreatmentDocumentSetupConfiguration());
            modelBuilder.Configurations.Add(new SolicitorConfiguration());
            modelBuilder.Configurations.Add(new ComplaintStatusConfiguration());
            modelBuilder.Configurations.Add(new ComplaintTypeConfiguration());
            modelBuilder.Configurations.Add(new SupplierComplaintConfiguration());
            modelBuilder.Configurations.Add(new SupplierDocumentConfiguration());
            modelBuilder.Configurations.Add(new SupplierTreatmentConfiguration());
            modelBuilder.Configurations.Add(new SupplierTreatmentPricingConfiguration());
            modelBuilder.Configurations.Add(new RegistrationTypeConfiguration());
            modelBuilder.Configurations.Add(new SupplierInsuranceConfiguration());
            modelBuilder.Configurations.Add(new SupplierSiteAuditConfiguration());
            modelBuilder.Configurations.Add(new SupplierSearchConfiguration());
            modelBuilder.Configurations.Add(new SupplierClinicalAuditConfiguration());
            modelBuilder.Configurations.Add(new TreatmentTypeConfiguration());
            modelBuilder.Configurations.Add(new AreasofExpertiseConfiguration());
            modelBuilder.Configurations.Add(new PractitionerConfiguration());
            modelBuilder.Configurations.Add(new PractitionerExpertiseConfiguration());
            modelBuilder.Configurations.Add(new SupplierPractitionersConfiguration());
            modelBuilder.Configurations.Add(new CaseConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoriesTreatmentTypeConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoryTreatmentTypeConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoryAreasofExpetiseConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoriesAreasofExpertiseConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoriesRegistrationTypeConfiguration());
            modelBuilder.Configurations.Add(new BankHolidayConfiguration());
            modelBuilder.Configurations.Add(new PractitionerRegistrationConfiguration());
            modelBuilder.Configurations.Add(new PractitionerTreatmentRegistrationConfiguration());
            modelBuilder.Configurations.Add(new UKPostCodeConfiguration());
            modelBuilder.Configurations.Add(new ReferrerAuthorisationsConfiguration());
            modelBuilder.Configurations.Add(new PatientImpactValueConfiguration());
            modelBuilder.Configurations.Add(new PsychologicalFactorConfiguration());
            modelBuilder.Configurations.Add(new PatientWorkstatusConfiguration());
            modelBuilder.Configurations.Add(new PatientImpactConfiguration());
            modelBuilder.Configurations.Add(new ReferrerDocumentConfiguration());
            modelBuilder.Configurations.Add(new ProposedTreatmentMethodConfiguration());
            modelBuilder.Configurations.Add(new PatientLevelOfRecoveryConfiguration());
            modelBuilder.Configurations.Add(new PatientImpactOnWorkConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentPatientImpactConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentPatientImpactHistoryConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentPatientInjuryConfiguration());
            modelBuilder.Configurations.Add(new CaseTreatmentPricingConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoryBespokeServiceConfiguration());
            modelBuilder.Configurations.Add(new TreatmentCategoriesBespokeServiceConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentHistoryConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentPatientInjuryHistoryConfiguration());
            modelBuilder.Configurations.Add(new EmailTypeValueConfiguration());
            modelBuilder.Configurations.Add(new PatientRoleConfiguration());
            modelBuilder.Configurations.Add(new DurationConfiguration());
            modelBuilder.Configurations.Add(new TreatmentPeriodTypeConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentDetailConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentDetailHistoryConfiguration());
            modelBuilder.Configurations.Add(new CaseStopReasonConfiguration());
            modelBuilder.Configurations.Add(new CaseBespokeServicePricingConfiguration());
            modelBuilder.Configurations.Add(new CaseCommunicationHistoryConfiguration());
            modelBuilder.Configurations.Add(new CaseVATConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentProposedTreatmentMethodHistoryConfiguration());
            modelBuilder.Configurations.Add(new CaseAssessmentProposedTreatmentMethodConfiguration());
            modelBuilder.Configurations.Add(new InvoiceConfiguration());
            modelBuilder.Configurations.Add(new InvoicePaymentConfiguration());
            modelBuilder.Configurations.Add(new InvoiceCollectionActionConfiguration());
            modelBuilder.Configurations.Add(new InjuredPartyRepresentativeConfiguration());
            modelBuilder.Configurations.Add(new InjuredRepresentativeOptionConfiguration());
            modelBuilder.Configurations.Add(new AffectedAreaConfiguration());
            modelBuilder.Configurations.Add(new SymptomDescriptionConfiguration());
            modelBuilder.Configurations.Add(new StrengthTestingConfiguration());
            modelBuilder.Configurations.Add(new RestrictionRangeConfiguration());
            modelBuilder.Configurations.Add(new AdmittedConfiguration());           
            modelBuilder.Configurations.Add(new EmploymentConfiguration());
            modelBuilder.Configurations.Add(new EmploymentTypeConfiguration());
            modelBuilder.Configurations.Add(new FitForWorkConfiguration());           
            modelBuilder.Configurations.Add(new PolicyCriteriaConfiguration());
            modelBuilder.Configurations.Add(new PolicyTypeConfiguration());
            modelBuilder.Configurations.Add(new TypeCoverConfiguration());
            modelBuilder.Configurations.Add(new EmployeeDetailConfiguration());
            modelBuilder.Configurations.Add(new WorkTypeConfiguration());
            modelBuilder.Configurations.Add(new RoleTypeConfiguration());
            modelBuilder.Configurations.Add(new ReinsurerConfiguration());
            modelBuilder.Configurations.Add(new PrimaryConditionConfiguration());
            modelBuilder.Configurations.Add(new GenderConfiguration());    
            modelBuilder.Configurations.Add(new PasswordHistoryConfiguration());
            modelBuilder.Configurations.Add(new DrugTestConfiguration());
            modelBuilder.Configurations.Add(new AdditionalTestConfiguration());
            modelBuilder.Configurations.Add(new ReasonForReferralConfiguration());
            modelBuilder.Configurations.Add(new NetworkRailStandardApplicableConfiguration());
            modelBuilder.Configurations.Add(new CaseReferrerAssignedUserConfiguration());
            modelBuilder.Configurations.Add(new GipConfiguration());
            modelBuilder.Configurations.Add(new IipConfiguration());
            modelBuilder.Configurations.Add(new TpdConfiguration());
            modelBuilder.Configurations.Add(new ElRehabConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public virtual int Save()
        {
            return base.SaveChanges();
        }

        public ITSDBContext()
        {
        }

        public ITSDBContext(string connectionStringName)
            : base(connectionStringName)
        {
        }
    }
}