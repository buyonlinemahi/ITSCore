using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System;

namespace CoreTest
{
    [TestClass]
    public class PolicyOpenClassTest
    {
     
        IPolicyOpenDetailRepository _policyOpenDetailRepositroy;
        public PolicyOpenClassTest()
        {
        }

        [TestInitialize()]
        public void PolicyOpenClassTestInit()
        {
            _policyOpenDetailRepositroy = new PolicyOpenDetailRepository (new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
        }

        [TestMethod]
        public void Updatedata()
        {
            PolicyOpenDetail obj = new PolicyOpenDetail();
            obj.PolicyOpenDetailID = 22;
            obj.PolicyType = "aaa";
            obj.TypeCover = "aaaa";
            obj.PolicyCriteria = "aaa";
            obj.RehabORProportionate = "aaaa";
            obj.FitforWork = "aaa";
            obj.ReInsured = "aaaaa";
            obj.ReferenceNo = "aaaa";
            obj.Admitted = "aaaaa";
            obj.OpenBenefitDate = System.DateTime.Now;
            obj.OpenMonthlyValue = 56;
            obj.OpenEndBenefitDate = System.DateTime.Now;
            obj.NameofReinsurer = "aaa";
            obj.OpenPolicyWording = "aaaaaaaaaaaaaaaaaaaaaa";
            int _Result = _policyOpenDetailRepositroy.UpdatePolicieOpenDetail(obj);
            Assert.IsTrue(_Result != 0, "Error in inserting _ReferrerProjectTreatmentSLAResult !!!");            
        }
    }
}
