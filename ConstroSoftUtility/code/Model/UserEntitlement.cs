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
    /// There are no comments for ConstroSoft.UserEntitlement in the schema.
    /// </summary>
    public partial class UserEntitlement {
    
        #region Extensibility Method Definitions
        
        /// <summary>
        /// There are no comments for OnCreated in the schema.
        /// </summary>
        partial void OnCreated();
        
        #endregion
        /// <summary>
        /// There are no comments for UserEntitlement constructor in the schema.
        /// </summary>
        public UserEntitlement()
        {
            this.UserRoles = new HashSet<UserRole>();
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
        /// There are no comments for Level in the schema.
        /// </summary>
        public virtual int Level
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
        /// There are no comments for UserEntitlement_PARENT_ID in the schema.
        /// </summary>
        public virtual UserEntitlement parent
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserRoles in the schema.
        /// </summary>
        public virtual ISet<UserRole> UserRoles
        {
            get;
            set;
        }
    }

}
