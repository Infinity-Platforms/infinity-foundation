namespace Infinity.Shared.Domain.Messages
{
    /// <summary>
    /// Defines the <see cref="ActionMessage" />
    /// </summary>
    public class ActionMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionMessage"/> class.
        /// </summary>
        /// <param name="text">The text<see cref="string"/></param>
        /// <param name="type">The type<see cref="string"/></param>
        public ActionMessage(string text, string type)
        {
            Text = text;
            Type = type;
        }

        /// <summary>
        /// Gets or sets the Text
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the Type
        /// </summary>
        public string Type { get; set; }
    }
}
