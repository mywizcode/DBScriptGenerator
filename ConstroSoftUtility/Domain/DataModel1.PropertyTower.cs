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
    /// There are no comments for ConstroSoftNH.PropertyTower, ConstroSoftNH in the schema.
    /// </summary>
    public partial class PropertyTower {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for PropertyTower constructor in the schema.
        /// </summary>
        public PropertyTower()
        {
            this.InsertDate = DateTime.Now;
            this.UpdateDate = DateTime.Now;
            this.Version = 0;
            this.PropertyParkings = new HashSet<PropertyParking>();
            this.PropertySchedules = new HashSet<PropertySchedule>();
            this.PropertyUnits = new HashSet<PropertyUnit>();
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
        /// There are no comments for Rate in the schema.
        /// </summary>
        public virtual System.Nullable<decimal> Rate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LaunchDate in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> LaunchDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Possession in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> Possession
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
        /// There are no comments for Property in the schema.
        /// </summary>
        public virtual Property Property
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
        /// There are no comments for PropertySchedules in the schema.
        /// </summary>
        public virtual ISet<PropertySchedule> PropertySchedules
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PropertyUnits in the schema.
        /// </summary>
        public virtual ISet<PropertyUnit> PropertyUnits
        {
            get;
            set;
        }
    }

}