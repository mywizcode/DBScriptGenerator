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
    /// There are no comments for ConstroSoft.PrUnitSaleDetail, ConstroSoft in the schema.
    /// </summary>
    public partial class PrUnitSaleDetail {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for PrUnitSaleDetail constructor in the schema.
        /// </summary>
        public PrUnitSaleDetail()
        {
            this.IsPossessionDone = @"N";
            this.IsAgreementDone = @"N";
            this.InsertDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
            this.Version = 0;
            this.BulkDemandLetters = new HashSet<BulkDemandLetter>();
            this.PrUnitSalePymts = new HashSet<PrUnitSalePymt>();
            this.PrUnitSaleTaxDetails = new HashSet<PrUnitSaleTaxDetail>();
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
        /// There are no comments for BookingDate in the schema.
        /// </summary>
        public virtual System.DateTime BookingDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SaleRate in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> SaleRate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PossessionDate in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> PossessionDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPossessionDone in the schema.
        /// </summary>
        public virtual string IsPossessionDone
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AgreementDate in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> AgreementDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsAgreementDone in the schema.
        /// </summary>
        public virtual string IsAgreementDone
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoanBankName in the schema.
        /// </summary>
        public virtual string LoanBankName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoanBankBranch in the schema.
        /// </summary>
        public virtual string LoanBankBranch
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoanAmt in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> LoanAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountAdjAmt in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> DiscountAdjAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AgreementAmt in the schema.
        /// </summary>
        public virtual decimal AgreementAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalTaxAmt in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> TotalTaxAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalOtherAmt in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> TotalOtherAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalPymtAmt in the schema.
        /// </summary>
        public virtual decimal TotalPymtAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalCashAmt in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> TotalCashAmt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalPackageCost in the schema.
        /// </summary>
        public virtual decimal TotalPackageCost
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancellationFee in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> CancellationFee
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
        /// There are no comments for BulkDemandLetters in the schema.
        /// </summary>
        public virtual ISet<BulkDemandLetter> BulkDemandLetters
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Customer in the schema.
        /// </summary>
        public virtual Customer Customer
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

    
        /// <summary>
        /// There are no comments for PropertyUnit in the schema.
        /// </summary>
        public virtual PropertyUnit PropertyUnit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PrUnitSalePymts in the schema.
        /// </summary>
        public virtual ISet<PrUnitSalePymt> PrUnitSalePymts
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PrUnitSaleTaxDetails in the schema.
        /// </summary>
        public virtual ISet<PrUnitSaleTaxDetail> PrUnitSaleTaxDetails
        {
            get;
            set;
        }
    }

}
