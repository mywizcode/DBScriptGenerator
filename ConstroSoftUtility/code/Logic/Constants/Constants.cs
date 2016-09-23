using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Constants.
/// </summary>
namespace ConstroSoft
{
    public static class Constants
    {
        //Page Constants
        public class URL
        {
            public const string HOME = "Home";
            public const string LOGIN = "Login";
        }
        public class Session
        {
            public const string USERDEFINITION = "USERDEFINITION";
            public const string USERNAME = "USERNAME";
        }
        public class Entitlement
        {
            public const string MENU_DASHBOARD = "MENU_DASHBOARD";
            public const string MENU_ENQUIRY_MANAGEMENT = "MENU_ENQUIRY_MANAGEMENT";
            public const string MENU_FIRM_MANAGEMENT = "MENU_FIRM_MANAGEMENT";
            public const string MENU_PROPERTY_MANAGEMENT = "MENU_PROPERTY_MANAGEMENT";
            public const string MENU_CUSTOMER_MANAGEMENT = "MENU_CUSTOMER_MANAGEMENT";
            public const string MENU_SALES_MANAGEMENT = "MENU_SALES_MANAGEMENT";
            public const string MENU_PAYMENT_MANAGEMENT = "MENU_PAYMENT_MANAGEMENT";
            public const string MENU_PURCHASE_MANAGEMENT = "MENU_PURCHASE_MANAGEMENT";
            public const string MENU_CONTRACTOR_MANAGEMENT = "MENU_CONTRACTOR_MANAGEMENT";
            public const string MENU_EMPLOYEE_MANAGEMENT = "MENU_EMPLOYEE_MANAGEMENT";
            public const string MENU_REPORTS_AND_ANALYTICS = "MENU_REPORTS_AND_ANALYTICS";
            public const string MENU_PROMOTION_MANAGEMENT = "MENU_PROMOTION_MANAGEMENT";
            public const string MENU_BACKGROUND_MANAGEMENT = "MENU_BACKGROUND_MANAGEMENT";
            public const string MENU_DAILY_PLANNER = "MENU_DAILY_PLANNER";
            public const string MENU_MASTER_CONTROL_DATA = "MENU_MASTER_CONTROL_DATA";
            public const string FIRM_ACCOUNT_ADD_UPDATE = "FIRM_ACCOUNT_ADD_UPDATE";
        }
        public class DropDownType
        {
            public const string STATIC_VALUE = "STATIC_VALUE";
            public const string DB_VALUE = "DB_VALUE";
        }
        public class DropDownItem
        {
            public const string SELECT = "-- Select --";
            public const string SELECT_VALUE = "";
            public class EnquirySearchBy
            {
                public const string CUSTOMER_NAME = "Customer Name";
                public const string PROP_NAME = "Property Name";
                public const string PROP_TYPE = "Property Type";
                public const string PROP_LOCATION = "Property Location";
                public const string PROP_UNIT_TYPE = "Property Unit Type";
            }
            public class EmployeeSearchBy
            {
                public const string EMPLOYEE_NAME = "Employee Name";
                public const string EMPLOYEE_ID = "Employee Id";
                public const string DEPARTMENT = "Department";
            }
            public class Gender
            {
                public const string MALE = "Male";
                public const string MALE_VALUE = "M";
                public const string FEMALE = "Female";
                public const string FEMALE_VALUE = "F";
            }
            public class MaritalStatus
            {
                public const string SINGLE = "Single";
                public const string SINGLE_VALUE = "S";
                public const string MARRIED = "Married";
                public const string MARRIED_VALUE = "M";
            }
            public class EnquiryStatus
            {
                public const string OPEN = "Open";
                public const string CLOSED = "Closed";
            }
        }
        public class MCDType
        {
            public const string SALUTATION = "SALUTATION";
            public const string DESIGNATION = "DESIGNATION";
            public const string SECURITY_QUESTION = "SECURITY_QUESTION";
            public const string ACCOUNT_TYPE = "ACCOUNT_TYPE";
            public const string PROPERTY_TYPE = "PROPERTY_TYPE";
            public const string PROPERTY_LOCATION = "PROPERTY_LOCATION";
            public const string PR_TAX_TYPE = "PR_TAX_TYPE";
            public const string PR_EXPENSE_TYPE = "PR_EXPENSE_TYPE";
            public const string PR_UNIT_TYPE = "PR_UNIT_TYPE";
            public const string PR_UNIT_PARKING_TYPE = "PR_UNIT_PARKING_TYPE";
            public const string PR_UNIT_FACING = "PR_UNIT_FACING";
            public const string PR_UNIT_DIRECTION = "PR_UNIT_DIRECTION";
            public const string OCCUPATION = "OCCUPATION";
            public const string CUSTOMER_RELATION = "CUSTOMER_RELATION";
            public const string PR_UNIT_PYMT_TYPE = "PR_UNIT_PYMT_TYPE";
            public const string SUPPLIER_TYPE = "SUPPLIER_TYPE";
            public const string PURCHASE_ITEM_QUALITY = "PURCHASE_ITEM_QUALITY";
            public const string CONTRACTOR_TYPE = "CONTRACTOR_TYPE";
            public const string ENQUIRY_SOURCE = "ENQUIRY_SOURCE";
            public const string ENQUIRY_MEDIA_TYPE = "ENQUIRY_MEDIA_TYPE";
            public const string DOCUMENT_TYPE = "DOCUMENT_TYPE";
        }

        public const string DATE_FORMAT = "dd-MMM-yyyy";
        public const string PAYMENT_STATUS_UNPAID = "UNPAID";
        public const string PAYMENT_STATUS_PAID = "PAID";
        public const string PAYMENT_TRANSACTION_STATUS_PAID = "PAID";
        public const string PAYMENT_TRANSACTION_STATUS_CANCELLED = "CANCELLED";
        public const string PAYMENT_TRANSACTION_STATUS_REVERSED = "REVERSED";
        public const string PAYMENT_TRANSACTION_STATUS_PENDING = "PENDING";
        public const string PAYMENT_TRANSACTION_STATUS_DEPOSITED = "DEPOSITED";
        public const string PAYMENT_TRANSACTION_MODE_CASH = "CASH";
        public const string PAYMENT_TRANSACTION_MODE_CHEQUE = "CHEQUE";
        
        public const string PAYMENT_TRANSACTION_TYPE_PDC = "PDC";


        public const string BUILDER_TAB1_NAME = "Builder List";
        public const string BUILDER_TAB2_NAME_ADD = "Add Builder";
        public const string BUILDER_TAB2_NAME_EDIT = "Edit Builder";
        public const string BUILDER_TAB2_NAME_VIEW = "View Builder";

        public const string BUILDER_PYMT_TAB1_NAME = "Builder Payment List";
        public const string BUILDER_PYMT_TAB2_NAME_ADD = "Add Builder Payment";
        public const string BUILDER_PYMT_TAB2_NAME_EDIT = "Edit Builder Payment";
        public const string BUILDER_PYMT_TAB2_NAME_VIEW = "View Builder Payment";

        public const string PAYMENT_TAB3_NAME_ADD = "Add Payment";
        public const string PAYMENT_TAB3_NAME_EDIT = "Edit Payment";
        public const string PAYMENT_TAB3_NAME_VIEW = "View Payment";
    }
}