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
/// Summary description for MasterDataBO
/// </summary>
namespace ConstroSoft
{
    public class MasterDataBO
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public MasterDataBO() { }
        public void saveMasterData(MasterControlDataDTO masterDataDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        MasterControlData masterData = DTOToDomainUtil.populateMasterDataAddFields(masterDataDto);
                        session.Save(masterData);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while saving MasterData details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void updateMasterData(MasterControlDataDTO masterDataDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        MasterControlData masterData = session.Get<MasterControlData>(masterDataDto.Id);
                        DTOToDomainUtil.populateMasterDataUpdateFields(masterData, masterDataDto);
                        session.Update(masterData);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while updating MasterData details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void deleteMasterData(long Id)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        MasterControlData masterData = session.Get<MasterControlData>(Id);
                        session.Delete(masterData);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while deleting MasterData details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public bool isAlreadyExist(MasterControlDataDTO masterDataDto)
        {
            ISession session = null;
            bool isExist = false;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        MasterControlData masterData = session.QueryOver<MasterControlData>()
                                .Where(x => x.FirmNumber == masterDataDto.FirmNumber && x.Type == masterDataDto.Type)
                                .WhereRestrictionOn(x => x.Name).IsInsensitiveLike(masterDataDto.Name).SingleOrDefault<MasterControlData>();
                        if (masterData != null) isExist = true;
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while validating duplicate MasterData:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
            return isExist;
        }
    }
}