
namespace ITS.Core.Data.SqlServer.Global
{
    public class View
    {

        public struct lookup
        {
            public const string TreatmentCategoriesPricingTypes = "TreatmentCategoriesPricingTypes";
            public const string TreatmentCategoriesTreatmentType = "TreatmentCategoriesTreatmentTypes";
            public const string TreatmentCategoriesRegistrationType = "TreatmentCategoriesRegistrationTypes";
            public const string TreatmentCategoriesAreasofExpertise = "TreatmentCategoriesAreasofExpertises";
            public const string PractitionerTreatmentRegistration = "PractitionerTreatmentRegistrations";
            public const string TreatmentCategoriesBespokeService = "TreatmentCategoriesBespokeServices";
            
        }


        public struct supplier
        {
            public const string SupplierSearch = "SupplierSearch";
        }

        public struct referrer
        {
            public const string ReferrerAuthorisations = "ReferrerAuthorisations";
        }
    }
}
