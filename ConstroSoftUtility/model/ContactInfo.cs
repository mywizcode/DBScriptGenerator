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
    /// There are no comments for ConstroSoft.ContactInfo in the schema.
    /// </summary>
    public partial class ContactInfo {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for ContactInfo constructor in the schema.
        /// </summary>
        public ContactInfo()
        {
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
        /// There are no comments for Contact in the schema.
        /// </summary>
        public virtual string Contact
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AltContact in the schema.
        /// </summary>
        public virtual string AltContact
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Gender in the schema.
        /// </summary>
        public virtual string Gender
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MaritalStatus in the schema.
        /// </summary>
        public virtual string MaritalStatus
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        public virtual string Email
        {
            get;
            set;
        }

        /// <summary>
        /// There are no comments for Email in the schema.
        /// </summary>
        public virtual string AltEmail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Dob in the schema.
        /// </summary>
        public virtual System.Nullable<System.DateTime> Dob
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentAddressLine1 in the schema.
        /// </summary>
        public virtual string CurrentAddressLine1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentAddressLine2 in the schema.
        /// </summary>
        public virtual string CurrentAddressLine2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentTown in the schema.
        /// </summary>
        public virtual string CurrentTown
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentCity in the schema.
        /// </summary>
        public virtual string CurrentCity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentState in the schema.
        /// </summary>
        public virtual string CurrentState
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentCountry in the schema.
        /// </summary>
        public virtual string CurrentCountry
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrentPin in the schema.
        /// </summary>
        public virtual string CurrentPin
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PerAddressLine1 in the schema.
        /// </summary>
        public virtual string PerAddressLine1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PerAddressLine2 in the schema.
        /// </summary>
        public virtual string PerAddressLine2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PerTown in the schema.
        /// </summary>
        public virtual string PerTown
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PerCity in the schema.
        /// </summary>
        public virtual string PerCity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PerState in the schema.
        /// </summary>
        public virtual string PerState
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PerCountry in the schema.
        /// </summary>
        public virtual string PerCountry
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PerPin in the schema.
        /// </summary>
        public virtual string PerPin
        {
            get;
            set;
        }
    }

}
