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
    /// There are no comments for ConstroSoftNH.FirmAccount, ConstroSoftNH in the schema.
    /// </summary>
    public partial class FirmAccount {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for FirmAccount constructor in the schema.
        /// </summary>
        public FirmAccount()
        {
            this.InsertDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
            this.Version = 0;
            this.AccountTransactions = new HashSet<AccountTransaction>();
            this.ContractorPayments = new HashSet<ContractorPayment>();
            this.FirmAcntDeposites = new HashSet<FirmAcntDeposite>();
            this.Properties = new HashSet<Property>();
            this.PurchaseMasters = new HashSet<PurchaseMaster>();
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
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountNo in the schema.
        /// </summary>
        public virtual string AccountNo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountBalance in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> AccountBalance
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IfscCode in the schema.
        /// </summary>
        public virtual string IfscCode
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
        /// There are no comments for Branch in the schema.
        /// </summary>
        public virtual string Branch
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
        /// There are no comments for AccountTransactions in the schema.
        /// </summary>
        public virtual ISet<AccountTransaction> AccountTransactions
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for City in the schema.
        /// </summary>
        public virtual City City
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContractorPayments in the schema.
        /// </summary>
        public virtual ISet<ContractorPayment> ContractorPayments
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Country in the schema.
        /// </summary>
        public virtual Country Country
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Firm in the schema.
        /// </summary>
        public virtual Firm Firm
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MasterControlDatum in the schema.
        /// </summary>
        public virtual MasterControlDatum MasterControlDatum
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for State in the schema.
        /// </summary>
        public virtual State State
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirmAcntDeposites in the schema.
        /// </summary>
        public virtual ISet<FirmAcntDeposite> FirmAcntDeposites
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Properties in the schema.
        /// </summary>
        public virtual ISet<Property> Properties
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchaseMasters in the schema.
        /// </summary>
        public virtual ISet<PurchaseMaster> PurchaseMasters
        {
            get;
            set;
        }
    }

}
