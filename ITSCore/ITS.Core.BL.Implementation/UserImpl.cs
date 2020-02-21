using ITS.Core.Data;
using ITS.Core.Data.Model;
using System.Collections.Generic;
using BLModel = ITS.Core.BL.Model;
/*
 Page Name:  UserImpl.cs                      
  Version:  1.6                                             
  Purpose: Added a Method(GetUserByUserTypeID) to get the users by UsertypeId.
 */
namespace ITS.Core.BL.Implementation
{
    public class UserImpl : IUser
    {
        private readonly IUserRepository _userRepository;

        public UserImpl(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            return _userRepository.GetUserByUserName(userName);
        }

        public int UpdateUserLock(int userID, bool locked)
        {
            return _userRepository.UpdateUserLock(userID, locked);

        }


        public int UpdatePasswordOTPByID(int _userID, string _passwordOTP)
        {
            return _userRepository.UpdatePasswordOTPByID(_userID, _passwordOTP);

        }

        public User GetUserByUserId(int userId)
        {
            return _userRepository.GetUserByUserId(userId);
        }

        public void ResetUserPassword(int userId, string userPwassword)
        {
            _userRepository.ResetUserPassword(userId, userPwassword);
        }

        public User GetUserRecordByEmailID(string emailID)
        {
            return _userRepository.GetUserRecordByEmailID(emailID);
        }
        public User GetUserRecordByEmailAndUserName(string emailID, string username)
        {
            return _userRepository.GetUserRecordByEmailAndUserName(emailID, username);
        }

        public IEnumerable<User> GetUserByUserNameAutoComplete(string userNameLike)
        {
            return _userRepository.GetUserByUserNameAutoComplete(userNameLike);
        }
        public int AddUser(User user)
        {
            return _userRepository.AddUser(user);
        }

        public IEnumerable<User> GetAllSupplierUserBySupplierID(int _supplierID)
        {
            return _userRepository.GetAllSupplierUserBySupplierID(_supplierID);
        }
        public int UpdateUserByUserID(User user)
        {
            return _userRepository.UpdateUserByUserID(user);
        }


        public IEnumerable<User> GetUserByUserTypeID(int userTypeId)
        {
            return _userRepository.GetUserByUserTypeID(userTypeId);
        }

        public IEnumerable<User> GetReferrerUsersByCaseID(int CaseID)
        {
            return _userRepository.GetReferrerUsersByCaseID(CaseID);
        }

        public IEnumerable<User> GetReferrerUsersByID(int referrerID)
        {
            return _userRepository.GetReferrerUsersByID(referrerID);
        }
        public int UpdateUserFailedAttemptCount(int userID)
        {
            int numberOfFailedLoginAttempts = _userRepository.GetUserByUserId(userID).FailedAttemptCount;
            numberOfFailedLoginAttempts++;

            if (numberOfFailedLoginAttempts >= Global.GlobalConst.AppSetting.FAILEDATTEMPTCOUNT)
            {
                _userRepository.UpdateUserFailedAttemptCount(userID, numberOfFailedLoginAttempts);
                return _userRepository.UpdateUserLock(userID, true);
            }
            else { return _userRepository.UpdateUserFailedAttemptCount(userID, numberOfFailedLoginAttempts); }

        }


        public int ResetUserFailedAttemptCount(int userID)
        {
            return _userRepository.UpdateUserFailedAttemptCountAndLastLoginDate(userID, 0, System.DateTime.Now);
        }


        public IEnumerable<User> GetUsersRecentlyAdded()
        {
            return _userRepository.GetUsersRecentlyAdded();
        }


        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeUsername(string username, int skip, int take)
        {
            return _userRepository.GetUserTypeUsersLikeUsername(username, skip, take);
        }

        public int GetUserTypeUsersLikeUsernameCount(string username)
        {
            return _userRepository.GetUserTypeUsersLikeUsernameCount(username);
        }

        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeUserType(string userType, int skip, int take)
        {
            return _userRepository.GetUserTypeUsersLikeUserType(userType, skip, take);
        }

        public int GetUserTypeUsersLikeUserTypeCount(string userType)
        {
            return _userRepository.GetUserTypeUsersLikeUserTypeCount(userType);
        }

        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeName(string name, int skip, int take)
        {
            return _userRepository.GetUserTypeUsersLikeName(name, skip, take);
        }

        public int GetUserTypeUsersLikeNameCount(string name)
        {
            return _userRepository.GetUserTypeUsersLikeNameCount(name);
        }


        public bool GetUserExistsByName(string name)
        {
            return _userRepository.GetUserExistsByName(name);
        }


        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeReferrerName(string referrerName, int skip, int take)
        {
            return _userRepository.GetUserTypeUsersLikeReferrerName(referrerName, skip, take);
        }

        public int GetUserTypeUsersLikeReferrerNameCount(string referrerName)
        {
            return _userRepository.GetUserTypeUsersLikeReferrerNameCount(referrerName);
        }

        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeSupplierName(string supplierName, int skip, int take)
        {
            return _userRepository.GetUserTypeUsersLikeSupplierName(supplierName, skip, take);
        }

        public int GetUserTypeUsersLikeSupplierNameCount(string supplierName)
        {
            return _userRepository.GetUserTypeUsersLikeSupplierNameCount(supplierName);
        }

        public void AddUserProject(BLModel.UserProject _userProject)
        {
            foreach (int refID in _userProject.ReferrerProjectID)
            {
                UserProject coreUserProject = new UserProject();
                coreUserProject.ReferrerProjectID = refID;
                coreUserProject.UserID = _userProject.UserID;
                _userRepository.AddUserProject(coreUserProject);
            }
        }

        public int DeleteUserProject(int referrerProjectID, int userID)
        {
            return _userRepository.DeleteUserProject(referrerProjectID, userID);
        }

        public IEnumerable<string> GetAllUserEmailsByCaseContactByCaseID(int CaseID)
        {
            return _userRepository.GetAllUserEmailsByCaseContactByCaseID(CaseID);
        }

        public void UpdateUserSessionIDByUserID(int userId, string userSessionID)
        {
            _userRepository.UpdateUserSessionIDByUserID(userId, userSessionID);
        }

        public void ResetUserSessionID(int userID)
        {
            _userRepository.ResetUserSessionID(userID);
        }
    }
}
