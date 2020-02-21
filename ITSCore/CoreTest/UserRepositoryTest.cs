using ITS.Core.BL.Implementation;
using ITS.Core.Data;
using ITS.Core.Data.Model;
using ITS.Core.Data.SqlServer.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using BLModel = ITS.Core.BL.Model;

namespace CoreTest
{
    /*************************************************************************/
    /*Might need to use sqllite or other in memory sql later for unit testing*/
    /*************************************************************************/
    [TestClass]
    public class UserRepositoryTest
    {
        IUserRepository _userRepository; 
        [TestInitialize]
        public void UserRepositoryInit()
        {
            _userRepository = new UserRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()); 
        }

        [TestMethod]
        public void can_get_all_users()
        {
            IEnumerable<User> users = _userRepository.GetAll();
            Assert.IsTrue(users.Any()); 
        }

        [TestMethod]
        public void can_get_user_by_id()
        {
            User user = _userRepository.GetById(20);
            Assert.IsTrue(user != null, "unable get user by id");
        }

        [TestMethod]
        public void Get_UsersRecentlyAdded()
        {
            IEnumerable<User> users = _userRepository.GetUsersRecentlyAdded();
            Assert.IsTrue(users.Any()); 
        }

        
        [TestMethod]
        public void get_user_by_username()
        {
            User user = _userRepository.GetAll().First();
            User testUser = _userRepository.GetUserByUserName(user.UserName);
            Assert.IsTrue(testUser != null, "unable get user by user name");
        }


        [TestMethod]
        public void Get_UserTypeUsersLikeUsername()
        {
            IEnumerable<UserTypeUser> users = _userRepository.GetUserTypeUsersLikeUsername("h",1,2);
            Assert.IsTrue(users.Any()); 
        }

