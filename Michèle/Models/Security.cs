using Michèle.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebMatrix.WebData;



namespace Michèle.Models
{
    public class Security
    {
        public static void CreateUser(string login, string password, string roleName = "user")
        {
            ((CustomMembershipProvider) Membership.Provider).CreateUser(login, password, roleName);
        }

        public static void CreateRole(string roleName)
        {
            CustomRoleProvider crp = new CustomRoleProvider();
            crp.CreateRole(roleName);
        }
    }
}