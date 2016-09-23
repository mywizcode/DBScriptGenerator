using System;
using NHibernate;
using System.Collections.Generic;
using NHibernate.Transform;
using System.Reflection;
using System.Collections;
using NHibernate.Criterion;
using System.Linq.Expressions;
using NHibernate.Impl;

/// <summary>
/// Summary description for EmployeeBO
/// </summary>
namespace ConstroSoft
{
    public class EmployeeBO
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public EmployeeBO() { }
        public static void FilterQueryByDepartment(
            IQueryOver<FirmMember, FirmMember> query,
            Expression<Func<object>> dp, long departmentId)
        {
            PropertyProjection prop = CommonUtil.BuildProjection<Department>(dp, pr => pr.Id);
            query.Where(Restrictions.Eq(prop, departmentId));
        }

        public IList<FirmMemberDTO> fetchEmployeeGridData(string firmNumber, string selectBy, long selectByValue)
        {
            ISession session = null;
            IList<FirmMemberDTO> result = new List<FirmMemberDTO>();
            try
            {
                session = NHibertnateSession.OpenSession();
                FirmMember fm = null;
                ContactInfo c = null;
                Department dp = null;
                MasterControlData dg = null;
                FirmMemberDTO fmDto = null;
                
                var proj = Projections.ProjectionList()
                            .Add(Projections.Property(() => fm.Id).WithAlias(() => fmDto.Id))
                            .Add(Projections.SqlFunction("concat",
                                        NHibernateUtil.String,
                                        Projections.Property(() => fm.FirstName),
                                        Projections.Constant(" "),
                                        Projections.Property(() => fm.LastName)
                                    ).WithAlias(() => fm.FirstName))
                            .Add(Projections.Property(() => fm.EmployeeId).WithAlias(() => fmDto.EmployeeId))
                            .Add(Projections.Property(() => dp.Name), "Department.Name")
                            .Add(Projections.Property(() => dg.Name), "Designation.Name")
                            .Add(Projections.Property(() => c.Contact), "ContactInfo.Contact")
                            .Add(Projections.Property(() => fm.JoiningDate).WithAlias(() => fmDto.JoiningDate))
                            .Add(Projections.Property(() => c.Email), "ContactInfo.Email");
                var query = session.QueryOver<FirmMember>(() => fm)
                    .Inner.JoinAlias(() => fm.ContactInfo, () => c)
                    .Left.JoinAlias(() => fm.Department, () => dp)
                    .Left.JoinAlias(() => fm.Designation, () => dg);
                if (!string.IsNullOrWhiteSpace(selectBy))
                {
                    //FilterQueryByDepartment(query, () => dp, selectByValue);
                    PropertyProjection prop = CommonUtil.BuildProjection<Department>(() => dp, pr => pr.Id);
                    query.Where(Restrictions.Eq(prop, selectByValue));
                }
                result = query.Where(() => fm.FirmNumber == firmNumber)
                    .Select(proj)
                    .TransformUsing(new DeepTransformer<FirmMemberDTO>()).List<FirmMemberDTO>();
                /*result = session.QueryOver<FirmMember>(() => fm)
                    .Inner.JoinAlias(() => fm.ContactInfo, () => c)
                    .Left.JoinAlias(() => fm.Department, () => dp)
                    .Left.JoinAlias(() => fm.Designation, () => dg)
                    .Where(() => fm.FirmNumber == firmNumber)
                    .Select(proj)
                    .TransformUsing(new DeepTransformer<FirmMemberDTO>()).List<FirmMemberDTO>();*/
            }
            catch (Exception exp) {
                log.Error("Unexpected error populating dropdown:");
                log.Error(exp.Message, exp);
            } finally {
                NHibertnateSession.closeSession(session);
            }
            return result;
        }
        public FirmMemberDTO fetchEmployee(long Id)
        {
            ISession session = null;
            FirmMemberDTO employeeDto = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        FirmMember employee = session.Get<FirmMember>(Id);
                        employeeDto = DomainToDTOUtil.convertToFirmMemberDTO(employee, true);
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while Loading Employee details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
            return employeeDto;
        }
        public long saveEmployee(FirmMemberDTO employeeDto)
        {
            ISession session = null;
            long Id = -1;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        Random rd = new Random();
                        employeeDto.EmployeeId = "E" + rd.Next(100, 10000);
                        FirmMember employee = DTOToDomainUtil.populateFirmMemberAddFields(employeeDto);
                        session.Save(employee);
                        employee.EmployeeId = "E" + employee.Id;
                        session.Update(employee);
                        Id = employee.Id;
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while saving Employee details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
            return Id;
        }
        public void updateEmployee(FirmMemberDTO employeeDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        FirmMember employee = session.Get<FirmMember>(employeeDto.Id);
                        DTOToDomainUtil.populateFirmMemberUpdateFields(employee, employeeDto);
                        session.Update(employee);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while updating Employee details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void deleteEmployee(long Id)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        FirmMember employee = session.Get<FirmMember>(Id);
                        session.Delete(employee);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while deleting Employee details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
    }
}