        [TestMethod]
        public void Get_UserTypeUsersLikeName()
        {
            IEnumerable<UserTypeUser> users = _userRepository.GetUserTypeUsersLikeName("harpreet", 0, 7);
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        public void Get_UserTypeUsersLikeUserType()
        {
            IEnumerable<UserTypeUser> users = _userRepository.GetUserTypeUsersLikeUserType("i", 1, 2);
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        public void Get_UserTypeUsersLikeUserTypeCount()
        {
            int _user = _userRepository.GetUserTypeUsersLikeUserTypeCount("i");
            Assert.IsTrue(_user != 0, "Error in UserTypeUsersLikeUserTypeCount !!!");
        }

        [TestMethod]
        public void GetUserTypeUsersLikeUsernameCount()
        {
            int _user = _userRepository.GetUserTypeUsersLikeUsernameCount("h");
            Assert.IsTrue(_user != 0, "Error in UserTypeUsersLikeUsernameCount !!!");
        }


        [TestMethod]
        public void GetUserTypeUsersLikeNameCount()
        {
            int _user = _userRepository.GetUserTypeUsersLikeNameCount("harpreet");
            Assert.IsTrue(_user != 0, "Error in UserTypeUsersLikeNameCount !!!");
        }

        [TestMethod]
        public void Get_UserTypeUsersLikeReferrerName()
        {
            IEnumerable<UserTypeUser> users = _userRepository.GetUserTypeUsersLikeReferrerName("test", 0, 4);
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        public void GetUserTypeUsersLikeReferrerCount()
        {
            int _user = _userRepository.GetUserTypeUsersLikeReferrerNameCount("test");
            Assert.IsTrue(_user != 0, "Error in UserTypeUsersLikeReferrerNameCount !!!");
        }

        [TestMethod]
        public void Get_UserTypeUsersLikeSupplierName()
        {
            IEnumerable<UserTypeUser> users = _userRepository.GetUserTypeUsersLikeSupplierName("test", 0, 4);
            Assert.IsTrue(users.Any());
        }


        [TestMethod]
        public void Get_AllSupplierUser()
        {
            IEnumerable<User> users = _userRepository.GetAllSupplierUserBySupplierID(450);
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        public void GetUserTypeUsersLikeSupplierNameCount()
        {
            int _user = _userRepository.GetUserTypeUsersLikeSupplierNameCount("test");
            Assert.IsTrue(_user != 0, "Error in UserTypeUsersLikeSupplierNameCount !!!");
        }

        [TestMethod]
        public void Test_User_Name_Forautocomplete()
        {
            IEnumerable<User> user = _userRepository.GetUserByUserNameAutoComplete("de");
            Assert.IsTrue(user.Any());
        }

        [TestMethod]
        public void can_lock_user()
        {

            User user = _userRepository.GetAll().Last();
            _userRepository.UpdateUserLock(user.UserID, true);

            _userRepository = new UserRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()); 
            user = _userRepository.GetAll().Last();
            Assert.IsTrue(user.IsLocked, "error not able to lock user");

        }

        [TestMethod]
        public void can_unlock_user()
        {
            User user = _userRepository.GetAll().Last();
            _userRepository.UpdateUserLock(user.UserID, false);

            _userRepository = new UserRepository(new Core.Base.Data.SqlServer.Factory.BaseContextFactory<ITS.Core.Data.SqlServer.ITSDBContext>()); 
            User user1 = _userRepository.GetAll().Last();

            Assert.IsTrue(!user1.IsLocked, "error not able to unlock user");
        }
        [TestMethod]
         public void AddUser()
        {
            User user = new User();
            user.UserName = string.Format("user{0}{1}{2}", DateTime.Now.Day, DateTime.Now.Minute, DateTime.Now.Second);
            user.Password = "waheguru";
            user.FirstName = "Manjit";
            user.LastName = "Singh";
            user.UserTypeID = 1;
            user.IsLocked = true;
            user.SupplierID = null;
            user.ReferrerID = null;
            user.ReferrerLocationID = null;
            user.Email = "testemail@email.com";
            int _user = _userRepository.AddUser(user);   
            Assert.IsTrue(_user != 0, "Error in inserting user !!!");
        }

        [TestMethod]
        public void UpdateUser()
        {
            User user = new User();
            user.UserID = 24;
            user.UserName = "vijay Kumar";
            user.Password = "vk123@#a";
            user.FirstName = "Vijay";
            user.LastName = "Kumar";
            user.UserTypeID = 1;
            user.Telephone = "123456";
            user.Email = "test12@test.com";
            int _user = _userRepository.UpdateUserByUserID(user);
            Assert.IsTrue(_user != 0, "Error in Updating the user !!!");
        }
        [TestMethod]
        public void Test_GetUserbyUserTypeId()
        {
            IEnumerable<User> user = _userRepository.GetUserByUserTypeID(2);
            Assert.IsTrue(user.Any());
        }

         [TestMethod]
        public void Get_UserExistsByName()
        {
            bool user = _userRepository.GetUserExistsByName("demhho");
            Assert.IsTrue(user);
        }

        

        [TestMethod]
        public void Test_GetReferrerUsersByLocationId()
        {
            var referrerLocationID = 423;
            var referalid = 430;
            //IEnumerable<User> users = _userRepository.GetReferrerUsersByReferrerLocationID(referrerLocationID, referalid);
            //Assert.IsTrue(users.Any());

            ITS.Core.BL.IUser service = new UserImpl(_userRepository);
            IEnumerable<User> users2 = service.GetReferrerUsersByCaseID(referrerLocationID);
            Assert.IsTrue(users2.Any());
        }


        [TestMethod]
        public void GetReferrerUsersByID()
        {
            ITS.Core.BL.IUser service = new UserImpl(_userRepository);
            IEnumerable<User> users2 = service.GetReferrerUsersByID(498);
            Assert.IsTrue(users2.Any());
        }

        [TestMethod]
        public void Test_GetUserByUserId()
        {
            User user = _userRepository.GetUserByUserId(254);
            Assert.IsTrue(user != null, "unable to ger user By UserId");
        }


        [TestMethod]
        public void Test_UpdateUserFailedAttemptCount()
        {
            ITS.Core.BL.IUser service = new UserImpl(_userRepository);
            User user = _userRepository.GetAll().Last();

           var res = service.UpdateUserFailedAttemptCount(user.UserID);

            Assert.IsTrue(res != 0, "error in UpdateUserFailedAttemptCount");
        }

        [TestMethod]
        public void UpdateUserFailedAttemptCount_FailUpNumberOfAttempts()
        {
            ITS.Core.BL.IUser service = new UserImpl(_userRepository);

            const int userId = 499;
            User user = service.GetUserByUserId(userId);

            service.UpdateUserFailedAttemptCount(user.UserID);

            int expectedNumberOfAttempt = ++user.FailedAttemptCount;
            Assert.IsTrue(expectedNumberOfAttempt == service.GetUserByUserId(userId).FailedAttemptCount);
        }

        [TestMethod]
        public void Test_ResetUserFailedAttemptCount()
        {
            ITS.Core.BL.IUser service = new UserImpl(_userRepository);
            User user = _userRepository.GetAll().Last();

            var res = service.ResetUserFailedAttemptCount(user.UserID);

            Assert.IsTrue(res != 0, "error in ResetUserFailedAttemptCount");
        }

        [TestMethod]
        public void Test_AddUserProject()
        {
            BLModel.UserProject userProject = new BLModel.UserProject();
            int[] refID = {2,3};
            userProject.ReferrerProjectID = refID;
            userProject.UserID = 48;
            ITS.Core.BL.IUser service = new UserImpl(_userRepository);

            foreach(int i in refID)
            {
                UserProject coreUserProject = new UserProject();
                coreUserProject.ReferrerProjectID = i;
                coreUserProject.UserID = userProject.UserID;
                _userRepository.AddUserProject(coreUserProject);
                //Assert.IsTrue(res > 0, "Error");
            }
        }

        [TestMethod]
        public void Test_EmailContactsByUserEmails()
        {
            var user = _userRepository.GetAllUserEmailsByCaseContactByCaseID(1044);
            Assert.IsTrue(user != null, "unable to ger user By UserId");
        }
    }
}
