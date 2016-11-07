using Michèle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Michèle.DAL;
using System.Web.Helpers;
using System.Web.Security;

namespace Michèle.Filters
{
    public class CustomMembershipProvider : MembershipProvider
    {
        public override bool ValidateUser(string username, string password)
        {
            bool isValid = false;

            using (DatabaseContext _db = new DatabaseContext())
            {
                try
                {
                    User user = _db.Users.FirstOrDefault(e => e.Login == username);
                    if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                    {
                        isValid = true;
                    }
                }
                catch
                {
                    isValid = false;
                }
            }
            return isValid;
        }

        public MembershipUser CreateUser(string login, string password, string roleName = "user")
        {
            MembershipUser membershipUser = GetUser(login, false);

            if (membershipUser == null)
            {
                try
                {
                    using (DatabaseContext _db = new DatabaseContext())
                    {
                        User user = new User();
                        user.Id = Guid.NewGuid();
                        user.Login = login;
                        user.Password = Crypto.HashPassword(password);
                        user.CreationDate = DateTime.Now;
                        user.RoleId = _db.Roles.First(e => e.Name == roleName).Id;

                        _db.Users.Add(user);
                        _db.SaveChanges();
                        membershipUser = GetUser(login, false);
                        return membershipUser;
                    }
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        public override MembershipUser GetUser(string login, bool userIsOnline)
        {
            try
            {
                using (DatabaseContext _db = new DatabaseContext())
                {
                    var users = _db.Users.Where(e => e.Login == login);
                    if (users.Any())
                    {
                        User user = users.First();
                        MembershipUser memberUser = new MembershipUser("MyMembershipProvider", user.Login, null, null, null, null,
                            false, false, user.CreationDate, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                        return memberUser;
                    }
                }
            }
            catch
            {
                return null;
            }
            return null;
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }
        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }
        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }
        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }
        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }
        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }
        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }
        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }
        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }
        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }
        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }
        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }
        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }
        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }
    }
}