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
    /// There are no comments for ConstroSoftNH.PropertyUnit, ConstroSoftNH in the schema.
    /// </summary>
    public partial class PropertyUnit {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for PropertyUnit constructor in the schema.
        /// </summary>
        public PropertyUnit()
        {
            this.InsertDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
            this.Version = 0;
            this.PrUnitSaleDetails = new HashSet<PrUnitSaleDetail>();
            this.PropertyParkings = new HashSet<PropertyParking>();
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
        /// There are no comments for Wing in the schema.
        /// </summary>
        public virtual string Wing
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FloorNo in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> FloorNo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UnitNo in the schema.
        /// </summary>
        public virtual string UnitNo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuildupArea in the schema.
        /// </summary>
        public virtual decimal BuildupArea
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CarpetArea in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> CarpetArea
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BalconyArea in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> BalconyArea
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
        /// There are no comments for MasterControlDatum_UNIT_TYPE_ID in the schema.
        /// </summary>
        public virtual MasterControlDatum MasterControlDatum_UNIT_TYPE_ID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MasterControlDatum_FACING in the schema.
        /// </summary>
        public virtual MasterControlDatum MasterControlDatum_FACING
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MasterControlDatum_DIRECTION in the schema.
        /// </summary>
        public virtual MasterControlDatum MasterControlDatum_DIRECTION
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PrUnitSaleDetails in the schema.
        /// </summary>
        public virtual ISet<PrUnitSaleDetail> PrUnitSaleDetails
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PropertyParkings in the schema.
        /// </summary>
        public virtual ISet<PropertyParking> PropertyParkings
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PropertyTower in the schema.
        /// </summary>
        public virtual PropertyTower PropertyTower
        {
            get;
            set;
        }
    }

}
