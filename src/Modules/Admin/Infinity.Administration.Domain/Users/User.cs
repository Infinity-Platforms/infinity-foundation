namespace Infinity.Administration.Domain.Users
{
    using Infinity.Administration.Domain.Base;

    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    public abstract class User : BaseEntity, IUser
    {
        /// <summary>
        /// Gets or sets the Guid
        /// </summary>
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

        /// <summary>
        /// Gets or sets the Phones
        /// </summary>
        public string[] Phones { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether IsActive
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            return Firstname + " " + Lastname;
        }
    }
}
