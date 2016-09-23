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
/// Summary description for SupplierBO
/// </summary>
namespace ConstroSoft
{
    public class EnquiryBO
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public EnquiryBO() { }
        public IList<EnquiryDetailDTO> fetchEnquiryGridData(string firmNumber)
        {
            ISession session = null;
            IList<EnquiryDetailDTO> results = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                EnquiryDetailDTO enquiryDto = null;
                MasterControlDataDTO PropertyTypeDto = null;
                PropertyDTO propertyDto = null;
                MasterControlDataDTO PrUnitTypeDto = null;
                MasterControlDataDTO PropertyLocationDto = null;
                results = session.QueryOver<EnquiryDetail>()
                    .Left.JoinAlias(enq => enq.PropertyType, () => PropertyTypeDto)
                    .Left.JoinAlias(enq => enq.Property, () => propertyDto)
                    .Left.JoinAlias(enq => enq.PrUnitType, () => PrUnitTypeDto)
                    .Left.JoinAlias(enq => enq.PropertyLocation, () => PropertyLocationDto)
                    .SelectList(enq => enq.Select(e => e.Id).WithAlias(() => enquiryDto.Id)
                        .Select(e => e.FirstName).WithAlias(() => enquiryDto.FirstName)
                        .Select(e => e.LastName).WithAlias(() => enquiryDto.LastName)
                        .Select(e => e.EnquiryDate).WithAlias(() => enquiryDto.EnquiryDate)
                        //.Select(e => e.PropertyType.Name).WithAlias(() => enquiryDto.PropertyType.Name)
                        //.Select(e => e.Property.Name).WithAlias(() => enquiryDto.Property.Name)
                        //.Select(e => e.PropertyLocation.Name).WithAlias(() => enquiryDto.PropertyLocation.Name)
                        //.Select(e => e.PrUnitType.Name).WithAlias(() => enquiryDto.PrUnitType.Name)
                        .Select(e => e.Status).WithAlias(() => enquiryDto.Status)
                    )
                     .TransformUsing(Transformers.AliasToBean<EnquiryDetailDTO>())
                    .List<EnquiryDetailDTO>();
            }
            catch (Exception exp)
            {
                log.Error("Unexpected error populating dropdown:");
                log.Error(exp.Message, exp);
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
            return results;
        }
        public EnquiryDetailDTO fetchEnquiryDetails(long Id)
        {
            ISession session = null;
            EnquiryDetailDTO enquiryDto = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        EnquiryDetail enquiry = session.Get<EnquiryDetail>(Id);
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while Loading Enquiry details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
            return enquiryDto;
        }
        public void saveEnquiryDetails(EnquiryDetailDTO enquiryDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        EnquiryDetail enquiry = DTOToDomainUtil.populateEnquiryDetailAddFields(enquiryDto);
                        session.Save(enquiry);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while saving Enquiry details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void updateEnquiryDetails(EnquiryDetailDTO enquiryDto)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        EnquiryDetail enquiry = session.Get<EnquiryDetail>(enquiryDto.Id);
                        DTOToDomainUtil.populateEnquiryDetailUpdateFields(enquiry, enquiryDto);
                        session.Update(enquiry);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while updating Enquiry details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        public void deleteEnquiryDetails(long Id)
        {
            ISession session = null;
            try
            {
                session = NHibertnateSession.OpenSession();
                using (ITransaction tx = session.BeginTransaction())
                {
                    try
                    {
                        EnquiryDetail enquiry = session.Get<EnquiryDetail>(Id);
                        session.Delete(enquiry);
                        tx.Commit();
                    }
                    catch (Exception e)
                    {
                        tx.Rollback();
                        log.Error("Exception while deleting Enquiry details:", e);
                        throw new Exception(Resources.Messages.system_error);
                    }
                }
            }
            finally
            {
                NHibertnateSession.closeSession(session);
            }
        }
        
        public void populateEnquiryDetailsDTO(EnquiryDetail enquiryDtl)
        {
            EnquiryDetailDTO enquiryDtlDTO = new EnquiryDetailDTO();
            MasterControlDataDTO masterControlDTO = new MasterControlDataDTO();

        }
    }
}