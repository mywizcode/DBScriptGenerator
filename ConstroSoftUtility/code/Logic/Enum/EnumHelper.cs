
/// <summary>
/// Summary description for MyENUM
/// </summary>

using System;
namespace ConstroSoft
{
    public enum UserStatus
    {
        ACTIVE,
        DEACTIVE,
    }
    public class UserStatusStringType : NHibernate.Type.EnumStringType
    {
        public UserStatusStringType()
            : base(typeof(UserStatus), 20)
        {
        }
        public override object GetValue(object enm)
        {
            if (null == enm)
                return String.Empty;

            switch ((UserStatus)enm)
            {
                case UserStatus.ACTIVE: return "ACTIVE";
                case UserStatus.DEACTIVE: return "DEACTIVE";
                default: throw new ArgumentException("Invalid UserStatus.");
            }
        }
        public override object GetInstance(object code)
        {
            if ("ACTIVE".Equals(code))
                return UserStatus.ACTIVE;
            else if ("DEACTIVE".Equals(code))
                return UserStatus.DEACTIVE;

            throw new ArgumentException(
                "Cannot convert value '" + code + "' to UserStatus.");
        }
    }
    public enum DrpDataType
    {
        MASTER_CONTROL_DATA,
        ENQUIRY_SEARCH_BY,
        ENQUIRY_STATUS,
        ENQUIRY_CUSTOMER_NAME,
        EMPLOYEE_SEARCH_BY,
        GENDER,
        MARITAL_STATUS,
        PROPERTY_NAME,
        EMPLOYEE_NAME,
        DEPARTMENT,
    }
    public enum PageMode
    {
        ADD,
        MODIFY,
        VIEW,
        NONE,
    }
}