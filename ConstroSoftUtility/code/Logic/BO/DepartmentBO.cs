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
/// Summary description for DepartmentBO
/// </summary>
namespace ConstroSoft
{
    public class DepartmentBO
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DepartmentBO() { }
        public void saveDepartment(DepartmentDTO departmentDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        Department department = DTOToDomainUtil.populateDepartmentAddFields(departmentDto);
                        Firm firm = session.QueryOver<Firm>().Where(f => f.FirmNumber == departmentDto.FirmNumber).SingleOrDefault<Firm>();
                        department.Firm = firm;
                        session.Save(department);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while saving Department details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void updateDepartment(Department departmentDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        Department department = session.Get<Department>(departmentDto.Id);
                        //DTOToDomainUtil.populateDepartmentUpdateFields(masterData, masterDataDto);
                        session.Update(department);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while updating Department details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void deleteDepartment(long Id)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        Department department = session.Get<Department>(Id);
                        session.Delete(department);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while deleting Department details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public bool isAlreadyExist(DepartmentDTO departmentDto)
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
                        Department department = session.QueryOver<Department>()
                                .Where(x => x.FirmNumber == departmentDto.FirmNumber)
                                .WhereRestrictionOn(x => x.Name).IsInsensitiveLike(departmentDto.Name)
                                .SingleOrDefault<Department>();
                        if (department != null) isExist = true;
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while validating duplicate Department:", e);
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