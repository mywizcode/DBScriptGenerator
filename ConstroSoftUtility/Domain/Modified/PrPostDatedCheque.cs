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

namespace ConstroSoft
{

    /// <summary>
    /// There are no comments for ConstroSoft.PrPostDatedCheque, ConstroSoft in the schema.
    /// </summary>
    public partial class PrPostDatedCheque {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for PrPostDatedCheque constructor in the schema.
        /// </summary>
        public PrPostDatedCheque()
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
        /// There are no comments for TxDate in the schema.
        /// </summary>
        public virtual System.DateTime TxDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ChequeDate in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> ChequeDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PymtAmt in the schema.
        /// </summary>
        public virtual decimal PymtAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankName in the schema.
        /// </summary>
        public virtual string BankName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ChequeNo in the schema.
        /// </summary>
        public virtual string ChequeNo
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
        /// There are no comments for Status in the schema.
        /// </summary>
        public virtual string Status
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
        /// There are no comments for PaymentMaster in the schema.
        /// </summary>
        public virtual PaymentMaster PaymentMaster
        {
            get;
            set;
        }
    }

}
