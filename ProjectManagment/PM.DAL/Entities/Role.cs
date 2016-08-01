﻿using System;
using System.Collections.Generic;

namespace PM.DAL.Entities
{
    /// <summary>
    /// Role entity.
    /// </summary>
    public class Role
    {
        #region Fields

        private ICollection<User> _users;

        #endregion Fields

        #region Scalar Properties

        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public Guid RoleId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        #endregion Scalar Properies

        #region Navigation Properties

        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public ICollection<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
            set { _users = value; }
        }

        #endregion Navigation Properties
    }
}
 