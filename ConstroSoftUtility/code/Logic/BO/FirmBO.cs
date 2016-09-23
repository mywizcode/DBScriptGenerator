using System;
using NHibernate;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using ConstroSoft;
using System.Collections.Generic;
using NHibernate.Criterion;
using NHibernate.Transform;

/// <summary>
/// Summary description for FirmBO
/// </summary>
namespace ConstroSoft
{
    public class FirmBO
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public FirmBO() { }
        public FirmDTO fetchFirmDetails(string firmNumber)
        {
            ISession session = null;
            FirmDTO firmDto = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        Firm firm = session.QueryOver<Firm>().Where(f => f.FirmNumber == firmNumber).SingleOrDefault<Firm>();
                        firmDto = populateFirmDTO(firm);
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while Loading Firm details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
            return firmDto;
        }
        public void updateFirm(FirmDTO firmDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        Firm firm = session.Get<Firm>(firmDto.Id);
                        populateFirm(firm, firmDto);
                        session.Update(firm);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while Updating Firm:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void saveFirmAccount(FirmAccountDTO firmAccountDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        FirmAccount firmAccount = DTOToDomainUtil.populateFirmAccountAddFields(firmAccountDto);
                        session.Save(firmAccount);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while Updating Account:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void updateFirmAccount(FirmAccountDTO firmAccountDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        FirmAccount firmAccount = session.Get<FirmAccount>(firmAccountDto.Id);
                        DTOToDomainUtil.populateFirmAccountUpdateFields(firmAccount, firmAccountDto);
                        session.Update(firmAccount);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while Updating Account:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void deleteFirmAccount(long accountId)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        //TODO - need to validate whether account cannot be deleted is account balance is not 0
                        FirmAccount firmAccount = session.Get<FirmAccount>(accountId);
                        session.Delete(firmAccount);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while Deleting Account:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        private void populateFirm(Firm firm, FirmDTO firmDto)
        {
            firm.RegistrationNo = firmDto.RegistrationNo;
            firm.WebSite = firmDto.WebSite;
            firm.Description = firmDto.Description;
            DTOToDomainUtil.copyToContactInfo(firm.ContactInfo, firmDto.ContactInfo);
            firm.UpdateDate = DateTime.Now;
            firm.UpdateUser = firmDto.UpdateUser;
        }
        public FirmDTO populateFirmDTO(Firm firm)
        {
            FirmDTO firmDto = DomainToDTOUtil.convertToFirmDTO(firm, true);
            firmDto.FirmAccounts = new HashSet<FirmAccountDTO>();
            foreach (FirmAccount firmAcnt in firm.FirmAccounts)
            {
                firmDto.FirmAccounts.Add(DomainToDTOUtil.convertToFirmAccountDTO(firmAcnt, true));
            }
            return firmDto;
        }
    }
}