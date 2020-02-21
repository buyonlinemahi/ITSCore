using Core.Base.Data.SqlServer;
using Core.Base.Data.SqlServer.Factory;
using Core.Base.Data.SqlServer.Repository;
using ITS.Core.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
/*
 Page Name:  UserRepository.cs                       
  Version:  1.7                                              
  Purpose: Method(GetUserByUserTypeID) to get the users by UsertypeId
  Revision History:                                        
                                                           
    1.0 – 10/26/2012 Satya 
 *  1.1 – 10/26/2012 Vijay
 *  
 *  add GetUserByUserNameAutoComplete method to get user autocomplete
 * 1.2 - 10/26/2012 Anuj 
 * Added a method to lock unlock user
 
 * Edited By : Pardeep
 * Date : 27-Oct-2012
 * Version : 1.3
 * Description : Added a Method to retreive the user information by Id (UserId)
 
 * Edited By : Manjit Singh
 * Date : 3-Nov-2012
 * Version : 1.4
 * Description : Added a Method to Add User
 * 
 * Edited By : Vijay Kumar
 * Date : 3-Nov-2012
 * Version : 1.5
 * Description : Added a Method to update User
 * 
 * Edited By : Satya
 * Date : 6-Nov-2012
 * Version : 1.6
 * Description : Method to Update User by UserId
 * 
 * Edited By : Anuj Batra
 * Date : 28-Dec-2012
 * Version : 1.7
 * Description : Added a Method(GetUserByUserTypeID) to get the users by UsertypeId.
 */

namespace ITS.Core.Data.SqlServer.Repository
{
    public class UserRepository : BaseRepository<User, ITSDBContext>, IUserRepository
    {
        public UserRepository(IContextFactory<ITSDBContext> contextFactory) :
            base(new BaseUnitOfWork<ITSDBContext>(contextFactory), contextFactory)
        {
        }
        /// <summary>
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUserByUserName(string userName)
        {
            SqlParameter uname = new SqlParameter("@UserName", userName);
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserbyUserName, uname).SingleOrDefault<User>();
        }

