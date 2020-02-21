using Core.Base.Data;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
/*
 Page Name:  UserRepository.cs                       
  Version:  1.5                                            
  Purpose: Added a Method(GetUserByUserTypeID) to get the users by Usertype.
  Revision History:                                        
                                                           
    1.0 – 10/26/2012 Satya  
 * 1.1 – 10/26/2012 Vijay Kumar
 * Add GetUserByUserNameAutoComplete contract to get user autocomplete
 * 1.2 - 10/26/2012 Anuj 
 * Added a method to lock unlock user
 * 
 * Edited By : Pardeep
 * Date : 27-Oct-2012
 * Version : 1.2
 * Description : Added a Method to retreive the user information by Id (UserId)
 * 
 * Edited By : Manjit Singh
 * Date : 3-Nov-2012
 * Version : 1.3
 * Description : Added a Method to Add User
 * 
 * Edited By : Vijay Kumar
 * Date : 3-Nov-2012
 * Version : 1.4
 * Description : Added a Method(Update_UserByUserID) to update the user by ID(UserId)

 * Edited By : Anuj Batra
 * Date : 28-Dec-2012
 * Version : 1.5
 * Description : Added a Method(GetUserByUserTypeID) to get the users by UsertypeId.

 */
namespace ITS.Core.Data
{
	public interface IUserRepository : IBaseRepository<User>
	{
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUserByUserName(string userName);

        IEnumerable<User> GetUserByUserNameAutoComplete(string userNameLike);
        int UpdateUserLock(int userID, bool locked);
        User GetUserByUserId(int userId);
        int AddUser(User user);
        int UpdateUserByUserID(User user);

        IEnumerable<User> GetUserByUserTypeID(int userTypeID);
        IEnumerable<User> GetReferrerUsersByCaseID(int CaseID);

        IEnumerable<User> GetReferrerUsersByID(int referrerID);

        int UpdateUserFailedAttemptCount(int userID, int numberOfFailedLoginAttempts);
        int UpdateUserFailedAttemptCountAndLastLoginDate(int userID, int failedAttemptCount, DateTime? loginDate);
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
        User GetUserRecordByEmailAndUserName(string emailID,string username);

        IEnumerable<User> GetAllSupplierUserBySupplierID(int _supplierID);
        void AddUserProject(UserProject _userProject);
        int DeleteUserProject(int referrerProjectID, int userID);

        IEnumerable<string> GetAllUserEmailsByCaseContactByCaseID(int CaseID);

        void UpdateUserSessionIDByUserID(int userId, string userSessionID);
        void ResetUserSessionID(int userID);

        int UpdatePasswordOTPByID(int _userID, string _passwordOTP);
    }
}
