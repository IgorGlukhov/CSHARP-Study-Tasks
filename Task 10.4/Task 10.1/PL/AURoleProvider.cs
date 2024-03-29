using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Task_10._1.PL
{
    public class AURoleProvider : RoleProvider
    {
        public override string[] GetRolesForUser(string username)
        {
            if (username.StartsWith("admin"))
            {
                return new[] { "Admins", "Users" };
            } else
            {
                return new[] { "Users" };
            }
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            if (roleName=="Users")
            {
                return true;
            }
            if (roleName == "Admins")
            {
                return username.StartsWith("admin" );
            }
            return false;
        }

        #region Not implemented
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}