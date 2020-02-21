using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 *
 * Latest Version : 1.0
 * 
 * Author         : Robin Singh
 * Date           : 31-Jan-2013
 * Purpose        : Added Repository TreatmentCategoriesRegistrationTypeRepository and Implement Interface for the Same
 * Version        : 1.0
 * 
 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class TreatmentCategoriesRegistrationTypeRepository : BaseRepository<TreatmentCategoriesRegistrationType, ITSDBContext>, ITreatmentCategoriesRegistrationTypeRepository
    {
        public TreatmentCategoriesRegistrationTypeRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }

        public IEnumerable<TreatmentCategoriesRegistrationType> GetTreatmentCategoriesRegistrationTypeByTreatmentCategoryID(int treatmentCategoryID)
        {
            return GetAll(o => o.TreatmentCategoryID == treatmentCategoryID);
        }

        public IEnumerable<TreatmentCategoriesRegistrationType> GetTreatmentCategoriesRegistrationTypeByRegistrationTypeID(int registrationTypeID)
        {
            return GetAll(o => o.RegistrationTypeID == registrationTypeID);
        }
    }
}
