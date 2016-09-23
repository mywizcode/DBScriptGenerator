using System;
using System.Web.UI.WebControls;
using NHibernate;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Summary description for DropdownBO
/// </summary>
namespace ConstroSoft
{
    public class DropdownBO
    {
        private static readonly log4net.ILog log =
               log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public DropdownBO(){}
        public void drpGeneric(DropDownList drp, string drpType, DrpDataType drpDataType, string additionalInfo, string[] firstItem,
            string firmNumber)
        {
            drp.Items.Clear();
            if (firstItem != null) drp.Items.Add(new ListItem(firstItem[0], firstItem[1]));
            if (Constants.DropDownType.STATIC_VALUE.Equals(drpType))
            {
                populateDrpStaticData(drp, drpDataType);
            }
            else if (Constants.DropDownType.DB_VALUE.Equals(drpType))
            {
                ISession session = null;
                try
                {
                    session = NHibertnateSession.OpenSession();
                    using (ITransaction tx = session.BeginTransaction())
                    {
                        try
                        {
                            session = NHibertnateSession.OpenSession();
                            IList<object[]> result = getDrpItems(session, drpDataType, additionalInfo, firmNumber);
                            addItemsToDropDown(drp, result);
                        }
                        catch (Exception e)
                        {
                            tx.Rollback();
                            log.Error("Unexpected error populating dropdown:", e);
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
        private void populateDrpStaticData(DropDownList drp, DrpDataType drpDataType)
        {
            if (DrpDataType.ENQUIRY_SEARCH_BY == drpDataType)
            {
                drp.Items.Add(new ListItem(Constants.DropDownItem.EnquirySearchBy.CUSTOMER_NAME, Constants.DropDownItem.EnquirySearchBy.CUSTOMER_NAME));
                drp.Items.Add(new ListItem(Constants.DropDownItem.EnquirySearchBy.PROP_NAME, Constants.DropDownItem.EnquirySearchBy.PROP_NAME));
                drp.Items.Add(new ListItem(Constants.DropDownItem.EnquirySearchBy.PROP_TYPE, Constants.DropDownItem.EnquirySearchBy.PROP_TYPE));
                drp.Items.Add(new ListItem(Constants.DropDownItem.EnquirySearchBy.PROP_LOCATION, Constants.DropDownItem.EnquirySearchBy.PROP_LOCATION));
                drp.Items.Add(new ListItem(Constants.DropDownItem.EnquirySearchBy.PROP_UNIT_TYPE, Constants.DropDownItem.EnquirySearchBy.PROP_UNIT_TYPE));
            }
            else if (DrpDataType.ENQUIRY_STATUS == drpDataType)
            {
                drp.Items.Add(new ListItem(Constants.DropDownItem.EnquiryStatus.OPEN, Constants.DropDownItem.EnquiryStatus.OPEN));
                drp.Items.Add(new ListItem(Constants.DropDownItem.EnquiryStatus.CLOSED, Constants.DropDownItem.EnquiryStatus.CLOSED));
            }
            else if (DrpDataType.GENDER == drpDataType)
            {
                drp.Items.Add(new ListItem(Constants.DropDownItem.Gender.MALE, Constants.DropDownItem.Gender.MALE_VALUE));
                drp.Items.Add(new ListItem(Constants.DropDownItem.Gender.FEMALE, Constants.DropDownItem.Gender.FEMALE_VALUE));
            }
            else if (DrpDataType.MARITAL_STATUS == drpDataType)
            {
                drp.Items.Add(new ListItem(Constants.DropDownItem.MaritalStatus.SINGLE, Constants.DropDownItem.MaritalStatus.SINGLE_VALUE));
                drp.Items.Add(new ListItem(Constants.DropDownItem.MaritalStatus.MARRIED, Constants.DropDownItem.MaritalStatus.MARRIED_VALUE));
            }
            else if (DrpDataType.EMPLOYEE_SEARCH_BY == drpDataType)
            {
                drp.Items.Add(new ListItem(Constants.DropDownItem.EmployeeSearchBy.EMPLOYEE_NAME, Constants.DropDownItem.EmployeeSearchBy.EMPLOYEE_NAME));
                drp.Items.Add(new ListItem(Constants.DropDownItem.EmployeeSearchBy.EMPLOYEE_ID, Constants.DropDownItem.EmployeeSearchBy.EMPLOYEE_ID));
                drp.Items.Add(new ListItem(Constants.DropDownItem.EmployeeSearchBy.DEPARTMENT, Constants.DropDownItem.EmployeeSearchBy.DEPARTMENT));
            }
        }
        private IList<object[]> getDrpItems(ISession session, DrpDataType drpDataType, string additionalInfo, string firmNumber)
        {
            IList<object[]> result = null;
            if (DrpDataType.MASTER_CONTROL_DATA == drpDataType)
            {
                result = session.QueryOver<MasterControlData>().Select(c => c.Name,
                            c => c.Id).Where(c => c.FirmNumber == firmNumber && c.Type == additionalInfo).List<object[]>();
            }
            else if (DrpDataType.ENQUIRY_CUSTOMER_NAME == drpDataType)
            {
                result = session.QueryOver<EnquiryDetail>().Select(c => c.Id, c => c.FirstName + " " + c.LastName)
                        .Where(c => c.FirmNumber == firmNumber).List<object[]>();
            }
            else if (DrpDataType.PROPERTY_NAME == drpDataType)
            {
                result = session.QueryOver<Property>().Select(p => p.Name, p => p.Id)
                        .Where(p => p.FirmNumber == firmNumber).List<object[]>();
            }
            else if (DrpDataType.DEPARTMENT == drpDataType)
            {
                result = session.QueryOver<Department>().Select(p => p.Name, p => p.Id)
                        .Where(p => p.FirmNumber == firmNumber).List<object[]>();
            }
            return result;
        }
        private void addItemsToDropDown(DropDownList drp, IList<object[]> result)
        {
            if (result != null)
            {
                foreach (object[] obj in result)
                {
                    drp.Items.Add(new ListItem((string)obj[0], obj[1]+""));
                }
            }
        }
    }
}