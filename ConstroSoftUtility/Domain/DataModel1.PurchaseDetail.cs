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
    /// There are no comments for ConstroSoftNH.PurchaseDetail, ConstroSoftNH in the schema.
    /// </summary>
    public partial class PurchaseDetail {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for PurchaseDetail constructor in the schema.
        /// </summary>
        public PurchaseDetail()
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
        /// There are no comments for Quantity in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> Quantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Rate in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> Rate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Amount in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> Amount
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
        /// There are no comments for MasterControlDatum in the schema.
        /// </summary>
        public virtual MasterControlDatum MasterControlDatum
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PurchaseMaster in the schema.
        /// </summary>
        public virtual PurchaseMaster PurchaseMaster
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StockItem in the schema.
        /// </summary>
        public virtual StockItem StockItem
        {
            get;
            set;
        }
    }

}
