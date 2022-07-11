using System.Collections.Generic;

namespace EasyVCR
{
    /// <summary>
    ///     Static values used as defaults for EasyVCR.
    /// </summary>
    internal static class Defaults
    {
        internal const string ViaRecordingHeaderKey = "X-Via-EasyVCR-Recording";

        /// <summary>
        ///     Default headers to add to replayed requests.
        /// </summary>
        internal static readonly Dictionary<string, object> ReplayHeaders = new Dictionary<string, object>
        {
            { ViaRecordingHeaderKey, "true" }
        };

        /// <summary>
        ///     Default list of headers to censor in the cassettes.
        /// </summary>
        internal static List<string> CredentialHeadersToHide => new List<string>
        {
            "authorization"
        };

        /// <summary>
        ///     Default list of parameters to censor in the cassettes.
        /// </summary>
        internal static List<string> CredentialParametersToHide => new List<string>
        {
            "api_key",
            "apiKey",
            "key",
            "api_token",
            "apiToken",
            "token",
            "access_token",
            "client_id",
            "client_secret",
            "password",
            "secret",
            "username"
        };
    }
}
