namespace FactOff.Models
{
    /// <summary>
    /// Model View for the Error page in the Shared folder.
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// The requested id.
        /// </summary>
        public string RequestId { get; set; }

        /// <summary>
        /// Can the requested if be shown.
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}