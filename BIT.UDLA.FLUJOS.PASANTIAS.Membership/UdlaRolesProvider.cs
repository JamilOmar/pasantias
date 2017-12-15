using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIT.UDLA.FLUJOS.PASANTIAS.Membership
{
    public class UdlaRolesProvider : System.Web.Security.RoleProvider
    {

        List<string> Roles = new List<string>
        {
            "Empresas"
        };

        static string providerName = "UdlaRolesProvider";
        string applicationName = "UDLAEmpresas";
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }
       
        public override string ApplicationName
        {
            get
            {
                return applicationName;
            }
            set
            {
                applicationName = value;
            }
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
            return Roles.ToArray() ;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            return Roles.Exists(x=>x==roleName);
        }
    }
}
