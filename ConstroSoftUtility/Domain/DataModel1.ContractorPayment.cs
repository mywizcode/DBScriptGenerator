﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using NHibernate template.
// Code is generated on: 21/09/2016 9:37:15 PM
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

namespace ConstroSoftNH
{

    /// <summary>
    /// There are no comments for ConstroSoftNH.ContractorPayment, ConstroSoftNH in the schema.
    /// </summary>
    public partial class ContractorPayment {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for ContractorPayment constructor in the schema.
        /// </summary>
        public ContractorPayment()
        {
            this.InsertDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
            this.Version = 0;
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
        /// There are no comments for FromDate in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> FromDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ToDate in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> ToDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Tds in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> Tds
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OtherDeduction in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> OtherDeduction
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Tax in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> Tax
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentAmt in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> PaymentAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalAmt in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> TotalAmt
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
        /// There are no comments for Contractor in the schema.
        /// </summary>
        public virtual Contractor Contractor
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Property in the schema.
        /// </summary>
        public virtual Property Property
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirmAccount in the schema.
        /// </summary>
        public virtual FirmAccount FirmAccount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirmMember in the schema.
        /// </summary>
        public virtual FirmMember FirmMember
        {
            get;
            set;
        }
    }

}
