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
    /// There are no comments for ConstroSoft.StockDetail in the schema.
    /// </summary>
    public partial class StockDetail {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for StockDetail constructor in the schema.
        /// </summary>
        public StockDetail()
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
        /// There are no comments for Date in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> Date
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
        /// There are no comments for InvoiceNo in the schema.
        /// </summary>
        public virtual string InvoiceNo
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
        /// There are no comments for StockMaster in the schema.
        /// </summary>
        public virtual StockMaster StockMaster
        {
            get;
            set;
        }
    }

}
