using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace ITS.Core.Data.SqlServer.Repository
{
    public class CasePatientSupplierPractitionerRepository : BaseRepository<CasePatientSupplierPractitioner, ITSDBContext>, ICasePatientSupplierPractitionerRepository
    {
        public CasePatientSupplierPractitionerRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }



       public CasePatientSupplierPractitioner GetCasePatientSupplierPractitionerByCaseID(int caseID)
       {
           SqlParameter _CaseID = new SqlParameter("@CaseID", caseID);
           return Context.Database.SqlQuery<CasePatientSupplierPractitioner>(Global.StoredProcedureConst.CasePatientSupplierPractitionerRepositoryProcedure.GetCasePatientSupplierPractitionerByCaseID, _CaseID).SingleOrDefault<CasePatientSupplierPractitioner>();

       }

    }

 }

