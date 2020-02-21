using ITS.Core.BL;
using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CoreTest
{
    public class InjuredPartyRepresentativeTest
    {
        IInjuredPartyRepresentativeRepository _IInjuredPartyRepresentativeRepository;
        IInjuredPartyRepresentative BL;
        [TestInitialize]
        public void InjuredPartyRepresentativeInit()
        {
            _IInjuredPartyRepresentativeRepository = new InjuredPartyRepresentativeRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>());
            BL = new InjuredPartyRepresentativeImpl(_IInjuredPartyRepresentativeRepository);
        }

        [TestMethod]
        public void AddInjuredPartyRepresentative()
        {
            InjuredPartyRepresentative _injuredPartyRepresentative = new InjuredPartyRepresentative();
            _injuredPartyRepresentative.FirstName = "Abc";
            _injuredPartyRepresentative.LastName = "Singh";
            _injuredPartyRepresentative.ReferralID = 566;
            _injuredPartyRepresentative.Tel1 = "Chandigarh";
            _injuredPartyRepresentative.Tel2 = "16001";
            _injuredPartyRepresentative.Address = "152 B Tirlok Nagar Uttrakhand";
            _injuredPartyRepresentative.PostCode = "144009";
            _injuredPartyRepresentative.Email = "email@example.com";
            _injuredPartyRepresentative.Relationship = "7307194482";

            int _patient = _IInjuredPartyRepresentativeRepository.AdditionInjuredPartyRepresentative(_injuredPartyRepresentative);
            Assert.IsTrue(_patient != 0, "Error in Adding Patient !!!");
        }


        [TestMethod]
        public void GetInjuredPartyRepresentativeByReferralID()
        {

            InjuredPartyRepresentative _patient = _IInjuredPartyRepresentativeRepository.GetInjuredPartyRepresentativesByReferralID(1);
            Assert.IsTrue(_patient != null, "Error in geting Patient !!!");
        }

         [TestMethod]
        public void Get_InjuredPartyRepresentativesByID()
        {

            InjuredPartyRepresentative _patient = _IInjuredPartyRepresentativeRepository.GetInjuredPartyRepresentativesByID(1);
            Assert.IsTrue(_patient != null, "Error in geting Patient !!!");
        }
        

        [TestMethod]
        public void UpdateInjuredPartyRepresentative()
        {
            InjuredPartyRepresentative _injuredPartyRepresentative = new InjuredPartyRepresentative();
            _injuredPartyRepresentative.FirstName = "Abc";
            _injuredPartyRepresentative.LastName = "Singh";
            _injuredPartyRepresentative.ReferralID = 566;
            _injuredPartyRepresentative.Tel1 = "Chandigarh";
            _injuredPartyRepresentative.Tel2 = "16001";
            _injuredPartyRepresentative.Address = "2424 sdsafd";
            _injuredPartyRepresentative.PostCode = "144009";
            _injuredPartyRepresentative.Email = "email@example.com";
            _injuredPartyRepresentative.Relationship = "7307194482";

            int _patient = _IInjuredPartyRepresentativeRepository.AdditionInjuredPartyRepresentative(_injuredPartyRepresentative);
            Assert.IsTrue(_patient != 0, "Error in Updating Patient !!!");
        }
    }
}
