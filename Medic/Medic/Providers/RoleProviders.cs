using Medic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Medic.Providers
{
    public class RoleProviders : RoleProvider
    {
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

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            using (MedicContext db = new MedicContext())
            {
                User user = null;
                user = db.Users.FirstOrDefault(u => u.Email == username); 

                if (user != null)
                {
                    Permission userPermission = db.Permissions.Find(user.PermissionId);
                    if (userPermission != null)
                        roles = new string[] { userPermission.PerName };
                }
            }
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            bool outputResult = false;
            using (MedicContext db = new MedicContext())
            {
                User user = null;
                user = db.Users.FirstOrDefault(u => u.Email == username);

                if (user != null)
                {
                    User userRole = db.Users.Find(user.PermissionId);
                    if (userRole != null && userRole.Name == roleName)
                        outputResult = true; ;
                }
            }
            return outputResult;
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}