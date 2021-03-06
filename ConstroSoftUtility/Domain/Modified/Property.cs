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
    /// There are no comments for ConstroSoft.Property, ConstroSoft in the schema.
    /// </summary>
    public partial class Property {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for Property constructor in the schema.
        /// </summary>
        public Property()
        {
            this.InsertDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
            this.Version = 0;
            this.ContractorPayments = new HashSet<ContractorPayment>();
            this.EnquiryDetails = new HashSet<EnquiryDetail>();
            this.PropertyAmenities = new HashSet<PropertyAmenity>();
            this.PropertyCharges = new HashSet<PropertyCharge>();
            this.PropertyExpenses = new HashSet<PropertyExpense>();
            this.PropertyTaxDetails = new HashSet<PropertyTaxDetail>();
            this.PropertyTowers = new HashSet<PropertyTower>();
            this.PurchaseMasters = new HashSet<PurchaseMaster>();
            this.StockMasters = new HashSet<StockMaster>();
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
        /// There are no comments for PropertyArea in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> PropertyArea
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
        /// There are no comments for EstimatedAmt in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> EstimatedAmt
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
        /// There are no comments for ContactInfo in the schema.
        /// </summary>
        public virtual ContactInfo ContactInfo
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
        /// There are no comments for EnquiryDetails in the schema.
        /// </summary>
        public virtual ISet<EnquiryDetail> EnquiryDetails
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
        /// There are no comments for MasterControlData_TYPE_ID in the schema.
        /// </summary>
        public virtual MasterControlData TypeId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MasterControlData_LOCATION_ID in the schema.
        /// </summary>
        public virtual MasterControlData LocationId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PropertyAmenities in the schema.
        /// </summary>
        public virtual ISet<PropertyAmenity> PropertyAmenities
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PropertyCharges in the schema.
        /// </summary>
        public virtual ISet<PropertyCharge> PropertyCharges
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PropertyExpenses in the schema.
        /// </summary>
        public virtual ISet<PropertyExpense> PropertyExpenses
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PropertyTaxDetails in the schema.
        /// </summary>
        public virtual ISet<PropertyTaxDetail> PropertyTaxDetails
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PropertyTowers in the schema.
        /// </summary>
        public virtual ISet<PropertyTower> PropertyTowers
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

    
        /// <summary>
        /// There are no comments for StockMasters in the schema.
        /// </summary>
        public virtual ISet<StockMaster> StockMasters
        {
            get;
            set;
        }
    }

}
