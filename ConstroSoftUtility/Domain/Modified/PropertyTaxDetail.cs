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
    /// There are no comments for ConstroSoft.PropertyTaxDetail, ConstroSoft in the schema.
    /// </summary>
    public partial class PropertyTaxDetail {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for PropertyTaxDetail constructor in the schema.
        /// </summary>
        public PropertyTaxDetail()
        {
            this.TaxPercentage = 0.000m;
            this.IncludeInTotalPymt = @"Y";
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
        /// There are no comments for TaxPercentage in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> TaxPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IncludeInTotalPymt in the schema.
        /// </summary>
        public virtual string IncludeInTotalPymt
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxAmtLimit in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> TaxAmtLimit
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
        /// There are no comments for MasterControlData in the schema.
        /// </summary>
        public virtual MasterControlData MasterControlData
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
    }

}
