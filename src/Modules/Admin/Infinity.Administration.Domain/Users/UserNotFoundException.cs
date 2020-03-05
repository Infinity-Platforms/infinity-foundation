namespace Domain.Customers
{
    using Infinity.Shared.Domain;
    using System;

    /// <summary>
    ///     Customer Not Found Exception.
    /// </summary>
    public sealed class UserNotFoundException : DomainException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CustomerNotFoundException" /> class.
        /// </summary>
        /// <param name="message">Message.</param>
        public UserNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// </summary>
        public UserNotFoundException()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public UserNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
