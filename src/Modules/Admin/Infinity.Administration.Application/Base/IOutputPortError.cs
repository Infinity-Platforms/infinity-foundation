namespace Infinity.Administration.Application.Base
{
    public interface IOutputPortError
    {
        /// <summary>
        /// Informs an error happened.
        /// </summary>
        /// <param name="message">Text description.</param>
        void WriteError(string message);

        /// <summary>
        /// Informs errors happened.
        /// </summary>
        /// <param name="message">The message.</param>
        void WriteError(string[] message);
    }
}
