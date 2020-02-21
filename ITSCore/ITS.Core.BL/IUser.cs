using BLModel = ITS.Core.BL.Model;
using ITS.Core.Data.Model;
using System.Collections.Generic;

/*
 Page Name:  IUser.cs                      
  Version:  1.5                                              
  Purpose: Added a Method(GetUserByUserTypeID) to get the users by Usertype.
 */
namespace ITS.Core.BL
{
    public interface IUser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserByUserName(string userName);
        int UpdateUserLock(int userID, bool locked);
        User GetUserByUserId(int userId);
        IEnumerable<User> GetUserByUserNameAutoComplete(string userNameLike);
        int AddUser(User user);
        int UpdateUserByUserID(User user);
        int UpdatePasswordOTPByID(int _userID, string _passwordOTP);
        IEnumerable<User> GetUserByUserTypeID(int userTypeId);
        IEnumerable<User> GetReferrerUsersByCaseID(int CaseID);
        IEnumerable<User> GetReferrerUsersByID(int referrerID);
        int UpdateUserFailedAttemptCount(int userID);
        int ResetUserFailedAttemptCount(int userID);
        IEnumerable<User> GetUsersRecentlyAdded();

        IEnumerable<UserTypeUser> GetUserTypeUsersLikeUsername(string username, int skip, int take);
        int GetUserTypeUsersLikeUsernameCount(string username);

        IEnumerable<UserTypeUser> GetUserTypeUsersLikeUserType(string userType, int skip, int take);
        int GetUserTypeUsersLikeUserTypeCount(string userType);

        IEnumerable<UserTypeUser> GetUserTypeUsersLikeName(string name, int skip, int take);
        int GetUserTypeUsersLikeNameCount(string name);

        bool GetUserExistsByName(string name);

        IEnumerable<UserTypeUser> GetUserTypeUsersLikeReferrerName(string referrerName, int skip, int take);
        int GetUserTypeUsersLikeReferrerNameCount(string referrerName);


        IEnumerable<UserTypeUser> GetUserTypeUsersLikeSupplierName(string supplierName, int skip, int take);
        int GetUserTypeUsersLikeSupplierNameCount(string supplierName);

        void ResetUserPassword(int userId, string userPwassword);
        User GetUserRecordByEmailID(string emailID);
        User GetUserRecordByEmailAndUserName(string emailID, string username);
        IEnumerable<User> GetAllSupplierUserBySupplierID(int _supplierID);

        void AddUserProject(BLModel.UserProject _userProject);
        int DeleteUserProject(int referrerProjectID, int userID);
        IEnumerable<string> GetAllUserEmailsByCaseContactByCaseID(int CaseID);

        void UpdateUserSessionIDByUserID(int userId, string userSessionID);
        void ResetUserSessionID(int userID);
    }
}
