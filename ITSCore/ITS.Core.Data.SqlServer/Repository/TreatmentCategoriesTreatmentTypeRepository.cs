using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 Page Name:  TreatmentCategoriesTreatmentTypeRepository.cs                      
 Latest Version:  1.0                                              
  Purpose: create TreatmentCategoriesTreatmentTypeRepository model  inside itscore project                                                         
  Revision History:                                        
                                                           
   1.0 – 01/25/2012 Robin 

 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class TreatmentCategoriesTreatmentTypeRepository : BaseRepository<TreatmentCategoriesTreatmentType, ITSDBContext>, ITreatmentCategoriesTreatmentTypeRepository
    {
        public TreatmentCategoriesTreatmentTypeRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }


        public IEnumerable<TreatmentCategoriesTreatmentType> GetTreatmentCategoriesTreatmentTypeByTreatmentCategoryID(int treatmentCategoryID)
        {

            return GetAll(o => o.TreatmentCategoryID == treatmentCategoryID);

        }

        public IEnumerable<TreatmentCategoriesTreatmentType> GetTreatmentCategoriesTreatmentTypeByTreatmentTypeID(int treatmentTypeID)
        {
            return GetAll(o => o.TreatmentTypeID == treatmentTypeID);
        }
    }
}
