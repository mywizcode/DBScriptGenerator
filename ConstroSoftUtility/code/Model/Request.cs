﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// Code is generated on: 9/3/2016 2:47:10 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.Generic;


namespace ConstroSoft
{

    /// <summary>
    /// There are no comments for ConstroSoft.Request in the schema.
    /// </summary>
    public partial class Request {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for Request constructor in the schema.
        /// </summary>
        public Request()
        {
            this.InsertDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
            this.Version = 0;
            this.BulkDemandLetters = new HashSet<BulkDemandLetter>();
            OnCreated();
        }

    
        /// <summary>
        /// There are no comments for Id in the schema.
        /// </summary>
        public virtual long Id
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ReqIdentifier in the schema.
        /// </summary>
        public virtual string ReqIdentifier
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RequestType in the schema.
        /// </summary>
        public virtual string RequestType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GeneratedDate in the schema.
        /// </summary>
        public virtual System.DateTime GeneratedDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GeneratedBy in the schema.
        /// </summary>
        public virtual string GeneratedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StartTime in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> StartTime
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EndTime in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> EndTime
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        public virtual string Status
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SuccessMessage in the schema.
        /// </summary>
        public virtual string SuccessMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FailureMessage in the schema.
        /// </summary>
        public virtual string FailureMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirmNumber in the schema.
        /// </summary>
        public virtual string FirmNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InsertDate in the schema.
        /// </summary>
        public virtual System.DateTime InsertDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UpdateDate in the schema.
        /// </summary>
        public virtual System.DateTime UpdateDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Version in the schema.
        /// </summary>
        public virtual long Version
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InsertUser in the schema.
        /// </summary>
        public virtual string InsertUser
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UpdateUser in the schema.
        /// </summary>
        public virtual string UpdateUser
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BulkDemandLetters in the schema.
        /// </summary>
        public virtual ISet<BulkDemandLetter> BulkDemandLetters
        {
            get;
            set;
        }
    }

}
