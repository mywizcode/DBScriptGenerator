using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class is output TO. Holds status & messages for operation done in business layer.
/// </summary>
namespace ConstroSoft
{
    public class BusinessOutputTO
    {
        public BusinessOutputTO()
        {
            this.status = Status.SUCCESS;
        }
        public enum Status
        {
            SUCCESS,
            FAILURE,
            SUCESS_NODATA
        };
        public Status status { get; set; }
        public string successMessage { get; set; }
        public string errorMessage { get; set; }
        public Object result { get; set; }
        public List<Object> resultList { get; set; }
        public void setErrorMessage(string message)
        {
            this.errorMessage = message;
            this.status = Status.FAILURE;
        }
    }
}