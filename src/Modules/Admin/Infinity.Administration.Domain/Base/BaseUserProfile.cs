using System;
using System.Collections.Generic;
using System.Text;

namespace Infinity.Administration.Domain.Base
{
    public class BaseUserProfile: BaseEntity
    {
        public string Guid { get; set; }

        /// <summary>
        /// Gets or sets the Firstname
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Gets or sets the Lastname
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        public string Email { get; set; }
    }
}
