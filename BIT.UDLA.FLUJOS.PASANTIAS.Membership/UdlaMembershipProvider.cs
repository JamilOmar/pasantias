using System.Web.Security;
using System.Configuration.Provider;
using System.Collections.Specialized;
using System;
using System.Data;
using System.Data.Odbc;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using BIT.UDLA.FLUJOS.PASANTIAS.Entities;
using BIT.UDLA.FLUJOS.PASANTIAS.Logic;
using System.Collections.Generic;


namespace BIT.UDLA.FLUJOS.PASANTIAS.Membership
{
    public class UdlaMembershipProvider :MembershipProvider
    {
        UsuarioEmpresaLogic obj = new UsuarioEmpresaLogic();
        const string providerName = "UdlaMembershipProvider";
        string applicationName = "UDLAEmpresas";
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
            return MapToUser( obj.GetUsersbyEmail(emailToMatch, pageIndex, pageSize, out totalRecords));
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return MapToUser(obj.GetUsersbyUserName(usernameToMatch, pageIndex, pageSize, out totalRecords));
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            return MapToUser(obj.GetAllUsers( pageIndex, pageSize, out totalRecords));
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            return MapToUser(obj.GetUser(username));
        }
      

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            return MapToUser(obj.GetUserbyKey( providerUserKey.ToString()));
        }

        public override string GetUserNameByEmail(string email)
        {
           var data=  obj.GetUserByEmail(email);
           if (data != null)
               return data.UserName;
           else
               return string.Empty;
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

        public override bool ValidateUser(string username, string password)
        {
            return obj.IsValidUser(username, password);
        }
        public MembershipUser MapToUser(UsuarioEmpresa usuario)
        {
            if (usuario != null)
            {
                MembershipUser user = new MembershipUser(providerName, usuario.UserName, usuario.UniqueID,
                    usuario.Email, string.Empty, "USUARIO EMPRESA UDLA", usuario.EsValido, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now);
                return user;
            } return null;
        }
        
        public MembershipUserCollection MapToUser(List<UsuarioEmpresa> usuarios)
        {
            MembershipUserCollection collection = new MembershipUserCollection();
            foreach (var usuario in usuarios)
            {
                MembershipUser user = MapToUser(usuario);
                collection.Add(user);
                
            }
          

            return collection;

        }
            
    }
}