        public void ResetUserPassword(int userId, string UserPasssword)
        {
            SqlParameter _userId = new SqlParameter("@UserId", userId);
            SqlParameter _userPasssword = new SqlParameter("@UserPasssword", UserPasssword);
            Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.ResetUserPassword, _userId, _userPasssword);
        }

        public User GetUserRecordByEmailID(string emailID)
        {
            SqlParameter _emailID = new SqlParameter("@EmailID", emailID);
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserRecordByEmailID, _emailID).FirstOrDefault<User>();
        }

        public User GetUserRecordByEmailAndUserName(string emailID, string username)
        {
            SqlParameter _emailID = new SqlParameter("@EmailID", emailID);
            SqlParameter _userName = new SqlParameter("@Username", username);
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserRecordByEmailAndUserName, _emailID, _userName).FirstOrDefault<User>();
        }
        public IEnumerable<User> GetUserByUserNameAutoComplete(string userNameLike)
        {
            SqlParameter uname = new SqlParameter("@userName", userNameLike);
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUsersLikeUsername, uname);
        }
        /// <summary>
        /// Method to Lock and Unlock the user
        /// </summary>
        /// <param name="uid"></param>
        /// <param name="locked"></param>
        /// <returns></returns>
        public int UpdateUserLock(int userID, bool locked)
        {
            SqlParameter UserID = new SqlParameter("@UserID", userID);
            SqlParameter IsLocked = new SqlParameter("@IsLocked", locked);

            int i = Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.UpdateUserLock, UserID, IsLocked);

            return i;
        }

        public int UpdatePasswordOTPByID(int _userID, string _passwordOTP)
        {
            SqlParameter userID = new SqlParameter("@UserID", _userID);
            SqlParameter passwordOTP = new SqlParameter("@PasswordOTP", _passwordOTP);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.UpdatePasswordOTPByID, userID, passwordOTP);
        }



        /// <summary>
        /// Method to retreive the user information by UserId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public User GetUserByUserId(int userId)
        {
            SqlParameter UserId = new SqlParameter("@UserID", userId);
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.UserInfoByUserID, UserId).SingleOrDefault<User>();
        }

        /// <summary>
        /// Method to retreive the user information by UserId
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<User> GetAllSupplierUserBySupplierID(int _supplierID)
        {
            SqlParameter supplierID = new SqlParameter("@SupplierID", _supplierID);
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.GetAllSupplierUserBySupplierID, supplierID);
        }

        public int AddUser(User user)
        {
            SqlParameter _UserName  = new SqlParameter("@UserName", user.UserName);
            SqlParameter _Password  = new SqlParameter("@Password", user.Password);
            SqlParameter _FirstName = new SqlParameter("@FirstName", !string.IsNullOrEmpty(user.FirstName) ? (object)user.FirstName : System.DBNull.Value);
            SqlParameter _LastName = new SqlParameter("@LastName", !string.IsNullOrEmpty(user.LastName) ? (object)user.LastName : System.DBNull.Value);
            SqlParameter _UserTypeID  = new SqlParameter("@UserTypeID", user.UserTypeID);
            SqlParameter _IsLocked = new SqlParameter("@IsLocked", user.IsLocked);
            SqlParameter _SupplierTypes = new SqlParameter("@SupplierTypes", user.SupplierTypes);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", user.SupplierID.HasValue ? (object)user.SupplierID.Value : System.DBNull.Value);
            SqlParameter _ReferrerTypes = new SqlParameter("@ReferrerTypes", user.ReferrerTypes);
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", user.ReferrerID.HasValue ? (object)user.ReferrerID.Value : System.DBNull.Value);           
            SqlParameter _ReferrerLocationID = new SqlParameter("@ReferrerLocationID", user.ReferrerLocationID.HasValue ? (object)user.ReferrerLocationID.Value : System.DBNull.Value);
            SqlParameter _Email = new SqlParameter("@Email", !string.IsNullOrEmpty(user.Email) ? (object)user.Email : System.DBNull.Value);
            SqlParameter _Fax = new SqlParameter("@Fax", !string.IsNullOrEmpty(user.Fax) ? (object)user.Fax : System.DBNull.Value);
            SqlParameter _Telephone = new SqlParameter("@Telephone", !string.IsNullOrEmpty(user.Telephone) ? (object)user.Telephone : System.DBNull.Value);
            return (int)Context.Database.SqlQuery<decimal>(Global.StoredProcedureConst.UserRepositoryProcedures.AddUser, _UserName, _Password, _FirstName, _LastName, _UserTypeID, _IsLocked, _SupplierTypes, _SupplierID, _ReferrerTypes, _ReferrerID, _ReferrerLocationID, _Email, _Fax, _Telephone).SingleOrDefault();
  

        }
        /// <summary>
        /// Method to Update User by UserId
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUserByUserID(User user)
        {
            SqlParameter _UserID = new SqlParameter("@UserID", user.UserID);
            SqlParameter _UserName = new SqlParameter("@UserName", user.UserName);
            SqlParameter _Password = new SqlParameter("@Password", user.Password);
            SqlParameter _FirstName = new SqlParameter("@FirstName", !string.IsNullOrEmpty(user.FirstName) ? (object)user.FirstName : System.DBNull.Value);
            SqlParameter _LastName = new SqlParameter("@LastName", !string.IsNullOrEmpty(user.LastName) ? (object)user.LastName : System.DBNull.Value);
            SqlParameter _UserTypeID = new SqlParameter("@UserTypeID", user.UserTypeID);
            SqlParameter _SupplierTypes = new SqlParameter("@SupplierTypes", user.SupplierTypes);
            SqlParameter _SupplierID = new SqlParameter("@SupplierID", user.SupplierID.HasValue ? (object)user.SupplierID.Value : System.DBNull.Value);
            SqlParameter _ReferrerTypes = new SqlParameter("@ReferrerTypes", user.ReferrerTypes);
            SqlParameter _ReferrerID = new SqlParameter("@ReferrerID", user.ReferrerID.HasValue ? (object)user.ReferrerID.Value : System.DBNull.Value);
            SqlParameter _ReferrerLocationID = new SqlParameter("@ReferrerLocationID", user.ReferrerLocationID.HasValue ? (object)user.ReferrerLocationID.Value : System.DBNull.Value);
            SqlParameter _Email = new SqlParameter("@Email", !string.IsNullOrEmpty(user.Email) ? (object)user.Email : System.DBNull.Value);
            SqlParameter _Fax = new SqlParameter("@Fax", !string.IsNullOrEmpty(user.Fax) ? (object)user.Fax : System.DBNull.Value);
            SqlParameter _Telephone = new SqlParameter("@Telephone", !string.IsNullOrEmpty(user.Telephone) ? (object)user.Telephone : System.DBNull.Value);
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.UpdateUser, _UserID, _UserName, _Password, _FirstName, _LastName, _UserTypeID, _SupplierTypes, _SupplierID, _ReferrerTypes, _ReferrerID, _ReferrerLocationID, _Email, _Fax, _Telephone);
        }


        public IEnumerable<User> GetUserByUserTypeID(int userTypeID)
        {
            SqlParameter userTypeId = new SqlParameter("@UserTypeID", userTypeID);
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserByUserTypeID, userTypeId);
        }

        public IEnumerable<User> GetReferrerUsersByCaseID(int CaseID)
        {
            SqlParameter _CaseID = new SqlParameter("@CaseID", CaseID);
          
            return
              Context.Database.SqlQuery<User>(
                  Global.StoredProcedureConst.UserRepositoryProcedures.GetReferrerUsersByCaseID, _CaseID);                  
        }

        public IEnumerable<User> GetReferrerUsersByID(int referrerID)
        {
            SqlParameter _referrerID = new SqlParameter("@ReferrerID", referrerID);
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.GetReferrerUsersByID,_referrerID);
        }

        public int UpdateUserFailedAttemptCount(int userID, int numberOfFailedLoginAttempts)
        {
            SqlParameter _UserID = new SqlParameter("@UserID", userID);
            SqlParameter _NumberOfFailedLoginAttempts = new SqlParameter("@NumberOfFailedLoginAttempts", numberOfFailedLoginAttempts);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.UpdateUserFailedAttemptCount, _UserID, _NumberOfFailedLoginAttempts);

        }


        public int UpdateUserFailedAttemptCountAndLastLoginDate(int userID, int failedAttemptCount, DateTime? loginDate)
        {
            SqlParameter _UserID = new SqlParameter("@UserID", userID);
            SqlParameter _FailedAttemptCount = new SqlParameter("@FailedAttemptCount", failedAttemptCount);
            SqlParameter _LoginDate = new SqlParameter("@LoginDate", loginDate.HasValue ? (object)loginDate.Value : System.DBNull.Value);

            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.UpdateUserFailedAttemptCountAndLastLoginDate, _UserID, _FailedAttemptCount, _LoginDate);
        }

        public IEnumerable<User> GetUsersRecentlyAdded()
        {
            return Context.Database.SqlQuery<User>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUsersRecentlyAdded);
        }


        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeUsername(string username, int skip, int take)
        {
            SqlParameter _username = new SqlParameter("@UserName", username);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<UserTypeUser>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeUsername, _username, _skip, _take);
        }

        public int GetUserTypeUsersLikeUsernameCount(string username)
        {
            SqlParameter _username = new SqlParameter("@UserName", username);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeUsernameCount, _username).SingleOrDefault();
        }

        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeUserType(string userType, int skip, int take)
        {
            SqlParameter _userType = new SqlParameter("@UserType", userType);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<UserTypeUser>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeUserType, _userType, _skip, _take);
        }

        public int GetUserTypeUsersLikeUserTypeCount(string userType)
        {
            SqlParameter _userType = new SqlParameter("@UserType", userType);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeUserTypeCount, _userType).SingleOrDefault();
        }

        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeName(string name, int skip, int take)
        {
            SqlParameter _name = new SqlParameter("@Name", name);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<UserTypeUser>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeName, _name, _skip, _take);
        }

        public int GetUserTypeUsersLikeNameCount(string name)
        {
            SqlParameter _name = new SqlParameter("@Name", name);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeNameCount, _name).SingleOrDefault();
        }


        public bool GetUserExistsByName(string name)
        {
            SqlParameter _UserName = new SqlParameter("@UserName", name);
            return (bool)Context.Database.SqlQuery<bool>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserExistsByName, _UserName).SingleOrDefault();
        }


        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeReferrerName(string referrerName, int skip, int take)
        {
            SqlParameter _referrerName = new SqlParameter("@ReferrerName", referrerName);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<UserTypeUser>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeReferrerName, _referrerName, _skip, _take);
        }

        public int GetUserTypeUsersLikeReferrerNameCount(string referrerName)
        {
            SqlParameter _referrerName = new SqlParameter("@ReferrerName", referrerName);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeReferrerNameCount, _referrerName).SingleOrDefault();
        }

        public IEnumerable<UserTypeUser> GetUserTypeUsersLikeSupplierName(string supplierName, int skip, int take)
        {
            SqlParameter _supplierName = new SqlParameter("@SupplierName", supplierName);
            SqlParameter _skip = new SqlParameter("@Skip", skip);
            SqlParameter _take = new SqlParameter("@Take", take);

            return Context.Database.SqlQuery<UserTypeUser>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeSupplierName, _supplierName, _skip, _take);
        }

        public int GetUserTypeUsersLikeSupplierNameCount(string supplierName)
        {
            SqlParameter _supplierName = new SqlParameter("@SupplierName", supplierName);
            return (int)Context.Database.SqlQuery<int>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserTypeUsersLikeSupplierNameCount, _supplierName).SingleOrDefault();
        }

        public void AddUserProject(UserProject _userProject)
        {
            SqlParameter[] param = { 
                                       new SqlParameter("@ReferrerProjectID", _userProject.ReferrerProjectID),                                   
                                       new SqlParameter("@UserID", _userProject.UserID)
                                   };
            Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.AddUserProject, param);
        }

        public int DeleteUserProject(int referrerProjectID, int userID)
        {
            SqlParameter[] param = { 
                                       new SqlParameter("@referrerProjectID", referrerProjectID),                                   
                                       new SqlParameter("@userID", userID)
                                   };
            return Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.DeleteUserProject, param);
        }

        public IEnumerable<string> GetAllUserEmailsByCaseContactByCaseID(int CaseID)
        {
            SqlParameter _caseID = new SqlParameter("@CaseID", CaseID);
            return Context.Database.SqlQuery<string>(Global.StoredProcedureConst.UserRepositoryProcedures.GetUserEmailsByCaseContactByCaseID, _caseID);
        }


        public void UpdateUserSessionIDByUserID(int userId, string userSessionID)
        {
            SqlParameter _userId = new SqlParameter("@UserID", userId);
            SqlParameter _userSessionID = new SqlParameter("@UserSessionID", userSessionID);
            Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.UpdateUserSessionIDByUserID, _userId, _userSessionID);
        }

        public void ResetUserSessionID(int UserID)
        {
            SqlParameter _userID = new SqlParameter("@UserID", UserID);
            Context.Database.ExecuteSqlCommand(Global.StoredProcedureConst.UserRepositoryProcedures.ResetUserSessionID, _userID);
        }
    }
}

