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
    /// There are no comments for ConstroSoftNH.ContactInfo, ConstroSoftNH in the schema.
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
            this.CoCustomers = new HashSet<CoCustomer>();
            this.Contractors = new HashSet<Contractor>();
            this.Customers = new HashSet<Customer>();
            this.EnquiryDetails = new HashSet<EnquiryDetail>();
            this.Firms = new HashSet<Firm>();
            this.FirmMembers = new HashSet<FirmMember>();
            this.Properties = new HashSet<Property>();
            this.Suppliers = new HashSet<Supplier>();
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
        /// There are no comments for AltEmail in the schema.
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
        /// There are no comments for CoCustomers in the schema.
        /// </summary>
        public virtual ISet<CoCustomer> CoCustomers
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Contractors in the schema.
        /// </summary>
        public virtual ISet<Contractor> Contractors
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Customers in the schema.
        /// </summary>
        public virtual ISet<Customer> Customers
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
        /// There are no comments for Firms in the schema.
        /// </summary>
        public virtual ISet<Firm> Firms
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FirmMembers in the schema.
        /// </summary>
        public virtual ISet<FirmMember> FirmMembers
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
        /// There are no comments for Suppliers in the schema.
        /// </summary>
        public virtual ISet<Supplier> Suppliers
        {
            get;
            set;
        }
    }

}
