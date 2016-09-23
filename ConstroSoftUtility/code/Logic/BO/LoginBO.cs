using System;
using NHibernate;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using ConstroSoft;
using System.Collections.Generic;

/// <summary>
/// Summary description for SupplierBO
/// </summary>
namespace ConstroSoft
{
    public class LoginBO
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public LoginBO()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public BusinessOutputTO validateUser(string userName, string password)
        {
            BusinessOutputTO businessTO = new BusinessOutputTO();
            ISession session = null;
            log.Debug("Validating user login");
            try
            {
                bool result = false;
                session = NHibertnateSession.OpenSession();
                IList<UserDefinition> userDefList = session.QueryOver<UserDefinition>().Where(x => x.Username == userName).List();
                if (userDefList != null && userDefList.Count > 0)
                {
                    UserDefinition userDef = userDefList[0];
                    if (password.Equals(Decrypt(userDef.Password)))
                    {
                        log.Debug("Login Successful for user:" + userName);
                        businessTO.result = getUserDefinitionDTO(userDef);
                        result = true;
                    }
                }
                if (!result)
                {
                    log.Debug("Login Failed for user:" + userName);
                    businessTO.setErrorMessage(Resources.Messages.login_error_failed);
                }
            }
            catch (Exception exp)
            {
                log.Error("Unexpected error while login:" + userName);
                log.Error(exp.Message, exp);
                businessTO.setErrorMessage(Resources.Messages.system_error);
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
            return businessTO;
        }
        private UserDefinitionDTO getUserDefinitionDTO(UserDefinition userDef)
        {
            UserDefinitionDTO userDefDTO = new UserDefinitionDTO();
            userDefDTO.Username = userDef.Username;
            userDefDTO.UserRole = new UserRoleDTO();
            userDefDTO.UserRole.Name = userDef.UserRole.Name;
            userDefDTO.FirstName = userDef.FirstName;
            userDefDTO.LastName = userDef.LastName;
            userDefDTO.FirmNumber = userDef.FirmNumber;
            ISet<UserEntitlement> entitlements = userDef.UserRole.UserEntitlements;
            userDefDTO.UserRole.entitlements = new List<string>();
            foreach (UserEntitlement tmpEntitlement in entitlements)
            {
                userDefDTO.UserRole.entitlements.Add(tmpEntitlement.Name);
            }

            return userDefDTO;
        }
        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
    }
}